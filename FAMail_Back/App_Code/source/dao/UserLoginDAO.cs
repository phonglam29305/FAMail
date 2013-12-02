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
using System.Security.Cryptography;
/// <summary>
/// Summary description for UserLoginDAO
/// </summary>
public class UserLoginDAO
{
    public UserLoginDAO()
	{

	}
    public void tblUserLogin_insert(UserLoginDTO dt)
    {
        string sql = "INSERT INTO tblUserLogin(Username, Password, DepartmentId) " +
                     "VALUES(@Username, @Password, @DepartmentId)";
        SqlCommand   cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = dt.Username;
        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = dt.Password;
        cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = dt.DepartmentId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblUserLogin_Update(UserLoginDTO dt)
    {
        string sql = "UPDATE tblUserLogin SET " +
                "Password = @Password, " +
                "DepartmentId = @DepartmentId " +
                " WHERE UserId = @UserId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = dt.UserId;
        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = dt.Password;
        cmd.Parameters.Add("@DepartmentId", SqlDbType.NVarChar).Value = dt.DepartmentId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblUserLogin_Update(int userId, int hasSendMail)
    {
        string sql = "UPDATE tblUserLogin SET " +
                " hasSendMail = @hasSendMail " +
                " WHERE UserId = @UserId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
        cmd.Parameters.Add("@hasSendMail", SqlDbType.Int).Value = hasSendMail;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public void tblUserLogin_UpdateByDepartmentId(int departmentId, int hasSendMail)
    {
        string sql = "UPDATE tblUserLogin SET " +
                " hasSendMail = @hasSendMail " +
                " WHERE departmentId = @departmentId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@departmentId", SqlDbType.Int).Value = departmentId;
        cmd.Parameters.Add("@hasSendMail", SqlDbType.Int).Value = hasSendMail;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblUserLogin_Delete(int userId)
    {
        string sql = "DELETE FROM tblUserLogin WHERE UserId = @UserId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetAll()
    {
        string sql = "SELECT * FROM tblUserLogin";
        SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public DataTable GetByUserId(int UserId)
    {
        string sql = "SELECT * FROM tblUserLogin WHERE UserId = @UserId";
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
    public DataTable GetByUsername(string username)
    {
        string sql = "SELECT * FROM tblUserLogin WHERE Username = @Username";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
    public DataTable GetByUsernameAndPass(string username,string password)
    {
        string sql = "SELECT * FROM tblUserLogin WHERE Username = @Username AND Password = @Password";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
        cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetByDepartmentId(int departmentId)
    {
        string sql = "SELECT * FROM tblUserLogin WHERE DepartmentId = @DepartmentId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = departmentId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

}
