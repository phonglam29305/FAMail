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
/// Summary description for displayingfunction
/// </summary>
public class displayingfunction
{
	public displayingfunction()
	{
        //string strConnect = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        //Email.ConnectionData._ConnectionString = strConnect;
        //Email.ConnectionData.AddNewConnection();
	}
    public DataTable GetAllfunction()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblFunction",
            ConnectionData._MyConnection);
        DataTable table = new DataTable();
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public DataTable GetAllpakeg()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblPackage",
            ConnectionData._MyConnection);
 
        DataTable table = new DataTable();
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    internal DataTable GetbyPackage(int packageId)
    {
        string sql = "SELECT f.*, case when p.functionid is not null then 1 else 0 end selected FROM tblFunction f left join tblPackageFunction p on f.functionid = p.functionid and packageid= @packageid";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@packageid", SqlDbType.Int).Value = packageId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
}