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

/// <summary>
/// Summary description for HtmlMailRuleDTO
/// </summary>
public class HtmlMailRuleDTO
{
	public HtmlMailRuleDTO()
	{
	
	}
    public string Attribute { get; set; }
    public bool Outlookcom { get; set; }
    public bool YahooMail { get; set; }
    public bool Gmail { get; set; }
    public bool AOLMail { get; set; }
    public bool Outlook071013 { get; set; }
    public bool OutlookExpress { get; set; }
    public bool WindowsLiveMail2011 { get; set; }
    public bool Notes67 { get; set; }
    public bool LotusNotes85 { get; set; }
    public bool AOLDesktop10 { get; set; }
    public bool AppleMail65 { get; set; }
    public bool Postbox { get; set; }
    public bool Thunderbird17 { get; set; }
    public bool iPhoneiOS7iPad { get; set; }
    public bool Blackberry6 { get; set; }
    public bool Android4 { get; set; }
    public bool GmailMobile { get; set; }
    public bool WindowsMobile75 { get; set; }

}
