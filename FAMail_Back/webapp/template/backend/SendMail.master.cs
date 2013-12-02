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

public partial class webapp_template_backend_SendMail : System.Web.UI.MasterPage
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
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
