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
/// Summary description for SubGroupDTO
/// </summary>
public class SubGroupDTO
{
	public SubGroupDTO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int IDSubGroup { get; set; }
    public int GroupID { get; set; }
    public int CustomerID { get; set; }
    public string GroupName { get; set; }

}
