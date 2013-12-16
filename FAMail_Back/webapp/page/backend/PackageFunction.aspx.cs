using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Email;
using System.Linq;
public partial class webapp_page_backend_Default : System.Web.UI.Page
{
    FunctionBUS functionBus = new FunctionBUS();
    PackageBUS packageBus = new PackageBUS();
    public string TenGoiDichVu = "";
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


    private void LoadData()
    {
        int packageId = 0;
        int.TryParse(Request.QueryString["id"] + "", out packageId);
        DataTable T = functionBus.GetbyPackage(packageId);
        functionList.DataSource = T;
        functionList.DataTextField = "functionName";
        functionList.DataValueField = "functionid";

        functionList.DataBind();

        foreach (ListItem item in functionList.Items)
        {
            DataRow[] rows = T.Select("functionid = " + item.Value);
            if (rows.Length > 0)
            {
                if (rows[0]["selected"] + "" == "1")
                    item.Selected = true;
            }
        }
        //functionList.DataBind();
    }

    log4net.ILog logs = log4net.LogManager.GetLogger("ErrorRollingLogFileAppender");
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int packageId = 0;
            int.TryParse(Request.QueryString["id"] + "", out packageId);
            packageBus.deletePackageFuntion(packageId);

            List<string> selectedValues = functionList.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => li.Value).ToList();
            foreach (var id in selectedValues)
            {
                packageBus.addFunction(packageId, int.Parse(id));
            }
            Response.Redirect("package.aspx");

        }
        catch (Exception ex)
        {
            logs.Error(getUserLogin().Username+"-PackageFunction - Save", ex);
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
}