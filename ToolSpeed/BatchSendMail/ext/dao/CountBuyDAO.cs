using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using Email;

/// <summary>
/// Summary description for CountBuyDAO
/// </summary>
public class CountBuyDAO
{
	public CountBuyDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void tblCountBuy_insert(int CustomerID, int CategoryID, int CountBuy)
    {
        string sql = "INSERT INTO tblCountBuy(CustomerID, CategoryID, CountBuy) " +
                     "VALUES(@CustomerID, @CategoryID, @CountBuy)";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = CustomerID;
        cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;
        cmd.Parameters.Add("@CountBuy", SqlDbType.Int).Value = CountBuy;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public int tblCountBuy_UpdateCountBuy(int CustomerID, int CategoryID)
    {
        string sql = "UPDATE tblCountBuy SET " +
                     "CountBuy = @CountBuy WHERE CustomerID = @CustomerID and  CategoryID=@CategoryID";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = CustomerID;
        cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;
        DataTable count = GetByID(CustomerID, CategoryID);
        int i = 0;
        if (count.Rows.Count > 0)
        {
            i = int.Parse(count.Rows[0]["CountBuy"].ToString());
        }
        else
        { 
        }
        i++;
        cmd.Parameters.Add("@CountBuy", SqlDbType.Int).Value = i;

        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        return i;
    }
    public void tblCountBuy_Delete(int CustomerID, int CategoryID)
    {
        string sql = "DELETE FROM tblCountBuy WHERE CustomerID = @CustomerID and CategoryID =@CategoryID";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = CustomerID;
        cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;

        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetAll()
    {
        string sql = "SELECT * FROM tblCountBuy ";
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
    public DataTable GetGroup()
    {
        //trả vê CategoryID,Title
        string sql = "SELECT  DISTINCT  C.CategoryID ,CA.Title  FROM tblCountBuy as C ,tblCategory As CA where C.CategoryID= CA.ID";
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
 
    public DataTable GetByID(int CustomerID, int CategoryID)
    {
        string sql = "SELECT * FROM tblCountBuy WHERE CustomerID = @CustomerID and CategoryID =@CategoryID";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = CustomerID;
        cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
    public DataTable GetByCategoryID(int CategoryID)
    {
        string sql = "SELECT * FROM tblCountBuy WHERE CategoryID =@CategoryID";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
}
