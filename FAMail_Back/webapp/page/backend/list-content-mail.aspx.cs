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

public partial class webapp_page_backend_create_content_mail : System.Web.UI.Page
{
    SendContentBUS scBus = null;


    protected void Page_Load(object sender, EventArgs e)
    {
        scBus = new SendContentBUS();
        if (!IsPostBack)
        {
            try
            {                
                LoadDataListContent();
            }
            catch (Exception ex)
            {
                pnError.Visible = true;
                lblError.Text = ex.Message;
            }
            
        }
    }

    private void LoadDataListContent()
    {       
        DataTable lsContent = new DataTable();
        UserLoginDTO userLogin = getUserLogin();
        if (userLogin.DepartmentId == 1)
       {
            lsContent = scBus.GetAll();
        }
        else
        {
            
            lsContent = scBus.GetAllSendContent(userLogin.UserId);
        }
        
        this.dtlContentMail.DataSource = lsContent;
        this.dtlContentMail.DataBind();

    }

    private UserLoginDTO getUserLogin()
    {
        if (Session["us-login"] != null )
        {
            return (UserLoginDTO)Session["us-login"];
        }
        return null;
    }

   
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {          
            int ContentId = int.Parse(((ImageButton)sender).CommandArgument);
            ConnectionData.OpenMyConnection();
           
            SendRegisterBUS srBUS = new SendRegisterBUS();
            if (srBUS.GetByContentID(ContentId) > 0)
            {
                visibleMessage(false);
                pnError.Visible = true;
                lblError.Text = "Bạn không thể xóa nội dung này! Nội dung này đang chờ gửi!";
            }
            else
            {
                scBus.tblSendContent_Delete(ContentId);
                //Response.Redirect(Request.RawUrl);
                LoadDataListContent();
                visibleMessage(false);
                pnSuccess.Visible = true;
                lblSuccess.Text = "Bạn vừa xóa thành công nội dung mail !";
            }
            ConnectionData.CloseMyConnection();
        }
        catch (Exception ex)
        {
            pnError.Visible = true;
            lblError.Text = ex.Message;
        }
    }
    protected void visibleMessage(bool vis)
    {
        pnError.Visible = vis;
        pnSuccess.Visible = vis;
    }
    protected void btnPreview_Click(object sender, ImageClickEventArgs e)
    {
        int ContentId = int.Parse(((ImageButton)sender).CommandArgument);
        if (scBus.GetByID(ContentId).Rows.Count > 0)
        {
            Session["Content"] = scBus.GetByID(ContentId).Rows[0]["Body"].ToString();
        }
        else
        {
            Session["Content"] = "Không có nội dung";
        }
        Response.Redirect("PreviewContent.aspx");
    }
}
