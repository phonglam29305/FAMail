using Email;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webapp_page_backend_PackageChange : System.Web.UI.Page
{
    protected string Title;
    ClientBUS clientbus;
    ClientRegisterBUS clientRegister;
    ClientFunctionBUS clientFunction;
    PackageBUS pkgBus;
    PackageCostBUS pkgCostBus;
    PackageFunctionBUS pkgFunctionBus;
    PackageLimitBUS pkglimitBus;
    FunctionBUS function;
    string dayleft,expireDatesession;
    UserLoginDTO userLogin = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        userLogin = getUserLogin();
        if (!IsPostBack)
        {
            upgradeservices.Visible = false;
            extendbox.Visible = false;
            LoadData();
            LoadPackageTime();
            LoadAvailableService();
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
    private void LoadAvailableService()
    {
        if (Request.QueryString["type"] != null)
        {
            int user = Convert.ToInt32(userLogin.UserId);
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
            dtpackage = pkgBus.GetById(Convert.ToInt32(packageid));
            int packagelimitid = Convert.ToInt32(dtClientRegister.Rows[0]["limitid"].ToString());
            DataTable dtlimit = new DataTable();
            pkglimitBus = new PackageLimitBUS();
            dtlimit = pkgBus.GetAvailablePackage(Convert.ToInt32(packageid));
            //lblTenGoi.Text = dtlimit.Rows[0]["namepackagelimit"].ToString();
            //int idPackage = Convert.ToInt32(dtlimit.Rows[0]["limitId"]);
            //pkglimitBus = new PackageLimitBUS();
            //DataTable dtAvailable = pkglimitBus.GetAvailablePackage(idPackage);
            ddlUpgradeServices.DataSource = dtlimit;
            ddlUpgradeServices.DataTextField = "packageName";
            ddlUpgradeServices.DataValueField = "packageId";
            ddlUpgradeServices.DataBind();
        }
    }
    private void LoadData()
    {
        if (Request.QueryString["type"] != null)
        {
            string status = Request.QueryString["type"].ToString();
            int userid = Convert.ToInt32(userLogin.UserId);
            if (status == "extend")
            {
                #region Extend
                lblTitle.Text = "Gia hạn dịch vụ";
                extendbox.Visible = true;
                upgradeservices.Visible = false;
                btnGiahan.Enabled = false; ;
                btnGiahan.CssClass = "button round image-right ic-add text-upper";
                if (userid != null)
                {
                    int user = userid;//Convert.ToInt32(Request.QueryString["user"].ToString());
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
                    dtpackage = pkgBus.GetById(Convert.ToInt32(packageid));
                    int packagelimitid = Convert.ToInt32(dtClientRegister.Rows[0]["limitId"].ToString());
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
                        Session["totalDayLeft"] = totalday;
                    }
                    else if (expireDay == today)
                    {
                        double totalday = (expireDay - today).TotalMinutes;
                        if (totalday > 0)
                        {
                            lblExpireDate.Text = NgayHetHan.ToString("dd/MM/yyyy") + "(Còn " + totalday + " phút)";
                            btnGiahan.Enabled = false;
                            btnGiahan.CssClass = "button round image-right ic-add text-upper";
                            ddlExtend.Enabled = false;
                        }
                        else
                        {
                            lblExpireDate.Text = NgayHetHan.ToString("dd/MM/yyyy") + " (Đã hết hạn) ";
                        }
                    }
                }
                #endregion
            }
            else if (status == "upgrade")
            {
                #region Upgrade
                lblTitle.Text = "Nâng cấp dịch vụ";
                extendbox.Visible = false;
                upgradeservices.Visible = true;
                ddlUpgradeTime.Enabled = false;
                if (userid != null)
                {
                    int user = userid;
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
                    dtpackage = pkgBus.GetById(Convert.ToInt32(packageid));
                    int packagelimitid = Convert.ToInt32(dtClientRegister.Rows[0]["limitid"].ToString());
                    DataTable dtlimit = new DataTable();
                    pkglimitBus = new PackageLimitBUS();
                    dtlimit = pkglimitBus.GetByUserIdPackageLimit(packagelimitid);
                    lblTenGoi.Text = dtpackage.Rows[0]["packageName"].ToString();
                    #region loadpackage
                    pkgFunctionBus = new PackageFunctionBUS();
                    DataTable dtfunction = pkgFunctionBus.GetFunctionbyPackageId(Convert.ToInt32(packageid));
                    DataTable dtFunctionTemmp = new DataTable();
                    dtFunctionTemmp.Columns.Add("functionId");
                    dtFunctionTemmp.Columns.Add("functionName");
                    dtFunctionTemmp.Columns.Add("cost");
                    dtFunctionTemmp.Columns.Add("isDefault");
                    foreach (DataRow drfunction in dtfunction.Rows)
                    {
                        int id = Convert.ToInt32(drfunction["functionId"].ToString());
                        function = new FunctionBUS();
                        DataTable dtTemp = function.GetByUserId(id);
                        DataRow dr = dtFunctionTemmp.NewRow();
                        dr["functionId"] = dtTemp.Rows[0]["functionId"].ToString();
                        dr["functionName"] = dtTemp.Rows[0]["functionName"].ToString();
                        dr["cost"] = dtTemp.Rows[0]["cost"].ToString();
                        dr["isDefault"] = dtTemp.Rows[0]["isDefault"].ToString();
                        dtFunctionTemmp.Rows.Add(dr);
                    }
                    rptListOptionsUpgrade.DataSource = dtFunctionTemmp;
                    rptListOptionsUpgrade.DataBind();
                    pkgBus = new PackageBUS();
                    DataTable dtPackage = pkgBus.GetById(Convert.ToInt32(packageid));
                    int currentLimitID = Convert.ToInt32(dtPackage.Rows[0]["limitId"].ToString());
                    pkglimitBus = new PackageLimitBUS();
                    DataTable dtTempp = pkglimitBus.GetAll();
                    ddlPackageLimitUpgrade.DataSource = dtTempp;
                    ddlPackageLimitUpgrade.DataTextField = "namepackagelimit";
                    ddlPackageLimitUpgrade.DataValueField = "limitId";
                    ddlPackageLimitUpgrade.DataBind();
                    ddlPackageLimitUpgrade.SelectedValue = currentLimitID.ToString();
                    #endregion
                    DateTime today = DateTime.Now;
                    DateTime dayexpire = Convert.ToDateTime(dtClient.Rows[0]["expireDate"].ToString());
                    string totaldayleft,hoursleft;
                    if (dayexpire > today)
                    {
                        totaldayleft = Math.Round((dateexpire - today).TotalDays).ToString();
                        hoursleft = Math.Round(Convert.ToDouble((dateexpire - today).TotalHours-(24*Convert.ToDouble(totaldayleft)))).ToString();
                        double comparetime=Convert.ToDouble(totaldayleft);
                        double comparehours = Convert.ToDouble(hoursleft);
                        if (comparetime >= 1&&comparehours>0)
                        {
                            lblTimeLeft.Text =dateexpire.ToString("dd/MM/yyyy")+ " (Còn " + totaldayleft +" ngày "+hoursleft+" giờ)";
                            dayleft = totaldayleft;
                            Session["totalDayLeft"] = totaldayleft;
                        }
                        else if(comparetime>=1&&comparehours<=0)
                        {
                            lblTimeLeft.Text = dateexpire.ToString("dd/MM/yyyy") + " (Còn " + totaldayleft + " ngày)";
                            dayleft = totaldayleft;
                            Session["totalDayLeft"] = totaldayleft;
                        }
                        else
                        {
                            totaldayleft = (dateexpire - today).TotalHours.ToString();
                            comparetime = Convert.ToDouble(totaldayleft);
                            lblTimeLeft.Text = "Còn " + Math.Round(comparetime) + " giờ";
                            //sdayleft = totaldayleft;
                        }
                    }
                    else if(dayexpire<today)
                    {
                        lblTimeLeft.Text = dayexpire + " (Đã hết hạn)";
                    }
                    btnUpgrade.Enabled = false;
                    btnUpgrade.CssClass = "button round image-right ic-add text-upper";
                }
                #endregion
            }
            else if (status == "editoption")
            {
                #region EditOption
                lblTitle.Text = "Thay đổi chức năng dịch vụ";
                extendbox.Visible = false;
                upgradeservices.Visible = false;
                changeoptionbox.Visible = true;
                if (userid != null)
                {
                    int user = userid;
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
                    pkgFunctionBus=new PackageFunctionBUS();
                    DataTable dtfunction = pkgFunctionBus.GetFunctionbyPackageId(Convert.ToInt32(packageid));
                    DataTable dtFunctionTemmp = new DataTable();
                    dtFunctionTemmp.Columns.Add("functionId");
                    dtFunctionTemmp.Columns.Add("functionName");
                    dtFunctionTemmp.Columns.Add("cost");
                    dtFunctionTemmp.Columns.Add("isDefault");
                    foreach (DataRow drfunction in dtfunction.Rows)
                    {
                        int id = Convert.ToInt32(drfunction["functionId"].ToString());
                        function = new FunctionBUS();
                        DataTable dtTemp = function.GetByUserId(id);
                        DataRow dr = dtFunctionTemmp.NewRow();
                        dr["functionId"] = dtTemp.Rows[0]["functionId"].ToString();
                        dr["functionName"] = dtTemp.Rows[0]["functionName"].ToString();
                        dr["cost"] = dtTemp.Rows[0]["cost"].ToString();
                        dr["isDefault"] = dtTemp.Rows[0]["isDefault"].ToString();
                        dtFunctionTemmp.Rows.Add(dr);
                    }
                    rptListOptions.DataSource = dtFunctionTemmp;
                    rptListOptions.DataBind();
                    pkgBus=new PackageBUS();
                    DataTable dtPackage = pkgBus.GetById(Convert.ToInt32(packageid));
                    int currentLimitID = Convert.ToInt32(dtPackage.Rows[0]["limitId"].ToString());
                    pkglimitBus = new PackageLimitBUS();
                    DataTable dtTempp = pkglimitBus.GetAll();
                    ddlLimitPackage.DataSource = dtTempp;
                    ddlLimitPackage.DataTextField = "namepackagelimit";
                    ddlLimitPackage.DataValueField = "limitId";
                    ddlLimitPackage.DataBind();
                    ddlLimitPackage.SelectedValue = currentLimitID.ToString();
                    pkglimitBus = new PackageLimitBUS();
                    DataTable dtCosts = pkglimitBus.GetByUserIdPackageLimit(currentLimitID);
                    int value2 = Convert.ToInt32(dtCosts.Rows[0]["cost"].ToString());
                    foreach (RepeaterItem rptItems in rptListOptions.Items)
                    {
                        CheckBox chk = (CheckBox)rptItems.FindControl("chkOptions");
                        Label lbl = (Label)rptItems.FindControl("lblCost");
                        if (chk.Checked == true)
                        {
                            value2 += Convert.ToInt32(lbl.Text);
                        }
                    }
                    lblSumCost.Text = (value2).ToString();
                }
                #endregion
            }
        }
    }
    protected void ddlExtend_SelectedIndexChanged(object sender, EventArgs e)
    {
        string today = DateTime.Now.ToShortDateString();
        int numberofday = Convert.ToInt32(ddlExtend.SelectedValue.ToString());
        int user = Convert.ToInt32(userLogin.UserId);
        clientbus = new ClientBUS();
        DataTable dtClient = new DataTable();
        dtClient = clientbus.GetByID(user);
        int registerId = Convert.ToInt32(dtClient.Rows[0]["registerId"].ToString());
        clientRegister = new ClientRegisterBUS();
        DataTable dtClientRegister = new DataTable();
        dtClientRegister = clientRegister.GetbyID(registerId);
        int packageId = Convert.ToInt32(dtClientRegister.Rows[0]["packageId"].ToString());
        pkgCostBus = new PackageCostBUS();
        DataTable dtCost = pkgCostBus.GetPackageCost(packageId);
        lblExtendCost.Text = dtCost.Rows[0]["cost"].ToString();
        DateTime expiredays = Convert.ToDateTime(today).AddMonths(numberofday);
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
        btnGiahan.Enabled = true; ;
        btnGiahan.CssClass = "button round blue image-right ic-add text-upper";
    }
    protected void btnGiahan_Click(object sender, EventArgs e)
    {
        if (Session["expireDays"] != null)
        {
            int user = Convert.ToInt32(userLogin.UserId);
            clientbus = new ClientBUS();
            DataTable dtClient = new DataTable();
            dtClient = clientbus.GetByID(user);
            int registerId = Convert.ToInt32(dtClient.Rows[0]["registerId"].ToString());
            clientRegister = new ClientRegisterBUS();
            DataTable dtClientRegister = new DataTable();
            dtClientRegister = clientRegister.GetbyID(registerId);
            int clientId = Convert.ToInt32(dtClientRegister.Rows[0]["clientId"].ToString());
            int packageId = Convert.ToInt32(dtClientRegister.Rows[0]["packageId"].ToString());
            int limitId = Convert.ToInt32(dtClientRegister.Rows[0]["limitId"].ToString());
            int SubAccountCount = Convert.ToInt32(dtClientRegister.Rows[0]["subAccontCount"].ToString());
            int emailCount = 0;
            if(int.TryParse(dtClientRegister.Rows[0]["emailCount"].ToString(),out emailCount));
            int totalFee = Convert.ToInt32(lblExtendCost.Text);
            int registerType = Convert.ToInt32(dtClientRegister.Rows[0]["registerType"].ToString());
            int packageTimeId = Convert.ToInt32(dtClientRegister.Rows[0]["packageTimeId"].ToString());
            DateTime activeDate = DateTime.Now;
            DateTime expireDate = Convert.ToDateTime(Session["expireDays"].ToString());
            string from = activeDate.ToString("dd/MM/yyyy");
            string to = expireDate.ToString("dd/MM/yyyy") ;
            string lastRegisterFrom = Convert.ToDateTime(dtClientRegister.Rows[0]["from"].ToString()).ToString("dd/MM/yyyy");
            string lastRegisterTo = Convert.ToDateTime(dtClientRegister.Rows[0]["to"].ToString()).ToString("dd/MM/yyyy");
            int lastRegisterFee = Convert.ToInt32(dtClientRegister.Rows[0]["totalFee"].ToString());
            int lastRegisterFeeRemain=0;
            int newregisterid = clientRegister.UpdateUpgrade(clientId, packageId, limitId, SubAccountCount, totalFee, registerType, packageId, from, to, lastRegisterFrom, lastRegisterTo, lastRegisterFee, lastRegisterFeeRemain);
            clientbus.UpdateRegiterId(clientId, from, to, registerId, newregisterid);
            clientFunction = new ClientFunctionBUS();
            DataTable dtRegisOldFunction = clientFunction.GetByregisterIdandclientId(registerId, clientId);
            foreach (DataRow drRegisOldFunction in dtRegisOldFunction.Rows)
            {
                int functionId = Convert.ToInt32(drRegisOldFunction["functionId"].ToString());
                clientFunction.UpdateFunction(newregisterid, clientId, functionId);
            }
            #region oldcode
            expireDatesession = Session["expireDays"].ToString();
            clientbus.UpdateExtendLicense(clientId.ToString(), activeDate, expireDate);
            #endregion
        }
        LoadData();
    }
    protected void btnUpgrade_Click(object sender, EventArgs e)
    {
        //int limitId = Convert.ToInt32(ddlUpgradeServices.SelectedValue.ToString());
        int packageid = Convert.ToInt32(ddlUpgradeServices.SelectedValue.ToString());
        int user = Convert.ToInt32(userLogin.UserId);
        clientbus = new ClientBUS();
        DataTable dtClient = new DataTable();
        dtClient = clientbus.GetByID(user);
        DateTime dateexpire = Convert.ToDateTime(dtClient.Rows[0]["expireDate"].ToString());
        int registerId = Convert.ToInt32(dtClient.Rows[0]["registerId"].ToString());
        int clientId = Convert.ToInt32(dtClient.Rows[0]["clientId"].ToString());
        DateTime dayactive = Convert.ToDateTime(dtClient.Rows[0]["activeDate"].ToString());
        DateTime dayexpire = Convert.ToDateTime(dtClient.Rows[0]["expireDate"].ToString());
        clientRegister = new ClientRegisterBUS();
        DataTable dtClientRegister = new DataTable();
        dtClientRegister = clientRegister.GetbyID(registerId);
        int limitId = Convert.ToInt32(dtClientRegister.Rows[0]["limitId"].ToString());
        string lastRegisterFrom = Convert.ToDateTime(dtClientRegister.Rows[0]["from"].ToString()).ToString("dd/MM/yyyy"); ;
        string lastRegisterTo = Convert.ToDateTime(dtClientRegister.Rows[0]["to"].ToString()).ToString("dd/MM/yyyy");
        clientRegister = new ClientRegisterBUS();
        DataTable dtpackage = new DataTable();
        pkgBus = new PackageBUS();
        dtpackage = pkgBus.GetById(Convert.ToInt32(packageid));
        int SubAccount = Convert.ToInt32(dtpackage.Rows[0]["subAccontCount"].ToString());
        int packagelimitid = Convert.ToInt32(dtpackage.Rows[0]["limitid"].ToString());
        DataTable dtlimit = new DataTable();
        pkglimitBus = new PackageLimitBUS();
        dtlimit = pkglimitBus.GetByUserIdPackageLimit(limitId);
        pkgCostBus = new PackageCostBUS();
        DataTable dtCost = pkgCostBus.GetPackageCost(packageid);
        int cost = Convert.ToInt32(dtCost.Rows[0]["cost"].ToString());
        int numberoftime = Convert.ToInt32(ddlUpgradeTime.SelectedValue);
        int value = 0;
        int totalFee = Convert.ToInt32(lblFee.Text);
        string status = Request.QueryString["type"].ToString();
        int registerType;
        if (status == "extend")
        {
            registerType = 1;
        }
        else if (status == "upgrade")
        {
            registerType = 2;
        }
        else if (status == "addfunction")
        {
            registerType = 3;
        }
        else
        {
            registerType = 0;
        }
        string today = DateTime.Now.ToShortDateString();
        int numberofday = Convert.ToInt32(ddlUpgradeTime.SelectedValue.ToString());
        //DateTime expiredays = Convert.ToDateTime(today).AddMonths(numberofday);
        //DateTime activedays = Convert.ToDateTime(today);
        string registerDate = DateTime.Now.ToString("dd/MM/yyyy");
        string registerTime = DateTime.Now.ToString("dd/MM/yyyy");
        string from = DateTime.Now.ToString("dd/MM/yyyy");
        string to = DateTime.Parse(Session["expireDays"].ToString()).ToString("dd/MM/yyyy");
        int lastRegisterFee = Convert.ToInt32(dtClientRegister.Rows[0]["totalFee"].ToString());
        int lastRegisterFeeRemain = Convert.ToInt32(lblFeeRemain.Text);
        int packagetimeid = Convert.ToInt32(ddlUpgradeServices.SelectedValue);
        int newregisterid = clientRegister.UpdateUpgrade(clientId, packageid, limitId, SubAccount, totalFee, registerType, packagetimeid, from, to, lastRegisterFrom, lastRegisterTo, lastRegisterFee, lastRegisterFeeRemain);
        clientbus.UpdateRegiterId(clientId, from, to, registerId, newregisterid);
        foreach (RepeaterItem rptItems in rptListOptionsUpgrade.Items)
        {
            CheckBox chk = (CheckBox)rptItems.FindControl("chkOptionsUpgrade");
            Label lbl = (Label)rptItems.FindControl("lblIDUpgrade");
            int functionId = Convert.ToInt32(lbl.Text);
            if (chk.Checked == true)
            {
                clientFunction = new ClientFunctionBUS();
                clientFunction.UpdateFunction(newregisterid, clientId, functionId);
            }
        }
        btnUpgrade.Enabled = false;
        btnUpgrade.CssClass = "button round text-upper";
        btnUpgrade.Text = "Đã nâng cấp gói thành công!!!";
    }
    private void LoadPackageTime()
    {
        //if (Session["LoadDropdownlist"] != null)
        //{
            SqlCommand cmd = new SqlCommand("Select * from tblPackageTime order by monthCount", ConnectionData._MyConnection);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            ConnectionData._MyConnection.Close();
            if (ConnectionData._MyConnection.State == ConnectionState.Closed)
            {
                ConnectionData._MyConnection.Open();
            }
            adapter.Fill(table);
            cmd.Dispose();
            adapter.Dispose();
            DataTable dtTemp = new DataTable();
            DataRow drTemp;
            dtTemp.Columns.Add("monthCount", typeof(String));
            dtTemp.Columns.Add("packageTimeId", typeof(String));
            dtTemp.Columns.Add("PackageTimeName", typeof(String));
            foreach (DataRow dr in table.Rows)
            {
                drTemp = dtTemp.NewRow();
                drTemp["monthCount"] = dr["monthCount"].ToString();
                drTemp["packageTimeId"] = dr["packageTimeId"].ToString();
                drTemp["PackageTimeName"] = dr["monthCount"].ToString() + " tháng";
                dtTemp.Rows.Add(drTemp);
            }
            ddlExtend.DataSource = dtTemp;
            ddlExtend.DataTextField = "PackageTimeName";
            ddlExtend.DataValueField = "monthCount";
            ddlExtend.DataBind();
            ddlUpgradeTime.DataSource = dtTemp;
            ddlUpgradeTime.DataTextField = "PackageTimeName";
            ddlUpgradeTime.DataValueField = "monthCount";
            ddlUpgradeTime.DataBind();
        //    Session["LoadDropdownlist"] = "Loaded";
        //}
    }
    protected void ddlUpgradeTime_SelectedIndexChanged(object sender, EventArgs e)
    {
        int value=Convert.ToInt32(ddlUpgradeServices.SelectedValue);
        if (value != 0 )
        {
            string today = DateTime.Now.ToShortDateString();
            int packageId = Convert.ToInt32(ddlUpgradeServices.SelectedValue);
            int numberofday = Convert.ToInt32(ddlUpgradeTime.SelectedValue.ToString());
            pkgCostBus = new PackageCostBUS();
            DataTable dtCost = pkgCostBus.GetPackageCost(packageId);
            int cost = Convert.ToInt32(dtCost.Rows[0]["cost"].ToString());
            int numberoftime = Convert.ToInt32(ddlUpgradeTime.SelectedValue);
            double dayleft = Convert.ToDouble(Session["totalDayLeft"]);
            int totalFee = cost * numberoftime;
            double costperday = cost / 30;
            double feeRemain = GetFeeRemain(Convert.ToInt32(userLogin.UserId));
            double finalFeeRemain = Math.Round(feeRemain * dayleft);
            if (numberofday > 0)
            {
                DateTime expiredays = Convert.ToDateTime(today).AddMonths(numberofday);
                if (dayleft != null)
                {
                    expiredays = expiredays.AddDays(Convert.ToInt32(dayleft));
                    double daybonus = (finalFeeRemain / costperday);
                    string temp = daybonus.ToString();
                    if (temp == "NaN")
                    {
                        daybonus = 0;
                    }
                    expiredays = expiredays.AddDays(Math.Round(daybonus));
                    if (daybonus > 0)
                    {
                        lblUpgradeExpireTime.Text = expiredays.ToString("dd/MM/yyyy") + " (+" + Math.Round(daybonus) + " ngày)";
                        Session["expireDays"] = expiredays.ToString();
                    }
                    else
                    {
                        lblUpgradeExpireTime.Text = expiredays.ToString("dd/MM/yyyy");
                        Session["expireDays"] = expiredays.ToString();
                    }
                }
                else
                {
                    lblUpgradeExpireTime.Text = expiredays.ToString("dd/MM/yyyy");
                    Session["expireDays"] = expiredays.ToString();
                }
                btnUpgrade.Enabled = true;
                btnUpgrade.CssClass = "button round blue image-right ic-add text-upper";
                lblFee.Text = totalFee.ToString();
                lblFeeRemain.Text = finalFeeRemain.ToString();
            }
            else
            {
                DateTime expiredays = Convert.ToDateTime(today).AddMonths(numberofday);
                if (dayleft != null)
                {
                    expiredays = expiredays.AddDays(Convert.ToInt32(dayleft));
                    lblUpgradeExpireTime.Text = expiredays.ToString("dd/MM/yyyy");
                    Session["expireDays"] = expiredays.ToString();
                }
                else
                {
                    lblUpgradeExpireTime.Text = expiredays.ToString("dd/MM/yyyy");
                    Session["expireDays"] = expiredays.ToString();
                }
                lblFee.Text = totalFee.ToString();
                lblFeeRemain.Text = Math.Round(feeRemain).ToString();
            }
            #region loadfunction
            pkgFunctionBus = new PackageFunctionBUS();
            DataTable dtfunction = pkgFunctionBus.GetFunctionbyPackageId(Convert.ToInt32(packageId));
            DataTable dtFunctionTemmp = new DataTable();
            dtFunctionTemmp.Columns.Add("functionId");
            dtFunctionTemmp.Columns.Add("functionName");
            dtFunctionTemmp.Columns.Add("cost");
            dtFunctionTemmp.Columns.Add("isDefault");
            foreach (DataRow drfunction in dtfunction.Rows)
            {
                int id = Convert.ToInt32(drfunction["functionId"].ToString());
                function = new FunctionBUS();
                DataTable dtTemp = function.GetByUserId(id);
                DataRow dr = dtFunctionTemmp.NewRow();
                dr["functionId"] = dtTemp.Rows[0]["functionId"].ToString();
                dr["functionName"] = dtTemp.Rows[0]["functionName"].ToString();
                dr["cost"] = dtTemp.Rows[0]["cost"].ToString();
                dr["isDefault"] = dtTemp.Rows[0]["isDefault"].ToString();
                dtFunctionTemmp.Rows.Add(dr);
            }
            rptListOptionsUpgrade.DataSource = dtFunctionTemmp;
            rptListOptionsUpgrade.DataBind();
            pkgBus = new PackageBUS();
            DataTable dtPackage = pkgBus.GetById(Convert.ToInt32(packageId));
            int currentLimitID = Convert.ToInt32(dtPackage.Rows[0]["limitId"].ToString());
            pkglimitBus = new PackageLimitBUS();
            DataTable dtTempp = pkglimitBus.GetAll();
            ddlPackageLimitUpgrade.DataSource = dtTempp;
            ddlPackageLimitUpgrade.DataTextField = "namepackagelimit";
            ddlPackageLimitUpgrade.DataValueField = "limitId";
            ddlPackageLimitUpgrade.DataBind();
            ddlPackageLimitUpgrade.SelectedValue = currentLimitID.ToString();
            #endregion
        }
    }
    private double GetFeeRemain(int userid)
    {
        clientbus = new ClientBUS();
        DataTable dtClient = new DataTable();
        dtClient = clientbus.GetByID(userid);
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
        dtpackage = pkgBus.GetById(Convert.ToInt32(packageid));
        int packagelimitid = Convert.ToInt32(dtClientRegister.Rows[0]["limitId"].ToString());
        DataTable dtlimit = new DataTable();
        pkglimitBus = new PackageLimitBUS();
        dtlimit = pkglimitBus.GetByUserIdPackageLimit(packagelimitid);
        int cost = Convert.ToInt32(dtClientRegister.Rows[0]["totalFee"].ToString());
        int numberofdayleft=0;
        double feeRemain=0;
        if (Session["totalDayLeft"] != null)
        {
            numberofdayleft = Convert.ToInt32(Session["totalDayLeft"]);
            feeRemain = (cost / numberofdayleft);
        }
        return feeRemain;
    }
    [WebMethod]
    public static string CalculateCost(string myparam)
    {
        string rasd = "Success catching event!!! ";
        return rasd;
    }
    [WebMethod]
    public static string sbGetData(string sdPreNo)
    {
        return sdPreNo + " hurray ";
    }
    protected void chkOptions_CheckedChanged(object sender, EventArgs e)
    {
        int value = 0;
        int Id=Convert.ToInt32(ddlLimitPackage.SelectedValue.ToString());
        pkglimitBus = new PackageLimitBUS();
        DataTable dtTemp = pkglimitBus.GetByUserIdPackageLimit(Id);
        foreach (RepeaterItem rptItems in rptListOptions.Items)
        {
            CheckBox chk = (CheckBox)rptItems.FindControl("chkOptions");
            Label lbl = (Label)rptItems.FindControl("lblCost");
            if (chk.Checked == true)
            {
                value += Convert.ToInt32(lbl.Text);
            }
            else
            {
                //value = value;
            }
        }
        int value2=Convert.ToInt32(dtTemp.Rows[0]["cost"].ToString());
        lblSumCost.Text = (value+value2).ToString();
    }
    protected void chkOptionsUpgrade_CheckedChanged(object sender, EventArgs e)
    {
        int value = 0;
        int Id = Convert.ToInt32(ddlPackageLimitUpgrade.SelectedValue.ToString());
        int numberoftime = Convert.ToInt32(ddlUpgradeTime.SelectedValue);
        pkglimitBus = new PackageLimitBUS();
        DataTable dtTemp = pkglimitBus.GetByUserIdPackageLimit(Id);
        foreach (RepeaterItem rptItems in rptListOptionsUpgrade.Items)
        {
            CheckBox chk = (CheckBox)rptItems.FindControl("chkOptionsUpgrade");
            Label lbl = (Label)rptItems.FindControl("lblCostUpgrade");
            if (chk.Checked == true)
            {
                value += Convert.ToInt32(lbl.Text);
            }
            else
            {
                //value = value;
            }
        }
        int value2 = Convert.ToInt32(dtTemp.Rows[0]["cost"].ToString());
        if (numberoftime == 0)
        { 
            lblFee.Text = (value + value2).ToString();
        }
        else if (numberoftime > 0)
        {
            int sum=((value + value2)*numberoftime);
            lblFee.Text = sum.ToString();
        }
    }
    protected void ddlLimitPackage_SelectedIndexChanged(object sender, EventArgs e)
    {
        int value = 0;
        int Id = Convert.ToInt32(ddlLimitPackage.SelectedValue.ToString());
        pkglimitBus = new PackageLimitBUS();
        DataTable dtTemp = pkglimitBus.GetByUserIdPackageLimit(Id);
        foreach (RepeaterItem rptItems in rptListOptions.Items)
        {
            CheckBox chk = (CheckBox)rptItems.FindControl("chkOptions");
            Label lbl = (Label)rptItems.FindControl("lblCost");
            if (chk.Checked == true)
            {
                value += Convert.ToInt32(lbl.Text);
            }
            else
            {
                //value = value;
            }
        }
        int value2 = Convert.ToInt32(dtTemp.Rows[0]["cost"].ToString());
        lblSumCost.Text = (value + value2).ToString();
    }
    protected void rptListOptions_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            CheckBox chk = (CheckBox)e.Item.FindControl("chkOptions");
            Label lbl = (Label)e.Item.FindControl("lblCheck");
            Label lblid = (Label)e.Item.FindControl("lblID");
            string value=lbl.Text.Trim();
            int id = Convert.ToInt32(lblid.Text);
            if (id != null)
            {
                if (value == "True")
                {
                    chk.Checked = true;
                    chk.Enabled = false;
                }
                else
                {
                    chk.Checked = true;
                }
            }
        }
    }
    protected void btnEditOption_Click(object sender, EventArgs e)
    {
        int user = Convert.ToInt32(userLogin.UserId);
        clientbus = new ClientBUS();
        DataTable dtClient = new DataTable();
        dtClient = clientbus.GetByID(user);
        DateTime dateexpire = Convert.ToDateTime(dtClient.Rows[0]["expireDate"].ToString());
        int registerId = Convert.ToInt32(dtClient.Rows[0]["registerId"].ToString());
        int clientId = Convert.ToInt32(dtClient.Rows[0]["clientId"].ToString());
        clientRegister = new ClientRegisterBUS();
        DataTable dtClientRegister = new DataTable();
        dtClientRegister = clientRegister.GetbyID(registerId);
        int packageid = Convert.ToInt32(dtClientRegister.Rows[0]["packageId"].ToString());
        int limitId = Convert.ToInt32(ddlLimitPackage.SelectedValue.ToString());
        pkgBus = new PackageBUS();
        DataTable dtpackage = new DataTable();
        dtpackage = pkgBus.GetById(Convert.ToInt32(packageid));
        int SubAccount = Convert.ToInt32(dtpackage.Rows[0]["subAccontCount"].ToString());
        int totalFee = Convert.ToInt32(lblSumCost.Text);
        int registerType = 3;
        int packagetimeid = Convert.ToInt32(dtClientRegister.Rows[0]["packageTimeId"].ToString());
        string from = Convert.ToDateTime(dtClientRegister.Rows[0]["from"].ToString()).ToString("dd/MM/yyyy");
        string to = Convert.ToDateTime(dtClientRegister.Rows[0]["to"].ToString()).ToString("dd/MM/yyyy");
        string lastRegisterFrom = Convert.ToDateTime(dtClientRegister.Rows[0]["lastRegisterFrom"].ToString()).ToString("dd/MM/yyyy");
        string lastRegisterTo = Convert.ToDateTime(dtClientRegister.Rows[0]["lastRegisterTo"].ToString()).ToString("dd/MM/yyyy");
        int lastRegisterFee = Convert.ToInt32(dtClientRegister.Rows[0]["lastRegisterFee"].ToString());
        int lastRegisterFeeRemain = Convert.ToInt32(dtClientRegister.Rows[0]["lastRegisterFeeRemain"].ToString());
        int newregisterid = clientRegister.UpdateUpgrade(clientId, packageid, limitId, SubAccount, totalFee, registerType, packagetimeid, from, to, lastRegisterFrom, lastRegisterTo, lastRegisterFee, lastRegisterFeeRemain);
        clientbus.UpdateRegiterId(clientId, from, to, registerId, newregisterid);
        foreach (RepeaterItem rptItems in rptListOptions.Items)
        {
            CheckBox chk = (CheckBox)rptItems.FindControl("chkOptions");
            Label lbl = (Label)rptItems.FindControl("lblID");
            int functionId = Convert.ToInt32(lbl.Text);
            if (chk.Checked == true)
            {
                clientFunction = new ClientFunctionBUS();
                clientFunction.UpdateFunction(newregisterid, clientId, functionId);
            }
        }
        btnEditOption.Enabled = false;
        btnEditOption.CssClass = "button round text-upper";
        btnEditOption.Text = "Đã điều chỉnh chức năng gói!!!";
    }
    protected void rptListOptionsUpgrade_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            CheckBox chk = (CheckBox)e.Item.FindControl("chkOptionsUpgrade");
            Label lbl = (Label)e.Item.FindControl("lblCheckUpgrade");
            Label lblid = (Label)e.Item.FindControl("lblIDUpgrade");
            string value = lbl.Text.Trim();
            int id = Convert.ToInt32(lblid.Text);
            if (id != null)
            {
                if (value == "True")
                {
                    chk.Checked = true;
                    chk.Enabled = false;
                }
                else
                {
                    chk.Checked = true;
                }
            }
        }
    }
    protected void ddlPackageLimitUpgrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        int value = 0;
        int Id = Convert.ToInt32(ddlPackageLimitUpgrade.SelectedValue.ToString());
        pkglimitBus = new PackageLimitBUS();
        DataTable dtTemp = pkglimitBus.GetByUserIdPackageLimit(Id);
        foreach (RepeaterItem rptItems in rptListOptionsUpgrade.Items)
        {
            CheckBox chk = (CheckBox)rptItems.FindControl("chkOptionsUpgrade");
            Label lbl = (Label)rptItems.FindControl("lblCostUpgrade");
            if (chk.Checked == true)
            {
                value += Convert.ToInt32(lbl.Text);
            }
            else
            {
            }
        }
        int value2 = Convert.ToInt32(dtTemp.Rows[0]["cost"].ToString());
        lblFee.Text = (value + value2).ToString();
    }
    protected void ddlUpgradeServices_SelectedIndexChanged(object sender, EventArgs e)
    {
        int packageId = Convert.ToInt32(ddlUpgradeServices.SelectedValue);
        if (packageId != 0)
        {
            pkgFunctionBus = new PackageFunctionBUS();
            DataTable dtfunction = pkgFunctionBus.GetFunctionbyPackageId(Convert.ToInt32(packageId));
            DataTable dtFunctionTemmp = new DataTable();
            dtFunctionTemmp.Columns.Add("functionId");
            dtFunctionTemmp.Columns.Add("functionName");
            dtFunctionTemmp.Columns.Add("cost");
            dtFunctionTemmp.Columns.Add("isDefault");
            foreach (DataRow drfunction in dtfunction.Rows)
            {
                int id = Convert.ToInt32(drfunction["functionId"].ToString());
                function = new FunctionBUS();
                DataTable dtTemp = function.GetByUserId(id);
                DataRow dr = dtFunctionTemmp.NewRow();
                dr["functionId"] = dtTemp.Rows[0]["functionId"].ToString();
                dr["functionName"] = dtTemp.Rows[0]["functionName"].ToString();
                dr["cost"] = dtTemp.Rows[0]["cost"].ToString();
                dr["isDefault"] = dtTemp.Rows[0]["isDefault"].ToString();
                dtFunctionTemmp.Rows.Add(dr);
            }
            rptListOptionsUpgrade.DataSource = dtFunctionTemmp;
            rptListOptionsUpgrade.DataBind();
            pkgBus = new PackageBUS();
            DataTable dtPackage = pkgBus.GetById(Convert.ToInt32(packageId));
            int currentLimitID = Convert.ToInt32(dtPackage.Rows[0]["limitId"].ToString());
            pkglimitBus = new PackageLimitBUS();
            DataTable dtTempp = pkglimitBus.GetAll();
            ddlPackageLimitUpgrade.DataSource = dtTempp;
            ddlPackageLimitUpgrade.DataTextField = "namepackagelimit";
            ddlPackageLimitUpgrade.DataValueField = "limitId";
            ddlPackageLimitUpgrade.DataBind();
            ddlPackageLimitUpgrade.SelectedValue = currentLimitID.ToString();
            ddlUpgradeTime.Enabled = true;
            //ddlUpgradeTime.SelectedValue = 1+"";
            int value = 0;
            int Id = Convert.ToInt32(ddlPackageLimitUpgrade.SelectedValue.ToString());
            int numberoftime = Convert.ToInt32(ddlUpgradeTime.SelectedValue);
            pkglimitBus = new PackageLimitBUS();
            DataTable dtTemps = pkglimitBus.GetByUserIdPackageLimit(Id);
            if (numberoftime > 0)
            {
                foreach (RepeaterItem rptItems in rptListOptionsUpgrade.Items)
                {
                    CheckBox chk = (CheckBox)rptItems.FindControl("chkOptionsUpgrade");
                    Label lbl = (Label)rptItems.FindControl("lblCostUpgrade");
                    if (chk.Checked == true)
                    {
                        value += Convert.ToInt32(lbl.Text);
                    }
                    else
                    {
                        //value = value;
                    }
                }
                int value2 = Convert.ToInt32(dtTemps.Rows[0]["cost"].ToString());
                if (numberoftime == 0)
                {
                    lblFee.Text = (value + value2).ToString();
                }
                else if (numberoftime > 0)
                {
                    int sum = ((value + value2) * numberoftime);
                    lblFee.Text = sum.ToString();
                }
            }
            else
            { 
                
            }
        }
    }
}