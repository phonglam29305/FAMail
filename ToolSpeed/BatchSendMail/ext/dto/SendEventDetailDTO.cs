using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for SendRegisterDetailDTO
/// </summary>
public class SendEventDetailDTO
{
    public SendEventDetailDTO()
	{
	}

    public int ContentSendEventDetailID { get; set; }
    public int ContentSendEventID { get; set; }
    public string Email { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DayEnd { get; set; }
    public int HoursEnd { get; set; }
    public int MinuteEnd { get; set; }
    public int SecondEnd { get; set; }
    public bool Status { get; set; }
    public string ErrorType { get; set; }
    public string MailSend { get; set; }
    public bool isOpenMail { get; set; }
    public DateTime DateOpen { get; set; }
    public bool isNotRecive { get; set; }
    public int countNumberLinkClick { get; set; }
    public string CustomerName { get; set; }
}
