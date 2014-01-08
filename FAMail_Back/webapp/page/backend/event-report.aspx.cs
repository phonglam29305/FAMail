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

public partial class webapp_page_backend_Mail_Sended : System.Web.UI.Page
{
    MailGroupBUS mailGroupBus = null;
    EventDetailBUS eventDetailBus = null;
    EventBUS eventBus = null;
    DataTable group = null;
    log4net.ILog logs = log4net.LogManager.GetLogger("ErrorRollingLogFileAppender");
    UserLoginDTO userLogin = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                loadData();
                LoadEventReport();

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
        return null;
    }


    private void loadData()
    {
        eventDetailBus = new EventDetailBUS();
        eventBus = new EventBUS();
        try
        {

            DataTable dtEvent = new DataTable();

            if (Session["us-login"] != null)
            {
                //if (getUserLogin().DepartmentId == 1)
                //{
                //    dtEvent = eventBus.GetAll();
                //}
                //else
                //{
                dtEvent = eventBus.GetByUserId(getUserLogin().UserId);
                //}



                if (dtEvent.Rows.Count > 0)
                {
                    createTableMail();
                    DataRow rowE = null;
                    if (getUserLogin().DepartmentId == 1)
                    {
                        rowE = group.NewRow();
                        rowE["EventId"] = 0;
                        rowE["Subject"] = "Tất cả";
                        group.Rows.Add(rowE);
                    }
                    foreach (DataRow rowItem in dtEvent.Rows)
                    {
                        rowE = group.NewRow();
                        rowE["EventId"] = rowItem["EventId"];
                        rowE["Subject"] = rowItem["Subject"];
                        group.Rows.Add(rowE);
                    }
                } //DataRow dr = group.NewRow();
                //dr["Subject"] = "---------------[Tất cả]-----------------";
                //dr["EventId"] = "-1";
                //group.Rows.InsertAt(dr, 0);
                this.drlNhomMail.DataSource = group;
                this.drlNhomMail.DataTextField = "Subject";
                this.drlNhomMail.DataValueField = "EventId";
                this.drlNhomMail.DataBind();


                object obj = Request.QueryString["id"];
                int eventId = 0;
                if (int.TryParse(obj + "", out eventId))
                {
                    if (group.Select("eventid=" + eventId).Count() > 0)
                        drlNhomMail.SelectedValue = eventId+"";
                }
            }

        }
        catch (Exception ex)
        {

            logs.Error(userLogin.Username + "-eventreport - LoadData", ex);

        }
    }

    private void createTableMail()
    {
        group = new DataTable("group");
        DataColumn Id = new DataColumn("EventId");
        Id.DataType = System.Type.GetType("System.Int32");
        DataColumn Name = new DataColumn("Subject");
        DataColumn[] key = { Id };
        group.Columns.Add(Id);
        group.Columns.Add(Name);
        group.PrimaryKey = key;
    }

    protected void LoadEventReport()
    {
        try
        {
            mailGroupBus = new MailGroupBUS();
            eventDetailBus = new EventDetailBUS();
            UserLoginDTO userLogin = getUserLogin();
            DataTable dtGroup = new DataTable();


            int eventID = int.Parse(drlNhomMail.SelectedValue.ToString());
            //if (getUserLogin().DepartmentId == 1)
            //{
            //    dtGroup = mailGroupBus.GetAllNew();
            //}

            //if (getUserLogin().DepartmentId == 3)
            //{
            //    dtGroup = mailGroupBus.GetAllNewDepart3(getUserLogin().UserId);
            //}
            //else 
            //{
            //    dtGroup = mailGroupBus.GetMailGroupByUserId(getUserLogin().UserId);
            // }
            dtGroup = mailGroupBus.GetMailGroupByEventId(eventID);

            rptGroup.DataSource = dtGroup;
            rptGroup.DataBind();
            for (int i = 0; i < dtGroup.Rows.Count; i++)
            {

                DataRow rowGroup = dtGroup.Rows[i];
                int groupId = int.Parse(rowGroup["Id"].ToString());


                DataTable dtEventByGroup = eventDetailBus.GetByGroupIdNew(groupId, eventID);
                if (dtEventByGroup.Rows.Count > 0)
                {
                    Label lblGroupName = (Label)rptGroup.Items[i].FindControl("lblGroupName");
                    lblGroupName.Text = rowGroup["Name"].ToString() + " ( Có " + dtEventByGroup.Rows.Count + " khách hàng đăng ký )";
                }

                if (dtEventByGroup.Rows.Count > 0)
                {
                    DataList dlEventRegister = (DataList)rptGroup.Items[i].FindControl("dlEventRegister");
                    dlEventRegister.DataSource = dtEventByGroup;
                    dlEventRegister.DataBind();
                    for (int j = 0; j < dtEventByGroup.Rows.Count; j++)
                    {
                        DataRow rowEventDetail = dtEventByGroup.Rows[j];
                        Label lblEmail = (Label)dlEventRegister.Items[j].FindControl("lblEmail");
                        lblEmail.Text = rowEventDetail["EmailID"].ToString();

                        Label lblName = (Label)dlEventRegister.Items[j].FindControl("lblName");
                        lblName.Text = (rowEventDetail["FullName"].ToString() == null) ? "Không có" : rowEventDetail["FullName"].ToString();

                        Label lblAddress = (Label)dlEventRegister.Items[j].FindControl("lblAddress");
                        lblAddress.Text = (rowEventDetail["Address"].ToString() == "") ? "Không có" : rowEventDetail["Address"].ToString();

                        Label lblCreateDate = (Label)dlEventRegister.Items[j].FindControl("lblCreateDate");
                        lblCreateDate.Text = rowEventDetail["CreateDate"].ToString();

                        Label lblGroup = (Label)dlEventRegister.Items[j].FindControl("lblGroupName");
                        lblGroup.Text = rowGroup["Name"].ToString();//Lay tu group ben tren

                        Label lblEvent = (Label)dlEventRegister.Items[j].FindControl("lblEvent");
                        lblEvent.Text = rowEventDetail["EventId"].ToString();
                    }
                }


            }
        }
        catch (Exception ex)
        {
            logs.Error(userLogin.Username + "EventReport - LoadEventReport", ex);
        }
    }


    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        //CheckBox chkAll = (CheckBox)sender;
        //if (chkAll != null)
        //{
        //    for (int i = 0; i < dtlWaitSend.Items.Count; i++)
        //    {
        //        DataListItem item = dtlWaitSend.Items[i];
        //        CheckBox chk = (CheckBox)item.FindControl("chkXoa");
        //        chk.Checked = chkAll.Checked;
        //    }
        //}
    }
    protected void lbtExecute_Click(object sender, EventArgs e)
    {
    }
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        LoadEventReport();
    }
}
