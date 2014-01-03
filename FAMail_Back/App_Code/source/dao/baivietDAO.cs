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
/// Summary description for baivietDAO
/// </summary>
public class baivietDAO
{
	public baivietDAO()
	{		
	}
    public DataTable Getallconfig()
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM V_baiviet",
             ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;       
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
    public DataTable Getbykey(string key)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM V_baiviet WHERE [key] = @key",
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@key", SqlDbType.NVarChar).Value =key;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
    
}