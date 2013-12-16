using Email;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClientRegisterDAO
/// </summary>
public class ClientRegisterDAO
{
	public ClientRegisterDAO()
	{
	
	}
    public DataTable GetByID(int Id)
    {
        SqlCommand cmd = new SqlCommand("Select * from tblClientRegister where registerId=@registerId", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@registerId", SqlDbType.NVarChar).Value = Id;
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
public DataTable Search_client_register(string clientName, string namepackagelimit, string registerTime_from, string registerTime_to, string expireDate_from, string expireDate_to)
    {
        SqlCommand cmd = new SqlCommand("Client_Search_register", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@clientName", SqlDbType.NVarChar).Value = clientName;
        cmd.Parameters.Add("@namepackagelimit", SqlDbType.NVarChar, 250).Value = namepackagelimit;
        cmd.Parameters.Add("@registerTime_from", SqlDbType.VarChar,12).Value = registerTime_from;
        cmd.Parameters.Add("@registerTime_to", SqlDbType.VarChar, 12).Value = registerTime_to;
        cmd.Parameters.Add("@expireDate_from", SqlDbType.VarChar, 12).Value = expireDate_from;
        cmd.Parameters.Add("@expireDate_to", SqlDbType.VarChar, 12).Value = expireDate_to;
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
    public DataTable GetAllPackage()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblPackageLimit",
            ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
}