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
public class PartSendDAO
{
    public PartSendDAO()
	{
	}
    public void tblPartSend_insert(PartSendDTO dt)
    {
        string sql = "INSERT INTO tblPartSend(UserId, GroupId, hasContentSend, settingFirst) " +
                     "VALUES(@UserId, @GroupId, @hasContentSend, @settingFirst)";
        SqlCommand   cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = dt.UserId;
        cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = dt.GroupId;
        cmd.Parameters.Add("@hasContentSend", SqlDbType.VarChar).Value = dt.hasContentSend;
        cmd.Parameters.Add("@settingFirst", SqlDbType.Bit).Value = dt.settingFirst;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblPartSend_Update(PartSendDTO dt)
    {
        string sql = "UPDATE tblPartSend SET " +
                "hasContentSend = @hasContentSend, " +
                "settingFirst = @settingFirst " +
                " WHERE UserId = @UserId AND GroupId = @GroupId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = dt.UserId;
        cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = dt.GroupId;
        cmd.Parameters.Add("@hasContentSend", SqlDbType.VarChar).Value = dt.hasContentSend;
        cmd.Parameters.Add("@settingFirst", SqlDbType.Bit).Value = dt.settingFirst;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblUserLogin_Delete(int userId, int groupId)
    {
        string sql = "DELETE FROM tblPartSend WHERE UserId = @UserId AND GroupId = @GroupId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
        cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = groupId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetAll()
    {
        string sql = "SELECT * FROM tblPartSend";
        SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public DataTable GetByUserIdAndGroupId(int UserId, int groupId)
    {
        string sql = "SELECT * FROM tblPartSend WHERE UserId = @UserId AND GroupId = @GroupId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
        cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = groupId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
   

}
