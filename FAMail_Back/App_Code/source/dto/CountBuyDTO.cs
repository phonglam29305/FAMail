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
/// Summary description for CountBuyDTO
/// </summary>
public class CountBuyDTO
{
	public CountBuyDTO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int CustomerID { get; set; }
    public int CategoryID { get; set; }
    public int CountBuy { get; set; }

}
