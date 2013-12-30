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
using System.Data.SqlClient;
using Email;
using System.Security.Cryptography;
/// <summary>
/// Summary description for UserLoginDAO
/// </summary>
public class UserLoginDAO
{
    public UserLoginDAO()
    {

    }
    public void tblUserLogin_insert(UserLoginDTO dt)
    {
        string sql = "INSERT INTO tblUserLogin(Username, Password,DepartmentId, UserType,Is_Block,Deleted) " +
                     "VALUES(@Username, @Password, @departmentId, @UserType,@Is_Block,@Deleted)";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = dt.Username;
        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = dt.Password;
        cmd.Parameters.Add("@departmentId", SqlDbType.Int).Value = dt.DepartmentId;
        cmd.Parameters.Add("@UserType", SqlDbType.Int).Value = dt.UserType;
        cmd.Parameters.Add("@Is_Block", SqlDbType.Bit).Value = dt.Is_Block;
        cmd.Parameters.Add("@Deleted", SqlDbType.Bit).Value = dt.Deleted;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }


    public void tblUserLoginSubClient_insert(UserLoginDTO dt)
    {
        string sql = "INSERT INTO tblUserLogin(Username, Password, UserType,Is_Block,DepartmentId) " +
                     "VALUES(@Email, @Password, @UserType,@Is_Block,@UserId) ";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = dt.Email;
        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = dt.Password;
        cmd.Parameters.Add("@UserType", SqlDbType.Int).Value = dt.UserType;
        cmd.Parameters.Add("@Is_Block", SqlDbType.Bit).Value = dt.Is_Block;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = dt.UserId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();


    }

    public void tblSubClient_insert(UserLoginDTO dt)
    {
        string sql = "INSERT INTO tblSubClient(subName,subEmail,clientId, userId,Is_Block) " +
                     "VALUES(@subName,@subEmail, @clientId, @userId,@Is_Block)";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@subName", SqlDbType.NVarChar).Value = dt.Username;
        cmd.Parameters.Add("@subEmail", SqlDbType.NVarChar).Value = dt.Email;
        cmd.Parameters.Add("@clientId", SqlDbType.Int).Value = dt.ClientID;
        cmd.Parameters.Add("@userId", SqlDbType.Int).Value = dt.UserId;
        cmd.Parameters.Add("@Is_Block", SqlDbType.Bit).Value = dt.Is_Block;
        cmd.ExecuteNonQuery();
        cmd.Dispose();


        //SqlCommand cmd = new SqlCommand();
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.CommandText = "pro_add_tblsubclient";
        //cmd.Parameters.Add("@subName", SqlDbType.NVarChar).Value = dt.Username;
        //cmd.Parameters.Add("@subEmail", SqlDbType.NVarChar).Value = dt.Email;
        //cmd.Parameters.Add("@clientId", SqlDbType.Int).Value = dt.ClientID;
        //cmd.Parameters.Add("@userId", SqlDbType.Int).Value = dt.UserId;
        //cmd.Parameters.Add("@Is_Block", SqlDbType.Bit).Value = dt.Is_Block;
        //cmd.Parameters.Add("@subId", SqlDbType.Int).Direction = ParameterDirection.Output;
        //cmd.Connection = ConnectionData._MyConnection;
        //try
        //{
        //    ConnectionData._MyConnection.Open();
        //    cmd.ExecuteNonQuery();
        //    string subId = cmd.Parameters["@subId"].Value.ToString();

        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
        //finally
        //{
        //    ConnectionData._MyConnection.Close();
        //    ConnectionData._MyConnection.Dispose();
        //}

    }
    public void tblUserLogin_Update(UserLoginDTO dt)
    {
        string sql = "UPDATE tblUserLogin SET " +
                "Password = @Password, " +
                "userType = @UserType, " +
                 "Is_Block = @Is_Block " +
                " WHERE UserId = @UserId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = dt.UserId;
        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = dt.Password;
        cmd.Parameters.Add("@UserType", SqlDbType.NVarChar).Value = dt.UserType;
        cmd.Parameters.Add("@Is_Block", SqlDbType.Bit).Value = dt.Is_Block;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public void tblSubClient_Update(UserLoginDTO dt)
    {
        string sql = "UPDATE tblSubClient SET " +
                 "Is_Block = @Is_Block " +
                " WHERE subId = @subId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@subId", SqlDbType.Int).Value = dt.SubId;
        cmd.Parameters.Add("@subEmail", SqlDbType.NVarChar).Value = dt.Email;
        cmd.Parameters.Add("@Is_Block", SqlDbType.Bit).Value = dt.Is_Block;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public void tblUserLoginSub_Update(string userId, bool Is_Block)
    {
        string sql = "UPDATE tblUserLogin SET " +
                 "Is_Block = @Is_Block " +
                     " WHERE Username = @UserId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = userId;
        cmd.Parameters.Add("@Is_Block", SqlDbType.Bit).Value = Is_Block;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public void tblUserLogin_UpdateSendMail(int userId, int hasSendMail)
    {
        string sql = "UPDATE tblUserLogin SET " +
                " hasSendMail = @hasSendMail " +
                " WHERE UserId = @UserId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
        cmd.Parameters.Add("@hasSendMail", SqlDbType.Int).Value = hasSendMail;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public void tblUserLogin_UpdateByDepartmentId(int departmentId, int hasSendMail)
    {
        string sql = "UPDATE tblUserLogin SET " +
                " hasSendMail = @hasSendMail " +
                " WHERE departmentId = @departmentId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@departmentId", SqlDbType.Int).Value = departmentId;
        cmd.Parameters.Add("@hasSendMail", SqlDbType.Int).Value = hasSendMail;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblUserLogin_Delete(int userId)
    {
        string sql = "DELETE FROM tblUserLogin WHERE UserId = @UserId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public void tblUserLoginSub_Delete(string userId)
    {
        string sql = "Update tblUserLogin set deleted =1 WHERE Username = @UserId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = userId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public void tblSubClient_Delete(int subId)
    {
        string sql = "Update tblSubClient set deleted = 1 WHERE subId = @subId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@subId", SqlDbType.Int).Value = subId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetAll()
    {
        string sql = "SELECT * FROM vw_tblUserLogin";
        SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }

    public DataTable GetAllByUserId(int userId)
    {
        string sql = "SELECT * FROM vw_tblUserLogin WHERE UserId = @UserId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }


    public DataTable GetSubClientUserID(int clientID)
    {
        string sql = "SELECT * FROM vw_tblSubClient WHERE ClientId = @clientID";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@clientID", SqlDbType.Int).Value = clientID;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }


    public DataTable GetSubClientDepart3(int userID)
    {
        string sql = "SELECT * FROM vw_tblSubClient WHERE userId = @userID";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetSubClient()
    {
        string sql = "SELECT * FROM vw_tblSubClient";
        SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }

    public DataTable GetClientId(int UserId)
    {
        string sql = "SELECT * FROM tblClient WHERE UserId = @UserId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetClientIdSub(int UserId)
    {
        string sql = "SELECT * FROM tblSubClient WHERE UserId = @UserId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }


    public DataTable GetSubAccountCount(int ClientId)
    {
        string sql = "SELECT subAccontCount FROM tblClientRegister WHERE ClientID = @ClientId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = ClientId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetEmail(string email)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblSubClient WHERE  subEmail = @email", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email.Trim();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }


    public DataTable GetEmailByUser(int subId, string email)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblSubClient WHERE subId != @subId AND subEmail = @email", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@subId", SqlDbType.Int).Value = subId;
        cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email.Trim();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetCountSubClient(int ClientId)
    {
        string sql = "SELECT count(*) as numberSub FROM tblSubClient WHERE ClientID = @ClientId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = ClientId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetUserIdBySubID(int subId)
    {
        string sql = "SELECT * FROM tblSubClient WHERE subId = @subId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@subId", SqlDbType.Int).Value = subId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetByUserId(int UserId)
    {
        string sql = "SELECT * FROM tblUserLogin WHERE UserId = @UserId and deleted =0";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetIsBlockByUserId(string username)
    {
        string sql = "SELECT * FROM tblUserLogin WHERE Username = @username and deleted =0";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }


    public DataTable GetUserIDByUserName(string Username)
    {
        string sql = "SELECT * FROM tblUserLogin WHERE Username = @Username and deleted =0";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = Username;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetBySubId(int subId)
    {
        string sql = "SELECT * FROM tblSubClient WHERE subId = @subId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@subId", SqlDbType.Int).Value = subId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetByUsername(string username)
    {
        string sql = "SELECT * FROM tblUserLogin WHERE Username = @Username and deleted = 0";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
    public DataTable GetByUsernameAndPass(string username, string password)
    {
        string sql = "SELECT * FROM tblUserLogin WHERE Username = @Username AND Password = @Password and deleted =0";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
        cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetByDepartmentId(int departmentId)
    {
        string sql = "SELECT * FROM tblUserLogin WHERE DepartmentId = @DepartmentId and deleted =0";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = departmentId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    /// <summary>
    /// tam add
    /// </summary>
    /// <param name="departmentId"></param>
    /// <returns></returns>
    public DataTable GetByUserType(int departmentId)
    {
        string sql = "SELECT * FROM tblDepartment WHERE ID = @DepartmentId ";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = departmentId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

}
