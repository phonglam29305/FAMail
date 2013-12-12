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
/// Summary description for FunctionDAO
/// </summary>
public class FunctionDAO
{

    public FunctionDAO()
    {

    }
    public void tblFunction_insert(FunctionDTO dt)
    {
        string sql = "INSERT INTO tblFunction (functionName, cost,isDefault,description) " +
                     "VALUES( @functionName, @cost,@isDefault,@description) ";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@functionName", SqlDbType.NVarChar).Value = dt.functionName;
        cmd.Parameters.Add("@description", SqlDbType.NVarChar).Value = dt.description;
        cmd.Parameters.Add("@cost", SqlDbType.Float).Value = dt.cost;
        cmd.Parameters.Add("@isDefault", SqlDbType.Bit).Value = dt.isDefault;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetAll()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblFunction ",
            ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public DataTable GetByUserId(int functionId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblFunction WHERE functionId = @functionId",
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@functionId", SqlDbType.Int).Value = functionId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
    public DataTable tblFunction_GetByID(string functionName)
    {

        string sql = "SELECT * FROM tblFunction WHERE functionName= @functionName";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@functionName", SqlDbType.NVarChar).Value = functionName;
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
    public bool tblFunction_Delete(int functionId)
    {
        int i = 0;
        try
        {
            if (ConnectionData._MyConnection.State == ConnectionState.Closed)
            {
                ConnectionData._MyConnection.Open();
            }
            SqlCommand cmd = new SqlCommand("DELETE FROM tblFunction WHERE functionId = @functionId",
                ConnectionData._MyConnection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@functionId", SqlDbType.Int).Value = functionId;
            i = cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            ConnectionData._MyConnection.Close();
        }
        return i > 0;
    }
    public void tblFunction_Update(FunctionDTO dt)
    {
        string sql = "UPDATE tblFunction SET " +
                    "functionName = @functionName, " +
                    "cost = @cost, " +
                    "isDefault= @isDefault " +
                    " WHERE functionid = @functionid";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;

        cmd.Parameters.Add("@functionName", SqlDbType.NVarChar).Value = dt.functionName;
        cmd.Parameters.Add("@cost", SqlDbType.Float).Value = dt.cost;
        cmd.Parameters.Add("@isDefault", SqlDbType.Bit).Value = dt.isDefault;
        cmd.Parameters.Add("@functionId", SqlDbType.Int).Value = dt.functionId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    internal DataTable GetbyPackage(int packageId)
    {
        string sql = "SELECT f.*, case when p.functionid is not null then 1 else 0 end selected FROM tblFunction f left join tblPackageFunction p on f.functionid = p.functionid and packageid= @packageid";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@packageid", SqlDbType.Int).Value = packageId;
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