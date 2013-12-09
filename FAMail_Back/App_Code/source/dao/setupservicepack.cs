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
/// Summary description for setupservicepack
/// </summary>
public class setupservicepack
{
	public setupservicepack()
	{		
	}
    public DataTable GetAllfunction()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblFunction",
            ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
}