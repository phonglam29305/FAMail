using Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;

public partial class webapp_page_backend_Default : System.Web.UI.Page
{
    SMTPaccountBUS smtpaccountbus = new SMTPaccountBUS();
    log4net.ILog logs = log4net.LogManager.GetLogger("ErrorRollingLogFileAppender");
    UserLoginDTO userLogin = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        userLogin = getUserLogin();
        if (!IsPostBack)
        {
            try
            {
                display();
                hdfId.Value = null;
            }
            catch (Exception)
            {


            }
        }
       
    }
    private void display()
    {
        dtsmtpaccount.DataSource = smtpaccountbus.getall();
        dtsmtpaccount.DataBind();
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
    private string checkInput()
    {
        string masseng = "";
        int i = 0;
        if (txtEmailConfig.Text == "")
        {
            masseng = "Vui lòng nhập Email vào";
        }
        else if (kiemtraso(txtlimit.Text) == false)
        {
            masseng = "Vui lòng nhập giới hạn đúng định dạng số";
        }
        else if (txtlimit.Text== "")
        {
            masseng = "Vui lòng nhập giới hạn mail vào ";
        }
        else if (IsValidMail(txtEmailConfig.Text) == false)
        {
            masseng = "Email không đúng định dạng";
        }
        
        return masseng;
    }
    private bool kiemtraso(string chuoi)
    {
        foreach (char k in chuoi)
        {
            if (char.IsDigit(k) == false)
                return false;
        }

        return true;
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
             string message = checkInput();
        if (message == "")
        {
            int status = 0;
            SMTPaccountDTO smtpaccount = getsmtpaccount();
            ConnectionData.OpenMyConnection();
            if (hdfId.Value == null || hdfId.Value == "")
            {

                smtpaccountbus.insert(smtpaccount);
                status = 1;
            }
            else
            {
                SMTPaccountDTO smtpaccountupdate = updatesmtpaccount();
                smtpaccountbus.update(smtpaccount);
                status = 2;
                hdfId.Value = null;
            }
            pnSuccess.Visible = true;
            if (status == 1)
            {
                lblSuccess.Text = "Bạn vừa thêm thành công chức năng !";
            }
            else
                if (status == 2)
                {
                    lblSuccess.Text = "Bạn vừa cập nhật thành công chức năng !";
                }
        }
        else
        {

            pnSuccess.Visible = false;
            pnError.Visible = true;
            lblError.Text = message;

        }
        }
        catch (Exception)
        {
            
            throw;
        }
        display();
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int id = int.Parse(((ImageButton)sender).CommandArgument.ToString());
           if( smtpaccountbus.smtpaccount_Delete(id))
           {

           }
            
        }
        catch (Exception ex)
        {

            pnError.Visible = true;
            lblError.Text = "Không thể xóa !</br>" + ex.Message;
            logs.Error(userLogin.Username + "-SMTPAcount-Delete-", ex);
        }
        display();

    }
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int id = int.Parse((((ImageButton)sender).CommandArgument.ToString()));
            DataTable data = smtpaccountbus.getid(id);
            {
                if (data.Rows.Count > 0)
                {
                    txtEmailConfig.Text = data.Rows[0]["email"].ToString();
                    txtpassword.Text = data.Rows[0]["password"].ToString();
                    txtaccesskey.Text = data.Rows[0]["accesskey"].ToString();
                    txtsecrectkey.Text = data.Rows[0]["Secreckey"].ToString();
                    txtpasssmtp.Text = data.Rows[0]["PasswordSMTP"].ToString();
                    txtserversmtp.Text = data.Rows[0]["ServerSMTP"].ToString();
                    txtusername.Text = data.Rows[0]["UsernameSMTP"].ToString();
                    txtlimit.Text = data.Rows[0]["Limit"].ToString();
                }
            }


        }
        catch (Exception ex)
        {
            pnError.Visible = false;
            pnSuccess.Visible = false;
            logs.Error(userLogin.Username + "-Package - Edit", ex);
        }
    }
}