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
using System.Collections.Generic;
using System.Net.Mail;

public partial class webapp_page_backend_AmazonManage : System.Web.UI.Page
{
    const string AccessKey = "AKIAISOKS5VTXBRTVFEQ";
    const string SecrectKey = "4vWG7GoCd5JbZ/r9hxA8MTIoo9elkkvRxW80qyU6";
    VerifyEmail veriryEmail = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadVerifyList();
        }
    }

    private void LoadVerifyList()
    {
        veriryEmail = new VerifyEmail(AccessKey, SecrectKey);
        List<string> listEmail = veriryEmail.ListVerifiedEmailAddresses();
        
        int stt=0;
        DataTable List = this.CreateListEmail();
        if (listEmail.Count > 0)
        {
            foreach (string Email  in listEmail)
            {
                stt++;
                DataRow row = List.NewRow();
                row["No"] = stt;
                row["Email"] = Email;
                List.Rows.Add(row);
            }
            this.dtlEmail.DataSource = List;
            this.dtlEmail.DataBind();
        }

    }
    public DataTable CreateListEmail()
    {

        DataTable dt = new DataTable("ListEmail");
        DataColumn No = new DataColumn("No");
        DataColumn Email = new DataColumn("Email");
        DataColumn[] key = { No };
        dt.Columns.Add(No);
        dt.Columns.Add(Email);
        dt.PrimaryKey = key;
        return dt;
    }
    protected void btnVerify_Click(object sender, EventArgs e)
    {
        if (txtEmailVerify.Text != "" || IsValidMail(txtEmailVerify.Text)==false)
        {
            veriryEmail = new VerifyEmail(AccessKey, SecrectKey);
            bool status = veriryEmail.VerifyEmailAddress(txtEmailVerify.Text.Trim());
            if (status == true)
            {
                txtEmailVerify.Text = "";
                pnError.Visible = false;
                lblSuccess.Text = "Bạn đã verify thành công email: " + txtEmailVerify.Text + " Vui lòng kiểm tra email để hoàn thành việc verify";
                pnSuccess.Visible = true;
                LoadVerifyList();
            }
            else
            {
                pnSuccess.Visible = false;
                pnError.Visible = true;
                lblError.Text = "Lỗi trong quá trình verify";
            }
        }
        else
        {
            pnSuccess.Visible = false;
            pnError.Visible = true;
            lblError.Text = "Bạn chưa nhập email hoặc không đúng định dạng! Vui lòng kiểm tra lại";
            txtEmailVerify.Focus();
        }
    }
    public bool IsValidMail(string emailaddress)
    {
        try
        {
            MailAddress m = new MailAddress(emailaddress);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
    protected void lbtContentDelete_Click(object sender, EventArgs e)
    {
        string email = ((LinkButton)sender).CommandArgument.ToString();
        veriryEmail = new VerifyEmail(AccessKey, SecrectKey);
        bool status = veriryEmail.DeleteEmailAddress(email);
        if (status == true)
        {
            pnError.Visible = false;
            lblSuccess.Text = "Bạn đã xóa thành công email: " + txtEmailVerify.Text;
            pnSuccess.Visible = true;
        }
        else
        {
            pnSuccess.Visible = false;
            pnError.Visible = true;
            lblError.Text = "Lỗi trong quá trình xóa email";
        }
    }
}
