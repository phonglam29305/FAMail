using Email;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for ClientFunctionDAO
/// </summary>
public class ClientFunctionDAO
{
	public ClientFunctionDAO()
	{
		
	}
    public DataTable GetByregisterIdandclientId(int Id,int Id2)
    {
        SqlCommand cmd = new SqlCommand("Select * from tblClientFunction where registerId=@registerId and clientId=@clientId", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@registerId", SqlDbType.Int).Value = Id;
        cmd.Parameters.Add("@clientId", SqlDbType.Int).Value = Id2;
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