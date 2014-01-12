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
    public string Subject { get; set; }
    public string Body { get; set; }
}
