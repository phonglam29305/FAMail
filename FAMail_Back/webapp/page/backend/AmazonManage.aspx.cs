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
    private string accessKey = null;
    private string secretKey = null;
    private string password = null;
    private string server = null;
    private string username = null;

    VerifyEmail veriryEmail = null;
    log4net.ILog logs = log4net.LogManager.GetLogger("ErrorRollingLogFileAppender");
    UserLoginDTO userLogin = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        userLogin = getUserLogin();        
        if (!IsPostBack)
        {
            //LoadVerifyListByUserId();
            LoadVerifyList();
        }
    }

    private void getConfigAmazone()
    {
        accessKey = ConfigurationManager.AppSettings["AccessKey"].ToString();
        if (accessKey == null)
        {
            accessKey = "AKIAISOKS5VTXBRTVFEQ";
        }
        secretKey = ConfigurationManager.AppSettings["SecrectKey"].ToString();
        if (secretKey == null)
        {
            secretKey = "4vWG7GoCd5JbZ/r9hxA8MTIoo9elkkvRxW80qyU6";
        }

        password = ConfigurationManager.AppSettings["PasswordSMTP"].ToString();
        if (password == null)
        {
            password = "AjzPf6o0UITv4qtyXEzXY15xm9nmyVhb7Tk7g2X8DOPk";
        }

        server = ConfigurationManager.AppSettings["ServerSMTP"].ToString();
        if (server == null)
        {
            server = "email-smtp.us-east-1.amazonaws.com";
        }

        username = ConfigurationManager.AppSettings["UserNameSMTP"].ToString();
        if (username == null)
        {
            username = "AKIAJGQEDHANI2RZVAWQ";
        }
            
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

    private void LoadVerifyList()
    {
        try
        {
            int stt = 0;
            DataTable List = this.CreateListEmail();
            VerifyBUS vBus = new VerifyBUS();
            DataTable dtVerifyList = vBus.GetByUserId(getUserLogin().UserId);
            MailConfigBUS mcBUS = new MailConfigBUS();

            // Load accessKey & secretKey & Password.
            getConfigAmazone();
            veriryEmail = new VerifyEmail(accessKey, secretKey);
            List<string> listEmail = veriryEmail.ListVerifiedEmailAddresses();
            foreach (DataRow EmailItem in dtVerifyList.Rows)
            {
                stt++;
                DataRow row = List.NewRow();
                row["No"] = stt;
                row["Email"] = EmailItem["EmailVerify"].ToString();
                if (listEmail.Contains(EmailItem["EmailVerify"].ToString()))
                {
                    row["Status"] = "Đã xác thực";
                }
                else
                {
                    row["Status"] = "Chờ xác thực..";
                }

                string email= EmailItem["EmailVerify"].ToString();                
                DataTable mailConfig = mcBUS.GetByEmailAndPass(email, password);
                if (mailConfig.Rows.Count > 0)
                {
                    row["Name"] = mailConfig.Rows[0]["Name"].ToString();
                }
                else
                {
                    row["Name"] = "Chưa cấu hình";
                }
                List.Rows.Add(row);
            }
            this.dtlEmail.DataSource = List;
            this.dtlEmail.DataBind();

        }
        catch (Exception ex)
        {
            logs.Error(userLogin.Username +"-Verify",ex);
        }
       
    }

    private void LoadVerifyListByUserId()
    {
        VerifyBUS vBus = new VerifyBUS();
        DataTable dtVerifyList = vBus.GetByUserId(getUserLogin().UserId);   
        this.dtlEmail.DataSource = dtVerifyList;
        this.dtlEmail.DataBind();
        
    }

    public DataTable CreateListEmail()
    {
        DataTable dt = new DataTable("ListEmail");
        DataColumn No = new DataColumn("No");
        DataColumn Status = new DataColumn("Status");
        DataColumn Name = new DataColumn("Name");
        DataColumn Email = new DataColumn("Email");
        DataColumn[] key = { No };
        dt.Columns.Add(No);
        dt.Columns.Add(Email);
        dt.Columns.Add(Status);
        dt.Columns.Add(Name);
        dt.PrimaryKey = key;
        return dt;
    }
    protected void btnVerify_Click(object sender, EventArgs e)
    {
        //try
        //{
        VerifyBUS vBus = new VerifyBUS();
            string err = ValidateNull();
            DataTable dt = vBus.GetByUserId(getUserLogin().UserId);
            if (dt.Rows.Count>=2)
            {
                pnSuccess.Visible = false;
                pnError.Visible = true;
                lblError.Text = "Giới hạn tối đa cho phép xác thực là 2. Vui lòng xóa mail cũ !";
             } 
             else if (err=="")
             {
                // Get amazone config.
                getConfigAmazone();
                veriryEmail = new VerifyEmail(accessKey, secretKey);
                bool status = veriryEmail.VerifyEmailAddress(txtEmailVerify.Text.Trim());
                if (status == true)
                {
                    // Them vao danh sach email xac thuc thanh cong.
                    MailConfigBUS mcBUS = new MailConfigBUS();
                    VerifyDTO vDto = new VerifyDTO();
                    vDto.EmailVerify = txtEmailVerify.Text.Trim();
                    vDto.userId = getUserLogin().UserId;
                    if (vBus.GetByEmail(vDto.EmailVerify).Rows.Count > 0)
                    {
                        pnSuccess.Visible = false;
                        pnError.Visible = true;
                        lblError.Text = "Email này đã được verify trong hệ thống";
                        return;
                    }
                    else
                    {
                        vBus.tblVerify_insert(vDto);
                    }
                   
                    // Thêm vào cấu hình mail.
                    MailConfigDTO mcDTO = new MailConfigDTO();
                    mcDTO.DepartmentID = getUserLogin().DepartmentId;
                    mcDTO.userId = getUserLogin().UserId;
                    mcDTO.Email = txtEmailVerify.Text.Trim();
                    mcDTO.parentId = 1;
                    mcDTO.levelId = 1;
                    mcDTO.isSSL = true;
                    mcDTO.Port = 25;
                    mcDTO.Server = server;
                    mcDTO.username = username;
                    mcDTO.Password = password;
                    mcDTO.Name = txtNameConfig.Text;
                    if (mcBUS.GetByEmailAndPass(mcDTO.Email, mcDTO.Password).Rows.Count > 0)
                    {
                        mcDTO.Id = int.Parse(mcBUS.GetByEmailAndPass(mcDTO.Email, mcDTO.Password).Rows[0]["Id"].ToString());
                        mcBUS.tblMailConfig_Update(mcDTO);
                    }
                    else
                    {
                        mcBUS.tblMailConfig_insert(mcDTO);
                    }
                    
                    pnError.Visible = false;
                    lblSuccess.Text = "Bạn đã xác thực thành công email: " + txtEmailVerify.Text + " Vui lòng kiểm tra email để hoàn thành việc xác thực";
                    txtEmailVerify.Text = "";
                    txtNameConfig.Text = "";
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
                lblError.Text = err;
                txtEmailVerify.Focus();
            }
        //}
        //catch (Exception)
        //{
        //}
        
    }

    private string ValidateNull()
    {
        string err="";
        if(txtEmailVerify.Text=="")
        {
            err="Bạn chưa nhập email!";
            return err;
        }
        else if(IsValidMail(txtEmailVerify.Text)== false)
        {
            err="Bạn nhập không đúng định dạng Email!";
            return err;
        }
        else if(txtNameConfig.Text=="")
        {
            err="Bạn chưa nhập tên cấu hình";
            return err;
        }
        return err;
    }
    protected bool checkExceedLimitEmail()
    {
        VerifyBUS vBus = new VerifyBUS();
        if (getUserLogin().DepartmentId != 1)
        {
            DataTable dt = vBus.GetByUserId(getUserLogin().UserId);
            if (dt.Rows.Count >= 2)
            {
                return false;
            }
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
    protected void lbtContentDelete_Click(object sender, EventArgs e)
    {
        try
        {
            // Load amazone config.
            getConfigAmazone();

            VerifyBUS vBus = new VerifyBUS();
            string email = ((LinkButton)sender).CommandArgument.ToString();
            veriryEmail = new VerifyEmail(accessKey, secretKey);
            bool status = veriryEmail.DeleteEmailAddress(email);
            if (status == true)
            {
                // Xoa trong db.
                vBus.tblVerify_Delete(email);
                string pass = password;
                // Xóa trong mail Config
                MailConfigBUS mcConfig = new MailConfigBUS();
                DataTable mailconfig = mcConfig.GetByEmailAndPass(email, pass);
                if (mailconfig.Rows.Count > 0)
                {
                    int id = int.Parse(mailconfig.Rows[0]["Id"].ToString());
                    mcConfig.tblMailConfig_Delete(id);
                }
                pnError.Visible = false;
                lblSuccess.Text = "Bạn đã xóa thành công email: " + email;
                pnSuccess.Visible = true;
                LoadVerifyList();
            }
            else
            {
                pnSuccess.Visible = false;
                pnError.Visible = true;
                lblError.Text = "Lỗi trong quá trình xóa email";
            }

        }
        catch (Exception)
        {
        }
    }
}
