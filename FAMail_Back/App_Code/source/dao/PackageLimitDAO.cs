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
/// Summary description for PackageLimitDAO
/// </summary>
public class PackageLimitDAO
{
	public PackageLimitDAO()
	{		
	}
    public DataTable GetAll()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblPackageLimit ",
            ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public void tblPackageLimit_insert(PackageLimitDTO dt)
    {
        string sql = "INSERT INTO tblPackageLimit (namepackagelimit,under,cost,isActive, IsUnLimit) " +
                     "VALUES( @namepackagelimit, @under,@cost,@isActive, @IsUnLimit) ";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@namepackagelimit", SqlDbType.NVarChar).Value = dt.namepackagelimit;
        cmd.Parameters.Add("@under", SqlDbType.BigInt).Value = dt.under;
        cmd.Parameters.Add("@cost", SqlDbType.Float).Value = dt.cost;
        cmd.Parameters.Add("@isActive", SqlDbType.Bit).Value = dt.isActive;
        cmd.Parameters.Add("@IsUnLimit", SqlDbType.Bit).Value = dt.isUnLimit;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblPackageLimit_Delete(int limitId)
    {
        SqlCommand cmd = new SqlCommand("DELETE FROM tblPackageLimit WHERE limitId = @limitId",
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@limitId", SqlDbType.Int).Value = limitId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetByUserIdPackageLimit(int limitId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblPackageLimit WHERE limitId = @limitId",
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@limitId", SqlDbType.Int).Value = limitId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
    public void tblPackageLimit_Update(PackageLimitDTO dt)
    {
        string sql = "UPDATE tblPackageLimit SET " +
                "namepackagelimit= @namepackagelimit, " +
                "under = @under, " +
                "cost = @cost, " +
                "isActive = @isActive, " +
                "isUnlimit = @IsUnLimit " +
                " WHERE limitId = @limitId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@namepackagelimit", SqlDbType.NVarChar).Value = dt.namepackagelimit;
        cmd.Parameters.Add("@under", SqlDbType.BigInt).Value = dt.under;
        cmd.Parameters.Add("@cost", SqlDbType.Float).Value = dt.cost;
        cmd.Parameters.Add("@isActive", SqlDbType.Bit).Value = dt.isActive;
        cmd.Parameters.Add("@IsUnLimit", SqlDbType.Bit).Value = dt.isUnLimit;
        ConnectionData.OpenMyConnection();
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        ConnectionData.CloseMyConnection();
    }
    public DataTable GetAvailablePackage(int limitId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblPackageLimit except Select * From tblPackageLimit Where limitId = @limitId",
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@limitId", SqlDbType.Int).Value = limitId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
}