﻿using Email;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webapp_page_backend_PackageLimit : System.Web.UI.Page
{
    PackageLimitBUS packageBus = new PackageLimitBUS();
    log4net.ILog logs = log4net.LogManager.GetLogger("ErrorRollingLogFileAppender");
    UserLoginDTO userLogin = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        userLogin = getUserLogin();
        if (!IsPostBack)
        {
            try
            {
                LoadData();
            }
            catch (Exception)
            {


            }
        }
    }

    private string checkInput()
    {
        string masseng = "";
        int i = 0;
        if (txtnamepackagelimit.Text == "")
        {
            masseng = "Vui lòng nhập tên gói giới hạn";
        }
        else if (kiemtraso(txtcode.Text) == false)
        {
            masseng = "Vui lòng nhập giá đúng định dạng";
        }
        else if (txtcode.Text == "")
        {
            masseng = "Vui lòng nhập giá vào ";
        }
        else if (kiemtraso(txtunder.Text) == false)
        {
            masseng = "Vui lòng nhập số giới hạn mail đúng định dạng";
        }
        else if (!ceUnLimit.Checked && (txtunder.Text == "" || !int.TryParse(txtunder.Text + "", out i)))
        {
            masseng = "Vui lòng nhập số giới hạn mail";
        }
        else if (validate_namepackagelimit(txtnamepackagelimit.Text,hdfId.Value))
        {
            masseng = "Chức năng này đã tồn tại trong hệ thống";
        }
        else
        {
            int.TryParse(txtunder.Text + "", out i);
            if (!ceUnLimit.Checked && i <= 0)
                masseng = "Giới hạn mail phải lớn hơn 0";
        }
        return masseng;
    }
    protected bool validate_namepackagelimit(string namepackagelimit,object id)
    {
        DataTable table = packageBus.viladate_Packagelimint(namepackagelimit,id);
        if (table.Rows.Count > 0)
        {
            return true;
        }
        return false;
    }
    private bool kiemtraso(string chuoi)
    {
        foreach (char k in chuoi)
        {
            if (char.IsDigit(k) == false)
                return false;
        }

        return true;
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
    private PackageLimitDTO getpackageDTO()
    {
        PackageLimitDTO sign = new PackageLimitDTO();
        int id = 0;
        Int32.TryParse(hdfId.Value + "", out id);
        sign.limitId = id;
        sign.namepackagelimit = txtnamepackagelimit.Text;
        if (!ceUnLimit.Checked)
            sign.under = Int32.Parse(txtunder.Text);
        sign.cost = float.Parse(txtcode.Text);
        sign.isUnLimit = ceUnLimit.Checked;
        sign.isActive = ceIsActive.Checked;
        

        return sign;


    }
    private void LoadData()
    {


        dtfunction.DataSource = packageBus.GetAll().DefaultView;
        dtfunction.DataBind();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            string message = checkInput();
            int status = 0;
            if (message == "")
            {

                PackageLimitDTO packageDto = getpackageDTO();
                if (hdfId.Value == null || hdfId.Value == "")//them moi
                {
                    packageBus.tblPackageLimit_insert(packageDto);
                    status = 1;
                }
                else
                {
                    packageBus.tblPackageLimit_Update(packageDto);
                    status = 2;
                    hdfId.Value = null;
                }
                pnSuccess.Visible = true;
                if (status == 1)
                {
                    lblSuccess.Text = "Bạn vừa thêm thành công chức năng !";
                }
                else
                    if (status == 2)
                    {
                        lblSuccess.Text = "Bạn vừa cập nhật thành công chức năng !";
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
            lblError.Text = " Đã xảy ra lỗi trong quá trình thực hiện. Vui lòng thử lại !<br/>" + ex.Message;
            logs.Error(userLogin.Username + "- PLimit - Update", ex);
        }
        LoadData();
        txtcode.Text = "";
        txtnamepackagelimit.Text = "";
        txtunder.Text = "";
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        int limitId = int.Parse(((ImageButton)sender).CommandArgument.ToString());
        
        int dem = 0;
        DataTable table_package = packageBus.check_delete_package(limitId);

        for (int i = 0; i < table_package.Rows.Count; i++)
        {
            int tam = int.Parse(table_package.Rows[i]["limitId"].ToString());

            if (tam == limitId)
            {
                dem++;
                pnSuccess.Visible = false;
                pnError.Visible = true;
                lblError.Text = "Không xóa được vì có chức năng khác đăng sử dụng";

            }
        }
        DataTable table_clientregister = packageBus.check_delete_clientregister(limitId);
        for (int i = 0; i < table_clientregister.Rows.Count; i++)
        {
            int tam1 = int.Parse(table_clientregister.Rows[i]["limitId"].ToString());
            if (tam1 == limitId)
            {
                dem++;
                pnSuccess.Visible = false;
                pnError.Visible = true;
                lblError.Text = "Không xóa được vì có chức năng khác đăng sử dụng";

            }
        }
        if (dem == 0)
        {
            try
            {


                packageBus.tblPackageLimit_Delete(limitId);
                LoadData();
                pnError.Visible = false;
                pnSuccess.Visible = true;
                lblSuccess.Text = "Bạn vừa xóa chữ ký thành công !";
            }
            catch (Exception ex)
            {

                pnError.Visible = true;
                lblError.Text = "Không thể xóa !</br>" + ex.Message;
            }
        }
    }
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            pnSuccess.Visible = false;
            pnError.Visible = false;

            int limitId = int.Parse((((ImageButton)sender).CommandArgument.ToString()));
            DataTable table = packageBus.GetByUserIdPackageLimit(limitId);
            if (table.Rows.Count > 0)
            {

                txtnamepackagelimit.Text = table.Rows[0]["namepackagelimit"].ToString();
                txtunder.Text = table.Rows[0]["under"].ToString();
                txtcode.Text = table.Rows[0]["cost"].ToString();
                ceUnLimit.Checked = Convert.ToBoolean(table.Rows[0]["IsUnlimit"]);
                ceIsActive.Checked = Convert.ToBoolean(table.Rows[0]["IsActive"]);
                hdfId.Value = limitId+"";
            }


        }
        catch (Exception ex)
        {

            logs.Error(userLogin.Username + "- edit - Edit", ex);
        }
    }
}