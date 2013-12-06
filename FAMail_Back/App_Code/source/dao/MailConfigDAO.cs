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
/// Summary description for MailConfigDAO
/// </summary>
public class MailConfigDAO
{

	public MailConfigDAO()
	{
	
	}
    SqlCommand cmd;
    public void tblMailConfig_insert(MailConfigDTO dt)
    {
        string sql = "INSERT INTO tblMailConfig(Server, Port, Email, Password, Name, DepartmentID, parentId, levelId, username, isSSL, UserId) " +
                       "VALUES(@Server, @Port, @Email, @Password, @Name, @DepartmentID, @parentId, @levelId, @username, @isSSL, @UserId)";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Server", SqlDbType.VarChar).Value = dt.Server;
        cmd.Parameters.Add("@Port", SqlDbType.Int).Value = dt.Port;
        cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = dt.Email;
        cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = dt.Password;
        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dt.Name;
        cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = dt.DepartmentID;
        cmd.Parameters.Add("@parentId", SqlDbType.Int).Value = dt.parentId;
        cmd.Parameters.Add("@levelId", SqlDbType.Int).Value = dt.levelId;
        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = dt.username;
        cmd.Parameters.Add("@isSSL", SqlDbType.Bit).Value = dt.isSSL;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = dt.userId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblMailConfig_Update(MailConfigDTO dt)
    {
        string sql = "UPDATE tblMailConfig SET "+
	                "Server = @Server, "+
	                "Port = @Port, "+
	                "Email = @Email, "+
                    "Name = @Name, " +
                    "DepartmentID = @DepartmentID, " +
                    "parentId = @parentId, " +
                    "levelId = @levelId, " +
                    "username = @username, " +
                    "isSSL = @isSSL, " +
	                "Password = @Password, "+
                    "UserId = @UserId " +
                    " WHERE Id = @Id";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = dt.Id;
        cmd.Parameters.Add("@Server", SqlDbType.VarChar).Value = dt.Server;
        cmd.Parameters.Add("@Port", SqlDbType.Int).Value = dt.Port;
        cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = dt.Email;
        cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = dt.Password;
        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dt.Name;
        cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = dt.DepartmentID;
        cmd.Parameters.Add("@parentId", SqlDbType.Int).Value = dt.parentId;
        cmd.Parameters.Add("@levelId", SqlDbType.Int).Value = dt.levelId;
        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = dt.username;
        cmd.Parameters.Add("@isSSL", SqlDbType.Bit).Value = dt.isSSL;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = dt.userId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblMailConfig_Delete(int Id)
    {
        cmd = new SqlCommand("DELETE FROM tblMailConfig WHERE Id = @Id", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetAll()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblMailConfig", 
            ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }

    public DataTable GetByID(int Id)
    {
        cmd = new SqlCommand("SELECT * FROM tblMailConfig WHERE Id = @Id", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetByUserId(int UserId)
    {
        cmd = new SqlCommand("SELECT * FROM tblMailConfig WHERE UserId = @UserId", 
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetByEmailAndPass(string email,string pass)
    {
        cmd = new SqlCommand("SELECT * FROM tblMailConfig WHERE Email = @Email AND Password = @Password", 
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
        cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = pass;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetAll(int DepartmentID)
    {
        cmd = new SqlCommand("SELECT * FROM tblMailConfig WHERE DepartmentID = @DepartmentID", 
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = DepartmentID;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
}
