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

        public DeviceState Status;
        public MemoryMapping Mapping;

        public enum DeviceState
        {
            SNIOffline = 0,
            NoDevice = 1,
            DeviceStandby = 2, //device is recognized, ROM not loaded
            DeviceRunning = 3, //ROM is loaded
            DeviceRunningLive = 4 //ROM is loaded, in-game, actively being played by user
        }

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
            Devices = new List<DevicesResponse.Types.Device>();

            DevicesRequest req = new DevicesRequest();
            DevicesResponse res = DevicesClient.ListDevices(req);
                
            foreach (var d in res.Devices)
            {
                Devices.Add(d);
            }
        }

        public byte Read(uint address, byte nullValue = 0)
        {
            SingleReadMemoryRequest req = new SingleReadMemoryRequest();
            req.Uri = Devices[0].Uri;
            req.Request = new ReadMemoryRequest();
            req.Request.RequestAddress = address;
            req.Request.RequestAddressSpace = AddressSpace.SnesAbus;
            req.Request.RequestMemoryMapping = MemoryMapping.LoRom;
            req.Request.Size = 1;
            try
            {
                SingleReadMemoryResponse res = DeviceMemoryClient.SingleRead(req);

                return res.Response.Data[0];
            }
            catch (RpcException ex)
            {
                ex = ex;
            }
            return nullValue;
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
                    if (ex.StatusCode == StatusCode.Unknown && ex.Status.Detail == "fxpakpro: could not acquire NMI EXE pre-write: context deadline exceeded")
                    {
                        //console should be reset
                    }
                    else
                    {
                        Console.WriteLine("Write Failed: " + ex);
                        Status = DeviceState.SNIOffline;
                    }
                }

                System.Threading.Thread.Sleep(50);
                tries--;
            }
        }

        public void UpdateCurrentState()
        {
            if (Status == DeviceState.SNIOffline || Status == DeviceState.NoDevice)
            {
                try
                {
                    if (Devices == null)
                    {
                        Devices = new List<DevicesResponse.Types.Device>();
                    }

                    DevicesRequest req3 = new DevicesRequest();
                    DevicesResponse res = DevicesClient.ListDevices(req3);

                    foreach (var d in Devices)
                    {
                        if (!res.Devices.Contains(d))
                        {
                            Devices.Remove(d);
                        }
                    }

                    foreach (var d in res.Devices)
                    {
                        if (!Devices.Contains(d))
                        {
                            Devices.Add(d);
                        }
                    }

                    if (res.Devices.Count == 0)
                    {
                        Status = DeviceState.NoDevice;
                        return;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Status = DeviceState.SNIOffline;
                    return;
                }
                catch (RpcException ex)
                {
                    Status = DeviceState.SNIOffline;
                    return;
                }
            }

            if (Status != DeviceState.DeviceRunning && Status != DeviceState.DeviceRunningLive)
            {
                DetectMemoryMappingRequest req = new DetectMemoryMappingRequest();
                req.Uri = Devices[0].Uri;
                try
                {
                    DetectMemoryMappingResponse res = DeviceMemoryClient.MappingDetect(req);
                    Mapping = res.MemoryMapping;
                }
                catch (RpcException ex)
                {
                    if (ex.Status.Detail.StartsWith("detect:"))
                    {
                        Status = DeviceState.NoDevice;
                        return;
                    }
                    else
                    {
                        Status = DeviceState.SNIOffline;
                        return;
                    }
                }
            }
            SingleReadMemoryRequest req2 = new SingleReadMemoryRequest();
            req2.Uri = Devices[0].Uri;
            req2.Request = new ReadMemoryRequest();
            req2.Request.RequestAddress = 0x7e0010;
            req2.Request.RequestAddressSpace = AddressSpace.SnesAbus;
            req2.Request.RequestMemoryMapping = Mapping;
            req2.Request.Size = 16;
            try
            {
                SingleReadMemoryResponse res = DeviceMemoryClient.SingleRead(req2);

                if ((res.Response.Data[0] == 0 && res.Response.Data[0xc] == 0x55) || res.Response.Data[0] == 0xaa || res.Response.Data[0xc] == 0x55)
                {
                    Status = DeviceState.DeviceStandby;
                    return;
                }
                else if (res.Response.Data[0] == 0x1b || res.Response.Data[0] > 0x05 && res.Response.Data[0] != 0x14 && res.Response.Data[0] < 0x1b) //game specific logic, this is lttp
                {
                    Status = DeviceState.DeviceRunningLive;
                }
                else
                {
                    Status = DeviceState.DeviceRunning;
                    return;
                }
            }
            catch (RpcException ex)
            {
                if (ex.Status.Detail.StartsWith("detect:"))
                {
                    Status = DeviceState.NoDevice;
                    return;
                }
                else
                {
                    Status = DeviceState.SNIOffline;
                    return;
                }
            }
        }

        public string GetROMHeader()
        {
            DetectMemoryMappingRequest req = new DetectMemoryMappingRequest();
            req.Uri = Devices[0].Uri;

            string header = "";
            try
            {
                DetectMemoryMappingResponse res = DeviceMemoryClient.MappingDetect(req);
                header = System.Text.Encoding.UTF8.GetString(res.RomHeader00FFB0.ToByteArray());
                if (header.Length > 37)
                {
                    header = header.Substring(16, 21);
                }
                header = System.Text.RegularExpressions.Regex.Replace(header, @"[^a-zA-Z\p{Nd}_\-&#x20;&#x25;]", "");
                if (!res.Confidence)
                {
                    return "NO-CONF-" + header;
                }
                return header;
            }
            catch (RpcException ex)
            {
                if (ex.StatusCode == StatusCode.Unknown)
                {
                    switch (ex.Status.Detail)
                    {
                        case "detect: fxpakpro: The device is not connected.: (FxPakPro $007fb0 Unknown)":
                            break;
                        case "detect: unable to detect valid ROM header":
                            header = "NO-ROM";
                            break;
                        default:
                            throw;
                    }
                }
                else
                {
                    throw;
                }
            }

            return header;
        }

        public void Dispose()
        {
            _channel.ShutdownAsync();
        }
    }
}
