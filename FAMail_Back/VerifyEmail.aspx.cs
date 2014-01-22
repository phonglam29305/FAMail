using Email;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VerifyEmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Params["email"] != null)
                sendmail(Request.Params["email"].ToString());
            //Response.Redirect("http://emailmarketing.1onlinebusinesssystem.com/webapp/page/backend/login.aspx");
        }
    }
    private void sendmail(string EmailVerify)
    {
        VerifyBUS vbs = new VerifyBUS();
        
        ConnectionData.OpenMyConnection();
        VerifyDTO verify = new VerifyDTO();
        verify.userId = Convert.ToInt32(Request.Params["userId"]+"");
        verify.EmailVerify = EmailVerify;
        verify.isdelete = 0;
        if (vbs.GetByUserId(verify.userId).Select("EmailVerify='" + EmailVerify + "'").Length == 0)
        {
            vbs.tblVerify_insert(verify);
        }
        else {
            lblStatus.Text = "Emai này đã được đăng ký";
            lblStatus.ForeColor = System.Drawing.Color.Red;
        }
        ConnectionData.CloseMyConnection();
    }
}