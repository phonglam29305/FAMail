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

public partial class webapp_page_backend_Department : System.Web.UI.Page
{
    DepartmentBUS dpBUS = null;
    MailConfigBUS mcBUS = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitBUS();
            LoadDepartmentList();
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

    private void LoadDepartmentList()
    {
        try
        {
            DataTable tblDepart = null;
            if (getUserLogin().DepartmentId == 1)
           {
                tblDepart = dpBUS.GetAll();
           }
           else
            {
               tblDepart = dpBUS.GetByUserID(getUserLogin().UserId);
           }

            dlDepartment.DataSource = tblDepart;
            dlDepartment.DataBind();
            for (int i = 0; i < tblDepart.Rows.Count; i++)
            {
                Label lblNo = (Label)(Label)dlDepartment.Items[i].FindControl("No");
                lblNo.Text = (i + 1).ToString();

                ImageButton btnDelete = (ImageButton)dlDepartment.Items[i].FindControl("btnDelete");
                HyperLink hplSettingRole = (HyperLink)dlDepartment.Items[i].FindControl("hplSettingRole");
                if (int.Parse(tblDepart.Rows[i]["ID"].ToString()) == 1)
                {
                    btnDelete.Visible = false;
                    hplSettingRole.Visible = false;
                }
            }

        }
        catch (Exception)
        {
        }

    }

    private void InitBUS()
    {
        dpBUS = new DepartmentBUS();
        mcBUS = new MailConfigBUS();
    }

    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {

        try
        {
            ConnectionData.OpenMyConnection();
            int Id = int.Parse(((ImageButton)sender).CommandArgument.ToString());
            InitBUS();
            if (mcBUS.GetAll(Id).Rows.Count > 0)
            {
                Visible(false);
                pnError.Visible = true;
               lblError.Text = "Bạn không thể xóa nhóm người dùng này được! Bạn có những cấu hình mail gửi trong nhóm người dùng này";
            }
            else
            {
                dpBUS.tblDepartment_Delete(Id);
                Visible(false);
                pnSuccess.Visible = true;
                lblSuccess.Text = "Bạn vừa xóa thành công ID: " + Id.ToString();
                LoadDepartmentList();
            }
            ConnectionData.CloseMyConnection();

        }
        catch (Exception ex)
        {


        }
    }

    private void Visible(bool p)
    {
        this.pnError.Visible = p;
        this.pnSuccess.Visible = p;
    }


    protected string checkInput()
    {
        string message = "";
        if (txtDepartment.Text == "")
        {
            message = "Nhập vào tên nhóm người dùng !";
        }
        else if (checkExistUsername(txtDepartment.Text))
        {
            message = "Tên nhóm người dùng đã tồn tại !";
        }
      
        return message;
    }
    protected bool checkExistUsername(string username)
    {
        dpBUS = new DepartmentBUS();
        DataTable tblUser = dpBUS.GetByUsername(username);
        if (tblUser.Rows.Count > 0)
        {
            return true;
        }
        return false;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            InitBUS();
            string message = checkInput();
          
            if (message == "")
            {

            DepartmentDTO dpDTO = new DepartmentDTO();
            dpDTO.Name = this.txtDepartment.Text;
            dpDTO.Description = this.txtDescription.Text;
            dpDTO.UserId = getUserLogin().UserId; // Mac dinh la 1, khong quan ly
            dpDTO.UserType = int.Parse(this.dropTypeUser.SelectedItem.Value.ToString());
            ConnectionData.OpenMyConnection();
            dpBUS.tblDepartment_insert(dpDTO);
            Visible(false);
            pnSuccess.Visible = true;
            lblSuccess.Text = "Bạn đã thêm thành công!";
            LoadDepartmentList();
            ConnectionData.CloseMyConnection();
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
        }

    }
}
