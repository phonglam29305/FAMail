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
/// Summary description for DetailSubGroupDTO
/// </summary>
public class DetailGroupDTO
{
	public DetailGroupDTO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int GroupID { get; set; }
    public int CustomerID { get; set; }
    public int CountReceivedMail { get; set; }
    public DateTime LastReceivedMail { get; set; }
}
