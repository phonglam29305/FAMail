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
/// Summary description for EventDAO
/// </summary>
public class EventDAO
{
    public EventDAO()
    {
    }
    public int tblEvent_insert(EventDTO dt)
    {
        string sql = "INSERT INTO tblEvent(Subject, Voucher, Subscribe, Body, ConfigId, StartDate, EndDate, ResponeUrl, ConfirmContent, ConfirmFlag, UserId, GroupId) " +
                     "VALUES(@Subject, @Voucher, @Subscribe, @Body, @ConfigId, @StartDate, @EndDate, @ResponeUrl, @ConfirmContent, @ConfirmFlag, @UserId, @GroupId) SELECT SCOPE_IDENTITY()";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = dt.Subject;
        cmd.Parameters.Add("@Voucher", SqlDbType.VarChar).Value = dt.Voucher;
        cmd.Parameters.Add("@Subscribe", SqlDbType.VarChar).Value = dt.Subscribe;
        cmd.Parameters.Add("@Body", SqlDbType.NVarChar).Value = dt.Body;
        cmd.Parameters.Add("@ConfigId", SqlDbType.Int).Value = dt.ConfigId;
        cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = dt.StartDate;
        cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dt.EndDate;
        cmd.Parameters.Add("@ResponeUrl", SqlDbType.VarChar).Value = dt.ResponeUrl;
        cmd.Parameters.Add("@ConfirmContent", SqlDbType.NVarChar).Value = dt.ConfirmContent;
        cmd.Parameters.Add("@ConfirmFlag", SqlDbType.Char).Value = dt.ConfirmFlag;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = dt.UserId;
        cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = dt.GroupId;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        var eventId = cmd.ExecuteScalar();

        cmd.Dispose();
        return int.Parse(eventId.ToString());
    }
    public void tblEvent_Update(EventDTO dt)
    {
        string sql = "UPDATE tblEvent SET " +
                    "Subject = @Subject, " +
                    "Voucher = @Voucher, " +
                    "Subscribe = @Subscribe, " +
                    "Body = @Body," +
                    "ConfigId = @ConfigId, " +
                    "StartDate = @StartDate, " +
                    "EndDate = @EndDate, " +
                    "ResponeUrl = @ResponeUrl, " +
                    "ConfirmContent = @ConfirmContent, " +
                    "ConfirmFlag = @ConfirmFlag, " +
                    "UserId = @UserId, " +
                    "GroupId = @GroupId " +
                    "WHERE EventId = @EventId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@EventId", SqlDbType.Int).Value = dt.EventId;
        cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = dt.Subject;
        cmd.Parameters.Add("@Voucher", SqlDbType.VarChar).Value = dt.Voucher;
        cmd.Parameters.Add("@Subscribe", SqlDbType.VarChar).Value = dt.Subscribe;
        cmd.Parameters.Add("@Body", SqlDbType.NVarChar).Value = dt.Body;
        cmd.Parameters.Add("@ConfigId", SqlDbType.Int).Value = dt.ConfigId;
        cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = dt.StartDate;
        cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dt.EndDate;
        cmd.Parameters.Add("@ResponeUrl", SqlDbType.VarChar).Value = dt.ResponeUrl;
        cmd.Parameters.Add("@ConfirmContent", SqlDbType.NVarChar).Value = dt.ConfirmContent;
        cmd.Parameters.Add("@ConfirmFlag", SqlDbType.Char).Value = dt.ConfirmFlag;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = dt.UserId;
        cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = dt.GroupId;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();

        cmd.Dispose();
    }
    public void tblEvent_Delete(int EventId)
    {
        SqlCommand cmd = new SqlCommand("DELETE FROM tblEvent WHERE EventId = @EventId",
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@EventId", SqlDbType.Int).Value = EventId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public DataTable GetAllListEvent(string subject, int userId, int groupId)
    {

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "pro_get_all_listevent";
        cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = subject;
        cmd.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
        cmd.Parameters.Add("@groupId", SqlDbType.Int).Value = groupId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        cmd.Connection = ConnectionData._MyConnection;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;

    }

    public DataTable GetClientId(int UserId)
    {
        string sql = "SELECT * FROM tblClient WHERE UserId = @UserId";
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

    public DataTable GetAllListEventDepart2(string subject, int Userid, int groupId)
    {

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "pro_get_all_listevent_Depart2";
        cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = subject;
        cmd.Parameters.Add("@Userid", SqlDbType.Int).Value = Userid;
        cmd.Parameters.Add("@groupId", SqlDbType.Int).Value = groupId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        cmd.Connection = ConnectionData._MyConnection;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;

    }


    public DataTable GetAll()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblEvent",
            ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public DataTable GetByID(int EventId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblEvent WHERE EventId = @EventId",
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@EventId", SqlDbType.Int).Value = EventId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetAssignTo(int groupId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblMailGroup WHERE Id = @groupId",
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@groupId", SqlDbType.Int).Value = groupId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
    public DataTable GetByUserId(int userId)
    {
        SqlCommand cmd = new SqlCommand("SP_GetEvent_ByUserId",
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }




    internal void tblEventCustomer_Insert(int customerId, string eventId)
    {
        string sql = @"if not exists(select * from tblEventCustomer where eventid = @eventid and customerid = @customerid) begin
                    INSERT INTO tblEventCustomer(eventid, customerid, countReceivedMail) values(@eventid, @customerid, 0)
                    END";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@EventId", SqlDbType.Int).Value = eventId;
        cmd.Parameters.Add("@customerid", SqlDbType.Int).Value = customerId;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();

        cmd.Dispose();
    }

    internal void tblEventCustomer_Insert(EventDTO eventDto)
    {
        string sql = @"insert into tblEventCustomer(customerid, eventid, countReceivedMail) select customerid, @eventid, 0 from tblDetailGroup where groupid=@groupid";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@EventId", SqlDbType.Int).Value = eventDto.EventId;
        cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = eventDto.GroupId;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();

        cmd.Dispose();
    }
}
