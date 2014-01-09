using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Email;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using BatchSendMail.ext.dto;
using System.Threading;
using Amazon.SimpleEmail.Model;
using Amazon.SimpleEmail;
using System.Text.RegularExpressions;
namespace BatchSendMail
{
    public partial class frmMain : Form
    {
        // Parameter for multi thread send mail.
        static readonly object syncRoot = new object();
        private readonly static int maxParallelEmails = 196;
        private readonly static int maxParallelEvent = 1;

        log4net.ILog logs = log4net.LogManager.GetLogger("ErrorRollingLogFileAppender");
        log4net.ILog logs_info = log4net.LogManager.GetLogger("InfoRollingLogFileAppender");

        log4net.ILog logs_scan = log4net.LogManager.GetLogger("ScanEmailAppender");

        // Initial BUS.
        private SendRegisterBUS srBus = new SendRegisterBUS();
        private CustomerBUS customerBus = new CustomerBUS();
        private SendRegisterDetailBUS srdBus = new SendRegisterDetailBUS();
        private DetailGroupBUS dgBUS = new DetailGroupBUS();
        private PartSendBUS psBus = new PartSendBUS();
        private SendContentBUS scBus = new SendContentBUS();
        private SendRegisterBUS sendBUS = new SendRegisterBUS();
        private SendContentBUS scBUS = new SendContentBUS();
        private MailConfigBUS mcBUS = new MailConfigBUS();
        private SendRegisterDetailBUS sendDetailBUS = new SendRegisterDetailBUS();

        // Parameter for config server.        
        private string hostName = String.Empty;
        private string userSmtp = String.Empty;
        private string passSmtp = String.Empty;
        private int port = 0;
        private string senderName = String.Empty;
        private bool SSL = false;

        // Parameter for send mail.
        private string subject = String.Empty;
        private string body = String.Empty;
        private string mailFrom = String.Empty;
        private string mailTo = String.Empty;

        // Infor store of campaign send mail.
        private int sendRegisterId = 0;
        private int sendContentId = 0;
        private int configId = 0;
        private int groupId = 0;
        private int accountId = 0;
        private int SendType = 0;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitConnectToDatabase();
            btnStop.Enabled = false;
            btnStopEvent.Enabled = false;
            lblStatus.Text = "Đang ngưng dịch vụ";
            timer2.Start();
        }

        /**
         * Connect database.
         * */
        private void InitConnectToDatabase()
        {
            try
            {
                string conn = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
                //string strConnect = "Server=localhost;Database=SendMailVersion3;Uid=SendMailVersion3;Pwd=123456789;Min Pool Size=1;Max Pool Size=500;Pooling=true;MultipleActiveResultSets=true;";
                ConnectionData._ConnectionString = conn;
                ConnectionData.AddNewConnection();
            }
            catch
            {
                MessageBox.Show("Lỗi xảy ra trong quá trình kết nối cơ sở dữ liệu . Vui lòng kiểm tra kết nối!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }

        }

        /**
         * Lấy thông tin cấu hình server gửi mail.
         * Param: configId
         * */
        private void getConfigServer(int configId)
        {
            DataTable tableConfig = mcBUS.GetByID(configId);
            if (tableConfig.Rows.Count > 0)
            {
                hostName = tableConfig.Rows[0]["Server"].ToString();
                mailFrom = tableConfig.Rows[0]["Email"].ToString();
                userSmtp = tableConfig.Rows[0]["username"].ToString();
                passSmtp = tableConfig.Rows[0]["Password"].ToString();
                port = int.Parse(tableConfig.Rows[0]["Port"].ToString());
                senderName = tableConfig.Rows[0]["Name"].ToString();
                SSL = bool.Parse(tableConfig.Rows[0]["isSSL"].ToString());
            }
        }

        /**
         * Lấy nội dung cần gửi mail.
         * Param: contentId
         **/
        private void getMailContent(int contentId)
        {
            DataTable tableContent = scBUS.GetByID(sendContentId);
            if (tableContent.Rows.Count > 0)
            {
                subject = tableContent.Rows[0]["Subject"].ToString();
                body = tableContent.Rows[0]["Body"].ToString();
            }
        }

        /**
         * Timer tick.
         **/
        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                EmailSend mailSend = new EmailSend();
                DataTable tableSend = sendBUS.GetByTime(DateTime.Now, 0);
                if (tableSend.Rows.Count > 0)
                {
                    lblStatus.Text = "Đang gửi mail....";
                    foreach (DataRow item in tableSend.Rows)
                    {
                        timer1.Stop();
                        sendRegisterId = int.Parse(item["Id"].ToString());
                        sendContentId = int.Parse(item["SendContentId"].ToString());
                        configId = int.Parse(item["MailConfigID"].ToString());
                        groupId = int.Parse(item["GroupTo"].ToString());
                        SendType = int.Parse(item["SendType"].ToString());
                        accountId = int.Parse(item["AccountId"].ToString());

                        int SendRegisterId = int.Parse(item["Id"] + "");

                        //Lấy thông tin cấu hình mail gửi
                        getConfigServer(configId);

                        // Lấy nội dung mail
                        getMailContent(sendContentId);

                        IList<MailToDTO> recipients = mailSend.GetMailTod(SendRegisterId, groupId, SendType);

                        //IList<string> EmailS
                        int cnt = 0;
                        int totalCnt = recipients.Count;
                        Parallel.ForEach(recipients.AsParallel(), new ParallelOptions { MaxDegreeOfParallelism = maxParallelEmails }, recipient =>
                        {
                            bool send = false;
                            //DataTable tblPartSend = psBus.GetByUserIdAndGroupId(accountId, groupId);
                            // Send normal.
                            send = sendMail(send, port, hostName, userSmtp, passSmtp, mailFrom, senderName,
                                subject, body, recipient.Name, recipient.MailTo, sendRegisterId);
                            logs_info.Info("Status: " + send + ", sendRegisterId:" + sendRegisterId + ", MailTo: " + recipient.MailTo + ", mailFrom: " + mailFrom + ", Name: " + recipient.Name);
                            // Write log for history send
                            logHistoryForSend(sendRegisterId, recipient.MailTo, mailFrom, recipient.Name, send);

                            lock (syncRoot) cnt++;
                        });

                        // Update status for send mail campaign.
                        sendBUS.tblSendRegister_UpdateStatus(sendRegisterId, 1, DateTime.Now);
                    }
                    timer1.Start();
                    lblStatus.Text = "Đang chờ gửi mail";
                }
            }
            catch (Exception ex)
            {
                logs.Error("timer-tick", ex);

            }
        }

        /**
         * Lưu lại thông tin chi tiết của mail đã gửi.
         * Param: sendRegisterId, mailTo, mailFrom, name, status.
         **/
        private void logHistoryForSend(int sendRegisterId, string mailTo, string mailFrom, string name, bool status)
        {
            try
            {
                SendRegisterDetailDTO srdDto = new SendRegisterDetailDTO();
                srdDto.SendRegisterId = sendRegisterId;
                srdDto.Email = mailTo;
                srdDto.StartDate = DateTime.Now;
                srdDto.EndDate = DateTime.Now;
                srdDto.DayEnd = DateTime.Now.Day;
                srdDto.HoursEnd = DateTime.Now.Hour;
                srdDto.MinuteEnd = DateTime.Now.Minute;
                srdDto.SecondEnd = DateTime.Now.Second;
                srdDto.MailSend = mailFrom;
                srdDto.CustomerName = name;
                srdDto.ErrorType = "";
                srdDto.Status = status;

                sendDetailBUS.tblSendRegisterDetail_insert(srdDto);
            }
            catch (Exception)
            {
            }
        }

        /**
         * Send mail.
         * Param: send, port, hostName,...
         **/
        private bool sendMail(bool send, int port, string hostName,
            string userNameSmtp, string passwordSmtp, string emailFrom, string nameSender,
            string subject, string body, string name, string mailTo, int sendRegisterId)
        {
            if (validateEmail(mailTo.Trim()))
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Port = port;//Port gửi mail
                smtp.Host = hostName; //SMTP của amazone
                smtp.Credentials = new System.Net.NetworkCredential(userNameSmtp, passwordSmtp); // Username SMTP và Password SMTP 
                smtp.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(emailFrom, nameSender);// Email đã được verify trên Amazone
                //string isSubject=Subject.Replace("[khachhang]", recipient.Name).ToUpper();
                mail.Subject = subject;
                string isBody = body.Replace("[khachhang]", name);
                string Unreceve = String.Format("<p style='text-align: center;'>" +
                "<span style='color: rgb(102, 102, 102); font-family: Arial, Helvetica, sans-serif; font-size: 11px;'>If you have no more interest in receiving this, please unsubscribe.</span></p>" +
                "<p style='text-align: center;'>" +
                "<strong> Để ngừng nhận mail vui lòng click <a href='http://" + ConfigurationManager.AppSettings["site"] + "/UnReciveMail.aspx?sendRegisterId={0}&email={1}'>vào đây</a></strong></p>", sendRegisterId, mailTo);
                isBody += Unreceve;
                isBody += String.Format("<IMG height=1 src=\"http://" + ConfigurationManager.AppSettings["site"] + "/emailtrack.aspx?emailsentID={0}&email={1}\" width=1>", sendRegisterId, mailTo);
                mail.Body = isBody;
                mail.IsBodyHtml = true;
                // Thực hiện gửi Email
                mail.To.Add(mailTo);
                // mail.Headers.Add("","");
                try
                {
                    smtp.Send(mail);
                    //logs_info.Info(mail.From + "==>" + mail.To);
                    return true;
                }
                catch (Exception ex)
                {
                    logs.Error("send:" + mail.From + "==>" + mail.To, ex);
                    return false;
                }
            }
            else return false;
        }
        bool validateEmail(string email)
        {
            string pattern = null;
            pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (Regex.IsMatch(email, pattern))
            {
                return true;
            }
            else
            {
                logs.Error("invalid email: " + email);
                return false;
            }
        }

        /**
         * Part send mail.
         * Param: countReceivedMail, customerName, emailTo
         **/

        public void callPartSend(int countReceivedMail,
            string customerName, string emailTo, int customerId)
        {

            // Kiểm tra chiến dịch này có thuộc nhóm gửi mail từng phần
            DataTable tblPartSend = psBus.GetByUserIdAndGroupId(accountId, groupId);
            if (tblPartSend.Rows.Count > 0)
            {
                // Nội dung mail đã gửi cho nhóm này
                string hasContentSend = tblPartSend.Rows[0]["hasContentSend"].ToString();
                string[] arrayContent = hasContentSend.Split(',');

                if (arrayContent.Length > 0)
                {
                    // Nếu số lượng mail khách hàng này nhận ít hơn số nội dung đã gửi đi
                    if (countReceivedMail < arrayContent.Length)
                    {
                        // Duyệt qua những nội dung mà khách hàng này chưa nhận.// 
                        for (int k = countReceivedMail; k < arrayContent.Length; k++)
                        {
                            string contentId = arrayContent[k];
                            string contentDetail, subjectDetail;
                            DataTable tblContent = scBus.GetByID(int.Parse(contentId));
                            if (tblContent.Rows.Count > 0)
                            {
                                subjectDetail = tblContent.Rows[0]["Subject"].ToString();
                                contentDetail = tblContent.Rows[0]["Body"].ToString();

                                contentDetail = contentDetail.Replace("[khachhang]", customerName);
                                contentDetail = contentDetail.Replace("[email]", emailTo);

                                // Xử lý câu chào cho tiêu đề mail
                                subjectDetail = subjectDetail.Replace("[khachhang]", customerName).ToUpper();
                                bool send = false;
                                sendMail(send, port, hostName, userSmtp, passSmtp, mailFrom, senderName,
                                    subjectDetail, contentDetail, customerName, emailTo, sendRegisterId);

                                // Ghi lại nhật ký gửi mail.
                                logHistoryForSend(sendRegisterId, mailTo, mailFrom, senderName, send);
                            }
                        }

                        // Cập nhật số lượng mail đã nhận sau khi đã gửi đi đầy đủ.
                        DetailGroupDTO dgDto = new DetailGroupDTO();
                        dgDto.CustomerID = customerId;
                        dgDto.GroupID = groupId;
                        dgDto.CountReceivedMail = arrayContent.Length;
                        dgBUS.tblDetailGroup_Update(dgDto);
                    }
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            timer1.Enabled = true;
            timer1.Start();
            lblStatus.Text = "Đang chờ gửi mail...";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            lblStatus.Text = "Đang ngưng dịch vụ";
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblDay.Text = DateTime.Now.Day.ToString();
            lblMonth.Text = DateTime.Now.Month.ToString();
            lblYear.Text = DateTime.Now.Year.ToString();
            lblSecond.Text = DateTime.Now.Second.ToString();
            lblHour.Text = DateTime.Now.Hour.ToString();
            lblMinute.Text = DateTime.Now.Minute.ToString();
        }

        private void btnStartEvent_Click(object sender, EventArgs e)
        {
            btnStartEvent.Enabled = false;
            btnStopEvent.Enabled = true;
            timerEvent.Enabled = true;
            timerEvent.Start();
        }

        private void btnStopEvent_Click(object sender, EventArgs e)
        {
            btnStartEvent.Enabled = true;
            btnStopEvent.Enabled = false;
            timerEvent.Stop();
        }

        private void timerEvent_Tick(object sender, EventArgs e)
        {
            try
            {
                EmailSend mailSend = new EmailSend();
                DetailGroupBUS dgBus = new DetailGroupBUS();
                ContentSendEventBUS cseBus = new ContentSendEventBUS();
                SendContentBUS scBus = new SendContentBUS();
                EventBUS eventBUS = new EventBUS();

                DataTable tblSendList = dgBus.getGroupListByEventList();
                if (tblSendList.Rows.Count > 0)
                {

                    List<SendMailDTO> sendList = mailSend.convetToSendMail(tblSendList);
                    int totalCnt = sendList.Count;
                    foreach (SendMailDTO sendItem in sendList)
                    {
                        int eventId = sendItem.eventId;
                        DataTable dtContentSendEvent = cseBus.GetByEventId(eventId);
                        if (dtContentSendEvent.Rows.Count > 0)
                        {
                            if (sendItem.countReceivedMail == 0
                                && sendItem.lastReceivedMail == "") // Gui lan dau
                            {
                                int contentId = int.Parse(dtContentSendEvent.Rows[0]["ContentId"].ToString());
                                int hourSend = int.Parse(dtContentSendEvent.Rows[0]["HourSend"].ToString());
                                DataTable dtSendContent = scBus.GetByID(contentId);
                                subject = dtSendContent.Rows[0]["Subject"].ToString();
                                body = dtSendContent.Rows[0]["Body"].ToString();

                                bool sendRs = false;
                                // Send normal.
                                bool send = sendMail(sendRs, sendItem.port, sendItem.hostName, sendItem.userSmtp, sendItem.passSmtp, sendItem.mailFrom, sendItem.senderName,
                                        subject, body, sendItem.recieveName, sendItem.mailTo, sendRegisterId);
                                logs_info.Info("Status: " + send + ", sendRegisterId:" + sendRegisterId + ", MailTo: " + sendItem.mailTo + ", mailFrom: " + mailFrom + ", Name: " + sendItem.recieveName);

                                // Update tblDetailGroup.
                                DetailGroupDTO dgDto = new DetailGroupDTO();
                                dgDto.CustomerID = sendItem.customerId;
                                dgDto.GroupID = sendItem.groupId;
                                dgDto.CountReceivedMail = sendItem.countReceivedMail + 1;
                                dgDto.LastReceivedMail = DateTime.Now;
                                dgBus.tblDetailGroup_Update(dgDto);

                                eventBUS.tblEventCustomer_Update(eventId, sendItem.customerId, sendItem.countReceivedMail + 1);

                            }
                            else if (sendItem.countReceivedMail < dtContentSendEvent.Rows.Count)
                            {
                                string strReceivedMail = sendItem.lastReceivedMail;
                                DateTime lastReceivedMail = DateTime.Now;
                                if (strReceivedMail != "")
                                {
                                    lastReceivedMail = DateTime.Parse(strReceivedMail);
                                }
                                int hourSend = int.Parse(dtContentSendEvent.Rows[sendItem.countReceivedMail]["HourSend"].ToString());
                                DateTime currentTime = lastReceivedMail.AddHours(hourSend);
                                TimeSpan time = currentTime - DateTime.Now;
                                /*if (DateTime.Now.Year == currentTime.Year
                                    && DateTime.Now.Month == currentTime.Month
                                    && DateTime.Now.Day == currentTime.Day
                                    && DateTime.Now.Hour == currentTime.Hour
                                    && DateTime.Now.Minute == currentTime.Minute)*/
                                if (time.Days < 0 || time.Hours < 0 || time.Minutes < 0 || time.Seconds < 0)
                                {
                                    int contentId = int.Parse(dtContentSendEvent.Rows[sendItem.countReceivedMail]["ContentId"].ToString());
                                    DataTable dtSendContent = scBus.GetByID(contentId);
                                    if (dtSendContent.Rows.Count > 0)
                                    {
                                        subject = dtSendContent.Rows[0]["Subject"].ToString();
                                        body = dtSendContent.Rows[0]["Body"].ToString();
                                    }

                                    bool sendRs = false;
                                    // Send normal.
                                    bool send = sendMail(sendRs, sendItem.port, sendItem.hostName, sendItem.userSmtp, sendItem.passSmtp, sendItem.mailFrom, sendItem.senderName,
                                            subject, body, sendItem.recieveName, sendItem.mailTo, sendRegisterId);

                                    logs_info.Info("Status: " + send + ", sendRegisterId:" + sendRegisterId + ", MailTo: " + sendItem.mailTo + ", mailFrom: " + mailFrom + ", Name: " + sendItem.recieveName);
                                    // Update tblDetailGroup.
                                    DetailGroupDTO dgDto = new DetailGroupDTO();
                                    dgDto.CustomerID = sendItem.customerId;
                                    dgDto.GroupID = sendItem.groupId;
                                    dgDto.CountReceivedMail = sendItem.countReceivedMail + 1;
                                    dgDto.LastReceivedMail = DateTime.Now;
                                    dgBus.tblDetailGroup_Update(dgDto);
                                    eventBUS.tblEventCustomer_Update(eventId, sendItem.customerId, sendItem.countReceivedMail + 1);
                                }
                            }
                        }
                    }// End forEach.

                }
            }
            catch (Exception ex)
            {
                logs.Error("timer2_tick", ex);
            }
        }

        private void btnStartCheckMail_Click(object sender, EventArgs e)
        {
            if (!check_worker.IsBusy)
            {
                btnStartCheckMail.Enabled = false;
                btnStopCheckMail.Enabled = true;
                check_worker.RunWorkerAsync();
            }
        }

        private void validateEmail(DataRow row)
        {
            string email = row["Email"].ToString().Trim();
            try
            {
                MailAddress m = new MailAddress(email);
                // Khong kiem tra voi yahoo mail.
                if (!m.Host.ToLower().Equals("yahoo.com")
                    && !m.Host.ToLower().Equals("yahoo.com.vn"))
                {
                    string text = "Scan: " + email;
                    logs_scan.Info(text); //lblInfo.Text = text;
                    EmailVerifier verify = new EmailVerifier(true);
                    bool rs = verify.CheckExists(email);
                    if (!rs)
                    {
                        // Xoa va sao luu khach hang nay.
                        deleteAndBackupCustomer(row);
                        text = "Scan-Fail: " + email;
                        logs_scan.Info(text); //lblInfo.Text = text;
                    }
                    else
                    {
                        text = "Scan-OK: " + email;
                        logs_scan.Info(text); //lblInfo.Text = text;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xoa va sao luu khach hang nay.
                deleteAndBackupCustomer(row);
                logs_scan.Info("Scan-Error: " + email,ex);
            }

        }

        private void deleteAndBackupCustomer(DataRow row)
        {
            int id = int.Parse(row["Id"].ToString());
            string Name = (row["Name"] == null) ? "" : row["Name"].ToString();
            string Gender = (row["Gender"] == null) ? "" : row["Gender"].ToString();
            DateTime BirthDay = (row["BirthDay"] == null) ? DateTime.Now : DateTime.Parse(row["BirthDay"].ToString());
            string Email = (row["Email"] == null) ? "" : row["Email"].ToString().Trim();
            string Phone = (row["Phone"] == null) ? "" : row["Phone"].ToString();
            string SecondPhone = (row["SecondPhone"] == null) ? "" : row["SecondPhone"].ToString();
            string Address = (row["Address"] == null) ? "" : row["Address"].ToString();
            string Fax = (row["Fax"] == null) ? "" : row["Fax"].ToString();
            string Company = (row["Company"] == null) ? "" : row["Company"].ToString();
            string City = (row["City"] == null) ? "" : row["City"].ToString();
            string Province = (row["Province"] == null) ? "" : row["Province"].ToString();
            string Country = (row["Country"] == null) ? "" : row["Country"].ToString();
            string Type = (row["Type"] == null) ? "" : row["Type"].ToString();
            int countBuy = (row["countBuy"] == null) ? 0 : int.Parse(row["countBuy"].ToString());
            bool recivedEmail = (row["recivedEmail"] == null) ? false : bool.Parse(row["recivedEmail"].ToString());

            // Xoa trong table tblCustomer(Cap nhat colum IdDelete = 1)
            customerBus.updateIsDelete(1, id);

            // Backup trong table tblCustomerBackup
            CustomerDTO cusDto = new CustomerDTO();
            cusDto.Id = id;
            cusDto.Name = Name;
            cusDto.Gender = Gender;
            cusDto.BirthDay = BirthDay;
            cusDto.Email = Email;
            cusDto.Phone = Phone;
            cusDto.SecondPhone = SecondPhone;
            cusDto.Address = Address;
            cusDto.Fax = Fax;
            cusDto.Company = Company;
            cusDto.City = City;
            cusDto.Province = Province;
            cusDto.Country = Country;
            cusDto.Type = Type;
            cusDto.countBuy = countBuy;
            cusDto.recivedEmail = recivedEmail;

            customerBus.tblCustomerBackup_insert(cusDto);
        }

        private void btnStopCheckMail_Click(object sender, EventArgs e)
        {
            btnStartCheckMail.Enabled = true;
            btnStopCheckMail.Enabled = false;

            check_worker.CancelAsync();
        }

        private void auto_worker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void event_worker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void check_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int cusLastId = customerBus.GetLastId();
            if (cusLastId > 0)
            {
                // Quy dinh lay 100 record cho moi lan lay danh sach
                int countPaging = cusLastId / 100;
                int start = 1;
                int end = 100;
                for (int i = 1; i <= countPaging; i++)
                {
                    DataTable tblCustomer = customerBus.GetBetweenById(start, cusLastId);
                    if (tblCustomer.Rows.Count > 0)
                    {
                        foreach (DataRow row in tblCustomer.Rows)
                        {
                            validateEmail(row);
                        }
                    }
                    start = end;
                    end = end * (i + 1);
                    Thread.Sleep(10000);
                }
            }
        }

        private void check_worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //lblInfo.Text = e.UserState + "";
        }
    }
}
