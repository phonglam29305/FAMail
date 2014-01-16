using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
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
        try
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

            if (ConnectionData._MyConnection.State == ConnectionState.Closed)
            {
                ConnectionData._MyConnection.Open();
            }
            cmd.ExecuteNonQuery();
            return 1;
        }
        catch (Exception)
        {

            return 1;
        }
    }

    public int tblSendEventDetail_insert(SendEventDetailDTO dt)
    {
        try
        {
            string sql = "INSERT INTO tblContentSendEventDetail(ContentSendEventID, Email, StartDate, EndDate, DayEnd, HoursEnd, MinuteEnd, SecondEnd, Status, ErrorType, MailSend,CustomerName) " +
                     "VALUES(@ContentSendEventID, @Email, @StartDate, @EndDate, @DayEnd, @HoursEnd, @MinuteEnd, @SecondEnd, @Status, @ErrorType, @MailSend, @CustomerName) SELECT SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ContentSendEventID", SqlDbType.Int).Value = dt.ContentSendEventID;
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

            if (ConnectionData._MyConnection.State == ConnectionState.Closed)
            {
                ConnectionData._MyConnection.Open();
            }
            cmd.ExecuteNonQuery();

            return 1;
        }
        catch (Exception)
        {

            return 1;
        }
    }
    public void logsErrorEmail(string email, string Exception)
    {
        try
        {
            string sql = "SP_LogsErrorEmail";
            SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
            cmd.Parameters.Add("@Exception", SqlDbType.NVarChar).Value = Exception;

            if (ConnectionData._MyConnection.State == ConnectionState.Closed)
            {
                ConnectionData._MyConnection.Open();
            }
            cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {
        }
    }
    public void tblSendRegisterDetail_Update(int SendRegisterDetailId, DateTime StartDate, DateTime EndDate, bool Status)
    {
        string sql = "UPDATE tblSendRegisterDetail SET " +
                        "StartDate = @StartDate, " +
                        "EndDate = @EndDate, " +
                        "Status = @Status " +
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


}
