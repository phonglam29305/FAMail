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
    UserLoginBUS ulBus = new UserLoginBUS();
    RoleDetailBUS rdBus = new RoleDetailBUS();
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
                DataTable table = ulBus.GetClientId(userLogin.UserId);
                int clienID = int.Parse(table.Rows[0]["clientId"].ToString());
                int status = int.Parse(table.Rows[0]["Status"].ToString());
                DateTime NgayHetHan = Convert.ToDateTime(table.Rows[0]["expireDate"].ToString());
                string todays = DateTime.Now.ToString("yyyy-MM-dd");
                DateTime today = Convert.ToDateTime(todays);
                DateTime expireDay = Convert.ToDateTime(NgayHetHan);
               

                if(status != 1)
                {

                    if (expireDay < today)
                    {

                        lblMessage.Text = "Tài khoản đăng nhập đã hết hạn) ";
                    }
                    else
                    {
                        try
                        {
                            userLogin.hasSendMail = int.Parse(tbResult.Rows[0]["hasSendMail"].ToString());
                        }
                        catch (Exception)
                        {
                            userLogin.hasSendMail = 0;
                        }
                        int hasCreatedCustomer = Common.countHasCreateMailByUserId(int.Parse(tbResult.Rows[0]["UserId"].ToString()));
                        userLogin.hasCreatedCustomer = hasCreatedCustomer;

                        // Tạo session user login
                        Session["us-login"] = userLogin;
                        Session["UserName"] = userLogin.Username;
                        Session["UserId"] = userLogin.UserId;
                        // Kiểm tra user này có thuộc phân quyền nâng cao hay không 
                        DataTable tblRoleDetail = rdBus.GetByDepartmentIdAndRole(-1, userLogin.DepartmentId);
                        if (tblRoleDetail.Rows.Count > 0)
                        {
                            RoleDetailDTO rdDto = new RoleDetailDTO();
                            rdDto.roleId = int.Parse(tblRoleDetail.Rows[0]["roleId"].ToString());
                            rdDto.departmentId = int.Parse(tblRoleDetail.Rows[0]["departmentId"].ToString());
                            rdDto.limitSendMail = int.Parse(tblRoleDetail.Rows[0]["limitSendMail"].ToString());
                            rdDto.limitCreateCustomer = int.Parse(tblRoleDetail.Rows[0]["limitCreateCustomer"].ToString());
                            rdDto.toDate = DateTime.Parse(tblRoleDetail.Rows[0]["toDate"].ToString());
                            // Tạo session limit
                            Session["limitWithUser"] = rdDto;
                        }

                        Session["ID"] = 25;
                        Response.Redirect("list-content-mail.aspx");
                    }
                }
                else
                {
                    pnError.Visible = true;
                    lblMessage.Text = "Tài khoản đăng nhập đã bị khóa.";
                }
                
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
