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
/// Summary description for FunctionDTO
/// </summary>
public class FunctionDTO
{
	public FunctionDTO()
	{	
	}
    public int functionId { get; set; }
    public string functionName { get; set; }
    public string description { get; set; }
    public float cost { get; set; }
    public bool isDefault { get; set; }
}