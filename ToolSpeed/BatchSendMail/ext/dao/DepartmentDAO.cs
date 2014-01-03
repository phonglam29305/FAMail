using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using Email;

/// <summary>
/// Summary description for DepartmentDAO
/// </summary>
public class DepartmentDAO
{
	public DepartmentDAO()
	{

	}
    public void tblDepartment_insert(DepartmentDTO dt)
    {
        string sql = "INSERT INTO tblDepartment(Name, Description, Role) "+
	                 "VALUES(@Name, @Description, @Role)";
        SqlCommand   cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dt.Name;
        cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = dt.Description;
        cmd.Parameters.Add("@Role", SqlDbType.Int).Value = dt.Role;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblDepartment_Update(DepartmentDTO dt)
    {
        string sql = "UPDATE tblDepartment SET "+
	            "Name = @Name, " +
	            "Description = @Description, "+
                "Role = @Role WHERE ID = @ID";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = dt.ID;
        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dt.Name;
        cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = dt.Description;
        cmd.Parameters.Add("@Role", SqlDbType.Int).Value = dt.Role;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblDepartment_Delete(int ID)
    {
        string sql = "DELETE FROM tblDepartment WHERE ID = @ID";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetAll()
    {
        string sql = "SELECT * FROM tblDepartment";
        SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public DataTable GetByID(int ID)
    {
        string sql = "SELECT * FROM tblDepartment WHERE ID = @ID";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

}
