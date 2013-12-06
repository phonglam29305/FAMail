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

public partial class webapp_page_backend_sendVIP : System.Web.UI.Page
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
        CountBuyBUS countBUS = null;
        DataTable group = null;
    bool Now;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //try
            //{
                LoadMailGroupLists();
                LoadMailConfigLists();
                LoadMailContentList();
                LoadSignatureList();
                drlMailGroup_SelectedIndexChanged(sender, e);
                //drlContent_SelectedIndexChanged(sender, e);
                Now = false;
            //}
            //catch (Exception ex)
            //{
            //    pnError.Visible = true;
            //    lblError.Text = ex.Message;
            //}
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
            if (tblSignList.Rows.Count > 0)
            {
                drlSign.DataSource = tblSignList;
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
            drlContent.Items.Clear();
            drlContent.DataSource = tblSendContent.DefaultView;
            drlContent.DataTextField = "Subject";
            drlContent.DataValueField = "Id";
            drlContent.DataBind();
        }
    }
    private void LoadMailGroupLists()
    {
        countBUS = new CountBuyBUS();
        DataTable MailGroup = countBUS.GetGroup();
        if (MailGroup.Rows.Count > 0)
        {
            createTableMail();
            DataRow rowE = group.NewRow();
            rowE["Id"] = -1;
            rowE["Name"] = "Nhóm mua lần đầu";
            group.Rows.Add(rowE);
            DataRow rowE2 = group.NewRow();
            rowE2["Id"] = -2;
            rowE2["Name"] = "Nhóm mua nhiều lần";
            group.Rows.Add(rowE2);
            foreach (DataRow rowItem in MailGroup.Rows)
            {
                rowE = group.NewRow();
                rowE["Id"] = rowItem["CategoryID"];
                rowE["Name"] = rowItem["Title"];
                group.Rows.Add(rowE);
            }
            this.drlMailGroup.DataSource = group;
            this.drlMailGroup.DataTextField = "Name";
            this.drlMailGroup.DataValueField = "Id";
            this.drlMailGroup.DataBind();
        }

      
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
            SendRegisterDTO srDto = new SendRegisterDTO() { 
                AccountId = userLogin.UserId.ToString(),
                ErrorType = 0,
                SendContentId = contentId,
                MailConfigID = int.Parse(fromMail), 
                GroupTo = int.Parse(groupTo), 
                SendType=2,//Loại chăm sóc khách hàng
                EndDate = DateTime.Now,
                Status = 0 /*chua gui.*/ };
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
            DateTime timeStart = DateTime.Now.AddMinutes(1);
            if (txtStartDate.Text.ToString() != "")
            {
                timeStart = convertStringToDate(txtStartDate.Text);
            }            
            //checkAndInsertPartSend();
            Insert(timeStart);
            
        }
        catch (Exception ex)
        {
        }
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
            countBUS = new CountBuyBUS();
            
            int categoryID = int.Parse(this.drlMailGroup.SelectedValue.ToString());
            DataTable tblCustomer = new DataTable();
            if (categoryID == -1)
            {
                customerBus = new CustomerBUS();
                tblCustomer = customerBus.GetByCountBuy(1);                
            }
            else if (categoryID == -2)
            {
                customerBus = new CustomerBUS();
                tblCustomer = customerBus.GetByCountBuy(2);
            }
            else
            {
                tblCustomer = countBUS.GetByCategoryID(categoryID);
            }
            
            lblCountCustomer.Text = "Hiện có " + tblCustomer.Rows.Count + " khách hàng trong nhóm này !";          
            
        }
        catch (Exception)
        {
            lblCountCustomer.Text = "Lỗi chọn nhóm người nhận";
        }
    }
    protected int calcTimeForGroup(int groupid)
    {
        common = new Common();
        dsgBUS = new DetailGroupBUS();
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
        ConnectionData.OpenMyConnection();
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
            if (hdfContentID.Value == "")
            {
                contentID = scBUS.tblSendContent_insert(scDTO);
            }
            else
            {
                contentID = int.Parse(hdfContentID.Value.ToString());
            }
            SendRegisterDTO srDto = getSendRegister();
            srDto.SendContentId = contentID;
            srDto.StartDate = timeStart;
            srBUS.tblSendRegister_insert(srDto);
        }
        ConnectionData.CloseMyConnection();
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
    #endregion
}
