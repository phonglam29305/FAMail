using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for tblContentSendEvent
/// </summary>
public class ContentSendEventDTO
{
    public ContentSendEventDTO()
	{}
    public int Id { get; set; }
    public int ContentId { get; set; }
    public int HourSend { get; set; }
    public int EventId { get; set; }
}
