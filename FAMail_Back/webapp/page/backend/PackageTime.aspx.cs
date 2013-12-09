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
public partial class webapp_page_backend_PackageTime : System.Web.UI.Page
{
    PackageTimeBUS PackageBus = new PackageTimeBUS();
    protected void Page_Load(object sender, EventArgs e)
    {
            if (!IsPostBack)
        {           
            //LoadGroup(); 
            LoadData();
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
    private string checkInput()
    {
        string masseng = "";

        if (txtthoigian.Text == "")
        {
            masseng = "Vui lòng nhập số tháng ";
        }
        else if (kiemtraso(txtthoigian.Text) == false)
        {
            masseng = "Vui lòng nhập số tháng không đúng định dạng";
        }
        else if (txtdiscount.Text == "")
        {
            masseng = "Vui lòng nhập phần trăm vào ";
        }
        else if (kiemtraso(txtdiscount.Text) == false)
        {
            masseng = "phần trăm không đúng định dạng";
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

    private PackageTimeDTO getPackageDTO()
    {
        PackageTimeDTO sign = new PackageTimeDTO();
        UserLoginDTO userLogin = getUserLogin();
        if (userLogin != null)
        {
            sign.packageTimeId = userLogin.UserId;
            sign.monthCount =int.Parse(txtthoigian.Text);
            sign.discount = int.Parse(txtdiscount.Text);
        

        }
        return sign;


    }

    private PackageTimeDTO getPackageDTO_update()
    {
        PackageTimeDTO sign = new PackageTimeDTO();
        UserLoginDTO userLogin = getUserLogin();
        if (userLogin != null)
        {
            sign.packageTimeId = Convert.ToInt32(hdfId.Value);
            sign.monthCount = int.Parse(txtthoigian.Text);
            sign.discount = int.Parse(txtdiscount.Text);


        }
        return sign;


    }
    private void LoadData()
    {


        dtfunction.DataSource = PackageBus.GetAll().DefaultView;
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
                //PackageTimeDTO packDto = getPackageDTO();
                //ConnectionData.OpenMyConnection();
                //PackageBus.tblPackageTime_insert(packDto);

                PackageTimeDTO packDto = getPackageDTO();
                ConnectionData.OpenMyConnection();
                if (hdfId.Value == null || hdfId.Value == "")//them moi
                {
                    PackageBus.tblPackageTime_insert(packDto);
                    status = 1;
                }
                else
                {
                    PackageTimeDTO pack_updateDto = getPackageDTO_update();
                    PackageBus.tblPackageTime_Update(pack_updateDto);
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
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int packageTimeId = int.Parse((((ImageButton)sender).CommandArgument.ToString()));
            DataTable table = PackageBus.GetByUserId(packageTimeId);
            if (table.Rows.Count > 0)
            {
                txtthoigian.Text = table.Rows[0]["monthCount"].ToString();
                txtdiscount.Text = table.Rows[0]["discount"].ToString();
                this.hdfId.Value = packageTimeId + "";

            }


        }
        catch (Exception)
        {
            pnError.Visible = false;
            pnSuccess.Visible = false;
            throw;
        }
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int packageTimeId = int.Parse(((ImageButton)sender).CommandArgument.ToString());
            if (PackageBus.tblPackageTime_Delete(packageTimeId))
            {
                LoadData();
                pnError.Visible = false;
                pnSuccess.Visible = true;
                lblSuccess.Text = "Bạn vừa xóa chữ ký thành công !";
            }
        }
        catch (Exception ex)
        {
            pnError.Visible = true;
            lblError.Text = "Không thể xóa !</br>" + ex.Message;
        }
        LoadData();
    }
}