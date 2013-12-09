using Email;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webapp_page_backend_Package : System.Web.UI.Page
{
    PackageBUS packageBus = new PackageBUS();
    protected void Page_Load(object sender, EventArgs e)
    {      
        if (!IsPostBack)
        {
            try
            {
                package();
                LoadData();
                hdfId.Value = null;
            }
            catch (Exception)
            {


            }
        }
    }
    public void xoatextbok()
    {
        txtdiengiai.Text="";
        txtsubaccount.Text = "";
        txtname.Text = "";
    }
    private UserLoginDTO getUserLogin()
    {
        if (Session["us-login"] != null)
        {
            return (UserLoginDTO)Session["us-login"];
        }
        return null;
    }
    private PackageDTO getpackge_insert()
    {
    
        PackageDTO sign = new PackageDTO();
        UserLoginDTO userLogin = getUserLogin();
        if (userLogin != null)
        {
            int temp = 0;
            //sign.functionId = Convert.ToInt32(hdfId.Value);
            sign.packageId = userLogin.UserId;
            sign.packageName=txtname.Text;
            sign.diengiai = txtdiengiai.Text;
            int.TryParse(txtsubaccount.Text, out temp);
            sign.subAccontCount = temp;
            int.TryParse(drlDepartmen.Text, out temp);
            sign.limitId = int.Parse(drlDepartmen.SelectedValue);
            int.TryParse(txtEmailCount.Text, out temp);
            sign.emailCount = temp;

        }
        return sign;


    }
    private PackageDTO getpackge_update()
    {

        PackageDTO sign = new PackageDTO();
        UserLoginDTO userLogin = getUserLogin();
        if (userLogin != null)
        {
            sign.packageId = Convert.ToInt32(hdfId.Value);
            //sign.packageId = userLogin.UserId;
            sign.packageName = txtname.Text;
            sign.diengiai = txtdiengiai.Text;
            int temp = 0;
            int.TryParse(txtsubaccount.Text, out temp);
            sign.subAccontCount = temp;
            int.TryParse(drlDepartmen.Text, out temp);
            sign.limitId = int.Parse(drlDepartmen.SelectedValue);
            int.TryParse(txtEmailCount.Text, out temp);
            sign.emailCount = temp;

        }
        return sign;


    }
    private void package()
    {           
            drlDepartmen.Items.Clear();
            drlDepartmen.DataSource = packageBus.GetAllPackage();
            drlDepartmen.DataTextField = "namepackagelimit";
            drlDepartmen.DataValueField = "limitId";
            drlDepartmen.DataBind();
              
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
    private string checkInput()
    {
        string masseng = "";

        if (txtname.Text== "")
        {
            masseng = "Vui lòng nhập tên gói dịch vụ";
        }
        else if (txtsubaccount.Text=="")
        {
            masseng = "Vui lòng nhập vào số tài khoản con";
        }
        else if (kiemtraso(txtsubaccount.Text) == false)
        {
            masseng = "Nhập số tài khoản con không đúng định dạng";
        }
        else if (kiemtraso(txtEmailCount.Text) == false)
        {
            masseng = "Nhập số email quản lý không đúng định dạng";
        }
        
        return masseng;
    }
    private void LoadData()
    {
        dtfunction.DataSource = packageBus.GetdataPackage().DefaultView;
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
                //cho nay co van de ne
                PackageDTO packDto = getpackge_insert();
                ConnectionData.OpenMyConnection();
               
                if (hdfId.Value == null || hdfId.Value == "")//them moi
                {
                    packageBus.tblPackage_insert(packDto);
                    status = 1;
                }
                else
                {
                    PackageDTO packupdate = getpackge_update();
                    packageBus.tblPackage_Update(packupdate);
                    status = 2;
                }
                ConnectionData.CloseMyConnection();
                pnSuccess.Visible = true;
                if (status == 1)
                {
                    lblSuccess.Text = "Bạn vừa thêm thành công gói dịch vụ !";
                }
                else
                    if (status == 2)
                    {
                        lblSuccess.Text = "Bạn vừa cập nhật thành công gói dịch vụ !";
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
            lblError.Text = " Đã xảy ra lỗi trong quá trình thực hiện. Vui lòng thử lại !";
        }
        LoadData();
        xoatextbok();

    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
 
            int packageId = int.Parse(((ImageButton)sender).CommandArgument.ToString());
            if (packageBus.tblPackage_delete(packageId))
            {
                LoadData();
                pnError.Visible = false;
                pnSuccess.Visible = true;
                lblSuccess.Text = "Bạn vừa xóa thành công gói dịch vụ!";
            }
          
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
            int packageId = int.Parse((((ImageButton)sender).CommandArgument.ToString()));
            DataTable table = packageBus.GetByUserId(packageId);
            if (table.Rows.Count > 0)
            {
                txtname.Text = table.Rows[0]["packageName"].ToString();
                txtdiengiai.Text = table.Rows[0]["diengiai"].ToString();
                txtsubaccount.Text = table.Rows[0]["subAccontCount"].ToString();
                drlDepartmen.Text = table.Rows[0]["limitId"].ToString();
                txtEmailCount.Text = table.Rows[0]["emailCount"].ToString();
                this.hdfId.Value = packageId + "";

            }


        }
        catch (Exception)
        {
            pnError.Visible = false;
            pnSuccess.Visible = false;
            throw;
        }
    }
}