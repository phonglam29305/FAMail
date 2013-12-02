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
    SignatureBUS signBus = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                loadSignatureList();
            }
            catch (Exception)
            {
                Response.Redirect("login.aspx");
            }
            
        }
        
    }

    private void LoadSignature()
    {

        UserLoginDTO userLogin = getUserLogin();
        signBus = new SignatureBUS();
        DataTable tblSign = signBus.GetByUserId(userLogin.UserId);
        if (tblSign.Rows.Count > 0)
        {
            txtBody.Text = tblSign.Rows[0]["SignatureContent"].ToString();
        }
        else
        {
            //pnSuccess.Visible = true;
            //lblSuccess.Text = "Bạn chưa có chữ ký, vui lòng thêm chữ ký tại đây !";
        }
        
    }

    private void InitialBUS()
    {
        signBus = new SignatureBUS();
    }
    protected void btnSaveContent_Click(object sender, EventArgs e)
    {
        try
        {
            string message = checkInput();
            if (message!="")
            {
                pnError.Visible = true;
                lblError.Text = message;
                pnSuccess.Visible = false;
                return;

            }
            int status = 0;
            InitialBUS();
            SignatureDTO signDto = getSignatureDTO();
            ConnectionData.OpenMyConnection();            
            if (hdfId.Value==null||hdfId.Value=="")//them moi
            {
                signBus.tblSignature_insert(signDto);
                status = 1;
            }
            else
            {
                signBus.tblSignature_Update(signDto);
                status = 2;
            }
            ConnectionData.CloseMyConnection();
            pnSuccess.Visible = true;

            if (status == 1)
            {
                lblSuccess.Text = "Bạn vừa thêm thành công chữ ký !";
            }
            else
            {
                lblSuccess.Text = "Thông tin chữ ký đã được cập nhật !";
            }
            pnError.Visible = false;
            loadSignatureList();
        }
        catch (Exception)
        {
            pnSuccess.Visible = false;
            pnError.Visible = true;
            lblError.Text = " Đã xảy ra lỗi trong quá trình thực hiện. Vui lòng thử lại !";
        }
        
    }

    private string checkInput()
    {
        string message = "";
        if (txtSignatureName.Text == "")
        {
            message = "Vui lòng nhập vào tên chữ ký !";
        }
        else if (txtBody.Text == null || txtBody.Text == "")
        {
            message = "Vui lòng nhập vào nội dung chữ ký !";
        }
        return message;
    }

    private SignatureDTO getSignatureDTO()
    {
        SignatureDTO sign = new SignatureDTO();
        UserLoginDTO userLogin = getUserLogin();
        if (userLogin != null)
        {
            sign.userId = userLogin.UserId;
            sign.signatureContent = txtBody.Text;
            sign.SignatureName = txtSignatureName.Text;
            if (hdfId.Value != null&&hdfId.Value!="")
                sign.id = int.Parse(hdfId.Value);
        }
        else
        {
            Response.Redirect("login.aspx");
        }
        return sign;
        
    }
    

    protected void resetForm()
    {     
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
    private UserLoginDTO getUserLogin()
    {
        if (Session["us-login"] != null)
        {
            return (UserLoginDTO)Session["us-login"];
        }
        return null;
    }
    private void loadSignatureList()
    {
        UserLoginDTO userLogin = getUserLogin();
        signBus = new SignatureBUS();
        DataTable tblSign = signBus.GetByUserId(userLogin.UserId);
        dlSignature.DataSource = tblSign;
        dlSignature.DataBind();
        for (int i = 0; i < tblSign.Rows.Count; i++)
        {
            DataRow row = tblSign.Rows[i];

            Label lblNo = (Label)dlSignature.Items[i].FindControl("lblNo");
            lblNo.Text = (i + 1).ToString();

            LinkButton lbtSubject = (LinkButton)dlSignature.Items[i].FindControl("lbtSubject");
            lbtSubject.Text = row["SignatureName"].ToString();
            lbtSubject.ToolTip = row["SignatureContent"].ToString();

            LinkButton lbtEdit = (LinkButton)dlSignature.Items[i].FindControl("lbtEdit");
            lbtEdit.CssClass = "table-actions-button ic-table-edit";
            lbtEdit.CommandArgument = row["id"].ToString();

            LinkButton lbtDelete = (LinkButton)dlSignature.Items[i].FindControl("lbtDelete");
            lbtDelete.CssClass = "table-actions-button ic-table-delete";
            lbtDelete.CommandArgument = row["id"].ToString();

        }
    }
    protected void lbtEdit_Click(object sender, EventArgs e)
    {
        try 
	    {
            pnSuccess.Visible = false;
            pnError.Visible = false;
    		int signId = int.Parse(((LinkButton)sender).CommandArgument.ToString());
            signBus = new SignatureBUS();
            DataTable dtSign = signBus.GetById(signId);
            if (dtSign.Rows.Count > 0)
            {
                txtSignatureName.Text = dtSign.Rows[0]["SignatureName"].ToString();
                txtBody.Text = dtSign.Rows[0]["SignatureContent"].ToString();
                hdfId.Value = dtSign.Rows[0]["id"].ToString();                
            }
	    }
	    catch (Exception)
	    {    		
		    throw;
	    }
        
    }
    protected void lbtDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int signId = int.Parse(((LinkButton)sender).CommandArgument.ToString());
            signBus = new SignatureBUS();
            ConnectionData.OpenMyConnection();
            signBus.tblSignature_Delete(signId);
            ConnectionData.CloseMyConnection();
            loadSignatureList();
            pnError.Visible = false;
            pnSuccess.Visible = true;
            lblSuccess.Text = "Bạn vừa xóa chữ ký thành công !";

        }
        catch (Exception ex)
        {
            pnError.Visible = true;
            lblError.Text = "Không thể xóa !</br>" + ex.Message;
        }
       

    }
    protected void btnCreateNew_Click(object sender, EventArgs e)
    {
        hdfId.Value = null;
        txtBody.Text = "";
    }
}
