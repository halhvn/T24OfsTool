using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace T24OfsTool
{
    public partial class frmOFS : Form
    {
        private string mstrToday = "";

        #region Property
        private string[] mstrOfsList;
        public string[] OfsList
        {
            get { return mstrOfsList; }
            set { mstrOfsList = value; }
        }

        private string mstrOfsServer;
        private string mstrOfsPort;
        private string mstrOfsUser;
        private string mstrOfsPassword;

        public string OfsServer
        {
            get { return mstrOfsServer; }
            set { mstrOfsServer = value; }
        }
        public string OfsPort
        {
            get { return mstrOfsPort; }
            set { mstrOfsPort = value; }
        }
        public string OfsUser
        {
            get { return mstrOfsUser; }
            set { mstrOfsUser = value; }
        }
        public string OfsPassword
        {
            get { return mstrOfsPassword; }
            set { mstrOfsPassword = value; }
        }
        #endregion

        #region Init
        public frmOFS()
        {
            InitializeComponent();
        }

        private void frmOFS_Load(object sender, EventArgs e)
        {
            try
            {
                cboMessageType.SelectedIndex = 0;
                cboProfile.SelectedIndex = 0;
                cboDataSource.SelectedIndex = 0;
                cboThreadSourceMode.SelectedIndex = 0;
                btnWrapText.PerformClick();

                if (tabMain.TabPages.Count == 3) tabMain.TabPages.Remove(tabGrid);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string strProfile = cboProfile.SelectedItem.ToString();

                switch (strProfile)
                {
                    case "T24Test":
                        {
                            txtServer.Text = "10.37.16.201";
                            if (cboMessageType.SelectedItem.ToString() != "ISO") txtPort.Text = "7023";
                            else txtPort.Text = "14014";
                            break;
                        }
                    case "T24Dev":
                        {
                            txtServer.Text = "10.37.24.116";
                            if (cboMessageType.SelectedItem.ToString() != "ISO") txtPort.Text = "7123";
                            else txtPort.Text = "14014";
                            break;
                        }
                    case "T24Live":
                        {
                            txtServer.Text = "10.36.24.138";
                            if (cboMessageType.SelectedItem.ToString() != "ISO") txtPort.Text = "7023";
                            else txtPort.Text = "14014";
                            break;
                        }
                    case "T24R16uat01":
                        {
                            txtServer.Text = "10.36.9.156";
                            if (cboMessageType.SelectedItem.ToString() != "ISO") txtPort.Text = "7023";
                            else txtPort.Text = "14014";
                            break;
                        }
                    case "T24R16uat02":
                        {
                            txtServer.Text = "10.36.9.155";
                            if (cboMessageType.SelectedItem.ToString() != "ISO") txtPort.Text = "7023";
                            else txtPort.Text = "14014";
                            break;
                        }
                    case "T24R11":
                        {
                            txtServer.Text = "10.37.24.202";
                            if (cboMessageType.SelectedItem.ToString() != "ISO") txtPort.Text = "7023";
                            else txtPort.Text = "14014";
                            break;
                        }
                    default:
                        {
                            {
                                txtServer.Text = "";
                                txtPort.Text = "";
                                break;
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboMessageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboMessageType.SelectedItem.ToString() != "ISO") txtPort.Text = "7023";
                else txtPort.Text = "14014";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                file.InitialDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

                if (file.ShowDialog() == DialogResult.OK)
                {
                    string[] strFileData = System.IO.File.ReadAllLines(file.FileName);
                    txtRequest.Text = string.Join("\r\n", strFileData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
        private void btnWrapText_Click(object sender, EventArgs e)
        {
            try
            {
                txtRequest.WordWrap = !txtRequest.WordWrap;
                btnWrapText.Checked = txtRequest.WordWrap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtRequest_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] strOfsList = txtRequest.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                lblRequestNumer.Text = "Ofs Request No: " + strOfsList.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnShowResponse_Click(object sender, EventArgs e)
        {
            try
            {
                btnShowResponse.Checked = !btnShowResponse.Checked;

                if (btnShowResponse.Checked)
                {
                    splitOFS.SplitterDistance = splitOFS.Height/2;
                }
                else
                {
                    splitOFS.SplitterDistance = splitOFS.Height;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Control
        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnConnection = TCServer.CheckConnection(txtServer.Text, txtPort.Text);
                if (!blnConnection)
                {
                    MessageBox.Show("Ket noi KHONG thanh cong.\r\n" + TCServer.TCServerInformation.OfsErrorMessage);
                    return;
                }

                this.Enabled = false;
                this.Refresh();

                TCServer.SetConnection(txtServer.Text, txtPort.Text, txtUser.Text, txtPass.Text, cboMessageType.SelectedItem.ToString());
                TCServer ofs = new TCServer();
                
                string[] strOfsList = txtRequest.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                
                if (strOfsList.Length == 0) return;

                btnRun.Enabled = false;
                
                txtResponse.Text = "";
                grdEnquiryResult.DataSource = null;
                grdEnquiryResult.Columns.Clear();
                if (tabMain.TabPages.Contains(tabGrid)) tabMain.TabPages.Remove(tabGrid);

                if (strOfsList.Length == 1 && cboDataSource.SelectedIndex == 0)
                {
                    btnPause.Visible = false;
                    btnStop.Visible = false;
                    
                    SingleOfsProcess();

                    btnRun.Enabled = true;                    
                }
                else
                {
                    if (btnShowResponse.Checked)
                    {
                        //btnShowResponse.PerformClick();
                        splitOFS.SplitterDistance = splitOFS.Height;
                        btnShowResponse.Checked = false;
                    }

                    btnRun.Visible = false;
                    btnStop.Visible = true;
                    btnPause.Visible = true;
                    btnPause.Text = "&Pause";
                    
                    tabMain.SelectedIndex = 1;
                    this.Refresh();
                    this.OfsList = strOfsList;
                    this.OfsServer = txtServer.Text;
                    this.OfsPort = txtPort.Text;
                    this.OfsUser = txtUser.Text;
                    this.OfsPassword = txtPass.Text;

                    MultiOfsProcess();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private void btnInputFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                if (txtInputFolderPath.Text == "")
                    folder.SelectedPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                else
                    folder.SelectedPath = txtInputFolderPath.Text;

                if (folder.ShowDialog() == DialogResult.OK)
                {
                    txtInputFolderPath.Text = folder.SelectedPath;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnOutputFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                if (txtOutputFolderPath.Text == "")
                    folder.SelectedPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                else
                    folder.SelectedPath = txtOutputFolderPath.Text;
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    txtOutputFolderPath.Text = folder.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboDataSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cboDataSource.SelectedIndex)
                {
                    case 0:
                        {
                            if (!tabMain.TabPages.Contains(tabRequest)) tabMain.TabPages.Insert(0,tabRequest);
                            grpThreadLocation.Enabled = true;
                            break;
                        }
                    case 1:
                        {
                            //if (tabMain.TabPages.Count == 3) tabMain.TabPages.Remove(tabGrid);
                            if (tabMain.TabPages.Contains(tabGrid)) tabMain.TabPages.Remove(tabGrid);
                            if (tabMain.TabPages.Contains(tabRequest)) tabMain.TabPages.Remove(tabRequest);
                            grpThreadLocation.Enabled = true;
                            break;
                        }
                    default:
                        {
                            //if (tabMain.TabPages.Count == 3) tabMain.TabPages.Remove(tabGrid);
                            if (tabMain.TabPages.Contains(tabGrid)) tabMain.TabPages.Remove(tabGrid);
                            if (tabMain.TabPages.Contains(tabRequest)) tabMain.TabPages.Remove(tabRequest);
                            grpThreadLocation.Enabled = true;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #endregion

        #region Single Ofs
        private void SingleOfsProcess()
        {
            try
            {
                txtResponse.Text = "";
                lblTimeStart.Text = "...";
                lblTimeEnd.Text = "...";
                lblDuration.Text = "...";

                txtThread.Text = "1";
                txtThread.Enabled = false;

                TCServer ofs = new TCServer();

                DateTime tStart = DateTime.Now;

                string strResponse = ofs.OfsExecute(txtRequest.Text);

                if (cboMessageType.SelectedItem.ToString() == "ISO")
                {
                    strResponse = ofs.IsoExecute(txtRequest.Text);
                }
                else
                {
                    mstrToday = ofs.GetDate();
                    strResponse = ofs.OfsExecute(txtRequest.Text);
                }

                txtResponse.Text = strResponse;

                DateTime tEnd = DateTime.Now;                
                TimeSpan tsDuration = tEnd - tStart;
                DateTime tDuration = new DateTime(tsDuration.Ticks);                
                lblTimeStart.Text = tStart.ToString("HH:mm:ss.fff");
                lblTimeEnd.Text = tEnd.ToString("HH:mm:ss.fff");
                lblDuration.Text = tDuration.ToString("HH:mm:ss.fff");
                txtThread.Enabled = true;

                if (txtRequest.Text.Substring(0, 14) == "ENQUIRY.SELECT")
                {
                    if (!tabMain.TabPages.Contains(tabGrid)) tabMain.TabPages.Add(tabGrid);

                    DataTable dt = ofs.OfsExecToTable(txtRequest.Text);
                    grdEnquiryResult.Rows.Clear();
                    grdEnquiryResult.Columns.Clear();
                    grdEnquiryResult.DataSource = dt;
                    tabGrid.Text = "Enquiry Result";
                    tabMain.SelectedIndex = 2;
                    if (btnShowResponse.Checked)
                    {
                        splitOFS.SplitterDistance = splitOFS.Height;
                        btnShowResponse.Checked = false;
                    }
                }
                else
                {
                    if (!btnShowResponse.Checked)
                    {
                        splitOFS.SplitterDistance = splitOFS.Height/2;
                        btnShowResponse.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region Multi Ofs

        #region Thread Init
        ManualResetEvent _pauseEvent = new ManualResetEvent(true);
        ManualResetEvent _stopEvent = new ManualResetEvent(false);
        int intThreadStatus = 0;
        int _intThreadNumber = 1;
        int _intThreadFinishedCount = 0;
        DateTime _tTotalStart = DateTime.Now;
        string _strOutputFolder = "";
        string _strInputFolder = "";
        bool _blnSourceFromFolder = false;
        string[][] arrOfsRequestList = null;
        private void OfsRequestPrepareData()
        {
            try
            {
                if (cboDataSource.SelectedIndex == 1)
                {
                    _blnSourceFromFolder = true;
                    return;
                }
                _blnSourceFromFolder = false;

                arrOfsRequestList = new string[_intThreadNumber][];
                
                if (cboThreadSourceMode.SelectedIndex != 0)     //Source Duplicate 
                {
                    for (int i = 0; i < _intThreadNumber; i++)
                    {
                        arrOfsRequestList[i] = this.OfsList;
                    }
                    return;
                }

                //Source Split
                int intValue1 = this.OfsList.Length;
                double dblValue2 = intValue1 / _intThreadNumber;                
                int intValue2 = Convert.ToInt32(dblValue2);
                int intValue3 = intValue1 - intValue2 * _intThreadNumber;

                int iPos = 0;
                for (int i = 0; i < _intThreadNumber; i++)
                {
                    int intAdditional = 0;
                    if (i < intValue3) intAdditional = 1;
                    int intArraySize = intValue2 + intAdditional;

                    string[] strOfsTempList = new string[intArraySize];
                    for (int j = 0; j < intArraySize; j++)
                    {
                        strOfsTempList[j] = this.OfsList[iPos];
                        iPos++;
                    }
                    arrOfsRequestList[i] = strOfsTempList;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ThreadInit()
        {
            try
            {
                string strThread = txtThread.Text.Trim();
                if (strThread == "") strThread = "1";
                if (strThread == "0") strThread = "1";
                try
                {
                    _intThreadNumber = Int16.Parse(strThread);
                }
                catch
                {
                    txtThread.Text = "1";
                    _intThreadNumber = 1;
                }

                lsThread.Items.Clear();
                lsThread.Controls.Clear();
                btnRun.Enabled = false;
                btnRun.Visible = false;
                btnPause.Visible = true;
                grpConnection.Enabled = false;
                grpResult.Enabled = false;
                grpThread.Enabled = false;
                grpThreadMode.Enabled = false;
                grpThreadLocation.Enabled = false;
                txtRequest.ReadOnly = true;
                toolRequest.Enabled = false;

                intThreadStatus = 1;
                btnPause.Text = "&Pause";

                txtInputFolderPath.Invoke(new MethodInvoker(() => { _strInputFolder = txtInputFolderPath.Text; }));
                if (_strInputFolder == "") _strInputFolder = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                
                txtOutputFolderPath.Invoke(new MethodInvoker(() => { _strOutputFolder = txtOutputFolderPath.Text; }));
                if (_strOutputFolder == "") _strOutputFolder = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

                _intThreadFinishedCount = 0;
                OfsRequestPrepareData();

                _tTotalStart = DateTime.Now;
                lblTimeStart.Text = _tTotalStart.ToString("HH:mm:ss.fff");
                lblTimeEnd.Text = "...";
                lblDuration.Text = "...";
                
                _pauseEvent = new ManualResetEvent(true);
                _stopEvent = new ManualResetEvent(false);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region Thread Control
        private void DoRun()
        {
            try
            {
                ThreadInit();

                for (int i = 1; i <= _intThreadNumber; i++)
                {
                    string[] strOfsList = null;
                    if (!_blnSourceFromFolder) strOfsList = arrOfsRequestList[i - 1];
                    Thread tOfsThread = new Thread(() => OfsThreadProcess(i, strOfsList));
                    tOfsThread.Start();
                    Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DoPause()
        {
            try
            {
                intThreadStatus = 2;
                btnPause.Text = "&Resume";

                _pauseEvent.Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DoResume()
        {
            try
            {
                intThreadStatus = 1;
                btnPause.Text = "&Pause";

                _pauseEvent.Set();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DoStop()
        {
            try
            {
                _pauseEvent.Set();
                _stopEvent.Set();

                OfsThreadFinishAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MultiOfsProcess()
        {
            try
            {
                switch (intThreadStatus)
                {
                    case 0:
                        {
                            DoRun();
                            break;
                        }
                    case 1:
                        {
                            DoPause();
                            break;
                        }
                    case 2:
                        {
                            DoResume();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnPause_Click(object sender, EventArgs e)
        {
            try
            {
                MultiOfsProcess();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                DoStop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Thread Process
        private void OfsThreadProcess(int intThread, string[] strOfsList)
        {
            try
            {
                if (_blnSourceFromFolder)
                {
                    string strInputFile = _strInputFolder + "\\Input_" + intThread.ToString() + ".txt";
                    if (!System.IO.File.Exists(strInputFile))
                    {
                        ThreadAdd(intThread, 0, 0);
                        return;
                    }
                    strOfsList = System.IO.File.ReadAllLines(strInputFile);
                }

                ThreadAdd(intThread, strOfsList.Length, 0);

                int intFailure = 0;
                for (int i = 0; i < strOfsList.Length; i++)
                {
                    _pauseEvent.WaitOne(Timeout.Infinite);
                    if (_stopEvent.WaitOne(0)) break;
                    //if (_stopEvent.WaitOne(Timeout.Infinite))
                    //{
                    //    break;
                    //}

                    int j = i + 1;
                    string strOfsRequest = strOfsList[i];

                    bool blnOfsStatus = OfsRequestProcess(intThread, strOfsRequest, j);
                    if (!blnOfsStatus) intFailure++;
                    ThreadUpdate(intThread, i + 1, intFailure);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                _intThreadFinishedCount++;
                if (_intThreadFinishedCount == _intThreadNumber) OfsThreadFinishAll();
                if (Thread.CurrentThread != null && Thread.CurrentThread.IsAlive) Thread.CurrentThread.Abort();
            }
        }
        private void OfsThreadFinishAll()
        {
            try
            {
                DateTime tTotalEnd = DateTime.Now;
                TimeSpan tsTotalDuration = tTotalEnd - _tTotalStart;
                DateTime tTotalDuration = new DateTime(tsTotalDuration.Ticks);

                lblTimeStart.Invoke(new MethodInvoker(() => { lblTimeStart.Text = _tTotalStart.ToString("HH:mm:ss.fff"); }));
                lblTimeEnd.Invoke(new MethodInvoker(() => { lblTimeEnd.Text = tTotalEnd.ToString("HH:mm:ss.fff"); }));
                lblDuration.Invoke(new MethodInvoker(() => { lblDuration.Text = tTotalDuration.ToString("HH:mm:ss.fff"); }));                
                btnPause.Invoke(new MethodInvoker(() => { btnPause.Visible = false; }));
                btnStop.Invoke(new MethodInvoker(() => { btnStop.Visible = false; }));
                btnRun.Invoke(new MethodInvoker(() => { btnRun.Enabled = true; }));
                btnRun.Invoke(new MethodInvoker(() => { btnRun.Visible = true; }));

                grpConnection.Invoke(new MethodInvoker(() => { grpConnection.Enabled = true; }));
                grpResult.Invoke(new MethodInvoker(() => { grpResult.Enabled = true; }));
                grpThread.Invoke(new MethodInvoker(() => { grpThread.Enabled = true; }));
                grpThreadMode.Invoke(new MethodInvoker(() => { grpThreadMode.Enabled = true; }));
                grpThreadLocation.Invoke(new MethodInvoker(() => { grpThreadLocation.Enabled = true; }));

                txtRequest.Invoke(new MethodInvoker(() => { txtRequest.ReadOnly = false; }));
                toolRequest.Invoke(new MethodInvoker(() => { toolRequest.Enabled = true; }));
                intThreadStatus = 0;
            }
            catch
            { 
            }
        }
        private bool OfsRequestProcess(int intThread, string strOfsRequest, int intPos)
        {
            DateTime tStart = DateTime.Now;
            string strOutData = intPos.ToString();

            try
            {
                TCServer ofs = new TCServer();

                string strResponse = "";

                if (TCServer.TCServerInformation.MessageType == "ISO") strResponse = ofs.IsoExecute(strOfsRequest);
                else strResponse = ofs.OfsExecute(strOfsRequest);

                bool blnOfsStatus = ofs.OfsStatus;

                DateTime tEnd = DateTime.Now;
                TimeSpan tsDuration = tEnd - tStart;
                DateTime tDuration = new DateTime(tsDuration.Ticks);

                strOutData += "!@#" + blnOfsStatus.ToString();
                strOutData += "!@#" + tStart.ToString("HH:mm:ss.fff");
                strOutData += "!@#" + tEnd.ToString("HH:mm:ss.fff");
                strOutData += "!@#" + tDuration.ToString("HH:mm:ss.fff");
                strOutData += "!@#" + strOfsRequest;
                strOutData += "!@#" + strResponse;

                return blnOfsStatus;
            }
            catch (Exception ex)
            {
                DateTime tEnd = DateTime.Now;
                TimeSpan tsDuration = tEnd - tStart;
                DateTime tDuration = new DateTime(tsDuration.Ticks);

                strOutData += "!@#" + "False";
                strOutData += "!@#" + tStart.ToString("HH:mm:ss.fff");
                strOutData += "!@#" + tEnd.ToString("HH:mm:ss.fff");
                strOutData += "!@#" + tDuration.ToString("HH:mm:ss.fff");
                strOutData += "!@#" + strOfsRequest;
                strOutData += "!@#" + ex.Message;

                return false;
            }
            finally 
            {
                string strOutFile = _strOutputFolder + "\\Output_" + intThread.ToString() + ".txt";
                using (StreamWriter w = File.AppendText(strOutFile))
                {
                    strOutData = strOutData.Replace("\n", "");
                    w.WriteLine(strOutData);
                    //w.Write(strOutData);
                }
            }
        }
        #endregion

        #endregion

        #region List of Thread
        private void ThreadInit(int intNumberOfThread, int intMaxValue)
        {
            try
            {
                lsThread.Items.Clear();
                lsThread.Controls.Clear();

                for (int i = 1; i <= intNumberOfThread; i++)
                {
                    ThreadAdd(i, 100, 100-i*10);
                }                
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        private void ThreadAdd(int intThreadNo, int intMax, int intValue)
        {
            try
            {
                ListViewItem lvi = new ListViewItem();
                ProgressBar pb = new ProgressBar();

                lvi.SubItems[0].Text = "Thread " + intThreadNo.ToString();
                lvi.SubItems.Add(intMax.ToString());
                lvi.SubItems.Add(intValue.ToString());
                lvi.SubItems.Add("0");
                lvi.SubItems.Add("");                
                lsThread.Invoke(new MethodInvoker(() => { lsThread.Items.Add(lvi); }));

                Rectangle r = new Rectangle();// lvi.SubItems[4].Bounds;

                lsThread.Invoke(new MethodInvoker(delegate {r = lvi.SubItems[4].Bounds; }));

                pb.SetBounds(r.X, r.Y, r.Width, r.Height);
                pb.Minimum = 0;
                pb.Maximum = intMax;
                pb.Value = intValue;
                pb.Name = intThreadNo.ToString();                
                lsThread.Invoke(new MethodInvoker(() => { lsThread.Controls.Add(pb); }));
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void ThreadUpdate(int intThreadNo, int intValue, int intFailure)
        {
            try
            {
                int intThreadCount = 0;
                lsThread.Invoke(new MethodInvoker(delegate { intThreadCount = lsThread.Items.Count; }));
                if (intThreadNo > intThreadCount) return;

                ListViewItem lvi = new ListViewItem();
                lsThread.Invoke(new MethodInvoker(delegate { lvi = lsThread.Items[intThreadNo - 1]; }));
                
                lsThread.Invoke(new MethodInvoker(delegate { lvi.SubItems[2].Text = intValue.ToString(); }));
                lsThread.Invoke(new MethodInvoker(delegate { lvi.SubItems[3].Text = intFailure.ToString(); }));

                try
                {
                    ProgressBar pb = new ProgressBar();
                    lsThread.Invoke(new MethodInvoker(delegate { pb = (ProgressBar)lsThread.Controls[intThreadNo - 1]; }));
                    pb.Value = intValue;
                }
                catch
                { 
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            
        }
        private void lsThread_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            try
            {
                e.NewWidth = this.lsThread.Columns[e.ColumnIndex].Width;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion        
       
    }
}
