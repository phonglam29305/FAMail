using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class webapp_page_backend_view_content_send : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        loadListContentHasSend();
    }

    protected void loadListContentHasSend()
    {
        try 
	    {	        
            int groupId = int.Parse(Request.Params["groupId"]);
		    PartSendBUS psBus = new PartSendBUS();
            SendContentBUS scBus = new SendContentBUS();
            MailGroupBUS mgBus = new MailGroupBUS();
            DataTable tblPartSend = psBus.GetByUserIdAndGroupId(getUserLogin().UserId, groupId);
            if (tblPartSend.Rows.Count > 0)
            {
                string hasContentSend = tblPartSend.Rows[0]["hasContentSend"].ToString();
                string[] arrayContentSend = hasContentSend.Split(',');
                dlContentList.DataSource = arrayContentSend;
                dlContentList.DataBind();
                for (int i = 0; i < arrayContentSend.Length; i++)
                {
                    Label lblSubject = (Label)dlContentList.Items[i].FindControl("lblSubject");
                    Label lblContent = (Label)dlContentList.Items[i].FindControl("lblContent");
                    string contentId = arrayContentSend[i];
                    DataTable tblContent = scBus.GetByID(int.Parse(contentId));
                    if (tblContent.Rows.Count > 0)
                    {
                        lblSubject.Text = tblContent.Rows[0]["Subject"].ToString();
                        lblContent.Text = tblContent.Rows[0]["Body"].ToString();
                    }
                    
                }
            }

            DataTable tblMailGroup = mgBus.GetByID(groupId);
            if (tblMailGroup.Rows.Count > 0)
            {
                lblGroupName.Text = tblMailGroup.Rows[0]["Name"].ToString();
            }
	    }
	    catch (Exception)
	    {
		
		    throw;
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