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
/// Summary description for SMTPaccountDAO
/// </summary>
public class SMTPaccountDAO
{
	public SMTPaccountDAO()
	{		
	}
    public void insertSMTP(SMTPaccountDTO dt)
    {
        string sql = "insert into tblSMTPaccount (Email,Password,Accesskey,Secreckey,PasswordSMTP,ServerSMTP,UsernameSMTP,Limit)values(@Email,@Password,@Accesskey,@Secreckey,@PasswordSMTP,@ServerSMTP,@UsernameSMTP,@Limit)";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = dt.Email;
        cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = dt.Password;
        cmd.Parameters.Add("@Accesskey", SqlDbType.VarChar).Value = dt.Accesskey;
        cmd.Parameters.Add("@Secreckey", SqlDbType.VarChar).Value = dt.Secreckey;
        cmd.Parameters.Add("@PasswordSMTP", SqlDbType.VarChar).Value = dt.PasswordSMTP;
        cmd.Parameters.Add("@ServerSMTP", SqlDbType.VarChar).Value = dt.ServerSMTP;
        cmd.Parameters.Add("@UsernameSMTP", SqlDbType.VarChar).Value = dt.UsernameSMTP;
        cmd.Parameters.Add("@Limit", SqlDbType.VarChar).Value = dt.Limit;
        cmd.ExecuteNonQuery();

    }
}