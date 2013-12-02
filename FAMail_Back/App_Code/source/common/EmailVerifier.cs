using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Collections.Specialized;
using System.Threading;
using System.Collections.Generic;

/// <summary>
/// Summary description for EmailVerifier
/// </summary>
public class EmailVerifier:IDisposable
{
        private bool _useSMTPMethod;
        private Commander _commander = new Commander();

        public EmailVerifier(bool useSMTPMethod)
        {
            _useSMTPMethod = useSMTPMethod;
        }

        public bool CheckExists(string email)
        {
            if (_useSMTPMethod)
                return IsFormatValid(email) && IsExists_SMTPMethod(email);
            else
                return IsFormatValid(email) && IsExists_WebClientMethod(email);
        }

        private IList<string> _validList;
        private int _count;

        public IList<string> CheckExists(IList<string> emailList)
        {
            _validList = new List<string>();
            _count = 0;

            foreach (string email in emailList)
            {
                ParameterizedThreadStart threadStart = new ParameterizedThreadStart(CheckEmailExistsThreaded);
                Thread thread = new Thread(threadStart);

                thread.Start(email);
            }

            // Wait for completion
            while (_count < emailList.Count)
            {
                Thread.Sleep(100);
            }

            return _validList;
        }

        private void CheckEmailExistsThreaded(object emailObject)
        {
            string email = emailObject.ToString();
            bool result = CheckExists(email);
            lock (_validList)
            {
                if (result)
                    _validList.Add(email);

                _count++;
            }
        }

        private bool IsExists_WebClientMethod(string email)
        {
            using (WebClient wc = new WebClient())
            {
                string url = "http://verify-email.org";
                NameValueCollection formData = new NameValueCollection();
                formData["check"] = email;
                byte[] responseBytes = wc.UploadValues(url, "POST", formData);
                string response = Encoding.ASCII.GetString(responseBytes);
                return response.Contains("Result: Ok");
            }
        }

        private bool IsFormatValid(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            if (!email.Contains("@"))
                return false;

            if (!email.Contains("."))
                return false;

            return true;
        }

        public bool IsExists_SMTPMethod(string email)
        {
            string domain = email.Substring(email.IndexOf("@") + 1);
            var servers = _commander.GetMXServers(domain);

            Socket socket = null;

            foreach (MXServer mxserver in servers)
            {
                IPHostEntry ipHost = Dns.Resolve(mxserver.MailExchanger);
                IPEndPoint endPoint = new IPEndPoint(ipHost.AddressList[0], 25);
                socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(endPoint);

                if (!CheckResponse(socket, ResponseEnum.ConnectSuccess))
                {
                    socket.Close();

                }
                else
                {
                    // If connected, send SMTP commands
                    {
                        SendData(socket, string.Format("HELO {0}\r\n", "machinename"));
                        if (!CheckResponse(socket, ResponseEnum.GenericSuccess))
                        {
                            socket.Close();
                            continue;
                        }

                        SendData(socket, string.Format("MAIL FROM:  <{0}>\r\n", "from@domain.com"));
                        CheckResponse(socket, ResponseEnum.GenericSuccess);

                        SendData(socket, string.Format("RCPT TO:  <{0}>\r\n", email));
                        bool result = CheckResponse(socket, ResponseEnum.GenericSuccess);
                        if (!result)
                        {
                            socket.Close();
                            continue;
                        }
                        else
                            return true;
                    }
                }
            }

            return false;
        }

        private void SendData(Socket socket, string message)
        {
            byte[] _msg = Encoding.ASCII.GetBytes(message);
            socket.Send(_msg, 0, _msg.Length, SocketFlags.None);
        }

        private string _lastResponse;

        private bool CheckResponse(Socket socket, ResponseEnum responseEnum)
        {
            _lastResponse = string.Empty;
            int response;
            byte[] bytes = new byte[1024];

            int count = 1;
            while (socket.Available == 0)
            {
                System.Threading.Thread.Sleep(1000);
                count++;

                if (count > 10)
                    return false;
            }

            socket.Receive(bytes, 0, socket.Available, SocketFlags.None);
            _lastResponse = Encoding.ASCII.GetString(bytes);
            response = Convert.ToInt32(_lastResponse.Substring(0, 3));

            if (response == (int)responseEnum)
                return true;

            return false;
        }

        #region IDisposable Members

        public void Dispose()
        {
        
        }

        #endregion

        public enum ResponseEnum : int
        {
            ConnectSuccess = 220,
            GenericSuccess = 250,
            DataSuccess = 354,
            QuitSuccess = 221
        }

}
