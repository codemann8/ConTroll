using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Types;
using Newtonsoft.Json;

namespace ConTroll
{   public class OBSConnect : IDisposable
    {
        public static string DEFAULT_ADDRESS = "ws://127.0.0.1:4444";

        public OBSWebsocket _obs;
        private Main _main;

        public OBSStatus Status;

        public OBSConnect(Main main)
        {
            _main = main;
            _obs = new OBSWebsocket();

            _obs.Connected += onConnect;
            _obs.Disconnected += onDisconnect;

            //obs.SceneChanged += onSceneChange;
            //obs.SceneCollectionChanged += onSceneColChange;
            //obs.ProfileChanged += onProfileChange;
            //obs.TransitionChanged += onTransitionChange;
            //obs.TransitionDurationChanged += onTransitionDurationChange;

            //obs.StreamingStateChanged += onStreamingStateChange;
            //obs.RecordingStateChanged += onRecordingStateChange;

            //_obs.StreamStatus += onStreamData;
        }

        public void Connect(string address, string password)
        {
            if (!_obs.IsConnected)
            {
                try
                {
                    _obs.Connect(address, password);
                }
                catch (AuthFailureException)
                {
                    Status = OBSStatus.AuthError;
                    _main.BeginInvoke((MethodInvoker)(() =>
                    {
                        _main.UpdateOBSStatus();
                    }));
                    MessageBox.Show("OBS Websocket authentication failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                catch (ErrorResponseException ex)
                {
                    Status = OBSStatus.Error;
                    _main.BeginInvoke((MethodInvoker)(() =>
                    {
                        _main.UpdateOBSStatus();
                    }));
                    MessageBox.Show("OBS Websocket connection failed : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            else
            {
                _obs.Disconnect();
                Connect(address, password);
            }
        }

        public void Disconnect()
        {
            _obs.Disconnect();
        }

        private void onConnect(object sender, EventArgs e)
        {
            Status = OBSStatus.Connected;
            _main.BeginInvoke((MethodInvoker)(() =>
            {
                _main.UpdateOBSStatus();
            }));
        }

        private void onDisconnect(object sender, EventArgs e)
        {
            Status = OBSStatus.Disconnected;
            _main.BeginInvoke((MethodInvoker)(() =>
            {
                _main.UpdateOBSStatus();
            }));
        }

        private void onSceneChange(OBSWebsocket sender, string newSceneName)
        {
            throw new NotImplementedException();
        }

        private void onSceneColChange(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void onProfileChange(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void onTransitionChange(OBSWebsocket sender, string newTransitionName)
        {
            throw new NotImplementedException();
        }

        private void onTransitionDurationChange(OBSWebsocket sender, int newDuration)
        {
            throw new NotImplementedException();
        }

        private void onStreamingStateChange(OBSWebsocket sender, OutputState newState)
        {
            throw new NotImplementedException();
        }

        private void onRecordingStateChange(OBSWebsocket sender, OutputState newState)
        {
            throw new NotImplementedException();
        }

        private void onStreamData(OBSWebsocket sender, StreamStatus data)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _obs.Disconnect();
        }

        public enum OBSStatus
        {
            Disconnected = 0,
            Connected = 1,
            AuthError = 2,
            Error = 3
        }

        // TODO: COnsider adding this to a global utility library
        public static void AddOrReplaceProperty(Newtonsoft.Json.Linq.JObject json, string property, Newtonsoft.Json.Linq.JToken value)
        {
            if (json.ContainsKey(property))
            {
                json.Property(property).Value = value;
            }
            else
            {
                json.Add(property, value);
            }
        }
    }
}
