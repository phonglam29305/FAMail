using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webapp_page_backend_clientRegister : System.Web.UI.Page
{
    ClientRegisterBUS clientregisterBus = new ClientRegisterBUS();
    log4net.ILog logs = log4net.LogManager.GetLogger("ErrorRollingLogFileAppender");
    UserLoginDTO userLogin = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        userLogin = getUserLogin();
        if (!IsPostBack)
        {
            try
            {
                //loadData();
                package();
            }
            catch (Exception)
            {
            }
        }
    }
    private void package()
    {
        Dropgoidichvu.Items.Clear();
        DataTable dt = new DataTable();
        dt.Columns.Add("namepackagelimit");
        dt = clientregisterBus.GetAllPackage();
        DataRow dr = dt.NewRow();
        dr["namepackagelimit"] = "---------------[Tất cả]-----------------";
        dr["limitId"] = "-1";
        dt.Rows.InsertAt(dr, 0);
        //DataRow dr=new DataRow();
        //dr.colu
        Dropgoidichvu.DataSource = dt;
        Dropgoidichvu.DataTextField = "namepackagelimit";
        Dropgoidichvu.DataValueField = "limitId";
        Dropgoidichvu.DataBind();
        Dropgoidichvu.SelectedValue = "-1";

    }
    private void loadData()
    {
        try
        {
            //DateTime dt1 = new DateTime();
            DataTable t = clientregisterBus.Search_client_register("", "", "", "", "", "");
            dlPager.MaxPages = 1000;
            dlPager.PageSize = 50;
            dlPager.DataSource = t.DefaultView;
            dlPager.BindToControl = dtregister;
            this.dtregister.DataSource = dlPager.DataSourcePaged;
            this.dtregister.DataBind();


        }
        catch (Exception ex)
        { logs.Error(userLogin.Username+"-Client - LoadData", ex); }
    }
    private UserLoginDTO getUserLogin()
    {
        if (Session["us-login"] != null)
        {
            return (UserLoginDTO)Session["us-login"];
        }
        return null;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        string ngaydk_from = txtngaydangky.Text;
        string ngaydk_to = txtdenngaydangky.Text;
        string ngayhh_from =txtngayhethang.Text;
        string ngayhh_to = txtdenngayhethang.Text;
        DataTable t = clientregisterBus.Search_client_register(txtname.Text, Dropgoidichvu.SelectedValue, ngaydk_from, ngaydk_to, ngayhh_from, ngayhh_to);
        dlPager.MaxPages = 1000;
        dlPager.PageSize = 50;
        dlPager.DataSource = t.DefaultView;
        dlPager.BindToControl = dtregister;
        this.dtregister.DataSource = dlPager.DataSourcePaged;
        this.dtregister.DataBind();
        try
        {

        }
        catch (Exception ex)
        { logs.Error(userLogin.Username+"-Client - Filter", ex); }
    }
}