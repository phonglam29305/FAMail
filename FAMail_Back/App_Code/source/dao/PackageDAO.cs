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
/// Summary description for PackageDAO
/// </summary>
public class PackageDAO
{
	public PackageDAO()
	{	
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
    public DataTable GetdaPackage()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblPackage",
            ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }

    public DataTable GetByUserId(int packageId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblPackage where packageId = @packageId",
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@packageId", SqlDbType.Int).Value = packageId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }





    public void tblPackage_insert(PackageDTO dt)
    {
        string sql = "INSERT INTO tblPackage (packageName, diengiai,limitId,subAccontCount,isActive) " +
                     "VALUES( @packageName, @diengiai,@limitId,@subAccontCount,@isActive) ";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@packageName", SqlDbType.NVarChar).Value = dt.packageName;
        cmd.Parameters.Add("@diengiai", SqlDbType.NVarChar).Value = dt.diengiai;
        cmd.Parameters.Add("@limitId", SqlDbType.Int).Value = dt.limitId;
        cmd.Parameters.Add("@subAccontCount", SqlDbType.Int).Value = dt.subAccontCount;
        cmd.Parameters.Add("@isActive", SqlDbType.Bit).Value = dt.isActive;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public bool tblPackage_Delete(int packageId)
    {
        int i = 0;
        try
        {
            if (ConnectionData._MyConnection.State == ConnectionState.Closed)
            {
                ConnectionData._MyConnection.Open();
            }
            SqlCommand cmd = new SqlCommand("DELETE FROM tblPackage WHERE packageId = @packageId",
                ConnectionData._MyConnection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@packageId", SqlDbType.Int).Value = packageId;
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
    public void tblPackage_Update(PackageDTO dt)
    {
        string sql = "UPDATE tblPackage SET " +
                    "packageName = @packageName, " +
                    "limitId= @limitId, " +
                    "subAccontCount= @subAccontCount, " +
                     "diengiai= @diengiai, " +
                     "isActive= @isActive " +
                    " WHERE packageId = @packageId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;

        cmd.Parameters.Add("@packageName", SqlDbType.NVarChar).Value = dt.packageName;
        cmd.Parameters.Add("@limitId", SqlDbType.Int).Value = dt.limitId;
        cmd.Parameters.Add("@subAccontCount", SqlDbType.Int).Value = dt.subAccontCount;
        cmd.Parameters.Add("@diengiai", SqlDbType.NVarChar).Value = dt.diengiai;
        cmd.Parameters.Add("@isActive", SqlDbType.Bit).Value = dt.isActive;
        cmd.Parameters.Add("@packageId", SqlDbType.Int).Value = dt.packageId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }


    internal bool deletePackageFuntion(int packageID)
    {
        string sql = "delete tblPackageFunction where packageid=@packageId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;

        cmd.Parameters.Add("@packageId", SqlDbType.Int).Value = packageID;
        int i= cmd.ExecuteNonQuery();
        cmd.Dispose();
        return i > 0;
    }

    internal bool addFunction(int packageID, int functionId)
    {
        string sql = "insert into tblPackageFunction values( @packageId,@functionid)";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;

        cmd.Parameters.Add("@packageId", SqlDbType.Int).Value = packageID;
        cmd.Parameters.Add("@functionId", SqlDbType.Int).Value = functionId;
        int i = cmd.ExecuteNonQuery();
        cmd.Dispose();
        return i > 0;
    }
}