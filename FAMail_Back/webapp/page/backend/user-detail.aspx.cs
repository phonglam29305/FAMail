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

public partial class webapp_page_backend_reportSend : System.Web.UI.Page
{
    SendRegisterBUS srBUS = null;
    SendRegisterDetailBUS srdBus = null;
    SendContentBUS sendContentBus = null;
    MailGroupBUS mgBus = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                getUserInfo();
            }
            catch (Exception ex)
            {
            }          
        }

    }
    
    private void getUserInfo(){
        UserLoginBUS ulBus = new UserLoginBUS();
        DepartmentBUS dBus = new DepartmentBUS();
        RoleDetailBUS rdBus = new RoleDetailBUS();

        int userId = int.Parse(Request.QueryString["uid"].ToString());
        DataTable tblUserDetail = Common.GetUserLoginDetail(userId);
        
        DataTable tblSendRegisterDetailByUser = Common.GetSendRegisterByUserId(userId);
        DataTable tblCustomerCreated = Common.GetCustomerCreatedByUserId(userId);
        
        if (tblUserDetail.Rows.Count > 0)
        {
            int departId = int.Parse(tblUserDetail.Rows[0]["DepartmentId"].ToString());
            DataTable tblRoleDetail = rdBus.GetByDepartmentId(departId);

            lblUsername.Text = tblUserDetail.Rows[0]["Username"].ToString();
            lblDepartment.Text = tblUserDetail.Rows[0]["Name"].ToString();

            if(tblRoleDetail.Rows.Count>0){
                lblHasSend.Text = 
                    tblSendRegisterDetailByUser.Rows.Count + " / " + tblRoleDetail.Rows[0]["limitSendMail"].ToString();
                lblHasCustomerCreate.Text =
                    tblCustomerCreated.Rows.Count + " / " + tblRoleDetail.Rows[0]["limitCreateCustomer"].ToString();
                lblToDate.Text = tblRoleDetail.Rows[0]["toDate"].ToString();
            }
            
        }
        
                
           
    }
    private int getSessionId()
    {
        if (Session["ID"].ToString() != null || Session["ID"].ToString() != "")
        {
            return int.Parse(Session["ID"].ToString());
        }
        else
        {
            return 0;
        }
    }
    private int getSessionDepartmentId()
    {
        if (Session["DepartmentID"].ToString() != null || Session["DepartmentID"].ToString() != "")
        {
            return int.Parse(Session["DepartmentID"].ToString());
        }
        return 0;
    }

    
    //private void LoadOpenEmail(int RegisterID)
    //{
    //    srdBus = new SendRegisterDetailBUS();
    //    DataTable tblSendDetail = new DataTable();
    //    tblSendDetail = srdBus.GetByOpenMail(RegisterID);
    //    if (tblSendDetail.Rows.Count > 0)
    //    {
    //        dlReport.DataSource = tblSendDetail;
    //        dlReport.DataBind();
    //        int count = 0;
    //        for (int i = 0; i < tblSendDetail.Rows.Count; i++)
    //        {
    //            count++;
    //            DataRow row = tblSendDetail.Rows[i];
    //            Label lblNo = (Label)dlReport.Items[i].FindControl("lblNo");
    //            lblNo.Text = count.ToString();
    //            Label lblEmail = (Label)dlReport.Items[i].FindControl("lblEmail");
    //            lblEmail.Text = row["Email"].ToString();

    //            Label lblStartDate = (Label)dlReport.Items[i].FindControl("lblStartDate");
    //            lblStartDate.Text = row["StartDate"].ToString();

    //            Label lblOpenDate = (Label)dlReport.Items[i].FindControl("lblOpenDate");
    //            lblOpenDate.Text = row["DateOpen"].ToString();

    //            ImageButton ibtStatus = (ImageButton)dlReport.Items[i].FindControl("ibtStatus");
    //            bool check = Boolean.Parse(row["isOpenMail"].ToString());
    //            if (check == true)
    //            {
    //                ibtStatus.ImageUrl = "~/webapp/resource/images/ok.png";
    //            }
    //            else
    //            {
    //                ibtStatus.ImageUrl = "~/webapp/resource/images/warning.png";
    //            }
    //        }
    //    }
    //}

    
}
