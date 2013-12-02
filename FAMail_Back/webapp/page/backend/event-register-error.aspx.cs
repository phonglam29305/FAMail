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

public partial class webapp_page_backend_event_register_error2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Session["Error"].ToString() != null || Session["Error"].ToString() != "")
                {
                    lblMessage.Text = Session["Error"].ToString() ;
                }
            }
            catch (Exception)
            {
                lblMessage.Text = "Hệ thống đang bảo trì. Vui lòng quay lại sau ít phút !";
            }
            
        }
    }
}
