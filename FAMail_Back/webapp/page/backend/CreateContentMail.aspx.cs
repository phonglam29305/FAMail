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

public partial class webapp_page_backend_CreateContentMail : System.Web.UI.Page
{
    SendContentBUS scBUS = null;
    DataTable SignIn = null;
    SignatureBUS signBus = null;
    log4net.ILog logs = log4net.LogManager.GetLogger("ErrorRollingLogFileAppender");
    UserLoginDTO userLogin = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {


            if (!IsPostBack)
            {
                LoadContentMail();
                LoadSignatureList();


            }

        }
        catch (Exception)
        {
        }
    }


    private void LoadSignatureList()
    {
        try
        {
            InitialBUS();
            signBus = new SignatureBUS();
            UserLoginDTO userLogin = getUserLogin();
            DataTable tblSignList = signBus.GetByUserId(userLogin.UserId);
            createTableSign();
            if (tblSignList.Rows.Count > 0)
            {
                DataRow rowE = SignIn.NewRow();
                rowE["Id"] = 0;
                rowE["SignatureName"] = "Chọn chữ ký";
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


    private void LoadContentMail()
    {
        InitialBUS();
        try
        {
            int ID = int.Parse(Request.QueryString["id"].ToString());
            this.hdfContentId.Value = ID.ToString();
            if (ID != 0)
            {
                if (scBUS.GetByID(ID).Rows.Count > 0)
                {

                    this.txtSubject.Text = scBUS.GetByID(ID).Rows[0]["Subject"].ToString();
                    this.txtBody.Text = scBUS.GetByID(ID).Rows[0]["Body"].ToString();
                }
                else
                {
                    pnError.Visible = true;
                    lblError.Text = "Không có nội dung ";
                    pnSuccess.Visible = false;
                }
            }


        }
        catch (Exception ex)
        {

            //pnError.Visible = true;
            //lblError.Text = ex.ToString();
        }
    }

    private void InitialBUS()
    {
        scBUS = new SendContentBUS();
        signBus = new SignatureBUS();
    }
    protected void btnSaveContent_Click(object sender, EventArgs e)
    {
        InitialBUS();
        bool check = CheckNull();
        if (check == false)
        {
            pnError.Visible = true;
            lblError.Text = "Bạn chưa nhập tiêu đề hoặc nôi dung. Vui lòng kiểm tra lại";
            pnSuccess.Visible = false;
            return;

        }
        int status = 1;//1-insert 2-update
        String ContentId = this.hdfContentId.Value.ToString();
        SendContentDTO scDTO = getscDTO();
        ConnectionData.OpenMyConnection();
        if (ContentId == "" || ContentId == null || int.Parse(ContentId) == 0)//them moi
        {
            scBUS.tblSendContent_insert(scDTO);
        }
        else
        {

            scBUS.tblSendContent_Update(scDTO);
            status = 2;

        }

        ConnectionData.CloseMyConnection();
        pnSuccess.Visible = true;

        if (status == 1)
        {
            lblSuccess.Text = "Bạn vừa thêm thành công một nội dung mail !";
        }
        else
        {
            lblSuccess.Text = "Thông tin nội dung mail đã được cập nhật !";
        }
        pnError.Visible = false;
    }

    private bool CheckNull()
    {

        string subject = "";
        string body = "";
        body = this.txtBody.Text.ToString();
        DateTime createdate = DateTime.Now;
        subject = this.txtSubject.Text.ToString();

        if (subject == "" || subject == null || body == null || body == "")
        {
            return false;
        }
        return true;
    }

    private SendContentDTO getscDTO()
    {
        UserLoginDTO userLogin = getUserLogin();
        SendContentDTO scDTO = new SendContentDTO();
        if (userLogin != null)
        {
            int id = 0;
            id = int.Parse(this.hdfContentId.Value.ToString());
            string subject = "";
            string body = "";
            body = this.txtBody.Text.ToString();
            DateTime createdate = DateTime.Now;
            subject = this.txtSubject.Text.ToString();
            scDTO.CreateDate = createdate;
            scDTO.Subject = subject;
            scDTO.Body = body;
            scDTO.Id = id;
            scDTO.userId = userLogin.UserId;
            return scDTO;
        }
        else
        {
            return null;
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

    protected void resetForm()
    {
        txtSubject.Text = "";
        txtBody.Text = "";
    }

    protected void btnRefesh_Click(object sender, EventArgs e)
    {
        resetForm();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }
    protected void lbtInsertSignature_Click(object sender, EventArgs e)
    {
        InitialBUS();
        try
        {
            int signId = int.Parse(((LinkButton)sender).CommandArgument.ToString());
            SignatureBUS signBus = new SignatureBUS();
            DataTable tblSign = signBus.GetById(signId);
            if (tblSign.Rows.Count > 0)
            {
                txtBody.Text = txtBody.Text + "\n" + tblSign.Rows[0]["SignatureContent"].ToString();
            }
        }
        catch (Exception)
        {

            throw;
        }

    }
    protected void lbtEditSignature_Click(object sender, EventArgs e)
    {
        Response.Redirect("create-signature.aspx");
    }
    protected void lbtAddWelcome_Click(object sender, EventArgs e)
    {
        if (txtWelcome.Text != "" && txtAfterWelcome.Text != "")
        {

            String welcomeText = txtWelcome.Text;
            if (rdoCustomerName.Checked == true)
            {
                welcomeText += " [khachhang] ";
            }
            else
            {
                welcomeText += " [email] ";
            }
            welcomeText += txtAfterWelcome.Text;

            txtBody.Text = welcomeText + "</br>" + txtBody.Text;
        }
    }
    protected void btnPreview_Click(object sender, EventArgs e)
    {
        string ContentMail = this.txtBody.Text;
        Session["Content"] = ContentMail;
        Response.Redirect("PreviewContent.aspx");

    }


    [System.Web.Services.WebMethod]
    public static string GetCurrentTime(string name)
    {
        string selectedRdoValue = string.Empty;
        string selectedDdlValue = string.Empty;
        string selectedChkValue = string.Empty;
        Page page = HttpContext.Current.Handler as Page;
        TextBox txtBody = (TextBox)page.FindControl("txtBody");

        return "Hello " + name + Environment.NewLine + "The Current Time is: "
            + DateTime.Now.ToString();
    }

}
