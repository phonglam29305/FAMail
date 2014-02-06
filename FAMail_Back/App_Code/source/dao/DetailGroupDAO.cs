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

/// <summary>
/// Summary description for DetailSubGroupDAO
/// </summary>
public class DetailGroupDAO
{
    SqlCommand cmd = null;
	public DetailGroupDAO()
	{
		
	}
    public void tblDetailGroup_insert(DetailGroupDTO dt)
    {
        string sql = "INSERT INTO tblDetailGroup(GroupID, CustomerID,countReceivedMail,LastReceivedMail) " +
              "VALUES(@GroupID, @CustomerID, @countReceivedMail, @LastReceivedMail)";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = dt.GroupID;
        cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = dt.CustomerID;
        cmd.Parameters.Add("@countReceivedMail", SqlDbType.Int).Value = dt.CountReceivedMail;
        cmd.Parameters.Add("@LastReceivedMail", SqlDbType.DateTime).Value = dt.LastReceivedMail;

        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public void tblDetailGroup_Delete(int GroupID, int CustomerID)
    {
        string sql = "DELETE FROM tblDetailGroup WHERE GroupID = @GroupID and CustomerID=@CustomerID";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = GroupID;
        cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = CustomerID;

        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public void tblDetailGroup_Update(DetailGroupDTO dt)
    {
        string sql = "UPDATE tblDetailGroup SET countReceivedMail = @countReceivedMail, LastReceivedMail = @LastReceivedMail " +
                       " WHERE GroupID = @GroupID and CustomerID=@CustomerID";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = dt.GroupID;
        cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = dt.GroupID;
        cmd.Parameters.Add("@countReceivedMail", SqlDbType.Int).Value = dt.CountReceivedMail;
        cmd.Parameters.Add("@LastReceivedMail", SqlDbType.DateTime).Value = dt.LastReceivedMail;

        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public DataTable GetAll()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblDetailGroup", ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public DataTable GetByID(int GroupID, int CustomerID)
    {
        string sql = "SELECT * FROM tblDetailGroup WHERE GroupID = @GroupID and CustomerID=@CustomerID";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = GroupID;
        cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = CustomerID;
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
    public DataTable GetByID(int GroupID)
    {
        string sql = "SELECT * FROM tblDetailGroup WHERE GroupID = @GroupID ";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = GroupID;
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
    public object GetCountByGroupID(int GroupID)
    {
        string sql = "SELECT count(*) FROM tblDetailGroup g inner join tblCustomer c on c.id = g.customerid WHERE GroupID = @GroupID and recivedEmail='true'  and [isDelete]<>1 ";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = GroupID;
        
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        object obj = cmd.ExecuteScalar();
        return obj;
    }
    public void tblDetailGroup_DeleteByGroup(int GroupID)
    {
        string sql = "DELETE FROM tblDetailGroup WHERE GroupID = @GroupID";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = GroupID;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblDetailGroup_DeleteByCustomerID(int CustomerID)
    {
        string sql = "DELETE FROM tblDetailGroup WHERE CustomerID=@CustomerID";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = CustomerID;

        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
}
