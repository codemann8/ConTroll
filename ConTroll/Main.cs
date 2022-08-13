using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SNIConnect;

namespace ConTroll
{
    public partial class Main : Form
    {
        public SNIClient _sni;
        public OBSConnect _obs;
        public DistortionActivity _distort;
        public Database _database;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            AutoStartServices();

            Task.Run(() => {
                if (System.Threading.Thread.CurrentThread.Name == null)
                {
                    System.Threading.Thread.CurrentThread.Name = "Status Monitor";
                }

                Dictionary<SNIClient.DeviceState, int> pingFreq = new Dictionary<SNIClient.DeviceState, int>()
                {
                    { SNIClient.DeviceState.SNIOffline, 1000 },
                    { SNIClient.DeviceState.NoDevice, 1000 },
                    { SNIClient.DeviceState.DeviceStandby, 200 },
                    { SNIClient.DeviceState.DeviceRunning, 40 },
                    { SNIClient.DeviceState.DeviceRunningLive, 16 }
                };
                int updateUIFreq = 200;
                int counter = updateUIFreq + 1;
                while (true)
                {
                    bool updateDevices = _sni.Status == SNIClient.DeviceState.SNIOffline || _sni.Status == SNIClient.DeviceState.NoDevice;
                    _sni.UpdateCurrentState();
                    if (counter > updateUIFreq)
                    {
                        counter = 0;
                        this.BeginInvoke((MethodInvoker)(() =>
                        {
                            UpdateSNIStatus(updateDevices);
                        }));
                        Application.DoEvents();
                    }
                    counter += pingFreq[_sni.Status];
                    System.Threading.Thread.Sleep(pingFreq[_sni.Status]);
                }
            });
        }

        private void LoadSettings()
        {
            _database = new Database();

            if (_database.Settings.Connections.OBSAddress != "")
            {
                txtOBSAddress.Text = _database.Settings.Connections.OBSAddress;
                txtOBSAddress.ForeColor = SystemColors.WindowText;
            }    
            else
            {
                txtOBSAddress.Text = OBSConnect.DEFAULT_ADDRESS;
            }
            txtOBSPassword.Text = _database.Settings.Connections.OBSPassword;

            if (_database.Settings.Connections.SNIAddress != "")
            {
                txtSNIAddress.Text = _database.Settings.Connections.SNIAddress;
                txtSNIAddress.ForeColor = SystemColors.WindowText;
            }
            else
            {
                txtSNIAddress.Text = SNIClient.GetLocalGrpcAddress();
            }

            UpdateSNIClient();

            txtDistortInterval.Text = _database.Settings.SocialDistortion.Interval.ToString();
            txtDistortDuration.Text = _database.Settings.SocialDistortion.TransitionDuration.ToString();
            txtDistortTilt.Text = _database.Settings.SocialDistortion.MaxTilt.ToString();
            txtDistortAdjustX.Text = _database.Settings.SocialDistortion.AdjustmentX.ToString();
            txtDistortAdjustY.Text = _database.Settings.SocialDistortion.AdjustmentY.ToString();
            txtDistortColorDuration.Text = _database.Settings.SocialDistortion.ColorizeDuration.ToString();

            chkDistortMirrorX.CheckState = (CheckState)_database.Settings.SocialDistortion.MirrorHorizontal;
            chkDistortMirrorY.CheckState = (CheckState)_database.Settings.SocialDistortion.MirrorVertical;
            chkDistortRotate.CheckState = (CheckState)_database.Settings.SocialDistortion.Rotate;
            chkDistortZoom.CheckState = (CheckState)_database.Settings.SocialDistortion.ZoomIn;
            chkDistortScaleX.CheckState = (CheckState)_database.Settings.SocialDistortion.ScaleHorizontal;
            chkDistortScaleY.CheckState = (CheckState)_database.Settings.SocialDistortion.ScaleVertical;
            chkDistortShearX.CheckState = (CheckState)_database.Settings.SocialDistortion.ShearHorizontal;
            chkDistortShearY.CheckState = (CheckState)_database.Settings.SocialDistortion.ShearVertical;
            chkDistortColor.CheckState = (CheckState)_database.Settings.SocialDistortion.Colorize;

            if (_database.Settings.SocialDistortion.OBSSourceName != "")
            {
                var s = new OBSWebsocketDotNet.Types.SourceInfo();
                s.Name = _database.Settings.SocialDistortion.OBSSourceName;
                cboOBSGameSource.Items.Add(s);
                cboOBSGameSource.SelectedItem = s;
            }
        }

        public void AutoStartServices()
        {
            btnOBSStatus_Click(null, null);

            if (_obs != null && _obs.Status == OBSConnect.OBSStatus.Connected)
            {
                _distort = new DistortionActivity(this);
                _distort.Stop();
            }
        }

        #region Form Control Events

        private void txtOBSAddress_Enter(object sender, EventArgs e)
        {
            if (txtOBSAddress.Text == OBSConnect.DEFAULT_ADDRESS)
            {
                txtOBSAddress.Text = "";
                txtOBSAddress.ForeColor = SystemColors.WindowText;
            }
        }

        private void txtOBSAddress_Leave(object sender, EventArgs e)
        {
            if (txtOBSAddress.Text == "" || txtOBSAddress.Text == OBSConnect.DEFAULT_ADDRESS)
            {
                txtOBSAddress.Text = OBSConnect.DEFAULT_ADDRESS;
                txtOBSAddress.ForeColor = Color.Silver;
                _database.Settings.Connections.OBSAddress = "";
            }
            else
            {
                _database.Settings.Connections.OBSAddress = txtOBSAddress.Text;
            }
            _database.Update(_database.Settings.Connections);
        }

        private void txtOBSPassword_TextChanged(object sender, EventArgs e)
        {
            _database.Settings.Connections.OBSPassword = txtOBSPassword.Text;
            _database.Update(_database.Settings.Connections);

            txtOBSPassword.UseSystemPasswordChar = true;
        }

        private void txtOBSPassword_DoubleClick(object sender, EventArgs e)
        {
            txtOBSPassword.UseSystemPasswordChar = !txtOBSPassword.UseSystemPasswordChar;
        }

        private void txtSNIAddress_Enter(object sender, EventArgs e)
        {
            if (txtSNIAddress.Text == SNIClient.GetLocalGrpcAddress())
            {
                txtSNIAddress.Text = "";
                txtSNIAddress.ForeColor = SystemColors.WindowText;
            }
        }

        private void txtSNIAddress_Leave(object sender, EventArgs e)
        {
            if (txtSNIAddress.Text == "" || txtSNIAddress.Text == SNIClient.GetLocalGrpcAddress())
            {
                txtSNIAddress.Text = SNIClient.GetLocalGrpcAddress();
                txtSNIAddress.ForeColor = Color.Silver;
                _database.Settings.Connections.SNIAddress = "";
            }
            else
            {
                _database.Settings.Connections.SNIAddress = txtSNIAddress.Text;
            }

            _database.Update(_database.Settings.Connections);
            UpdateSNIClient();
        }

        private void txtDistortInterval_TextChanged(object sender, EventArgs e)
        {
            uint value = 0;
            UInt32.TryParse(txtDistortInterval.Text, out value);
            _database.Settings.SocialDistortion.Interval = value;
            _database.Update(_database.Settings.SocialDistortion);
        }

        private void txtDistortDuration_TextChanged(object sender, EventArgs e)
        {
            uint value = 0;
            UInt32.TryParse(txtDistortDuration.Text, out value);
            _database.Settings.SocialDistortion.TransitionDuration = value;
            _database.Update(_database.Settings.SocialDistortion);
        }

        private void txtDistortTilt_TextChanged(object sender, EventArgs e)
        {
            Double value = 0;
            Double.TryParse(txtDistortTilt.Text, out value);
            _database.Settings.SocialDistortion.MaxTilt = value;
            _database.Update(_database.Settings.SocialDistortion);
        }

        private void txtDistortAdjustX_TextChanged(object sender, EventArgs e)
        {
            Double value = 0;
            Double.TryParse(txtDistortAdjustX.Text, out value);
            _database.Settings.SocialDistortion.AdjustmentX = value;
            _database.Update(_database.Settings.SocialDistortion);
        }

        private void txtDistortAdjustY_TextChanged(object sender, EventArgs e)
        {
            Double value = 0;
            Double.TryParse(txtDistortAdjustY.Text, out value);
            _database.Settings.SocialDistortion.AdjustmentY = value;
            _database.Update(_database.Settings.SocialDistortion);
        }

        private void txtDistortColorDuration_TextChanged(object sender, EventArgs e)
        {
            uint value = 0;
            UInt32.TryParse(txtDistortColorDuration.Text, out value);
            _database.Settings.SocialDistortion.ColorizeDuration = value;
            _database.Update(_database.Settings.SocialDistortion);
        }

        private void chkDistortMirrorX_CheckStateChanged(object sender, EventArgs e)
        {
            _database.Settings.SocialDistortion.MirrorHorizontal = (DistortionActivity.DistortEnabled)chkDistortMirrorX.CheckState;
            _database.Update(_database.Settings.SocialDistortion);
        }

        private void chkDistortMirrorY_CheckStateChanged(object sender, EventArgs e)
        {
            _database.Settings.SocialDistortion.MirrorVertical = (DistortionActivity.DistortEnabled)chkDistortMirrorY.CheckState;
            _database.Update(_database.Settings.SocialDistortion);
        }

        private void chkDistortRotate_CheckStateChanged(object sender, EventArgs e)
        {
            _database.Settings.SocialDistortion.Rotate = (DistortionActivity.DistortEnabled)chkDistortRotate.CheckState;
            _database.Update(_database.Settings.SocialDistortion);
        }

        private void chkDistortZoom_CheckStateChanged(object sender, EventArgs e)
        {
            _database.Settings.SocialDistortion.ZoomIn = (DistortionActivity.DistortEnabled)chkDistortZoom.CheckState;
            _database.Update(_database.Settings.SocialDistortion);
        }

        private void chkDistortScaleX_CheckStateChanged(object sender, EventArgs e)
        {
            _database.Settings.SocialDistortion.ScaleHorizontal = (DistortionActivity.DistortEnabled)chkDistortScaleX.CheckState;
            _database.Update(_database.Settings.SocialDistortion);
        }

        private void chkDistortScaleY_CheckStateChanged(object sender, EventArgs e)
        {
            _database.Settings.SocialDistortion.ScaleVertical = (DistortionActivity.DistortEnabled)chkDistortScaleY.CheckState;
            _database.Update(_database.Settings.SocialDistortion);
        }

        private void chkDistortShearX_CheckStateChanged(object sender, EventArgs e)
        {
            _database.Settings.SocialDistortion.ShearHorizontal = (DistortionActivity.DistortEnabled)chkDistortShearX.CheckState;
            _database.Update(_database.Settings.SocialDistortion);
        }

        private void chkDistortShearY_CheckStateChanged(object sender, EventArgs e)
        {
            _database.Settings.SocialDistortion.ShearVertical = (DistortionActivity.DistortEnabled)chkDistortShearY.CheckState;
            _database.Update(_database.Settings.SocialDistortion);
        }

        private void chkDistortColor_CheckStateChanged(object sender, EventArgs e)
        {
            _database.Settings.SocialDistortion.Colorize = (DistortionActivity.DistortEnabled)chkDistortColor.CheckState;
            _database.Update(_database.Settings.SocialDistortion);
        }

        private void chkDistortMirrorX_Click(object sender, EventArgs e)
        {
            ReverseCheckStateOrder((CheckBox)sender);
        }

        private void chkDistortMirrorY_Click(object sender, EventArgs e)
        {
            ReverseCheckStateOrder((CheckBox)sender);
        }

        private void chkDistortRotate_Click(object sender, EventArgs e)
        {
            ReverseCheckStateOrder((CheckBox)sender);
        }

        private void chkDistortZoom_Click(object sender, EventArgs e)
        {
            ReverseCheckStateOrder((CheckBox)sender);
        }

        private void chkDistortScaleX_Click(object sender, EventArgs e)
        {
            ReverseCheckStateOrder((CheckBox)sender);
        }

        private void chkDistortScaleY_Click(object sender, EventArgs e)
        {
            ReverseCheckStateOrder((CheckBox)sender);
        }

        private void chkDistortShearX_Click(object sender, EventArgs e)
        {
            ReverseCheckStateOrder((CheckBox)sender);
        }

        private void chkDistortShearY_Click(object sender, EventArgs e)
        {
            ReverseCheckStateOrder((CheckBox)sender);
        }

        private void chkDistortColor_Click(object sender, EventArgs e)
        {
            ReverseCheckStateOrder((CheckBox)sender);
        }

        private void ReverseCheckStateOrder(CheckBox checkBox)
        {
            switch (checkBox.CheckState)
            {
                case CheckState.Checked: checkBox.CheckState = CheckState.Indeterminate; break;
                case CheckState.Unchecked: checkBox.CheckState = CheckState.Checked; break;
                default: checkBox.CheckState = CheckState.Unchecked; break;
            }
        }

        private void btnOBSStatus_Click(object sender, EventArgs e)
        {
            if (_obs != null && _obs.Status == OBSConnect.OBSStatus.Connected)
            {
                _obs.Disconnect();
            }
            else
            {
                _obs = new OBSConnect(this);
                _obs.Connect(txtOBSAddress.Text, txtOBSPassword.Text);
            }
        }

        private void cboOBSGameSource_DropDown(object sender, EventArgs e)
        {
            if (_obs != null && _obs.Status == OBSConnect.OBSStatus.Connected)
            {
                cboOBSGameSource.Items.Clear();
                OBSWebsocketDotNet.Types.SourceInfo source = new OBSWebsocketDotNet.Types.SourceInfo();
                cboOBSGameSource.Items.Add(source);
                foreach (OBSWebsocketDotNet.Types.SourceInfo s in _obs._obs.GetSourcesList())
                {
                    if (s.TypeID == "dshow_input")
                    {
                        cboOBSGameSource.Items.Add(s);
                    }
                }
                foreach (OBSWebsocketDotNet.Types.SourceInfo s in _obs._obs.GetSourcesList())
                {
                    if (s.TypeID == "game_capture")
                    {
                        cboOBSGameSource.Items.Add(s);
                    }
                }
                foreach (OBSWebsocketDotNet.Types.SourceInfo s in _obs._obs.GetSourcesList())
                {
                    if (s.TypeID == "window_capture")
                    {
                        cboOBSGameSource.Items.Add(s);
                    }
                }
                foreach (OBSWebsocketDotNet.Types.SourceInfo s in _obs._obs.GetSourcesList())
                {
                    if (s.TypeID == "monitor_capture")
                    {
                        cboOBSGameSource.Items.Add(s);
                    }
                }

                if (_database.Settings.SocialDistortion.OBSSourceName != "")
                {
                    foreach (OBSWebsocketDotNet.Types.SourceInfo s in cboOBSGameSource.Items)
                    {
                        if (s.Name == _database.Settings.SocialDistortion.OBSSourceName)
                        {
                            cboOBSGameSource.SelectedItem = s;
                            break;
                        }
                    }
                }
            }
        }

        private void cboOBSGameSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOBSGameSource.SelectedIndex != 0)
            {
                OBSWebsocketDotNet.Types.SourceInfo item = (OBSWebsocketDotNet.Types.SourceInfo)cboOBSGameSource.SelectedItem;
                _database.Settings.SocialDistortion.OBSSourceName = item.Name;
                _database.Update(_database.Settings.SocialDistortion);
            }
        }
        private void btnSNIStatus_MouseHover(object sender, EventArgs e)
        {
            tooltip.SetToolTip(stsMain, btnSNIStatus.ToolTipText);
        }

        private void btnSNIStatus_MouseLeave(object sender, EventArgs e)
        {
            tooltip.RemoveAll();
        }

        private void btnOBSStatus_MouseHover(object sender, EventArgs e)
        {
            tooltip.SetToolTip(stsMain, btnOBSStatus.ToolTipText);
        }

        private void btnOBSStatus_MouseLeave(object sender, EventArgs e)
        {
            tooltip.RemoveAll();
        }

        private void btnActivityDistortion_Click(object sender, EventArgs e)
        {
            if (_distort != null && _distort.Status != DistortionActivity.DistortStatus.Stopped)
            {
                _distort.Stop();
            }
            else
            {
                _distort = new DistortionActivity(this);
                _distort.Start();
            }
        }

        #endregion

        public void UpdateSNIClient()
        {
            if (_database.Settings.Connections.SNIAddress == "")
            {
                _sni = new SNIClient(SNIClient.DEFAULT_IP, SNIClient.GetGrpcPort());
            }
            else if (_database.Settings.Connections.SNIAddress.Contains(":"))
            {
                string[] address = _database.Settings.Connections.SNIAddress.Split(':');
                _sni = new SNIClient(address[address.Length - 2], int.Parse(address[address.Length - 1]));
            }
        }

        public void UpdateSNIStatus(bool updateDevices)
        {
            if (updateDevices)
            {
                dsSNIDevice.Clear();

                switch (_sni.Status)
                {
                    case SNIClient.DeviceState.SNIOffline:
                        {
                            SNI.DevicesResponse.Types.Device d = new SNI.DevicesResponse.Types.Device();
                            d.DisplayName = "(disconnected)";
                            dsSNIDevice.Add(d);
                        }
                        break;
                    case SNIClient.DeviceState.NoDevice:
                        {
                            SNI.DevicesResponse.Types.Device d = new SNI.DevicesResponse.Types.Device();
                            d.DisplayName = "(none found)";
                            dsSNIDevice.Add(d);
                        }
                        break;
                    default:
                        foreach (SNI.DevicesResponse.Types.Device d in _sni.Devices)
                        {
                            dsSNIDevice.Add(d);
                        }
                        break;
                }
            }

            Image img;
            switch (_sni.Status)
            {
                case SNIClient.DeviceState.DeviceRunning:
                case SNIClient.DeviceState.DeviceRunningLive:
                    btnSNIStatus.ToolTipText = string.Format("Active ({0})", _sni.Devices[0].DisplayName);
                    img = Properties.Resources.OnlineStatusAvailable;
                    break;
                case SNIClient.DeviceState.DeviceStandby:
                    btnSNIStatus.ToolTipText = string.Format("Connected ({0})", _sni.Devices[0].DisplayName);
                    img = Properties.Resources.OnlineStatusAway;
                    break;
                case SNIClient.DeviceState.NoDevice:
                    btnSNIStatus.ToolTipText = "No Device";
                    img = Properties.Resources.OnlineStatusPresenting;
                    break;
                default:
                    btnSNIStatus.ToolTipText = "Disconnected";
                    img = Properties.Resources.OnlineStatusUnknown;
                    break;
            }

            if (img != btnSNIStatus.Image)
            {
                btnSNIStatus.Image.Dispose();
                btnSNIStatus.Image = img;
            }
        }

        public void UpdateOBSStatus()
        {
            Image img;
            switch (_obs.Status)
            {
                case OBSConnect.OBSStatus.Connected:
                    btnOBSStatus.ToolTipText = "Connected";
                    img = Properties.Resources.OnlineStatusAvailable;
                    break;
                case OBSConnect.OBSStatus.AuthError:
                case OBSConnect.OBSStatus.Error:
                    btnOBSStatus.ToolTipText = "Error";
                    img = Properties.Resources.OnlineStatusPresenting;
                    break;
                default:
                    btnOBSStatus.ToolTipText = "Disconnected";
                    img = Properties.Resources.OnlineStatusUnknown;
                    break;
            }

            if (img != btnOBSStatus.Image)
            {
                btnOBSStatus.Image.Dispose();
                btnOBSStatus.Image = img;
            }
        }
    }
}
