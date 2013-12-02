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

public partial class webapp_page_backend_ManageHTMLRule : System.Web.UI.Page
{
    HtmlMailRuleBUS mailRuleBUS = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                LoadData();
            }
            catch (Exception)
            {
                
                
            }
        }
    }

    private void LoadData()
    {
        mailRuleBUS = new HtmlMailRuleBUS();
        dlPager.MaxPages = 1000;
        dlPager.PageSize = 10;
        dlPager.DataSource = mailRuleBUS.GetAll().DefaultView;
        dlPager.BindToControl = dtlHTML;
        this.dtlHTML.DataSource = dlPager.DataSourcePaged;
        this.dtlHTML.DataBind(); 
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.txtAttr.Text == "")
            {
                pnError.Visible = true;
                pnSuccess.Visible = false;
                lblError.Text = "Bạn chưa nhập thuộc tính HTML ";
            }
            else
            {
                mailRuleBUS = new HtmlMailRuleBUS();
                HtmlMailRuleDTO htmlDTO = new HtmlMailRuleDTO();
                htmlDTO.Attribute = txtAttr.Text;
                htmlDTO.Gmail = chkGmail.Checked;
                htmlDTO.YahooMail= chkYahoo.Checked;
                htmlDTO.Outlook071013 = chkOutLook.Checked;
                htmlDTO.WindowsLiveMail2011 = chkHotMail.Checked;
                htmlDTO.AOLMail = chkAOL.Checked;
                htmlDTO.Android4 = false;
                htmlDTO.AOLDesktop10 = false;
                htmlDTO.AppleMail65 = false;
                htmlDTO.Blackberry6 = false;
                htmlDTO.GmailMobile = false;
                htmlDTO.iPhoneiOS7iPad = true;
                htmlDTO.LotusNotes85 = true;
                htmlDTO.Notes67 = true;
                htmlDTO.Outlookcom = true;
                htmlDTO.OutlookExpress = false;
                htmlDTO.Postbox = true;
                htmlDTO.Thunderbird17 = true;
                htmlDTO.WindowsMobile75 = true;
                int i=0;
                if (mailRuleBUS.GetByID(txtAttr.Text).Rows.Count > 0)
                {
                    mailRuleBUS.tblHtmlMailRule_Update(htmlDTO);
                    i = 1;
                }
                else
                {
                    mailRuleBUS.tblHtmlMailRule_insert(htmlDTO);
                }
                pnSuccess.Visible = true;
                pnError.Visible = false;
                if (i != 1)
                {
                    lblSuccess.Text = "Bạn đã thêm thành công một thuộc tính html";

                }
                else
                {
                    lblSuccess.Text = "Bạn đã cập nhật thành công một thuộc tính html";
                }
                
                this.txtAttr.Text = "";
            }
            LoadData();
        }
        catch (Exception)
        {
            pnError.Visible = true;
            lblError.Text = "Lỗi trong quá trình cập nhật";
            pnSuccess.Visible = false;
            
        }
    }
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string Attr = ((ImageButton)sender).CommandArgument;
            mailRuleBUS = new HtmlMailRuleBUS();
            DataTable table = mailRuleBUS.GetByID(Attr);
            if (table.Rows.Count > 0)
            {
                txtAttr.Text = Attr;
                chkAOL.Checked = bool.Parse(table.Rows[0]["AOLMail"].ToString());
                chkGmail.Checked = bool.Parse(table.Rows[0]["Gmail"].ToString());
                chkHotMail.Checked = bool.Parse(table.Rows[0]["WindowsLiveMail2011"].ToString());
                chkOutLook.Checked = bool.Parse(table.Rows[0]["Outlook071013"].ToString());
                chkYahoo.Checked = bool.Parse(table.Rows[0]["YahooMail"].ToString());
            }
        }
        catch (Exception)
        {
            pnError.Visible = true;
            lblError.Text = "Lỗi trong quá trình sửa chữa!";
            pnSuccess.Visible = false;
        }
        LoadData();
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string Attr = ((ImageButton)sender).CommandArgument;
            mailRuleBUS = new HtmlMailRuleBUS();
            mailRuleBUS.tblHtmlMailRule_Delete(Attr);
            pnSuccess.Visible = true;
            pnError.Visible = false;
            lblSuccess.Text = "Bạn đã xóa thành công thuộc tính : " + Attr;
            LoadData();
        }
        catch (Exception)
        {
            pnError.Visible = true;
            lblError.Text = "Lỗi trong quá trình xóa!";
            pnSuccess.Visible = false;
        }
    }
}
