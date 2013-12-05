using Email;
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
    protected void Page_Load(object sender, EventArgs e)
    {
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

        if (txtnamepackagelimit.Text == "")
        {
            masseng = "Vui lòng nhập tên gói giới hạn";
        }
        else if (kiemtraso(txtcode.Text )== false)
        {
            masseng = "Vui lòng nhập giá đúng định dạng";
        }
        else if (txtcode.Text == "")
        {
            masseng = "Vui lòng nhập giá vào ";
        }
        else if (kiemtraso(txtunder.Text) ==false)
        {
            masseng = "Vui lòng nhập số giới hạn mail đúng định dạng";
        }
        else if (txtunder.Text == "")
        {
            masseng = "Vui lòng nhập số giới hạn mail";
        }
        return masseng;
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
        return null;
    }
    private PackageLimitDTO getpackageDTO()
    {
        PackageLimitDTO sign = new  PackageLimitDTO();
        UserLoginDTO userLogin = getUserLogin();
        if (userLogin != null)
        {
            sign.limitId = userLogin.UserId;
            sign.namepackagelimit = txtnamepackagelimit.Text;
            sign.under = Int64.Parse(txtunder.Text);
            sign.cost = float.Parse(txtcode.Text);

        }
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
                ConnectionData.OpenMyConnection();
                if (hdfId.Value == null || hdfId.Value == "")//them moi
                {
                    packageBus.tblPackageLimit_insert(packageDto);
                    status = 1;
                }
                else
                {
                    packageBus.tblPackageLimit_Update(packageDto);
                    status = 2;
                }
                ConnectionData.CloseMyConnection();
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
        catch (Exception)
        {

            pnSuccess.Visible = false;
            pnError.Visible = true;
            lblError.Text = " Đã xảy ra lỗi trong quá trình thực hiện. Vui lòng thử lại !";
        }
        LoadData();
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int limitId = int.Parse(((ImageButton)sender).CommandArgument.ToString());
           
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
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int limitId =int.Parse( (((ImageButton)sender).CommandArgument.ToString()));
            DataTable table = packageBus.GetByUserIdPackageLimit(limitId);
            if (table.Rows.Count > 0)
            {

                txtnamepackagelimit.Text = table.Rows[0]["namepackagelimit"].ToString();
                txtunder.Text = table.Rows[0]["under"].ToString();
                txtcode.Text = table.Rows[0]["cost"].ToString();


            }


        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void btnCreateNew_Click(object sender, EventArgs e)
    {




               PackageLimitDTO ulDto = new PackageLimitDTO();
               //ulDto.limitId = int.Parse(hdfId.Value);
               ulDto.namepackagelimit = txtnamepackagelimit.Text;
               ulDto.under = Int64.Parse(txtunder.Text);
               ulDto.cost = float.Parse(txtcode.Text);
                
                ConnectionData.OpenMyConnection();
             
                packageBus.tblPackageLimit_Update(ulDto);
                ConnectionData.CloseMyConnection();
                pnSuccess.Visible = true;
                pnError.Visible = false;
                
           
    }
}