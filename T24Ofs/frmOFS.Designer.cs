namespace T24OfsTool
{
    partial class frmOFS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOFS));
            this.label1 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.lblTimeStart = new System.Windows.Forms.Label();
            this.lblTimeEnd = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboProfile = new System.Windows.Forms.ComboBox();
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.cboMessageType = new System.Windows.Forms.ComboBox();
            this.txtThread = new System.Windows.Forms.TextBox();
            this.btnPause = new System.Windows.Forms.Button();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.tabRequest = new System.Windows.Forms.TabPage();
            this.toolRequest = new System.Windows.Forms.ToolStrip();
            this.btnFileOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnWrapText = new System.Windows.Forms.ToolStripButton();
            this.btnShowResponse = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblRequestNumer = new System.Windows.Forms.ToolStripLabel();
            this.splitOFS = new System.Windows.Forms.SplitContainer();
            this.txtRequest = new System.Windows.Forms.TextBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabThread = new System.Windows.Forms.TabPage();
            this.grpThreadMode = new System.Windows.Forms.GroupBox();
            this.cboThreadSourceMode = new System.Windows.Forms.ComboBox();
            this.cboDataSource = new System.Windows.Forms.ComboBox();
            this.grpThread = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpThreadLocation = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnOutputFile = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.btnOutputFolder = new System.Windows.Forms.Button();
            this.btnInputFolder = new System.Windows.Forms.Button();
            this.txtOutputFolderPath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtInputFolderPath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lsThread = new System.Windows.Forms.ListView();
            this.colNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFailure = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProgress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabGrid = new System.Windows.Forms.TabPage();
            this.grdEnquiryResult = new System.Windows.Forms.DataGridView();
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.grpConnection.SuspendLayout();
            this.tabRequest.SuspendLayout();
            this.toolRequest.SuspendLayout();
            this.splitOFS.Panel1.SuspendLayout();
            this.splitOFS.Panel2.SuspendLayout();
            this.splitOFS.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabThread.SuspendLayout();
            this.grpThreadMode.SuspendLayout();
            this.grpThread.SuspendLayout();
            this.grpThreadLocation.SuspendLayout();
            this.tabGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEnquiryResult)).BeginInit();
            this.grpResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(197, 27);
            this.txtServer.MaxLength = 15;
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(76, 20);
            this.txtServer.TabIndex = 4;
            this.txtServer.Text = "10.37.16.201";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(346, 27);
            this.txtPort.MaxLength = 5;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(69, 20);
            this.txtPort.TabIndex = 5;
            this.txtPort.Text = "7023";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Port";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(585, 12);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(106, 80);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "&Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lblTimeStart
            // 
            this.lblTimeStart.Location = new System.Drawing.Point(49, 23);
            this.lblTimeStart.Name = "lblTimeStart";
            this.lblTimeStart.Size = new System.Drawing.Size(81, 13);
            this.lblTimeStart.TabIndex = 2;
            this.lblTimeStart.Text = "...";
            this.lblTimeStart.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTimeEnd
            // 
            this.lblTimeEnd.Location = new System.Drawing.Point(52, 41);
            this.lblTimeEnd.Name = "lblTimeEnd";
            this.lblTimeEnd.Size = new System.Drawing.Size(78, 13);
            this.lblTimeEnd.TabIndex = 4;
            this.lblTimeEnd.Text = "...";
            this.lblTimeEnd.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDuration
            // 
            this.lblDuration.Location = new System.Drawing.Point(52, 59);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(78, 13);
            this.lblDuration.TabIndex = 6;
            this.lblDuration.Text = "...";
            this.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(346, 53);
            this.txtPass.MaxLength = 35;
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(69, 20);
            this.txtPass.TabIndex = 7;
            this.txtPass.Text = "123456";
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(290, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Password";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(197, 53);
            this.txtUser.MaxLength = 35;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(76, 20);
            this.txtUser.TabIndex = 6;
            this.txtUser.Text = "LHHA02";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(125, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Sign on name";
            // 
            // cboProfile
            // 
            this.cboProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProfile.FormattingEnabled = true;
            this.cboProfile.Items.AddRange(new object[] {
            "T24Test",
            "T24Dev"});
            this.cboProfile.Location = new System.Drawing.Point(16, 27);
            this.cboProfile.Name = "cboProfile";
            this.cboProfile.Size = new System.Drawing.Size(100, 21);
            this.cboProfile.TabIndex = 0;
            this.cboProfile.SelectedIndexChanged += new System.EventHandler(this.cboProfile_SelectedIndexChanged);
            // 
            // grpConnection
            // 
            this.grpConnection.Controls.Add(this.cboMessageType);
            this.grpConnection.Controls.Add(this.txtServer);
            this.grpConnection.Controls.Add(this.label1);
            this.grpConnection.Controls.Add(this.cboProfile);
            this.grpConnection.Controls.Add(this.label2);
            this.grpConnection.Controls.Add(this.txtPass);
            this.grpConnection.Controls.Add(this.txtPort);
            this.grpConnection.Controls.Add(this.label6);
            this.grpConnection.Controls.Add(this.label7);
            this.grpConnection.Controls.Add(this.txtUser);
            this.grpConnection.Location = new System.Drawing.Point(6, 8);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Size = new System.Drawing.Size(429, 84);
            this.grpConnection.TabIndex = 0;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Ofs Connection";
            // 
            // cboMessageType
            // 
            this.cboMessageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMessageType.FormattingEnabled = true;
            this.cboMessageType.Items.AddRange(new object[] {
            "OFS",
            "ISO"});
            this.cboMessageType.Location = new System.Drawing.Point(16, 53);
            this.cboMessageType.Name = "cboMessageType";
            this.cboMessageType.Size = new System.Drawing.Size(100, 21);
            this.cboMessageType.TabIndex = 1;
            this.cboMessageType.SelectedIndexChanged += new System.EventHandler(this.cboMessageType_SelectedIndexChanged);
            // 
            // txtThread
            // 
            this.txtThread.Location = new System.Drawing.Point(58, 25);
            this.txtThread.MaxLength = 3;
            this.txtThread.Name = "txtThread";
            this.txtThread.Size = new System.Drawing.Size(40, 20);
            this.txtThread.TabIndex = 1;
            this.txtThread.Text = "1";
            this.txtThread.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(585, 12);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(106, 35);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "&Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Visible = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // txtResponse
            // 
            this.txtResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResponse.Location = new System.Drawing.Point(0, 0);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ReadOnly = true;
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResponse.Size = new System.Drawing.Size(681, 95);
            this.txtResponse.TabIndex = 0;
            // 
            // tabRequest
            // 
            this.tabRequest.Controls.Add(this.toolRequest);
            this.tabRequest.Controls.Add(this.splitOFS);
            this.tabRequest.Location = new System.Drawing.Point(4, 22);
            this.tabRequest.Name = "tabRequest";
            this.tabRequest.Padding = new System.Windows.Forms.Padding(3);
            this.tabRequest.Size = new System.Drawing.Size(687, 285);
            this.tabRequest.TabIndex = 0;
            this.tabRequest.Text = "Ofs Message";
            this.tabRequest.UseVisualStyleBackColor = true;
            // 
            // toolRequest
            // 
            this.toolRequest.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFileOpen,
            this.toolStripSeparator1,
            this.btnWrapText,
            this.btnShowResponse,
            this.toolStripSeparator2,
            this.lblRequestNumer});
            this.toolRequest.Location = new System.Drawing.Point(3, 3);
            this.toolRequest.Name = "toolRequest";
            this.toolRequest.Size = new System.Drawing.Size(681, 25);
            this.toolRequest.TabIndex = 6;
            this.toolRequest.Text = "toolStrip1";
            // 
            // btnFileOpen
            // 
            this.btnFileOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnFileOpen.Image")));
            this.btnFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFileOpen.Name = "btnFileOpen";
            this.btnFileOpen.Size = new System.Drawing.Size(23, 22);
            this.btnFileOpen.Text = "Open Ofs File";
            this.btnFileOpen.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnWrapText
            // 
            this.btnWrapText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnWrapText.Image = ((System.Drawing.Image)(resources.GetObject("btnWrapText.Image")));
            this.btnWrapText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWrapText.Name = "btnWrapText";
            this.btnWrapText.Size = new System.Drawing.Size(23, 22);
            this.btnWrapText.Text = "Wrap Text";
            this.btnWrapText.Click += new System.EventHandler(this.btnWrapText_Click);
            // 
            // btnShowResponse
            // 
            this.btnShowResponse.Checked = true;
            this.btnShowResponse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnShowResponse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowResponse.Image = ((System.Drawing.Image)(resources.GetObject("btnShowResponse.Image")));
            this.btnShowResponse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowResponse.Name = "btnShowResponse";
            this.btnShowResponse.Size = new System.Drawing.Size(23, 22);
            this.btnShowResponse.Text = "Show Response";
            this.btnShowResponse.Click += new System.EventHandler(this.btnShowResponse_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // lblRequestNumer
            // 
            this.lblRequestNumer.Name = "lblRequestNumer";
            this.lblRequestNumer.Size = new System.Drawing.Size(95, 22);
            this.lblRequestNumer.Text = "Ofs Request No: ";
            // 
            // splitOFS
            // 
            this.splitOFS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitOFS.Location = new System.Drawing.Point(3, 3);
            this.splitOFS.Name = "splitOFS";
            this.splitOFS.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitOFS.Panel1
            // 
            this.splitOFS.Panel1.Controls.Add(this.txtRequest);
            // 
            // splitOFS.Panel2
            // 
            this.splitOFS.Panel2.Controls.Add(this.txtResponse);
            this.splitOFS.Panel2MinSize = 0;
            this.splitOFS.Size = new System.Drawing.Size(681, 279);
            this.splitOFS.SplitterDistance = 180;
            this.splitOFS.TabIndex = 5;
            // 
            // txtRequest
            // 
            this.txtRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRequest.Location = new System.Drawing.Point(0, 26);
            this.txtRequest.MaxLength = 0;
            this.txtRequest.Multiline = true;
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRequest.Size = new System.Drawing.Size(681, 152);
            this.txtRequest.TabIndex = 0;
            this.txtRequest.Text = "ENQUIRY.SELECT,,,VPB.GET.TXN.SUSP.PENDING,SUSPENSE.ACCOUNT:EQ=VND1300600210001";
            this.txtRequest.WordWrap = false;
            this.txtRequest.TextChanged += new System.EventHandler(this.txtRequest_TextChanged);
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabRequest);
            this.tabMain.Controls.Add(this.tabThread);
            this.tabMain.Controls.Add(this.tabGrid);
            this.tabMain.Location = new System.Drawing.Point(6, 98);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(695, 311);
            this.tabMain.TabIndex = 5;
            // 
            // tabThread
            // 
            this.tabThread.Controls.Add(this.grpThreadMode);
            this.tabThread.Controls.Add(this.grpThread);
            this.tabThread.Controls.Add(this.grpThreadLocation);
            this.tabThread.Controls.Add(this.lsThread);
            this.tabThread.Location = new System.Drawing.Point(4, 22);
            this.tabThread.Name = "tabThread";
            this.tabThread.Size = new System.Drawing.Size(687, 285);
            this.tabThread.TabIndex = 3;
            this.tabThread.Text = "Multi Thread";
            this.tabThread.UseVisualStyleBackColor = true;
            // 
            // grpThreadMode
            // 
            this.grpThreadMode.Controls.Add(this.cboThreadSourceMode);
            this.grpThreadMode.Controls.Add(this.cboDataSource);
            this.grpThreadMode.Location = new System.Drawing.Point(118, 4);
            this.grpThreadMode.Name = "grpThreadMode";
            this.grpThreadMode.Size = new System.Drawing.Size(168, 66);
            this.grpThreadMode.TabIndex = 6;
            this.grpThreadMode.TabStop = false;
            this.grpThreadMode.Text = "Thread Mode";
            // 
            // cboThreadSourceMode
            // 
            this.cboThreadSourceMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThreadSourceMode.FormattingEnabled = true;
            this.cboThreadSourceMode.Items.AddRange(new object[] {
            "Source Split",
            "Source Duplicate"});
            this.cboThreadSourceMode.Location = new System.Drawing.Point(19, 39);
            this.cboThreadSourceMode.Name = "cboThreadSourceMode";
            this.cboThreadSourceMode.Size = new System.Drawing.Size(132, 21);
            this.cboThreadSourceMode.TabIndex = 11;
            // 
            // cboDataSource
            // 
            this.cboDataSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataSource.FormattingEnabled = true;
            this.cboDataSource.Items.AddRange(new object[] {
            "Source on form",
            "Source in folder"});
            this.cboDataSource.Location = new System.Drawing.Point(19, 15);
            this.cboDataSource.Name = "cboDataSource";
            this.cboDataSource.Size = new System.Drawing.Size(132, 21);
            this.cboDataSource.TabIndex = 10;
            this.cboDataSource.SelectedIndexChanged += new System.EventHandler(this.cboDataSource_SelectedIndexChanged);
            // 
            // grpThread
            // 
            this.grpThread.Controls.Add(this.txtThread);
            this.grpThread.Controls.Add(this.label3);
            this.grpThread.Location = new System.Drawing.Point(3, 3);
            this.grpThread.Name = "grpThread";
            this.grpThread.Size = new System.Drawing.Size(109, 66);
            this.grpThread.TabIndex = 5;
            this.grpThread.TabStop = false;
            this.grpThread.Text = "Multi Thread";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Thread";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grpThreadLocation
            // 
            this.grpThreadLocation.Controls.Add(this.label12);
            this.grpThreadLocation.Controls.Add(this.btnOutputFile);
            this.grpThreadLocation.Controls.Add(this.label11);
            this.grpThreadLocation.Controls.Add(this.txtInputFile);
            this.grpThreadLocation.Controls.Add(this.btnOutputFolder);
            this.grpThreadLocation.Controls.Add(this.btnInputFolder);
            this.grpThreadLocation.Controls.Add(this.txtOutputFolderPath);
            this.grpThreadLocation.Controls.Add(this.label10);
            this.grpThreadLocation.Controls.Add(this.txtInputFolderPath);
            this.grpThreadLocation.Controls.Add(this.label9);
            this.grpThreadLocation.Location = new System.Drawing.Point(292, 4);
            this.grpThreadLocation.Name = "grpThreadLocation";
            this.grpThreadLocation.Size = new System.Drawing.Size(389, 67);
            this.grpThreadLocation.TabIndex = 4;
            this.grpThreadLocation.TabStop = false;
            this.grpThreadLocation.Text = "Input/Output";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(240, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Output File";
            // 
            // btnOutputFile
            // 
            this.btnOutputFile.Location = new System.Drawing.Point(299, 39);
            this.btnOutputFile.MaxLength = 500;
            this.btnOutputFile.Name = "btnOutputFile";
            this.btnOutputFile.ReadOnly = true;
            this.btnOutputFile.Size = new System.Drawing.Size(79, 20);
            this.btnOutputFile.TabIndex = 13;
            this.btnOutputFile.Text = "Output_xxx.txt";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(240, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Input File";
            // 
            // txtInputFile
            // 
            this.txtInputFile.Location = new System.Drawing.Point(299, 16);
            this.txtInputFile.MaxLength = 500;
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.ReadOnly = true;
            this.txtInputFile.Size = new System.Drawing.Size(79, 20);
            this.txtInputFile.TabIndex = 11;
            this.txtInputFile.Text = "Input_xxx.txt";
            // 
            // btnOutputFolder
            // 
            this.btnOutputFolder.Location = new System.Drawing.Point(200, 40);
            this.btnOutputFolder.Name = "btnOutputFolder";
            this.btnOutputFolder.Size = new System.Drawing.Size(24, 20);
            this.btnOutputFolder.TabIndex = 10;
            this.btnOutputFolder.Text = "...";
            this.btnOutputFolder.UseVisualStyleBackColor = true;
            this.btnOutputFolder.Click += new System.EventHandler(this.btnOutputFolder_Click);
            // 
            // btnInputFolder
            // 
            this.btnInputFolder.Location = new System.Drawing.Point(200, 16);
            this.btnInputFolder.Name = "btnInputFolder";
            this.btnInputFolder.Size = new System.Drawing.Size(24, 20);
            this.btnInputFolder.TabIndex = 9;
            this.btnInputFolder.Text = "...";
            this.btnInputFolder.UseVisualStyleBackColor = true;
            this.btnInputFolder.Click += new System.EventHandler(this.btnInputFolder_Click);
            // 
            // txtOutputFolderPath
            // 
            this.txtOutputFolderPath.Location = new System.Drawing.Point(61, 40);
            this.txtOutputFolderPath.MaxLength = 500;
            this.txtOutputFolderPath.Name = "txtOutputFolderPath";
            this.txtOutputFolderPath.ReadOnly = true;
            this.txtOutputFolderPath.Size = new System.Drawing.Size(133, 20);
            this.txtOutputFolderPath.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Output";
            // 
            // txtInputFolderPath
            // 
            this.txtInputFolderPath.Location = new System.Drawing.Point(61, 16);
            this.txtInputFolderPath.MaxLength = 500;
            this.txtInputFolderPath.Name = "txtInputFolderPath";
            this.txtInputFolderPath.ReadOnly = true;
            this.txtInputFolderPath.Size = new System.Drawing.Size(133, 20);
            this.txtInputFolderPath.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Input";
            // 
            // lsThread
            // 
            this.lsThread.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsThread.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNo,
            this.colMax,
            this.colValue,
            this.colFailure,
            this.colProgress});
            this.lsThread.FullRowSelect = true;
            this.lsThread.GridLines = true;
            this.lsThread.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsThread.LabelWrap = false;
            this.lsThread.Location = new System.Drawing.Point(0, 76);
            this.lsThread.Name = "lsThread";
            this.lsThread.Size = new System.Drawing.Size(687, 209);
            this.lsThread.TabIndex = 0;
            this.lsThread.UseCompatibleStateImageBehavior = false;
            this.lsThread.View = System.Windows.Forms.View.Details;
            this.lsThread.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lsThread_ColumnWidthChanging);
            // 
            // colNo
            // 
            this.colNo.Text = "Thread No";
            this.colNo.Width = 100;
            // 
            // colMax
            // 
            this.colMax.Text = "Total";
            this.colMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colMax.Width = 80;
            // 
            // colValue
            // 
            this.colValue.Text = "Processed";
            this.colValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colValue.Width = 80;
            // 
            // colFailure
            // 
            this.colFailure.Text = "Failure";
            this.colFailure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colFailure.Width = 80;
            // 
            // colProgress
            // 
            this.colProgress.Text = "Progress";
            this.colProgress.Width = 340;
            // 
            // tabGrid
            // 
            this.tabGrid.Controls.Add(this.grdEnquiryResult);
            this.tabGrid.Location = new System.Drawing.Point(4, 22);
            this.tabGrid.Name = "tabGrid";
            this.tabGrid.Size = new System.Drawing.Size(687, 285);
            this.tabGrid.TabIndex = 2;
            this.tabGrid.Text = "Enquiry Result";
            this.tabGrid.UseVisualStyleBackColor = true;
            // 
            // grdEnquiryResult
            // 
            this.grdEnquiryResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdEnquiryResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEnquiryResult.Location = new System.Drawing.Point(3, 3);
            this.grdEnquiryResult.Name = "grdEnquiryResult";
            this.grdEnquiryResult.Size = new System.Drawing.Size(681, 280);
            this.grdEnquiryResult.TabIndex = 21;
            // 
            // grpResult
            // 
            this.grpResult.Controls.Add(this.label8);
            this.grpResult.Controls.Add(this.label5);
            this.grpResult.Controls.Add(this.label4);
            this.grpResult.Controls.Add(this.lblTimeStart);
            this.grpResult.Controls.Add(this.lblTimeEnd);
            this.grpResult.Controls.Add(this.lblDuration);
            this.grpResult.Location = new System.Drawing.Point(441, 8);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(136, 84);
            this.grpResult.TabIndex = 1;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "Ofs Time";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Duration:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "End:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Start:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(585, 56);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(106, 35);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "&Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // frmOFS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 411);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.grpResult);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.grpConnection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(720, 450);
            this.Name = "frmOFS";
            this.Text = "T24 Ofs tool - halh v1.0 (30-Apr-2016)";
            this.Load += new System.EventHandler(this.frmOFS_Load);
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            this.tabRequest.ResumeLayout(false);
            this.tabRequest.PerformLayout();
            this.toolRequest.ResumeLayout(false);
            this.toolRequest.PerformLayout();
            this.splitOFS.Panel1.ResumeLayout(false);
            this.splitOFS.Panel1.PerformLayout();
            this.splitOFS.Panel2.ResumeLayout(false);
            this.splitOFS.Panel2.PerformLayout();
            this.splitOFS.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabThread.ResumeLayout(false);
            this.grpThreadMode.ResumeLayout(false);
            this.grpThread.ResumeLayout(false);
            this.grpThread.PerformLayout();
            this.grpThreadLocation.ResumeLayout(false);
            this.grpThreadLocation.PerformLayout();
            this.tabGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEnquiryResult)).EndInit();
            this.grpResult.ResumeLayout(false);
            this.grpResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lblTimeStart;
        private System.Windows.Forms.Label lblTimeEnd;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboProfile;
        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.TabPage tabRequest;
        private System.Windows.Forms.TextBox txtRequest;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TextBox txtThread;
        private System.Windows.Forms.SplitContainer splitOFS;
        private System.Windows.Forms.ComboBox cboMessageType;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpThreadLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabThread;
        private System.Windows.Forms.ListView lsThread;
        private System.Windows.Forms.ColumnHeader colNo;
        private System.Windows.Forms.ColumnHeader colMax;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.ColumnHeader colProgress;
        private System.Windows.Forms.Button btnOutputFolder;
        private System.Windows.Forms.Button btnInputFolder;
        private System.Windows.Forms.TextBox txtOutputFolderPath;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtInputFolderPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.GroupBox grpThread;
        private System.Windows.Forms.ColumnHeader colFailure;
        private System.Windows.Forms.ComboBox cboDataSource;
        private System.Windows.Forms.GroupBox grpThreadMode;
        private System.Windows.Forms.ComboBox cboThreadSourceMode;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ToolStrip toolRequest;
        private System.Windows.Forms.ToolStripButton btnFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnWrapText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lblRequestNumer;
        private System.Windows.Forms.TabPage tabGrid;
        private System.Windows.Forms.DataGridView grdEnquiryResult;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox btnOutputFile;
        private System.Windows.Forms.ToolStripButton btnShowResponse;
    }
}

