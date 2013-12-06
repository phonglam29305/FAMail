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
                string campaignId = Request.QueryString["campaign-id"].ToString();
                if (campaignId != null)
                {
                    drlCampaign.SelectedValue = campaignId;
                    drlCampaign_SelectedIndexChanged(sender, e);
                }
            }
            catch (Exception)
            {

            }
           
        }

    }
    protected void loadSendRegisterList(int status)
    {
        srBUS = new SendRegisterBUS();
        sendContentBus = new SendContentBUS();
        DataTable tblSendList = new DataTable();

        if (getUserLogin().DepartmentId==1)
        {
            tblSendList = srBUS.GetByStatus(status);
        }
        else
        {
            tblSendList = srBUS.GetByStatusUser(status, getUserLogin().UserId);
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
                          new ListItem(temp.Rows[0]["Subject"].ToString() + " - " + tblSendList.Rows[i]["StartDate"].ToString(), tblSendList.Rows[i]["Id"].ToString()));
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
            drlCampaign.Items.Add(new ListItem("Không có chiến dịch nào !", "1"));
            pnReport.Visible = false;
            
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
    private UserLoginDTO getUserLogin()
    {
        if (Session["us-login"] != null)
        {
            return (UserLoginDTO)Session["us-login"];
        }
        return null;
    }
    private int getSessionDepartmentId()
    {
        if (Session["DepartmentID"].ToString() != null || Session["DepartmentID"].ToString() != "")
        {
            return int.Parse(Session["DepartmentID"].ToString());
        }
        return 0;
    }

    protected void drlCampaign_SelectedIndexChanged(object sender, EventArgs e)
    {
        int readMail = 0;
        try
        {
            srBUS = new SendRegisterBUS();
            srdBus = new SendRegisterDetailBUS();
            sendContentBus = new SendContentBUS();
            mgBus = new MailGroupBUS();
            int sendId = int.Parse(drlCampaign.SelectedValue.ToString());
            DataTable campain = srdBus.GetByID(sendId);
            DataTable errSend = srdBus.GetByStatus(false, sendId);
            DataTable unreceve = srdBus.GetByNotReceve(sendId);
            int err = errSend.Rows.Count;
            this.lblTotalMailSend.Text = campain.Rows.Count.ToString();
            int notreceve = unreceve.Rows.Count;
            if (campain.Rows.Count > 0)
            {
                lblEmailSend.Text = campain.Rows[0]["MailSend"].ToString();
                foreach (DataRow row in campain.Rows)
                {
                    if (row["isOpenMail"].ToString() == "True")
                    {
                        readMail++;
                    }
                }
                lblNotOpen2.Text = (campain.Rows.Count - readMail).ToString();
            }
            lblOpened.Text = readMail.ToString();
            DataTable sendregisteDetail = srBUS.GetByID(sendId);
            if (sendregisteDetail.Rows.Count > 0)
            {
                int contentID = int.Parse(sendregisteDetail.Rows[0]["SendContentId"].ToString());
                lblDateStart.Text = sendregisteDetail.Rows[0]["StartDate"].ToString();
                lblDateEnd.Text = sendregisteDetail.Rows[0]["EndDate"].ToString();
                int groupSend = int.Parse(sendregisteDetail.Rows[0]["GroupTo"].ToString());
                lblGroupEmailTo.Text = mgBus.GetByID(groupSend).Rows[0]["Name"].ToString();
                if (sendContentBus.GetByID(contentID).Rows.Count > 0)
                {
                    lblCampianName.Text = sendContentBus.GetByID(contentID).Rows[0]["Subject"].ToString();
                }
            }
            CreateChart(campain.Rows.Count, err, readMail, 1, notreceve,lblCampianName.Text);
            LoadOpenEmail(sendId);
        }
        catch (Exception ex)
        {
            //pnError.Visible = true;
            //lblError.Text = ex.Message;
        }
    }

    private void LoadOpenEmail(int RegisterID)
    {
        srdBus = new SendRegisterDetailBUS();
        DataTable tblSendDetail = new DataTable();
        tblSendDetail = srdBus.GetByOpenMail(RegisterID);
        if (tblSendDetail.Rows.Count > 0)
        {
            dlReport.DataSource = tblSendDetail;
            dlReport.DataBind();
            int count = 0;
            for (int i = 0; i < tblSendDetail.Rows.Count; i++)
            {
                count++;
                DataRow row = tblSendDetail.Rows[i];
                Label lblNo = (Label)dlReport.Items[i].FindControl("lblNo");
                lblNo.Text = count.ToString();
                Label lblEmail = (Label)dlReport.Items[i].FindControl("lblEmail");
                lblEmail.Text = row["Email"].ToString();

                Label lblStartDate = (Label)dlReport.Items[i].FindControl("lblStartDate");
                lblStartDate.Text = row["StartDate"].ToString();

                Label lblOpenDate = (Label)dlReport.Items[i].FindControl("lblOpenDate");
                lblOpenDate.Text = row["DateOpen"].ToString();

                ImageButton ibtStatus = (ImageButton)dlReport.Items[i].FindControl("ibtStatus");
                bool check = Boolean.Parse(row["isOpenMail"].ToString());
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

    private void CreateChart(int total, int err, int open, int NotOpen, int notRecive, string campainName)
    {
        float percentErr = 1;
        percentErr = (err * 100) / total;
        double percentSend = 100 - percentErr;
        float percentOpen = 1;
        percentOpen = (open * 100) / total;
        double percentNotOpen = percentSend - percentOpen;
        double percentNotRecev = (notRecive * 100) / total;
        string html = "<table>"+
                   " <tr><td colspan='2' style='background-color:rgb(97, 88, 88); color:White;'><h2 style='font-size: 15px;font-weight:bolder;"+
                   " vertical-align: middle; text-transform: uppercase;  margin-top: 10px;width: 100%;'>Biểu đồ thông kê chiến dịch</h2></td></tr>"+
					" <tr style='height:35px'>"+
						               "<td style='width:35%; text-align:left;padding-left:10px;'>Tổng số mail gửi </td>"+
						              " <td style='text-align:left;'> <div style='width:"+percentSend.ToString()+"%; background-color:#59D2EB; ; text-align:center;' >"+
                                           "<asp:Label ID='lblTotalSend' runat='server' Text='" + percentSend.ToString() + "'>" + percentSend.ToString() + "%</asp:Label></div>  </td>" +
						          " </tr>"+
						            "<tr style='height:35px'>"+
						              " <td style='width:35%; text-align:left; padding-left:10px;'>Mail lỗi </td>"+
                                      " <td style='text-align:left'><div style='width:" + percentErr.ToString() + "%; background-color:#59D2EB; text-align:center;'>" +
                                           "<asp:Label ID='lblNumberErr' runat='server' Text='" + percentErr.ToString() + "% &nbsp;'>" + percentErr.ToString() + "%</asp:Label></div> </td>" +
						         "  </tr>"+
						           						           
						           " <tr style='height:35px'>"+
						            "   <td style='width:35%; text-align:left;padding-left:10px;'>Mail đã mở: </td>"+
                                     "  <td style='text-align:left'><div style='width:" + percentOpen.ToString() + "%; background-color:#59D2EB;text-align:center;' >" +
                                         "  <asp:Label ID='lblIsOpen' runat='server' Text='&nbsp;" + percentOpen.ToString() + "%'>" + percentOpen.ToString() + "%</asp:Label></div>  </td>" +
						          " </tr>"+						           
						           " <tr style='height:35px'>"+
						            "   <td style='width:35%; text-align:left;padding-left:10px;'>Mail chưa mở : </td>"+
                                      " <td style='text-align:left'><div style='width:" + percentNotOpen.ToString() + "%; background-color:#59D2EB; text-align:center;' >" +
                                      "     <asp:Label ID='lblNotOpen' runat='server' Text='&nbsp;" + percentNotOpen.ToString() + "%'>" + percentNotOpen.ToString() + "%</asp:Label></div> </td>" +
						          " </tr>"+						           
						           " <tr style='height:35px'>"+
						            "   <td style='width:35%; text-align:left;padding-left:10px;'>Mail từ chối nhận tin: </td>" +
                                     "  <td style='text-align:left'><div style='width:" + percentNotRecev.ToString() + "%; background-color:#59D2EB; text-align:center;' >" +
                                       "    <asp:Label ID='lblNotRecived' runat='server' Text='&nbsp;" + percentNotRecev.ToString() + "%'>" + percentNotRecev.ToString() + "%</asp:Label></div> </td>" +
						          " </tr>"+		      					           
						          
	"<tr><td colspan='2'><h2  style='font-size: 15px;font-weight:bolder; vertical-align: middle; text-transform:uppercase; height:35px; text-decoration:underline; padding-top:20px; '>Chiến dịch: "+campainName+"</h2></td></tr>"+
"</table>";
        lblChart.Text = html;
    }
}
