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

public partial class webapp_page_backend_user_manage : System.Web.UI.Page
{
    UserLoginBUS ulBus = null;
    DepartmentBUS deBus = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                loadListDepartment();
                drlDepartment_SelectedIndexChanged(sender, e);
            }
            catch (Exception)
            {
            }
        }
    }

    protected void loadListDepartment()
    {
        deBus = new DepartmentBUS();
        DataTable tblDepartment = deBus.GetAll();
        if(tblDepartment.Rows.Count>0)
        {
            drlDepartment.Items.Clear();
            drlDepartment.DataSource = tblDepartment;
            drlDepartment.DataTextField = "Name";
            drlDepartment.DataValueField = "ID";
            drlDepartment.DataBind();

        }
       
    }

    protected void loadUserByDepartmentId(int departId)
    {
        ulBus = new UserLoginBUS();
        deBus = new DepartmentBUS();
        DataTable dtLogin = ulBus.GetByDepartmentId(departId);
        if (dtLogin.Rows.Count > 0)
        {
            dlMember.DataSource = dtLogin;
            dlMember.DataBind();
            for (int i = 0; i < dtLogin.Rows.Count; i++)
            {                
                DataRow row = dtLogin.Rows[i];
               
               
                    Label lblUsername = (Label)dlMember.Items[i].FindControl("lblUsername");
                    lblUsername.Text = row["Username"].ToString();
                   
                    Label lblDepartment = (Label)dlMember.Items[i].FindControl("lblDepartment");
                    DataTable dtDepartment = deBus.GetByID(int.Parse(row["DepartmentId"].ToString()));
                    if (dtDepartment.Rows.Count > 0)
                    {
                        lblDepartment.Text = dtDepartment.Rows[0]["Name"].ToString();
                    }

                    LinkButton lbtEdit = (LinkButton)dlMember.Items[i].FindControl("lbtEdit");
                    lbtEdit.CommandArgument = row["UserId"].ToString();

                    LinkButton lbtDelete = (LinkButton)dlMember.Items[i].FindControl("lbtDelete");
                    lbtDelete.CommandArgument = row["UserId"].ToString();

                    LinkButton lbtViewDetail = (LinkButton)dlMember.Items[i].FindControl("lbtViewDetail");
                    lbtViewDetail.CommandArgument = row["UserId"].ToString();
                    lbtViewDetail.PostBackUrl = "user-detail.aspx?uid=" + row["UserId"].ToString();
                    if (row["Username"].Equals("administrator"))
                    {
                        lbtDelete.Visible = false;
                        lbtEdit.Visible = false;
                        lbtViewDetail.Visible = false;
                    }                  
                            
            }
            
        }
        
    }
    protected void drlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int departId = int.Parse(drlDepartment.SelectedValue.ToString());
            loadUserByDepartmentId(departId);
        }
        catch (Exception)
        {}
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string message = checkInput();
            if (message == "")
            {
                ulBus = new UserLoginBUS();                
                UserLoginDTO ulDto = new UserLoginDTO();
                ulDto.DepartmentId = int.Parse(drlDepartment.SelectedValue);
                ulDto.Username = txtUsername.Text;
                ulDto.Password = Common.GetMd5Hash(txtPassword.Text);
                ConnectionData.OpenMyConnection();
                ulBus.tblUserLogin_insert(ulDto);
                ConnectionData.CloseMyConnection();
                pnSuccess.Visible = true;
                pnError.Visible = false;
                loadUserByDepartmentId(ulDto.DepartmentId);
                lblSuccess.Text = "Thêm thành công !";
            }
            else
            {
                pnSuccess.Visible = false;
                pnError.Visible = true;
                lblError.Text = message;
            }
            
        }
        catch (Exception ex)
        {
            pnSuccess.Visible = false;
            pnError.Visible = true;
            lblError.Text = "Kiểm tra lại dữ liệu nhập vào !";
        }
    }
    protected string checkInput()
    {
        string message = "";
        if (txtUsername.Text == "")
        {
            message = "Nhập vào tài khoản !";
        }
        else if (checkExistUsername(txtUsername.Text))
        {
            message = "Tài khoản đã tồn tại !";
        }
        else
        {
            message = checkPassword();
        }
        return message;
    }
    protected bool checkExistUsername(string username)
    {
        ulBus = new UserLoginBUS();
        DataTable tblUser = ulBus.GetByUsername(username);
        if (tblUser.Rows.Count > 0)
        {
            return true;
        }
        return false;
    }
    protected void lbtEdit_Click(object sender, EventArgs e)
    {
        pnError.Visible = false;
        pnSuccess.Visible = false;
        int userId = int.Parse(((LinkButton)sender).CommandArgument);
        ulBus = new UserLoginBUS();
        DataTable tblUser = ulBus.GetByUserId(userId);
        if (tblUser.Rows.Count > 0)
        {
            hdfUserId.Value = tblUser.Rows[0]["UserId"].ToString();
            drlDepartment.SelectedValue = tblUser.Rows[0]["DepartmentId"].ToString();
            txtUsername.Text = tblUser.Rows[0]["Username"].ToString();
            txtUsername.Enabled = false;
            txtPassword.Text = tblUser.Rows[0]["Password"].ToString();
            txtRePassword.Text = tblUser.Rows[0]["Password"].ToString();
        }
    }
    protected void lbtDelete_Click(object sender, EventArgs e)
    {
        ulBus = new UserLoginBUS();

        try
        {
            int userId = int.Parse(((LinkButton)sender).CommandArgument);
            
            ConnectionData.OpenMyConnection();
            ulBus.tblUserLogin_Delete(userId);

            // Delete data has created with this user.


            ConnectionData.CloseMyConnection();
            drlDepartment_SelectedIndexChanged(sender, e);
            pnError.Visible = false;
            pnSuccess.Visible = true;
            lblSuccess.Text = "Xóa thành công !";
        }
        catch (Exception)
        {
            pnError.Visible = true;
            pnSuccess.Visible = false;
            lblSuccess.Text = "Không thể xóa !";
        }
        
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string message = checkPassword();
            if (message == "")
            {
                ulBus = new UserLoginBUS();                
                UserLoginDTO ulDto = new UserLoginDTO();
                ulDto.UserId = int.Parse(hdfUserId.Value);
                ulDto.DepartmentId = int.Parse(drlDepartment.SelectedValue);
                ulDto.Username = txtUsername.Text;
                ulDto.Password = Common.GetMd5Hash(txtPassword.Text);
                ConnectionData.OpenMyConnection();
                ulBus.tblUserLogin_Update(ulDto);
                ConnectionData.CloseMyConnection();
                pnSuccess.Visible = true;
                pnError.Visible = false;
                loadUserByDepartmentId(ulDto.DepartmentId);
                lblSuccess.Text = "Cập nhật thành công !";
            }
            else
            {
                pnSuccess.Visible = false;
                pnError.Visible = true;
                lblError.Text = message;
            }
        }
        catch (Exception ex)
        {
            pnSuccess.Visible = false;
            pnError.Visible = true;
            lblError.Text = "Kiểm tra lại dữ liệu nhập vào !";
        }
    }
    protected string checkPassword()
    {
        string message = "";
        if (txtPassword.Text == "")
        {
            message = "Nhập vào mật khẩu !";
        }
        else if (txtPassword.Text != txtRePassword.Text)
        {
            message = "Xác nhận mật khẩu không đúng !";
        }
        return message;
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        pnError.Visible = false;
        pnSuccess.Visible = false;
        hdfUserId.Value = "";
        txtUsername.Text = "";
        txtUsername.Enabled = true;
        txtPassword.Text = "";
        txtRePassword.Text = "";        
    }
}
