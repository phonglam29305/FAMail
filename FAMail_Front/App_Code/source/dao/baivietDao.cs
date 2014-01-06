using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Email;


/// <summary>
/// Summary description for baivietDao
/// </summary>
public class baivietDao
{
	public baivietDao()
	{		
	}
    public DataTable GetalltblConfig()
    {
        SqlCommand cmd = new SqlCommand("select * from tblConfig ", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable table = new DataTable();
        da.Fill(table);
        cmd.Dispose();
        da.Dispose();
        return table;
    }
    public DataTable GetalltblConfig_id(string key)
    {
        SqlCommand cmd = new SqlCommand("select * from tblConfig where [key]=@key", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@key", SqlDbType.NVarChar).Value =key;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        da.Fill(table);
        cmd.Dispose();
        da.Dispose();
        return table;
    }
    public DataTable Getalltblconfig_idgroup(string idGroup)  
    {
        SqlCommand cmd = new SqlCommand("select * from tblconfig where idGroup=@idGroup  and isShow='True'", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@idGroup", SqlDbType.NVarChar).Value = idGroup;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        da.Fill(table);
        cmd.Dispose();
        da.Dispose();
        return table;
    }

    
}