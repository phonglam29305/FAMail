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
using System.Net.Mail;
using System.Text.RegularExpressions;
using Email;
using System.Resources;
using System.Globalization;

public partial class webapp_page_backend_Config_Email_Send : System.Web.UI.Page
{
    MailConfigBUS mcBUS = null;
    DepartmentBUS dpBUS = null;
    private CultureInfo ci = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                InitBUS();                
            }
            catch (Exception ex)
            {
                pnError.Visible = true;
                lblError.Text = ex.Message;
            }
            
        }
    }

    private UserLoginDTO getUserLogin()
    {
        if (Session["us-login"] != null)
        {
            return (UserLoginDTO)Session["us-login"];
        }
        return null;
    }

    private void InitBUS()
    {
        mcBUS = new MailConfigBUS();
        dpBUS = new DepartmentBUS();
        if (getUserLogin().DepartmentId == 1)
        {
            drlDepartmen.Items.Clear();
            drlDepartmen.DataSource = dpBUS.GetAll();
            drlDepartmen.DataTextField = "Name";
            drlDepartmen.DataValueField = "ID";
            drlDepartmen.DataBind();
            dlMailConfig.DataSource = mcBUS.GetAll();
            dlMailConfig.DataBind();
        }
        else
        {
            this.btnSave.Enabled = false;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ci = new CultureInfo("vi-VN");
        try
        {
            if (CheckValidate() == "")
            {
                mcBUS = new MailConfigBUS();
                ConnectionData.OpenMyConnection();
                if (getUserLogin().DepartmentId == 1)
                {
                    mcBUS.tblMailConfig_insert(GetMailConfigDTO());
                    ConnectionData.CloseMyConnection();
                    pnSuccess.Visible = true;
                    //lblSuccess.Text = this.GetGlobalResourceObject("Resource", "InsertSucces").ToString();
                    Resources.Resource.Culture = ci;
                    lblSuccess.Text = Resources.Resource.InsertSucces;
                    dlMailConfig.DataSource = mcBUS.GetAll();
                    dlMailConfig.DataBind();
                    pnError.Visible = false;
                }
                else
                {
                    this.btnSave.Enabled = false;
                    pnError.Visible = true;
                    lblError.Text = Resources.Resource.InsertFail;
                    Resources.Resource.Culture=ci;
                    
                }
            }
            else
            {
                pnError.Visible = true;
                lblError.Text = CheckValidate();
                pnSuccess.Visible = false;
            }
            
            
        }
        catch (Exception ex)
        {
            pnError.Visible = true;
            lblError.Text = "Vui lòng kiểm tra lại cấu hình mail.<br/>" + ex.Message;
        }        

    }

    private MailConfigDTO GetMailConfigDTO()
    {
        MailConfigDTO mcDTO = new MailConfigDTO();
        string Name = null;
        string Server = null;
        string email = null;       
        string password = null;
        string confilmPass = null;
        int port = int.Parse(this.txtPort.Text.Trim());
        int departmentID = int.Parse(this.drlDepartmen.SelectedValue);
        Name = this.txtName.Text;
        Server = this.txtServer.Text;
        email = this.txtEmailSend.Text;
        password = this.txtPassword.Text.Trim();
        confilmPass = this.txtConfilmPassword.Text.Trim();
        mcDTO.Email = email;
        mcDTO.Server = Server;
        mcDTO.Port = port;
        mcDTO.Name = Name;
        mcDTO.Password = password;
        mcDTO.DepartmentID = departmentID;
        mcDTO.levelId = 1;
        mcDTO.parentId = 1;
        mcDTO.username = this.txtEmailConfig.Text;
        mcDTO.userId = getUserLogin().UserId;
        if (this.chkIsSSL.Checked == true)
        {
            mcDTO.isSSL = true;
        }
        else
        {
            mcDTO.isSSL = false;
        }
        return mcDTO;
    }
    
    private string CheckValidate()
    {   
        string Name = null;
        string Server = null;
        string email = null;
        //int port = 0;
        string password = null;
        string confilmPass = null;
        Name = this.txtName.Text;
        Server = this.txtServer.Text;
        email = this.txtEmailSend.Text;
       
        password = this.txtPassword.Text.ToString().Trim();
        confilmPass = this.txtConfilmPassword.Text.ToString().Trim();
        if (Name == "" || Name == null)
        {
            this.txtName.Focus();
            return "Bạn chưa nhập tên Email";
            
        }
        else if (Server == "" || Server == null)
        {
            this.txtServer.Focus();
            return "Bạn chưa nhập Server";
            
        }
        else if (email == "" || email == null)
        {
            this.txtEmailSend.Focus();
            return "Bạn chưa nhập Email gửi!";
            
        }
        else if (IsValidMail(email) == false)
        {
            this.txtEmailSend.Focus();
            return "Bạn chưa nhập đúng định dang Email!";
          
        }
        else if (password == "" || password == null)
        {
            this.txtPassword.Focus();
            return "Bạn chưa nhập mật khẩu";
            
        }
        else if (confilmPass == "" || confilmPass == null)
        {
            this.txtConfilmPassword.Focus();
            return "Bạn chưa nhập xác nhận mật khẩu!";
            
        }
        else if (password.Equals(confilmPass)==false)
        {
            this.txtConfilmPassword.Focus();
            return "Hai mật khẩu không trùng nhau!";
           
        }
        else if (txtPort.Text=="" || txtPort.Text==null)
        {
            this.txtPort.Focus();
            return "Bạn chưa nhập Port !";
            
        }
        else if (IsItNumber(txtPort.Text.Trim()) == false)
        {
            this.txtPort.Focus();
            return "Bạn nhập không phải là số !";
            
        }
        else
        {
            return "";
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
    public bool IsItNumber(string inputvalue)
    {
        Regex isnumber = new Regex("[^0-9]");
        return !isnumber.IsMatch(inputvalue);
    }
    protected void btnTest_Click(object sender, EventArgs e)
    {

        //Class1 c = new Class1();
        //try
        //{
        //    c.guimail();
        //    visibleMessage(false);
        //    pnError.Visible = true;
        //    lblError.Text = "Không";
        //}
        //catch (Exception ex)
        //{

        //    visibleMessage(false);
        //    pnError.Visible = true;
        //    lblError.Text = ex.Message;
        //}
        
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            UserLoginDTO userLogin = getUserLogin();
            ConnectionData.OpenMyConnection();
            int Id = int.Parse(((ImageButton)sender).CommandArgument.ToString());
            mcBUS = new MailConfigBUS();
            SendRegisterBUS srBUS = new SendRegisterBUS();

            if (srBUS.GetByMailConfigID(Id) > 0)
            {
                visibleMessage(false);
                pnError.Visible = true;
                lblError.Text = "Bạn vừa không thể xóa cấu hình này được. Cấu hình này đang có mail chờ gửi !";
               
            }
            else
            {
               int IDCurrent = userLogin.UserId;
               if (Id != IDCurrent)
               {
                   mcBUS.tblMailConfig_Delete(Id);
                   //Response.Redirect(Request.RawUrl);
                   dlMailConfig.DataSource = mcBUS.GetAll();
                   dlMailConfig.DataBind();
                   visibleMessage(false);
                   pnSuccess.Visible = true;
                   lblSuccess.Text = "Bạn vừa xóa thành một cấu hình !";
               }
               else
               {
                   visibleMessage(false);
                   pnError.Visible = true;
                   lblError.Text = "Bạn vừa không thể xóa cấu hình này được. Cấu hình này đang là cấu hình bạn đang đăng nhập!";
               }
            }
            ConnectionData.CloseMyConnection();
        }
        catch (Exception ex)
        {
            //pnError.Visible = true;
            //lblError.Text = ex.Message;
        }
    }
    protected void visibleMessage(bool vis)
    {
        pnError.Visible = vis;
        pnSuccess.Visible = vis;
    }
}
