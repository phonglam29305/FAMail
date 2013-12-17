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

public partial class webapp_page_backend_subClient : System.Web.UI.Page
{
    UserLoginBUS ulBus = null;
    DepartmentBUS deBus = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                InitBUS();
                LoadData();

            }
            catch (Exception)
            {
            }
        }
    }


    private void InitBUS()
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




    private void LoadData()
    {
        try
        {
            DataTable dtLogin = null;
            ulBus = new UserLoginBUS();
            dtLogin = ulBus.GetSubClient();
            dlMember.DataSource = dtLogin;
            dlMember.DataBind();

            for (int i = 0; i < dtLogin.Rows.Count; i++)
            {
                Label lblNo = (Label)(Label)dlMember.Items[i].FindControl("No");
                lblNo.Text = (i + 1).ToString();
            }

        }
        catch (Exception)
        {
        }

    }




    protected void loadUserByDepartmentId(int departId)
    {
        ulBus = new UserLoginBUS();
        deBus = new DepartmentBUS();
        DataTable dtLogin = ulBus.GetByDepartmentId(departId);

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
    protected void drlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        deBus = new DepartmentBUS();
        try
        {
            //  int departId = int.Parse(drlDepartment.SelectedValue.ToString());

            //  loadUserByDepartmentId(departId);
        }
        catch (Exception)
        { }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string message = "";
        try
        {
            if (hdfId.Value == null || hdfId.Value == "")//them moi
            {
                message = checkInput();
            }
            else
            {
                message = checkPassword();
            }
            int status = 0;
            if (message == "")
            {

                ulBus = new UserLoginBUS();
                UserLoginDTO ulDto = new UserLoginDTO();
                ulDto.Username = txtUsername.Text;
                ulDto.Password = Common.GetMd5Hash(txtPassword.Text);
                ulDto.Email = txtEmail.Text;
                ulDto.Is_Block = this.chkBlock.Checked;
                ulDto.UserType = 2;
                //tai khoan con ID =3
                ulDto.UserId = 3;
                ConnectionData.OpenMyConnection();
                if (hdfId.Value == null || hdfId.Value == "")//them moi
                {
                   ulBus.tblUserLoginSubClient_insert(ulDto);

                   //lay UserID
                   DataTable dt = ulBus.GetUserIDByUserName(txtEmail.Text);
                    int userID = int.Parse(dt.Rows[0]["UserId"].ToString());
                    ulDto.UserId = userID;

                    //lay clientID
                    DataTable table = ulBus.GetClientId(getUserLogin().UserId);
                    int clienID = int.Parse(table.Rows[0]["clientId"].ToString());
                    ulDto.ClientID = clienID;
                    ulBus.tblSubClient_insert(ulDto);
                    status = 1;
                }
                else
                {

                    ulDto.SubId = int.Parse(hdfId.Value);
                    ulBus.tblSubClient_Update(ulDto);
                    DataTable table1 = ulBus.GetUserIdBySubID(ulDto.SubId);
                    int userID = int.Parse(table1.Rows[0]["UserID"].ToString());
                    bool Is_Block_check = chkBlock.Checked;

                    ulBus.tblUserLoginSub_Update(userID, Is_Block_check);
                    status = 2;

                }

                ConnectionData.CloseMyConnection();
                pnSuccess.Visible = true;
                pnError.Visible = false;
                LoadData();
                if (status == 1)
                {
                    lblSuccess.Text = "Thêm thành công !";
                }
                else
                    if (status == 2)
                    {
                        lblSuccess.Text = "Bạn vừa cập nhật thành công chức năng !";
                        txtUsername.Enabled = true;
                    }

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
            message = "Nhập vào tên tài khoản con !";
        }
        else if (txtEmail.Text == "")
        {
            message = "Nhập vào Email !";
        }
        else if (checkExistUsername(txtUsername.Text))
        {
            message = "Tên tài khoản con đã tồn tại !";
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


    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            pnSuccess.Visible = false;
            pnError.Visible = false;
            int subId = int.Parse((((ImageButton)sender).CommandArgument.ToString()));
            ulBus = new UserLoginBUS();
            DataTable table = ulBus.GetBySubId(subId);
            DataTable table1 = ulBus.GetUserIdBySubID(subId);
            int UserId = int.Parse(table.Rows[0]["UserId"].ToString());
            DataTable dtIsBlock = ulBus.GetIsBlockByUserId(UserId);
            if (table.Rows.Count > 0)
            {
                txtUsername.Text = table.Rows[0]["subName"].ToString();
                txtUsername.Enabled = false;
                txtEmail.Text = table.Rows[0]["subEmail"].ToString();
                txtEmail.Enabled = false;
                bool checkBlock = bool.Parse(dtIsBlock.Rows[0]["Is_Block"].ToString());

                chkBlock.Checked = checkBlock;

                this.hdfId.Value = subId + "";

            }


        }
        catch (Exception)
        {
            pnError.Visible = false;
            pnSuccess.Visible = false;
            throw;
        }
    }

    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int subId = int.Parse((((ImageButton)sender).CommandArgument.ToString()));
            ulBus = new UserLoginBUS();
            ConnectionData.OpenMyConnection();

            DataTable table = ulBus.GetUserIdBySubID(subId);
            int UserId = int.Parse(table.Rows[0]["UserId"].ToString());
            ulBus.tblUserLogin_Delete(UserId);

            ulBus.tblSubClient_Delete(subId);

            //lay UserID
          
            ConnectionData.CloseMyConnection();
            pnError.Visible = false;
            pnSuccess.Visible = true;
            lblSuccess.Text = "Xóa thành công !";
        }
        catch (Exception ex)
        {
            pnError.Visible = true;
            lblError.Text = "Không thể xóa !</br>" + ex.Message;
        }
        LoadData();
    }


    //tam edit
    //protected void lbtEdit_Click(object sender, EventArgs e)
    //{
    //    pnError.Visible = false;
    //    pnSuccess.Visible = false;
    //    int userId = int.Parse(((LinkButton)sender).CommandArgument);
    //    ulBus = new UserLoginBUS();
    //    DataTable tblUser = ulBus.GetByUserId(userId);
    //    if (tblUser.Rows.Count > 0)
    //    {
    //        hdfUserId.Value = tblUser.Rows[0]["UserId"].ToString();
    //        //   drlDepartment.SelectedValue = tblUser.Rows[0]["DepartmentId"].ToString();
    //        txtUsername.Text = tblUser.Rows[0]["Username"].ToString();
    //        txtUsername.Enabled = false;
    //        txtPassword.Text = tblUser.Rows[0]["Password"].ToString();
    //        txtRePassword.Text = tblUser.Rows[0]["Password"].ToString();
    //    }
    //}
    //protected void lbtDelete_Click(object sender, EventArgs e)
    //{
    //    ulBus = new UserLoginBUS();

    //    try
    //    {
    //        int userId = int.Parse(((LinkButton)sender).CommandArgument);

    //        ConnectionData.OpenMyConnection();
    //        ulBus.tblUserLogin_Delete(userId);

    //        // Delete data has created with this user.


    //        ConnectionData.CloseMyConnection();
    //        drlDepartment_SelectedIndexChanged(sender, e);
    //        pnError.Visible = false;
    //        pnSuccess.Visible = true;
    //        lblSuccess.Text = "Xóa thành công !";
    //    }
    //    catch (Exception)
    //    {
    //        pnError.Visible = true;
    //        pnSuccess.Visible = false;
    //        lblSuccess.Text = "Không thể xóa !";
    //    }

    //}
    //protected void btnUpdate_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string message = checkPassword();
    //        if (message == "")
    //        {
    //            ulBus = new UserLoginBUS();                
    //            UserLoginDTO ulDto = new UserLoginDTO();
    //            ulDto.UserId = int.Parse(hdfUserId.Value);
    //         //   ulDto.DepartmentId = int.Parse(drlDepartment.SelectedValue);
    //            ulDto.Username = txtUsername.Text;
    //            ulDto.Password = Common.GetMd5Hash(txtPassword.Text);
    //            ConnectionData.OpenMyConnection();
    //            ulBus.tblUserLogin_Update(ulDto);
    //            ConnectionData.CloseMyConnection();
    //            pnSuccess.Visible = true;
    //            pnError.Visible = false;
    //            loadUserByDepartmentId(ulDto.DepartmentId);
    //            lblSuccess.Text = "Cập nhật thành công !";
    //        }
    //        else
    //        {
    //            pnSuccess.Visible = false;
    //            pnError.Visible = true;
    //            lblError.Text = message;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        pnSuccess.Visible = false;
    //        pnError.Visible = true;
    //        lblError.Text = "Kiểm tra lại dữ liệu nhập vào !";
    //    }
    //}
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
    protected void btnRefesh_Click(object sender, EventArgs e)
    {
        pnError.Visible = false;
        pnSuccess.Visible = false;
        hdfUserId.Value = "";
        txtUsername.Text = "";
        txtUsername.Enabled = true;
        txtPassword.Text = "";
        txtRePassword.Text = "";
        txtEmail.Text = "";
        this.hdfId.Value = "";
    }

}
