using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for EventDTO
/// </summary>
public class EventDTO
{
	
    public int EventId { get; set; }
    public string Subject { get; set; }
    public string Voucher { get; set; }
    public string Subscribe { get; set; }
    public string Body { get; set; }
    public int ConfigId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string ResponeUrl { get; set; }
    public string ConfirmContent { get; set; }
    public string ConfirmFlag { get; set; }
    public int UserId { get; set; } 
    public EventDTO()
    {
    }
    public EventDTO(string subject, string voucher, string subscribe, string body,
        int configId, DateTime startDate, DateTime endDate, string responeUrl, 
        string confirmContent,string confirmFlag)
    {
        this.Subject = subject;
        this.Voucher = voucher;
        this.Subscribe = subscribe;
        this.Body = body;
        this.ConfigId = configId;
        this.StartDate = startDate;
        this.EndDate = endDate;
        this.ResponeUrl = responeUrl;
        this.ConfirmContent = confirmContent;
        this.ConfirmFlag = confirmFlag;
    }

}
