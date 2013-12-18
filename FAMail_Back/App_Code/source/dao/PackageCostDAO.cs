using Email;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PackageCostDAO
/// </summary>
public class PackageCostDAO
{
	public PackageCostDAO()
	{
		
	}
    public DataTable GetPackageCost(int id)
    {
        SqlCommand cmd = new SqlCommand("SP_Package_GetById", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
}