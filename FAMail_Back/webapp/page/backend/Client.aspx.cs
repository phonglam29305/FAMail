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

public partial class webapp_page_backend_Customer : System.Web.UI.Page
{
    ClientBUS clientBUS = null;
    log4net.ILog logs = log4net.LogManager.GetLogger("ErrorRollingLogFileAppender");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                loadData();
            }
            catch (Exception)
            {
            }
        }

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
    private void loadData()
    {
        try
        {
            InitBUS();
            DataTable T = clientBUS.Search("", "", -1, false, "", "");
            dlPager.MaxPages = 1000;
            dlPager.PageSize = 50;
            dlPager.DataSource = T.DefaultView;
            dlPager.BindToControl = dtlCustomer;
            this.dtlCustomer.DataSource = dlPager.DataSourcePaged;
            this.dtlCustomer.DataBind();
        }
        catch (Exception ex)
        { logs.Error(getUserLogin().Username+"-Client - LoadData", ex); }
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        try{
        InitBUS();
        int sex = 0;
        sex = int.Parse(dlGioiTinh.SelectedValue.ToString());
        DataTable T = clientBUS.Search(txtName.Text, txtEmail.Text, sex, false, "", "");
        dlPager.MaxPages = 1000;
        dlPager.PageSize = 50;
        dlPager.DataSource = T.DefaultView;
        dlPager.BindToControl = dtlCustomer;
        this.dtlCustomer.DataSource = dlPager.DataSourcePaged;
        this.dtlCustomer.DataBind();
        }
        catch (Exception ex)
        { logs.Error(getUserLogin().Username+"-Client - Filter", ex); }
    }
    protected void btn_Click(object sender, CommandEventArgs e)
    {
        try
        {
            InitBUS();
            int id = int.Parse(e.CommandArgument + "");
            if (e.CommandName == "Lock")
                clientBUS.Customer_Lock_Unlock(id, Common.clientStatus.Lock);
            else
                clientBUS.Customer_Lock_Unlock(id, Common.clientStatus.Normal);
            btnFilter_Click(null, EventArgs.Empty);
        }
        catch (Exception ex)
        { logs.Error(getUserLogin().Username+"-Client - Lock-UnLock", ex); }
    }
    private void InitBUS()
    {
        clientBUS = new ClientBUS();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }
}
