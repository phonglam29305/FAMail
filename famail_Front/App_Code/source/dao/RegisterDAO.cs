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

    public DataTable GetByUserId(int id)
    {
        SqlCommand cmd = new SqlCommand("Package_GetALL",
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
        SqlCommand cmd = new SqlCommand("SP_Package_GetById " + id, ConnectionData._MyConnection);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;

    }
    public int Insert_Client(clientdto client, clientRegisterdto clientRegister, UserLoginDTO ulDto)
    {
        string sql = "insert into tblClient (clientName,address,email,phone)" +
            "values(@clientName,@address,@email,@phone) select @@identity";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@clientName", SqlDbType.NVarChar).Value = client.clientName;
        cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = client.address;
        cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = client.email;
        cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = client.phone;
        object id = cmd.ExecuteScalar();
        cmd.Dispose();

        sql = @"set dateformat dmy INSERT INTO [tblClientRegister]
           ([clientId]
           ,[packageId]
           ,[limitId]
           ,[subAccontCount]
           ,[emailCount]
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
           ,@emailCount
           ,@totalFee
           ,0
           ,@packageTimeId
           ,@from
           ,@to
           ,null           ,null           ,0           ,0           ,getdate()           ,getdate()) select @@identity";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@clientId", SqlDbType.Int).Value = id;
        cmd.Parameters.Add("@packageId", SqlDbType.Int).Value = clientRegister.packageId;
        cmd.Parameters.Add("@limitId", SqlDbType.Int).Value = clientRegister.limitId;
        cmd.Parameters.Add("@subAccontCount", SqlDbType.Int).Value = clientRegister.subAccontCount;
        cmd.Parameters.Add("@emailCount", SqlDbType.Int).Value = clientRegister.emailCount;
        cmd.Parameters.Add("@totalFee", SqlDbType.Float).Value = clientRegister.totalFee;
        cmd.Parameters.Add("@packageTimeId", SqlDbType.Int).Value = clientRegister.packageTimeId;
        cmd.Parameters.Add("@from", SqlDbType.VarChar, 12).Value = clientRegister.from.ToString("dd/MM/yyyy");
        cmd.Parameters.Add("@to", SqlDbType.VarChar, 12).Value = clientRegister.to.ToString("dd/MM/yyyy");
        object registerid = cmd.ExecuteScalar();
        cmd.Dispose();

        DataTable T = new LoadFunctionPackageDAO().dispalyfunctionpackage(clientRegister.packageId);
        sql = "insert into tblClientFunction(registerId, clientId, functionId) values(@registerId, @clientId, @functionId)";
        if (T != null)
            foreach (DataRow r in T.Rows)
            {
                if (r["functionId"] + "" == "yes")
                {
                    cmd = new SqlCommand(sql, ConnectionData._MyConnection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@functionId", SqlDbType.Int).Value = r["functionId"];
                    cmd.Parameters.Add("@clientId", SqlDbType.Int).Value = clientRegister.clientId;
                    cmd.Parameters.Add("@registerId", SqlDbType.Int).Value = registerid;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }


        sql = "INSERT INTO tblUserLogin(Username, Password, UserType,Is_Block,DepartmentId) " +
                     "VALUES(@Email, @Password, @UserType,@Is_Block,@UserType) select @identity";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = ulDto.Email;
        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = ulDto.Password;
        cmd.Parameters.Add("@UserType", SqlDbType.Int).Value = ulDto.UserType;
        cmd.Parameters.Add("@Is_Block", SqlDbType.Bit).Value = ulDto.Is_Block;
        id = cmd.ExecuteScalar();

        sql = "update tblClient set userid = @userid, registerid=@registerid, activedate=getdate(), expiredate='" + clientRegister.to.ToString("dd/MM/yyyy") + "' where clientid=@clientid";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@userid", SqlDbType.Int).Value = id;
        cmd.Parameters.Add("@clientid", SqlDbType.Int).Value = clientRegister.clientId;
        cmd.Parameters.Add("@registerid", SqlDbType.Int).Value = registerid;
        return cmd.ExecuteNonQuery();
    }


    internal bool CheckExistByEmail(string Email)
    {
        SqlCommand cmd = new SqlCommand("select clientid From tblClient wgere email= " + Email, ConnectionData._MyConnection);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table == null || table.Rows.Count == 0;
    }
}