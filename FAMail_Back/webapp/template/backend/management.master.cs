using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.IO;

public partial class webapp_template_backend_SendMail : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckUrl();
        if (!IsPostBack)
        {
            checkRole();
        }
    }
    private void checkRole()
    {
        try
        {
            UserLoginDTO ulDto = getUserLogin();
            foreach (Control child in ControlPanel.Controls)
            {
                if (child is HyperLink)
                {
                    HyperLink hplRole = (HyperLink)child;
                    hplRole.Visible =
                          Common.checkRoleByRoleId(int.Parse(hplRole.Attributes["roleId"]), ulDto.DepartmentId);
                }
            }
        }
        catch (Exception ex)
        {
            //throw;
        }
    }
    private void CheckUrl()
    {
        string role = "";
        UserLoginDTO ulDto = getUserLogin();
        string url = Path.GetFileName(Request.PhysicalPath);
        DataTable dt = Common.GetRoleIdByName(url);
        if (dt.Rows.Count > 0)
        {
            role = dt.Rows[0]["roleId"].ToString();
            int DepartmentId = ulDto.DepartmentId;
            bool isAllowed = Common.checkRoleByRoleId(int.Parse(role), DepartmentId);
            if (isAllowed == false)
            {
                Response.Redirect("clientregister.aspx");
            }
        }
    }
    private UserLoginDTO getUserLogin()
    {
        if (Session["us-login"] != null)
        {
            //string name = Session["us-login"].ToString();
            return (UserLoginDTO)Session["us-login"];
        }
        return null;
    }
}
