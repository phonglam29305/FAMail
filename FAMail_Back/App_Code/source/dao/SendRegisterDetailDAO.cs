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
/// Summary description for SendRegisterDetailDAO
/// </summary>
public class SendRegisterDetailDAO
{
	public SendRegisterDetailDAO()
	{
    
	}
    public int tblSendRegisterDetail_insert(SendRegisterDetailDTO dt)
    {
        string sql = "INSERT INTO tblSendRegisterDetail(SendRegisterId, Email, StartDate, EndDate, DayEnd, HoursEnd, MinuteEnd, SecondEnd, Status, ErrorType, MailSend,CustomerName) " +
                     "VALUES(@SendRegisterId, @Email, @StartDate, @EndDate, @DayEnd, @HoursEnd, @MinuteEnd, @SecondEnd, @Status, @ErrorType, @MailSend, @CustomerName) SELECT SCOPE_IDENTITY()";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@SendRegisterId", SqlDbType.Int).Value = dt.SendRegisterId;
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = dt.Email;
        cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = dt.StartDate;
        cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dt.EndDate;
        cmd.Parameters.Add("@DayEnd", SqlDbType.Int).Value = dt.DayEnd;
        cmd.Parameters.Add("@HoursEnd", SqlDbType.Int).Value = dt.HoursEnd;
        cmd.Parameters.Add("@MinuteEnd", SqlDbType.Int).Value = dt.MinuteEnd;
        cmd.Parameters.Add("@SecondEnd", SqlDbType.Int).Value = dt.SecondEnd;
        cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = dt.Status;
        cmd.Parameters.Add("@ErrorType", SqlDbType.VarChar).Value = dt.ErrorType;
        cmd.Parameters.Add("@MailSend", SqlDbType.NVarChar).Value = dt.MailSend;
        cmd.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = dt.CustomerName;

        var sendID = cmd.ExecuteScalar();
        cmd.Dispose();
        return int.Parse(sendID.ToString());
    }
    public void tblSendRegisterDetail_Update(int SendRegisterDetailId, DateTime StartDate, DateTime EndDate, bool Status)
    {
        string sql = "UPDATE tblSendRegisterDetail SET "+
	                    "StartDate = @StartDate, "+
	                    "EndDate = @EndDate, "+
	                    "Status = @Status "+
                        "WHERE SendRegisterDetailId = @SendRegisterDetailId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@SendRegisterDetailId", SqlDbType.Int).Value = SendRegisterDetailId;
        cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
        cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
        cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = Status;

        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblSendRegisterDetail_UpdateOpenMail(int SendRegisterDetailId, bool isOpenMail, DateTime DateOpen)
    {
        string sql = "UPDATE tblSendRegisterDetail SET " +
                        "isOpenMail = @isOpenMail, " +
                        "DateOpen = @DateOpen " +
                        " WHERE SendRegisterDetailId = @SendRegisterDetailId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@SendRegisterDetailId", SqlDbType.Int).Value = SendRegisterDetailId;
        cmd.Parameters.Add("@isOpenMail", SqlDbType.Bit).Value = isOpenMail;
        cmd.Parameters.Add("@DateOpen", SqlDbType.DateTime).Value = DateOpen;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblSendRegisterDetail_Delete(int SendRegisterId)
    {
        SqlCommand cmd = new SqlCommand("DELETE FROM tblSendRegisterDetail WHERE SendRegisterId = @SendRegisterId", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@SendRegisterId", SqlDbType.Int).Value = SendRegisterId;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public void tblSendRegisterDetail_Delete(int SendRegisterId, string email)
    {
        SqlCommand cmd = new SqlCommand("DELETE FROM tblSendRegisterDetail WHERE SendRegisterId = @SendRegisterId AND Email =@Email", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@SendRegisterId", SqlDbType.Int).Value = SendRegisterId;
        cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public DataTable GetAll()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblSendRegisterDetail", ConnectionData._MyConnection);
        DataTable table = new DataTable();
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public DataTable GetByID(int SendRegisterId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblSendRegisterDetail WHERE SendRegisterId = @SendRegisterId", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@SendRegisterId", SqlDbType.Int).Value = SendRegisterId;
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

    public DataTable GetByStatus(bool status)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblSendRegisterDetail WHERE Status = @Status", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = status;
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
    public DataTable GetByStatus_User(bool status, int UserId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblSendRegisterDetail WHERE Status = @Status and sendregisterid in (select id from tblSendRegister where AccountId=@userid or AccountId in (select userid from tblSubClient where clientid = (select clientid from tblClient where userid=@userid)))", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = status;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
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
    public DataTable GetByStatus_SubUser(bool status, int UserId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblSendRegisterDetail WHERE Status = @Status and sendregisterid in (select id from tblSendRegister where userid=@userid)", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = status;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
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
    public DataTable GetByStatus(bool status, int SendRegisterId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblSendRegisterDetail WHERE Status = @Status and SendRegisterId=@SendRegisterId", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = status;
        cmd.Parameters.Add("@SendRegisterId", SqlDbType.Int).Value = SendRegisterId;
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

    public DataTable GetBySendIdAndLimit(int SendRegisterId, int limit)
    {
        SqlCommand cmd = new SqlCommand("SELECT TOP " + limit + 
            " SendRegisterId,Email,StartDate,EndDate,Status FROM tblSendRegisterDetail WHERE SendRegisterId = @SendRegisterId", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@SendRegisterId", SqlDbType.Int).Value = SendRegisterId;
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
    public DataTable GetBySendIdAndLimit(int SendRegisterId, int limit, string EmailSend)
    {
        string sql = "SELECT TOP " + limit + "SD.SendRegisterId,SD.Email,SD.StartDate,SD.EndDate,SD.Status from tblSendRegister AS S, tblSendRegisterDetail AS SD " +
        "where SD.SendRegisterId=@Id and SD.MailSend=@EmailSend Group By SD.SendRegisterId,SD.Email,SD.StartDate,SD.EndDate,SD.Status ";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = SendRegisterId;
        cmd.Parameters.Add("@EmailSend", SqlDbType.NVarChar).Value = EmailSend;
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
    public DataTable GetByStatus(bool status, string EmailSend)
    {
        string sql = "SELECT * FROM tblSendRegisterDetail WHERE Status = @Status and MailSend=@EmailSend";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = status;
        cmd.Parameters.Add("@EmailSend", SqlDbType.NVarChar).Value = EmailSend;
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
    public void tblSendRegisterDetail_UpdateOpenMail(int SendRegisterId, bool isOpenMail, DateTime DateOpen, string Email)
    {
        string sql = "UPDATE tblSendRegisterDetail SET " +
                        "isOpenMail = @isOpenMail, " +
                        "DateOpen = @DateOpen " +
                        " WHERE SendRegisterId = @SendRegisterId and Email=@Email";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@SendRegisterId", SqlDbType.Int).Value = SendRegisterId;
        cmd.Parameters.Add("@isOpenMail", SqlDbType.Bit).Value = isOpenMail;
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
        cmd.Parameters.Add("@DateOpen", SqlDbType.DateTime).Value = DateOpen;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetByOpenMail(int SendRegisterId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblSendRegisterDetail WHERE SendRegisterId = @SendRegisterId and isOpenMail= 'True'", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@SendRegisterId", SqlDbType.Int).Value = SendRegisterId;
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
    public void tblSendRegisterDetail_UpdateUnreceve(int SendRegisterId, bool isUnreceve, DateTime DateUnreceve, string Email)
    {
        string sql = "UPDATE tblSendRegisterDetail SET " +
                        "isNotRecive = @isUnreceve, " +
                        "DateStopRecive = @DateUnreceve " +
                        " WHERE SendRegisterId = @SendRegisterId and Email=@Email";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@SendRegisterId", SqlDbType.Int).Value = SendRegisterId;
        cmd.Parameters.Add("@isUnreceve", SqlDbType.Bit).Value = isUnreceve;
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
        cmd.Parameters.Add("@DateUnreceve", SqlDbType.DateTime).Value = DateUnreceve;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetByNotReceve(int SendRegisterId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblSendRegisterDetail WHERE SendRegisterId = @SendRegisterId and isNotRecive= 'True'", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@SendRegisterId", SqlDbType.Int).Value = SendRegisterId;
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
