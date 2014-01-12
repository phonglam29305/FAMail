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
using System.Drawing;

public partial class webapp_page_backend_wait_send : System.Web.UI.Page
{
    SendRegisterBUS srBUS = null;
    SendRegisterDetailBUS srdBus = null;
    MailConfigBUS mailConfigBus = null;
    MailGroupBUS mailGroupBus = null;
    SendContentBUS sendContentBus = null;
    DetailGroupBUS dsgBus = null;
    CategoryBUS cateBUs = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                getRegisterSendList();
            }
            catch (Exception ex)
            {
                pnError.Visible = true;
                lblError.Text = ex.Message;
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

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)sender;
        if (chkAll != null)
        {
            for (int i = 0; i < dlWaitSend.Items.Count; i++)
            {
                DataListItem item = dlWaitSend.Items[i];
                CheckBox chk = (CheckBox)item.FindControl("chkCheck");
                chk.Checked = chkAll.Checked;
            }
        }
    }

    protected void lbtDelete_Click(object sender, EventArgs e)
    {
        try
        {
            srBUS = new SendRegisterBUS();
            int sendRegisterId = int.Parse(((LinkButton)sender).CommandArgument.ToString());
            ConnectionData.OpenMyConnection();
            srBUS.tblSendRegister_Delete(sendRegisterId);
            ConnectionData.CloseMyConnection();
            pnError.Visible = false;
            pnSuccess.Visible = true;
            lblSuccess.Text = "Bạn đã xóa thành công !";
            getRegisterSendList();
        }
        catch (Exception ex)
        {
            pnSuccess.Visible = false;
            pnError.Visible = true;
            lblError.Text = ex.Message;
        }
    }

    protected void getRegisterSendList()
    {
        try
        {
            cateBUs = new CategoryBUS();
            srBUS = new SendRegisterBUS();
            srdBus = new SendRegisterDetailBUS();
            mailConfigBus = new MailConfigBUS();
            mailGroupBus = new MailGroupBUS();
            sendContentBus = new SendContentBUS();
            dsgBus = new DetailGroupBUS();
            UserLoginDTO userLogin = getUserLogin();
            DataTable tblSendRegister = new DataTable();
            if (userLogin.DepartmentId == 1)
            {
                tblSendRegister = srBUS.GetAll();
            }
            else
            {
                tblSendRegister = srBUS.GetAll(userLogin.UserId);
            }
            if (tblSendRegister.Rows.Count > 0)
            {
                dlWaitSend.DataSource = tblSendRegister;
                dlWaitSend.DataBind();
                for (int i = 0; i < tblSendRegister.Rows.Count; i++)
                {
                    try
                    {

                        DataRow row = tblSendRegister.Rows[i];
                        int Sendtype = int.Parse(row["Sendtype"].ToString());
                        HiddenField hdfId = (HiddenField)dlWaitSend.Items[i].FindControl("hdfId");
                        hdfId.Value = row["Id"].ToString();
                        int contentId = int.Parse(row["SendContentId"].ToString());
                        //DataTable tblContent = sendContentBus.GetByID(contentId);
                        Label lblSubject = (Label)dlWaitSend.Items[i].FindControl("lblSubject");
                        //if (tblContent.Rows.Count > 0)
                        //{
                        //    lblSubject.Text = tblContent.Rows[0]["Subject"].ToString();
                        //}
                        //else 
                        lblSubject.Text = row["Subject"] + "";

                        int mailConfig = int.Parse(row["MailConfigID"].ToString());
                        DataTable tblMailConfig = mailConfigBus.GetByID(mailConfig);
                        if (tblMailConfig.Rows.Count > 0)
                        {
                            Label lblMailConfig = (Label)dlWaitSend.Items[i].FindControl("lblMailConfig");
                            lblMailConfig.Text = tblMailConfig.Rows[0]["Email"].ToString();
                        }
                        int groupTo = int.Parse(row["GroupTo"].ToString());
                        if (groupTo == -3)
                        {
                            Label lblGroupTo = (Label)dlWaitSend.Items[i].FindControl("lblGroupTo");
                            lblGroupTo.Text = "Tất cả khách hàng";
                        }
                        else if (groupTo == -2)
                        {
                            Label lblGroupTo = (Label)dlWaitSend.Items[i].FindControl("lblGroupTo");
                            lblGroupTo.Text = "Nhóm mua nhiều lần";
                        }
                        else if (groupTo == -1)
                        {
                            Label lblGroupTo = (Label)dlWaitSend.Items[i].FindControl("lblGroupTo");
                            lblGroupTo.Text = "Nhóm mua lần đầu";
                        }
                        else
                        {
                            DataTable tblGroupTo = new DataTable();
                            if (Sendtype == 1)
                            {
                                tblGroupTo = mailGroupBus.GetByID(groupTo);

                                if (tblGroupTo.Rows.Count > 0)
                                {
                                    Label lblGroupTo = (Label)dlWaitSend.Items[i].FindControl("lblGroupTo");
                                    lblGroupTo.Text = tblGroupTo.Rows[0]["Name"].ToString();
                                }
                            }
                            else
                            {
                                tblGroupTo = cateBUs.GetByID(groupTo);
                                if (tblGroupTo.Rows.Count > 0)
                                {
                                    Label lblGroupTo = (Label)dlWaitSend.Items[i].FindControl("lblGroupTo");
                                    lblGroupTo.Text = tblGroupTo.Rows[0]["Title"].ToString();
                                }
                            }

                        }

                        Label lblStartDate = (Label)dlWaitSend.Items[i].FindControl("lblStartDate");
                        lblStartDate.Text = row["StartDate"].ToString();


                        Label lblEndDate = (Label)dlWaitSend.Items[i].FindControl("lblEndDate");

                        int status = int.Parse(row["Status"].ToString());

                        Panel panel = (Panel)dlWaitSend.Items[i].FindControl("Panel1");
                        TextBox progressbar = (TextBox)dlWaitSend.Items[i].FindControl("progressbar");
                        LinkButton lbtDetail = (LinkButton)dlWaitSend.Items[i].FindControl("lbtDetail");

                        //get list detail
                        DataTable listDetail = srdBus.GetByID(int.Parse(row["Id"].ToString()));
                        int hasSend = 0, sumSend = dsgBus.GetByID(groupTo).Rows.Count;
                        for (int k = 0; k < listDetail.Rows.Count; k++)
                        {
                            hasSend++;
                        }

                        //calc percent has send
                        int percent = 0;
                        if (sumSend != 0)
                        {
                            percent = (hasSend * 100) / sumSend;
                        }

                        if (status == 0)
                        {
                            //display process bar
                            panel.Visible = true;
                            progressbar.BackColor = System.Drawing.Color.Cornsilk;
                            progressbar.Width = percent + 20;
                            progressbar.Text = percent + "%";

                            lbtDetail.Visible = false;
                            lbtDetail.Text = "";
                            lblEndDate.Text = "Chưa xác định ";
                        }
                        else
                        {
                            //hidden process bar
                            panel.Visible = false;
                            lbtDetail.Text = "Xem chi tiết";
                            lbtDetail.PostBackUrl = "reportSend.aspx?campaign-id=" + row["Id"].ToString();
                            lblEndDate.Text = row["EndDate"].ToString();
                        }

                        LinkButton lbtDelete = (LinkButton)dlWaitSend.Items[i].FindControl("lbtDelete");
                        lbtDelete.CommandArgument = row["Id"].ToString();
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }

        }
        catch (Exception)
        {


        }
    }

    protected void lbtExecute_Click(object sender, EventArgs e)
    {
        try
        {
            DataListItem footer = (DataListItem)dlWaitSend.Controls[dlWaitSend.Controls.Count - 1];
            DropDownList drlType = (DropDownList)footer.FindControl("drlType");
            Label lblMessage = (Label)footer.FindControl("lblMessage");
            if (drlType.SelectedValue == "1")
            {
                int countDelete = 0;
                for (int i = 0; i < dlWaitSend.Items.Count; i++)
                {
                    DataListItem item = dlWaitSend.Items[i];
                    HiddenField id = (HiddenField)item.FindControl("hdfId");
                    CheckBox chkXoa = (CheckBox)item.FindControl("chkCheck");
                    srBUS = new SendRegisterBUS();
                    if (chkXoa.Checked == true)
                    {
                        ConnectionData.OpenMyConnection();
                        srBUS.tblSendRegister_Delete(int.Parse(id.Value.ToString()));
                        ConnectionData.CloseMyConnection();
                        countDelete++;
                    }
                }
                getRegisterSendList();
                lblMessage.Text = countDelete.ToString();

            }

        }
        catch (Exception ex)
        {
            pnError.Visible = true;
            lblError.Text = ex.Message;
        }

    }

    private void LoadDataListContent()
    {
        srBUS = new SendRegisterBUS();
        this.dlWaitSend.DataSource = srBUS.GetWailSend(DateTime.Now);
        this.dlWaitSend.DataBind();
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        getRegisterSendList();
    }
    protected void LoadCurrentDate()
    {
        DateTime d = DateTime.Now;
        string[] thu = { " Chủ nhật", " Thứ hai", " Thứ ba", " Thứ tư", "Thứ năm", " Thứ sáu", " Thứ bảy" };
        int i = d.DayOfWeek.GetHashCode();
        string currentDate = "Hôm nay: " + thu[i] + ", ngày " + d.ToShortDateString() + ", hiện tại là: " + d.ToLongTimeString(); ;

    }
}
