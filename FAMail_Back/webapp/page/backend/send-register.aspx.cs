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
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public partial class webapp_page_backend_send_register : System.Web.UI.Page
{
    #region Khai báo biến
    SendContentBUS scBUS = null;
    MailConfigBUS mailConfigBus = null;
    MailGroupBUS mailGroupBus = null;
    CustomerBUS customerBus = null;
    SendRegisterBUS srBUS = null;
    DetailGroupBUS dsgBUS = null;
    SignatureBUS signBus = null;
    Common common = null;
    PartSendBUS psBus = null;
    DataTable group = null;
    DataTable Content = null;
    DataTable SignIn = null;
    SpamRuleBUS spamBUS = null;

    #endregion
    log4net.ILog logs = log4net.LogManager.GetLogger("ErrorRollingLogFileAppender");
    UserLoginDTO userLogin = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        userLogin = getUserLogin();
        if (!IsPostBack)
        {
            try
            {
                LoadMailGroupLists();
                LoadMailConfigLists();
                LoadMailContentList();
                LoadSignatureList();
                drlMailGroup_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                pnError.Visible = true;
                lblError.Text = ex.Message;
            }
        }
    }

    #region Load dữ liệu
    private void LoadSignatureList()
    {
        try
        {

            signBus = new SignatureBUS();
            UserLoginDTO userLogin = getUserLogin();
            DataTable tblSignList = signBus.GetByUserId(userLogin.UserId);
            createTableSign();
            if (tblSignList.Rows.Count > 0)
            {
                DataRow rowE = SignIn.NewRow();
                rowE["Id"] = 0;
                rowE["SignatureName"] = "Chọn nội chữ ký";
                SignIn.Rows.Add(rowE);
                foreach (DataRow RowItem in tblSignList.Rows)
                {
                    rowE = SignIn.NewRow();
                    rowE["Id"] = RowItem["id"];
                    rowE["SignatureName"] = RowItem["SignatureName"];
                    SignIn.Rows.Add(rowE);
                }
                drlSign.DataSource = SignIn;
                drlSign.DataTextField = "SignatureName";
                drlSign.DataValueField = "id";
                drlSign.DataBind();
            }
        }
        catch (Exception)
        {
        }
    }
    private void InitialBUS()
    {
        scBUS = new SendContentBUS();
        mailConfigBus = new MailConfigBUS();
        mailGroupBus = new MailGroupBUS();
        customerBus = new CustomerBUS();
        srBUS = new SendRegisterBUS();
        common = new Common();
        dsgBUS = new DetailGroupBUS();
    }
    private void LoadMailConfigLists()
    {
        mailConfigBus = new MailConfigBUS();
        DataTable dtMailConfig = new DataTable();
        UserLoginDTO userLogin = getUserLogin();
        if (userLogin != null)
        {
            if (userLogin.DepartmentId == 1)
            {
                dtMailConfig = mailConfigBus.GetAll();
            }
            else
            {
                dtMailConfig = mailConfigBus.GetByUserId(userLogin.UserId);
            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
        drlMailConfig.Items.Clear();
        drlMailConfig.DataSource = dtMailConfig.DefaultView;
        drlMailConfig.DataTextField = "Email";
        drlMailConfig.DataValueField = "Id";
        drlMailConfig.DataBind();
    }
    protected void LoadMailContentList()
    {
        InitialBUS();
        createTableContent();
        UserLoginDTO userLogin = getUserLogin();
        DataTable tblSendContent = new DataTable();
        if (userLogin.DepartmentId == 1)
        {
            tblSendContent = scBUS.GetAll();
        }
        else
        {
            tblSendContent = scBUS.GetAll(userLogin.UserId);
        }

        if (tblSendContent.Rows.Count > 0)
        {
            DataRow rowE = Content.NewRow();
            rowE["Id"] = 0;
            rowE["Subject"] = "Chọn nội dung";
            Content.Rows.Add(rowE);
            foreach (DataRow rowItem in tblSendContent.Rows)
            {
                rowE = Content.NewRow();
                rowE["Id"] = rowItem["Id"];
                rowE["Subject"] = rowItem["Subject"];
                Content.Rows.Add(rowE);
            }
            drlContent.Items.Clear();
            drlContent.DataSource = Content.DefaultView;
            drlContent.DataTextField = "Subject";
            drlContent.DataValueField = "Id";
            drlContent.DataBind();
            object id = Request.QueryString["SendContenID"];
            if (id + "" != "")
            {
                drlContent.Text = id + "";
                DataTable T = scBUS.GetByID(Convert.ToInt32(id));
                if (T != null && T.Rows.Count > 0)
                {
                    txtBody.Text = T.Rows[0]["body"] + "";
                    txtSubject.Text = T.Rows[0]["subject"] + "";
                }
            }


        }
    }
    private void LoadMailGroupLists()
    {
        mailGroupBus = new MailGroupBUS();
        createTableMail();
        DataTable dtMailGroup = new DataTable();
        UserLoginDTO userLogin = getUserLogin();
        if (userLogin.DepartmentId == 1)
        {
            dtMailGroup = mailGroupBus.GetAll();
        }
        if (userLogin.DepartmentId == 3)
        {
            dtMailGroup = mailGroupBus.GetAllAssignTo(userLogin.UserId);
        }
        if (userLogin.DepartmentId == 2)
        {
            dtMailGroup = mailGroupBus.GetAll(userLogin.UserId);
        }

        if (dtMailGroup.Rows.Count > 0)
        {
            DataRow rowE = group.NewRow();
            if (userLogin.DepartmentId == 1)
            {

                rowE["Id"] = -3;
                rowE["Name"] = "Tất cả";
                group.Rows.Add(rowE);

            }
            if (userLogin.DepartmentId == 2)
            {

                rowE["Id"] = -3;
                rowE["Name"] = "Tất cả";
                group.Rows.Add(rowE);

            }
            if (userLogin.DepartmentId == 3)
            {

                rowE["Id"] = -3;
                rowE["Name"] = "Tất cả";
                group.Rows.Add(rowE);

            }
            foreach (DataRow rowItem in dtMailGroup.Rows)
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
    private void createTableSign()
    {
        SignIn = new DataTable("SignIn");
        DataColumn Id = new DataColumn("Id");
        Id.DataType = System.Type.GetType("System.Int32");
        DataColumn SignatureName = new DataColumn("SignatureName");
        DataColumn[] key = { Id };
        SignIn.Columns.Add(Id);
        SignIn.Columns.Add(SignatureName);
        SignIn.PrimaryKey = key;
    }
    private void createTableContent()
    {
        Content = new DataTable("Content");
        DataColumn Id = new DataColumn("Id");
        Id.DataType = System.Type.GetType("System.Int32");
        DataColumn Subject = new DataColumn("Subject");
        DataColumn[] key = { Id };
        Content.Columns.Add(Id);
        Content.Columns.Add(Subject);
        Content.PrimaryKey = key;
    }
    #endregion
    #region Gửi từng phần
    //private void checkAndInsertPartSend()
    //{
    //    try
    //    {
    //        if (chkPartSend.Checked)
    //        {
    //            PartSendDTO psDto = new PartSendDTO();
    //            PartSendBUS psBus = new PartSendBUS();
    //            int groupId = int.Parse(drlMailGroup.SelectedValue);
    //            int userId = getUserLogin().UserId;
    //            string contentId = drlContent.SelectedValue;

    //            //nếu group đang ở trong chiến dịch gửi từng phần
    //            DataTable tblPart = psBus.GetByUserIdAndGroupId(userId, groupId);
    //            if (tblPart.Rows.Count > 0)
    //            {
    //                psDto.UserId = getUserLogin().UserId;
    //                psDto.GroupId = groupId;
    //                psDto.hasContentSend = tblPart.Rows[0]["hasContentSend"].ToString() + "," + contentId;
    //                psDto.settingFirst = bool.Parse(tblPart.Rows[0]["settingFirst"].ToString());
    //                psBus.tblPartSend_update(psDto);
    //            }
    //            else //chiến dịch mới
    //            {
    //                psDto.UserId = getUserLogin().UserId;
    //                psDto.GroupId = groupId;
    //                psDto.hasContentSend = contentId;
    //                psDto.settingFirst = true;
    //                psBus.tblPartSend_insert(psDto);
    //            }

    //        }
    //    }
    //    catch (Exception)
    //    {
    //    }


    //}
    //protected void drlContent_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    scBUS = new SendContentBUS();
    //    int contentId = int.Parse(drlContent.SelectedValue.ToString());
    //    DataTable tblContent = scBUS.GetByID(contentId);
    //    if (tblContent.Rows.Count > 0)
    //    {
    //        lblContentDetail.Text = tblContent.Rows[0]["Body"].ToString();
    //        hplViewContentDetail.NavigateUrl = "content-detail.aspx?id=" + contentId;
    //    }
    //}
    protected void lbtResetPartSend_Click(object sender, EventArgs e)
    {
        try
        {
            PartSendBUS psBus = new PartSendBUS();
            int groupId = int.Parse(drlMailGroup.SelectedValue);
            ConnectionData.OpenMyConnection();
            psBus.tblPartSend_Delete(getUserLogin().UserId, groupId);
            ConnectionData.CloseMyConnection();
            drlMailGroup_SelectedIndexChanged(sender, e);
        }
        catch (Exception)
        {
        }


    }
    #endregion
    private UserLoginDTO getUserLogin()
    {
        if (Session["us-login"] != null)
        {
            return (UserLoginDTO)Session["us-login"];
        }
        return null;
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("list-content-mail.aspx");
    }
    protected SendRegisterDTO getSendRegister()
    {
        try
        {
            UserLoginDTO userLogin = getUserLogin();
            string fromMail = drlMailConfig.SelectedValue;
            string groupTo = drlMailGroup.SelectedValue;
            string startDate = txtStartDate.Text;
            int contentId = int.Parse(drlContent.SelectedValue);
            SendRegisterDTO srDto = new SendRegisterDTO()
            {
                AccountId = userLogin.UserId.ToString(),
                ErrorType = 0,
                SendContentId = contentId,
                MailConfigID = int.Parse(fromMail),
                GroupTo = int.Parse(groupTo),
                SendType = 1,// Loại gửi bình thường
                EndDate = DateTime.Now,
                Status = 0 /*chua gui.*/
            };
            return srDto;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string message = "";// checkLimitSendMail();
            if (message != "")
            {
                pnError.Visible = true;
                lblError.Text = message;
            }
            else
            {
                drlMailGroup_SelectedIndexChanged(sender, e);
                DateTime timeStart = DateTime.Now.AddMinutes(1);
                if (txtStartDate.Text.ToString() != "" & this.chkNow.Checked == false)
                {
                    timeStart = convertStringToDate(txtStartDate.Text);
                }

                // Cap nhat thong tin so luong mail da gui cho user.
                infoUpdate();

                //checkAndInsertPartSend();
                Insert(timeStart);
            }
        }
        catch (Exception ex)
        {
            pnError.Visible = true;
            lblError.Text = "Có lỗi trong quá trình đăng ký gửi mail!";
            logs.Error(userLogin.Username + "-Send_Register-Send", ex);
        }
    }
    private void infoUpdate()
    {
        // Cap nhat so luong mail da gui.
        UserLoginBUS ulBus = new UserLoginBUS();
        int currentSend = int.Parse(hdfCountCustomer.Value);
        int hasSend = getUserLogin().hasSendMail;
        int currentHasSend = currentSend + hasSend;
        ulBus.tblUpdateSendMail(getUserLogin().UserId, currentHasSend);

        // Cap nhat session 
        UserLoginDTO ulDto = getUserLogin();
        ulDto.hasSendMail = currentHasSend;
        Session["us-login"] = ulDto;
    }
    private string checkLimitSendMail()
    {
        string message = "";
        if (getUserLogin().DepartmentId != 1)
        {
            RoleDetailBUS rdBus = new RoleDetailBUS();
            DataTable register = new ClientRegisterBUS().GetByUserId(userLogin.UserId);//rdBus.GetByDepartmentIdAndRole(-1, getUserLogin().DepartmentId);
            if (userLogin.DepartmentId == 3)
                register = new ClientRegisterBUS().GetBySubUserId(userLogin.UserId);
            if (register.Rows.Count > 0)
            {
                int hasSendMail = getUserLogin().hasSendMail;
                int limitMailSend = int.Parse(register.Rows[0]["emailCount"].ToString());
                DateTime limitToDate = DateTime.Parse(register.Rows[0]["to"].ToString());
                int currentSend = int.Parse(hdfCountCustomer.Value);
                if (DateTime.Now >= limitToDate)
                {
                    message = "Thời gian gửi mail của bạn đã hết hạn ngày " + limitToDate.ToShortDateString();
                    message += "<br/> Vui lòng liên hệ với administrator để gia hạn tiếp thời gian gửi !";
                }
                else if (limitMailSend - hasSendMail < currentSend)
                {
                    // Thông báo lỗi
                    message = "Vượt quá hạng ngạch cho phép gửi, số lượng còn lại là: " + (limitMailSend - hasSendMail).ToString();
                }
            }
        }
        return message;
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
    protected void drlMailGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (this.drlMailGroup.SelectedValue != null)
            {
                DataTable tblCustomer = new DataTable();
                dsgBUS = new DetailGroupBUS();
                psBus = new PartSendBUS();
                int groupID = int.Parse(this.drlMailGroup.SelectedValue.ToString());
                int numbermail = 0;
                if (groupID == -3)
                {
                    customerBus = new CustomerBUS();
                    //tblCustomer = dsgBUS.GetAll();
                    DataTable dtEmail = customerBus.GetCountCustomerCreatedMail(userLogin.UserId);
                    numbermail = int.Parse(dtEmail.Rows[0]["numberMail"].ToString());
                }
                else
                {
                    tblCustomer = dsgBUS.GetByID(groupID);
                    numbermail = tblCustomer.Rows.Count;
                }

                //string countCustomer = tblCustomer.Rows.Count.ToString();
                lblCountCustomer.Text = "Hiện có " + numbermail + " khách hàng trong nhóm này !";
                hdfCountCustomer.Value = numbermail + "";

                // Đếm số lượng mail đã gửi trong group trong chiến dịch gửi từng phần
                //DataTable tblPartSend = psBus.GetByUserIdAndGroupId(getUserLogin().UserId, groupID);
                //if (tblPartSend.Rows.Count > 0)
                //{
                //    string strContentList = tblPartSend.Rows[0]["hasContentSend"].ToString();
                //    string[] arrayContentList = strContentList.Split(',');
                //    hplCountPartSend.Text = arrayContentList.Length + " nội dung";
                //    hplCountPartSend.NavigateUrl = "view-content-send.aspx?groupId=" + groupID;
                //}

            }
        }
        catch (Exception ex)
        {
            lblCountCustomer.Text = ex.Message;
        }
    }
    protected int calcTimeForGroup(int groupid)
    {
        dsgBUS = new DetailGroupBUS();
        common = new Common();
        DataTable tblCustomer = dsgBUS.GetByID(groupid);
        int calcMinute = 0;
        if (tblCustomer.Rows.Count > 0)
        {
            calcMinute = common.calculatorMinuteQuantityEmail(tblCustomer.Rows.Count) + 1;
        }
        return calcMinute;
    }
    protected void btnSendNow_Click(object sender, EventArgs e)
    {
        InitialBUS();
        DateTime currentTime = DateTime.Now.AddMinutes(1);
        try
        {
            Insert(currentTime);
        }
        catch (Exception ex)
        {
        }

    }
    private void VisibleAll()
    {
        pnError.Visible = false;
        pnSuccess.Visible = false;
    }
    private void Insert(DateTime startDate)
    {
        srBUS = new SendRegisterBUS();
        scBUS = new SendContentBUS();
        SendContentDTO scDTO = new SendContentDTO();
        scDTO = getContentDTO();

        //Lấy thời gian của người dùng Thiết lập
        DateTime timeEnd = startDate.AddMinutes(calcTimeForGroup(int.Parse(drlMailGroup.SelectedValue)) + 1);
        DateTime timeStart = startDate;
        int GroupID = 0;
        DataTable tableFirt = new DataTable();
        tableFirt = srBUS.GetByTimeCheck(startDate, 0);// 0 là chưa gửi.
        if (tableFirt.Rows.Count > 0)
        {
            GroupID = int.Parse(tableFirt.Rows[0]["GroupTo"].ToString());
            timeStart = DateTime.Parse(tableFirt.Rows[0]["StartDate"].ToString()).AddMinutes(calcTimeForGroup(GroupID) + 1);

            if (timeStart < startDate)
            {
                timeStart = startDate;
            }
            else
            {
            }
            timeEnd = timeStart.AddMinutes(calcTimeForGroup(int.Parse(drlMailGroup.SelectedValue)) + 1);
        }
        else
        {
        }
    SelectTime: ;
        tableFirt = srBUS.GetByTimeNext(timeStart, timeEnd, 0);
        if (tableFirt.Rows.Count > 0)
        {
            GroupID = int.Parse(tableFirt.Rows[0]["GroupTo"].ToString());
            timeStart = DateTime.Parse(tableFirt.Rows[0]["StartDate"].ToString()).AddMinutes(calcTimeForGroup(GroupID) + 1);
            timeEnd = timeStart.AddMinutes(calcTimeForGroup(int.Parse(drlMailGroup.SelectedValue)) + 1);
            goto SelectTime;
        }
        else
        {
            int contentID;
            //if (hdfContentID.Value == "")
            //{
            contentID = scBUS.tblSendContent_insert(scDTO);
            //}
            //else
            //{
            //    contentID = int.Parse(hdfContentID.Value.ToString());
            //    scDTO.Id = contentID;
            //    scBUS.tblSendContent_Update(scDTO);
            //}
            SendRegisterDTO srDto = getSendRegister();
            srDto.SendContentId = contentID;
            srDto.StartDate = timeStart;
            srBUS.tblSendRegister_insert(srDto);
        }

        Response.Redirect("wait-send.aspx");

    }
    private SendContentDTO getContentDTO()
    {
        SendContentDTO scDTO = new SendContentDTO();
        string err = ValidateNull();
        if (err == "")
        {
            scDTO.Body = txtBody.Text;
            scDTO.Subject = txtSubject.Text;
            scDTO.CreateDate = DateTime.Now;
            scDTO.userId = getUserLogin().UserId;
        }
        else
        {
            pnSuccess.Visible = false;
            pnError.Visible = true;
            lblError.Text = err;
        }
        return scDTO;
    }
    private string ValidateNull()
    {
        string err = "";
        if (txtSubject.Text == "")
        {
            err = "Bạn chưa nhập tiêu đề Email";
        }
        else if (txtBody.Text == "")
        {
            err = "Bạn chưa nhập nội dung Email";
        }
        if (drlMailConfig.Text == "")
        {
            err = "Bạn chưa có Mail gửi";
        }
        return err;
    }
    #region Hàm xử lý javascript
    [System.Web.Services.WebMethod]
    public static string getContentTemplate(string contentId)
    {
        SendContentBUS scBUS = new SendContentBUS();
        int id = int.Parse(contentId);
        DataTable tblContent = scBUS.GetByID(id);
        if (tblContent.Rows.Count > 0)
        {
            return tblContent.Rows[0]["Body"].ToString();
        }
        return null;
    }
    [System.Web.Services.WebMethod]
    public static string getJsonSpam(string contentId)
    {
        // Lay noi dung cho xu ly spam.
        SendContentBUS scBUS = new SendContentBUS();
        int id = int.Parse(contentId);
        string contentDetail = null;
        DataTable tblContent = scBUS.GetByID(id);
        if (tblContent.Rows.Count > 0)
        {
            contentDetail = tblContent.Rows[0]["Body"].ToString();
        }

        // Tien hanh check spam
        SpamRuleBUS spamBUS = new SpamRuleBUS();
        DataTable spam = spamBUS.GetAll();

        List<SpamRuleDTO> listSpam = new List<SpamRuleDTO>();
        for (int i = 0; i < spam.Rows.Count; i++)
        {
            SpamRuleDTO spamDto = new SpamRuleDTO();
            spamDto.Keyword = spam.Rows[i]["Keyword"].ToString();
            spamDto.SameWord = spam.Rows[i]["SameWord"].ToString();
            spamDto.Score = float.Parse(spam.Rows[i]["Score"].ToString());
            listSpam.Add(spamDto);
        }

        var json = new JavaScriptSerializer().Serialize(listSpam);
        return json;

    }

    [System.Web.Services.WebMethod]
    public static string getSign(string SignId)
    {
        try
        {
            SignatureBUS signBus = new SignatureBUS();
            int id = int.Parse(SignId);
            DataTable tblSign = signBus.GetById(id);
            if (tblSign.Rows.Count > 0)
            {
                return tblSign.Rows[0]["SignatureContent"].ToString();
            }
            return null;
        }
        catch (Exception)
        {
            throw;
        }
    }
    [System.Web.Services.WebMethod]
    public static string getJsonList(string content)
    {
        SpamRuleBUS spamBUS = new SpamRuleBUS();
        DataTable spam = spamBUS.GetAll();

        List<SpamRuleDTO> listSpam = new List<SpamRuleDTO>();
        for (int i = 0; i < spam.Rows.Count; i++)
        {
            SpamRuleDTO spamDto = new SpamRuleDTO();
            spamDto.Keyword = spam.Rows[i]["Keyword"].ToString();
            spamDto.SameWord = spam.Rows[i]["SameWord"].ToString();
            spamDto.Score = float.Parse(spam.Rows[i]["Score"].ToString());
            listSpam.Add(spamDto);
        }

        var json = new JavaScriptSerializer().Serialize(listSpam);
        return json;
    }

    [System.Web.Services.WebMethod]
    public static string Spam(string title, string content)
    {
        try
        {
            SpamRuleBUS spamBUS = new SpamRuleBUS();
            DataTable spam = spamBUS.GetAll();
            float totalScoreTitle = 0;
            float totalScoreContent = 0;
            string ruleContent = "";
            float ItemScore = 0;
            string key = "";
            string titleData = title;
            string contentData = HttpUtility.UrlDecode(content);
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
    #endregion
    protected void btnPreview_Click(object sender, EventArgs e)
    {
        string ContentMail = this.txtBody.Text;
        Session["Content"] = ContentMail;
        Response.Redirect("PreviewContent.aspx");
    }
}
