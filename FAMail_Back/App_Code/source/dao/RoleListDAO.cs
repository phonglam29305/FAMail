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
using System.Data.SqlClient;
using Email;

/// <summary>
/// Summary description for RoleListDAO
/// </summary>
public class RoleListDAO
{
    public RoleListDAO()
	{

	}
    public void tblRoleList_insert(RoleListDTO dt)
    {
        string sql = "INSERT INTO tblRoleList(roleId, roleName) " +
                     "VALUES(@roleId, @roleName)";
        SqlCommand   cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@roleId", SqlDbType.Int).Value = dt.roleId;
        cmd.Parameters.Add("@roleName", SqlDbType.Int).Value = dt.roleName;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public void tblRoleList_Delete(int roleId)
    {
        string sql = "DELETE FROM tblRoleList WHERE roleId = @roleId ";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@roleId", SqlDbType.Int).Value = roleId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetAll()
    {
        string sql = "SELECT * FROM tblRoleList WHERE roleId > 0 Order By RoleId DESC";
        SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public DataTable GetByRoleId(int roleId)
    {
        string sql = "SELECT * FROM tblRoleList WHERE roleId = @roleId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@roleId", SqlDbType.Int).Value = roleId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
    
}
