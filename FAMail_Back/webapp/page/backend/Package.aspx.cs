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
    log4net.ILog logs = log4net.LogManager.GetLogger("ErrorRollingLogFileAppender");
    protected void Page_Load(object sender, EventArgs e)
    {
        UserLoginDTO userLogin = getUserLogin();
        
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
        txtdescription.Text="";
        txtsubaccount.Text = "";
        txtname.Text = "";
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
            sign.description = txtdescription.Text;
            int.TryParse(txtsubaccount.Text, out temp);
            sign.subAccontCount = temp;
            int.TryParse(drlPackageLimit.Text, out temp);
            sign.limitId = int.Parse(drlPackageLimit.SelectedValue);
            sign.isUnLimit = ceIsUnlimit.Checked;
            sign.isActive = ceIsActive.Checked;
            if (!ceIsUnlimit.Checked)
            {
                int.TryParse(txtEmailCount.Text, out temp);
                sign.emailCount = temp;
            }

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
            sign.description = txtdescription.Text;
            int temp = 0;
            int.TryParse(txtsubaccount.Text, out temp);
            sign.subAccontCount = temp;
            int.TryParse(drlPackageLimit.Text, out temp);
            sign.limitId = int.Parse(drlPackageLimit.SelectedValue);
            if (ceIsUnlimit.Checked)
            {
                int.TryParse(txtEmailCount.Text, out temp);
                sign.emailCount = temp;
            }
        }
        return sign;


    }
    private void package()
    {           
            drlPackageLimit.Items.Clear();
            drlPackageLimit.DataSource = packageBus.GetAllPackage();
            drlPackageLimit.DataTextField = "namepackagelimit";
            drlPackageLimit.DataValueField = "limitId";
            drlPackageLimit.DataBind();
              
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
        else if (!ceIsUnlimit.Checked && kiemtraso(txtEmailCount.Text) == false)
        {
            masseng = "Nhập số email quản lý không đúng định dạng";
        }
        else
        {
            int i = 0;
            int.TryParse(txtEmailCount.Text + "", out i);
            if (!ceIsUnlimit.Checked && i <= 0)
                masseng = "Giới hạn mail quản lý phải lớn hơn 0";
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
                    hdfId.Value = null;
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
            logs.Error(getUserLogin().Username+"-Package - Update", ex);
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
            logs.Error(getUserLogin().Username+"-Package - Delete", ex);
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
                txtdescription.Text = table.Rows[0]["description"].ToString();
                txtsubaccount.Text = table.Rows[0]["subAccontCount"].ToString();
                drlPackageLimit.Text = table.Rows[0]["limitId"].ToString();
                txtEmailCount.Text = table.Rows[0]["emailCount"].ToString();
                this.hdfId.Value = packageId + "";
                ceIsUnlimit.Checked = Convert.ToBoolean(table.Rows[0]["isunlimit"]);
                ceIsActive.Checked = Convert.ToBoolean(table.Rows[0]["isactive"]);
            }


        }
        catch (Exception ex)
        {
            pnError.Visible = false;
            pnSuccess.Visible = false;

            logs.Error(getUserLogin().Username+"-Package - Edit", ex);
        }
    }
}