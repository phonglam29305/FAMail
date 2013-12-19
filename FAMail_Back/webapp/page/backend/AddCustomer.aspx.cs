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
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Collections.Specialized;
using System.Text;
using log4net;

public partial class webapp_page_backend_AddCustomer : System.Web.UI.Page
{


    private int limitCreateCustomer;
    private int hasCreate;

    DataTable table = null;
    CustomerBUS ctBUS = new CustomerBUS();
    MailGroupBUS mailGroupBus = new MailGroupBUS();
    DetailGroupBUS dgBUS = new DetailGroupBUS();
    static string fileName;
    EmailVerifier verify;
    log4net.ILog logMgr = LogManager.GetLogger("ErrorRollingLogFileAppender");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                loadData();
            }
            catch (Exception ex)
            {
                pnError.Visible = true;
                lblError.Text = "Hệ thống đang chờ quá lâu, vui lòng tải lại trang !";
            }
        }

    }

    private void loadData()
    {
        try
        {
            InitBUS();
           
            pnSelectGroup.Visible = false;
            LoadCustomer();
            LoadMailGroupLists();
        }
        catch (Exception ex)
        {
            logMgr.Error(Session["us-login"] + " - loadData", ex);
           
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
    private void LoadCustomer()
    {
        try
        {
            string CustomerId = Request.QueryString["CustomerId"].ToString();
            this.hdfCustomerId.Value = CustomerId + "";
            if (CustomerId != null)
            {
                int ID = int.Parse(CustomerId);
                this.CustomerID.Value = ID.ToString();
                DataTable dt = ctBUS.GetByID(ID);
               // int AssignTo = int.Parse(dt.Rows[0]["AssignTo"].ToString());
               // DataTable dtGroup = ctBUS.GetByGroupID(AssignTo);
                if (dt.Rows.Count > 0)
                {
                    //tamhm edit lai
                    //tam eiditthis.txtAddress.Text = ctBUS.GetByID(ID).Rows[0]["Address"].ToString();
                    // this.txtHomePhone.Text = ctBUS.GetByID(ID).Rows[0]["SecondPhone"].ToString();
                    // this.txtPhone.Text = ctBUS.GetByID(ID).Rows[0]["Phone"].ToString();
                    // this.txtBirthday.Text = String.Format("{0:dd/MM/yyyy }", DateTime.Parse(ctBUS.GetByID(ID).Rows[0]["BirthDay"].ToString()));
                    // this.txtEmail.Text = ctBUS.GetByID(ID).Rows[0]["Email"].ToString();
                    //  this.txtName.Text = ctBUS.GetByID(ID).Rows[0]["Name"].ToString();
                    //  this.drlGroup.SelectedValue = ctBUS.GetByID(ID).Rows[0]["GroupId"].ToString();
                    //  this.drlGender.SelectedValue = ctBUS.GetByID(ID).Rows[0]["Gender"].ToString();

                    this.txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    this.txtHomePhone.Text = dt.Rows[0]["SecondPhone"].ToString();
                    this.txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                    this.txtBirthday.Text = String.Format("{0:dd/MM/yyyy }", DateTime.Parse(dt.Rows[0]["BirthDay"].ToString()));
                    this.txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    this.txtName.Text = dt.Rows[0]["Name"].ToString();
                    this.drlGroup.SelectedValue = dt.Rows[0]["AssignTo"].ToString();
                    this.drlGender.SelectedValue = dt.Rows[0]["Gender"].ToString();

                }
            }
        }
        catch (Exception ex)
        {
            logMgr.Error(Session["us-login"] + " - LoadCustomer", ex);
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
        if (getUserLogin().DepartmentId == 2)
        {
            dtMailGroup = mailGroupBus.GetAllNew(getUserLogin().UserId);
        }
        if (getUserLogin().DepartmentId == 3)
        {
            dtMailGroup = mailGroupBus.GetAllNewDepart3(getUserLogin().UserId);
        }

        if (dtMailGroup.Rows.Count > 0)
        {
            drlMailGroup.Items.Clear();
            drlMailGroup.DataSource = dtMailGroup.DefaultView;
            drlMailGroup.DataTextField = "Name";
            drlMailGroup.DataValueField = "Id";
            drlMailGroup.DataBind();
            drlGroup.Items.Clear();
            drlGroup.DataSource = dtMailGroup.DefaultView;
            drlGroup.DataTextField = "Name";
            drlGroup.DataValueField = "Id";
            drlGroup.DataBind();
            pnSelectGroup.Visible = true;
        }
        else
        {
            pnSelectGroup.Visible = false;
        }
        }
        catch (Exception ex)
        {
            logMgr.Error(Session["us-login"] + " - LoadMailGroupLists", ex);
        }
    }
    private void InitBUS()
    {
        ctBUS = new CustomerBUS();
        mailGroupBus = new MailGroupBUS();
        dgBUS = new DetailGroupBUS();
    }
    protected void btnReadExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Visible(false);
            Common cm = new Common();
            InitBUS();
            table = new DataTable();
            string excelContent = "application/vnd.ms-excel";
            string excelContent2010 = "application/openxmlformats-officedocument-spreadsheetml.sheet";
            if (fileExcel.HasFile)
            {

                if (fileExcel.PostedFile.ContentType != excelContent && fileExcel.PostedFile.ContentType != excelContent2010)
                {
                    Visible(false);
                    pnError.Visible = true;
                    lblError.Text = "Vui lòng chọn file Excel";
                }
                else
                {
                    fileName = "~/database/" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + fileExcel.FileName;
                    string path = string.Concat(Server.MapPath(fileName));
                    fileExcel.SaveAs(path);
                    table = cm.ReadExcelContents(path);
                    if (table.Rows.Count < 1000)
                    {
                        string message = checkCreateCustomer(table.Rows.Count);
                        if (message != "")
                        {
                            this.dtlCustomer.DataSource = table;
                            this.dtlCustomer.DataBind();
                            LoadMailGroupLists();
                        }
                        else
                        {
                            Visible(false);
                            pnError.Visible = true;
                            lblError.Text = message;
                        }
                    }
                    else
                    {
                        Visible(false);
                        pnError.Visible = true;
                        lblError.Text = "Số lương dữ liệu quá lớn ! Vui lòng chọn file bé hơn < 1000 khách hàng";
                    }

                }

            }
            else
            {
                Visible(false);
                pnError.Visible = true;
                lblError.Text = "Vui lòng chọn file";
            }
        }
        catch (Exception ex)
        {

            Visible(false);
            pnError.Visible = true;
            lblError.Text = "Vui lòng kiểm tra lại định dạng file, hoặc file của bạn đang được sử dụng <br/>" + ex.ToString();
            logMgr.Error(Session["us-login"] + " - btnReadExcel_Click", ex);
        }
    }
    private void Visible(bool p)
    {
        pnError.Visible = p;
        pnSuccess.Visible = p;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        CustomerDTO ctDTO = new CustomerDTO();
        int groupID = int.Parse(drlMailGroup.SelectedValue.ToString());
        int CustomerID = 0;
        int count = 0;
        int err = 0;
        try
        {
            for (int i = 0; i < dtlCustomer.Items.Count; i++)
            {
                DataListItem item = dtlCustomer.Items[i];
                CheckBox chkXoa = (CheckBox)item.FindControl("chkCheck");
                Label lblName = (Label)item.FindControl("lblName");
                Label lblGender = (Label)item.FindControl("lblGender");
                Label lblBirthDay = (Label)item.FindControl("lblBirthDay");
                Label lblEmail = (Label)item.FindControl("lblEmail");
                Label lblPhone = (Label)item.FindControl("lblPhone");
                Label lblAddr = (Label)item.FindControl("lblAddr");
                InitBUS();
                if (chkXoa.Checked == true)
                {
                    try
                    {
                        ConnectionData.OpenMyConnection();
                        ctDTO.Name = (lblName.Text == null || lblName.Text == "") ? "Không có" : lblName.Text;
                        ctDTO.Email = lblEmail.Text;
                        ctDTO.BirthDay = (lblBirthDay.Text == null || lblBirthDay.Text == "") ? DateTime.Now : DateTime.Parse(lblBirthDay.Text);
                        ctDTO.Gender = (lblGender.Text == null || lblGender.Text == "") ? "Không có" : lblGender.Text;
                        ctDTO.Phone = (lblPhone.Text == null || lblPhone.Text == "") ? "Không có" : lblPhone.Text;
                        ctDTO.Address = (lblAddr.Text == null || lblAddr.Text == "") ? "Không có" : lblAddr.Text;
                        ctDTO.City = "";
                        ctDTO.Company = "";
                        ctDTO.Country = "";
                        ctDTO.Province = "";
                        ctDTO.Fax = "";
                        ctDTO.SecondPhone = "";
                        ctDTO.Type = "";
                        ctDTO.UserID = getUserLogin().UserId;
                        ctDTO.createBy = getUserLogin().UserId;
                        count++;

                        DataTable checkExistsMail = ctBUS.GetByEmail(lblEmail.Text, getUserLogin().UserId);
                        if (checkExistsMail.Rows.Count > 0)
                        {
                            CustomerID = int.Parse(checkExistsMail.Rows[0]["Id"].ToString());
                        }
                        else
                        {

                            CustomerID = ctBUS.tblCustomer_insert(ctDTO);

                        }

                        if (dgBUS.GetByID(groupID, CustomerID).Rows.Count > 0)
                        {
                            count--;
                            err++;
                        }
                        else
                        {
                            DetailGroupDTO dgDTO = new DetailGroupDTO();
                            dgDTO.GroupID = groupID;
                            dgDTO.CustomerID = CustomerID;
                            dgDTO.CountReceivedMail = 0;
                            dgDTO.LastReceivedMail = DateTime.Now;
                            dgBUS.tblDetailGroup_insert(dgDTO);
                        }
                        ConnectionData.OpenMyConnection();
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }
            }
            Visible(false);
            pnSuccess.Visible = true;
            lblSuccess.Text = "- Bạn đã thêm thành công " + count + " khách hàng vào nhóm: " + drlMailGroup.SelectedItem.ToString() + " </br> - Trùng :" + err.ToString() + " khách hàng.";

            // Update limit send and create customer.
            updateLimitSendAndCreate(count, 0);
        }
        catch (Exception ex)
        {
            logMgr.Error(Session["us-login"] + " - btnSave_Click", ex);
        }

    }
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)sender;
        if (chkAll != null)
        {
            for (int i = 0; i < dtlCustomer.Items.Count; i++)
            {
                DataListItem item = dtlCustomer.Items[i];
                CheckBox chk = (CheckBox)item.FindControl("chkCheck");
                chk.Checked = chkAll.Checked;
            }
        }
    }
    public bool VerifyEmail(string emailVerify)
    {
        using (WebClient webclient = new WebClient())
        {
            string url = "http://verify-email.org/";
            NameValueCollection formData = new NameValueCollection();
            formData["check"] = emailVerify;
            byte[] responseBytes = webclient.UploadValues(url, "POST", formData);
            string response = Encoding.ASCII.GetString(responseBytes);
            if (response.Contains("Result: Ok"))
            {
                return true;
            }
            return false;
        }
    }


    private string checkInputCustomer()
    {

        //verify = new EmailVerifier(true);
        string message = "";
        if (txtName.Text == "")
        {
            message = "Bạn chưa nhập tên khách hàng!";
            this.txtName.Focus();
        }
        else if (txtEmail.Text == "")
        {
            message = "Bạn chưa nhập Email khách hàng!";
            this.txtEmail.Focus();
        }
        else if (IsValidMail(txtEmail.Text.ToString()) == false)
        {
            message = "Bạn nhập không đúng định dạng Email!";
            this.txtEmail.Focus();
        }
        //else if (verify.CheckExists(txtEmail.Text) == false)
        //{
        //    message = "Địa chỉ mail không tồn tại";
        //    this.txtEmail.Focus();
        //}
        else
        {
            message = checkCreateCustomer(1);
        }
        return message;
    }

    protected string checkCreateCustomer(int create)
    {
        string resultMessage = "";
        // Kiem tra hang ngach cho phep tao khach hang.
        if (getUserLogin().DepartmentId != 1) // Khong kiem tra voi tai khoan admin.
        {
            RoleDetailBUS rdBus = new RoleDetailBUS();
            DataTable dtRoleDetail = rdBus.GetByDepartmentIdAndRole(-1, getUserLogin().DepartmentId);
            if (dtRoleDetail.Rows.Count > 0)
            {
                limitCreateCustomer = int.Parse(dtRoleDetail.Rows[0]["limitCreateCustomer"].ToString());
                hasCreate = Common.countHasCreateMailByUserId(getUserLogin().UserId);
                if (hasCreate + create > limitCreateCustomer)
                {
                    resultMessage = "Vượt quá hạng ngạch tạo khách hàng.";
                    resultMessage += "<br/>- Đã tạo: " + hasCreate;
                    resultMessage += "<br/>- Giới hạn: " + limitCreateCustomer;
                }
            }
        }
        return resultMessage;
    }

    protected void updateLimitSendAndCreate(int hasCreatedCustomer, int countSend)
    {
        UserLoginDTO userLogin = getUserLogin();
        userLogin.hasCreatedCustomer = userLogin.hasCreatedCustomer + hasCreatedCustomer;
        userLogin.hasSendMail = userLogin.hasSendMail + countSend;
        Session["us-login"] = userLogin;

        // Update to DB
        UserLoginBUS ulBus = new UserLoginBUS();
        ulBus.tblUpdateSendMail(userLogin.UserId, userLogin.hasSendMail);

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            InitBUS();
            Visible(false);
            int GroupID = int.Parse(drlGroup.SelectedValue.ToString());
            int CustomerID = 0;
            string message = checkInputCustomer();
            if (message != "")
            {
                pnError.Visible = true;
                lblError.Text = message;
            }
            else
            {
                ConnectionData.OpenMyConnection();
                CustomerDTO ctDTO = new CustomerDTO();
                ctDTO.Address = this.txtAddress.Text;
                ctDTO.BirthDay = convertStringToDate(txtBirthday.Text);
                ctDTO.City = "";
                ctDTO.Company = "";
                ctDTO.Country = "";
                ctDTO.Email = txtEmail.Text;
                ctDTO.Fax = "";
                ctDTO.Gender = drlGender.SelectedItem.ToString();
                ctDTO.Name = txtName.Text;
                ctDTO.Phone = this.txtPhone.Text;
                ctDTO.Province = "";
                ctDTO.SecondPhone = txtHomePhone.Text;
                ctDTO.Type = "";
                ctDTO.UserID = getUserLogin().UserId;
                ctDTO.createBy = getUserLogin().UserId;
                ctDTO.AssignTo = int.Parse(drlGroup.SelectedValue.ToString());
                //them moi
                if (hdfCustomerId.Value == null || hdfCustomerId.Value == "")
                {
                    DataTable table = ctBUS.GetClientId(getUserLogin().UserId);
                    int clienID = int.Parse(table.Rows[0]["clientId"].ToString());

                    DataTable dtCountEmail = ctBUS.GetCountEmail(clienID);
                    int countEmail = int.Parse(dtCountEmail.Rows[0]["emailCount"].ToString());

                    DataTable dtEmail = ctBUS.GetCountCustomerCreatedMail(getUserLogin().UserId);
                    int numbermail = int.Parse(dtEmail.Rows[0]["numberMail"].ToString());
                    if (numbermail < countEmail)
                    {
                        CustomerID = ctBUS.tblCustomer_insert(ctDTO);


                        if (dgBUS.GetByID(GroupID, CustomerID).Rows.Count > 0)
                        {
                            pnSuccess.Visible = false;
                            pnError.Visible = true;
                            lblError.Text = "Khách hàng này đã tồn tại trong nhóm này !";
                        }
                        else
                        {
                            DetailGroupDTO dgDTO = new DetailGroupDTO();
                            dgDTO.GroupID = GroupID;
                            dgDTO.CustomerID = CustomerID;
                            dgDTO.CountReceivedMail = 0;
                            dgDTO.LastReceivedMail = DateTime.Now;
                            dgBUS.tblDetailGroup_insert(dgDTO);
                            pnError.Visible = false;
                            pnSuccess.Visible = true;
                            lblSuccess.Text = "Bạn đã thêm thành công 1 khách hàng vào nhóm: " + drlGroup.SelectedItem.ToString();

                            // Update limit send and create.
                            updateLimitSendAndCreate(1, 0);
                        }
                    }
                    else
                    {
                        lblSuccess.Text = "Vượt quá hạng ngạch tạo khách hàng!";
                    }


                }
                //update
                else
                {
                    CustomerID = int.Parse(this.CustomerID.Value.ToString());
                    GroupID = int.Parse(drlGroup.SelectedValue.ToString());
                    ctDTO.Id = int.Parse(this.CustomerID.Value.ToString());
                    // CustomerID = int.Parse(ctBUS.GetByEmail(txtEmail.Text).Rows[0]["Id"].ToString());
                    ctBUS.tblCustomer_Update(ctDTO);
                    pnError.Visible = false;
                    pnSuccess.Visible = true;
                    //   lblSuccess.Text = "Bạn đã cập nhật thông thành công 1 khách hàng ! <br/>";
                    if (dgBUS.GetByID(GroupID, CustomerID).Rows.Count > 0)
                    {
                        pnSuccess.Visible = false;
                        pnError.Visible = true;
                        lblError.Text = "Khách hàng này đã tồn tại trong nhóm này !";
                    }
                    else
                    {
                        DetailGroupDTO dgDTO = new DetailGroupDTO();
                        dgDTO.GroupID = GroupID;
                        dgDTO.CustomerID = CustomerID;
                        dgDTO.LastReceivedMail = DateTime.Now;
                        dgBUS.tblDetailGroup_insert(dgDTO);
                        pnError.Visible = false;
                        pnSuccess.Visible = true;
                        lblSuccess.Text = "Bạn đã cập nhật thành công 1 khách hàng vào nhóm: " + drlGroup.SelectedItem.ToString();

                        // Update limit send and create.
                        updateLimitSendAndCreate(1, 0);
                    }
                }





                //tam edit
                //  if (this.CustomerID.Value.ToString() == "")
                // {
                ///    DataTable tblCheckByEmail = ctBUS.GetByEmail(txtEmail.Text);
                //    if (tblCheckByEmail.Rows.Count > 0)
                //    {
                //      CustomerID = int.Parse(tblCheckByEmail.Rows[0]["Id"].ToString());
                //    ctDTO.Id = CustomerID;
                //     ctBUS.tblCustomer_Update(ctDTO);
                //   pnError.Visible = false;
                //   pnSuccess.Visible = true;
                //lblSuccess.Text = "Bạn đã cập nhật thông thành công 1 khách hàng ! <br/>";
                //   }

                //tamhm edit
                //else
                //{
                //    CustomerID = ctBUS.tblCustomer_insert(ctDTO);
                //}

                //if (dgBUS.GetByID(GroupID, CustomerID).Rows.Count > 0)
                //{
                //    pnSuccess.Visible = false;
                //    pnError.Visible = true;
                //    lblError.Text = "Khách hàng này đã tồn tại trong nhóm này !";
                //}
                //else
                //{
                //    DetailGroupDTO dgDTO = new DetailGroupDTO();
                //    dgDTO.GroupID = GroupID;
                //    dgDTO.CustomerID = CustomerID;
                //    dgDTO.CountReceivedMail = 0;
                //    dgDTO.LastReceivedMail = DateTime.Now;
                //    dgBUS.tblDetailGroup_insert(dgDTO);
                //    pnError.Visible = false;
                //    pnSuccess.Visible = true;
                //    lblSuccess.Text = "Bạn đã thêm thành công 1 khách hàng vào nhóm: " + drlGroup.SelectedItem.ToString();

                //    // Update limit send and create.
                //    updateLimitSendAndCreate(1, 0);
                //}
                // }
                // else
                //  {
                //   CustomerID = int.Parse(this.CustomerID.Value.ToString());
                //   GroupID = int.Parse(drlGroup.SelectedValue.ToString());
                //   ctDTO.Id = int.Parse(this.CustomerID.Value.ToString());
                //   CustomerID = int.Parse(ctBUS.GetByEmail(txtEmail.Text).Rows[0]["Id"].ToString());
                //   ctBUS.tblCustomer_Update(ctDTO);
                //   pnError.Visible = false;
                //   pnSuccess.Visible = true;
                ////   lblSuccess.Text = "Bạn đã cập nhật thông thành công 1 khách hàng ! <br/>";
                //   if (dgBUS.GetByID(GroupID, CustomerID).Rows.Count > 0)
                //   {
                //       pnSuccess.Visible = false;
                //       pnError.Visible = true;
                //       lblError.Text = "Khách hàng này đã tồn tại trong nhóm này !";
                //   }
                //   else
                //   {
                //       DetailGroupDTO dgDTO = new DetailGroupDTO();
                //       dgDTO.GroupID = GroupID;
                //       dgDTO.CustomerID = CustomerID;
                //       dgBUS.tblDetailGroup_insert(dgDTO);
                //       pnError.Visible = false;
                //       pnSuccess.Visible = true;
                //       lblSuccess.Text = "Bạn đã thêm thành công 1 khách hàng vào nhóm: " + drlGroup.SelectedItem.ToString();

                //       // Update limit send and create.
                //       updateLimitSendAndCreate(1, 0);
                //   }
                //}
                ConnectionData.CloseMyConnection();
                setTextDefault();
            }
        }
        catch (Exception ex)
        {
            logMgr.Error(Session["us-login"] + " - btnAdd_Click", ex);
            pnError.Visible = true;
            lblError.Text = "Lỗi trong quá trình thêm khách hàng!" + ex.Message.ToString();
        }

    }
    protected DateTime convertStringToDate(string strDate)
    {
        int day = int.Parse(strDate.Substring(0, 2));
        int month = int.Parse(strDate.Substring(3, 2));
        int year = int.Parse(strDate.Substring(6, 4));
        //int hours = int.Parse(strDate.Substring(11, 2));
        //int minute = int.Parse(strDate.Substring(14, 2));
        DateTime dDate = new DateTime(year, month, day, 00, 00, 00);
        return dDate;
    }
    public bool IsValidMail(string emailaddress)
    {
        try
        {
            MailAddress m = new MailAddress(emailaddress);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
    private void setTextDefault()
    {
        this.txtName.Text = "";
        this.txtEmail.Text = "";
        this.txtPhone.Text = "";
        this.txtHomePhone.Text = "";
        this.txtAddress.Text = "";
        this.txtBirthday.Text = "";
        this.hdfCustomerId.Value = "";

    }
    protected void btnRefesh_Click(object sender, EventArgs e)
    {
        setTextDefault();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Customer.aspx");
    }
}
