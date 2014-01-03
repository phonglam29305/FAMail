using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for EmailDTO
/// </summary>
public class EmailDTO
{
	public EmailDTO()
	{
	
	}
    // Thuộc tính cấu hình mail
    public string HostName { get; set; }
    public int Port { get; set; }
    public bool SSL { get; set; }
    public string UsernameSMTP { get; set; }
    public string PasswordSMTP { get; set; }
    // Thuộc tính gửi mail
    public string MailFrom { get; set; }
    public string MailTo { get; set; }
    public string NameSender { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    // Thuộc tính theo dõi Email
    public int SendID { get; set; }
}
