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

public partial class webapp_page_backend_mail_report : System.Web.UI.Page
{
    SendRegisterBUS srBUS = null;
    SendRegisterDetailBUS srdBus = null;
    SendContentBUS sendContentBus = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            try
            {
                loadSendRegisterList(1);
                drlCampaign_SelectedIndexChanged(sender, e);
             
            }
            catch (Exception ex)
            {
                //pnError.Visible = true;
                //lblError.Text = ex.Message;
            }

            try
            {
                UserLoginDTO userLogin = getUserLogin();
                string campaignId = Request.QueryString["campaign-id"].ToString();
                if (campaignId != null)
                {
                    drlCampaign.SelectedValue = campaignId;
                    int sendId = int.Parse(campaignId);
                    loadDetailReport(sendId, 100, userLogin.UserId);
                }
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

    protected void loadSendRegisterList(int status)
    {
        srBUS = new SendRegisterBUS();
        sendContentBus = new SendContentBUS();
        DataTable tblSendList = new DataTable();
        UserLoginDTO userLogin = getUserLogin();
        if (userLogin.DepartmentId == 1)
        {
            tblSendList = srBUS.GetByStatus(status);
        }
        else
        {
            tblSendList = srBUS.GetByStatus(status, userLogin.UserId);
        }
        
        if (tblSendList.Rows.Count > 0)
        {
            DataTable temp = new DataTable();
            for (int i = 0; i < tblSendList.Rows.Count; i++)
            {
                try
                {
                    temp = sendContentBus.GetByID(int.Parse(tblSendList.Rows[i]["SendContentId"].ToString()));
                    if (temp.Rows.Count > 0)
                    {
                        drlCampaign.Items.Add(
                          new ListItem(temp.Rows[0]["Subject"].ToString()+" - " + tblSendList.Rows[i]["StartDate"].ToString(), tblSendList.Rows[i]["Id"].ToString()));
                    }
                }
                catch (Exception)
                {
                    continue;
                }
                
            }
        }
        else
        {
            drlCampaign.Items.Add(new ListItem("Không có chiến dịch nào !","1"));
        }
               
    }

    protected void loadDetailReport(int sendRegisterId, int limit, int MailConfigID)
    {
        DataTable tblSendDetail = null;
        srdBus = new SendRegisterDetailBUS();
        UserLoginDTO userLogin = getUserLogin();
        if (userLogin.DepartmentId != 1)
        {
            tblSendDetail = srdBus.GetBySendIdAndLimit(sendRegisterId, limit, Session["us-login"].ToString());
        }
        else
        {
            tblSendDetail = srdBus.GetBySendIdAndLimit(sendRegisterId, limit);
        }
        if (tblSendDetail.Rows.Count > 0)
        {
            dlReport.DataSource = tblSendDetail;
            dlReport.DataBind();
            int count = 0;
            for (int i = 0; i < tblSendDetail.Rows.Count; i++)
            {
                count ++;
                DataRow row = tblSendDetail.Rows[i];
                Label lblNo = (Label)dlReport.Items[i].FindControl("lblNo");
                lblNo.Text = count.ToString();

                Label lblEmail = (Label)dlReport.Items[i].FindControl("lblEmail");
                lblEmail.Text = row["Email"].ToString();

                Label lblStartDate = (Label)dlReport.Items[i].FindControl("lblStartDate");
                lblStartDate.Text = row["StartDate"].ToString();

                Label lblEndDate = (Label)dlReport.Items[i].FindControl("lblEndDate");
                lblEndDate.Text = row["EndDate"].ToString();

                ImageButton ibtStatus = (ImageButton)dlReport.Items[i].FindControl("ibtStatus");
                bool status = Boolean.Parse(row["Status"].ToString());
                if (status == true)
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

    private void LoadDataListContent()
    {
        srBUS = new SendRegisterBUS();
        this.dlReport.DataSource = srBUS.GetSended();
        this.dlReport.DataBind();
    }
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)sender;
        if (chkAll != null)
        {
            for (int i = 0; i < dlReport.Items.Count; i++)
            {
                DataListItem item = dlReport.Items[i];
                CheckBox chk = (CheckBox)item.FindControl("chkXoa");
                chk.Checked = chkAll.Checked;
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
                    CheckBox chkXoa = (CheckBox)item.FindControl("chkXoa");
                    srBUS = new SendRegisterBUS();
                    if (chkXoa.Checked == true)
                    {
                        srBUS.tblSendRegister_Delete(int.Parse(id.Value.ToString()));
                        countDelete++;
                    }
                }
                LoadDataListContent();
                lblMessage.Text = countDelete.ToString();

            }

        }
        catch (Exception ex)
        {
            pnError.Visible = true;
            lblError.Text = ex.Message;
        }

    }
    protected void drlCampaign_SelectedIndexChanged(object sender, EventArgs e)
    {
        UserLoginDTO userLogin = getUserLogin();
        try
        {
            int sendId = int.Parse(drlCampaign.SelectedValue.ToString());
            loadDetailReport(sendId, 100, userLogin.UserId);
        }
        catch (Exception ex)
        {
            //pnError.Visible = true;
            //lblError.Text = ex.Message;
        }
    }
}
