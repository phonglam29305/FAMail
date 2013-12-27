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
/// Summary description for EventDetailDAO
/// </summary>
public class EventDetailDAO
{
    public EventDetailDAO()
    {

    }
    public void tblEventDetail_insert(EventDetailDTO dt)
    {
        string sql = "INSERT INTO tblEventDetail(EventId, CreateDate, FullName, EmailID, Company, Phone, SecondPhone, Address, Address2, City, Province, ZipCode, Country, Fax,GroupId, CountReceivedMail, LastReceivedMail) " +
                      "VALUES(@EventId, @CreateDate, @FullName, @EmailID, @Company, @Phone, @SecondPhone, @Address, @Address2, @City, @Province, @ZipCode, @Country, @Fax, @GroupId,@CountReceivedMail, @LastReceivedMail)";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@EventId", SqlDbType.Int).Value = dt.EventId;
        cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = dt.CreateDate;
        cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = dt.FullName;
        cmd.Parameters.Add("@EmailID", SqlDbType.VarChar).Value = dt.EmailID;
        cmd.Parameters.Add("@Company", SqlDbType.NVarChar).Value = dt.Company;
        cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = dt.Phone;
        cmd.Parameters.Add("@SecondPhone", SqlDbType.VarChar).Value = dt.SecondPhone;
        cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = dt.Address;
        cmd.Parameters.Add("@Address2", SqlDbType.NVarChar).Value = dt.Address2;
        cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = dt.City;
        cmd.Parameters.Add("@Province", SqlDbType.NVarChar).Value = dt.Province;
        cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = dt.ZipCode;
        cmd.Parameters.Add("@Country", SqlDbType.NVarChar).Value = dt.Country;
        cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = dt.Fax;
        cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = dt.GroupId;
        cmd.Parameters.Add("@CountReceivedMail", SqlDbType.Int).Value = dt.CountReceivedMail;
        cmd.Parameters.Add("@LastReceivedMail", SqlDbType.DateTime).Value = dt.LastReceivedMail;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblEventDetail_Update(EventDetailDTO dt)
    {
        string sql = "UPDATE tblEventDetail SET " +
                    "CreateDate = @CreateDate, " +
                    "FullName = @FullName, " +
                    "EmailID = @EmailID, " +
                    "Company = @Company, " +
                    "Phone = @Phone, " +
                    "SecondPhone = @SecondPhone, " +
                    "Address = @Address, " +
                    "Address2 = @Address2, " +
                    "City = @City, " +
                    "Province = @Province, " +
                    "ZipCode = @ZipCode, " +
                    "Country = @Country, " +
                    "Fax = @Fax, GroupId = @GroupId	WHERE EventId = @EventId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@EventId", SqlDbType.Int).Value = dt.EventId;
        cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = dt.CreateDate;
        cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = dt.FullName;
        cmd.Parameters.Add("@EmailID", SqlDbType.VarChar).Value = dt.EmailID;
        cmd.Parameters.Add("@Company", SqlDbType.NVarChar).Value = dt.Company;
        cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = dt.Phone;
        cmd.Parameters.Add("@SecondPhone", SqlDbType.VarChar).Value = dt.SecondPhone;
        cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = dt.Address;
        cmd.Parameters.Add("@Address2", SqlDbType.NVarChar).Value = dt.Address2;
        cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = dt.City;
        cmd.Parameters.Add("@Province", SqlDbType.NVarChar).Value = dt.Province;
        cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = dt.ZipCode;
        cmd.Parameters.Add("@Country", SqlDbType.NVarChar).Value = dt.Country;
        cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = dt.Fax;
        cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = dt.GroupId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblEventDetail_Delete(int EventId)
    {
        SqlCommand cmd = new SqlCommand("DELETE FROM tblEventDetail WHERE EventId = @EventId", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@EventId", SqlDbType.Int).Value = EventId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetAll()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblEventDetail", ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public DataTable GetByGroupId(int GroupId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblEventDetail WHERE GroupId = @GroupId", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = GroupId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }


    public DataTable GetByGroupIdNew(int GroupId, int eventID)
    {

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "pro_get_all_listEventDetail";
        cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = GroupId;
        cmd.Parameters.Add("@eventID", SqlDbType.Int).Value = eventID;
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


    public DataTable GetByID(int EventId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblEventDetail WHERE EventId = @EventId", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@EventId", SqlDbType.Int).Value = EventId;
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
    public DataTable GetByIdAndEmail(int EventId, string email)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblEventDetail WHERE EventId = @EventId AND EmailID = @EmailID", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@EventId", SqlDbType.Int).Value = EventId;
        cmd.Parameters.Add("@EmailID", SqlDbType.VarChar).Value = email.Trim();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

}
