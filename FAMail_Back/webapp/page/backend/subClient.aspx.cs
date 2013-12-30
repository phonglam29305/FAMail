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
using System.Net.Mail;

public partial class webapp_page_backend_subClient : System.Web.UI.Page
{
    UserLoginBUS ulBus = null;
    DepartmentBUS deBus = null;

    log4net.ILog logs = log4net.LogManager.GetLogger("ErrorRollingLogFileAppender");
    UserLoginDTO userLogin = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        userLogin = getUserLogin();
        if (!IsPostBack)
        {
            try
            {
                InitBUS();
                LoadData();

            }
            catch (Exception ex)
            {

                logs.Error(userLogin.Username + "-Client - LoadData", ex);
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
        else Response.Redirect("~");
        return null;
    }




    private void LoadData()
    {
        try
        {
            DataTable dtLogin = null;
            ulBus = new UserLoginBUS();
            DataTable table = ulBus.GetClientId(getUserLogin().UserId);
            int clienID = int.Parse(table.Rows[0]["clientId"].ToString());
            if (getUserLogin().DepartmentId == 1)
            {
                dtLogin = ulBus.GetSubClient();
            }
            else if (getUserLogin().DepartmentId == 3)
            {
                dtLogin = ulBus.GetSubClientDepart3(getUserLogin().UserId);
            }
            if (getUserLogin().DepartmentId == 2)
            {
                dtLogin = ulBus.GetSubClientUserID(clienID);
            }
            dlMember.DataSource = dtLogin;
            dlMember.DataBind();

            for (int i = 0; i < dtLogin.Rows.Count; i++)
            {
                Label lblNo = (Label)(Label)dlMember.Items[i].FindControl("No");
                lblNo.Text = (i + 1).ToString();
            }

        }
        catch (Exception ex)
        {

            logs.Error(userLogin.Username + "-Client - LoadData", ex);
        }

    }




    protected void loadUserByDepartmentId(int departId)
    {
        try
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
        catch (Exception ex)
        {
            logs.Error(userLogin.Username + "subClient-Load", ex);
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


    private void Visible(bool p)
    {
        pnError.Visible = p;
        pnSuccess.Visible = p;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataTable table = null;
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

                    if (getUserLogin().DepartmentId == 3)
                    {
                        table = ulBus.GetClientIdSub(getUserLogin().UserId);
                    }
                    else
                    {
                        table = ulBus.GetClientId(getUserLogin().UserId);
                    }

                    int clienID = int.Parse(table.Rows[0]["clientId"].ToString());
                    ulDto.ClientID = clienID;

                    int statusclient = int.Parse(table.Rows[0]["Status"].ToString());

                    DataTable countSubClient = ulBus.GetCountSubClient(ulDto.ClientID);
                    int countSub = int.Parse(countSubClient.Rows[0]["numberSub"].ToString());

                    DataTable subAccount = ulBus.GetSubAccountCount(ulDto.ClientID);
                    int SubAccount = int.Parse(subAccount.Rows[0]["subAccontCount"].ToString());

                    DateTime NgayHetHan = Convert.ToDateTime(table.Rows[0]["expireDate"].ToString());
                    string todays = DateTime.Now.ToString("yyyy-MM-dd");
                    DateTime today = Convert.ToDateTime(todays);
                    DateTime expireDay = Convert.ToDateTime(NgayHetHan);
                    DataTable checkEmail = ulBus.GetEmail(txtEmail.Text.Trim());
                    if (statusclient == 2 || expireDay < today)
                    {
                        status = 3;
                    }
                    else
                    {
                        if (countSub < SubAccount)
                        {
                            if (checkEmail.Rows.Count > 0)
                            {
                                status = 5;
                            }
                            else
                            {
                                ulBus.tblUserLoginSubClient_insert(ulDto);
                                //lay UserID
                                DataTable dt = ulBus.GetUserIDByUserName(txtEmail.Text);
                                int userID = int.Parse(dt.Rows[0]["UserId"].ToString());
                                ulDto.UserId = userID;
                                ulBus.tblSubClient_insert(ulDto);
                                status = 1;
                            }
                        }
                        else
                        {
                            status = 4;
                        }
                    }

                }
                else
                {

                    ulDto.SubId = int.Parse(hdfId.Value);
                    DataTable checkEmail = ulBus.GetEmailByUser(ulDto.SubId, txtEmail.Text.Trim());
                    if (checkEmail.Rows.Count > 0)
                    {
                        status = 5;
                    }
                    else
                    {
                        ulBus.tblSubClient_Update(ulDto);
                        // DataTable table1 = ulBus.GetUserIdBySubID(ulDto.SubId);
                        // int userID = int.Parse(table1.Rows[0]["UserID"].ToString());
                        DataTable tablesub = ulBus.GetBySubId(ulDto.SubId);
                        string Username = tablesub.Rows[0]["subEmail"].ToString();
                        DataTable dtIsBlock = ulBus.GetIsBlockByUserId(Username);
                        bool Is_Block_check = chkBlock.Checked;
                        ulBus.tblUserLoginSub_Update(Username, Is_Block_check);
                        status = 2;
                    }

                }


                ConnectionData.CloseMyConnection();
                pnSuccess.Visible = true;
                pnError.Visible = false;
                LoadData();
                if (status == 5)
                {
                    pnSuccess.Visible = false;
                    pnError.Visible = true;
                    lblError.Text = "Email đã được sử dụng. Vui lòng chọn email khác !";
                    this.txtEmail.Focus();
                }
                if (status == 4)
                {
                    lblError.Text = "Tạo tài khoản con vượt quá giới hạn cho phép!";
                    pnSuccess.Visible = false;
                    pnError.Visible = true;
                }
                if (status == 3)
                {
                    lblError.Text = "Không cho phép tạo tài khoản con.Liên hệ quản trị!";
                    pnSuccess.Visible = false;
                    pnError.Visible = true;
                }
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
            logs.Error(userLogin.Username + "subClient-Save", ex);
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
        else if (IsValidMail(txtEmail.Text.ToString()) == false)
        {
            message = "Bạn nhập không đúng định dạng Email!";
            this.txtEmail.Focus();
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
            string Username = table.Rows[0]["subEmail"].ToString();
            DataTable dtIsBlock = ulBus.GetIsBlockByUserId(Username);
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
        catch (Exception ex)
        {
            pnError.Visible = false;
            logs.Error(userLogin.Username + "subClient-Edit", ex);
        }
    }

    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int subId = int.Parse((((ImageButton)sender).CommandArgument.ToString()));
            ulBus = new UserLoginBUS();
            ConnectionData.OpenMyConnection();

            // DataTable table = ulBus.GetUserIdBySubID(subId);
            //  int UserId = int.Parse(table.Rows[0]["UserId"].ToString());

            DataTable table = ulBus.GetBySubId(subId);
            string Username = table.Rows[0]["subEmail"].ToString();

            ulBus.tblUserLoginSub_Delete(Username);

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
            logs.Error(userLogin.Username + "subClient-Delete", ex);
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
        txtEmail.Enabled = true;
    }

}
