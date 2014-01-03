using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using Email;

/// <summary>
/// Summary description for RoleDetailDAO
/// </summary>
public class RoleDetailDAO
{
	public RoleDetailDAO()
	{

	}
    public void tblRoleDetail_insert(RoleDetailDTO dt)
    {
        string sql = "INSERT INTO tblRoleDetail(roleId, departmentId) " +
                     "VALUES(@roleId, @departmentId)";
        SqlCommand   cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@roleId", SqlDbType.Int).Value = dt.roleId;
        cmd.Parameters.Add("@departmentId", SqlDbType.Int).Value = dt.departmentId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public void tblRoleDetail_Delete(int roleId, int departmentId)
    {
        string sql = "DELETE FROM tblRoleDetail WHERE roleId = @roleId AND departmentId = @departmentId ";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@roleId", SqlDbType.Int).Value = roleId;
        cmd.Parameters.Add("@departmentId", SqlDbType.Int).Value = departmentId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetAll()
    {
        string sql = "SELECT * FROM tblRoleDetail";
        SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public DataTable GetByDepartmentId(int departmentId)
    {
        string sql = "SELECT * FROM tblRoleDetail WHERE departmentId = @departmentId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@departmentId", SqlDbType.Int).Value = departmentId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
    public DataTable GetByDepartmentIdAndRole(int role, int departmentId)
    {
        string sql = "SELECT * FROM tblRoleDetail WHERE roleId = @roleId AND departmentId = @departmentId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@roleId", SqlDbType.Int).Value = role;
        cmd.Parameters.Add("@departmentId", SqlDbType.Int).Value = departmentId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

}
