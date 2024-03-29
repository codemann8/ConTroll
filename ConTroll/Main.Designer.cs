﻿
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
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.grpDistortion = new System.Windows.Forms.GroupBox();
            this.lblDistortColorDuration = new System.Windows.Forms.Label();
            this.txtDistortColorDuration = new System.Windows.Forms.TextBox();
            this.chkDistortColor = new System.Windows.Forms.CheckBox();
            this.chkDistortShearY = new System.Windows.Forms.CheckBox();
            this.chkDistortShearX = new System.Windows.Forms.CheckBox();
            this.chkDistortScaleY = new System.Windows.Forms.CheckBox();
            this.chkDistortScaleX = new System.Windows.Forms.CheckBox();
            this.chkDistortZoom = new System.Windows.Forms.CheckBox();
            this.chkDistortRotate = new System.Windows.Forms.CheckBox();
            this.chkDistortMirrorY = new System.Windows.Forms.CheckBox();
            this.chkDistortMirrorX = new System.Windows.Forms.CheckBox();
            this.lblDistortInterval = new System.Windows.Forms.Label();
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
            this.lblDevices = new System.Windows.Forms.Label();
            this.cboDevices = new System.Windows.Forms.ComboBox();
            this.dsSNIDevice = new System.Windows.Forms.BindingSource(this.components);
            this.lblSNIAddress = new System.Windows.Forms.Label();
            this.txtSNIAddress = new System.Windows.Forms.TextBox();
            this.grpOBSSettings = new System.Windows.Forms.GroupBox();
            this.lblOBSAddress = new System.Windows.Forms.Label();
            this.txtOBSAddress = new System.Windows.Forms.TextBox();
            this.lblOBSPassword = new System.Windows.Forms.Label();
            this.txtOBSPassword = new System.Windows.Forms.TextBox();
            this.dsOBSGameSource = new System.Windows.Forms.BindingSource(this.components);
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.btnSNIStatus = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblSNIStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnOBSStatus = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblOBSStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.tabbarMain.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabConfig.SuspendLayout();
            this.grpDistortion.SuspendLayout();
            this.tabConnection.SuspendLayout();
            this.grpSNI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsSNIDevice)).BeginInit();
            this.grpOBSSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsOBSGameSource)).BeginInit();
            this.stsMain.SuspendLayout();
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
            this.tabbarMain.Size = new System.Drawing.Size(294, 226);
            this.tabbarMain.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.lblActivityDistortion);
            this.tabMain.Controls.Add(this.btnActivityDistortion);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(286, 200);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // lblActivityDistortion
            // 
            this.lblActivityDistortion.AutoSize = true;
            this.lblActivityDistortion.Location = new System.Drawing.Point(5, 11);
            this.lblActivityDistortion.Name = "lblActivityDistortion";
            this.lblActivityDistortion.Size = new System.Drawing.Size(86, 13);
            this.lblActivityDistortion.TabIndex = 6;
            this.lblActivityDistortion.Text = "Social Distortion:";
            // 
            // btnActivityDistortion
            // 
            this.btnActivityDistortion.Image = global::ConTroll.Properties.Resources.OnlineStatusUnknown;
            this.btnActivityDistortion.Location = new System.Drawing.Point(97, 6);
            this.btnActivityDistortion.Name = "btnActivityDistortion";
            this.btnActivityDistortion.Size = new System.Drawing.Size(23, 23);
            this.btnActivityDistortion.TabIndex = 5;
            this.btnActivityDistortion.UseVisualStyleBackColor = true;
            this.btnActivityDistortion.Click += new System.EventHandler(this.btnActivityDistortion_Click);
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.grpDistortion);
            this.tabConfig.Controls.Add(this.lblOBSGameSource);
            this.tabConfig.Controls.Add(this.cboOBSGameSource);
            this.tabConfig.Location = new System.Drawing.Point(4, 22);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfig.Size = new System.Drawing.Size(286, 200);
            this.tabConfig.TabIndex = 2;
            this.tabConfig.Text = "Config";
            this.tabConfig.UseVisualStyleBackColor = true;
            // 
            // grpDistortion
            // 
            this.grpDistortion.Controls.Add(this.lblDistortColorDuration);
            this.grpDistortion.Controls.Add(this.txtDistortColorDuration);
            this.grpDistortion.Controls.Add(this.chkDistortColor);
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
            this.grpDistortion.Location = new System.Drawing.Point(6, 33);
            this.grpDistortion.Name = "grpDistortion";
            this.grpDistortion.Size = new System.Drawing.Size(273, 163);
            this.grpDistortion.TabIndex = 2;
            this.grpDistortion.TabStop = false;
            this.grpDistortion.Text = "Social Distortion";
            // 
            // lblDistortColorDuration
            // 
            this.lblDistortColorDuration.AutoSize = true;
            this.lblDistortColorDuration.Location = new System.Drawing.Point(2, 140);
            this.lblDistortColorDuration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDistortColorDuration.Name = "lblDistortColorDuration";
            this.lblDistortColorDuration.Size = new System.Drawing.Size(77, 13);
            this.lblDistortColorDuration.TabIndex = 10;
            this.lblDistortColorDuration.Text = "Color Duration:";
            // 
            // txtDistortColorDuration
            // 
            this.txtDistortColorDuration.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDistortColorDuration.Location = new System.Drawing.Point(81, 137);
            this.txtDistortColorDuration.Name = "txtDistortColorDuration";
            this.txtDistortColorDuration.Size = new System.Drawing.Size(56, 20);
            this.txtDistortColorDuration.TabIndex = 11;
            this.txtDistortColorDuration.TextChanged += new System.EventHandler(this.txtDistortColorDuration_TextChanged);
            // 
            // chkDistortColor
            // 
            this.chkDistortColor.AutoSize = true;
            this.chkDistortColor.Location = new System.Drawing.Point(150, 139);
            this.chkDistortColor.Name = "chkDistortColor";
            this.chkDistortColor.Size = new System.Drawing.Size(63, 17);
            this.chkDistortColor.TabIndex = 31;
            this.chkDistortColor.Text = "Colorize";
            this.chkDistortColor.ThreeState = true;
            this.chkDistortColor.UseVisualStyleBackColor = true;
            this.chkDistortColor.CheckStateChanged += new System.EventHandler(this.chkDistortColor_CheckStateChanged);
            this.chkDistortColor.Click += new System.EventHandler(this.chkDistortColor_Click);
            // 
            // chkDistortShearY
            // 
            this.chkDistortShearY.AutoSize = true;
            this.chkDistortShearY.Location = new System.Drawing.Point(150, 124);
            this.chkDistortShearY.Name = "chkDistortShearY";
            this.chkDistortShearY.Size = new System.Drawing.Size(92, 17);
            this.chkDistortShearY.TabIndex = 30;
            this.chkDistortShearY.Text = "Shear Vertical";
            this.chkDistortShearY.ThreeState = true;
            this.chkDistortShearY.UseVisualStyleBackColor = true;
            this.chkDistortShearY.CheckStateChanged += new System.EventHandler(this.chkDistortShearY_CheckStateChanged);
            this.chkDistortShearY.Click += new System.EventHandler(this.chkDistortShearY_Click);
            // 
            // chkDistortShearX
            // 
            this.chkDistortShearX.AutoSize = true;
            this.chkDistortShearX.Location = new System.Drawing.Point(150, 109);
            this.chkDistortShearX.Name = "chkDistortShearX";
            this.chkDistortShearX.Size = new System.Drawing.Size(104, 17);
            this.chkDistortShearX.TabIndex = 29;
            this.chkDistortShearX.Text = "Shear Horizontal";
            this.chkDistortShearX.ThreeState = true;
            this.chkDistortShearX.UseVisualStyleBackColor = true;
            this.chkDistortShearX.CheckStateChanged += new System.EventHandler(this.chkDistortShearX_CheckStateChanged);
            this.chkDistortShearX.Click += new System.EventHandler(this.chkDistortShearX_Click);
            // 
            // chkDistortScaleY
            // 
            this.chkDistortScaleY.AutoSize = true;
            this.chkDistortScaleY.Location = new System.Drawing.Point(150, 94);
            this.chkDistortScaleY.Name = "chkDistortScaleY";
            this.chkDistortScaleY.Size = new System.Drawing.Size(96, 17);
            this.chkDistortScaleY.TabIndex = 28;
            this.chkDistortScaleY.Text = "Squish Vertical";
            this.chkDistortScaleY.ThreeState = true;
            this.chkDistortScaleY.UseVisualStyleBackColor = true;
            this.chkDistortScaleY.CheckStateChanged += new System.EventHandler(this.chkDistortScaleY_CheckStateChanged);
            this.chkDistortScaleY.Click += new System.EventHandler(this.chkDistortScaleY_Click);
            // 
            // chkDistortScaleX
            // 
            this.chkDistortScaleX.AutoSize = true;
            this.chkDistortScaleX.Location = new System.Drawing.Point(150, 79);
            this.chkDistortScaleX.Name = "chkDistortScaleX";
            this.chkDistortScaleX.Size = new System.Drawing.Size(108, 17);
            this.chkDistortScaleX.TabIndex = 27;
            this.chkDistortScaleX.Text = "Squish Horizontal";
            this.chkDistortScaleX.ThreeState = true;
            this.chkDistortScaleX.UseVisualStyleBackColor = true;
            this.chkDistortScaleX.CheckStateChanged += new System.EventHandler(this.chkDistortScaleX_CheckStateChanged);
            this.chkDistortScaleX.Click += new System.EventHandler(this.chkDistortScaleX_Click);
            // 
            // chkDistortZoom
            // 
            this.chkDistortZoom.AutoSize = true;
            this.chkDistortZoom.Location = new System.Drawing.Point(150, 64);
            this.chkDistortZoom.Name = "chkDistortZoom";
            this.chkDistortZoom.Size = new System.Drawing.Size(65, 17);
            this.chkDistortZoom.TabIndex = 26;
            this.chkDistortZoom.Text = "Zoom In";
            this.chkDistortZoom.ThreeState = true;
            this.chkDistortZoom.UseVisualStyleBackColor = true;
            this.chkDistortZoom.CheckStateChanged += new System.EventHandler(this.chkDistortZoom_CheckStateChanged);
            this.chkDistortZoom.Click += new System.EventHandler(this.chkDistortZoom_Click);
            // 
            // chkDistortRotate
            // 
            this.chkDistortRotate.AutoSize = true;
            this.chkDistortRotate.Location = new System.Drawing.Point(150, 49);
            this.chkDistortRotate.Name = "chkDistortRotate";
            this.chkDistortRotate.Size = new System.Drawing.Size(79, 17);
            this.chkDistortRotate.TabIndex = 25;
            this.chkDistortRotate.Text = "Rotate 180";
            this.chkDistortRotate.ThreeState = true;
            this.chkDistortRotate.UseVisualStyleBackColor = true;
            this.chkDistortRotate.CheckStateChanged += new System.EventHandler(this.chkDistortRotate_CheckStateChanged);
            this.chkDistortRotate.Click += new System.EventHandler(this.chkDistortRotate_Click);
            // 
            // chkDistortMirrorY
            // 
            this.chkDistortMirrorY.AutoSize = true;
            this.chkDistortMirrorY.Location = new System.Drawing.Point(150, 34);
            this.chkDistortMirrorY.Name = "chkDistortMirrorY";
            this.chkDistortMirrorY.Size = new System.Drawing.Size(90, 17);
            this.chkDistortMirrorY.TabIndex = 24;
            this.chkDistortMirrorY.Text = "Mirror Vertical";
            this.chkDistortMirrorY.ThreeState = true;
            this.chkDistortMirrorY.UseVisualStyleBackColor = true;
            this.chkDistortMirrorY.CheckStateChanged += new System.EventHandler(this.chkDistortMirrorY_CheckStateChanged);
            this.chkDistortMirrorY.Click += new System.EventHandler(this.chkDistortMirrorY_Click);
            // 
            // chkDistortMirrorX
            // 
            this.chkDistortMirrorX.AutoSize = true;
            this.chkDistortMirrorX.Location = new System.Drawing.Point(150, 19);
            this.chkDistortMirrorX.Name = "chkDistortMirrorX";
            this.chkDistortMirrorX.Size = new System.Drawing.Size(102, 17);
            this.chkDistortMirrorX.TabIndex = 23;
            this.chkDistortMirrorX.Text = "Mirror Horizontal";
            this.chkDistortMirrorX.ThreeState = true;
            this.chkDistortMirrorX.UseVisualStyleBackColor = true;
            this.chkDistortMirrorX.CheckStateChanged += new System.EventHandler(this.chkDistortMirrorX_CheckStateChanged);
            this.chkDistortMirrorX.Click += new System.EventHandler(this.chkDistortMirrorX_Click);
            // 
            // lblDistortInterval
            // 
            this.lblDistortInterval.AutoSize = true;
            this.lblDistortInterval.Location = new System.Drawing.Point(34, 20);
            this.lblDistortInterval.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDistortInterval.Name = "lblDistortInterval";
            this.lblDistortInterval.Size = new System.Drawing.Size(45, 13);
            this.lblDistortInterval.TabIndex = 0;
            this.lblDistortInterval.Text = "Interval:";
            // 
            // txtDistortInterval
            // 
            this.txtDistortInterval.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDistortInterval.Location = new System.Drawing.Point(81, 17);
            this.txtDistortInterval.Name = "txtDistortInterval";
            this.txtDistortInterval.Size = new System.Drawing.Size(56, 20);
            this.txtDistortInterval.TabIndex = 1;
            this.txtDistortInterval.TextChanged += new System.EventHandler(this.txtDistortInterval_TextChanged);
            // 
            // lblDistortAdjustY
            // 
            this.lblDistortAdjustY.AutoSize = true;
            this.lblDistortAdjustY.Location = new System.Drawing.Point(7, 116);
            this.lblDistortAdjustY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDistortAdjustY.Name = "lblDistortAdjustY";
            this.lblDistortAdjustY.Size = new System.Drawing.Size(72, 13);
            this.lblDistortAdjustY.TabIndex = 8;
            this.lblDistortAdjustY.Text = "Y Adjustment:";
            // 
            // txtDistortAdjustY
            // 
            this.txtDistortAdjustY.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDistortAdjustY.Location = new System.Drawing.Point(81, 113);
            this.txtDistortAdjustY.Name = "txtDistortAdjustY";
            this.txtDistortAdjustY.Size = new System.Drawing.Size(56, 20);
            this.txtDistortAdjustY.TabIndex = 9;
            this.txtDistortAdjustY.TextChanged += new System.EventHandler(this.txtDistortAdjustY_TextChanged);
            // 
            // lblDistortAdjustX
            // 
            this.lblDistortAdjustX.AutoSize = true;
            this.lblDistortAdjustX.Location = new System.Drawing.Point(7, 92);
            this.lblDistortAdjustX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDistortAdjustX.Name = "lblDistortAdjustX";
            this.lblDistortAdjustX.Size = new System.Drawing.Size(72, 13);
            this.lblDistortAdjustX.TabIndex = 6;
            this.lblDistortAdjustX.Text = "X Adjustment:";
            // 
            // txtDistortAdjustX
            // 
            this.txtDistortAdjustX.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDistortAdjustX.Location = new System.Drawing.Point(81, 89);
            this.txtDistortAdjustX.Name = "txtDistortAdjustX";
            this.txtDistortAdjustX.Size = new System.Drawing.Size(56, 20);
            this.txtDistortAdjustX.TabIndex = 7;
            this.txtDistortAdjustX.TextChanged += new System.EventHandler(this.txtDistortAdjustX_TextChanged);
            // 
            // lblDistortTilt
            // 
            this.lblDistortTilt.AutoSize = true;
            this.lblDistortTilt.Location = new System.Drawing.Point(32, 68);
            this.lblDistortTilt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDistortTilt.Name = "lblDistortTilt";
            this.lblDistortTilt.Size = new System.Drawing.Size(47, 13);
            this.lblDistortTilt.TabIndex = 4;
            this.lblDistortTilt.Text = "Max Tilt:";
            // 
            // txtDistortTilt
            // 
            this.txtDistortTilt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDistortTilt.Location = new System.Drawing.Point(81, 65);
            this.txtDistortTilt.Name = "txtDistortTilt";
            this.txtDistortTilt.Size = new System.Drawing.Size(56, 20);
            this.txtDistortTilt.TabIndex = 5;
            this.txtDistortTilt.TextChanged += new System.EventHandler(this.txtDistortTilt_TextChanged);
            // 
            // lblDistortDuration
            // 
            this.lblDistortDuration.AutoSize = true;
            this.lblDistortDuration.Location = new System.Drawing.Point(29, 44);
            this.lblDistortDuration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDistortDuration.Name = "lblDistortDuration";
            this.lblDistortDuration.Size = new System.Drawing.Size(50, 13);
            this.lblDistortDuration.TabIndex = 2;
            this.lblDistortDuration.Text = "Duration:";
            // 
            // txtDistortDuration
            // 
            this.txtDistortDuration.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDistortDuration.Location = new System.Drawing.Point(81, 41);
            this.txtDistortDuration.Name = "txtDistortDuration";
            this.txtDistortDuration.Size = new System.Drawing.Size(56, 20);
            this.txtDistortDuration.TabIndex = 3;
            this.txtDistortDuration.TextChanged += new System.EventHandler(this.txtDistortDuration_TextChanged);
            // 
            // lblOBSGameSource
            // 
            this.lblOBSGameSource.AutoSize = true;
            this.lblOBSGameSource.Location = new System.Drawing.Point(7, 9);
            this.lblOBSGameSource.Name = "lblOBSGameSource";
            this.lblOBSGameSource.Size = new System.Drawing.Size(75, 13);
            this.lblOBSGameSource.TabIndex = 0;
            this.lblOBSGameSource.Text = "Game Source:";
            // 
            // cboOBSGameSource
            // 
            this.cboOBSGameSource.DisplayMember = "Name";
            this.cboOBSGameSource.FormattingEnabled = true;
            this.cboOBSGameSource.Location = new System.Drawing.Point(88, 6);
            this.cboOBSGameSource.Name = "cboOBSGameSource";
            this.cboOBSGameSource.Size = new System.Drawing.Size(145, 21);
            this.cboOBSGameSource.TabIndex = 1;
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
            this.tabConnection.Size = new System.Drawing.Size(286, 200);
            this.tabConnection.TabIndex = 1;
            this.tabConnection.Text = "Connection";
            this.tabConnection.UseVisualStyleBackColor = true;
            // 
            // grpSNI
            // 
            this.grpSNI.Controls.Add(this.lblDevices);
            this.grpSNI.Controls.Add(this.cboDevices);
            this.grpSNI.Controls.Add(this.lblSNIAddress);
            this.grpSNI.Controls.Add(this.txtSNIAddress);
            this.grpSNI.Location = new System.Drawing.Point(8, 84);
            this.grpSNI.Name = "grpSNI";
            this.grpSNI.Size = new System.Drawing.Size(248, 75);
            this.grpSNI.TabIndex = 14;
            this.grpSNI.TabStop = false;
            this.grpSNI.Text = "SNI Connection";
            // 
            // lblDevices
            // 
            this.lblDevices.AutoSize = true;
            this.lblDevices.Location = new System.Drawing.Point(5, 49);
            this.lblDevices.Name = "lblDevices";
            this.lblDevices.Size = new System.Drawing.Size(44, 13);
            this.lblDevices.TabIndex = 15;
            this.lblDevices.Text = "Device:";
            // 
            // cboDevices
            // 
            this.cboDevices.DataSource = this.dsSNIDevice;
            this.cboDevices.DisplayMember = "DisplayName";
            this.cboDevices.FormattingEnabled = true;
            this.cboDevices.Location = new System.Drawing.Point(66, 46);
            this.cboDevices.Name = "cboDevices";
            this.cboDevices.Size = new System.Drawing.Size(175, 21);
            this.cboDevices.TabIndex = 14;
            // 
            // dsSNIDevice
            // 
            this.dsSNIDevice.DataSource = typeof(SNI.DevicesResponse.Types.Device);
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
            this.txtSNIAddress.Enter += new System.EventHandler(this.txtSNIAddress_Enter);
            this.txtSNIAddress.Leave += new System.EventHandler(this.txtSNIAddress_Leave);
            // 
            // grpOBSSettings
            // 
            this.grpOBSSettings.Controls.Add(this.lblOBSAddress);
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
            // lblOBSAddress
            // 
            this.lblOBSAddress.AutoSize = true;
            this.lblOBSAddress.Location = new System.Drawing.Point(5, 21);
            this.lblOBSAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOBSAddress.Name = "lblOBSAddress";
            this.lblOBSAddress.Size = new System.Drawing.Size(48, 13);
            this.lblOBSAddress.TabIndex = 9;
            this.lblOBSAddress.Text = "Address:";
            // 
            // txtOBSAddress
            // 
            this.txtOBSAddress.ForeColor = System.Drawing.Color.Silver;
            this.txtOBSAddress.Location = new System.Drawing.Point(66, 18);
            this.txtOBSAddress.Name = "txtOBSAddress";
            this.txtOBSAddress.Size = new System.Drawing.Size(175, 20);
            this.txtOBSAddress.TabIndex = 0;
            this.txtOBSAddress.Text = "ws://127.0.0.1:4444";
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
            // stsMain
            // 
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSNIStatus,
            this.lblSNIStatus,
            this.btnOBSStatus,
            this.lblOBSStatus});
            this.stsMain.Location = new System.Drawing.Point(0, 224);
            this.stsMain.Name = "stsMain";
            this.stsMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.stsMain.Size = new System.Drawing.Size(292, 24);
            this.stsMain.TabIndex = 1;
            // 
            // btnSNIStatus
            // 
            this.btnSNIStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSNIStatus.Image = global::ConTroll.Properties.Resources.OnlineStatusUnknown;
            this.btnSNIStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSNIStatus.Name = "btnSNIStatus";
            this.btnSNIStatus.ShowDropDownArrow = false;
            this.btnSNIStatus.Size = new System.Drawing.Size(20, 22);
            this.btnSNIStatus.ToolTipText = "Disconnected";
            this.btnSNIStatus.MouseLeave += new System.EventHandler(this.btnSNIStatus_MouseLeave);
            this.btnSNIStatus.MouseHover += new System.EventHandler(this.btnSNIStatus_MouseHover);
            // 
            // lblSNIStatus
            // 
            this.lblSNIStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblSNIStatus.Name = "lblSNIStatus";
            this.lblSNIStatus.Size = new System.Drawing.Size(29, 19);
            this.lblSNIStatus.Text = "SNI";
            // 
            // btnOBSStatus
            // 
            this.btnOBSStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOBSStatus.Image = global::ConTroll.Properties.Resources.OnlineStatusUnknown;
            this.btnOBSStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOBSStatus.Name = "btnOBSStatus";
            this.btnOBSStatus.ShowDropDownArrow = false;
            this.btnOBSStatus.Size = new System.Drawing.Size(20, 22);
            this.btnOBSStatus.Text = "OBS";
            this.btnOBSStatus.ToolTipText = "Disconnected";
            this.btnOBSStatus.Click += new System.EventHandler(this.btnOBSStatus_Click);
            this.btnOBSStatus.MouseLeave += new System.EventHandler(this.btnOBSStatus_MouseLeave);
            this.btnOBSStatus.MouseHover += new System.EventHandler(this.btnOBSStatus_MouseHover);
            // 
            // lblOBSStatus
            // 
            this.lblOBSStatus.Name = "lblOBSStatus";
            this.lblOBSStatus.Size = new System.Drawing.Size(29, 19);
            this.lblOBSStatus.Text = "OBS";
            // 
            // tooltip
            // 
            this.tooltip.ShowAlways = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 248);
            this.Controls.Add(this.stsMain);
            this.Controls.Add(this.tabbarMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "ConTroll";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.tabbarMain.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.tabConfig.ResumeLayout(false);
            this.tabConfig.PerformLayout();
            this.grpDistortion.ResumeLayout(false);
            this.grpDistortion.PerformLayout();
            this.tabConnection.ResumeLayout(false);
            this.grpSNI.ResumeLayout(false);
            this.grpSNI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsSNIDevice)).EndInit();
            this.grpOBSSettings.ResumeLayout(false);
            this.grpOBSSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsOBSGameSource)).EndInit();
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabbarMain;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabConnection;
        private System.Windows.Forms.Label lblOBSPassword;
        private System.Windows.Forms.Label lblOBSAddress;
        private System.Windows.Forms.TextBox txtOBSPassword;
        private System.Windows.Forms.TextBox txtOBSAddress;
        private System.Windows.Forms.GroupBox grpOBSSettings;
        private System.Windows.Forms.GroupBox grpSNI;
        private System.Windows.Forms.Label lblSNIAddress;
        private System.Windows.Forms.TextBox txtSNIAddress;
        private System.Windows.Forms.BindingSource dsSNIDevice;
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
        private System.Windows.Forms.StatusStrip stsMain;
        private System.Windows.Forms.ToolStripDropDownButton btnSNIStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblSNIStatus;
        private System.Windows.Forms.ToolStripDropDownButton btnOBSStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblOBSStatus;
        private System.Windows.Forms.Label lblDevices;
        private System.Windows.Forms.ComboBox cboDevices;
        public System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.CheckBox chkDistortColor;
        private System.Windows.Forms.Label lblDistortColorDuration;
        private System.Windows.Forms.TextBox txtDistortColorDuration;
    }
}

