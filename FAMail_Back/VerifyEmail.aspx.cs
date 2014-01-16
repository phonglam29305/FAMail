using Email;
using System;
using System.Collections.Generic;
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
            Response.Redirect("http://localhost:40025/FAMail_Back/webapp/page/backend/login.aspx");
        }
    }
    private void sendmail(string EmailVerify)
    {
        VerifyBUS vbs = new VerifyBUS();
        ConnectionData.OpenMyConnection();
        vbs.updateveryfy(EmailVerify, false);
        ConnectionData.CloseMyConnection();
        

    }
}