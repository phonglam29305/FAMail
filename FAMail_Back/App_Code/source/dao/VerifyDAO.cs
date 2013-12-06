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

/// <summary>
/// Summary description for VerifyDAO
/// </summary>
public class VerifyDAO
{
    public VerifyDAO()
	{
	}
    public void tblVerify_insert(VerifyDTO dt)
    {
        string sql = "INSERT INTO tblVerify(EmailVerify, UserId) " +
                     "VALUES(@EmailVerify, @UserId)";
        SqlCommand   cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@EmailVerify", SqlDbType.VarChar).Value = dt.EmailVerify;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = dt.userId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public void tblVerify_Delete(string email)
    {
        string sql = "DELETE FROM tblVerify WHERE EmailVerify = @EmailVerify ";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@EmailVerify", SqlDbType.VarChar).Value = email;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetAll()
    {
        string sql = "SELECT * FROM tblVerify";
        SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public DataTable GetByUserId(int userId)
    {
        string sql = "SELECT * FROM tblVerify WHERE UserId = @UserId";
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
    public DataTable GetByEmail(string EmailVerify)
    {
        string sql = "SELECT * FROM tblVerify WHERE EmailVerify = @EmailVerify";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@EmailVerify", SqlDbType.NVarChar).Value = EmailVerify;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
    
}
