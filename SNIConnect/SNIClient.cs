using System;
using System.Collections.Generic;
using Grpc.Core;
using SNI;

namespace SNIConnect
{
    public class SNIClient : IDisposable
    {
        public static string DEFAULT_IP = "127.0.0.1";
        public static int DEFAULT_PORT = 8191;

        private Channel _channel;
        readonly Devices.DevicesClient DevicesClient;
        readonly DeviceControl.DeviceControlClient DeviceControlClient;
        readonly DeviceMemory.DeviceMemoryClient DeviceMemoryClient;
        readonly DeviceFilesystem.DeviceFilesystemClient DeviceFilesystemClient;

        public List<DevicesResponse.Types.Device> Devices;

        public SNIClient(string address, int port)
        {
            _channel = new Channel(address, port, ChannelCredentials.Insecure);
            this.DevicesClient = new Devices.DevicesClient(_channel);
            this.DeviceControlClient = new DeviceControl.DeviceControlClient(_channel);
            this.DeviceMemoryClient = new DeviceMemory.DeviceMemoryClient(_channel);
            this.DeviceFilesystemClient = new DeviceFilesystem.DeviceFilesystemClient(_channel);
        }

        public static int GetGrpcPort()
        {
            string value = Environment.GetEnvironmentVariable("SNI_GRPC_LISTEN_PORT");
            int port = 0;
            int.TryParse(value, out port);
            if (port == 0)
            {
                port = DEFAULT_PORT;
            }
            return port;
        }

        public static string GetLocalGrpcAddress()
        {
            return string.Format("{0}:{1}", DEFAULT_IP, SNIClient.GetGrpcPort());
        }

        public void Connect()
        {
            DevicesRequest req = new DevicesRequest();
            DevicesResponse res = DevicesClient.ListDevices(req);

            Devices = new List<DevicesResponse.Types.Device>();
            foreach (var d in res.Devices)
            {
                Devices.Add(d);
            }
        }

        public byte Read(uint address)
        {
            SingleReadMemoryRequest req = new SingleReadMemoryRequest();
            req.Uri = Devices[0].Uri;
            req.Request = new ReadMemoryRequest();
            req.Request.RequestAddress = address;
            req.Request.RequestAddressSpace = AddressSpace.SnesAbus;
            req.Request.RequestMemoryMapping = MemoryMapping.LoRom;
            req.Request.Size = 1;
            SingleReadMemoryResponse res = DeviceMemoryClient.SingleRead(req);

            return res.Response.Data[0];
        }

        public byte[] Read(uint address, uint count)
        {
            int tries = 10;
            while (tries > 0)
            {
                try
                {
                    SingleReadMemoryRequest req = new SingleReadMemoryRequest();
                    req.Uri = Devices[0].Uri;
                    req.Request = new ReadMemoryRequest();
                    req.Request.RequestAddress = address;
                    req.Request.RequestAddressSpace = AddressSpace.SnesAbus;
                    req.Request.RequestMemoryMapping = MemoryMapping.LoRom;
                    req.Request.Size = count;
                    SingleReadMemoryResponse res = DeviceMemoryClient.SingleRead(req);

                    return res.Response.Data.ToByteArray();
                }
                catch (RpcException ex)
                {
                    Console.WriteLine("Read Failed: " + ex);
                }

                System.Threading.Thread.Sleep(50);
                tries--;
            }

            return null;
        }

        public void Write(uint address, byte value)
        {
            Write(address, new byte[] { value });
        }

        public void Write(uint address, ushort value)
        {
            Write(address, BitConverter.GetBytes(value));
        }

        public void Write(uint address, byte[] values)
        {
            int tries = 10;
            while (tries > 0)
            {
                try
                {
                    SingleWriteMemoryRequest req = new SingleWriteMemoryRequest();
                    req.Uri = Devices[0].Uri;
                    req.Request = new WriteMemoryRequest();
                    req.Request.RequestAddress = address;
                    req.Request.RequestAddressSpace = AddressSpace.SnesAbus;
                    req.Request.RequestMemoryMapping = MemoryMapping.LoRom;
                    req.Request.Data = Google.Protobuf.ByteString.CopyFrom(values);
                    SingleWriteMemoryResponse res = DeviceMemoryClient.SingleWrite(req);
                }
                catch (RpcException ex)
                {
                    Console.WriteLine("Write Failed: " + ex);
                }

                System.Threading.Thread.Sleep(50);
                tries--;
            }
        }

        public string GetROMHeader()
        {
            DetectMemoryMappingRequest req = new DetectMemoryMappingRequest();
            req.Uri = Devices[0].Uri;
            DetectMemoryMappingResponse res = DeviceMemoryClient.MappingDetect(req);
            string header = System.Text.Encoding.UTF8.GetString(res.RomHeader00FFB0.ToByteArray()).Substring(16, 21);
            header = header.Substring(0, header.IndexOf('\0'));
            return header;
        }

        public void Dispose()
        {
            _channel.ShutdownAsync();
        }
    }
}
