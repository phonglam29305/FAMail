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
/// Summary description for SendContentDTO
/// </summary>
public class SendContentDTO
{
	public SendContentDTO()
	{
	}
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public int userId { get; set; }

}
