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
using System.Threading;
using System.Net.Mail;
using Amazon.SimpleEmail.Model;
using Amazon.SimpleEmail;
using System.Collections.Generic;
using Amazon;

/// <summary>
/// Summary description for ProcessSendEmail
/// </summary>
/// 
namespace Email
{

    public class ProcessSendEmail
    {
        public static bool Stop = false;
        DetailGroupBUS dgBUS = null;
        log4net.ILog logs = log4net.LogManager.GetLogger("ErrorRollingLogFileAppender");
        public ProcessSendEmail()
        {
            string strConnect = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            ConnectionData._ConnectionString = strConnect;
            ConnectionData.AddNewConnection();

        }
        public bool SendMail(string EmailSubject, string EmailBody,
                             string HostName, int PortNumber, string EmailFrom, string Password,
                             string Name, string EmailTo)
        {
            string Body = EmailBody;
            using (System.Net.Mail.MailMessage Msg = new System.Net.Mail.MailMessage())
            {
                Msg.From = new System.Net.Mail.MailAddress(EmailFrom, Name);
                Msg.To.Add(new System.Net.Mail.MailAddress(EmailTo));
                Msg.IsBodyHtml = true;
                Msg.Subject = EmailSubject;
                Msg.Body = Body;
                System.Net.Mail.SmtpClient objMail = new System.Net.Mail.SmtpClient(HostName, PortNumber);
                System.Net.NetworkCredential info = new System.Net.NetworkCredential(EmailFrom, Password);
                objMail.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                objMail.Credentials = info;
                if (EmailFrom.Contains("gmail.com") || EmailFrom.Contains("yahoo.com"))
                {
                    objMail.EnableSsl = true;
                }
                else
                {
                    objMail.EnableSsl = false;
                }
                try
                {
                    objMail.Send(Msg);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public bool SendMail(string EmailSubject, string EmailBody,
                     string HostName, int PortNumber, string EmailFrom, string Password,
                     string Name, string EmailTo, string username, bool isSSL)
        {
            string Body = EmailBody;
            using (System.Net.Mail.MailMessage Msg = new System.Net.Mail.MailMessage())
            {
                Msg.From = new System.Net.Mail.MailAddress(EmailFrom, Name);
                Msg.To.Add(new System.Net.Mail.MailAddress(EmailTo));
                Msg.IsBodyHtml = true;
                Msg.Subject = EmailSubject;
                Msg.Body = Body;
                System.Net.Mail.SmtpClient objMail = new System.Net.Mail.SmtpClient(HostName, PortNumber);
                System.Net.NetworkCredential info = new System.Net.NetworkCredential(username, Password);
                objMail.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                objMail.Credentials = info;
                objMail.EnableSsl = isSSL;
                try
                {
                    objMail.Send(Msg);
                    return true;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString()); logs.Error("ProcessSendEmail-SendMail" + ex);
                    return false;
                }
            }
        }


        public void RunActiveMail(DataTable listSendRegister, DataTable listSendContent, DataTable listCustomer, DataTable listMailConfig)
        {
            try
            {
                //Biến sendMail
                string EmailTo = "";
                string EmailSubject = "";
                string EmailBody = "";
                string EmailFrom = "";
                string Name = "";
                string Password = "";
                string HostName = "";
                int PortNumber = 0;
                //Biến lấy nội dung
                int SendContentId;
                int EmailFromID;
                int SendRegisterID;
                SendRegisterBUS srBus = new SendRegisterBUS();
                //Kiểm tra và duyệt 
                if (listSendRegister.Rows.Count > 0)
                {

                    //So sánh thời gian hiện tại với thời gian cần gửi mail
                    DataRow[] resultListSendRegister = listSendRegister.Select(String.Format("StartDate = #{0}#", String.Format("{0:yyyy-M-d HH:mm:ss}", DateTime.Now)));

                    if (resultListSendRegister.Length > 0)
                    {
                        foreach (DataRow Row in resultListSendRegister)
                        {

                            SendContentId = int.Parse(Row["SendContentId"].ToString());
                            DataRow[] resultListSendContend = listSendContent.Select(String.Format("Id = {0}", SendContentId));
                            if (resultListSendContend.Length > 0)
                            {
                                EmailSubject = resultListSendContend[0]["Subject"].ToString();
                                EmailBody = resultListSendContend[0]["Body"].ToString();
                            }
                            //Mail nhận
                            EmailTo = Row["AccountId"].ToString();
                            SendRegisterID = int.Parse(Row["Id"].ToString());

                            //Lấy cấu hình mail gửi 
                            EmailFromID = int.Parse(Row["MailConfigID"].ToString());
                            DataRow[] resultListMailConfig = listMailConfig.Select(String.Format("Id = {0}", EmailFromID));

                            if (resultListMailConfig.Length > 0)
                            {
                                EmailFrom = resultListMailConfig[0]["Email"].ToString();
                                Password = resultListMailConfig[0]["Password"].ToString();
                                HostName = resultListMailConfig[0]["Server"].ToString();
                                Name = resultListMailConfig[0]["Name"].ToString();
                                //Name = "Chợ Mỹ tại Việt Nam";
                                PortNumber = int.Parse(resultListMailConfig[0]["Port"].ToString());
                            }
                            bool send;
                            send = SendMail(EmailSubject, EmailBody, HostName, PortNumber, EmailFrom, Password, Name, EmailTo);
                            if (send == true)
                            {
                                ConnectionData.OpenMyConnection();
                                srBus.tblSendRegister_UpdateStatus(SendRegisterID, 2, DateTime.Now);
                                ConnectionData.CloseMyConnection();
                            }


                        }

                    }
                    else
                        return;
                }

                else
                    return;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString()); logs.Error("ProcessSendEmail-RunActiveMail" + ex);
            }
        }





        public void SendBulkMail(DataTable listSendRegister, DataTable listSendContent, DataTable listCustomer, DataTable listMailConfig)
        {
            try
            {
                //param for send mail
                string EmailTo = "";
                string customerName = "";
                string EmailSubject = "";
                string EmailBody = "";
                string EmailFrom = "";
                string Name = "";
                string Password = "";
                string HostName = "";
                int PortNumber = 0;
                //param for content
                int SendContentId;
                int EmailFromID;
                int SendRegisterID;
                SendRegisterBUS srBus = new SendRegisterBUS();
                CustomerBUS customerBus = new CustomerBUS();
                SendRegisterDetailBUS srdBus = new SendRegisterDetailBUS();
                //Kiểm tra và duyệt 
                if (listSendRegister.Rows.Count > 0)
                {
                    DataRow Row = null;
                    DateTime currentDate = DateTime.Now;
                    for (int i = 0; i < listSendRegister.Rows.Count; i++)
                    {
                        DataRow rowTemp = listSendRegister.Rows[i];
                        DateTime dateItem = DateTime.Parse(rowTemp["StartDate"].ToString());
                        if (currentDate.Year == dateItem.Year && currentDate.Month == dateItem.Month
                            && currentDate.Day == dateItem.Day && currentDate.Hour == dateItem.Hour
                            && currentDate.Minute == dateItem.Minute)
                        {
                            Row = rowTemp;
                            break;
                        }
                    }

                    if (Row != null)
                    {
                        //stop timer check               
                        SendContentId = int.Parse(Row["SendContentId"].ToString());
                        DataRow[] resultListSendContend = listSendContent.Select(String.Format("Id = {0}", SendContentId));
                        if (resultListSendContend.Length > 0)
                        {
                            EmailSubject = resultListSendContend[0]["Subject"].ToString();
                            EmailBody = resultListSendContend[0]["Body"].ToString();
                        }

                        //Lấy cấu hình mail gửi 
                        EmailFromID = int.Parse(Row["MailConfigID"].ToString());
                        DataRow[] resultListMailConfig = listMailConfig.Select(String.Format("Id = {0}", EmailFromID));

                        if (resultListMailConfig.Length > 0)
                        {
                            EmailFrom = resultListMailConfig[0]["Email"].ToString();
                            Password = resultListMailConfig[0]["Password"].ToString();
                            HostName = resultListMailConfig[0]["Server"].ToString();
                            Name = resultListMailConfig[0]["Name"].ToString();
                            PortNumber = int.Parse(resultListMailConfig[0]["Port"].ToString());
                        }

                        //lấy danh sách mail cần gửi đi
                        string groupId = Row["SendType"].ToString();
                        DataTable tblCustomerByGroup = customerBus.GetByID(int.Parse(groupId));
                        if (tblCustomerByGroup.Rows.Count > 0)
                        {
                            SendRegisterID = int.Parse(Row["Id"].ToString());

                            for (int i = 0; i < tblCustomerByGroup.Rows.Count; i++)
                            {
                                EmailTo = tblCustomerByGroup.Rows[i]["Email"].ToString();
                                customerName = tblCustomerByGroup.Rows[i]["Name"].ToString();
                                DateTime startDate = DateTime.Now;
                                bool send = SendMail(EmailSubject, EmailBody, HostName, PortNumber, EmailFrom, Password, Name, EmailTo);
                                DateTime endDate = DateTime.Now;
                                SendRegisterDetailDTO srdDto = new SendRegisterDetailDTO();
                                srdDto.SendRegisterId = SendRegisterID;
                                srdDto.Email = EmailTo;
                                srdDto.StartDate = startDate;
                                srdDto.EndDate = endDate;
                                srdDto.DayEnd = endDate.Day;
                                srdDto.HoursEnd = endDate.Hour;
                                srdDto.MinuteEnd = endDate.Minute;
                                srdDto.SecondEnd = endDate.Second;
                                srdDto.MailSend = EmailFrom;
                                if (send == true)
                                {
                                    srdDto.Status = true;
                                }
                                else
                                {
                                    srdDto.Status = false;
                                }
                                ConnectionData.OpenMyConnection();
                                //lưu lại thông tin từng mail đã gửi
                                srdBus.tblSendRegisterDetail_insert(srdDto);
                                ConnectionData.CloseMyConnection();
                            }
                            // cập nhật trạng thái đã gửi mail & thời gian kết thúc cho chiến dịch gửi mail này   
                            // trạng thái 1 - đã gửi, 0 - chưa gửi
                            srBus.tblSendRegister_UpdateStatus(SendRegisterID, 1, DateTime.Now);
                        }

                    }
                    else
                        return;
                }
                else
                    return;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString()); logs.Error("ProcessSendEmail-SendBulkMail" + ex);
            }
        }
        // Thêm ngày 16/09 by Viết Hùng
        //Thêm ngày 26/9
        public void callSendBulkMail_BySubGroup(DataRow Row, DataTable listSendContent, DataTable listCustomer, DataTable listMailConfig)
        {
            try
            {
                //param for send mail
                string EmailTo = "";
                string customerName = "";
                string EmailSubject = "";
                string EmailBody = "";
                string EmailFrom = "";
                string Name = "";
                string username = "";
                string Password = "";
                string HostName = "";
                int PortNumber = 0;
                bool isSSL = false;
                //param for content
                int SendContentId;
                int EmailFromID;
                int SendRegisterID = 0;
                int AccountId = 0;
                SendRegisterBUS srBus = new SendRegisterBUS();
                CustomerBUS customerBus = new CustomerBUS();
                SendRegisterDetailBUS srdBus = new SendRegisterDetailBUS();
                dgBUS = new DetailGroupBUS();
                PartSendBUS psBus = new PartSendBUS();
                SendContentBUS scBus = new SendContentBUS();

                try
                {
                    if (Row != null)
                    {
                        // Stop timer check               
                        SendContentId = int.Parse(Row["SendContentId"].ToString());
                        AccountId = int.Parse(Row["AccountId"].ToString());

                        // Lấy nội dung đăng ký gửi đi
                        DataRow[] resultListSendContend = listSendContent.Select(String.Format("Id = {0}", SendContentId));
                        if (resultListSendContend.Length > 0)
                        {
                            EmailSubject = resultListSendContend[0]["Subject"].ToString();
                            EmailBody = resultListSendContend[0]["Body"].ToString();
                        }

                        //Lấy cấu hình mail gửi 
                        EmailFromID = int.Parse(Row["MailConfigID"].ToString());
                        DataRow[] resultListMailConfig = listMailConfig.Select(String.Format("Id = {0}", EmailFromID));
                        if (resultListMailConfig.Length > 0)
                        {
                            EmailFrom = resultListMailConfig[0]["Email"].ToString();
                            username = resultListMailConfig[0]["username"].ToString();
                            Password = resultListMailConfig[0]["Password"].ToString();
                            HostName = resultListMailConfig[0]["Server"].ToString();
                            Name = resultListMailConfig[0]["Name"].ToString();
                            PortNumber = int.Parse(resultListMailConfig[0]["Port"].ToString());
                            isSSL = bool.Parse(resultListMailConfig[0]["isSSL"].ToString());
                        }

                        // ID nhóm mail cần gửi đi
                        string groupId = Row["GroupTo"].ToString();

                        //Lấy danh sách khách hàng của nhóm
                        DataTable tblCustomerBySubGroup = dgBUS.GetByID(int.Parse(groupId));
                        if (tblCustomerBySubGroup.Rows.Count > 0)
                        {
                            // Kiểm tra chiến dịch này có thuộc nhóm gửi mail từng phần
                            DataTable tblPartSend = psBus.GetByUserIdAndGroupId(AccountId, int.Parse(groupId));

                            SendRegisterID = int.Parse(Row["Id"].ToString());
                            for (int i = 0; i < tblCustomerBySubGroup.Rows.Count; i++)
                            {
                                Stop = true;
                                DataTable tblCustomerByID = customerBus.GetByID(int.Parse(tblCustomerBySubGroup.Rows[i]["CustomerID"].ToString()));
                                if (tblCustomerByID.Rows.Count > 0)
                                {
                                    EmailTo = tblCustomerByID.Rows[0]["Email"].ToString();
                                    customerName = (tblCustomerByID.Rows[0]["Name"].ToString() == null || tblCustomerByID.Rows[0]["Name"].ToString() == "") ? EmailTo : tblCustomerByID.Rows[0]["Name"].ToString();
                                }
                                // Xử lý câu chào cho nội dung mail
                                string body = EmailBody.Replace("[khachhang]", customerName);
                                body = body.Replace("[email]", EmailTo);

                                // Xử lý câu chào cho tiêu đề mail
                                string subject = EmailSubject.Replace("[khachhang]", customerName).ToUpper();

                                // Thời gian bắt đầu gửi 
                                DateTime startDate = DateTime.Now;
                                // Thời gian kết thúc gửi
                                DateTime endDate = DateTime.Now;
                                SendRegisterDetailDTO srdDto = new SendRegisterDetailDTO()
                                {
                                    SendRegisterId = SendRegisterID,
                                    Email = EmailTo,
                                    StartDate = startDate,
                                    EndDate = endDate,
                                    DayEnd = endDate.Day,
                                    HoursEnd = endDate.Hour,
                                    MinuteEnd = endDate.Minute,
                                    SecondEnd = endDate.Second,
                                    MailSend = EmailFrom,
                                    CustomerName = customerName,
                                    Status = false,
                                    ErrorType = "0"
                                };
                                int sendetailID = 0;

                                // Lưu lại thông tin từng mail đã gửi                           
                                sendetailID = srdBus.tblSendRegisterDetail_insert(srdDto);
                                srdDto.SendRegisterDetailId = sendetailID;
                                body += String.Format("<IMG height=1 src=\"http://fastautomaticmail.com/emailtrack.aspx?emailsentID={0}\" width=1>", sendetailID);

                                //Update thời gian bắt đầu gửi
                                startDate = DateTime.Now;
                                srdDto.StartDate = DateTime.Now;
                                bool send = false;
                                try
                                {
                                    //===============================================================================
                                    //        Edit by HThanhHai for part send mail
                                    //===============================================================================

                                    // Nếu nhóm này nằm trong danh sách gửi từng phần
                                    if (tblPartSend.Rows.Count > 0)
                                    {
                                        // Kiểm tra số lượng mail khách hàng này đã nhận được
                                        int countReceivedMail = int.Parse(tblCustomerBySubGroup.Rows[i]["countReceivedMail"].ToString());

                                        // Nội dung mail đã gửi cho nhóm này
                                        string hasContentSend = tblPartSend.Rows[0]["hasContentSend"].ToString();
                                        string[] arrayContent = hasContentSend.Split(',');

                                        if (arrayContent.Length > 0)
                                        {
                                            // Nếu số lượng mail khách hàng này nhận ít hơn số nội dung đã gửi đi
                                            if (countReceivedMail < arrayContent.Length)
                                            {
                                                // Duyệt qua những nội dung mà khách hàng này chưa nhận                                            // 
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
                                                        contentDetail = contentDetail.Replace("[email]", EmailTo);

                                                        // Xử lý câu chào cho tiêu đề mail
                                                        subjectDetail = subjectDetail.Replace("[khachhang]", customerName).ToUpper();
                                                    }
                                                    else
                                                    {
                                                        subjectDetail = "No subject";
                                                        contentDetail = "Nội dung không tồn tại !";
                                                    }

                                                    if (HostName == "Amazon API")
                                                    {
                                                        send = SendEmailWithAmazone(EmailFrom, EmailTo, subjectDetail, contentDetail, username, Password, Name);
                                                    }
                                                    else
                                                    {
                                                        send = SendMail(subjectDetail, contentDetail, HostName, PortNumber, EmailFrom, Password, Name, EmailTo, username, isSSL);
                                                    }
                                                }

                                                // Update số lượng mail đã nhận sau khi đã gửi đi đầy đủ
                                                DetailGroupDTO dgDto = new DetailGroupDTO();
                                                dgDto.CustomerID = AccountId;
                                                dgDto.GroupID = int.Parse(groupId);
                                                dgDto.CountReceivedMail = arrayContent.Length;
                                                dgBUS.tblDetailGroup_Update(dgDto);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // Không phải chiến dịch gửi mail từng phần
                                        if (HostName == "Amazon API")
                                        {
                                            send = SendEmailWithAmazone(EmailFrom, EmailTo, subject, body, username, Password, Name);
                                        }
                                        else
                                        {
                                            send = SendMail(subject, body, HostName, PortNumber, EmailFrom, Password, Name, EmailTo, username, isSSL);
                                        }
                                    }

                                }
                                catch (Exception ex)
                                {
                                    const string errSubject = "Error from FAMail";
                                    string errBody = ex.Message + DateTime.Now; ;
                                    const string errHost = "smtp.gmail.com";
                                    const string errUser = "fastautomaticmail@gmail.com";
                                    const string errPass = "a123456789@";
                                    SendMail(errSubject, errBody, errHost, 587, errUser, errPass, "Error from FAMail", "viethung1402@gmail.com");
                                    SendMail(errSubject, errBody, errHost, 587, errUser, errPass, "Error from FAMail", "huynhthanhhai1989@gmail.com");
                                }

                                //Update thời gian bắt kết thúc
                                srdDto.EndDate = endDate;
                                endDate = DateTime.Now;
                                srdBus.tblSendRegisterDetail_Update(sendetailID, startDate, endDate, send);
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString()); logs.Error("ProcessSendEmail-callSendBulkMail_BySubGroup" + e);
                }
                finally
                {
                    // cập nhật trạng thái đã gửi mail & thời gian kết thúc cho chiến dịch gửi mail này   
                    // trạng thái 1 - đã gửi, 0 - chưa gửi              
                    srBus.tblSendRegister_UpdateStatus(SendRegisterID, 1, DateTime.Now);
                    Stop = false;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString()); logs.Error("ProcessSendEmail-callSendBulkMail_BySubGroup" + ex);
            }
        }

        public static bool SendEmailWithAmazone(string FROM, string TO, string SUBJECT, string BODY, string AWSAccessKey, string AWSSecrectKey, string NameSender)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("ErrorRollingLogFileAppender");
            try
            {
                string Name = NameSender;
                Destination destination = new Destination().WithToAddresses(new List<string>() { TO });
                // Create the subject and body of the message.
                Amazon.SimpleEmail.Model.Content subject = new Amazon.SimpleEmail.Model.Content().WithData(SUBJECT);
                Amazon.SimpleEmail.Model.Content textBody = new Amazon.SimpleEmail.Model.Content().WithData(BODY);
                Body body = new Body().WithHtml(textBody);

                // Create a message with the specified subject and body.
                Message message = new Message().WithSubject(subject).WithBody(body);

                string Fr = String.Format("{0}<{1}>", Name, FROM);
                SendEmailRequest request = new SendEmailRequest().WithSource(Fr).WithDestination(destination).WithMessage(message);

                using (AmazonSimpleEmailServiceClient client = new AmazonSimpleEmailServiceClient(AWSAccessKey, AWSSecrectKey))
                {
                    // Send the email.
                    try
                    {
                        client.SendEmail(request);
                        return true;
                    }
                    catch (Exception e)
                    {
                        log.Error("ProcessSendEmail-callSendBulkMail_BySubGroup" + e);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString()); log.Error("ProcessSendEmail-callSendBulkMail_BySubGroup" + ex);return false;
            }

        }



    }
}


