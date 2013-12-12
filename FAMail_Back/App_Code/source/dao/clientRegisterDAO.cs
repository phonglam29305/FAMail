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
/// Summary description for clientRegisterDAO
/// </summary>
public class clientRegisterDAO
{
	public clientRegisterDAO()
	{
		
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