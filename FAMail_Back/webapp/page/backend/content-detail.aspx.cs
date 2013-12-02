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

public partial class webapp_page_backend_content_detail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            SendContentBUS scBus = new SendContentBUS();
            string id = Request.QueryString["id"] ;
            DataTable tblContent = scBus.GetByID(int.Parse(id));
            if (tblContent.Rows.Count > 0)
            {
                lblContentDetail.Text = tblContent.Rows[0]["Body"].ToString();
            }
        }
        catch (Exception)
        {            
            throw;
        }
        
    }
}
