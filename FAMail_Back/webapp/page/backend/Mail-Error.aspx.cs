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

public partial class webapp_page_backend_Mail_Error : System.Web.UI.Page
{
    SendRegisterBUS srBUS = null;
    SendRegisterDetailBUS srdBus = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                loadDetailReport(false);
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

    protected void loadDetailReport(bool status)
    {
        srBUS = new SendRegisterBUS();
        srdBus = new SendRegisterDetailBUS();
        DataTable tblSendDetail = new DataTable();
        UserLoginDTO userLogin = getUserLogin();
        if (userLogin.DepartmentId == 1)
        {
            tblSendDetail = srdBus.GetByStatus(status);
        }
        else
        {
            tblSendDetail = srdBus.GetByStatus(status);
        }
        
        if (tblSendDetail.Rows.Count > 0)
        {
            
            dlPager.MaxPages = 1000;
            dlPager.PageSize = 100;
            dlPager.DataSource = tblSendDetail.DefaultView;
            dlPager.BindToControl = dlReport;
            this.dlReport.DataSource = dlPager.DataSourcePaged;
            this.dlReport.DataBind();
            int count = 0;
            for (int i = 0; i < tblSendDetail.Rows.Count; i++)
            {
                count++;
                DataRow row = tblSendDetail.Rows[i];
                Label lblNo = (Label)dlReport.Items[i].FindControl("lblNo");
                lblNo.Text = count.ToString();
                HiddenField hdfId = (HiddenField)dlReport.Items[i].FindControl("hdfId");
                hdfId.Value = row["SendRegisterId"].ToString();
                Label lblEmail = (Label)dlReport.Items[i].FindControl("lblEmail");
                lblEmail.Text = row["Email"].ToString();
                Label lblStartDate = (Label)dlReport.Items[i].FindControl("lblStartDate");
                lblStartDate.Text = row["StartDate"].ToString();
                Label lblEndDate = (Label)dlReport.Items[i].FindControl("lblEndDate");
                lblEndDate.Text = row["EndDate"].ToString();
                ImageButton ibtStatus = (ImageButton)dlReport.Items[i].FindControl("ibtStatus");
                bool check = Boolean.Parse(row["Status"].ToString());
                if (check == true)
                {
                    ibtStatus.ImageUrl = "~/webapp/resource/images/ok.png";
                }
                else
                {
                    ibtStatus.ImageUrl = "~/webapp/resource/images/warning.png";
                }
            }
        }
    }
    protected void lbtExecute_Click(object sender, EventArgs e)
    {
        try
        {
            DataListItem footer = (DataListItem)dlReport.Controls[dlReport.Controls.Count - 1];
            DropDownList drlType = (DropDownList)footer.FindControl("drlType");
            Label lblMessage = (Label)footer.FindControl("lblMessage");
            if (drlType.SelectedValue == "1")
            {
                int countDelete = 0;
                for (int i = 0; i < dlReport.Items.Count; i++)
                {
                    DataListItem item = dlReport.Items[i];
                    HiddenField id = (HiddenField)item.FindControl("hdfId");
                    Label lblEmail = (Label)dlReport.Items[i].FindControl("lblEmail");
                    CheckBox chkXoa = (CheckBox)item.FindControl("chkCheck");
                    srdBus = new SendRegisterDetailBUS();
                    if (chkXoa.Checked == true)
                    {
                        ConnectionData.OpenMyConnection();
                        srdBus.tblSendRegisterDetail_Delete(int.Parse(id.Value), lblEmail.Text);
                        ConnectionData.CloseMyConnection();
                        countDelete++;
                    }
                }

            }
            loadDetailReport(false);
        }
        catch (Exception ex)
        {
            //pnError.Visible = true;
            //lblError.Text = ex.Message;
        }
    }
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)sender;
        if (chkAll != null)
        {
            for (int i = 0; i < dlReport.Items.Count; i++)
            {
                DataListItem item = dlReport.Items[i];
                CheckBox chk = (CheckBox)item.FindControl("chkCheck");
                chk.Checked = chkAll.Checked;
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
}
