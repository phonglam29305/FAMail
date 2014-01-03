using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using Email;

/// <summary>
/// Summary description for OrderDatailDAO
/// </summary>
public class OrderDatailDAO
{
	public OrderDatailDAO()
	{
	
	}
    public int tblOrderDetail_insert(OrderDatailDTO dt)
    {
        string sql = "INSERT INTO tblOrderDetail(OrderID, ProductID, ProductName, DeliveryCode, Size, UnitPrice, Quantity, Total, Note) " +
                     "VALUES(@OrderID, @ProductID, @ProductName, @DeliveryCode, @Size, @UnitPrice, @Quantity, @Total ,@Note)";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@OrderID", SqlDbType.NVarChar).Value = dt.OrderID;
        cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = dt.ProductID;
        cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = dt.ProductName;
        cmd.Parameters.Add("@DeliveryCode", SqlDbType.NVarChar).Value = dt.DeliveryCode;
        cmd.Parameters.Add("@Size", SqlDbType.NVarChar).Value = dt.Size;
        cmd.Parameters.Add("@UnitPrice", SqlDbType.Float).Value = dt.UnitPrice;
        cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = dt.Quantity;
        cmd.Parameters.Add("@Total", SqlDbType.Float).Value = dt.Total;
        cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = dt.Note;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        int row = cmd.ExecuteNonQuery();
        cmd.Dispose();
        return row;
    }
    public int tblOrderDetail_update(OrderDatailDTO dt)
    {
        string sql = "UPDATE tblOrderDetail SET " +
               "ProductName = @ProductName, " +
               "DeliveryCode = @DeliveryCode, " +
               "Size = @Size, " +
               "UnitPrice = @UnitPrice, " +
               "Quantity = @Quantity, " +
               "Total = @Total, " +
               "Note = @Note " +
               "WHERE OrderID = @OrderID and ProductID = @ProductID";

        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@OrderID", SqlDbType.NVarChar).Value = dt.OrderID;
        cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = dt.ProductID;
        cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = dt.ProductName;
        cmd.Parameters.Add("@DeliveryCode", SqlDbType.NVarChar).Value = dt.DeliveryCode;
        cmd.Parameters.Add("@Size", SqlDbType.NVarChar).Value = dt.Size;
        cmd.Parameters.Add("@UnitPrice", SqlDbType.Float).Value = dt.UnitPrice;
        cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = dt.Quantity;
        cmd.Parameters.Add("@Total", SqlDbType.Float).Value = dt.Total;
        cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = dt.Note;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        int row = cmd.ExecuteNonQuery();
        cmd.Dispose();
        return row;
    }
    public void tblOrderDetail_Delete(string OrderID, int ProductID)
    {

        string sql = "DELETE FROM tblOrderDetail WHERE OrderID = @OrderID and ProductID = @ProductID ";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@OrderID", SqlDbType.NVarChar).Value = OrderID;
        cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblOrderDetail_Delete(string OrderID)
    {

        string sql = "DELETE FROM tblOrderDetail WHERE OrderID = @OrderID";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@OrderID", SqlDbType.NVarChar).Value = OrderID;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable tblOrderDetail_GetByID(string OrderID)
    {

        string sql = "SELECT * FROM tblOrderDetail WHERE OrderID = @OrderID";
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
    public DataTable tblOrderDetail_GetByID(string OrderID, int ProductID)
    {

        string sql = "SELECT * FROM tblOrderDetail WHERE OrderID = @OrderID and ProductID=@ProductID";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@OrderID", SqlDbType.NVarChar).Value = OrderID;
        cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
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
    public DataTable tblOrderDetail_GetByDeliveryCode(string DeliveryCode)
    {

        string sql = "SELECT * FROM tblOrderDetail WHERE DeliveryCode = @DeliveryCode ";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@DeliveryCode", SqlDbType.NVarChar).Value = DeliveryCode;
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
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblOrderDetail", ConnectionData._MyConnection);
        DataTable table = new DataTable();
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
}
