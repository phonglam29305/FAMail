using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Class2
/// </summary>
public class Class2
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter da;
    SqlDataReader dr;
    static string chuoiketnoi = @"Data Source=27.0.14.133;Initial Catalog=1onlinebusinesssystem.com;Persist Security Info=True;User ID=SendMailVersion3;Password=123456789";

        
    
    public DataTable laydulieu(string sql)
    {
        con = new SqlConnection(chuoiketnoi);
        
        con.Open();
        cmd = new SqlCommand(sql, con);
        da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public int thucthi(string sql)
    {
        try
        {
            con = new SqlConnection(chuoiketnoi);
            con.Open();
            cmd = new SqlCommand(sql, con);
            return cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            return -1;
        }
        return 0;

    }
    public  bool KiemtraDN(string user, string pass)
    {
        con = new SqlConnection(chuoiketnoi);
        con.Open();
        string sql = "select * from khachhang where email=@user and matkhau=@pass";
        cmd = new SqlCommand(sql, con);
       
        SqlParameter pa1 = new SqlParameter();
        pa1.ParameterName = "user";
        pa1.Value = user;
        cmd.Parameters.Add(pa1);
        SqlParameter pa2 = new SqlParameter();
        pa2.ParameterName = "pass";
        pa2.Value = pass;
        cmd.Parameters.Add(pa2);

        dr = cmd.ExecuteReader();
        bool kt = false;
        if (dr.HasRows)
            kt = true;
        return kt;
    }
}