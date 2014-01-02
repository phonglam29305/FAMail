using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Support : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void image_Click(object sender, ImageClickEventArgs e)
    {
        SmtpClient SmtpServer = new SmtpClient();
        SmtpServer.Credentials = new System.Net.NetworkCredential("AKIAIGXHHO72FHXGCPFQ", "Ara8HV/kcfjNU+rqrTpJBAAjs/OsD1xEykLsuguqpe1Z");
        SmtpServer.Port = 25;
        SmtpServer.Host = "email-smtp.us-east-1.amazonaws.com";
        SmtpServer.EnableSsl = true;
        MailMessage mail = new MailMessage();
        String[] addr = txtemail.Text.Split(' ');
        mail.From = new MailAddress("admin@fastautomaticmail.com",
        "Xác Nhận Từ Hệ Thống FA MAIL  ", System.Text.Encoding.UTF8);
        Byte i;
        for (i = 0; i < addr.Length; i++)
            mail.To.Add(addr[i]);
        mail.Subject = "Bộ phận hỗ trợ kỹ thuật";
        mail.Body += "<html>  <body><table class='auto-style1'> <tr><td>Chào</td></tr></table></body>  " + txtten.Text; mail.Body += "</html>";
        //mail.Body = "Chào "+txtten.Text+" Chúng tôi đã nhận được câu hỏi của bạn với nội dung sau "+txtconten.Text+"Chúng tôi sẽ trả lời trong vòng 12 giờ tới .Đây là Email tự động xin vui lòng đừng trả lời "+"bộ phận khách hàng online";       
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        mail.ReplyTo = new MailAddress(txtemail.Text);
        SmtpServer.Send(mail);
    }
}