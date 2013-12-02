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
/// Summary description for CategoryDTO
/// </summary>
public class CategoryDAO
{
	public CategoryDAO()
	{
	
	}
    public DataTable GetByID(int ID)
	{
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblCategory WHERE ID = @ID", ConnectionData._MyConnection);
		cmd.CommandType = CommandType.Text;
		cmd.Parameters.Add("@ID",SqlDbType.Int ).Value=ID;
		SqlDataAdapter adapter=new SqlDataAdapter(cmd);
		DataTable table=new DataTable();
		adapter.Fill(table);
		cmd.Dispose();
		adapter.Dispose();
		return table;
	}
}
