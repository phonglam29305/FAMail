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
                DataRow dr = group.NewRow();
                dr["Name"] = "---------------[Tất cả]-----------------";
                dr["Id"] = "-1";
                group.Rows.InsertAt(dr, 0);
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

        try
        {
            InitialBUS();
            int eventId = int.Parse(((ImageButton)sender).CommandArgument.ToString());
            ConnectionData.OpenMyConnection();
            eventBus.tblEvent_Delete(eventId);
            //Response.Redirect(Request.RawUrl);
            btnFilter_Click(null, null);
            visibleMessage(false);
            pnSuccess.Visible = true;
            lblSuccess.Text = "Bạn vừa xóa thành công sự kiện !";
            ConnectionData.CloseMyConnection();

        }
        catch (Exception ex)
        {
            logs.Error(userLogin.Username + "-Client - btnDelete_Click", ex);
            pnError.Visible = true;
            lblError.Text = ex.Message;
        }
    }

    protected void visibleMessage(bool vis)
    {
        pnError.Visible = vis;
        pnSuccess.Visible = vis;
    }
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        try
        {
            int AssignUserId = 0;
            InitialBUS();
            int ID = 0;
            int GroupID = 0;

            GroupID = int.Parse(drlMailGroup.SelectedValue.ToString());

            DataTable dtEvent = new DataTable();
            DataTable dtclient = new DataTable();
            UserLoginDTO userLogin = getUserLogin();

            if (userLogin.DepartmentId == 1)
            {
                dtEvent = eventBus.GetAll();
            }
            else if (getUserLogin().DepartmentId == 2)
            {
                dtclient = eventBus.GetClientId(getUserLogin().UserId);
                int clientid = int.Parse(dtclient.Rows[0]["clientId"].ToString());
                dtEvent = eventBus.GetAllListEventDepart2(txtSubject.Text, clientid, GroupID);
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

            }
        }
        catch (Exception ex)
        {
            logs.Error(userLogin.Username + "-Client - btnFilter_Click", ex);
        }


    }
}