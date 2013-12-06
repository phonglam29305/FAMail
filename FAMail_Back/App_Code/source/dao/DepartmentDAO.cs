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
/// Summary description for DepartmentDAO
/// </summary>
public class DepartmentDAO
{
	public DepartmentDAO()
	{

	}
    public void tblDepartment_insert(DepartmentDTO dt)
    {
        string sql = "INSERT INTO tblDepartment(Name, Description, UserId) "+
                     "VALUES(@Name, @Description, @UserId)";
        SqlCommand   cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dt.Name;
        cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = dt.Description;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = dt.UserId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblDepartment_Update(DepartmentDTO dt)
    {
        string sql = "UPDATE tblDepartment SET "+
	            "Name = @Name, " +
	            "Description = @Description, "+
                "UserId = @UserId WHERE ID = @ID";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = dt.ID;
        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dt.Name;
        cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = dt.Description;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = dt.UserId;
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
    public DataTable GetByUserID(int UserId)
    {
        string sql = "SELECT * FROM tblDepartment WHERE UserId = @UserId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

}
