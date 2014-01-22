using Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webapp_page_backend_Default : System.Web.UI.Page
{
    SMTPaccountBUS smtpaccountbus = new SMTPaccountBUS();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private UserLoginDTO getUserLogin()
    {
        if (Session["us-login"] != null)
        {
            return (UserLoginDTO)Session["us-login"];
        }
        else Response.Redirect("~");
        return null;
    }
    private SMTPaccountDTO getsmtpaccount()
    {
        SMTPaccountDTO smtpaccount = new SMTPaccountDTO();
        UserLoginDTO userLogin = getUserLogin();
        if (userLogin != null)
        {
            smtpaccount.id = userLogin.UserId;
            smtpaccount.Email = txtEmailConfig.Text;
            smtpaccount.Password = txtpassword.Text;
            smtpaccount.Accesskey = txtaccesskey.Text;
            smtpaccount.Secreckey = txtsecrectkey.Text;
            smtpaccount.PasswordSMTP = txtpasssmtp.Text;
            smtpaccount.ServerSMTP = txtserversmtp.Text;
            smtpaccount.UsernameSMTP = txtusername.Text;
            smtpaccount.Limit = txtlimit.Text;          
        }
        return smtpaccount;
    }

    private SMTPaccountDTO updatesmtpaccount()
    {
        SMTPaccountDTO smtpaccount = new SMTPaccountDTO();
        UserLoginDTO userLogin = getUserLogin();
        if (userLogin != null)
        {
            smtpaccount.id =Convert.ToInt32(hdfId);
            smtpaccount.Email = txtEmailConfig.Text;
            smtpaccount.Password = txtpassword.Text;
            smtpaccount.Accesskey = txtaccesskey.Text;
            smtpaccount.Secreckey = txtsecrectkey.Text;
            smtpaccount.PasswordSMTP = txtpasssmtp.Text;
            smtpaccount.ServerSMTP = txtserversmtp.Text;
            smtpaccount.UsernameSMTP = txtusername.Text;
            smtpaccount.Limit = txtlimit.Text;
        }
        return smtpaccount;



    }
    protected void btnSave_Click(object sender, EventArgs e)
    {       
        SMTPaccountDTO smtpaccount = getsmtpaccount();

        ConnectionData.OpenMyConnection();
        if (hdfId.Value == null || hdfId.Value == "")
        {
           
            smtpaccountbus.insert(smtpaccount);
            //status = 1;
        }
        else
        {
            SMTPaccountDTO smtpaccountupdate =updatesmtpaccount();         
            smtpaccountbus.insert(smtpaccount);
            hdfId.Value = null;

        }
    }
}