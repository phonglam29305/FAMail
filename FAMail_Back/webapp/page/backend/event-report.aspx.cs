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
    ContentSendEventBUS cseBus = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        userLogin = getUserLogin();
        if (!IsPostBack)
        {
            try
            {
                loadData();
                LoadEventReport();
                LoadContentList();
            }
            catch (Exception)
            {
            }
        }

    }
    private void LoadContentList()
    {
        try
        {
            object obj = Request.QueryString["id"];
            int eventId = 0;
            if (int.TryParse(obj + "", out eventId))
            {
                LoadReport(eventId);
            }

        }
        catch (Exception ex)
        {
            logs.Error(userLogin.Username + "-Create-Event - LoadContentList", ex);
        }
    }

    void LoadReport(int eventId)
    {
        cseBus = new ContentSendEventBUS();
        DataTable tblContent = cseBus.GetReportByEventId(eventId);
        dlContentSendEvent.DataSource = tblContent;
        dlContentSendEvent.DataBind();

        for (int i = 0; i < tblContent.Rows.Count; i++)
        {
            Label lblChart = (Label)dlContentSendEvent.Items[i].FindControl("lblChart");
            int totalSend = Convert.ToInt32(tblContent.Rows[i]["TotalSend"] + "");
            if (totalSend == 0) lblChart.Text = "Chưa được gửi";
            else
                CreateChart(Convert.ToInt32(tblContent.Rows[i]["TotalSend"] + ""), Convert.ToInt32(tblContent.Rows[i]["TotalErr"] + ""), Convert.ToInt32(tblContent.Rows[i]["TotalOpen"] + ""), Convert.ToInt32(tblContent.Rows[i]["TotalNotOpen"] + ""), Convert.ToInt32(tblContent.Rows[i]["TotalNotRecieve"] + ""), tblContent.Rows[i]["Subject"] + "", lblChart);
        }
    }
    private UserLoginDTO getUserLogin()
    {
        if (Session["us-login"] != null)
        {
            return (UserLoginDTO)Session["us-login"];
        }
        else Response.Redirect("~");
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
                        drlNhomMail.SelectedValue = eventId + "";
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
                LoadReport(eventID);

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

    protected string LoadChart(object id)
    {
        int readMail = 0;
        try
        {
            //int i=0;
            for (int i = 0; i < dlContentSendEvent.Items.Count; i++)
            {
                HiddenField hdfId = (HiddenField)dlContentSendEvent.Items[i].FindControl("hdfId");
                if (hdfId.Value + "" == id + "")
                {
                    SendRegisterBUS srBUS = new SendRegisterBUS();
                    SendRegisterDetailBUS srdBus = new SendRegisterDetailBUS();
                    SendContentBUS sendContentBus = new SendContentBUS();
                    MailGroupBUS mgBus = new MailGroupBUS();
                    int sendId = int.Parse(id + "");
                    DataTable campain = srdBus.GetByContentID(sendId);
                    DataTable errSend = srdBus.GetContentSendEventDetailByStatus(false, sendId);
                    DataTable unreceve = srdBus.GetByNotReceve(sendId);
                    int err = errSend.Rows.Count;
                    Label lblTotalMailSend = (Label)dlContentSendEvent.Items[i].FindControl("lblTotalMailSend");
                    Label lblEmailSend = (Label)dlContentSendEvent.Items[i].FindControl("lblEmailSend");
                    Label lblNotOpen2 = (Label)dlContentSendEvent.Items[i].FindControl("lblNotOpen2");
                    Label lblOpened = (Label)dlContentSendEvent.Items[i].FindControl("lblOpened");
                    Label lblDateStart = (Label)dlContentSendEvent.Items[i].FindControl("lblDateStart");
                    Label lblDateEnd = (Label)dlContentSendEvent.Items[i].FindControl("lblDateEnd");
                    Label lblGroupEmailTo = (Label)dlContentSendEvent.Items[i].FindControl("lblGroupEmailTo");
                    Label lblCampianName = (Label)dlContentSendEvent.Items[i].FindControl("lblCampianName");
                    Label lblChart = (Label)dlContentSendEvent.Items[i].FindControl("lblChart");
                    lblTotalMailSend.Text = campain.Rows.Count.ToString();
                    int notreceve = unreceve.Rows.Count;
                    if (campain.Rows.Count > 0)
                    {
                        lblEmailSend.Text = campain.Rows[0]["MailSend"].ToString();
                        foreach (DataRow row in campain.Rows)
                        {
                            if (row["isOpenMail"].ToString() == "True")
                            {
                                readMail++;
                            }
                        }
                        lblNotOpen2.Text = (campain.Rows.Count - readMail).ToString();
                    }
                    lblOpened.Text = readMail.ToString();
                    DataTable sendregisteDetail = cseBus.GetById(sendId);
                    if (sendregisteDetail.Rows.Count > 0)
                    {
                        int contentID = int.Parse(sendregisteDetail.Rows[0]["id"].ToString());
                        //lblDateStart.Text = sendregisteDetail.Rows[0]["StartDate"].ToString();
                        //lblDateEnd.Text = sendregisteDetail.Rows[0]["EndDate"].ToString();
                        int groupSend = int.Parse(sendregisteDetail.Rows[0]["GroupTo"].ToString());
                        if (groupSend == -3)
                            lblGroupEmailTo.Text = "Tất cả";
                        else lblGroupEmailTo.Text = mgBus.GetByID(groupSend).Rows[0]["Name"].ToString();
                        if (sendContentBus.GetByID(contentID).Rows.Count > 0)
                        {
                            lblCampianName.Text = sendContentBus.GetByID(contentID).Rows[0]["Subject"].ToString();
                        }
                    }
                    CreateChart(campain.Rows.Count, err, readMail, 1, notreceve, lblCampianName.Text, lblChart);
                }
            }
        }
        catch (Exception ex)
        {
            pnError.Visible = true;
            lblError.Text = ex.Message;

        }
        return "";
    }

    private void CreateChart(int total, int err, int open, int NotOpen, int notRecive, string campainName, Label lblChart)
    {
        if (total == 0) total = 1;
        float percentErr = 1;
        percentErr = (err * 100) / total;
        double percentSend = 100 - percentErr;
        float percentOpen = 1;
        percentOpen = (open * 100) / total;
        double percentNotOpen = percentSend - percentOpen;
        double percentNotRecev = (notRecive * 100) / total;
        string html = "<table>" +
                   " <tr><td colspan='2' style='background-color:rgb(97, 88, 88); color:White;'><h2 style='font-size: 15px;font-weight:bolder;" +
                   " vertical-align: middle; text-transform: uppercase;  margin-top: 10px;width: 100%;'>Biểu đồ thông kê chiến dịch</h2></td></tr>" +
                    " <tr style='height:35px'>" +
                                       "<td style='width:35%; text-align:left;padding-left:10px;'>Tổng số mail gửi </td>" +
                                      " <td style='text-align:left;'> <div style='width:" + percentSend.ToString() + "%; background-color:#59D2EB; ; text-align:center;' >" +
                                           "<asp:Label ID='lblTotalSend' runat='server' Text='" + percentSend.ToString() + "'>" + percentSend.ToString() + "%</asp:Label></div>  </td>" +
                                  " </tr>" +
                                    "<tr style='height:35px'>" +
                                      " <td style='width:35%; text-align:left; padding-left:10px;'>Mail lỗi </td>" +
                                      " <td style='text-align:left'><div style='width:" + percentErr.ToString() + "%; background-color:#59D2EB; text-align:center;'>" +
                                           "<asp:Label ID='lblNumberErr' runat='server' Text='" + percentErr.ToString() + "% &nbsp;'>" + percentErr.ToString() + "%</asp:Label></div> </td>" +
                                 "  </tr>" +

                                   " <tr style='height:35px'>" +
                                    "   <td style='width:35%; text-align:left;padding-left:10px;'>Mail đã mở: </td>" +
                                     "  <td style='text-align:left'><div style='width:" + percentOpen.ToString() + "%; background-color:#59D2EB;text-align:center;' >" +
                                         "  <asp:Label ID='lblIsOpen' runat='server' Text='&nbsp;" + percentOpen.ToString() + "%'>" + percentOpen.ToString() + "%</asp:Label></div>  </td>" +
                                  " </tr>" +
                                   " <tr style='height:35px'>" +
                                    "   <td style='width:35%; text-align:left;padding-left:10px;'>Mail chưa mở : </td>" +
                                      " <td style='text-align:left'><div style='width:" + percentNotOpen.ToString() + "%; background-color:#59D2EB; text-align:center;' >" +
                                      "     <asp:Label ID='lblNotOpen' runat='server' Text='&nbsp;" + percentNotOpen.ToString() + "%'>" + percentNotOpen.ToString() + "%</asp:Label></div> </td>" +
                                  " </tr>" +
                                   " <tr style='height:35px'>" +
                                    "   <td style='width:35%; text-align:left;padding-left:10px;'>Mail từ chối nhận tin: </td>" +
                                     "  <td style='text-align:left'><div style='width:" + percentNotRecev.ToString() + "%; background-color:#59D2EB; text-align:center;' >" +
                                       "    <asp:Label ID='lblNotRecived' runat='server' Text='&nbsp;" + percentNotRecev.ToString() + "%'>" + percentNotRecev.ToString() + "%</asp:Label></div> </td>" +
                                  " </tr>" +

    "<tr><td colspan='2'><h2  style='font-size: 15px;font-weight:bolder; vertical-align: middle; text-transform:uppercase; height:35px; text-decoration:underline; padding-top:20px; '>Chiến dịch: " + campainName + "</h2></td></tr>" +
"</table>";
        lblChart.Text = html;
    }
}
