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
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Summary description for EmailSend
/// </summary>
public class EmailSend
{
    SendRegisterDetailBUS srdBUS = null;
    SendContentBUS scBUS = null;
    MailConfigBUS mcBUS = null;
	public EmailSend()
	{
        srdBUS = new SendRegisterDetailBUS();
        scBUS = new SendContentBUS();
        mcBUS= new MailConfigBUS();
	}
    public  IList<EmailDTO> GetMailToSend(int SendRegisterID,int SendContentID, int ConfigID)
    {
        List<EmailDTO> listEmail = new List<EmailDTO>();
        EmailDTO eDTO = new EmailDTO();
        string Subject="";
        string Body="";
        string EmailFrom="";
        string HostName="";
        string UserNameSMTP="";
        string PasswordSMTP="";
        int Port=0;
        string NameSender="";
        bool SSL=false;
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
        DataTable table = srdBUS.GetByStatus(false,SendRegisterID);
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
                eBody += String.Format("<IMG height=1 src=\"http://EMAILMARKETING.1ONLINEBUSINESSSYSTEM.COM/emailtrack.aspx?emailsentID={0}\" width=1>", rowEmail["SendRegisterDetailId"]);
                eDTO.Subject = eSubject;
                eDTO.Content = eBody;
                eDTO.SendID = int.Parse(rowEmail["SendRegisterDetailId"].ToString());
                listEmail.Add(eDTO);
            }
        }
       
        return listEmail;
    }
}
