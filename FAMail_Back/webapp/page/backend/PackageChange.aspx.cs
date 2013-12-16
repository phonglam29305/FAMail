using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webapp_page_backend_PackageChange : System.Web.UI.Page
{
    protected string Title;
    ClientBUS clientbus;
    ClientRegisterBUS clientRegister;
    ClientFunctionBUS clientFunction;
    PackageBUS pkgBus;
    PackageLimitBUS pkglimitBus;
    FunctionBUS function;
    string dayleft,expireDatesession;
    protected void Page_Load(object sender, EventArgs e)
    {
        upgradeservices.Visible = false;
        extendbox.Visible = false;
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    private void LoadData()
    {
        if (Request.QueryString["type"] != null)
        {
            string status = Request.QueryString["type"].ToString();
            if (status == "extend")
            {
                lblTitle.Text += "Gia hạn dịch vụ";
                extendbox.Visible = true;
                upgradeservices.Visible = false;
                if (Request.QueryString["user"] != null)
                {
                    int user = Convert.ToInt32(Request.QueryString["user"].ToString());
                    clientbus = new ClientBUS();
                    DataTable dtClient = new DataTable();
                    dtClient = clientbus.GetByID(user);
                    string email = dtClient.Rows[0]["email"].ToString();
                    DateTime dateexpire = Convert.ToDateTime(dtClient.Rows[0]["expireDate"].ToString());
                    int registerId = Convert.ToInt32(dtClient.Rows[0]["registerId"].ToString());
                    int clientId = Convert.ToInt32(dtClient.Rows[0]["clientId"].ToString());
                    clientRegister = new ClientRegisterBUS();
                    DataTable dtClientRegister = new DataTable();
                    dtClientRegister = clientRegister.GetbyID(registerId);
                    string packageid = dtClientRegister.Rows[0]["packageId"].ToString();
                    DataTable dtpackage = new DataTable();
                    pkgBus = new PackageBUS();
                    dtpackage = pkgBus.GetByUserId(Convert.ToInt32(packageid));
                    int packagelimitid = Convert.ToInt32(dtpackage.Rows[0]["limitid"].ToString());
                    DataTable dtlimit = new DataTable();
                    pkglimitBus = new PackageLimitBUS();
                    dtlimit = pkglimitBus.GetByUserIdPackageLimit(packagelimitid);
                    DateTime NgayHetHan = Convert.ToDateTime(dtClient.Rows[0]["expireDate"].ToString());
                    string todays = DateTime.Now.ToString("yyyy-MM-dd");
                    DateTime today = Convert.ToDateTime(todays);
                    DateTime expireDay = Convert.ToDateTime(NgayHetHan);
                    if (today > expireDay)
                    {
                        lblExpireDate.Text = NgayHetHan.ToString("dd/MM/yyyy") + " (Đã hết hạn) ";
                    }
                    else if (expireDay > today)
                    {
                        string totalday = (expireDay - today).TotalDays.ToString();
                        dayleft = totalday;
                        lblExpireDate.Text = NgayHetHan.ToString("dd/MM/yyyy") + "(Còn " + totalday + " ngày)";
                        btnGiahan.Enabled = false;
                        btnGiahan.CssClass = "button round image-right ic-add text-upper";
                        ddlExtend.Enabled = false;
                    }
                }
            }
            else if (status == "upgrade")
            {
                lblTitle.Text += "Nâng cấp dịch vụ";
                extendbox.Visible = false;
                upgradeservices.Visible = true;
                if (Request.QueryString["user"] != null)
                {
                    int user = Convert.ToInt32(Request.QueryString["user"].ToString());
                    clientbus = new ClientBUS();
                    DataTable dtClient = new DataTable();
                    dtClient = clientbus.GetByID(user);
                    string email = dtClient.Rows[0]["email"].ToString();
                    DateTime dateexpire = Convert.ToDateTime(dtClient.Rows[0]["expireDate"].ToString());
                    int registerId = Convert.ToInt32(dtClient.Rows[0]["registerId"].ToString());
                    int clientId = Convert.ToInt32(dtClient.Rows[0]["clientId"].ToString());
                    clientRegister = new ClientRegisterBUS();
                    DataTable dtClientRegister = new DataTable();
                    dtClientRegister = clientRegister.GetbyID(registerId);
                    string packageid = dtClientRegister.Rows[0]["packageId"].ToString();
                    DataTable dtpackage = new DataTable();
                    pkgBus = new PackageBUS();
                    dtpackage = pkgBus.GetByUserId(Convert.ToInt32(packageid));
                    int packagelimitid = Convert.ToInt32(dtpackage.Rows[0]["limitid"].ToString());
                    DataTable dtlimit = new DataTable();
                    pkglimitBus = new PackageLimitBUS();
                    dtlimit = pkglimitBus.GetByUserIdPackageLimit(packagelimitid);
                    lblTenGoi.Text = dtlimit.Rows[0]["namepackagelimit"].ToString();
                    int idPackage =Convert.ToInt32( dtlimit.Rows[0]["limitId"]);
                    pkglimitBus = new PackageLimitBUS();
                    DataTable dtAvailable = pkglimitBus.GetAvailablePackage(idPackage);
                    ddlUpgradeServices.DataSource = dtAvailable;
                    ddlUpgradeServices.DataTextField = "namepackagelimit";
                    ddlUpgradeServices.DataValueField = "limitId";
                    ddlUpgradeServices.DataBind();
                }
            }
        }
    }
    protected void ddlExtend_SelectedIndexChanged(object sender, EventArgs e)
    {
        string today = DateTime.Now.ToShortDateString();
        int numberofday = Convert.ToInt32(ddlExtend.SelectedValue.ToString());
        DateTime expiredays = Convert.ToDateTime(today).AddDays(numberofday);
        if (dayleft != null)
        {
            expiredays = expiredays.AddDays(Convert.ToInt32(dayleft));
            lblExpireDate.Text = expiredays.ToString("dd/MM/yyyy");
            Session["expireDays"] = expiredays.ToString();
        }
        else
        {
            lblExpireDate.Text = expiredays.ToString("dd/MM/yyyy");
            Session["expireDays"] = expiredays.ToString();
        }
    }
    protected void btnGiahan_Click(object sender, EventArgs e)
    {
        if (Session["expireDays"] != null)
        {
            expireDatesession = Session["expireDays"].ToString();
            string clientid = Request.QueryString["user"].ToString();
            DateTime activeDate = DateTime.Now;
            DateTime expireDate = Convert.ToDateTime(expireDatesession);
            clientbus.UpdateExtendLicense(clientid, activeDate, expireDate);
        }
        LoadData();
    }
}