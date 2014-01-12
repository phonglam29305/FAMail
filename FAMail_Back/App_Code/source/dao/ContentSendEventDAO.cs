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
/// Summary description for ContentSendEvent
/// </summary>
public class ContentSendEventDAO
{
    public ContentSendEventDAO()
	{
	}
    public void tblContentSendEvent_insert(ContentSendEventDTO dt)
    {
        string sql = "INSERT INTO tblContentSendEvent(EventId, ContentId, HourSend, subject, body) " +
                     "VALUES(@EventId, @ContentId, @HourSend, @subject, @body)";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@EventId", SqlDbType.Int).Value = dt.EventId;
        cmd.Parameters.Add("@ContentId", SqlDbType.NVarChar).Value = dt.ContentId;
        cmd.Parameters.Add("@HourSend", SqlDbType.NVarChar).Value = dt.HourSend;
        cmd.Parameters.Add("@subject", SqlDbType.NVarChar).Value = dt.Subject;
        cmd.Parameters.Add("@body", SqlDbType.NVarChar).Value = dt.Body;       
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public int tblContentSendEvent_Update(ContentSendEventDTO dt)
    {
        string sql = "UPDATE tblContentSendEvent SET " +
                    "EventId = @EventId, " +
                    "ContentId = @ContentId, " +
                    "HourSend = @HourSend, " +
                    "subject = @subject, " +
                    "body = @body " +
                    " WHERE Id = @Id";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = dt.Id;
        cmd.Parameters.Add("@EventId", SqlDbType.Int).Value = dt.EventId;
        cmd.Parameters.Add("@ContentId", SqlDbType.NVarChar).Value = dt.ContentId;
        cmd.Parameters.Add("@HourSend", SqlDbType.NVarChar).Value = dt.HourSend;
        cmd.Parameters.Add("@subject", SqlDbType.NVarChar).Value = dt.Subject;
        cmd.Parameters.Add("@body", SqlDbType.NVarChar).Value = dt.Body;
        int rs = cmd.ExecuteNonQuery();
        cmd.Dispose();
        return rs;
    }
    public void tblContentSendEvent_Delete(int id)
    {
        SqlCommand cmd = new SqlCommand("DELETE FROM tblContentSendEvent WHERE Id = @Id", 
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetAll()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblContentSendEvent", 
            ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public DataTable GetById(int id)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblContentSendEvent WHERE Id = @Id", 
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
    public DataTable GetByEventId(int eventId)
    {
        SqlCommand cmd = new SqlCommand("SP_Event_ReportById", 
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EventId", SqlDbType.Int).Value = eventId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
}
