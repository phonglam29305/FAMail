using Email;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PackageFunctionDAO
/// </summary>
public class PackageFunctionDAO
{
	public PackageFunctionDAO()
	{
		
	}
    public DataTable GetFunctionbyPackageId(int packageId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblPackageFunction where packageId = @packageId", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@packageId", SqlDbType.Int).Value = packageId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
}