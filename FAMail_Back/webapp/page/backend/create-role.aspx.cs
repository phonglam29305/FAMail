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
using System.Drawing;

public partial class webapp_page_backend_create_role : System.Web.UI.Page
{
    DepartmentBUS dmBus = null;
    RoleListBUS rlBus = null;
    RoleDetailBUS rdBus = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                loadBasicRole();
                loadAdvanceRole();
            }
            catch (Exception)
            {
                pnError.Visible = true;
                lblError.Text = "Vui lòng chọn phòng ban cần phân quyền !";
            }            
        }
        
    }

    private void loadAdvanceRole()
    {
        rdBus = new RoleDetailBUS();
        String departmentId = Request.QueryString["departmentId"];

        // Kiểm tra user đang login có được cấp quyền nâng cao.
        DataTable dtAdvanceRoleWithAdmin = rdBus.GetByDepartmentIdAndRole(-1, getUserLogin().DepartmentId);
        if (dtAdvanceRoleWithAdmin.Rows.Count > 0)
        {
            // Hiển thị quyền nâng cao với user đang chọn.
            PanelAdvanceRole.Visible = true;
            DataTable dtAdvanceRole = rdBus.GetByDepartmentIdAndRole(-1, int.Parse(departmentId));
            if (dtAdvanceRole.Rows.Count > 0)
            {
                chkAdvance.Checked = true;
                txtLimitMailSend.Text = dtAdvanceRole.Rows[0]["limitSendMail"].ToString();
                txtLimitCreateCustomer.Text = dtAdvanceRole.Rows[0]["limitCreateCustomer"].ToString();
                DateTime toDate = DateTime.Parse(dtAdvanceRole.Rows[0]["toDate"].ToString());
                txtToDate.Text = toDate.Day + "/" + toDate.Month + "/" + toDate.Year;
            }

        }
        else
        {
            // Ẩn module phân quyền nâng cao.
            PanelAdvanceRole.Visible = false;
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
    protected void loadBasicRole()
    {
        String departmentId = Request.QueryString["departmentId"];
        dmBus = new DepartmentBUS();
        rlBus = new RoleListBUS();
        rdBus = new RoleDetailBUS();
        DataTable tblDepartment = dmBus.GetByID(int.Parse(departmentId));
        if (tblDepartment.Rows.Count > 0)
        {
            string info = tblDepartment.Rows[0]["Name"].ToString();
                    lblDepartmentName.Text = info;
        }

        //load role list
        DataTable dtRoleList = null;
        if (getUserLogin().DepartmentId == 1)
        {
            dtRoleList = rlBus.GetAll();
        }
        else
        {
            // load role list by role admin level 2.
            dtRoleList = rlBus.GetRoleByDepartmentId(getUserLogin().DepartmentId);
        }

        // Lấy danh sách quyền của phòng ban được chọn.
        DataTable dtRoleDetail = rdBus.GetByDepartmentId(int.Parse(departmentId));     
  
        // Không hiển thị với phân quyền tạo phòng ban & tạo user với admin cấp 2
        DataTable dtNewRoleList = dtRoleList.Clone();
        foreach (DataRow row in dtRoleList.Rows)
        {
            // Không hiển thị chức năng cấp quyền tạo phòng ban & tạo user
            // Với user thuộc phòng ban tấp 2
            if (getUserLogin().DepartmentId != 1
                && (int.Parse(row["roleId"].ToString()) == 9
                || int.Parse(row["roleId"].ToString()) == 22))
            {
                continue;
            }
            else
            {

                dtNewRoleList.ImportRow(row);
            }
        }

        dlRoleList.DataSource = dtNewRoleList;
        dlRoleList.DataBind();
        for (int i = 0; i < dtNewRoleList.Rows.Count; i++)
        {
            DataRow row = dtNewRoleList.Rows[i];
            string roleId = row["roleId"].ToString();            
            
            HiddenField hdfRoleId = (HiddenField)dlRoleList.Items[i].FindControl("hdfRoleId");
            hdfRoleId.Value = roleId;

            //selected role with department
            CheckBox chkCheck = (CheckBox)dlRoleList.Items[i].FindControl("chkCheck");
            for (int j = 0; j < dtRoleDetail.Rows.Count; j++)
            {
                int rId = int.Parse(dtRoleDetail.Rows[j]["roleId"].ToString());
                if (rId == int.Parse(roleId))
                {
                    chkCheck.Checked = true;
                    break;
                }
            }          

            Label lblRoleName = (Label)dlRoleList.Items[i].FindControl("lblRoleName");
            lblRoleName.Text = row["roleName"]!=null?row["roleName"].ToString():"";
            if (int.Parse(roleId) >= 100) // Là những tùy chọn chức năng chính.
            {
                lblRoleName.ForeColor = Color.Red;
            }
                    
        }
        hdfDepartmentId.Value = departmentId;
    }
    
    protected bool checkExistRole(int roleId, int departmentId)
    {        
        rdBus = new RoleDetailBUS();
        DataTable dtRoleDetail = rdBus.GetByDepartmentIdAndRole(roleId, departmentId);
        //check exists role in role_detail
        if (dtRoleDetail.Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected void checkNewOldRole(DataTable oldRole, DataTable insertRole, int currentRole)
    {
        DataRow row = null;
        bool find = false;
        for (int i = 0; i < oldRole.Rows.Count; i++)
        {
            row = oldRole.Rows[i];
            if(int.Parse(row["roleId"].ToString())==currentRole){
                find = true;
                oldRole.Rows.Remove(row);
                break;
            }
        }

        if (!find)
        {
            insertRole.Rows.Add(currentRole);
        }
    }
    protected void lbtChangeRole_Click(object sender, EventArgs e)
    {        
        try
        {
            // Get role list by departmentId
            int departId = int.Parse(hdfDepartmentId.Value.ToString());
            rdBus = new RoleDetailBUS();
            DataTable dtOldRole = rdBus.GetByDepartmentId(departId);

            DataTable insertRole = new DataTable();
            insertRole.Columns.Add("roleId", typeof(int));

            //iterator to check new_role with old_role
            for (int i = 0; i < dlRoleList.Items.Count; i++)
            {                
                CheckBox chkCheck = (CheckBox)dlRoleList.Items[i].FindControl("chkCheck");
                HiddenField hdfRoleId = (HiddenField)dlRoleList.Items[i].FindControl("hdfRoleId");
                if (chkCheck.Checked)
                {
                    checkNewOldRole(dtOldRole, insertRole, int.Parse(hdfRoleId.Value));
                }
            }
            //delete old role
            if (dtOldRole.Rows.Count > 0)
            {
                for (int j = 0; j < dtOldRole.Rows.Count; j++)
                {
                    int roleId = int.Parse(dtOldRole.Rows[j]["roleId"].ToString());
                    ConnectionData.OpenMyConnection();
                    rdBus.tblRoleDetail_Delete(roleId,departId);
                    ConnectionData.CloseMyConnection();
                }
            }

            //insert new role
            if (insertRole.Rows.Count > 0)
            {
                for (int k = 0; k < insertRole.Rows.Count; k++)
                {
                    int roleId = int.Parse(insertRole.Rows[k]["roleId"].ToString());
                    RoleDetailDTO rdDto = new RoleDetailDTO();
                    rdDto.roleId = roleId;
                    rdDto.departmentId = departId;
                    rdDto.limitSendMail = 0; // Set default value.
                    rdDto.limitCreateCustomer = 0; // Set default value
                    rdDto.toDate = DateTime.Now; // Set default value

                    ConnectionData.OpenMyConnection();
                    rdBus.tblRoleDetail_insert(rdDto);
                    ConnectionData.CloseMyConnection();
                }
            }

            pnSuccess.Visible = true;
            pnError.Visible = false;
            lblSuccess.Text = "Đã thay đổi quyền thành công !";
        }
        catch (Exception)
        {            
            throw;
        }
    }
    protected void lbtChangeAdvance_Click(object sender, EventArgs e)
    {
        try
        {
            RoleDetailBUS rdBus = new RoleDetailBUS();
            PanelAdvance.Visible = false;
            int departmentId = int.Parse(hdfDepartmentId.Value);
            int limitSendMail = int.Parse(txtLimitMailSend.Text);
            string toDate = txtToDate.Text;
            int limitCreateCustomer = int.Parse(txtLimitCreateCustomer.Text);

            if (chkAdvance.Checked)
            {
                // Cap nhat voi hang ngach gui mail, tao khach hang.
                RoleDetailDTO rdDto = new RoleDetailDTO();
                rdDto.roleId = -1;
                rdDto.departmentId = departmentId;
                rdDto.limitSendMail = limitSendMail;
                rdDto.limitCreateCustomer = limitCreateCustomer;
                rdDto.toDate = convertStringToDate(toDate);
                ConnectionData.OpenMyConnection();
                int rsUpdate = rdBus.tblRoleDetail_Update(rdDto);
                ConnectionData.CloseMyConnection();
                if (rsUpdate <= 0)
                {
                    // Them voi hang ngach gui mail, tao khach hang.
                    ConnectionData.OpenMyConnection();
                    rdBus.tblRoleDetail_insert(rdDto);
                    ConnectionData.CloseMyConnection();
                } 

                // Reset thong tin so luong da gui mail cua tat ca user trong group.
                UserLoginBUS ulBus = new UserLoginBUS();
                ConnectionData.OpenMyConnection();
                ulBus.tblUserLogin_UpdateByDepartmentId(departmentId, 0);
                ConnectionData.CloseMyConnection();
            }
            else
            {
                // Xóa phân quyền nâng cao.
                ConnectionData.OpenMyConnection();
                rdBus.tblRoleDetail_Delete(-1, departmentId);
                ConnectionData.CloseMyConnection();
            }

            PanelAdvanceSuccess.Visible = true;
            lblAdvanceSuccess.Text = "Cập nhập thành công !";
  
        }
        catch (Exception)
        {
            PanelAdvanceSuccess.Visible = false;
            PanelAdvance.Visible = true;
            lblAdvanceError.Text = "Kiểm tra lại dữ liệu nhập !";
        }
    }
    protected DateTime convertStringToDate(string strDate)
    {
        int day = int.Parse(strDate.Substring(0, 2));
        int month = int.Parse(strDate.Substring(3, 2));
        int year = int.Parse(strDate.Substring(6, 4));        
        DateTime dDate = new DateTime(year, month, day);
        return dDate;
    }
    
}
