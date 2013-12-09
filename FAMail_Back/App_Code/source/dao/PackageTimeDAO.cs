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
/// Summary description for PackageTimeDAO
/// </summary>
public class PackageTimeDAO
{
	public PackageTimeDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void tblPackageTime_insert(PackageTimeDTO dt)
    {
        string sql = "INSERT INTO tblPackageTime (monthCount,discount) " +
                     "VALUES( @monthCount, @discount)";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@monthCount", SqlDbType.Int).Value = dt.monthCount;
        cmd.Parameters.Add("@discount", SqlDbType.Int).Value = dt.discount;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public DataTable GetAll()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblPackageTime ",
        ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }

    public DataTable GetByUserId(int packageTimeId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblPackageTime WHERE packageTimeId = @packageTimeId",
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@packageTimeId", SqlDbType.Int).Value = packageTimeId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
    public bool tblPackageTime_Delete(int packageTimeId)
    {
        int i = 0;
        try
        {
            if (ConnectionData._MyConnection.State == ConnectionState.Closed)
            {
                ConnectionData._MyConnection.Open();
            }
            SqlCommand cmd = new SqlCommand("DELETE FROM tblpackageTime WHERE packageTimeId = @packageTimeId",
                ConnectionData._MyConnection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@packageTimeId", SqlDbType.Int).Value = packageTimeId;
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





    public void tblpackageTime_Update(PackageTimeDTO dt)
    {
        string sql = "UPDATE tblpackageTime SET " +
                    "monthCount = @monthCount, " +
                    "discount = @discount " +
                    " WHERE packageTimeId = @packageTimeId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@packageTimeId", SqlDbType.Int).Value = dt.packageTimeId;
        cmd.Parameters.Add("@monthCount", SqlDbType.Int).Value = dt.monthCount;
        cmd.Parameters.Add("@discount", SqlDbType.Int).Value = dt.discount;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }


}