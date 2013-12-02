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

    private void LoadDepartmentList()
    {
        try
        {
            DataTable tblDepart = dpBUS.GetAll();
            dlDepartment.DataSource = tblDepart;
            dlDepartment.DataBind();
            for (int i = 0; i < tblDepart.Rows.Count; i++)
            {
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
                lblError.Text = "Bạn không thể xóa phòng ban này được! Bạn có những cấu hình mail gửi trong phòng ban này";
            }
            else
            {
                dpBUS.tblDepartment_Delete(Id);
                Visible(false);
                pnSuccess.Visible = true;
                lblSuccess.Text = "Bạn vừa xóa thành công phong ban ID: "+ Id.ToString();
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
         InitBUS();
        DepartmentDTO dpDTO = new DepartmentDTO();
        dpDTO.Name = this.txtDepartment.Text;
        dpDTO.Description = this.txtDescription.Text;
        dpDTO.Role = 1; // Mac dinh la 1, khong quan ly
        ConnectionData.OpenMyConnection();
        dpBUS.tblDepartment_insert(dpDTO);
        Visible(false);
        pnSuccess.Visible = true;
        lblSuccess.Text = "Bạn đã thêm thành công một phòng ban!";
        LoadDepartmentList();
        ConnectionData.CloseMyConnection();
        }
        catch (Exception)
        {
        }
        
    }
}
