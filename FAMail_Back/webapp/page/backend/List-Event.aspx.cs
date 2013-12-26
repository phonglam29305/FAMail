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
using System.Web.Script.Services;
using System.Text.RegularExpressions;


public partial class webapp_page_backend_List_Event : System.Web.UI.Page
{
    log4net.ILog logs = log4net.LogManager.GetLogger("ErrorRollingLogFileAppender");
    UserLoginDTO userLogin = null;
    MailConfigBUS mailConfigBus = null;
    MailGroupBUS mailGroupBus = null;
    EventBUS eventBus = null;
    SignatureBUS signBus = null;
    DataTable group = null;
    MailGroupBUS mgBUS = new MailGroupBUS();
    protected void Page_Load(object sender, EventArgs e)
    {
        userLogin = getUserLogin();
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


    private void InitialBUS()
    {
        mailConfigBus = new MailConfigBUS();
        mailGroupBus = new MailGroupBUS();
        eventBus = new EventBUS();
    }
    private void createTableMail()
    {
        group = new DataTable("group");
        DataColumn Id = new DataColumn("Id");
        Id.DataType = System.Type.GetType("System.Int32");
        DataColumn Name = new DataColumn("Name");
        DataColumn[] key = { Id };
        group.Columns.Add(Id);
        group.Columns.Add(Name);
        group.PrimaryKey = key;
    }

    private void loadData()
    {

      
        try
        {
           
            DataTable MailGroup = new DataTable();
            if (Session["us-login"] != null)
            {
                if (getUserLogin().DepartmentId == 1)
                {
                    MailGroup = mgBUS.GetAllNew();
                }
                if (getUserLogin().DepartmentId == 3)
                {
                    MailGroup = mgBUS.GetAllNewDepart3(getUserLogin().UserId);
                }
                if (getUserLogin().DepartmentId == 2)
                {
                    MailGroup = mgBUS.GetAllNew(getUserLogin().UserId);
                }
                if (MailGroup.Rows.Count > 0)
                {
                    createTableMail();
                    DataRow rowE = null;
                    if (getUserLogin().DepartmentId == 1)
                    {
                        rowE = group.NewRow();
                        rowE["Id"] = 0;
                        rowE["Name"] = "Tất cả";
                        group.Rows.Add(rowE);
                    }
                    foreach (DataRow rowItem in MailGroup.Rows)
                    {
                        rowE = group.NewRow();
                        rowE["Id"] = rowItem["Id"];
                        rowE["Name"] = rowItem["Name"];
                        group.Rows.Add(rowE);
                    }
                } 
           
                this.drlMailGroup.DataSource = group;
                this.drlMailGroup.DataTextField = "Name";
                this.drlMailGroup.DataValueField = "Id";
                this.drlMailGroup.DataBind();
            }

        }
        catch (Exception ex)
        {

            logs.Error(userLogin.Username + "-Client - LoadData", ex);

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

    protected void lbtDelete_Click(object sender, EventArgs e)
    {
       

    }


    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        //try
        //{

        //    ContentSendEventBUS cseBus = new ContentSendEventBUS();
        //    int contentId = int.Parse(((LinkButton)sender).CommandArgument.ToString());
        //    DataTable dtContent = (DataTable)Session["listContentSendEvent"];
        //    if (dtContent.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dtContent.Rows.Count; i++)
        //        {
        //            DataRow row = dtContent.Rows[i];
        //            if (row["Id"].Equals(contentId))
        //            {
        //                dtContent.Rows.Remove(row);
        //                cseBus.tblContentSendEvent_Delete(contentId);
                       
        //            }
        //        }
        //    }
        //    //LoadContentSendEventList(dtContent);
        //}
        //catch (Exception ex)
        //{

        //    logs.Error(userLogin.Username + "-Client - btnDelete_Click", ex);
        //    pnSuccess.Visible = false;
        //    pnError.Visible = true;
        //    lblError.Text = ex.Message;
        //}
    }


    protected void btnFilter_Click(object sender, EventArgs e)
    {
        InitialBUS();
        int GroupID = 0;
        GroupID = int.Parse(drlMailGroup.SelectedValue.ToString());
        DataTable dtEvent = new DataTable();
        UserLoginDTO userLogin = getUserLogin();
     
        if (userLogin.DepartmentId == 1)
        {
            dtEvent = eventBus.GetAll();
        }
        else if (getUserLogin().DepartmentId == 2)
        {
            dtEvent = eventBus.GetAllListEvent(txtSubject.Text, userLogin.UserId, GroupID);
        }
        else if (getUserLogin().DepartmentId == 3)
        {
            dtEvent = eventBus.GetAllListEvent(txtSubject.Text, userLogin.UserId, GroupID);
        }
        
        dlEvent.DataSource = dtEvent;
        dlEvent.DataBind();
        for (int i = 0; i < dtEvent.Rows.Count; i++)
        {
            DataRow row = dtEvent.Rows[i];

            LinkButton lbtSubject = (LinkButton)dlEvent.Items[i].FindControl("lbtSubject");
            lbtSubject.Text = row["Subject"].ToString();

            Label lblEmailGui = (Label)dlEvent.Items[i].FindControl("lblEmailGui");
            DataTable config = mailConfigBus.GetByID(int.Parse(row["ConfigId"].ToString()));
            if (config.Rows.Count > 0)
            {
                lblEmailGui.Text = config.Rows[0]["Email"].ToString();
            }

            Label lblStartDate = (Label)dlEvent.Items[i].FindControl("lblStartDate");
            lblStartDate.Text = row["StartDate"].ToString();

            Label lblEndDate = (Label)dlEvent.Items[i].FindControl("lblEndDate");
            lblEndDate.Text = row["EndDate"].ToString();

            Label lblVoucher = (Label)dlEvent.Items[i].FindControl("lblVoucher");
            lblVoucher.Text = row["Voucher"].ToString();

            //LinkButton lbtEdit = (LinkButton)dlEvent.Items[i].FindControl("lbtEdit");
            //lbtEdit.CssClass = "table-actions-button ic-table-edit";
            //lbtEdit.CommandArgument = row["EventId"].ToString();

            //LinkButton lbtDelete = (LinkButton)dlEvent.Items[i].FindControl("lbtDelete");
            //lbtDelete.CssClass = "table-actions-button ic-table-delete";
            //lbtDelete.CommandArgument = row["EventId"].ToString();

        }
    
       
    }
}