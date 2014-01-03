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

public partial class webapp_page_backend_create_event : System.Web.UI.Page
{
    MailConfigBUS mailConfigBus = null;
    MailGroupBUS mailGroupBus = null;
    EventBUS eventBus = null;
    SignatureBUS signBus = null;
    UserLoginDTO userLogin = null;
    log4net.ILog logs = log4net.LogManager.GetLogger("ErrorRollingLogFileAppender");
    log4net.ILog logs_info = log4net.LogManager.GetLogger("InfoRollingLogFileAppender");
    protected void Page_Load(object sender, EventArgs e)
    {
            userLogin = getUserLogin();
        if (!IsPostBack)
        {
            try
            {
                InitialBUS();
                LoadMailGroupLists();
                LoadMailConfigList();
                //LoadEventList();
                // Khoi tao session for store contentSendEvent
                ContentSendEventBUS cseBus = new ContentSendEventBUS();
                Session["listContentSendEvent"] = cseBus.GetById(0);

                LoadContentList();
            }
            catch (Exception ex)
            {
                logs.Error(userLogin.Username + "-Create-Event - Page_Load", ex);
                pnError.Visible = true;
                lblError.Text = ex.Message;
            }

        }
    }

    private void LoadContentList()
    {
        try
        {
            SendContentBUS scBus = new SendContentBUS();
            DataTable dtContent = scBus.GetAll(getUserLogin().UserId);
            if (dtContent.Rows.Count > 0)
            {
                DataRow row = dtContent.NewRow();
                row["Subject"] = "[Chọn nội dung]";
                row["Id"] = "-1";
                dtContent.Rows.InsertAt(row, 0);
                drlContent.DataSource = dtContent;
                drlContent.DataTextField = "Subject";
                drlContent.DataValueField = "Id";
                drlContent.DataBind();
            }
        }
        catch (Exception ex)
        {
            logs.Error(userLogin.Username + "-Create-Event - LoadContentList", ex);
        }
    }

    private void LoadContentSendEventList(DataTable dataTable)
    {
        try
        {
            SendContentBUS scBus = new SendContentBUS();
            if (dataTable.Rows.Count > -1)
            {
                dlContentSendEvent.DataSource = dataTable;
                dlContentSendEvent.DataBind();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Label lblNo = (Label)dlContentSendEvent.Items[i].FindControl("lblNo");
                    lblNo.Text = (i + 1).ToString();

                    LinkButton lbtContent = (LinkButton)dlContentSendEvent.Items[i].FindControl("lbtContent");
                    String contentId = dataTable.Rows[i]["ContentId"].ToString();
                    DataTable dtContent = scBus.GetByID(int.Parse(contentId));
                    if (dtContent.Rows.Count > 0)
                    {
                        lbtContent.Text = dtContent.Rows[0]["Subject"].ToString();
                    }

                    Label lblHour = (Label)dlContentSendEvent.Items[i].FindControl("lblHour");
                    lblHour.Text = dataTable.Rows[i]["HourSend"].ToString() + " Giờ sau";

                    string id = dataTable.Rows[i]["Id"].ToString();
                    LinkButton lbtDelete = (LinkButton)dlContentSendEvent.Items[i].FindControl("lbtContentDelete");
                    lbtDelete.CommandArgument = id;

                }
            }
        }
        catch (Exception ex)
        {
            logs.Error(userLogin.Username + "-Create-Event - LoadContentSendEventList", ex);
        }

    }

    //private void LoadSignatureList()
    //{
    //    try
    //    {
    //        signBus = new SignatureBUS();
    //        UserLoginDTO userLogin = getUserLogin();
    //        DataTable tblSignList = signBus.GetByUserId(userLogin.UserId);
    //        if (tblSignList.Rows.Count > 0)
    //        {
    //            dlSignature.DataSource = tblSignList;
    //            dlSignature.DataBind();

    //            for (int i = 0; i < tblSignList.Rows.Count; i++)
    //            {                    
    //                LinkButton lbtInsert = (LinkButton)dlSignature.Items[i].FindControl("lbtInsert");
    //                lbtInsert.CommandArgument = tblSignList.Rows[i]["id"].ToString();
    //                lbtInsert.Text = tblSignList.Rows[i]["SignatureName"].ToString();
    //                //lbtInsert.ToolTip = tblSignList.Rows[i]["SignatureContent"].ToString();
    //            }
    //        }
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //}

    private UserLoginDTO getUserLogin()
    {
        if (Session["us-login"] != null)
        {
            return (UserLoginDTO)Session["us-login"];
        }
        else Response.Redirect("~");
        return null;
    }
    protected void lbtInsertSignature_Click(object sender, EventArgs e)
    {
        try
        {
            int signId = int.Parse(((LinkButton)sender).CommandArgument.ToString());
            signBus = new SignatureBUS();
            DataTable tblSign = signBus.GetById(signId);
            if (tblSign.Rows.Count > 0)
            {
                txtContent.Text = txtContent.Text + "\n" + tblSign.Rows[0]["SignatureContent"].ToString();
            }
        }
        catch (Exception ex)
        {

            logs.Error(userLogin.Username + "-Create-Event - lbtInsertSignature_Click", ex);
        }

    }

    private void LoadEventList()
    {
        try
        {
            string EventId = Request.QueryString["EventId"].ToString();
            this.hdfEventId.Value = EventId + "";
            int ID = 0;
            if (EventId != null)
            {
                ID = int.Parse(EventId);
                DataTable dtEvent = eventBus.GetByID(ID);
                if (dtEvent.Rows.Count > 0)
                {

                    txtSubject.Text = dtEvent.Rows[0]["Subject"].ToString();
                    txtVoucher.Text = dtEvent.Rows[0]["Voucher"].ToString();
                    drlMailConfig.SelectedItem.Value = dtEvent.Rows[0]["ConfigId"].ToString();
                    drlMailGroup.SelectedValue = dtEvent.Rows[0]["GroupId"].ToString();
                    txtContent.Text = dtEvent.Rows[0]["Body"].ToString();
                    txtStartDate.Text = convertDateToString(DateTime.Parse(dtEvent.Rows[0]["StartDate"].ToString()));
                    txtEndDate.Text = convertDateToString(DateTime.Parse(dtEvent.Rows[0]["EndDate"].ToString()));
                    if (dtEvent.Rows[0]["ResponeUrl"].Equals("Default"))
                    {
                        chkDefaultPage.Checked = true;
                        txtResponeUrl.Enabled = false;
                    }
                    else
                    {
                        txtResponeUrl.Text = dtEvent.Rows[0]["ResponeUrl"].ToString();
                    }


                    // Hien thi ConentSendEvent list.
                    ContentSendEventBUS cseBus = new ContentSendEventBUS();
                    DataTable tblContent = cseBus.GetByEventId(ID);
                    if (tblContent.Rows.Count > 0)
                    {
                        Session["listContentSendEvent"] = tblContent;
                        LoadContentSendEventList(tblContent);
                    }

                }
            }
        }
        catch (Exception ex)
        {

            logs.Error(userLogin.Username + "-Create-Event - LoadEventList", ex);
        }

    }

    private void LoadMailConfigList()
    {
        try
        {
            DataTable dtMailConfig = new DataTable();
            UserLoginDTO userLogin = getUserLogin();
            if (userLogin.DepartmentId == 1)
            {
                dtMailConfig = mailConfigBus.GetAll();
            }
            else
            {
                dtMailConfig = mailConfigBus.GetByUserId(userLogin.UserId);
            }
            drlMailConfig.Items.Clear();
            drlMailConfig.DataSource = dtMailConfig.DefaultView;
            drlMailConfig.DataTextField = "Email";
            drlMailConfig.DataValueField = "Id";
            drlMailConfig.DataBind();
        }
        catch (Exception ex)
        {

            logs.Error(userLogin.Username + "-Create-Event - LoadMailConfigList", ex);
        }
    }



    private void LoadMailGroupLists()
    {
        try
        {
            DataTable dtMailGroup = null;

            if (getUserLogin().DepartmentId == 1)
            {
                dtMailGroup = mailGroupBus.GetAllNew();
            }
            else //if (getUserLogin().DepartmentId == 2)
            {
                dtMailGroup = mailGroupBus.GetMailGroupByUserId(getUserLogin().UserId);
            }
            //if (getUserLogin().DepartmentId == 3)
            //{
            //    dtMailGroup = mailGroupBus.GetAllNewDepart3(getUserLogin().UserId);
            //}

            if (dtMailGroup.Rows.Count > 0)
            {
                drlMailGroup.Items.Clear();
                drlMailGroup.DataSource = dtMailGroup.DefaultView;
                drlMailGroup.DataTextField = "Name";
                drlMailGroup.DataValueField = "Id";
                drlMailGroup.DataBind();

            }
            else
            {
                //pnSelectGroup.Visible = false;
            }
        }
        catch (Exception ex)
        {

            logs.Error(userLogin.Username + "-Create-Event - LoadMailGroupLists", ex);
        }
    }

    private void InitialBUS()
    {
        mailConfigBus = new MailConfigBUS();
        mailGroupBus = new MailGroupBUS();
        eventBus = new EventBUS();
    }
    protected void btnSaveEvent_Click(object sender, EventArgs e)
    {
        try
        {

            InitialBUS();
            String eventId = hdfEventId.Value.ToString();
            EventDTO eventDto = getEvent();
            if (checkData() != "")
            {
                pnSuccess.Visible = false;
                pnError.Visible = true;
                lblError.Text = checkData();
                return;
            }
            //check time for event
            if (chkRequireTime.Checked == true)
            {
                try
                {
                    string strStartDate = txtStartDate.Text;
                    DateTime startDate = convertStringToDate(strStartDate);
                    string strEndDate = txtEndDate.Text;
                    DateTime endDate = convertStringToDate(strEndDate);
                    eventDto.StartDate = startDate;
                    eventDto.EndDate = endDate;
                }
                catch (Exception)
                {
                    pnError.Visible = true;
                    lblError.Text = "Vui lòng kiểm tra lại định dạng ngày tháng !";
                    return;
                }

            }

            int status = 1;// insert
            if (eventId == "" || eventId == null)//insert new
            {
                int eId = eventBus.tblEvent_insert(eventDto);
                eventDto.EventId = eId;
                hdfEventId.Value = eId.ToString();
                // Store for ContentSendEvent table.
                saveContentSendEvent(eId);

                DataTable dtContent = (DataTable)Session["listContentSendEvent"];
                eventBus.tblEventCustomer_Insert(eventDto);
                logs_info.Info(userLogin.Username + " create event(" + eId + ") with " + dtContent.Rows.Count + " send times");
            }
            else //update
            {
                status = 2;
                eventDto.EventId = int.Parse(eventId);
                eventBus.tblEvent_Update(eventDto);

                // Store for ContentSendEvent table.
                saveContentSendEvent(int.Parse(eventId));
            }

            pnSuccess.Visible = true;

            if (status == 1)
            {
                lblSuccess.Text = "Bạn vừa thêm thành công sự kiện !";
            }
            else
            {
                lblSuccess.Text = "Thông tin của sự kiện đã được cập nhật !";
            }
            pnError.Visible = false;
            // LoadEventList();
        }
        catch (Exception ex)
        {
            logs.Error(userLogin.Username + "Create-Event - btnSaveEvent_Click", ex);
            pnError.Visible = true;
            lblError.Text = ex.Message;
        }

    }
    private string checkData()
    {
        string msg = "";
        if (txtSubject.Text == "")
        {
            msg = "Vui lòng nhập vào tiêu đề cho sự kiện !";
        }
        else if (txtContent.Text == "")
        {
            msg = "Vui lòng nhập vào nội dung của sự kiện này !";
        }
        return msg;
    }
    protected EventDTO getEvent()
    {

        string subject = txtSubject.Text;
        string voucher = txtVoucher.Text;
        string subscribe = "";
        string body = txtContent.Text;
        int configId = int.Parse(drlMailConfig.SelectedValue.ToString());
        string responeUrl = "";
        if (chkDefaultPage.Checked == true)
        {
            responeUrl = "Default";
        }
        else
        {
            responeUrl = txtResponeUrl.Text;

            if (responeUrl == null || responeUrl == "")
            {
                responeUrl = "http://chomy.com.vn";
            }
        }

        int groupId = int.Parse(drlMailGroup.SelectedValue);
        // Set some default value.
        string confirmContent = "";
        string confirmFlag = "t";

        // Initial eventDto object.
        EventDTO eventDto = new EventDTO(subject, voucher, subscribe, body, configId,
            DateTime.Now, DateTime.Now, responeUrl, confirmContent, confirmFlag, getUserLogin().UserId, groupId);

        return eventDto;
    }
    protected void btnCreateNew_Click(object sender, EventArgs e)
    {
        try
        {
            resetForm();
            hdfEventId.Value = "";
            Response.Redirect(Request.RawUrl);

            // Set null value for listContentSendEvent session.
            ContentSendEventBUS cseBus = new ContentSendEventBUS();
            Session["listContentSendEvent"] = cseBus.GetById(0);

        }
        catch (Exception ex)
        {
            logs.Error(userLogin.Username + "Create-Event - btnCreateNew_Click", ex);
            pnError.Visible = true;
            lblError.Text = ex.Message;
        }

    }
    protected void resetForm()
    {
        txtSubject.Text = "";
        txtVoucher.Text = "";
        txtContent.Text = "";
        drlMailConfig.SelectedIndex = 0;
        drlMailGroup.SelectedIndex = 0;
    }
    protected DateTime convertStringToDate(string strDate)
    {
        int month = int.Parse(strDate.Substring(0, 2));
        int day = int.Parse(strDate.Substring(3, 2));
        int year = int.Parse(strDate.Substring(6, 4));
        int hours = int.Parse(strDate.Substring(11, 2));
        int minute = int.Parse(strDate.Substring(14, 2));
        DateTime dDate = new DateTime(year, month, day, hours, minute, 00);
        return dDate;
    }
    protected String convertDateToString(DateTime date)
    {
        int month = date.Month;
        int day = date.Day;
        int year = date.Year;
        int hours = date.Hour;
        int minute = date.Minute;
        String strDate = (month < 10) ? "0" + month : month + "";
        strDate += "/";
        strDate += (day < 10) ? "0" + day : day + "";
        strDate += "/";
        strDate += year + " ";
        strDate += (hours < 10) ? "0" + hours : hours + "";
        strDate += ":";
        strDate += (minute < 10) ? "0" + minute : minute + "";
        return strDate;

    }


    protected void lbtEdit_Click(object sender, EventArgs e)
    {
        try
        {
            InitialBUS();
            visibleMessage(false);
            int eventId = int.Parse(((LinkButton)sender).CommandArgument.ToString());
            DataTable dtEvent = eventBus.GetByID(eventId);
            if (dtEvent.Rows.Count > 0)
            {
                DataRow row = dtEvent.Rows[0];
                hdfEventId.Value = row["EventId"].ToString();
                txtSubject.Text = row["Subject"].ToString();
                txtVoucher.Text = row["Voucher"].ToString();
                drlMailConfig.SelectedValue = row["ConfigId"].ToString();
                drlMailGroup.SelectedValue = row["GroupId"].ToString();
                txtContent.Text = row["Body"].ToString();
                txtStartDate.Text = convertDateToString(DateTime.Parse(row["StartDate"].ToString()));
                txtEndDate.Text = convertDateToString(DateTime.Parse(row["EndDate"].ToString()));
                if (row["ResponeUrl"].Equals("Default"))
                {
                    chkDefaultPage.Checked = true;
                    txtResponeUrl.Enabled = false;
                }
                else
                {
                    txtResponeUrl.Text = row["ResponeUrl"].ToString();
                }
            }

            // Hien thi ConentSendEvent list.
            ContentSendEventBUS cseBus = new ContentSendEventBUS();
            DataTable tblContent = cseBus.GetByEventId(eventId);
            if (tblContent.Rows.Count > 0)
            {
                Session["listContentSendEvent"] = tblContent;
                LoadContentSendEventList(tblContent);
            }

        }
        catch (Exception ex)
        {
            logs.Error(userLogin.Username + "Create-Event - lbtEdit_Click", ex);
            pnError.Visible = true;
            lblError.Text = ex.Message;
        }

    }
    protected void visibleMessage(bool vis)
    {
        pnError.Visible = vis;
        pnSuccess.Visible = vis;
    }
    protected void lbtDelete_Click(object sender, EventArgs e)
    {
        try
        {
            InitialBUS();
            int eventId = int.Parse(((LinkButton)sender).CommandArgument.ToString());
            ConnectionData.OpenMyConnection();
            eventBus.tblEvent_Delete(eventId);
            //Response.Redirect(Request.RawUrl);
            LoadEventList();
            visibleMessage(false);
            pnSuccess.Visible = true;
            lblSuccess.Text = "Bạn vừa xóa thành công sự kiện !";
            ConnectionData.CloseMyConnection();

        }
        catch (Exception ex)
        {
            logs.Error(userLogin.Username + "Create-Event - lbtDelete_Click", ex);
            pnError.Visible = true;
            lblError.Text = ex.Message;
        }


    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            String eventId = hdfEventId.Value.ToString();
            EventDTO eventDto = getEvent();
            InitialBUS();
            if (eventId == "" || eventId == null)//them moi
            {
                int rs = eventBus.tblEvent_insert(eventDto);
                eventId = rs.ToString();
            }
            else //cap nhat
            {
                eventDto.EventId = int.Parse(eventId);
                eventBus.tblEvent_Update(eventDto);
            }
            Session["eventId"] = eventId;
            Session["GroupId"] = drlMailGroup.SelectedValue;
            Session["RequireTime"] = (chkRequireTime.Checked == true) ? "true" : "false";
            Response.Redirect("generate.aspx");
        }
        catch (Exception ex)
        {
            logs.Error(userLogin.Username + "Create-Event - btnGenerate_Click", ex);
            pnError.Visible = true;
            lblError.Text = ex.Message;
        }

    }
    protected void chkDefaultPage_CheckedChanged(object sender, EventArgs e)
    {
        if (chkDefaultPage.Checked == true)
        {
            txtResponeUrl.Enabled = false;
        }
        else
        {
            txtResponeUrl.Enabled = true;
        }
    }

    protected void lbtEditSignature_Click(object sender, EventArgs e)
    {
        Response.Redirect("create-signature.aspx");
    }
    //protected void lbtAddWelcome_Click(object sender, EventArgs e)
    //{
    //    if (txtWelcome.Text != "" && txtAfterWelcome.Text != "")
    //    {

    //        String welcomeText = txtWelcome.Text;
    //        if (rdoCustomerName.Checked == true)
    //        {
    //            welcomeText += "[khachhang]";
    //        }
    //        else
    //        {
    //            welcomeText += "[email]";
    //        }
    //        welcomeText += txtAfterWelcome.Text;

    //        txtContent.Text = welcomeText + "</br>" + txtContent.Text;
    //    }
    //}
    protected void btnSaveContent_Click(object sender, EventArgs e)
    {
        SendContentBUS scBus = new SendContentBUS();
        try
        {
            PanelHourError.Visible = false;
            DataTable dtContent = (DataTable)Session["listContentSendEvent"];
            int contentId = int.Parse(drlContent.SelectedValue);
            string contentSubject = drlContent.SelectedItem.ToString();

            int hour = int.Parse(txtHour.Text);
            DataRow row = dtContent.NewRow();
            row["ContentId"] = contentId;
            row["HourSend"] = hour;
            row["Id"] = DateTime.Now.Millisecond;
            dtContent.Rows.Add(row);

            LoadContentSendEventList(dtContent);
            txtContent.Text = "";
            drlContent.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            logs.Error(userLogin.Username + "Create-Event - btnSaveContent_Click", ex);
            PanelHourError.Visible = true;
            lblHourError.Text = "Nhập sai giá trị giờ !";
        }
    }
    protected void lbtContentDelete_Click(object sender, EventArgs e)
    {
        try
        {
            ContentSendEventBUS cseBus = new ContentSendEventBUS();
            int contentId = int.Parse(((LinkButton)sender).CommandArgument.ToString());
            DataTable dtContent = (DataTable)Session["listContentSendEvent"];
            if (dtContent.Rows.Count > 0)
            {
                for (int i = 0; i < dtContent.Rows.Count; i++)
                {
                    DataRow row = dtContent.Rows[i];
                    if (row["Id"].Equals(contentId))
                    {
                        dtContent.Rows.Remove(row);

                        // Xóa trong db, nếu có tồn tại.
                        if (hdfEventId.Value != null)
                        {
                            cseBus.tblContentSendEvent_Delete(contentId);
                        }
                    }
                }
            }
            LoadContentSendEventList(dtContent);
        }
        catch (Exception ex)
        {
            logs.Error(userLogin.Username + "Create-Event - btnSaveContent_Click", ex);
        }

    }

    protected void saveContentSendEvent(int eventId)
    {
        try
        {
            ContentSendEventBUS cseBus = new ContentSendEventBUS();
            DataTable dtContent = (DataTable)Session["listContentSendEvent"];
            if (dtContent.Rows.Count > 0)
            {
                for (int i = 0; i < dtContent.Rows.Count; i++)
                {
                    DataRow row = dtContent.Rows[i];
                    ContentSendEventDTO cseDto = new ContentSendEventDTO();
                    cseDto.Id = int.Parse(row["Id"].ToString());
                    cseDto.EventId = eventId;
                    cseDto.ContentId = int.Parse(row["ContentId"].ToString());
                    cseDto.HourSend = int.Parse(row["HourSend"].ToString());

                    int rsUpdate = cseBus.tblContentSendEvent_Update(cseDto);
                    if (rsUpdate <= 0)
                    {
                        cseBus.tblContentSendEvent_insert(cseDto);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            logs.Error(userLogin.Username + "Create-Event - btnSaveContent_Click", ex);
        }
    }

    protected void lbtContentRefresh_Click(object sender, EventArgs e)
    {
        LoadContentList();
    }
    [System.Web.Services.WebMethod]
    public static string Spam(string content)
    {
        try
        {
            string[] _content = Regex.Split(content, "//Hung-Hai//");
            SpamRuleBUS spamBUS = new SpamRuleBUS();
            DataTable spam = spamBUS.GetAll();
            float totalScoreTitle = 0;
            float totalScoreContent = 0;
            string ruleContent = "";
            float ItemScore = 0;
            string key = "";
            string titleData = _content[0];
            string contentData = _content[1];
            #region MyRegion
            #region Fisrt
            ruleContent = "<div class='toolTipBox' style='padding: 5px; margin-top: 10px; background-color: rgb(224, 236, 255);" +
                    "color: rgb(51, 51, 51); text-decoration: none; margin-bottom: 15px; font-family: Tahoma, Arial;" +
                    "font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal;" +
                    "letter-spacing: normal; line-height: normal; orphans: auto; text-align: start;" +
                    "text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px;" +
                    "-webkit-text-stroke-width: 0px;'>" +
                    "<img align='left' height='16' src='../../resource/images/infoballon.gif' width='20' />Thống" +
                    "kê nội dung các quy tắc vi phạm của &#39;<b>Tiêu đề gửi</b>&#39; chi tiết như bên" +
                    " dưới:</div>" +
                    "<div class='Heading2' style='font-weight: bold; color: rgb(0, 0, 0); height: 16pt;" +
                    "background-color: rgb(237, 236, 236); padding: 4px 4px 4px 10px; background-image: url(../../resource/images/table_bg.gif);" +
                    "font-family: Tahoma, Arial; font-size: 11px; font-style: normal; font-variant: normal;" +
                    "letter-spacing: normal; line-height: normal; orphans: auto; text-align: start;" +
                    "text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px;" +
                    "-webkit-text-stroke-width: 0px;'>" +
                    "<div class='spamRuleBroken_row_rulename' style='float: left; padding: 3px 0px 3px 5px;'>" +
                    "Quy tắc vi phạm</div>" +
                    "<div class='spamRuleBroken_row_rulescore' style='float: right; width: 80px; text-align: right;" +
                    "padding: 3px 15px 3px 5px;'>" +
                    "Điểm</div>" +
                    "&nbsp;</div>" +
                    "<div class='spam_info spamRuleBroken_row' style='padding: 4px 8px; background-color: rgb(249, 249, 249);" +
                   " display: block; clear: both; color: rgb(103, 103, 103); font-family: Tahoma, Arial;" +
                    "font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal;" +
                    "letter-spacing: normal; line-height: normal; orphans: auto; text-align: start;" +
                    "text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px;" +
                    "-webkit-text-stroke-width: 0px;'>";
            #endregion Fisrt
            foreach (DataRow RowItem in spam.Rows)
            {
                key = " " + RowItem["Keyword"].ToString() + " ";
                ItemScore = float.Parse(RowItem["Score"].ToString());
                if (titleData.Contains(key) == true)
                {
                    //Bắt đầu vòng lặp tính điểm tiêu đề
                    ruleContent += "<div class='spam_info spamRuleBroken_row' style='padding: 4px 8px; background-color: rgb(249, 249, 249);" +
                          "display: block; clear: both; color: rgb(103, 103, 103); font-family: Tahoma, Arial;" +
                          "font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal;" +
                          "letter-spacing: normal; line-height: normal; orphans: auto; text-align: start;" +
                          "text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px;" +
                          "-webkit-text-stroke-width: 0px;'>";
                    ruleContent += "<div class='spamRuleBroken_row_rulename' style='float: left; padding: 3px 0px 3px 5px;'>" + "Chứa từ vi phạm '" + key + "'" + "</div>" +
                     "<div class='spamRuleBroken_row_rulescore' style='float: right; width: 80px; text-align: right;" + "padding: 3px 15px 3px 5px;'>" + ItemScore + "</div> </br>";
                    ruleContent += "</div>";
                    totalScoreTitle = totalScoreTitle + ItemScore;
                    // Kết thúc vòng lặp tính điểm tiêu đề
                }
            }

            #region Medium
            ruleContent += "" +
              "<div class='spam_info spamRuleBroken_row' style='padding: 4px 8px; background-color: rgb(249, 249, 249);" +
               "display: block; clear: both; color: rgb(103, 103, 103); font-family: Tahoma, Arial;" +
               "font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal;" +
               "letter-spacing: normal; line-height: normal; orphans: auto; text-align: start;" +
               "text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px;" +
               "-webkit-text-stroke-width: 0px;'>" +
               "<div class='spamRuleBroken_graph' style='border: 1px solid gray; height: 5px; background-color: rgb(238, 238, 238);'>" +
               "<div class='spam_notspam' style='background-color: rgb(0, 255, 0); height: 5px; width: 165.296875px;'>" +
               "<img height='5' src='../../resource/images/1x1.gif' width='1' /></div>" +
               "</div>" +
               "<div style='line-height: 1; margin-bottom: 5px;'>" +
               "<br />" +
               "Nội dung được đánh giá cao nhất<span class ='Apple-converted-space'>&nbsp;</span><span" +
               " style='font-size: 12px; font-weight: bold;'><b>" + totalScoreTitle.ToString() + "</b></span><span class='Apple-converted-space'>&nbsp;</span>trong" +
               " ngưỡng cho phép là 5. Điều này có nghĩa email của bạn sẽ được gửi đến đích, nhưng" +
               "điều này không được bảo đảm tuyệt đối nó chỉ có giá trị tham khảo.</div>" +
            "</div>" +
            "<div class='toolTipBox' style='padding: 5px; margin-top: 10px; background-color: rgb(224, 236, 255);" +
            "color: rgb(51, 51, 51); text-decoration: none; margin-bottom: 15px; font-family: Tahoma, Arial;" +
            "font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal;" +
            "letter-spacing: normal; line-height: normal; orphans: auto; text-align: start;" +
            "text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px;" +
            "-webkit-text-stroke-width: 0px;'>" +
            "<img align='left' height='16' src='../../resource/images/infoballon.gif' width='20' />Thống" +
            " kê nội dung các quy tắc vi phạm của &#39;<b>Nội dung gửi</b>&#39; chi tiết như" +
            " bên dưới:" + "</div>" +
             "<div class='Heading2' style='font-weight: bold; color: rgb(0, 0, 0); height: 16pt;" +
             "background-color: rgb(237, 236, 236); padding: 4px 4px 4px 10px; background-image: url(../../resource/images/table_bg.gif);" +
             "font-family: Tahoma, Arial; font-size: 11px; font-style: normal; font-variant: normal;" +
             "letter-spacing: normal; line-height: normal; orphans: auto; text-align: start;" +
             "text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px;" +
             "-webkit-text-stroke-width: 0px;'>" +
             "<div class='spamRuleBroken_row_rulename' style='float: left; padding: 3px 0px 3px 5px;'>" +
             "Quy tắc vi phạm</div>" +
             "<div class='spamRuleBroken_row_rulescore' style='float: right; width: 80px; text-align: right;" +
             "padding: 3px 15px 3px 5px;'>" +
             "Điểm</div>" +
            "&nbsp;</div>";

            #endregion
            //Đánh giá nội dung
            foreach (DataRow RowItem in spam.Rows)
            {
                key = " " + RowItem["Keyword"].ToString() + " ";
                ItemScore = float.Parse(RowItem["Score"].ToString());
                if (contentData.Contains(key) == true)
                {
                    //Bắt đầu vòng lặp tính điểm tiêu đề
                    ruleContent += "<div class='spam_info spamRuleBroken_row' style='padding: 4px 8px; background-color: rgb(249, 249, 249);" +
                                 "display: block; clear: both; color: rgb(103, 103, 103); font-family: Tahoma, Arial;" +
                                 "font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal;" +
                                 "letter-spacing: normal; line-height: normal; orphans: auto; text-align: start;" +
                                 "text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px;" +
                                 "-webkit-text-stroke-width: 0px;'>";
                    ruleContent += "<div class='spamRuleBroken_row_rulename' style='float: left; padding: 3px 0px 3px 5px;'>" + "Chứa từ vi phạm '" + key + "'" + "</div>" +
                     "<div class='spamRuleBroken_row_rulescore' style='float: right; width: 80px; text-align: right;" + "padding: 3px 15px 3px 5px;'>" + ItemScore + "</div></br>";
                    ruleContent += "</div>";
                    totalScoreContent = totalScoreContent + ItemScore;
                    // Kết thúc vòng lặp tính điểm tiêu đề
                }
            }

            //Kết thúc đánh giá nội dung
            #region End
            ruleContent += "" +
              "<div class='spam_info spamRuleBroken_row' style='padding: 4px 8px; background-color: rgb(249, 249, 249);" +
              "display: block; clear: both; color: rgb(103, 103, 103); font-family: Tahoma, Arial;" +
              "font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal;" +
              "letter-spacing: normal; line-height: normal; orphans: auto; text-align: start;" +
              "text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px;" +
              "-webkit-text-stroke-width: 0px;'>" +
              "<div class='spamRuleBroken_graph' style='border: 1px solid gray; height: 5px; background-color: rgb(238, 238, 238);'>" +
              "<div class='spam_notspam' style='background-color: rgb(0, 255, 0); height: 5px; width: 50%;'>" +
              "<img height='5' src='../../resource/images/1x1.gif' width='1' /></div>" + "</div>" +
               "<div style='line-height: 1; margin-bottom: 5px;'>" + "<br />" +
               "Nội dung được đánh giá cao nhất<span class='Apple-converted-space'>&nbsp;</span><span" +
               " style='font-size: 13px; font-weight: bold;'>" + totalScoreContent.ToString() + "</span><span class='Apple-converted-space'>&nbsp;</span>trong" +
               " ngưỡng cho phép là 5. Điều này có nghĩa email của bạn sẽ được gửi đến đích, nhưng" +
               "điều này không được bảo đảm tuyệt đối nó chỉ có giá trị tham khảo." +
                "</div>" +
            "</div>";
            #endregion
            #endregion
            return ruleContent;
        }
        catch (Exception)
        {
            return null;
        }

    }
    [System.Web.Services.WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string contentUpdate(string content)
    {
        string con = content;
        return null;
    }
}
