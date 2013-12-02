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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
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

    protected void LoadEventReport()
    {
        mailGroupBus = new MailGroupBUS();
        eventDetailBus = new EventDetailBUS();
        UserLoginDTO userLogin = getUserLogin();
        DataTable dtGroup = new DataTable();
        if (userLogin.DepartmentId == 1)
        {
            dtGroup = mailGroupBus.GetAll();
        }
        else
        {
            dtGroup = mailGroupBus.GetAll(userLogin.UserId);
        }
        rptGroup.DataSource = dtGroup;
        rptGroup.DataBind();
        for (int i = 0; i < dtGroup.Rows.Count; i++)
        {
            DataRow rowGroup = dtGroup.Rows[i];
            int groupId = int.Parse(rowGroup["Id"].ToString());
            DataTable dtEventByGroup = eventDetailBus.GetByGroupId(groupId);

            
            Label lblGroupName = (Label)rptGroup.Items[i].FindControl("lblGroupName");
            lblGroupName.Text = rowGroup["Name"].ToString()+" ( Có "+dtEventByGroup.Rows.Count+" khách hàng đăng ký )";            

            
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
}
