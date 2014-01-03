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
using Email;
using System.Data.SqlClient;

/// <summary>
/// Summary description for baivietBUS
/// </summary>
public class baivietBUS
{
	public baivietBUS()
	{		
	}
    public DataTable getallconfig()
    {
        baivietDAO bv = new baivietDAO();
        return bv.Getallconfig();
    }
    public DataTable getbykey(string key)
    {
        baivietDAO bv = new baivietDAO();
        return bv.Getbykey(key);
    }
}