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
/// Summary description for SendContentDAO
/// </summary>
public class SendContentDAO
{
	public SendContentDAO()
	{

	}
    public int tblSendContent_insert(SendContentDTO dt)
    {
        string sql = "INSERT INTO tblSendContent(CreateDate, Subject, Body, UserId) " +
                     "VALUES(@CreateDate, @Subject, @Body, @UserId)SELECT SCOPE_IDENTITY()";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = dt.CreateDate;
        cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = dt.Subject;
        cmd.Parameters.Add("@Body", SqlDbType.NVarChar).Value = dt.Body;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = dt.userId;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        var contentID = cmd.ExecuteScalar();

        cmd.Dispose();
        return int.Parse(contentID.ToString());
    }
    public void tblSendContent_Update(SendContentDTO dt)
    {
        string sql = "UPDATE tblSendContent SET "+
	                "CreateDate = @CreateDate, "+
	                "Subject = @Subject, "+
                    "UserId = @UserId, " +
	                "Body = @Body	WHERE Id = @Id";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = dt.Id;
        cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = dt.CreateDate;
        cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = dt.Subject;
        cmd.Parameters.Add("@Body", SqlDbType.NVarChar).Value = dt.Body;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = dt.userId;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblSendContent_Delete(int Id)
    {
        SqlCommand cmd = new SqlCommand("DELETE FROM tblSendContent WHERE Id = @Id", 
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetAll()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT id, createdate, subject, userid FROM tblSendContent", 
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
    public DataTable GetByID(int Id)
    {
        SqlCommand cmd = new SqlCommand("SELECT id, createdate, subject, userid FROM tblSendContent WHERE Id = @Id", 
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
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
    public DataTable GetAll(int userId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblSendContent WHERE UserId = @UserId", 
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
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
