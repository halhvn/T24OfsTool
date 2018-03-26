using System;
using System.Data;
using System.Text;
using System.Net.Sockets;

namespace System.Data
{
    public class OfsError
    {
        public const int INIT = -1;
        public const int SUCCESS = 0;
        public const int GENERAL_ERROR = 9000;
        public const int INVALID_REQUEST_FORMAT = 2000;
        public const int AUTHENTICATED_FAILED = 3005;
        public const int SERVER_TIMEOUT = 4000;
        public const int SERVER_BUSY = 4001;
        public const int RECORD_NOT_FOUND = 5000;
        public const int LIVE_RECORD_NOT_CHANGE = 3003;
    }

    class TCServerHelper
    {
        #region Property
        private Socket _socClient;
        public OfsError _sockErr = new OfsError();

        private string _strOfsServer = "10.37.16.201";
        private string _strOfsPort = "7023";
        private int _intOfsTimeOut = 60000;
        private int _intOfsBuffer = 1024;

        private int _intOfsErrorCode = OfsError.SUCCESS;
        private string _strOfsErrorMessage = "";

        public string OfsServer
        {
            get { return _strOfsServer; }
            set { _strOfsServer = value; }
        }
        public string OfsPort
        {
            get { return _strOfsPort; }
            set { _strOfsPort = value; }
        }
        public int OfsTimeout
        {
            get { return _intOfsTimeOut; }
            set { _intOfsTimeOut = value; }
        }
        public int OfsBuffer
        {
            get { return _intOfsBuffer; }
            set { _intOfsBuffer = value; }
        }

        public int OfsErrorCode
        {
            get { return _intOfsErrorCode; }
            set { _intOfsErrorCode = value; }
        }
        public string OfsErrorMessage
        {
            get { return _strOfsErrorMessage; }
            set { _strOfsErrorMessage = value; }
        }

        #endregion

        public TCServerHelper()
        {
            _socClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            OfsErrorCode = OfsError.SUCCESS;
        }

        public bool OpenSocket(string sIPAddress, string sServPort)
        {
            if (string.IsNullOrEmpty(sIPAddress) || string.IsNullOrEmpty(sServPort))
            {
                OfsErrorCode = OfsError.INVALID_REQUEST_FORMAT;
                OfsErrorMessage = "Missing Server IP and Port?? " + sIPAddress + ":" + sServPort;
                return false;
            }
            else
            {
                OfsServer = sIPAddress;
                OfsPort = sServPort;
                return this.SockConnect();
            }
        }

        public bool OpenSocket(string sIPAddress, string sServPort, int iTimeOut, int iMaxBuff)
        {
            if (string.IsNullOrEmpty(sIPAddress) || string.IsNullOrEmpty(sServPort) || iTimeOut <= 0 || iMaxBuff <= 0)
            {
                OfsErrorCode = OfsError.INVALID_REQUEST_FORMAT;
                OfsErrorMessage = "Server setting is not correct!";
                return false;
            }
            else
            {
                OfsServer = sIPAddress;
                OfsPort = sServPort;
                OfsBuffer = iMaxBuff;
                OfsTimeout = iTimeOut;
                return this.SockConnect();
            }
        }

        ~TCServerHelper()
        {
            if (_socClient != null && _socClient.Connected)
            {
                _socClient.Shutdown(SocketShutdown.Both);
                _socClient.Close();
                _socClient = null;
            }
        }

        public bool IsSockConnect()
        {
            if (_socClient != null)
            {
                return _socClient.Connected;
            }
            else
                return false;
        }

        public bool SockDisconnect()
        {
            try
            {
                if (_socClient != null && _socClient.Connected)
                {
                    _socClient.Disconnect(true);
                    OfsErrorCode = OfsError.SUCCESS;
                    OfsErrorMessage = "Socket was disconnect by user.";
                }

                return true;
            }
            catch (Exception ex)
            {
                OfsErrorCode = OfsError.SERVER_BUSY;
                OfsErrorMessage = ex.Message;
                return false;
            }
        }

        public bool SockReconnect()
        {
            try
            {
                if (_socClient != null && _socClient.Connected)
                {
                    _socClient.Disconnect(true);
                }

                _socClient.Close();
                _socClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                SockConnect();

                if (OfsErrorCode == OfsError.SUCCESS) return true;
                else return false;
            }
            catch (Exception ex)
            {
                OfsErrorCode = OfsError.GENERAL_ERROR;
                OfsErrorMessage = ex.Message;
                return false;
            }
        }

        private bool SockConnect()
        {
            try
            {
                int alPort = System.Convert.ToInt16(OfsPort, 10);

                System.Net.IPAddress remoteIPAddress = System.Net.IPAddress.Parse(OfsServer);
                System.Net.IPEndPoint remoteEndPoint = new System.Net.IPEndPoint(remoteIPAddress, alPort);
                _socClient.ReceiveTimeout = OfsTimeout;
                _socClient.ReceiveBufferSize = OfsBuffer;

                _socClient.Connect(remoteEndPoint);

                this.GetResponse(ref _strOfsErrorMessage);

                if (OfsErrorCode == OfsError.SUCCESS) return true;
                else return false;
            }
            catch (Exception ex)
            {
                OfsErrorCode = OfsError.GENERAL_ERROR;
                OfsErrorMessage = ex.Message;
                return false;
            }
        }

        public bool SendRequest(string sRq, ref string sResp)
        {
            try
            {
                if (!_socClient.Connected)
                {
                    if (!SockReconnect())
                    {
                        sResp = "";
                        return false;
                    }
                }

                string objData = sRq + "\n";
                byte[] byData = System.Text.Encoding.UTF8.GetBytes(objData);
                _socClient.Send(byData);

                this.GetResponse(ref sResp);

                if (OfsErrorCode == OfsError.SUCCESS) return true;
                else return false;
            }
            catch (Exception ex)
            {
                OfsErrorCode = OfsError.GENERAL_ERROR;
                OfsErrorMessage = "Exception:" + ex.Message;
                return false;
            }
        }        

        private void GetResponse(ref string sResp)
        {
            try
            {
                sResp = "";
                do
                {
                    byte[] buffer = new byte[OfsBuffer];

                    int iRx = _socClient.Receive(buffer);
                    char[] chars = new char[iRx];

                    System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                    int charLen = d.GetChars(buffer, 0, iRx, chars, 0);
                    sResp += new System.String(chars);

                } while (_socClient.Available > 0 || !sResp.EndsWith("\r\n"));

                OfsErrorCode = OfsError.SUCCESS;
            }
            catch (SocketException se)
            {
                sResp = "";
                OfsErrorCode = OfsError.GENERAL_ERROR;
                OfsErrorMessage = se.Message;
            }
        }        
    }

    public class TCServerInfo
    {
        public TCServerInfo()
        {
            
        }

        #region Property
        private string _strOfsServer = ""; //10.37.16.201
        private string _strOfsPort = "";//7023
        private int _intOfsTimeOut = 10000;
        private int _intOfsBuffer = 1024;

        private string _strUser = "";
        private string _strPassword = "";

        private bool _blnOfsStatus = false;
        private int _intOfsErrorCode = OfsError.SUCCESS;
        private string _strOfsErrorMessage = "";
        private string _strMessageType = "OFS";

        public string OfsServer
        {
            get { return _strOfsServer; }
            set { _strOfsServer = value; }
        }
        public string OfsPort
        {
            get { return _strOfsPort; }
            set { _strOfsPort = value; }
        }
        public int OfsTimeout
        {
            get { return _intOfsTimeOut; }
            set { _intOfsTimeOut = value; }
        }
        public int OfsBuffer
        {
            get { return _intOfsBuffer; }
            set { _intOfsBuffer = value; }
        }
        public string User
        {
            get { return _strUser; }
            set { _strUser = value; }
        }
        public string Password
        {
            get { return _strPassword; }
            set { _strPassword = value; }
        }

        public bool OfsStatus
        {
            get { return _blnOfsStatus; }
            set { _blnOfsStatus = value; }
        }
        public int OfsErrorCode
        {
            get { return _intOfsErrorCode; }
            set { _intOfsErrorCode = value; }
        }
        public string OfsErrorMessage
        {
            get { return _strOfsErrorMessage; }
            set { _strOfsErrorMessage = value; }
        }
        public string MessageType
        {
            get { return _strMessageType; }
            set { _strMessageType = value; }
        }
        #endregion
    }

    public class TCServer
    {
        #region Property
        private TCServerHelper _tcsHelper = new TCServerHelper();
        public OfsError _ofsError = new OfsError();

        public static TCServerInfo _tcsinfo = new TCServerInfo();
        public static TCServerInfo TCServerInformation
        {
            get { return _tcsinfo; }
            set { _tcsinfo = value; }
        }
        private static string _strConnectionErrorMessage = "";
        public static string ConnectionErrorMessage
        {
            get { return _strConnectionErrorMessage; }
            set { _strConnectionErrorMessage = value; }
        }  

        private bool _blnOfsStatus = false;
        private int _intOfsErrorCode = OfsError.SUCCESS;
        private string _strOfsErrorMessage = "";

        public bool OfsStatus
        {
            get { return _blnOfsStatus; }
            set { _blnOfsStatus = value; }
        }
        public int OfsErrorCode
        {
            get { return _intOfsErrorCode; }
            set { _intOfsErrorCode = value; }
        }
        public string OfsErrorMessage
        {
            get { return _strOfsErrorMessage; }
            set { _strOfsErrorMessage = value; }
        }         
        #endregion

        public TCServer()
        {
        }

        #region GetDate
        public string GetDate()
        {
            string strT24Date = GetDate(TCServerInformation);
            return strT24Date;
        }
        public string GetDate(TCServerInfo tcsinfo)
        {
            string strT24Date = "";
            string strEnq = "ENQUIRY.SELECT,," + tcsinfo.User + "/" + tcsinfo.Password + ",TEC.OVERVIEW,COMPANY.CODE:EQ=VN0010001";

            string strResponse = OfsExecute(tcsinfo, strEnq);

            if (OfsErrorCode == OfsError.SUCCESS)
            {
                string dataArea = OfsEnquiryAnalyze(strResponse, "JULIAN::Julian", 2);
                string[] columns = dataArea.Split('|');
                if (columns.Length >= 1)
                {
                    string[] sdata = columns[0].Split('\t');
                    strT24Date = sdata.Length > 1 ? sdata[1] : "";
                }
            }

            return strT24Date;
        }
        #endregion

        #region Connection
        public static bool CheckConnection(string strOfsServer, string strOfsPort)
        {
            
            TcpClient tcp = new TcpClient();
            try
            {
                tcp.Connect(strOfsServer, Convert.ToInt16(strOfsPort));

                if (tcp.Connected)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _tcsinfo.OfsErrorCode = OfsError.GENERAL_ERROR;
                _tcsinfo.OfsErrorMessage = ex.Message;
                return false;
            }


            //TCServerHelper tcsh = new TCServerHelper();
            //TCServer tcs = new TCServer();

            //TCServerInfo tcsinfo = new TCServerInfo();
            //tcsinfo.OfsServer = strOfsServer;
            //tcsinfo.OfsPort = strOfsPort;

            //if (!tcsh.IsSockConnect())
            //{
            //    tcsh.OpenSocket(tcsinfo.OfsServer, tcsinfo.OfsPort, tcsinfo.OfsTimeout, tcsinfo.OfsBuffer);
            //}

            //if (tcsh.OfsErrorCode != 0)
            //{
            //    ConnectionErrorMessage = tcsh.OfsErrorMessage;
            //    tcsh.SockDisconnect();
            //    return false;
            //}

            //tcsh.SockDisconnect();
            //return true;
        }
        public static bool CheckConnection(string strOfsServer, string strOfsPort, string strSignOnName, string strPassword)
        {
            TcpClient tcp = new TcpClient();
            try
            {
                tcp.Connect(strOfsServer, Convert.ToInt16(strOfsPort));

                if (tcp.Connected)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _tcsinfo.OfsErrorCode = OfsError.GENERAL_ERROR;
                _tcsinfo.OfsErrorMessage = ex.Message;
                return false;
            }

            /*try
            {
                string strToday = tcs.GetDate(tcsinfo);
                if (string.IsNullOrEmpty(strToday))
                {
                    tcsh.SockDisconnect();
                    return false;
                }
            }
            catch
            {
                tcsh.SockDisconnect();
                return false;
            }
             tcsh.SockDisconnect();
            */
            //return true;
        }
        public static void SetConnection(string strOfsServer, string strOfsPort, string strSignOnName, string strPassword)
        {
            try
            {
                TCServerInformation.OfsServer = strOfsServer;
                TCServerInformation.OfsPort = strOfsPort;
                TCServerInformation.User = strSignOnName;
                TCServerInformation.Password = strPassword;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static void SetConnection(string strOfsServer, string strOfsPort, string strSignOnName, string strPassword, string strMessageType)
        {
            try
            {
                TCServerInformation.OfsServer = strOfsServer;
                TCServerInformation.OfsPort = strOfsPort;
                TCServerInformation.User = strSignOnName;
                TCServerInformation.Password = strPassword;
                TCServerInformation.MessageType = strMessageType;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region Ofs Execute
        public string OfsExecute(string strOfsRequest)
        {
            try
            {
                return OfsExecute(TCServerInformation, strOfsRequest);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string OfsExecute(TCServerInfo tcsinfo, string strOfsRequest)
        {
            try
            {
                strOfsRequest = strOfsRequest.Trim();
                if (strOfsRequest == "")
                {
                    OfsErrorCode = OfsError.GENERAL_ERROR;
                    OfsErrorMessage = "Request empty";
                    OfsStatus = false;
                    return "";
                }

                string s = "";

                if (!_tcsHelper.IsSockConnect())
                {
                    _tcsHelper.OpenSocket(tcsinfo.OfsServer, tcsinfo.OfsPort, tcsinfo.OfsTimeout, tcsinfo.OfsBuffer);
                }
                try
                {
                    strOfsRequest = OfsRequestVerify(strOfsRequest);
                    _tcsHelper.SendRequest(strOfsRequest, ref s);
                    OfsErrorCode = _tcsHelper.OfsErrorCode;
                }
                catch (Exception ex)
                {
                    OfsErrorCode = OfsError.SERVER_TIMEOUT;
                    OfsErrorMessage = ex.Message;
                }

                _tcsHelper.SockDisconnect();

                if (s == "")
                {
                    OfsErrorCode = OfsError.SERVER_TIMEOUT;
                    OfsErrorMessage = "TimedOut connection";
                    OfsStatus = false;
                }
                else
                {
                    s = s.ToUpper();

                    if (((_ofsError == null) || (OfsErrorCode != OfsError.SUCCESS)) && s.Contains("-1") && !s.Contains("LIVE RECORD NOT CHANGED"))

                        if (s.Contains("MISSING FILE")) OfsErrorCode = OfsError.SERVER_BUSY;
                        else if (s.Contains("SECURITY VIOLATION")) OfsErrorCode = OfsError.AUTHENTICATED_FAILED;
                        else if (s.Contains("NO SIGN ON NAME")) OfsErrorCode = OfsError.AUTHENTICATED_FAILED;
                        else if (s.Contains("NO RECORDS WERE FOUND")) OfsErrorCode = OfsError.RECORD_NOT_FOUND;
                        else if (s.Contains("LIVE RECORD NOT CHANGED")) OfsErrorCode = OfsError.LIVE_RECORD_NOT_CHANGE;
                        else OfsErrorCode = OfsError.SUCCESS;

                    OfsStatus = OfsResponseStatus(strOfsRequest, s);

                    //else _ofsError.SetBifErr(cbiError.PROCESS_MSG_FAILED, s);
                }

                return s;
            }
            catch (Exception ex)
            {
                OfsErrorCode = OfsError.GENERAL_ERROR;
                OfsErrorMessage = ex.Message;
                OfsStatus = false;
                return ex.Message;
            }
        }                

        public DataTable OfsExecToTable(string strOfsRequest)
        {
            DataTable dt = new DataTable();

            try
            {
                if (strOfsRequest.Substring(0, 14) != "ENQUIRY.SELECT") return null;
                string strOfsRequestMessage = OfsRequestVerify(strOfsRequest);

                string strOfsResponse = OfsExecute(_tcsinfo, strOfsRequestMessage);

                dt = OfsResponeToTable(strOfsResponse);

                return dt;
            }
            catch //(Exception ex)
            {
                return null;
            }
        }
        public DataTable OfsResponeToTable(string strOfsResponse)
        {
            DataTable dt = new DataTable();

            try
            {
                string[] strResponseList = strOfsResponse.Split(new string[] { ",\"" }, StringSplitOptions.None);
                int intRow = strResponseList.Length;

                int intCol = 0;
                for (int i=1; i < intRow; i++)
                {
                    string[] strRowList = strResponseList[i].Split('\t');
                    int intCount = strRowList.Length;
                    if (intCol < intCount) intCol = intCount;
                }

                string strTemp = strResponseList[0];
                string [] strTemp2 = strTemp.Split(',');
                if (strTemp2.Length >= 2) strTemp = strTemp2[1];

                string[] strFirstRow = strTemp.Split('/');
                for (int i = 0; i < intCol; i++)
                {
                    string strColumnName = strFirstRow[i];
                    string[] strColumnList = strColumnName.Split(':');
                    if (strColumnList.Length > 1)
                    {
                        strColumnName = strColumnName.Split(':')[2].ToString();
                        dt.Columns.Add(strColumnName);
                    }
                }


                for (int i = 1; i < intRow; i++)
                {
                    string[] strRowData = strResponseList[i].Split('\t');
                    if (strRowData.Length == intCol)
                    {
                        DataRow drRow = dt.NewRow();
                        for (int j = 0; j < intCol; j++)
                        {
                            if (strRowData.Length > j)
                            {
                                string strData = strRowData[j];
                                strData = strData.Replace("\"", "");
                                strData = strData.Trim();
                                drRow[j] = strData;
                            }
                            else
                            {
                                drRow[j] = "";
                            }
                        }
                        dt.Rows.Add(drRow);
                    }
                    else
                    {

                    }
                }

                return dt;
            }
            catch //(Exception ex)
            {
                return null;
            }
        }
        
        private string OfsRequestVerify(string strOfsRequest)
        {
            try
            {
                string[] arrComma = strOfsRequest.Split(',');
                if (arrComma.Length < 4) return strOfsRequest;

                string strAudit = arrComma[2];

                string[] arrAudit = strAudit.Split('/');

                string strUser = "";
                string strPass = "";
                string strCompany = "";

                if (arrAudit.Length < 2)
                {
                    strUser = _tcsinfo.User;
                    strPass = _tcsinfo.Password;
                }
                else
                {
                    strUser = arrAudit[0].Trim();
                    strPass = arrAudit[1].Trim();                    
                }

                if (arrAudit.Length > 2) strCompany = arrAudit[2].Trim();
                

                string strAuditNew = _tcsinfo.User + "/" + _tcsinfo.Password + "/" + strCompany;

                if ((strUser == ""))
                {
                    strAuditNew = _tcsinfo.User + "/" + _tcsinfo.Password;
                }
                else
                {
                    strAuditNew = strUser + "/" + strPass;
                }

                if (strCompany != "")
                {
                    strAuditNew += "/" + strCompany;
                }

                arrComma[2] = strAuditNew;

                string strNewRequest = arrComma[0];

                for (int i = 1; i < arrComma.Length; i++)
                {
                    strNewRequest += "," + arrComma[i];
                }
                return strNewRequest;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public bool OfsResponseStatus(string strOfsRequest, string strOfsResponse)
        {
            try
            {
                if (strOfsRequest.Substring(0, 14) != "ENQUIRY.SELECT")
                {
                    string[] arrResponse = strOfsResponse.Split('/');
                    if (arrResponse.Length < 3) return false;
                    string strStatus = arrResponse[2];

                    if (strStatus.Substring(0, 1) == "1") return true;
                    else return false;
                }
                else
                {
                    string[] arrResponse = strOfsResponse.Split(new string[] { ",\"" }, StringSplitOptions.None);

                    if (arrResponse.Length < 2) return false;
                    else return true;
                }
                //return false;
            }
            catch
            {
                return false;
            }
        }
        private string OfsEnquiryAnalyze(string sOriginal, string sEndFlag, int iPlus)
        {
            sOriginal = sOriginal.ToUpper();
            sEndFlag = sEndFlag.ToUpper();

            string dataArea = sOriginal;
            int lastOrrc = sOriginal.LastIndexOf(sEndFlag);
            int firstOrrc = sOriginal.LastIndexOf(",Y.ISO.RESPONSE:1:1");
            if (firstOrrc < lastOrrc) firstOrrc = sOriginal.LastIndexOf("\r\n");
            if (firstOrrc < lastOrrc) firstOrrc = sOriginal.Length;

            int iTmp = sEndFlag.Length + iPlus;

            if (firstOrrc - lastOrrc - iTmp > 0)
            {
                dataArea = sOriginal.Substring(lastOrrc + iTmp, firstOrrc - lastOrrc - iTmp);
                dataArea = dataArea.Replace("\",\"", "|");//Phan cach cac ban ghi
                dataArea = dataArea.Replace("\"\t\"", "\t");//Phan cach cac gtri truong
                dataArea = dataArea.Replace("\"", "");//Phan cach cac gtri truong
            }
            else
            {
                dataArea = "";
            }

            return dataArea;
        }
        #endregion

        #region Iso Execute
        public string IsoExecute(string strOfsRequest)
        {
            try
            {
                return IsoExecute(TCServerInformation, strOfsRequest);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string IsoExecute(TCServerInfo tcsinfo, string strOfsRequest)
        {
            TcpClient tcp = new TcpClient();
            try
            {
                strOfsRequest = strOfsRequest.Trim();
                if (strOfsRequest == "")
                {
                    OfsErrorCode = OfsError.GENERAL_ERROR;
                    OfsErrorMessage = "Request empty";
                    OfsStatus = false;
                    return "";
                }

                tcp.Connect(tcsinfo.OfsServer, Convert.ToInt16(tcsinfo.OfsPort));

                if (!tcp.Connected)
                {
                    OfsStatus = false;
                    return "";
                }

                NetworkStream ourStream = tcp.GetStream();
                byte[] data = Encoding.ASCII.GetBytes(strOfsRequest);
                ourStream.Write(data, 0, data.Length);

                data = new byte[tcsinfo.OfsBuffer];
                ourStream.Read(data, 0, tcsinfo.OfsBuffer);

                string strOutput = System.Text.Encoding.ASCII.GetString(data, 0, tcsinfo.OfsBuffer);
                if (strOutput == "")
                {
                    OfsErrorCode = OfsError.SERVER_TIMEOUT;
                    OfsErrorMessage = "TimedOut connection";
                    OfsStatus = false;
                }
                else
                {
                    if (strOutput.IndexOf(",", System.StringComparison.Ordinal) < 0)
                    {
                        OfsErrorCode = OfsError.GENERAL_ERROR;
                        OfsStatus = false;
                    }
                    else
                    {                        
                        OfsErrorCode = OfsError.SUCCESS;
                        OfsStatus = true;
                    }
                }
                
                return strOutput;
            }
            catch (Exception ex)
            {
                OfsErrorCode = OfsError.GENERAL_ERROR;
                OfsErrorMessage = ex.Message;
                OfsStatus = false;
                return ex.Message;
            }
        }
        #endregion
    }
}
