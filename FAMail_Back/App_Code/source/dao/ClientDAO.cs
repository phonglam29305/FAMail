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
using Email;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CustomerDAO
/// </summary>
public class ClientDAO
{
    public ClientDAO()
    {

    }

    public bool Customer_Lock_Unlock(int Id, Common.clientStatus status)
    {
        string sql = "UPDATE tblClient SET " +
                    "status = " + (int)status + " where clientid=" + Id;

        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@clientid", SqlDbType.Int).Value = Id;

        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        int i = cmd.ExecuteNonQuery();
        cmd.Dispose();
        return i > 0;
    }

    public DataTable Search(string name, string email, int sex, bool isCheckExpire, string from, string to)
    {
        SqlCommand cmd = new SqlCommand("SP_Client_Search", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
        cmd.Parameters.Add("@sex", SqlDbType.NVarChar).Value = sex;
        cmd.Parameters.Add("@isCheckExpire", SqlDbType.NVarChar).Value = isCheckExpire;
        cmd.Parameters.Add("@from", SqlDbType.NVarChar).Value = from;
        cmd.Parameters.Add("@to", SqlDbType.NVarChar).Value = to;
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

    public DataTable GetByID(int Id)
    {
        SqlCommand cmd = new SqlCommand("Select * from tblClient where Clientid=@ClientId", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Clientid", SqlDbType.NVarChar).Value = Id;
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

    public DataTable GetByEmail(string Email)
    {
        SqlCommand cmd = new SqlCommand("Select * from tblClient where Email=@Email", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
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
}