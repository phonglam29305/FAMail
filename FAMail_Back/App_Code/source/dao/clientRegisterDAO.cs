using Email;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClientRegisterDAO
/// </summary>
public class ClientRegisterDAO
{
    public ClientRegisterDAO()
    {

    }
    public DataTable GetByID(int Id)
    {
        SqlCommand cmd = new SqlCommand("Select * from tblClientRegister where registerId=@registerId", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@registerId", SqlDbType.NVarChar).Value = Id;
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
    public DataTable Search_client_register(string clientName, string namepackagelimit, string registerTime_from, string registerTime_to, string expireDate_from, string expireDate_to)
    {
        SqlCommand cmd = new SqlCommand("Client_Search_register", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@clientName", SqlDbType.NVarChar).Value = clientName;
        cmd.Parameters.Add("@namepackagelimit", SqlDbType.Int).Value = namepackagelimit;
        cmd.Parameters.Add("@registerTime_from", SqlDbType.VarChar, 12).Value = registerTime_from;
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
    public int UpdateUpgrade(int clientId, int packageId, int limitId, int SubAccount, float totalFee, int registerType, int packagetimeid, string From, string To, string LastRegisterFrom, string LastRegisterTo, int LastRegisterFee, int LastRegisterFeeRemain)
    {
        string sql = "set dateformat dmy Insert Into tblClientRegister (clientId,packageId,limitId,subAccontCount,totalFee,registerType,packageTimeId,[from],[to],lastRegisterFrom,lastRegisterTo,lastRegisterFee,lastRegisterFeeRemain,registerTime,registerDate) values (@clientId,@packageId,@limitId,@subAccontCount,@totalFee,@registerType,@packageTimeId,@from,@to,@lastRegisterFrom,@lastRegisterTo,@lastRegisterFee,@lastRegisterFeeRemain,getdate(),'" + DateTime.Now.ToString("dd/MM/yyyy") + "') Select @@identity";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@clientId", SqlDbType.Int).Value = clientId;
        cmd.Parameters.Add("@packageId", SqlDbType.Int).Value = packageId;
        cmd.Parameters.Add("@limitId", SqlDbType.Int).Value = limitId;
        cmd.Parameters.Add("@subAccontCount", SqlDbType.Int).Value = SubAccount;
        cmd.Parameters.Add("@totalFee", SqlDbType.Float).Value = totalFee;
        cmd.Parameters.Add("@registerType", SqlDbType.Int).Value = registerType;
        cmd.Parameters.Add("@packageTimeId", SqlDbType.Int).Value = packagetimeid;
        cmd.Parameters.Add("@from", SqlDbType.VarChar).Value = From;
        cmd.Parameters.Add("@to", SqlDbType.VarChar).Value = To;
        cmd.Parameters.Add("@lastRegisterFrom", SqlDbType.VarChar).Value = LastRegisterFrom;
        cmd.Parameters.Add("@lastRegisterTo", SqlDbType.VarChar).Value = LastRegisterTo;
        cmd.Parameters.Add("@lastRegisterFee", SqlDbType.Float).Value = LastRegisterFee;
        cmd.Parameters.Add("@lastRegisterFeeRemain", SqlDbType.Float).Value = LastRegisterFeeRemain;
        //cmd.Parameters.Add("@registerTime", SqlDbType.VarChar).Value = registerTime;
        //cmd.Parameters.Add("@registerDate", SqlDbType.VarChar).Value = registerDate;
        object id = cmd.ExecuteScalar();
        cmd.Dispose();
        return Int32.Parse(id + "");
    }
}