using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using Email;

/// <summary>
/// Summary description for HtmlMailRuleDAO
/// </summary>
public class HtmlMailRuleDAO
{
    SqlCommand cmd = null;
	public HtmlMailRuleDAO()
	{
		//
		// TODO: Add constructor logic here
		//
        
	}
    public void tblHtmlMailRule_insert(HtmlMailRuleDTO dt)
    {
        string sql = "INSERT INTO tblHtmlMailRule VALUES(@Attribute, @Outlookcom, @YahooMail, @Gmail, @AOLMail, "+
                      "@Outlook071013, @OutlookExpress, @WindowsLiveMail2011, @Notes67, @LotusNotes85, "+
                     "@AOLDesktop10, @AppleMail65, @Postbox, @Thunderbird17, @iPhoneiOS7iPad, "+
                     "@Blackberry6, @Android4, @GmailMobile, @WindowsMobile75)";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Attribute", SqlDbType.VarChar).Value = dt.Attribute;
        cmd.Parameters.Add("@Outlookcom", SqlDbType.Bit).Value = dt.Outlookcom;
        cmd.Parameters.Add("@YahooMail", SqlDbType.Bit).Value = dt.YahooMail;
        cmd.Parameters.Add("@Gmail", SqlDbType.Bit).Value = dt.Gmail;
        cmd.Parameters.Add("@AOLMail", SqlDbType.Bit).Value = dt.AOLMail;
        cmd.Parameters.Add("@Outlook071013", SqlDbType.Bit).Value = dt.Outlook071013;
        cmd.Parameters.Add("@OutlookExpress", SqlDbType.Bit).Value = dt.OutlookExpress;
        cmd.Parameters.Add("@WindowsLiveMail2011", SqlDbType.Bit).Value = dt.WindowsLiveMail2011;
        cmd.Parameters.Add("@Notes67", SqlDbType.Bit).Value = dt.Notes67;
        cmd.Parameters.Add("@LotusNotes85", SqlDbType.Bit).Value = dt.LotusNotes85;
        cmd.Parameters.Add("@AOLDesktop10", SqlDbType.Bit).Value = dt.AOLDesktop10;
        cmd.Parameters.Add("@AppleMail65", SqlDbType.Bit).Value = dt.AppleMail65;
        cmd.Parameters.Add("@Postbox", SqlDbType.Bit).Value = dt.Postbox;
        cmd.Parameters.Add("@Thunderbird17", SqlDbType.Bit).Value = dt.Thunderbird17;
        cmd.Parameters.Add("@iPhoneiOS7iPad", SqlDbType.Bit).Value = dt.iPhoneiOS7iPad;
        cmd.Parameters.Add("@Blackberry6", SqlDbType.Bit).Value = dt.Blackberry6;
        cmd.Parameters.Add("@Android4", SqlDbType.Bit).Value = dt.Android4;
        cmd.Parameters.Add("@GmailMobile", SqlDbType.Bit).Value = dt.GmailMobile;
        cmd.Parameters.Add("@WindowsMobile75", SqlDbType.Bit).Value = dt.WindowsMobile75;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblHtmlMailRule_Update(HtmlMailRuleDTO dt)
    {
        string sql = "UPDATE tblHtmlMailRule SET "+
	                "Outlookcom = @Outlookcom, "+
	                "YahooMail = @YahooMail, "+
	                "Gmail = @Gmail, "+
	                "AOLMail = @AOLMail, "+
	                "Outlook071013 = @Outlook071013, "+
	                "OutlookExpress = @OutlookExpress, "+
	                "WindowsLiveMail2011 = @WindowsLiveMail2011, "+
	                "Notes67 = @Notes67, "+
	                "LotusNotes85 = @LotusNotes85, "+
	                "AOLDesktop10 = @AOLDesktop10, "+
	                "AppleMail65 = @AppleMail65, "+
	                "Postbox = @Postbox, "+
	                "Thunderbird17 = @Thunderbird17, "+
	                "iPhoneiOS7iPad = @iPhoneiOS7iPad, "+
	                "Blackberry6 = @Blackberry6, "+
	                "Android4 = @Android4, "+
	                "GmailMobile = @GmailMobile, "+
	                "WindowsMobile75 = @WindowsMobile75	WHERE Attribute = @Attribute ";

        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Attribute", SqlDbType.VarChar).Value = dt.Attribute;
        cmd.Parameters.Add("@Outlookcom", SqlDbType.Bit).Value = dt.Outlookcom;
        cmd.Parameters.Add("@YahooMail", SqlDbType.Bit).Value = dt.YahooMail;
        cmd.Parameters.Add("@Gmail", SqlDbType.Bit).Value = dt.Gmail;
        cmd.Parameters.Add("@AOLMail", SqlDbType.Bit).Value = dt.AOLMail;
        cmd.Parameters.Add("@Outlook071013", SqlDbType.Bit).Value = dt.Outlook071013;
        cmd.Parameters.Add("@OutlookExpress", SqlDbType.Bit).Value = dt.OutlookExpress;
        cmd.Parameters.Add("@WindowsLiveMail2011", SqlDbType.Bit).Value = dt.WindowsLiveMail2011;
        cmd.Parameters.Add("@Notes67", SqlDbType.Bit).Value = dt.Notes67;
        cmd.Parameters.Add("@LotusNotes85", SqlDbType.Bit).Value = dt.LotusNotes85;
        cmd.Parameters.Add("@AOLDesktop10", SqlDbType.Bit).Value = dt.AOLDesktop10;
        cmd.Parameters.Add("@AppleMail65", SqlDbType.Bit).Value = dt.AppleMail65;
        cmd.Parameters.Add("@Postbox", SqlDbType.Bit).Value = dt.Postbox;
        cmd.Parameters.Add("@Thunderbird17", SqlDbType.Bit).Value = dt.Thunderbird17;
        cmd.Parameters.Add("@iPhoneiOS7iPad", SqlDbType.Bit).Value = dt.iPhoneiOS7iPad;
        cmd.Parameters.Add("@Blackberry6", SqlDbType.Bit).Value = dt.Blackberry6;
        cmd.Parameters.Add("@Android4", SqlDbType.Bit).Value = dt.Android4;
        cmd.Parameters.Add("@GmailMobile", SqlDbType.Bit).Value = dt.GmailMobile;
        cmd.Parameters.Add("@WindowsMobile75", SqlDbType.Bit).Value = dt.WindowsMobile75;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblHtmlMailRule_Delete(string Attribute)
    {
        string sql = "DELETE FROM tblHtmlMailRule WHERE Attribute = @Attribute";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Attribute", SqlDbType.VarChar).Value = Attribute;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
      }
    public DataTable GetAll()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblHtmlMailRule", ConnectionData._MyConnection);
        DataTable table = new DataTable();
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public DataTable GetByID(string Attribute)
    {
        string sql = "SELECT * FROM tblHtmlMailRule WHERE Attribute = @Attribute";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Attribute", SqlDbType.VarChar).Value = Attribute;
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
