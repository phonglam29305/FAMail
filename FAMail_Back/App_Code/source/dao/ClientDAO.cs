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
/// Summary description for CustomerDAO
/// </summary>
public class ClientDAO
{
    public ClientDAO()
    {

    }

    public bool Customer_Lock_Unlock(int Id, Common.clientStatus status)
    {
        string sql = "UPDATE tblClient SET " +
                    "status = " + (int)status + " where clientid=" + Id;

        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@clientid", SqlDbType.Int).Value = Id;

        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        int i = cmd.ExecuteNonQuery();
        cmd.Dispose();
        return i > 0;
    }

    public DataTable Search(string name, string email, int sex, bool isCheckExpire, string from, string to)
    {
        SqlCommand cmd = new SqlCommand("SP_Client_Search", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
        cmd.Parameters.Add("@sex", SqlDbType.NVarChar).Value = sex;
        cmd.Parameters.Add("@isCheckExpire", SqlDbType.NVarChar).Value = isCheckExpire;
        cmd.Parameters.Add("@from", SqlDbType.NVarChar).Value = from;
        cmd.Parameters.Add("@to", SqlDbType.NVarChar).Value = to;
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

    public DataTable GetByID(int Id)
    {
        SqlCommand cmd = new SqlCommand("Select * from tblClient where userid=@userId", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@userId", SqlDbType.NVarChar).Value = Id;
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
    public DataTable getallclient(int clientId)
    {
        SqlCommand cmd = new SqlCommand("Select * from tblClient where clientId=@clientId ", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@clientId", SqlDbType.Int).Value = clientId;
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

    public DataTable GetByEmail(string Email)
    {
        SqlCommand cmd = new SqlCommand("Select * from tblClient where Email=@Email", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
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
    public void UpdateInfomation(int clientid, string name, string adddress, DateTime dateofbirth, string phone)
    {
        string sql = "Update tblClient set clientName=@clientName,address=@address,phone=@phone,dateofbirth=@dateofbirth where clientId=@clientId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@clientId", SqlDbType.Int).Value = clientid;
        cmd.Parameters.Add("@clientName", SqlDbType.NVarChar).Value = name;
        cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = adddress;
        cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
        cmd.Parameters.Add("@dateofbirth", SqlDbType.DateTime).Value = dateofbirth;
        cmd.ExecuteNonQuery();
    }
    public void UpdateExtendLicense(string clientid, DateTime activeday, DateTime expireday)
    {
        string sql = "Update tblClient set activeDate=@activeDate,expireDate=@expireDate where clientId=@clientId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@clientId", SqlDbType.Int).Value = clientid;
        cmd.Parameters.Add("@activeDate", SqlDbType.DateTime).Value = activeday;
        cmd.Parameters.Add("@expireDate", SqlDbType.DateTime).Value = expireday;
        cmd.ExecuteNonQuery();
    }
    public void UpdateRegiterId(int clientId,string activeDay,string expireDay,int lastRegisterId, int registerId)
    {
        string sql = "set dateformat dmy Update tblClient set activeDate=@activeDate,expireDate=@expireDate,lastRegisterId=@lastRegisterId, registerId=@registerId where clientId=@clientId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@clientId", SqlDbType.Int).Value = clientId;
        cmd.Parameters.Add("@activeDate", SqlDbType.VarChar).Value = activeDay;
        cmd.Parameters.Add("@expireDate", SqlDbType.VarChar).Value = expireDay;
        cmd.Parameters.Add("@lastRegisterId", SqlDbType.Int).Value = lastRegisterId;
        cmd.Parameters.Add("@registerId", SqlDbType.Int).Value = registerId;
        cmd.ExecuteNonQuery();
    }
}
