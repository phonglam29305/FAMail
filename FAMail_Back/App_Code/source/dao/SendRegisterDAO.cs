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
using System.Globalization;

/// <summary>
/// Summary description for SendRegisterDAO
/// </summary>
public class SendRegisterDAO
{
    
    public SendRegisterDAO()
	{
        
	}
    public void tblSendRegister_insert(SendRegisterDTO dt)
    {
        string sql = "INSERT INTO tblSendRegister(AccountId, StartDate, EndDate, SendContentId, SendType, Status, ErrorType, MailConfigID, GroupTo, subject, body) " +
                     "VALUES(@AccountId, @StartDate, @EndDate, @SendContentId, @SendType, @Status, @ErrorType, @MailConfigID, @GroupTo, @subject, @body)";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@AccountId", SqlDbType.VarChar).Value = dt.AccountId;
        cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = dt.StartDate;
        cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dt.EndDate;
        cmd.Parameters.Add("@SendContentId", SqlDbType.Int).Value = dt.SendContentId;
        cmd.Parameters.Add("@SendType", SqlDbType.Int).Value = dt.SendType;
        cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dt.Status;
        cmd.Parameters.Add("@ErrorType", SqlDbType.Int).Value = dt.ErrorType;
        cmd.Parameters.Add("@MailConfigID", SqlDbType.Int).Value = dt.MailConfigID;
        cmd.Parameters.Add("@GroupTo", SqlDbType.Int).Value = dt.GroupTo;
        cmd.Parameters.Add("@subject", SqlDbType.VarChar).Value = dt.Subject;
        cmd.Parameters.Add("@body", SqlDbType.VarChar).Value = dt.Body;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblSendRegister_Update(SendRegisterDTO dt)
    {
        string sql = "UPDATE tblSendRegister SET " +
                            "AccountId = @AccountId, " +
                            "StartDate = @StartDate, " +
                            "EndDate = @EndDate, " +
                            "SendContentId = @SendContentId, " +
                            "SendType = @SendType, " +
                            "Status = @Status, " +
                            "MailConfigID = @MailConfigID, " +
                            "GroupTo = @GroupTo, " +
                            "ErrorType = @ErrorType	WHERE Id = @Id";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = dt.Id;
        cmd.Parameters.Add("@AccountId", SqlDbType.VarChar).Value = dt.AccountId;
        cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = dt.StartDate;
        cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dt.EndDate;
        cmd.Parameters.Add("@SendContentId", SqlDbType.Int).Value = dt.SendContentId;
        cmd.Parameters.Add("@SendType", SqlDbType.Int).Value = dt.SendType;
        cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dt.Status;
        cmd.Parameters.Add("@ErrorType", SqlDbType.Int).Value = dt.ErrorType;
        cmd.Parameters.Add("@MailConfigID", SqlDbType.Int).Value = dt.MailConfigID;
        cmd.Parameters.Add("@GroupTo", SqlDbType.Int).Value = dt.GroupTo;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblSendRegister_Delete(int ID)
    {
        SqlCommand cmd = new SqlCommand("DELETE FROM tblSendRegister WHERE Id = @Id", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = ID;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetAll(int UserId)
    {
        SqlCommand cmd = new SqlCommand("SP_GetSendRegister_ByUserId", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
        cmd.Parameters.Add("@Status", SqlDbType.Int).Value = 1;
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
    public DataTable GetAll()
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblSendRegister", ConnectionData._MyConnection);
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
    public DataTable GetByID(int ID)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblSendRegister WHERE Id = @Id ", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = ID;
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


    public DataTable GetByStatus(int status)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblSendRegister WHERE Status = @Status", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Status", SqlDbType.Int).Value = status;
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
    public DataTable GetByStatus(int status, int MailConfigID)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblSendRegister WHERE Status = @Status and MailConfigID = @MailConfigID ", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Status", SqlDbType.Int).Value = status;
        cmd.Parameters.Add("@MailConfigID", SqlDbType.Int).Value = MailConfigID;
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
    public DataTable GetByStatusUser(int status, int AccountId)
    {
        SqlCommand cmd = new SqlCommand("SP_GetSendRegister_ByUserId", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Status", SqlDbType.Int).Value = status;
        cmd.Parameters.Add("@userid", SqlDbType.Int).Value = AccountId;
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
    public DataTable GetByTime(DateTime befortTimeStart, int status)
    {
        //string sql = "SELECT * FROM tblSendRegister WHERE StartDate >= @befortTimeStart  and Status = @Status ";

        string sql = "SELECT * FROM tblSendRegister WHERE StartDate < @befortTimeStart  and Status = @Status ";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@befortTimeStart", SqlDbType.DateTime).Value = befortTimeStart.AddMinutes(2);
        cmd.Parameters.Add("@Status", SqlDbType.Int).Value = status;
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
    public DataTable GetByTimeCheck(DateTime befortTimeStart, int status)
    {
        //string sql = "SELECT * FROM tblSendRegister WHERE StartDate >= @befortTimeStart  and Status = @Status ";

        string sql = "SELECT TOP 1 * FROM tblSendRegister WHERE StartDate < @befortTimeStart  and Status = @Status ORDER BY StartDate DESC  ";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@befortTimeStart", SqlDbType.DateTime).Value = befortTimeStart;
        cmd.Parameters.Add("@Status", SqlDbType.Int).Value = status;
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
    public void tblSendRegister_UpdateStatus(int Id, int Status, DateTime EndDate)
    {
        string sql = "UPDATE tblSendRegister SET " +
                            "EndDate = @EndDate, " +
                            "Status = @Status " +	"WHERE Id = @Id";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
        cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
        cmd.Parameters.Add("@Status", SqlDbType.Int).Value = Status;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
 
    }

    public DataTable GetWailSend(DateTime Now, int MailConfigID)
    {
        string sql = " Select S.AccountId, S.StartDate ,SC.Subject ,S.Id from  tblSendRegister as S ,"
         + "tblSendContent as SC where S.SendContentId = SC.id and S.status=1 and S.StartDate >= @Now and S.MailConfigID = @MailConfigID ";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Now", SqlDbType.DateTime).Value = Now;
        cmd.Parameters.Add("@MailConfigID", SqlDbType.Int).Value = MailConfigID;
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
    public DataTable GetWailSend(DateTime Now)
    {
        string sql = " Select S.AccountId, S.StartDate ,SC.Subject ,S.Id from  tblSendRegister as S ,"
         + "tblSendContent as SC where S.SendContentId = SC.id and S.status=1 and S.StartDate >= @Now";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Now", SqlDbType.DateTime).Value = Now;
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
     public DataTable GetMailError(DateTime Now)
     {
         string sql = " Select S.AccountId, S.StartDate ,SC.Subject ,S.Id from  tblSendRegister as S ,"
          + "tblSendContent as SC where S.SendContentId = SC.id and S.status=1 and StartDate < @Now ";
         SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
         cmd.CommandType = CommandType.Text;
         cmd.Parameters.Add("@Now", SqlDbType.DateTime).Value = Now;
         //SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionData._MyConnection);
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
     public DataTable GetMailError(DateTime Now, int MailConfigID)
     {
         string sql = " Select S.AccountId, S.StartDate ,SC.Subject ,S.Id from  tblSendRegister as S ,"
          + "tblSendContent as SC where S.SendContentId = SC.id and S.status=1 and StartDate < @Now and S.MailConfigID= @MailConfigID";
         SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
         cmd.CommandType = CommandType.Text;
         cmd.Parameters.Add("@Now", SqlDbType.DateTime).Value = Now;
         cmd.Parameters.Add("@MailConfigID", SqlDbType.Int).Value = MailConfigID;
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
     public DataTable GetSended()
     {
         string sql = " Select S.AccountId, S.StartDate ,SC.Subject ,S.Id from  tblSendRegister as S ,"
          + "tblSendContent as SC where S.SendContentId = SC.id and S.status=1 ";
         SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionData._MyConnection);
         DataTable table = new DataTable();
         if (ConnectionData._MyConnection.State == ConnectionState.Closed)
         {
             ConnectionData._MyConnection.Open();
         }
         adapter.Fill(table);
         adapter.Dispose();
         return table;
     }
     public int GetByMailConfigID(int ID)
     {
         SqlCommand cmd = new SqlCommand("SELECT * FROM tblSendRegister WHERE MailConfigID = @Id and Status=0", ConnectionData._MyConnection);
         cmd.CommandType = CommandType.Text;
         cmd.Parameters.Add("@Id", SqlDbType.Int).Value = ID;
         SqlDataAdapter adapter = new SqlDataAdapter(cmd);
         DataTable table = new DataTable();
         if (ConnectionData._MyConnection.State == ConnectionState.Closed)
         {
             ConnectionData._MyConnection.Open();
         }
         adapter.Fill(table);
         cmd.Dispose();
         adapter.Dispose();
         return table.Rows.Count;
     }
     public int GetByContentID(int ID)
     {
         SqlCommand cmd = new SqlCommand("SELECT * FROM tblSendRegister WHERE SendContentId = @Id and Status = 0", ConnectionData._MyConnection);
         cmd.CommandType = CommandType.Text;
         cmd.Parameters.Add("@Id", SqlDbType.Int).Value = ID;
         SqlDataAdapter adapter = new SqlDataAdapter(cmd);
         DataTable table = new DataTable();
         if (ConnectionData._MyConnection.State == ConnectionState.Closed)
         {
             ConnectionData._MyConnection.Open();
         }
         adapter.Fill(table);
         cmd.Dispose();
         adapter.Dispose();
         return table.Rows.Count;
     }

     public DataTable GetByTimeNext(DateTime timeStart, DateTime timeEnd , int status)
     {
         //string sql = "SELECT * FROM tblSendRegister WHERE StartDate >= @befortTimeStart  and Status = @Status ";

         string sql = "SELECT TOP 1 * FROM tblSendRegister WHERE StartDate between @timeStart and @timeEnd and Status = @Status ORDER BY StartDate DESC ";
         SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
         cmd.CommandType = CommandType.Text;
         cmd.Parameters.Add("@timeStart", SqlDbType.DateTime).Value = timeStart;
         cmd.Parameters.Add("@timeEnd", SqlDbType.DateTime).Value = timeEnd;
         cmd.Parameters.Add("@Status", SqlDbType.Int).Value = status;
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
     public int GetByBefor(DateTime timeStart,int status)
     {
         //string sql = "SELECT TOP 1 * FROM tblSendRegister WHERE StartDate < @timeStart and Status = @Status ORDER BY  StartDate DESC ";
         //SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
         //cmd.CommandType = CommandType.Text;
         //cmd.Parameters.Add("@timeStart", SqlDbType.DateTime).Value = timeStart;
         //cmd.Parameters.Add("@Status", SqlDbType.Int).Value = status;
         //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
         //DataTable table = new DataTable();
         //adapter.Fill(table);
         //int countMail = 0;
         //int TimeBefor = 0;
         //if(table.Rows.Count>0)
         //{
         //   int GroupID =int.Parse(table.Rows[0]["SendType"].ToString());
         //   CustomerBUS ctBUS = new CustomerBUS();
            
         //   if (ctBUS.GetByGroupID(GroupID).Rows.Count > 0)
         //   {
         //       countMail = ctBUS.GetByGroupID(GroupID).Rows.Count;
         //   }
         //   Common common = new Common();
         //   TimeBefor = common.calculatorMinuteQuantityEmail(countMail);
         //}
         
         //cmd.Dispose();
         //adapter.Dispose();
         //return TimeBefor;
         return 1;
       
     }
     public string GetByAfter(DateTime timeEnd, int status)
     {
         //string sql = "SELECT * FROM tblSendRegister WHERE StartDate >= @befortTimeStart  and Status = @Status ORDER BY  StartDate DESC ";

         string sql = "SELECT TOP 1 * FROM tblSendRegister WHERE StartDate < @timeEnd and Status = @Status ORDER BY  StartDate DESC ";
         SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
         cmd.CommandType = CommandType.Text;
         cmd.Parameters.Add("@timeEnd", SqlDbType.DateTime).Value = timeEnd;
         cmd.Parameters.Add("@Status", SqlDbType.Int).Value = status;
         SqlDataAdapter adapter = new SqlDataAdapter(cmd);
         DataTable table = new DataTable();
         adapter.Fill(table);
         string Date = "";
         if (table.Rows.Count > 0)
         {
             Date = table.Rows[0]["StartDate"].ToString();
         }

         cmd.Dispose();
         adapter.Dispose();
         return Date;

     }
     public int GetByGroupID(int GroupID, int status)
     {
         string sql = "SELECT * FROM tblSendRegister WHERE SendType = @GroupID and Status = @Status";
         SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
         cmd.CommandType = CommandType.Text;
         cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = GroupID;
         cmd.Parameters.Add("@Status", SqlDbType.Int).Value = status;
         SqlDataAdapter adapter = new SqlDataAdapter(cmd);
         DataTable table = new DataTable();
         if (ConnectionData._MyConnection.State == ConnectionState.Closed)
         {
             ConnectionData._MyConnection.Open();
         }
         adapter.Fill(table);
         cmd.Dispose();
         adapter.Dispose();
         return table.Rows.Count;

     }

     
    
}
