using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class webapp_page_backend_CustomerDetail : System.Web.UI.Page
{
    ClientBUS clientbus;
    ClientRegisterBUS clientRegister;
    ClientFunctionBUS clientFunction;
    PackageBUS pkgBus;
    PackageLimitBUS pkglimitBus;
    FunctionBUS function;
    UserLoginDTO userLogin = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        userLogin = getUserLogin();
        if (!IsPostBack)
        {
            LoadData();
            Page.Header.Title = "Thông tin tài khoản!!!";
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
    private void LoadData()
    {
        #region LoadData
        int id = Convert.ToInt32(userLogin.UserId);
        if (id != null)
        {
            //int user = Convert.ToInt32(Request.QueryString["user"].ToString());
            int user = id;
            clientbus = new ClientBUS();
            DataTable dtClient = new DataTable();
            dtClient = clientbus.GetByID(user);
            string email = dtClient.Rows[0]["email"] + "";
            int registerId = Convert.ToInt32(dtClient.Rows[0]["registerId"].ToString());
            int clientId = Convert.ToInt32(dtClient.Rows[0]["clientId"].ToString());
            clientRegister = new ClientRegisterBUS();
            DataTable dtClientRegister = new DataTable();
            dtClientRegister = clientRegister.GetbyID(registerId);
            string packageid = dtClientRegister.Rows[0]["packageId"].ToString();
            DataTable dtpackage = new DataTable();
            pkgBus = new PackageBUS();
            dtpackage = pkgBus.GetById(Convert.ToInt32(packageid));
            int packagelimitid = Convert.ToInt32(dtClientRegister.Rows[0]["limitid"].ToString());
            DataTable dtlimit = new DataTable();
            pkglimitBus = new PackageLimitBUS();
            dtlimit = pkglimitBus.GetByUserIdPackageLimit(packagelimitid);
            string SoluongEmail = "";
            if (dtpackage.Rows.Count > 0)
            {
                lblTenGoi.Text = dtpackage.Rows[0]["packageName"].ToString();
                SoluongEmail = dtpackage.Rows[0]["isUnlimit"].ToString();
                if (SoluongEmail.Trim() != "True")
                {
                    SoluongEmail = dtpackage.Rows[0]["emailCount"].ToString();
                    lblSoLuongEmail.Text = SoluongEmail;
                }
                else
                {
                    lblSoLuongEmail.Text = "Không giới hạn";
                }
            }
            lblNgayKichHoat.Text = dtClient.Rows[0]["activeDate"].ToString();
            lblNgayDenHan.Text = dtClient.Rows[0]["expireDate"].ToString();
            lblSoTaiKhoanCon.Text = dtClientRegister.Rows[0]["subAccontCount"].ToString();

            string GioihanEmail = dtlimit.Rows[0]["isUnlimit"].ToString();
            if (GioihanEmail.Trim() != "True")
            {
                GioihanEmail = dtlimit.Rows[0]["under"].ToString();
                lblGioiHanEmail.Text = GioihanEmail;
            }
            else
            {
                lblGioiHanEmail.Text = "Không giới hạn";
            }
            clientFunction = new ClientFunctionBUS();
            DataTable dtfunction = new DataTable();
            dtfunction = clientFunction.GetByregisterIdandclientId(registerId, clientId);
            if (dtfunction != null && dtfunction.Rows.Count > 0)
            {
                DataTable dtTemp = new DataTable();
                dtTemp.Columns.Add("functionName", typeof(String));
                foreach (DataRow drfunction in dtfunction.Rows)
                {
                    DataRow dr = dtTemp.NewRow();
                    function = new FunctionBUS();
                    string idFunction = drfunction["functionId"].ToString();
                    DataTable dtTemp2 = function.GetByFunctionId(Convert.ToInt32(idFunction));
                    if (dtTemp2 != null && dtTemp2.Rows.Count > 0)
                    {
                        string FunctionName = dtTemp2.Rows[0]["functionName"].ToString();
                        dr["functionName"] = FunctionName;
                        dtTemp.Rows.Add(dr);
                    }
                }

                rptFunction.DataSource = dtTemp;
                rptFunction.DataBind();
            }
            txtHoTen.Text = dtClient.Rows[0]["clientName"].ToString();
            txtDiaChi.Text = dtClient.Rows[0]["address"].ToString();
            txtSoDienThoai.Text = dtClient.Rows[0]["phone"].ToString();
            DateTime d = DateTime.Now;// Convert.ToDateTime(dtClient.Rows[0]["dateofbirth"].ToString());
            if (DateTime.TryParse(dtClient.Rows[0]["dateofbirth"] + "", out d))
                txtDateofBirth.Text = d.ToString("dd/MM/yyyy");
            lblEmail.Text = email;
            string todays = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime today = Convert.ToDateTime(todays);

            DateTime dateexpire = DateTime.Now;

            if (DateTime.TryParse(dtClient.Rows[0]["expireDate"] + "", out dateexpire) && dateexpire < today)
            {
                btnGiahan.Enabled = true;
                btnGiahan.Text = "Gia hạn (Đã hết hạn " + (today - dateexpire).TotalDays + " ngày)";
            }
            else
            {
                btnGiahan.Enabled = false; ;
                btnGiahan.CssClass = "button round image-right ic-add text-upper";
                btnGiahan.Text = "Gia hạn (Còn lại " + (dateexpire - today).TotalDays + " ngày)";
            }
        }
        else
        {

        }
        #endregion
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtDateofBirth.Text.Trim() == "")
        {
            //Response.Write("<script type='text/javascrit'>alert('Ngày sinh không được rỗng !!!')</script>");
        }
        else
        {
            clientbus = new ClientBUS();
            int user = Convert.ToInt32(Request.QueryString["user"].ToString());
            string name = txtHoTen.Text;
            string address = txtDiaChi.Text;
            string phone = txtSoDienThoai.Text;
            DateTime dateofbirth = Convert.ToDateTime(txtDateofBirth.Text);
            clientbus.UpdateInfomation(user, name, address, dateofbirth, phone);
        }
    }
    protected void btnGiahan0_Click(object sender, EventArgs e)
    {
        Response.Redirect("packagechange.aspx?type=editoption");
    }
    protected void btnGiahan_Click(object sender, EventArgs e)
    {
        Response.Redirect("PackageChange.aspx?type=extend");
    }
    protected void btnUpGradeServices_Click(object sender, EventArgs e)
    {
        Response.Redirect("packagechange.aspx?type=upgrade");
    }
}