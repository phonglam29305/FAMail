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

public partial class webapp_page_backend_send_mail : System.Web.UI.Page
{

    MailConfigBUS mailConfigBus = null;
    MailGroupBUS mailGroupBus = null;
    EventBUS eventBus = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                  InitialBUS();
                LoadMailGroupLists();
                LoadMailConfigLists();
            }
            catch (Exception)
            {
                
             
            }
        }
    }

    private void LoadMailConfigLists()
    {
        DataTable dtMailConfig = mailConfigBus.GetAll();
        drlMailConfig.Items.Clear();
        drlMailConfig.DataSource = dtMailConfig.DefaultView;
        drlMailConfig.DataTextField = "Email";
        drlMailConfig.DataValueField = "Id";
        drlMailConfig.DataBind();
    }

    private void LoadMailGroupLists()
    {
        DataTable dtMailGroup = mailGroupBus.GetAll();
        drlMailGroup.Items.Clear();
        drlMailGroup.DataSource = dtMailGroup.DefaultView;
        drlMailGroup.DataTextField = "Name";
        drlMailGroup.DataValueField = "Id";
        drlMailGroup.DataBind();
    }

    private void InitialBUS()
    {
        mailConfigBus = new MailConfigBUS();
        mailGroupBus = new MailGroupBUS();
        eventBus = new EventBUS();
    }
}
