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
/// Summary description for dangkyDAO
/// </summary>
public class dangkyDAO 
{

    public DataTable GetByUserId( int id)
    {
        SqlCommand cmd = new SqlCommand("Package_GetALL ",
           ConnectionData._MyConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

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
    public DataTable GetAllPackagetime()
    {
        SqlCommand cmd = new SqlCommand("select * from tblPackageTime", ConnectionData._MyConnection);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;

    }
    public void Insert_Client(dangkydto dt)
    {
        string sql = "insert into tblClient (clientName,address,email,phone)" +
            "values(@clientName,@address,@email,@phone)";
        SqlCommand cmd = new SqlCommand(sql,ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@clientName", SqlDbType.NVarChar).Value = dt.clientName;
        cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = dt.address;
        cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = dt.email;
        cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = dt.phone;    
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

}