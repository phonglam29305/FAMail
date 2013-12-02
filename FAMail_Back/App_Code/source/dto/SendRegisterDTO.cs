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
/// Summary description for SendRegisterDTO
/// </summary>
public class SendRegisterDTO
{
    public int Id { get; set; }
    public string AccountId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int SendContentId { get; set; }
    public int SendType { get; set; }
    public int Status { get; set; }
    public int ErrorType { get; set; }
    public int MailConfigID { get; set; }
    public int GroupTo { get; set; }
	public SendRegisterDTO()
	{
		
	}
}
