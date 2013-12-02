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

public partial class webapp_page_backend_change_pass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    private UserLoginDTO getUserLogin()
    {
        if (Session["us-login"] != null)
        {
            return (UserLoginDTO)Session["us-login"];
        }
        return null;
    }
    protected void lbtChangPass_Click(object sender, EventArgs e)
    {
        UserLoginDTO userLogin = getUserLogin();
        string message = checkInput();
        if (message == "")
        {
            UserLoginBUS ulBus = new UserLoginBUS();
            string newPass = Common.GetMd5Hash(txtNewPass.Text.Trim());
            userLogin.Password = newPass;
            ConnectionData.OpenMyConnection();
            ulBus.tblUserLogin_Update(userLogin);
            ConnectionData.CloseMyConnection();
            //update session userlogin info
            Session["us-login"] = userLogin;

            pnSuccess.Visible = true;
            pnError.Visible = false;
            lblSuccess.Text = "Đã thay đổi mật khẩu thành công !";
        }
        else
        {
            pnSuccess.Visible = false;
            pnError.Visible = true;
            lblError.Text = message;
        }
    }
    protected string checkInput()
    {
        string message = "";
        if (txtOldPass.Text == "")
        {
            message = "Vui lòng nhập vào mật khẩu cũ !";
        }
        else if (!checkOldPass())
        {
            message = "Mật khẩu cũ không đúng !";
        }
        else if (txtNewPass.Text == "")
        {
            message = "Vui lòng nhập mật khẩu mới !";
        }
        else if (txtConfirmPass.Text != txtNewPass.Text)
        {
            message = "Xác nhận mật khẩu mới không đúng !";
        }
        return message;
    }
    protected bool checkOldPass()
    {
        UserLoginDTO userLogin = getUserLogin();
        string inputOldPass = Common.GetMd5Hash(txtOldPass.Text.Trim());
        if (getUserLogin().Password != inputOldPass)
            return false;
        return true;
    }
}
