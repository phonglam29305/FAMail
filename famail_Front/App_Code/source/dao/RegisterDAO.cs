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
/// Summary description for dangkyDAO
/// </summary>
public class RegisterDAO 
{

    public DataTable GetByUserId( int id)
    {
        SqlCommand cmd = new SqlCommand("Package_GetALL ",
           ConnectionData._MyConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

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
    public DataTable GetAllPackagetime()
    {
        SqlCommand cmd = new SqlCommand("select * from tblPackageTime", ConnectionData._MyConnection);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;

    }
    public DataTable GetPackageById(int id)
    {
        SqlCommand cmd = new SqlCommand("SP_Package_GetById "+id, ConnectionData._MyConnection);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;

    }
    public void Insert_Client(clientdto client, clientRegisterdto clientRegister)
    {
        string sql = "insert into tblClient (clientName,address,email,phone)" +
            "values(@clientName,@address,@email,@phone) select @@identity";
        SqlCommand cmd = new SqlCommand(sql,ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@clientName", SqlDbType.NVarChar).Value = client.clientName;
        cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = client.address;
        cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = client.email;
        cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = client.phone;    
       object id= cmd.ExecuteScalar();
        cmd.Dispose();

        sql = @"set dateformat dmy INSERT INTO [tblClientRegister]
           ([clientId]
           ,[packageId]
           ,[limitId]
           ,[subAccontCount]
           ,[totalFee]
           ,[registerType]
           ,[packageTimeId]
           ,[from]
           ,[to]
           ,[lastRegisterFrom]
           ,[lastRegisterTo]
           ,[lastRegisterFee]
           ,[lastRegisterFeeRemain]
           ,[registerTime]
           ,[registerDate])
     VALUES
           (@clientId
           ,@packageId
           ,@limitId
           ,@subAccontCount
           ,@totalFee
           ,0
           ,@packageTimeId
           ,@from
           ,@to
           ,null           ,null           ,0           ,0           ,getdate()           ,getdate())";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@clientId", SqlDbType.Int).Value = id;
        cmd.Parameters.Add("@packageId", SqlDbType.Int).Value = clientRegister.packageId;
        cmd.Parameters.Add("@limitId", SqlDbType.Int).Value = clientRegister.limitId;
        cmd.Parameters.Add("@subAccontCount", SqlDbType.Int).Value = clientRegister.subAccontCount;
        cmd.Parameters.Add("@totalFee", SqlDbType.Float).Value = clientRegister.totalFee;
        cmd.Parameters.Add("@packageTimeId", SqlDbType.Int).Value = clientRegister.packageTimeId;
        cmd.Parameters.Add("@from", SqlDbType.VarChar, 12).Value = clientRegister.from.ToString("dd/MM/yyyy");
        cmd.Parameters.Add("@to", SqlDbType.VarChar, 12).Value = clientRegister.to.ToString("dd/MM/yyyy");
        cmd.ExecuteNonQuery();
        cmd.Dispose();

    }

}