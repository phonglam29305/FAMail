using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using BatchSendMail.ext.dto;

/// <summary>
/// Summary description for EmailSend
/// </summary>
public class EmailSend
{
    SendRegisterDetailBUS srdBUS = null;
    SendContentBUS scBUS = null;
    MailConfigBUS mcBUS = null;
    DetailGroupBUS dtGroupBUS = null;
    CustomerBUS ctBUS = null;
    CountBuyBUS countBUS = null;
    public EmailSend()
    {
        srdBUS = new SendRegisterDetailBUS();
        scBUS = new SendContentBUS();
        mcBUS = new MailConfigBUS();
        ctBUS = new CustomerBUS();
        dtGroupBUS = new DetailGroupBUS();
        countBUS = new CountBuyBUS();

    }
    public IList<EmailDTO> GetMailToSend(int SendRegisterID, int SendContentID, int ConfigID)
    {
        List<EmailDTO> listEmail = new List<EmailDTO>();
        EmailDTO eDTO = new EmailDTO();
        string Subject = "";
        string Body = "";
        string EmailFrom = "";
        string HostName = "";
        string UserNameSMTP = "";
        string PasswordSMTP = "";
        int Port = 0;
        string NameSender = "";
        bool SSL = false;
        //Lấy thông tin cấu hình mail gửi
        DataTable tableConfig = mcBUS.GetByID(ConfigID);
        if (tableConfig.Rows.Count > 0)
        {
            HostName = tableConfig.Rows[0]["Server"].ToString();
            EmailFrom = tableConfig.Rows[0]["Email"].ToString();
            UserNameSMTP = tableConfig.Rows[0]["username"].ToString();
            PasswordSMTP = tableConfig.Rows[0]["Password"].ToString();
            Port = int.Parse(tableConfig.Rows[0]["Port"].ToString());
            NameSender = tableConfig.Rows[0]["Name"].ToString();
            SSL = bool.Parse(tableConfig.Rows[0]["isSSL"].ToString());
        }
        // Lấy nội dung mail
        DataTable tableContent = scBUS.GetByID(SendContentID);
        if (tableContent.Rows.Count > 0)
        {
            Subject = tableContent.Rows[0]["Subject"].ToString();
            Body = tableContent.Rows[0]["Body"].ToString();
        }
        //Lấy nội dung để gửi
        DataTable table = srdBUS.GetByStatus(false, SendRegisterID);
        if (table.Rows.Count > 0)
        {
            foreach (DataRow rowEmail in table.Rows)
            {
                //Thông tin mail gửi
                eDTO.HostName = HostName;
                eDTO.MailFrom = EmailFrom;
                eDTO.UsernameSMTP = UserNameSMTP;
                eDTO.PasswordSMTP = PasswordSMTP;
                eDTO.Port = Port;
                eDTO.SSL = SSL;
                //Thông tin nội dung
                string eSubject = Subject.Replace("[khachhang]", rowEmail["CustomerName"].ToString());
                string eBody = Body.Replace("[khachhang]", rowEmail["CustomerName"].ToString());
                eBody += String.Format("<IMG height=1 src=\"http://fastautomaticmail.com/emailtrack.aspx?emailsentID={0}\" width=1>", rowEmail["SendRegisterDetailId"]);
                eDTO.Subject = eSubject;
                eDTO.Content = eBody;
                eDTO.SendID = int.Parse(rowEmail["SendRegisterDetailId"].ToString());
                eDTO.MailTo = rowEmail["Email"].ToString();
                listEmail.Add(eDTO);
            }
        }

        return listEmail;
    }
    public IList<MailToDTO> GetMailTod(int SendRegisterId, int GroupID, int sendtype)
    {
        List<MailToDTO> listEmail = new List<MailToDTO>();
        DataTable table = new DataTable();
        #region Gửi cho tất cả khách hàng
        if (GroupID == -3)
        {
            //Gửi cho tất cả khách hàng
            table = ctBUS.GetAllByRegisterId(SendRegisterId);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow rowEmail in table.Rows)
                {
                    //Thông tin khách hàng
                    MailToDTO mt = new MailToDTO();
                    int CustomerID = int.Parse(rowEmail["Id"].ToString());
                    string name = rowEmail["Name"].ToString();
                    string email = rowEmail["Email"].ToString();
                    if (name != "" || name != "Không có")
                    {
                        mt.customerId = CustomerID;
                        mt.Name = name;
                        mt.MailTo = email;
                        mt.countReceivedMail = rowEmail["countReceivedMail"] + "" == "" ? 0 : int.Parse(rowEmail["countReceivedMail"].ToString());
                    }
                    else
                    {
                        mt.customerId = CustomerID;
                        mt.MailTo = email;
                        mt.Name = email;
                        mt.countReceivedMail = rowEmail["countReceivedMail"] + "" == "" ? 0 : int.Parse(rowEmail["countReceivedMail"].ToString()); ;
                    }
                    listEmail.Add(mt);
                }//Kết thúc foreach
            }
        }
        #endregion
        #region Khách hàng mua nhiều lần
        else if (GroupID == -2)
        {
            //Gửi cho khách hàng mua hàng nhiều hơn 2 lần tại website
            table = ctBUS.GetByCountBuy(2);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow rowEmail in table.Rows)
                {
                    //Thông tin khách hàng
                    MailToDTO mt = new MailToDTO();
                    int CustomerID = int.Parse(rowEmail["Id"].ToString());
                    string name = rowEmail["Name"].ToString();
                    string email = rowEmail["Email"].ToString();
                    if (name != "" || name != "Không có")
                    {
                        mt.customerId = CustomerID;
                        mt.Name = name;
                        mt.MailTo = email;
                        mt.countReceivedMail = int.Parse(rowEmail["countReceivedMail"].ToString());
                    }
                    else
                    {
                        mt.customerId = CustomerID;
                        mt.MailTo = email;
                        mt.Name = email;
                        mt.countReceivedMail = int.Parse(rowEmail["countReceivedMail"].ToString()); ;
                    }
                    listEmail.Add(mt);
                }//Kết thúc foreach

            }

        }
        #endregion
        #region Khách hang mua lần đầu
        else if (GroupID == -1)
        {
            //Gửi cho khách hàng mua lần đầu tại website
            table = ctBUS.GetByCountBuy(1);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow rowEmail in table.Rows)
                {
                    //Thông tin khách hàng
                    MailToDTO mt = new MailToDTO();
                    int CustomerID = int.Parse(rowEmail["Id"].ToString());
                    string name = rowEmail["Name"].ToString();
                    string email = rowEmail["Email"].ToString();
                    if (name != "" || name != "Không có")
                    {
                        mt.customerId = CustomerID;
                        mt.Name = name;
                        mt.MailTo = email;
                        mt.countReceivedMail = int.Parse(rowEmail["countReceivedMail"].ToString());
                    }
                    else
                    {
                        mt.customerId = CustomerID;
                        mt.MailTo = email;
                        mt.Name = email;
                        mt.countReceivedMail = int.Parse(rowEmail["countReceivedMail"].ToString()); ;
                    }
                    listEmail.Add(mt);
                }//Kết thúc foreach

            }
        }
        #endregion
        else
        {
            #region Gửi cho người thuộc nhóm mail
            if (sendtype == 1)
            {
                //Gửi cho những người thuộc nhóm mail 
                table = dtGroupBUS.GetCustomerByGroupID(GroupID);
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow rowEmail in table.Rows)
                    {
                        //Thông tin khách hàng
                        MailToDTO mt = new MailToDTO();
                        int CustomerID = int.Parse(rowEmail["Id"].ToString());
                        string name = rowEmail["Name"].ToString();
                        string email = rowEmail["Email"].ToString();

                        if (name != "" || name != "Không có")
                        {
                            mt.customerId = CustomerID;
                            mt.Name = name;
                            mt.MailTo = email;
                            mt.countReceivedMail = int.Parse(rowEmail["countReceivedMail"].ToString());
                        }
                        else
                        {
                            mt.customerId = CustomerID;
                            mt.MailTo = email;
                            mt.Name = name;
                            mt.countReceivedMail = int.Parse(rowEmail["countReceivedMail"].ToString()); ;
                        }
                        listEmail.Add(mt);


                    }//Kết thúc foreach
                }

            }
            #endregion
            else
            #region Gửi cho người thuộc nhóm mua sản phẩm (Chăm sóc khách hàng)
            {
                //Gửi cho những người thuộc nhóm mua theo loại sản phẩm
                table = countBUS.GetByCategoryID(GroupID);
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow rowEmail in table.Rows)
                    {
                        //Thông tin khách hàng
                        MailToDTO mt = new MailToDTO();
                        int CustomerID = int.Parse(rowEmail["CustomerID"].ToString());
                        DataTable customer = ctBUS.GetByID(CustomerID, true);
                        if (customer.Rows.Count > 0)
                        {
                            string name = customer.Rows[0]["Name"].ToString();
                            if (name != "" || name != "Không có")
                            {
                                mt.customerId = CustomerID;
                                mt.Name = name;
                                mt.MailTo = customer.Rows[0]["Email"].ToString();
                                mt.countReceivedMail = int.Parse(rowEmail["countReceivedMail"].ToString());
                            }
                            else
                            {
                                mt.customerId = CustomerID;
                                mt.MailTo = customer.Rows[0]["Email"].ToString();
                                mt.Name = customer.Rows[0]["Email"].ToString();
                                mt.countReceivedMail = int.Parse(rowEmail["countReceivedMail"].ToString()); ;
                            }

                        }
                        listEmail.Add(mt);
                    }//Kết thúc foreach
                }
            }
            #endregion
        }
        // Trả về danh sách email cần gửi
        return listEmail;
    }

    public IList<SendMailDTO> convetToSendMailDTO(DataTable table)
    {
        List<SendMailDTO> listEmail = new List<SendMailDTO>();
        if (table.Rows.Count > 0)
        {
            foreach (DataRow row in table.Rows)
            {
                //Thông tin nội dung
                SendMailDTO smDto = new SendMailDTO();
                smDto.hostName = row["Server"].ToString();
                smDto.mailFrom = row["mailFrom"].ToString();
                smDto.mailTo = row["mailTo"].ToString();
                smDto.userSmtp = row["username"].ToString();
                smDto.passSmtp = row["Password"].ToString();
                smDto.port = int.Parse(row["Port"].ToString());
                smDto.senderName = row["sender"].ToString();
                smDto.SSL = bool.Parse(row["isSSL"].ToString());
                smDto.countReceivedMail = int.Parse(row["countReceivedMail"].ToString());
                smDto.eventId = int.Parse(row["EventId"].ToString());
                smDto.lastReceivedMail = row["LastReceivedMail"].ToString();
                listEmail.Add(smDto);
            }
        }
        return listEmail;
    }
    public List<SendMailDTO> convetToSendMail(DataTable table)
    {
        List<SendMailDTO> listEmail = new List<SendMailDTO>();
        if (table.Rows.Count > 0)
        {
            foreach (DataRow row in table.Rows)
            {
                //Thông tin nội dung
                SendMailDTO smDto = new SendMailDTO();
                smDto.customerId = int.Parse(row["CustomerID"].ToString());
                smDto.groupId = int.Parse(row["groupId"].ToString());
                smDto.hostName = row["Server"].ToString();
                smDto.mailFrom = row["mailFrom"].ToString();
                smDto.mailTo = row["mailTo"].ToString();
                smDto.userSmtp = row["username"].ToString();
                smDto.passSmtp = row["Password"].ToString();
                smDto.port = int.Parse(row["Port"].ToString());
                smDto.senderName = row["sender"].ToString();
                smDto.recieveName = row["name"].ToString();
                smDto.SSL = bool.Parse(row["isSSL"].ToString());
                smDto.countReceivedMail = int.Parse(row["countReceivedMail"].ToString());
                smDto.eventId = int.Parse(row["EventId"].ToString());
                smDto.lastReceivedMail = row["LastReceivedMail"] + "";
                listEmail.Add(smDto);
            }
        }
        return listEmail;
    }
}
