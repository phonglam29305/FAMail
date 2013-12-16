﻿using System;
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
        string sql = "INSERT INTO tblUserLogin(Username, Password,DepartmentId, UserType,Is_Block) " +
                     "VALUES(@Username, @Password, @departmentId, @UserType,@Is_Block)";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = dt.Username;
        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = dt.Password;
        cmd.Parameters.Add("@departmentId", SqlDbType.Int).Value = dt.DepartmentId;
        cmd.Parameters.Add("@UserType", SqlDbType.Int).Value = dt.UserType;
        cmd.Parameters.Add("@Is_Block", SqlDbType.Bit).Value = dt.Is_Block;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }


    public void tblUserLoginSubClient_insert(UserLoginDTO dt)
    {
        string sql = "INSERT INTO tblUserLogin(Username, Password, UserType,Is_Block) " +
                     "VALUES(@Email, @Password, @UserType,@Is_Block)";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = dt.Email;
        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = dt.Password;
        cmd.Parameters.Add("@UserType", SqlDbType.Int).Value = dt.UserType;
        cmd.Parameters.Add("@Is_Block", SqlDbType.Bit).Value = dt.Is_Block;
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
                "subEmail = @subEmail, " +
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

    public void tblUserLoginSub_Update(int userId, bool Is_Block)
    {
        string sql = "UPDATE tblUserLogin SET " +
                 "Is_Block = @Is_Block " +
                     " WHERE UserId = @UserId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
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

    public void tblSubClient_Delete(int subId)
    {
        string sql = "DELETE FROM tblSubClient WHERE subId = @subId";
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
        string sql = "SELECT * FROM tblUserLogin WHERE UserId = @UserId";
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

    public DataTable GetIsBlockByUserId(int UserId)
    {
        string sql = "SELECT * FROM tblUserLogin WHERE UserId = @UserId";
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


    public DataTable GetUserIDByUserName(string Username)
    {
        string sql = "SELECT * FROM tblUserLogin WHERE Username = @Username";
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
        string sql = "SELECT * FROM tblUserLogin WHERE Username = @Username";
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
        string sql = "SELECT * FROM tblUserLogin WHERE Username = @Username AND Password = @Password";
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
        string sql = "SELECT * FROM tblUserLogin WHERE DepartmentId = @DepartmentId";
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
        string sql = "SELECT * FROM tblDepartment WHERE ID = @DepartmentId";
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
