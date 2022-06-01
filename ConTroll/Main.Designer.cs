
namespace ConTroll
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tabbarMain = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.lblActivityDistortion = new System.Windows.Forms.Label();
            this.btnActivityDistortion = new System.Windows.Forms.Button();
            this.lblOBSStatus = new System.Windows.Forms.Label();
            this.btnOBSStatus = new System.Windows.Forms.Button();
            this.lblDevices = new System.Windows.Forms.Label();
            this.btnDeviceRefresh = new System.Windows.Forms.Button();
            this.cboDevices = new System.Windows.Forms.ComboBox();
            this.dsSNIDevice = new System.Windows.Forms.BindingSource(this.components);
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.grpDistortion = new System.Windows.Forms.GroupBox();
            this.chkDistortShearY = new System.Windows.Forms.CheckBox();
            this.chkDistortShearX = new System.Windows.Forms.CheckBox();
            this.chkDistortScaleY = new System.Windows.Forms.CheckBox();
            this.chkDistortScaleX = new System.Windows.Forms.CheckBox();
            this.chkDistortZoom = new System.Windows.Forms.CheckBox();
            this.chkDistortRotate = new System.Windows.Forms.CheckBox();
            this.chkDistortMirrorY = new System.Windows.Forms.CheckBox();
            this.chkDistortMirrorX = new System.Windows.Forms.CheckBox();
            this.txtDistortInterval = new System.Windows.Forms.TextBox();
            this.lblDistortAdjustY = new System.Windows.Forms.Label();
            this.txtDistortAdjustY = new System.Windows.Forms.TextBox();
            this.lblDistortAdjustX = new System.Windows.Forms.Label();
            this.txtDistortAdjustX = new System.Windows.Forms.TextBox();
            this.lblDistortTilt = new System.Windows.Forms.Label();
            this.txtDistortTilt = new System.Windows.Forms.TextBox();
            this.lblDistortDuration = new System.Windows.Forms.Label();
            this.txtDistortDuration = new System.Windows.Forms.TextBox();
            this.lblOBSGameSource = new System.Windows.Forms.Label();
            this.cboOBSGameSource = new System.Windows.Forms.ComboBox();
            this.tabConnection = new System.Windows.Forms.TabPage();
            this.grpSNI = new System.Windows.Forms.GroupBox();
            this.lblSNIAddress = new System.Windows.Forms.Label();
            this.txtSNIAddress = new System.Windows.Forms.TextBox();
            this.grpOBSSettings = new System.Windows.Forms.GroupBox();
            this.lblObsAddress = new System.Windows.Forms.Label();
            this.txtOBSAddress = new System.Windows.Forms.TextBox();
            this.lblOBSPassword = new System.Windows.Forms.Label();
            this.txtOBSPassword = new System.Windows.Forms.TextBox();
            this.dsOBSGameSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblDistortInterval = new System.Windows.Forms.Label();
            this.tabbarMain.SuspendLayout();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsSNIDevice)).BeginInit();
            this.tabConfig.SuspendLayout();
            this.grpDistortion.SuspendLayout();
            this.tabConnection.SuspendLayout();
            this.grpSNI.SuspendLayout();
            this.grpOBSSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsOBSGameSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabbarMain
            // 
            this.tabbarMain.Controls.Add(this.tabMain);
            this.tabbarMain.Controls.Add(this.tabConfig);
            this.tabbarMain.Controls.Add(this.tabConnection);
            this.tabbarMain.Location = new System.Drawing.Point(0, 0);
            this.tabbarMain.Name = "tabbarMain";
            this.tabbarMain.SelectedIndex = 0;
            this.tabbarMain.Size = new System.Drawing.Size(294, 216);
            this.tabbarMain.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.lblActivityDistortion);
            this.tabMain.Controls.Add(this.btnActivityDistortion);
            this.tabMain.Controls.Add(this.lblOBSStatus);
            this.tabMain.Controls.Add(this.btnOBSStatus);
            this.tabMain.Controls.Add(this.lblDevices);
            this.tabMain.Controls.Add(this.btnDeviceRefresh);
            this.tabMain.Controls.Add(this.cboDevices);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(286, 190);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // lblActivityDistortion
            // 
            this.lblActivityDistortion.AutoSize = true;
            this.lblActivityDistortion.Location = new System.Drawing.Point(3, 166);
            this.lblActivityDistortion.Name = "lblActivityDistortion";
            this.lblActivityDistortion.Size = new System.Drawing.Size(86, 13);
            this.lblActivityDistortion.TabIndex = 6;
            this.lblActivityDistortion.Text = "Social Distortion:";
            // 
            // btnActivityDistortion
            // 
            this.btnActivityDistortion.Image = global::ConTroll.Properties.Resources.OnlineStatusUnknown;
            this.btnActivityDistortion.Location = new System.Drawing.Point(95, 161);
            this.btnActivityDistortion.Name = "btnActivityDistortion";
            this.btnActivityDistortion.Size = new System.Drawing.Size(23, 23);
            this.btnActivityDistortion.TabIndex = 5;
            this.btnActivityDistortion.UseVisualStyleBackColor = true;
            this.btnActivityDistortion.Click += new System.EventHandler(this.btnActivityDistortion_Click);
            // 
            // lblOBSStatus
            // 
            this.lblOBSStatus.AutoSize = true;
            this.lblOBSStatus.Location = new System.Drawing.Point(3, 38);
            this.lblOBSStatus.Name = "lblOBSStatus";
            this.lblOBSStatus.Size = new System.Drawing.Size(32, 13);
            this.lblOBSStatus.TabIndex = 4;
            this.lblOBSStatus.Text = "OBS:";
            // 
            // btnOBSStatus
            // 
            this.btnOBSStatus.Image = global::ConTroll.Properties.Resources.OnlineStatusUnknown;
            this.btnOBSStatus.Location = new System.Drawing.Point(53, 33);
            this.btnOBSStatus.Name = "btnOBSStatus";
            this.btnOBSStatus.Size = new System.Drawing.Size(23, 23);
            this.btnOBSStatus.TabIndex = 3;
            this.btnOBSStatus.UseVisualStyleBackColor = true;
            this.btnOBSStatus.Click += new System.EventHandler(this.btnOBSStatus_Click);
            // 
            // lblDevices
            // 
            this.lblDevices.AutoSize = true;
            this.lblDevices.Location = new System.Drawing.Point(3, 9);
            this.lblDevices.Name = "lblDevices";
            this.lblDevices.Size = new System.Drawing.Size(44, 13);
            this.lblDevices.TabIndex = 2;
            this.lblDevices.Text = "Device:";
            // 
            // btnDeviceRefresh
            // 
            this.btnDeviceRefresh.Image = global::ConTroll.Properties.Resources.Refresh;
            this.btnDeviceRefresh.Location = new System.Drawing.Point(235, 4);
            this.btnDeviceRefresh.Name = "btnDeviceRefresh";
            this.btnDeviceRefresh.Size = new System.Drawing.Size(23, 23);
            this.btnDeviceRefresh.TabIndex = 1;
            this.btnDeviceRefresh.UseVisualStyleBackColor = true;
            // 
            // cboDevices
            // 
            this.cboDevices.DataSource = this.dsSNIDevice;
            this.cboDevices.DisplayMember = "DisplayName";
            this.cboDevices.FormattingEnabled = true;
            this.cboDevices.Location = new System.Drawing.Point(53, 6);
            this.cboDevices.Name = "cboDevices";
            this.cboDevices.Size = new System.Drawing.Size(176, 21);
            this.cboDevices.TabIndex = 0;
            // 
            // dsSNIDevice
            // 
            this.dsSNIDevice.DataSource = typeof(SNI.DevicesResponse.Types.Device);
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.grpDistortion);
            this.tabConfig.Controls.Add(this.lblOBSGameSource);
            this.tabConfig.Controls.Add(this.cboOBSGameSource);
            this.tabConfig.Location = new System.Drawing.Point(4, 22);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfig.Size = new System.Drawing.Size(286, 190);
            this.tabConfig.TabIndex = 2;
            this.tabConfig.Text = "Config";
            this.tabConfig.UseVisualStyleBackColor = true;
            // 
            // grpDistortion
            // 
            this.grpDistortion.Controls.Add(this.chkDistortShearY);
            this.grpDistortion.Controls.Add(this.chkDistortShearX);
            this.grpDistortion.Controls.Add(this.chkDistortScaleY);
            this.grpDistortion.Controls.Add(this.chkDistortScaleX);
            this.grpDistortion.Controls.Add(this.chkDistortZoom);
            this.grpDistortion.Controls.Add(this.chkDistortRotate);
            this.grpDistortion.Controls.Add(this.chkDistortMirrorY);
            this.grpDistortion.Controls.Add(this.chkDistortMirrorX);
            this.grpDistortion.Controls.Add(this.lblDistortInterval);
            this.grpDistortion.Controls.Add(this.txtDistortInterval);
            this.grpDistortion.Controls.Add(this.lblDistortAdjustY);
            this.grpDistortion.Controls.Add(this.txtDistortAdjustY);
            this.grpDistortion.Controls.Add(this.lblDistortAdjustX);
            this.grpDistortion.Controls.Add(this.txtDistortAdjustX);
            this.grpDistortion.Controls.Add(this.lblDistortTilt);
            this.grpDistortion.Controls.Add(this.txtDistortTilt);
            this.grpDistortion.Controls.Add(this.lblDistortDuration);
            this.grpDistortion.Controls.Add(this.txtDistortDuration);
            this.grpDistortion.Location = new System.Drawing.Point(10, 33);
            this.grpDistortion.Name = "grpDistortion";
            this.grpDistortion.Size = new System.Drawing.Size(269, 151);
            this.grpDistortion.TabIndex = 2;
            this.grpDistortion.TabStop = false;
            this.grpDistortion.Text = "Social Distortion";
            // 
            // chkDistortShearY
            // 
            this.chkDistortShearY.AutoSize = true;
            this.chkDistortShearY.Location = new System.Drawing.Point(156, 130);
            this.chkDistortShearY.Name = "chkDistortShearY";
            this.chkDistortShearY.Size = new System.Drawing.Size(92, 17);
            this.chkDistortShearY.TabIndex = 31;
            this.chkDistortShearY.Text = "Shear Vertical";
            this.chkDistortShearY.UseVisualStyleBackColor = true;
            this.chkDistortShearY.CheckedChanged += new System.EventHandler(this.chkDistortShearY_CheckedChanged);
            // 
            // chkDistortShearX
            // 
            this.chkDistortShearX.AutoSize = true;
            this.chkDistortShearX.Location = new System.Drawing.Point(156, 114);
            this.chkDistortShearX.Name = "chkDistortShearX";
            this.chkDistortShearX.Size = new System.Drawing.Size(104, 17);
            this.chkDistortShearX.TabIndex = 30;
            this.chkDistortShearX.Text = "Shear Horizontal";
            this.chkDistortShearX.UseVisualStyleBackColor = true;
            this.chkDistortShearX.CheckedChanged += new System.EventHandler(this.chkDistortShearX_CheckedChanged);
            // 
            // chkDistortScaleY
            // 
            this.chkDistortScaleY.AutoSize = true;
            this.chkDistortScaleY.Location = new System.Drawing.Point(156, 98);
            this.chkDistortScaleY.Name = "chkDistortScaleY";
            this.chkDistortScaleY.Size = new System.Drawing.Size(96, 17);
            this.chkDistortScaleY.TabIndex = 29;
            this.chkDistortScaleY.Text = "Squish Vertical";
            this.chkDistortScaleY.UseVisualStyleBackColor = true;
            this.chkDistortScaleY.CheckedChanged += new System.EventHandler(this.chkDistortScaleY_CheckedChanged);
            // 
            // chkDistortScaleX
            // 
            this.chkDistortScaleX.AutoSize = true;
            this.chkDistortScaleX.Location = new System.Drawing.Point(156, 82);
            this.chkDistortScaleX.Name = "chkDistortScaleX";
            this.chkDistortScaleX.Size = new System.Drawing.Size(108, 17);
            this.chkDistortScaleX.TabIndex = 28;
            this.chkDistortScaleX.Text = "Squish Horizontal";
            this.chkDistortScaleX.UseVisualStyleBackColor = true;
            this.chkDistortScaleX.CheckedChanged += new System.EventHandler(this.chkDistortScaleX_CheckedChanged);
            // 
            // chkDistortZoom
            // 
            this.chkDistortZoom.AutoSize = true;
            this.chkDistortZoom.Location = new System.Drawing.Point(156, 66);
            this.chkDistortZoom.Name = "chkDistortZoom";
            this.chkDistortZoom.Size = new System.Drawing.Size(65, 17);
            this.chkDistortZoom.TabIndex = 27;
            this.chkDistortZoom.Text = "Zoom In";
            this.chkDistortZoom.UseVisualStyleBackColor = true;
            this.chkDistortZoom.CheckedChanged += new System.EventHandler(this.chkDistortZoom_CheckedChanged);
            // 
            // chkDistortRotate
            // 
            this.chkDistortRotate.AutoSize = true;
            this.chkDistortRotate.Location = new System.Drawing.Point(156, 50);
            this.chkDistortRotate.Name = "chkDistortRotate";
            this.chkDistortRotate.Size = new System.Drawing.Size(79, 17);
            this.chkDistortRotate.TabIndex = 26;
            this.chkDistortRotate.Text = "Rotate 180";
            this.chkDistortRotate.UseVisualStyleBackColor = true;
            this.chkDistortRotate.CheckedChanged += new System.EventHandler(this.chkDistortRotate_CheckedChanged);
            // 
            // chkDistortMirrorY
            // 
            this.chkDistortMirrorY.AutoSize = true;
            this.chkDistortMirrorY.Location = new System.Drawing.Point(156, 34);
            this.chkDistortMirrorY.Name = "chkDistortMirrorY";
            this.chkDistortMirrorY.Size = new System.Drawing.Size(90, 17);
            this.chkDistortMirrorY.TabIndex = 25;
            this.chkDistortMirrorY.Text = "Mirror Vertical";
            this.chkDistortMirrorY.UseVisualStyleBackColor = true;
            this.chkDistortMirrorY.CheckedChanged += new System.EventHandler(this.chkDistortMirrorY_CheckedChanged);
            // 
            // chkDistortMirrorX
            // 
            this.chkDistortMirrorX.AutoSize = true;
            this.chkDistortMirrorX.Location = new System.Drawing.Point(156, 18);
            this.chkDistortMirrorX.Name = "chkDistortMirrorX";
            this.chkDistortMirrorX.Size = new System.Drawing.Size(102, 17);
            this.chkDistortMirrorX.TabIndex = 24;
            this.chkDistortMirrorX.Text = "Mirror Horizontal";
            this.chkDistortMirrorX.UseVisualStyleBackColor = true;
            this.chkDistortMirrorX.CheckedChanged += new System.EventHandler(this.chkDistortMirrorX_CheckedChanged);
            // 
            // txtDistortInterval
            // 
            this.txtDistortInterval.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDistortInterval.Location = new System.Drawing.Point(83, 19);
            this.txtDistortInterval.Name = "txtDistortInterval";
            this.txtDistortInterval.Size = new System.Drawing.Size(56, 20);
            this.txtDistortInterval.TabIndex = 0;
            this.txtDistortInterval.TextChanged += new System.EventHandler(this.txtDistortInterval_TextChanged);
            // 
            // lblDistortAdjustY
            // 
            this.lblDistortAdjustY.AutoSize = true;
            this.lblDistortAdjustY.Location = new System.Drawing.Point(6, 126);
            this.lblDistortAdjustY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDistortAdjustY.Name = "lblDistortAdjustY";
            this.lblDistortAdjustY.Size = new System.Drawing.Size(72, 13);
            this.lblDistortAdjustY.TabIndex = 21;
            this.lblDistortAdjustY.Text = "Y Adjustment:";
            // 
            // txtDistortAdjustY
            // 
            this.txtDistortAdjustY.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDistortAdjustY.Location = new System.Drawing.Point(83, 123);
            this.txtDistortAdjustY.Name = "txtDistortAdjustY";
            this.txtDistortAdjustY.Size = new System.Drawing.Size(56, 20);
            this.txtDistortAdjustY.TabIndex = 4;
            this.txtDistortAdjustY.TextChanged += new System.EventHandler(this.txtDistortAdjustY_TextChanged);
            // 
            // lblDistortAdjustX
            // 
            this.lblDistortAdjustX.AutoSize = true;
            this.lblDistortAdjustX.Location = new System.Drawing.Point(6, 100);
            this.lblDistortAdjustX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDistortAdjustX.Name = "lblDistortAdjustX";
            this.lblDistortAdjustX.Size = new System.Drawing.Size(72, 13);
            this.lblDistortAdjustX.TabIndex = 19;
            this.lblDistortAdjustX.Text = "X Adjustment:";
            // 
            // txtDistortAdjustX
            // 
            this.txtDistortAdjustX.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDistortAdjustX.Location = new System.Drawing.Point(83, 97);
            this.txtDistortAdjustX.Name = "txtDistortAdjustX";
            this.txtDistortAdjustX.Size = new System.Drawing.Size(56, 20);
            this.txtDistortAdjustX.TabIndex = 3;
            this.txtDistortAdjustX.TextChanged += new System.EventHandler(this.txtDistortAdjustX_TextChanged);
            // 
            // lblDistortTilt
            // 
            this.lblDistortTilt.AutoSize = true;
            this.lblDistortTilt.Location = new System.Drawing.Point(31, 74);
            this.lblDistortTilt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDistortTilt.Name = "lblDistortTilt";
            this.lblDistortTilt.Size = new System.Drawing.Size(47, 13);
            this.lblDistortTilt.TabIndex = 17;
            this.lblDistortTilt.Text = "Max Tilt:";
            // 
            // txtDistortTilt
            // 
            this.txtDistortTilt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDistortTilt.Location = new System.Drawing.Point(83, 71);
            this.txtDistortTilt.Name = "txtDistortTilt";
            this.txtDistortTilt.Size = new System.Drawing.Size(56, 20);
            this.txtDistortTilt.TabIndex = 2;
            this.txtDistortTilt.TextChanged += new System.EventHandler(this.txtDistortTilt_TextChanged);
            // 
            // lblDistortDuration
            // 
            this.lblDistortDuration.AutoSize = true;
            this.lblDistortDuration.Location = new System.Drawing.Point(28, 48);
            this.lblDistortDuration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDistortDuration.Name = "lblDistortDuration";
            this.lblDistortDuration.Size = new System.Drawing.Size(50, 13);
            this.lblDistortDuration.TabIndex = 15;
            this.lblDistortDuration.Text = "Duration:";
            // 
            // txtDistortDuration
            // 
            this.txtDistortDuration.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDistortDuration.Location = new System.Drawing.Point(83, 45);
            this.txtDistortDuration.Name = "txtDistortDuration";
            this.txtDistortDuration.Size = new System.Drawing.Size(56, 20);
            this.txtDistortDuration.TabIndex = 1;
            this.txtDistortDuration.TextChanged += new System.EventHandler(this.txtDistortDuration_TextChanged);
            // 
            // lblOBSGameSource
            // 
            this.lblOBSGameSource.AutoSize = true;
            this.lblOBSGameSource.Location = new System.Drawing.Point(7, 9);
            this.lblOBSGameSource.Name = "lblOBSGameSource";
            this.lblOBSGameSource.Size = new System.Drawing.Size(75, 13);
            this.lblOBSGameSource.TabIndex = 1;
            this.lblOBSGameSource.Text = "Game Source:";
            // 
            // cboOBSGameSource
            // 
            this.cboOBSGameSource.DisplayMember = "Name";
            this.cboOBSGameSource.FormattingEnabled = true;
            this.cboOBSGameSource.Location = new System.Drawing.Point(88, 6);
            this.cboOBSGameSource.Name = "cboOBSGameSource";
            this.cboOBSGameSource.Size = new System.Drawing.Size(145, 21);
            this.cboOBSGameSource.TabIndex = 0;
            this.cboOBSGameSource.DropDown += new System.EventHandler(this.cboOBSGameSource_DropDown);
            this.cboOBSGameSource.SelectedIndexChanged += new System.EventHandler(this.cboOBSGameSource_SelectedIndexChanged);
            // 
            // tabConnection
            // 
            this.tabConnection.Controls.Add(this.grpSNI);
            this.tabConnection.Controls.Add(this.grpOBSSettings);
            this.tabConnection.Location = new System.Drawing.Point(4, 22);
            this.tabConnection.Name = "tabConnection";
            this.tabConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnection.Size = new System.Drawing.Size(286, 190);
            this.tabConnection.TabIndex = 1;
            this.tabConnection.Text = "Connection";
            this.tabConnection.UseVisualStyleBackColor = true;
            // 
            // grpSNI
            // 
            this.grpSNI.Controls.Add(this.lblSNIAddress);
            this.grpSNI.Controls.Add(this.txtSNIAddress);
            this.grpSNI.Location = new System.Drawing.Point(8, 84);
            this.grpSNI.Name = "grpSNI";
            this.grpSNI.Size = new System.Drawing.Size(248, 47);
            this.grpSNI.TabIndex = 14;
            this.grpSNI.TabStop = false;
            this.grpSNI.Text = "SNI Connection";
            // 
            // lblSNIAddress
            // 
            this.lblSNIAddress.AutoSize = true;
            this.lblSNIAddress.Location = new System.Drawing.Point(5, 22);
            this.lblSNIAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSNIAddress.Name = "lblSNIAddress";
            this.lblSNIAddress.Size = new System.Drawing.Size(48, 13);
            this.lblSNIAddress.TabIndex = 13;
            this.lblSNIAddress.Text = "Address:";
            // 
            // txtSNIAddress
            // 
            this.txtSNIAddress.ForeColor = System.Drawing.Color.Silver;
            this.txtSNIAddress.Location = new System.Drawing.Point(66, 19);
            this.txtSNIAddress.Name = "txtSNIAddress";
            this.txtSNIAddress.Size = new System.Drawing.Size(175, 20);
            this.txtSNIAddress.TabIndex = 12;
            this.txtSNIAddress.TextChanged += new System.EventHandler(this.txtSNIAddress_TextChanged);
            this.txtSNIAddress.Enter += new System.EventHandler(this.txtSNIAddress_Enter);
            this.txtSNIAddress.Leave += new System.EventHandler(this.txtSNIAddress_Leave);
            // 
            // grpOBSSettings
            // 
            this.grpOBSSettings.Controls.Add(this.lblObsAddress);
            this.grpOBSSettings.Controls.Add(this.txtOBSAddress);
            this.grpOBSSettings.Controls.Add(this.lblOBSPassword);
            this.grpOBSSettings.Controls.Add(this.txtOBSPassword);
            this.grpOBSSettings.Location = new System.Drawing.Point(8, 6);
            this.grpOBSSettings.Name = "grpOBSSettings";
            this.grpOBSSettings.Size = new System.Drawing.Size(248, 72);
            this.grpOBSSettings.TabIndex = 13;
            this.grpOBSSettings.TabStop = false;
            this.grpOBSSettings.Text = "OBS Websocket";
            // 
            // lblObsAddress
            // 
            this.lblObsAddress.AutoSize = true;
            this.lblObsAddress.Location = new System.Drawing.Point(5, 21);
            this.lblObsAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblObsAddress.Name = "lblObsAddress";
            this.lblObsAddress.Size = new System.Drawing.Size(48, 13);
            this.lblObsAddress.TabIndex = 9;
            this.lblObsAddress.Text = "Address:";
            // 
            // txtOBSAddress
            // 
            this.txtOBSAddress.ForeColor = System.Drawing.Color.Silver;
            this.txtOBSAddress.Location = new System.Drawing.Point(66, 18);
            this.txtOBSAddress.Name = "txtOBSAddress";
            this.txtOBSAddress.Size = new System.Drawing.Size(175, 20);
            this.txtOBSAddress.TabIndex = 0;
            this.txtOBSAddress.Text = "ws://127.0.0.1:4444";
            this.txtOBSAddress.TextChanged += new System.EventHandler(this.txtOBSAddress_TextChanged);
            this.txtOBSAddress.Enter += new System.EventHandler(this.txtOBSAddress_Enter);
            this.txtOBSAddress.Leave += new System.EventHandler(this.txtOBSAddress_Leave);
            // 
            // lblOBSPassword
            // 
            this.lblOBSPassword.AutoSize = true;
            this.lblOBSPassword.Location = new System.Drawing.Point(5, 47);
            this.lblOBSPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOBSPassword.Name = "lblOBSPassword";
            this.lblOBSPassword.Size = new System.Drawing.Size(56, 13);
            this.lblOBSPassword.TabIndex = 11;
            this.lblOBSPassword.Text = "Password:";
            // 
            // txtOBSPassword
            // 
            this.txtOBSPassword.Location = new System.Drawing.Point(66, 44);
            this.txtOBSPassword.Name = "txtOBSPassword";
            this.txtOBSPassword.Size = new System.Drawing.Size(175, 20);
            this.txtOBSPassword.TabIndex = 1;
            this.txtOBSPassword.UseSystemPasswordChar = true;
            this.txtOBSPassword.TextChanged += new System.EventHandler(this.txtOBSPassword_TextChanged);
            this.txtOBSPassword.DoubleClick += new System.EventHandler(this.txtOBSPassword_DoubleClick);
            // 
            // dsOBSGameSource
            // 
            this.dsOBSGameSource.DataSource = typeof(OBSWebsocketDotNet.Types.SourceInfo);
            // 
            // lblDistortInterval
            // 
            this.lblDistortInterval.AutoSize = true;
            this.lblDistortInterval.Location = new System.Drawing.Point(33, 22);
            this.lblDistortInterval.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDistortInterval.Name = "lblDistortInterval";
            this.lblDistortInterval.Size = new System.Drawing.Size(45, 13);
            this.lblDistortInterval.TabIndex = 23;
            this.lblDistortInterval.Text = "Interval:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 216);
            this.Controls.Add(this.tabbarMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "ConTroll";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.tabbarMain.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsSNIDevice)).EndInit();
            this.tabConfig.ResumeLayout(false);
            this.tabConfig.PerformLayout();
            this.grpDistortion.ResumeLayout(false);
            this.grpDistortion.PerformLayout();
            this.tabConnection.ResumeLayout(false);
            this.grpSNI.ResumeLayout(false);
            this.grpSNI.PerformLayout();
            this.grpOBSSettings.ResumeLayout(false);
            this.grpOBSSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsOBSGameSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabbarMain;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabConnection;
        private System.Windows.Forms.Label lblOBSPassword;
        private System.Windows.Forms.Label lblObsAddress;
        private System.Windows.Forms.TextBox txtOBSPassword;
        private System.Windows.Forms.TextBox txtOBSAddress;
        private System.Windows.Forms.GroupBox grpOBSSettings;
        private System.Windows.Forms.Button btnDeviceRefresh;
        private System.Windows.Forms.ComboBox cboDevices;
        private System.Windows.Forms.GroupBox grpSNI;
        private System.Windows.Forms.Label lblSNIAddress;
        private System.Windows.Forms.TextBox txtSNIAddress;
        private System.Windows.Forms.BindingSource dsSNIDevice;
        private System.Windows.Forms.Label lblDevices;
        private System.Windows.Forms.Label lblOBSStatus;
        private System.Windows.Forms.Button btnOBSStatus;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.ComboBox cboOBSGameSource;
        private System.Windows.Forms.BindingSource dsOBSGameSource;
        private System.Windows.Forms.Label lblOBSGameSource;
        private System.Windows.Forms.Label lblActivityDistortion;
        public System.Windows.Forms.Button btnActivityDistortion;
        private System.Windows.Forms.GroupBox grpDistortion;
        private System.Windows.Forms.Label lblDistortAdjustY;
        private System.Windows.Forms.TextBox txtDistortAdjustY;
        private System.Windows.Forms.Label lblDistortAdjustX;
        private System.Windows.Forms.TextBox txtDistortAdjustX;
        private System.Windows.Forms.Label lblDistortTilt;
        private System.Windows.Forms.TextBox txtDistortTilt;
        private System.Windows.Forms.Label lblDistortDuration;
        private System.Windows.Forms.TextBox txtDistortDuration;
        private System.Windows.Forms.TextBox txtDistortInterval;
        private System.Windows.Forms.CheckBox chkDistortShearY;
        private System.Windows.Forms.CheckBox chkDistortShearX;
        private System.Windows.Forms.CheckBox chkDistortScaleY;
        private System.Windows.Forms.CheckBox chkDistortScaleX;
        private System.Windows.Forms.CheckBox chkDistortZoom;
        private System.Windows.Forms.CheckBox chkDistortRotate;
        private System.Windows.Forms.CheckBox chkDistortMirrorY;
        private System.Windows.Forms.CheckBox chkDistortMirrorX;
        private System.Windows.Forms.Label lblDistortInterval;
    }
}

