using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using Email;

/// <summary>
/// Summary description for OrderDAO
/// </summary>
public class OrderDAO
{
	public OrderDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int tblOrder_insert(OrderDTO dt)
    {
        string sql = "INSERT INTO tblOrder(OrderID, CreateDate, CustomerID, PersonCreate, Status, DeliveryDate, DeliveryMethod, PaymentMethod, HandSel) " +
                     "VALUES(@OrderID, @CreateDate, @CustomerID, @PersonCreate, @Status, @DeliveryDate, @DeliveryMethod, @PaymentMethod, @HandSel)";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection, ConnectionData._MyTransaction);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@OrderID", SqlDbType.NVarChar).Value = dt.OrderID;
        cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = dt.CreateDate;
        cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = dt.CustomerID;
        cmd.Parameters.Add("@PersonCreate", SqlDbType.NVarChar).Value = dt.PersonCreate;
        cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = dt.Status;
        cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = dt.DeliveryDate;
        cmd.Parameters.Add("@DeliveryMethod", SqlDbType.NVarChar).Value = dt.DeliveryMethod;
        cmd.Parameters.Add("@PaymentMethod", SqlDbType.NVarChar).Value = dt.PaymentMethod;
        cmd.Parameters.Add("@HandSel", SqlDbType.Float).Value = dt.HandSel;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
         int  row = cmd.ExecuteNonQuery();
         cmd.Dispose();
         return row;
    }
    public int tblOrder_update(OrderDTO dt)
    {
        string sql = "UPDATE tblOrder SET "+
                "CreateDate = @CreateDate, "+
                "CustomerID = @CustomerID, "+
                "PersonCreate = @PersonCreate, "+
                "Status = @Status, "+
                "DeliveryDate = @DeliveryDate, "+
                "DeliveryMethod = @DeliveryMethod, " +
                "HandSel = @HandSel, " +
                "PaymentMethod = @PaymentMethod " +
                "WHERE OrderID = @OrderID ";

        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection,ConnectionData._MyTransaction);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@OrderID", SqlDbType.NVarChar).Value = dt.OrderID;
        cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = dt.CreateDate;
        cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = dt.CustomerID;
        cmd.Parameters.Add("@PersonCreate", SqlDbType.NVarChar).Value = dt.PersonCreate;
        cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = dt.Status;
        cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = dt.DeliveryDate;
        cmd.Parameters.Add("@DeliveryMethod", SqlDbType.NVarChar).Value = dt.DeliveryMethod;
        cmd.Parameters.Add("@PaymentMethod", SqlDbType.NVarChar).Value = dt.PaymentMethod;
        cmd.Parameters.Add("@HandSel", SqlDbType.Float).Value = dt.HandSel;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        int row = cmd.ExecuteNonQuery();
        cmd.Dispose();
        return row;
    }
    public int tblOrder_updateStatus(string OrderID, bool Status)
    {
        string sql = "UPDATE tblOrder SET " +
                      "Status = @Status " +
                      "WHERE OrderID = @OrderID ";

        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection,ConnectionData._MyTransaction);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@OrderID", SqlDbType.NVarChar).Value = OrderID;
        cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = Status;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        int row = cmd.ExecuteNonQuery();
        cmd.Dispose();
        return row;
    }
    public void tblOrder_Delete(string OrderID)
    {
        
        string sql = "DELETE FROM tblOrder WHERE OrderID = @OrderID";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection,ConnectionData._MyTransaction);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@OrderID", SqlDbType.NVarChar).Value = OrderID;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        OrderDatailDAO orDao = new OrderDatailDAO();
        orDao.tblOrderDetail_Delete(OrderID);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable tblOrder_GetByID(string OrderID)
    {

        string sql = "SELECT * FROM tblOrder WHERE OrderID = @OrderID";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@OrderID", SqlDbType.NVarChar).Value = OrderID;
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
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblOrder", ConnectionData._MyConnection);
        DataTable table = new DataTable();
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }

    public DataTable tblOrder_GetByDateCreate(DateTime from , DateTime to)
    {

        string sql = "SELECT * FROM tblOrder WHERE CreateDate between @DateFrom and @DateTo";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = from;
        cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = to;
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
    public DataTable tblOrder_GetByStatus(bool status)
    {

        string sql = "SELECT * FROM tblOrder WHERE Status=@Status";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
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

    public DataTable tblOrder_GetCustomer(int customerID)
    {

        string sql = "SELECT * FROM tblOrder WHERE CustomerID=@CustomerID";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;
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
