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
using log4net;
using System.Data.SqlClient;

public partial class webapp_page_backend_group_mail : System.Web.UI.Page
{
    MailGroupBUS mgBUS = null;
    SendRegisterBUS srBUS = null;
    CustomerBUS ctBUS = null;
    DetailGroupBUS dgBUS = null;
    UserLoginBUS ulBus = null;
    log4net.ILog logs = log4net.LogManager.GetLogger("ErrorRollingLogFileAppender");
    UserLoginDTO userLogin = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        userLogin = getUserLogin();
        if (!IsPostBack)
        {
            LoadSubClient();
            LoadGroup();
        }
    }

    private UserLoginDTO getUserLogin()
    {
        if (Session["us-login"] != null)
        {
            return (UserLoginDTO)Session["us-login"];
        }
        else Response.Redirect("~");//test confict
        return null;
    }


    private void LoadSubClient()
    {
        try
        {
            InitBUS();
            UserLoginDTO userLogin = getUserLogin();
            dropSubClient.Items.Clear();
            if (userLogin.DepartmentId == 3)
            {

                dropSubClient.DataSource = mgBUS.GetSubClientByAssignUserID(getUserLogin().UserId);
                dropSubClient.DataTextField = "subEmail";
                dropSubClient.DataValueField = "subId";
                dropSubClient.DataBind();
            }
            if (userLogin.DepartmentId == 2)
            {
                DataTable table = ulBus.GetClientId(getUserLogin().UserId);
                if (table.Rows.Count > 0)
                {
                    int clienID = int.Parse(table.Rows[0]["clientId"].ToString());
                    DataTable T = mgBUS.GetSubClient(clienID);
                    DataRow r = T.NewRow();
                    r["subEmail"] = "[Chọn tài khoản con]";
                    r["subId"] = "-1";
                    T.Rows.InsertAt(r, 0);
                    dropSubClient.DataSource = T;
                    dropSubClient.DataTextField = "subEmail";
                    dropSubClient.DataValueField = "subId";
                    dropSubClient.DataBind();
                }

            }
            if (userLogin.DepartmentId == 1)
            {
                dropSubClient.DataSource = mgBUS.GetSubClientAll();
                dropSubClient.DataTextField = "subEmail";
                dropSubClient.DataValueField = "subId";
                dropSubClient.DataBind();
            }
            LoadGroup();
        }
        catch (Exception ex)
        {
            logs.Error(userLogin.Username + "-Client - LoadSubClient", ex);
        }
    }
    private void LoadGroup()
    {
        try
        {
            InitBUS();
            UserLoginDTO userLogin = getUserLogin();
            DataTable tblGroupMail = new DataTable();


            if (userLogin.DepartmentId == 1)
            {
                tblGroupMail = mgBUS.GetAllNew();
            }
            else //if (getUserLogin().DepartmentId == 2)
            {
                tblGroupMail = mgBUS.GetMailGroupByUserId(getUserLogin().UserId);
            }

            dlGroupMail.DataSource = tblGroupMail;
            dlGroupMail.DataBind();
            for (int i = 0; i < tblGroupMail.Rows.Count; i++)
            {
                Label lblNo = (Label)dlGroupMail.Items[i].FindControl("lblNO");
                lblNo.Text = (i + 1).ToString();
            }
        }
        catch (Exception ex)
        {

            logs.Error(userLogin.Username + "-Client - LoadGroup", ex);
        }
    }
    private void InitBUS()
    {
        ulBus = new UserLoginBUS();
        mgBUS = new MailGroupBUS();
        srBUS = new SendRegisterBUS();
        ctBUS = new CustomerBUS();
        dgBUS = new DetailGroupBUS();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            InitBUS();
            UserLoginDTO userLogin = getUserLogin();
            if (checkValid() == true)
            {
                string namecheck = txtGroupName.Text.Trim();
                if (CheckGroupName(namecheck) <= 0)
                {
                    #region Save
                    ConnectionData.OpenMyConnection();
                    MailGroupDTO mgDTO = new MailGroupDTO();
                    mgDTO.Name = txtGroupName.Text;
                    mgDTO.Description = txtDescription.Text;
                    mgDTO.UserId = userLogin.UserId;
                    mgDTO.CreatedBy = userLogin.Username;
                    if (dropSubClient.SelectedValue + "" != "" && dropSubClient.SelectedValue + "" != "-1")
                    {
                        DataTable dtSubUserID = mgBUS.GetSubClientBySubID(int.Parse(dropSubClient.SelectedValue.ToString()));
                        mgDTO.AssignToUserID = int.Parse(dtSubUserID.Rows[0]["UserId"].ToString());
                        mgDTO.AssignTo = dtSubUserID.Rows[0]["subEmail"].ToString();
                    }
                    else
                    {
                        mgDTO.AssignToUserID = -1;
                        mgDTO.AssignTo = "";
                    }
                    int status = 1;
                    if (this.GroupId.Value.ToString() == "" || this.GroupId.Value.ToString() == null)
                    {
                        mgBUS.tblMailGroup_insert(mgDTO);
                        this.txtGroupName.Text = "";
                        this.txtDescription.Text = "";
                        this.txtGroupName.Focus();
                    }
                    else
                    {
                        int ID = int.Parse(GroupId.Value.ToString());
                        mgDTO.Id = ID;
                        mgBUS.tblMailGroup_Update(mgDTO);
                        status = 2;
                    }
                    LoadSubClient();
                    pnSuccess.Visible = true;
                    if (status == 1)
                    {
                        lblSuccess.Text = "Bạn vừa thêm thành công nhóm Email !";
                    }
                    else
                    {
                        lblSuccess.Text = "Thông tin của  nhóm Email đã được cập nhật !";
                    }
                    ConnectionData.CloseMyConnection();
                    pnError.Visible = false;
                    #endregion
                }
                else
                {
                    pnError.Visible = true;
                    lblError.Text = "Tên nhóm Mail đã tồn tại trong hệ thống !";
                    pnSuccess.Visible = false;
                }
            }
            else
            {
                pnError.Visible = true;
                lblError.Text = "Bạn chưa nhập Tên Nhóm Mail !";
                pnSuccess.Visible = false;
            }

        }
        catch (Exception ex)
        {

            logs.Error(userLogin.Username + "-Client - btnSave_Click", ex);
        }
        LoadGroup();
    }
    private int CheckGroupName(string name)
    {
        int count = 0;
        UserLoginDTO userLogin = getUserLogin();
        int clientID = getUserLogin().UserId;
        string sql = "SELECT * FROM tblMailGroup Where UserId='" + clientID + "'";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        if (table.Rows.Count > 0)
        {
            foreach (DataRow dr in table.Rows)
            {
                string tempName = dr["Name"].ToString();
                if (tempName == name)
                {
                    count++;
                }
            }
        }
        return count;
    }
    private bool checkValid()
    {
        if (txtGroupName.Text == "" || txtGroupName.Text == null)
        {
            return false;
        }
        return true;

    }
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        ConnectionData.OpenMyConnection();
        try
        {
            InitBUS();
            int Id = int.Parse(((ImageButton)sender).CommandArgument.ToString());
            DataTable dtGroup = mgBUS.GetByID(Id);
            if (dtGroup.Rows.Count > 0)
            {
                if (dtGroup.Rows[0]["AssignTo"] != null && dtGroup.Rows[0]["AssignTo"].ToString() != "" && dtGroup.Rows[0]["AssignToUserID"].ToString() != "-1")
                {
                    int AssignToUserID = int.Parse(dtGroup.Rows[0]["AssignToUserID"].ToString());
                    DataTable dt = mgBUS.GetSubClientByAssignUserID(AssignToUserID);
                    dropSubClient.SelectedValue = dt.Rows[0]["subId"].ToString();
                }
                DataRow row = dtGroup.Rows[0];
                GroupId.Value = Id.ToString();
                txtGroupName.Text = row["Name"].ToString();
                //txtGroupName.Enabled = false;
                txtDescription.Text = row["Description"].ToString();
            }

        }
        catch (Exception ex)
        {

            logs.Error(userLogin.Username + "-Client - btnEdit_Click", ex);
            pnError.Visible = true;
            lblError.Text = "Đã có lỗi : " + ex.ToString();
        }
        ConnectionData.CloseMyConnection();

    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        int dem = 0;
        int hcount = 0;
        try
        {
            int Id = int.Parse(((ImageButton)sender).CommandArgument.ToString());
            ConnectionData.OpenMyConnection();
            InitBUS();
            //if (dgBUS.GetByID(Id).Rows.Count == 0)
            //{
            hcount += CheckSendin24h(Id);
            dem += CheckEventDate(Id);
            if (dem != 0 || hcount != 0)
            {
                if (dem >= 1)
                {
                    visibleMessage(true);
                    pnSuccess.Visible = false;
                    lblError.Text = "Nhóm mail đang có " + dem + " sự kiện .Xin vui lòng xóa sự kiện trước";
                }
                else if (hcount >= 1)
                {
                    visibleMessage(true);
                    pnSuccess.Visible = false;
                    lblError.Text = "Nhóm mail vừa gửi email đi trong vòng 24 tiếng.Không thể xóa nhóm mail này";
                }
            }
            else
            {
                //mgBUS.tblMailGroup_Delete(Id);
                //Response.Redirect(Request.RawUrl);
                //dgBUS.tblDetailGroup_DeleteByGroup(Id);
                UpdateDelete(Id);
                UpdateGroupDelele(Id);
                LoadGroup();
                visibleMessage(false);
                pnSuccess.Visible = true;
                lblSuccess.Text = "Bạn vừa xóa thành công nhóm mail !";
            }
            //}
            //else
            //{
            //    pnError.Visible = true;
            //    lblError.Text = "Bạn không thể xóa nhóm mail này ! ";
            //}
            ConnectionData.CloseMyConnection();
        }
        catch (Exception ex)
        {
            logs.Error(userLogin.Username + "-Group-Mail - btnDelete_Click", ex);
            pnError.Visible = true;
            lblError.Text = ex.Message;
        }
    }
    protected void visibleMessage(bool vis)
    {
        pnError.Visible = vis;
        pnSuccess.Visible = vis;
    }
    protected void btnRefesh_Click(object sender, EventArgs e)
    {
        txtGroupName.Text = "";
        txtGroupName.Enabled = true;
        txtDescription.Text = "";
        dropSubClient.SelectedIndex = 0;
    }
    private int CheckSendin24h(int groupId)
    {
        int count = 0;
        string sql = "SELECT * FROM tblSendRegister Where GroupTo='" + groupId + "'";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        if (table.Rows.Count > 0)
        {
            foreach (DataRow dr in table.Rows)
            {
                DateTime startDate = Convert.ToDateTime(dr["StartDate"].ToString());
                DateTime endDate = Convert.ToDateTime(dr["EndDate"].ToString());
                DateTime today = DateTime.Now;
                double dayleft = (today - startDate).TotalHours;
                double dayleft2 = (today - endDate).TotalHours;
                if (dayleft >= 24 || dayleft2 >= 24)
                {
                    count += 1;
                }
            }
        }
        return count;
    }
    private int CheckEventDate(int groupId)
    {
        int count = 0;
        string sql = "SELECT * FROM tblEvent Where groupId='" + groupId + "'";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        if (table.Rows.Count > 0)
        {
            foreach (DataRow dr in table.Rows)
            {
                DateTime startDate = Convert.ToDateTime(dr["StartDate"].ToString());
                DateTime EndDate = Convert.ToDateTime(dr["EndDate"].ToString());
                DateTime today = DateTime.Now;
                double dayleft = (today - startDate).TotalHours;
                double dayleft2 = (today - EndDate).TotalHours;
                if (dayleft >= 24 || dayleft2 >= 24)
                {
                    count += 1;
                }
            }
        }
        else
        {
            count = 0;
        }
        return count;
    }
    private void UpdateDelete(int Id)
    {
        string sql = "Update tblMailGroup set IsDelete='1' Where Id='" + Id + "'";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
    }
    private void UpdateGroupDelele(int Id)
    {
        string sql = "Update tblCustomer set IsDelete='1' Where assignTo='" + Id + "'";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
    }
    protected void dlGroupMail_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        UserLoginDTO userLogin = getUserLogin();
        int type = userLogin.UserType;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ImageButton imgEdit = (ImageButton)e.Item.FindControl("btnEdit");
            ImageButton imgDelete = (ImageButton)e.Item.FindControl("btnDelete");
            if (type == 0)
            {
                imgDelete.Visible = false;
                imgEdit.Visible = false;
            }
        }
    }
}
