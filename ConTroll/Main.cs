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
        public Main()
        {
            InitializeComponent();

            LoadSettings();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            AutoStartServices();
        }

        private void LoadSettings()
        {
            string value = Properties.Settings.Default.OBSWebsocketAddress;
            if (value != "")
            {
                txtOBSAddress.Text = value;
                txtOBSAddress.ForeColor = SystemColors.WindowText;
            }    
            else
            {
                txtOBSAddress.Text = OBSConnect.DEFAULT_ADDRESS;
            }
            txtOBSPassword.Text = Properties.Settings.Default.OBSWebsocketPassword;

            value = Properties.Settings.Default.SNIAddress;
            if (value != "")
            {
                txtSNIAddress.Text = value;
                txtSNIAddress.ForeColor = SystemColors.WindowText;
            }
            else
            {
                txtSNIAddress.Text = SNIClient.GetLocalGrpcAddress();
            }

            txtDistortInterval.Text = Properties.Settings.Default.DistortInterval.ToString();
            txtDistortDuration.Text = Properties.Settings.Default.DistortDuration.ToString();
            txtDistortTilt.Text = Properties.Settings.Default.DistortTilt.ToString();
            txtDistortAdjustX.Text = Properties.Settings.Default.DistortAdjustX.ToString();
            txtDistortAdjustY.Text = Properties.Settings.Default.DistortAdjustY.ToString();

            chkDistortMirrorX.Checked = Properties.Settings.Default.DistortMirrorX;
            chkDistortMirrorY.Checked = Properties.Settings.Default.DistortMirrorY;
            chkDistortRotate.Checked = Properties.Settings.Default.DistortRotate;
            chkDistortZoom.Checked = Properties.Settings.Default.DistortZoom;
            chkDistortScaleX.Checked = Properties.Settings.Default.DistortScaleX;
            chkDistortScaleY.Checked = Properties.Settings.Default.DistortScaleY;
            chkDistortShearX.Checked = Properties.Settings.Default.DistortShearX;
            chkDistortShearY.Checked = Properties.Settings.Default.DistortShearY;

            value = Properties.Settings.Default.OBSGameSource;
            if (value != "")
            {
                var s = new OBSWebsocketDotNet.Types.SourceInfo();
                s.Name = value;
                cboOBSGameSource.Items.Add(s);
                cboOBSGameSource.SelectedItem = s;
            }
        }

        public void AutoStartServices()
        {
            btnOBSStatus_Click(null, null);
            btnDeviceRefresh_Click(null, null);
        }

        #region Form Control Events

        private void txtOBSAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtOBSAddress.Text != "" && txtOBSAddress.Text != OBSConnect.DEFAULT_ADDRESS)
            {
                Properties.Settings.Default.OBSWebsocketAddress = txtOBSAddress.Text;
            }
            else
            {
                Properties.Settings.Default.OBSWebsocketAddress = "";
            }
               
            Properties.Settings.Default.Save();
        }

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
            }
        }

        private void txtOBSPassword_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.OBSWebsocketPassword = txtOBSPassword.Text;
            Properties.Settings.Default.Save();

            txtOBSPassword.UseSystemPasswordChar = true;
        }

        private void txtOBSPassword_DoubleClick(object sender, EventArgs e)
        {
            txtOBSPassword.UseSystemPasswordChar = !txtOBSPassword.UseSystemPasswordChar;
        }

        private void txtSNIAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtSNIAddress.Text != "" && txtSNIAddress.Text != SNIClient.GetLocalGrpcAddress())
            {
                Properties.Settings.Default.SNIAddress = txtSNIAddress.Text;
            }
            else
            {
                Properties.Settings.Default.SNIAddress = "";
            }

            Properties.Settings.Default.Save();
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
            }
        }

        private void txtDistortInterval_TextChanged(object sender, EventArgs e)
        {
            uint value = 0;
            UInt32.TryParse(txtDistortInterval.Text, out value);
            Properties.Settings.Default.DistortInterval = value;
            Properties.Settings.Default.Save();
        }

        private void txtDistortDuration_TextChanged(object sender, EventArgs e)
        {
            uint value = 0;
            UInt32.TryParse(txtDistortDuration.Text, out value);
            Properties.Settings.Default.DistortDuration = value;
            Properties.Settings.Default.Save();
        }

        private void txtDistortTilt_TextChanged(object sender, EventArgs e)
        {
            Double value = 0;
            Double.TryParse(txtDistortTilt.Text, out value);
            Properties.Settings.Default.DistortTilt = value;
            Properties.Settings.Default.Save();
        }

        private void txtDistortAdjustX_TextChanged(object sender, EventArgs e)
        {
            Double value = 0;
            Double.TryParse(txtDistortAdjustX.Text, out value);
            Properties.Settings.Default.DistortAdjustX = value;
            Properties.Settings.Default.Save();
        }

        private void txtDistortAdjustY_TextChanged(object sender, EventArgs e)
        {
            Double value = 0;
            Double.TryParse(txtDistortAdjustY.Text, out value);
            Properties.Settings.Default.DistortAdjustY = value;
            Properties.Settings.Default.Save();
        }

        private void chkDistortMirrorX_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DistortMirrorX = chkDistortMirrorX.Checked;
            Properties.Settings.Default.Save();
        }

        private void chkDistortMirrorY_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DistortMirrorY = chkDistortMirrorY.Checked;
            Properties.Settings.Default.Save();
        }

        private void chkDistortRotate_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DistortRotate = chkDistortRotate.Checked;
            Properties.Settings.Default.Save();
        }

        private void chkDistortZoom_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DistortZoom = chkDistortZoom.Checked;
            Properties.Settings.Default.Save();
        }

        private void chkDistortScaleX_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DistortScaleX = chkDistortScaleX.Checked;
            Properties.Settings.Default.Save();
        }

        private void chkDistortScaleY_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DistortScaleY = chkDistortScaleY.Checked;
            Properties.Settings.Default.Save();
        }

        private void chkDistortShearX_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DistortShearX = chkDistortShearX.Checked;
            Properties.Settings.Default.Save();
        }

        private void chkDistortShearY_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DistortShearY = chkDistortShearY.Checked;
            Properties.Settings.Default.Save();
        }

        private void btnDeviceRefresh_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SNIAddress == "")
            {
                _sni = new SNIClient(SNIClient.DEFAULT_IP, SNIClient.GetGrpcPort());
            }
            else
            {
                string[] address = Properties.Settings.Default.SNIAddress.Split(':');
                _sni = new SNIClient(address[0], int.Parse(address[1]));
            }

            _sni.Connect();

            dsSNIDevice.Clear();
            foreach (SNI.DevicesResponse.Types.Device d in _sni.Devices)
            {
                dsSNIDevice.Add(d);
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

                if (Properties.Settings.Default.OBSGameSource != "")
                {
                    foreach (OBSWebsocketDotNet.Types.SourceInfo s in cboOBSGameSource.Items)
                    {
                        if (s.Name == Properties.Settings.Default.OBSGameSource)
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
                Properties.Settings.Default.OBSGameSource = item.Name;
                Properties.Settings.Default.Save();
            }
        }

        #endregion

        public void UpdateOBSStatus()
        {
            Image img;
            switch (_obs.Status)
            {
                case OBSConnect.OBSStatus.Connected:
                    img = Properties.Resources.OnlineStatusAvailable;
                    break;
                case OBSConnect.OBSStatus.AuthError:
                case OBSConnect.OBSStatus.Error:
                    img = Properties.Resources.OnlineStatusPresenting;
                    break;
                default:
                    img = Properties.Resources.OnlineStatusUnknown;
                    break;
            }

            if (img != btnOBSStatus.Image)
            {
                btnOBSStatus.Image.Dispose();
                btnOBSStatus.Image = img;
            }
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
    }
}
