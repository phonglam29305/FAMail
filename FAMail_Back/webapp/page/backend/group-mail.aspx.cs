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

public partial class webapp_page_backend_group_mail : System.Web.UI.Page
{
    MailGroupBUS mgBUS = null;
    SendRegisterBUS srBUS = null;
    CustomerBUS ctBUS = null;
    DetailGroupBUS dgBUS= null;
    UserLoginBUS ulBus = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        
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
        return null;
    }


    private void LoadSubClient()
    {
         try
        {
            InitBUS();
            dropSubClient.Items.Clear();
            
            DataTable table = ulBus.GetClientId(getUserLogin().UserId);
            if (table.Rows.Count > 0)
            {
                int clienID = int.Parse(table.Rows[0]["clientId"].ToString());
                dropSubClient.DataSource = mgBUS.GetSubClient(clienID);
                dropSubClient.DataTextField = "subEmail";
                dropSubClient.DataValueField = "subId";
                dropSubClient.DataBind();
            }
        }
         catch (Exception ex)
         {
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
            else
            {
                tblGroupMail = mgBUS.GetAllNew(userLogin.UserId);
            }
            dlGroupMail.DataSource = tblGroupMail;
            dlGroupMail.DataBind();
            for (int i = 0; i < tblGroupMail.Rows.Count; i++ )
            {
                Label lblNo = (Label)dlGroupMail.Items[i].FindControl("lblNO");
                lblNo.Text = (i + 1).ToString();
            }

        }
        catch (Exception ex)
        {
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
        InitBUS();
        UserLoginDTO userLogin = getUserLogin();
        if (checkValid() == true)
        {
            ConnectionData.OpenMyConnection();
            MailGroupDTO mgDTO = new MailGroupDTO();
            mgDTO.Name = txtGroupName.Text;
            mgDTO.Description = txtDescription.Text;
            mgDTO.UserId = userLogin.UserId;
            mgDTO.CreatedBy = userLogin.Username;
            DataTable dtSubUserID = mgBUS.GetSubClientBySubID(int.Parse(dropSubClient.SelectedValue.ToString()));
            mgDTO.AssignToUserID =int.Parse(dtSubUserID.Rows[0]["UserId"].ToString());
            mgDTO.AssignTo = dtSubUserID.Rows[0]["subEmail"].ToString();
            int status = 1;
            if (this.GroupId.Value.ToString() == "" || this.GroupId.Value.ToString() == null )
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
        }
        else
        {
                pnError.Visible = true;
                lblError.Text = "Lỗi trong qua trình nhập! Bạn phải nhập dữ liệu !";
                pnSuccess.Visible = false;
        }
        LoadGroup();

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
                if (dtGroup.Rows[0]["AssignTo"].ToString() != null || dtGroup.Rows[0]["AssignTo"].ToString() != "")
                {
                    int AssignToUserID = int.Parse(dtGroup.Rows[0]["AssignToUserID"].ToString());
                    DataTable dt = mgBUS.GetSubClientByAssignUserID(AssignToUserID);
                    dropSubClient.SelectedValue = dt.Rows[0]["subId"].ToString();
                }
                DataRow row = dtGroup.Rows[0];
                GroupId.Value = Id.ToString();
                txtGroupName.Text = row["Name"].ToString();
               
                txtDescription.Text = row["Description"].ToString();
            }
            
        }
        catch (Exception ex)
        {
            pnError.Visible = true;
            lblError.Text = "Đã có lỗi : "+ex.ToString() ;
        }
        ConnectionData.CloseMyConnection();
       
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int Id = int.Parse(((ImageButton)sender).CommandArgument.ToString());
           
            ConnectionData.OpenMyConnection();
            InitBUS();
            if (dgBUS.GetByID(Id).Rows.Count == 0)
            {
                mgBUS.tblMailGroup_Delete(Id);
                //Response.Redirect(Request.RawUrl);
                dgBUS.tblDetailGroup_DeleteByGroup(Id);
                LoadGroup();
                visibleMessage(false);
                pnSuccess.Visible = true;
                lblSuccess.Text = "Bạn vừa xóa thành công nhóm mail !";
            }
            else
            {
                pnError.Visible = true;
                lblError.Text = "Bạn không thể xóa nhóm mail này ! ";
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
