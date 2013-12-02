using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text.RegularExpressions;

public partial class webapp_page_backend_PreviewContent : System.Web.UI.Page
{

    HtmlMailRuleBUS hmrBUS = null;
    string _contentmail = "";
     string gmailC = "";
            string yahooC = "";
            string aolC = "";
            string oulookC = "";
            string contentCheck = "";
            string contentCheckGmail = "";
            string contentCheckYahoo = "";
            string contentCheckHotmail = "";
            string contentCheckOutlook = "";
            string contentCheckAol = "";
            string contentGmail = "";
            string contentYahoo = "";
            string contentHotmail = "";
            string contentOutlook = "";
            string contentAol = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {
                 _contentmail = Session["Content"].ToString();
                 Session["contentGmail"] = null;
                 Session["contentYahoo"] = null;
                 Session["contentHotmail"] = null;
                 Session["contentOutlook"] = null;
                 Session["contentAol"] = null;
                lblContent.Text = _contentmail;
                hmrBUS = new HtmlMailRuleBUS();
                CheckHtmlCSS();
            }
        }
        catch (Exception)
        {
            
           
        }
    }

    private void CheckHtmlCSS()
    {
        string gmail, hotmail, yahoo, aol, oulook, att;
        string hotmailC = "";
        DataTable rule= new DataTable();
        hmrBUS = new HtmlMailRuleBUS();
        rule = hmrBUS.GetAll();
        
        if(rule.Rows.Count>0)
        {
            foreach (DataRow row in rule.Rows)
            {
                att = row["Attribute"].ToString();               
                gmail = row["Gmail"].ToString();
                yahoo = row["YahooMail"].ToString();
                aol = row["AOLMail"].ToString();
                hotmail = row["WindowsLiveMail2011"].ToString();
                oulook = row["Outlook071013"].ToString();

                if (_contentmail.Contains(att) == true)
                {
                    if (bool.Parse(gmail) == false)
                    {
                        gmailC += String.Format("- Thuộc tính: {0} sẽ không hiện thị với Gmail </br>", att);
                        
                        if (contentGmail == "")
                        {
                            contentGmail = _contentmail.Replace(att, "");
                            Session["contentGmail"] = contentGmail;
                        }
                        else
                        {
                            contentGmail = Session["contentGmail"].ToString();
                            contentGmail = contentGmail.Replace(att, "");
                            Session["contentGmail"] = contentGmail;
                        }
                    }
                    else if (bool.Parse(yahoo) == false)
                    {
                        yahooC += String.Format("- Thuộc tính: {0} sẽ không hiện thị với Yahoo Mail </br>", att);
                        if (contentYahoo == "")
                        {
                            contentYahoo = _contentmail.Replace(att, "");
                            Session["contentYahoo"] = contentYahoo;
                        }
                        else
                        {
                            contentYahoo = Session["contentYahoo"].ToString();
                            contentYahoo = contentYahoo.Replace(att, "");
                            Session["contentYahoo"] = contentYahoo;
                        }
                    }
                    else if (bool.Parse(aol) == false)
                    {
                        aolC += String.Format("- Thuộc tính: {0} sẽ không hiện thị với AOL Mail </br>", att);
                        if (contentAol == "")
                        {
                            contentAol = _contentmail.Replace(att, "");
                            Session["contentAol"] = contentAol;
                        }
                        else
                        {
                            contentAol = Session["contentAol"].ToString();
                            contentAol = contentAol.Replace(att, "");
                            Session["contentAol"] = contentAol;
                        }

                    }
                    else if (bool.Parse(hotmail) == false)
                    {
                        hotmailC += String.Format("- Thuộc tính: {0} sẽ không hiện thị với Hotmail </br>", att);
                        if (contentHotmail == "")
                        {
                            contentHotmail = _contentmail.Replace(att, "");
                            Session["contentHotmail"] = contentHotmail;
                        }
                        else
                        {
                            contentHotmail = Session["contentHotmail"].ToString();
                            contentHotmail = contentHotmail.Replace(att, "");
                            Session["contentHotmail"] = contentHotmail;
                        }
                    }
                    else if (bool.Parse(oulook) == false)
                    {
                        oulookC += String.Format("- Thuộc tính: {0} sẽ không hiện thị với Outlook </br>", att);
                        if (contentOutlook == "")
                        {
                            contentOutlook = _contentmail.Replace(att, "");
                            Session["contentOutlook"] = contentOutlook;
                        }
                        else
                        {
                            contentOutlook = Session["contentOutlook"].ToString();
                            contentOutlook = contentOutlook.Replace(att, "");
                            Session["contentOutlook"] = contentOutlook;
                        }
                    }
               
                }
            }
            
            contentCheck += hotmailC;
            contentCheck += oulookC;
            contentCheck += yahooC;
            contentCheck += aolC;
            if (gmailC != "")
            {
                contentCheckGmail += "<div class='error-box round gmail'>";
                contentCheckGmail += gmailC;
                contentCheckGmail += "</div>";
            }
            else
            {
                contentCheckGmail += "<div class='confirmation-box round gmail'>";
                contentCheckGmail += "Nội dung này hiện thị tốt với Gmail";
                contentCheckGmail += "</div>";
            }
            if (hotmailC != "")
            {
                contentCheckHotmail += "<div class='error-box round'>";
                contentCheckHotmail += hotmailC;
                contentCheckHotmail += "</div>";
            }
            else
            {
                contentCheckHotmail += "<div class='confirmation-box round'>";
                contentCheckHotmail += "Nội dung này hiện thị tốt với Hotmail";
                contentCheckHotmail += "</div>";
            }
            if (oulookC != "")
            {
                contentCheckOutlook += "<div class='error-box round'>";
                contentCheckOutlook += oulookC;
                contentCheckOutlook += "</div>";
            }
            else
            {
                contentCheckOutlook += "<div class='confirmation-box round'>";
                contentCheckOutlook += "Nội dung này hiện thị tốt với Outlook";
                contentCheckOutlook += "</div>";
            }
            if (yahooC != "")
            {
                contentCheckYahoo += "<div class='error-box round '>";
                contentCheckYahoo += yahooC;
                contentCheckYahoo += "</div>";
            }
            else
            {
                contentCheckYahoo += "<div class='confirmation-box round'>";
                contentCheckYahoo += "Nội dung này hiện thị tốt với Yahoo mail";
                contentCheckYahoo += "</div>";
            }
            if (aolC != "")
            {
                contentCheckAol += "<div class='error-box round'>";
                contentCheckAol += aolC;
                contentCheckAol += "</div>";
            }
            else
            {
                contentCheckAol += "<div class='confirmation-box round'>";
                contentCheckAol += "Nội dung này hiện thị tốt với AOL Mail";
                contentCheckAol += "</div>";
            }

            this.lblGmail.Text = contentCheckGmail + contentCheckHotmail + contentCheckYahoo + contentCheckOutlook + contentCheckAol;
           
            
            
        }
    }


    protected void btnDefault_Click(object sender, EventArgs e)
    {
       _contentmail = Session["Content"].ToString();
        CheckHtmlCSS();
        lblContent.Text = _contentmail;
    }
    protected void btnGmal_Click(object sender, EventArgs e)
    {
        _contentmail = Session["Content"].ToString();
        CheckHtmlCSS();
        
        try
        {
            lblContent.Text = Session["contentGmail"].ToString();
        }
        catch (Exception)
        {

            lblContent.Text = _contentmail;
        }
    }
    protected void btnYahoo_Click(object sender, EventArgs e)
    {
        _contentmail = Session["Content"].ToString();
        CheckHtmlCSS();
       
        try
        {
            lblContent.Text = Session["contentYahoo"].ToString();
        }
        catch (Exception)
        {

            lblContent.Text = _contentmail;
        }
    }
    protected void btnHotmail_Click(object sender, EventArgs e)
    {
        _contentmail = Session["Content"].ToString();
        CheckHtmlCSS();
       
        try
        {
            lblContent.Text = Session["contentHotmail"].ToString();
        }
        catch (Exception)
        {

            lblContent.Text = _contentmail;
        }
       
    }
    protected void btnOutlook_Click(object sender, EventArgs e)
    {
        _contentmail = Session["Content"].ToString();
        CheckHtmlCSS();
        try{
             lblContent.Text = Session["contentOutlook"].ToString();
         }
        catch (Exception)
        {

            lblContent.Text = _contentmail;
        }
    }
    protected void btnAOL_Click(object sender, EventArgs e)
    {
        _contentmail = Session["Content"].ToString();
        CheckHtmlCSS();
        try
        {
            lblContent.Text = Session["contentAol"].ToString();
        }
        catch (Exception)
        {

            lblContent.Text = _contentmail;
        }
       
    }
}
