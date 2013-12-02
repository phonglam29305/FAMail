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
using Email;

public partial class webapp_page_backend_login : System.Web.UI.Page
{
    UserLoginBUS ulBus = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session["us-login"] = null;
        }
        catch (Exception)
        {}
    }
    protected void lbtSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            String user = txtUsername.Text;
            string en_pass = Common.GetMd5Hash(txtPassword.Text.Trim());
            ulBus = new UserLoginBUS();
            ConnectionData.OpenMyConnection();
            DataTable tbResult = ulBus.GetByUsernameAndPass(user, en_pass);
            ConnectionData.CloseMyConnection();
            if (tbResult.Rows.Count > 0)
            {
                UserLoginDTO userLogin = new UserLoginDTO();
                userLogin.UserId = int.Parse(tbResult.Rows[0]["UserId"].ToString());
                userLogin.Username = tbResult.Rows[0]["Username"].ToString();
                userLogin.Password = tbResult.Rows[0]["Password"].ToString();
                userLogin.DepartmentId = int.Parse(tbResult.Rows[0]["DepartmentId"].ToString());

                try
                {
                    userLogin.hasSendMail = int.Parse(tbResult.Rows[0]["hasSendMail"].ToString());
                }
                catch (Exception)
                {
                    userLogin.hasSendMail = 0;
                }               

                Session["us-login"] = userLogin;

                Session["DepartmentID"] = 1;
                Session["ID"] = 25;
                Response.Redirect("list-content-mail.aspx");
            }
            else
            {
                pnError.Visible = true;
                lblMessage.Text = "Email hoặc mật khẩu không đúng.";
            }
        }
        catch (Exception ex)
        {
            pnError.Visible = true;
            lblMessage.Text = ex.Message;
        }
        
    }
}
