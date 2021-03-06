﻿using System;
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
    EventBUS eventBus = null;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnContinute_Click(object sender, EventArgs e)
    {
        try
        {
            String htmlForm = getHTMLCode();
            lblHTML.Visible = true;
            txtHTML.Text = htmlForm;
            txtHTML.Visible = true;
        }
        catch (Exception)
        {
            
         
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
    protected String getHTMLCode()
    {
        try
        {
            int eventId = int.Parse(Session["eventId"].ToString());
            int groupId = int.Parse(Session["GroupId"].ToString());
            int UserID = getUserLogin().UserId;
            string requireTime = Session["RequireTime"]+"";

            eventBus = new EventBUS();
            DataTable tblEvent = eventBus.GetByID(eventId);

            String visibleField = "";
            String rowVisible = "";
            Hashtable htVisibleField = getVisibleField();            
            foreach (DictionaryEntry entry in htVisibleField)
            {
                visibleField += entry.Key+" ";
                rowVisible += "<tr>\n";
                rowVisible += String.Format("<td>{0}</td>\n", entry.Value);           
                rowVisible +="</tr>";
                rowVisible += "<tr>\n";
                rowVisible += String.Format("<td><input name=\"{0}\" id=\"{0}\" type=\"text\" size=\"40\" /></td>\n", entry.Key);
                rowVisible += "</tr>";
            }
            rowVisible += "<tr align=\"center\">\n";
            rowVisible += "<td><input name=\"btnSubmit\" id=\"btnSubmit\" type=\"submit\" value=\"Đăng ký\" /></td>\n";
            rowVisible += "</tr>\n";

            String rs = "";
            rs += "<form id=\"form1\" method=\"post\" action=\"http://emailmarketing.1onlinebusinesssystem.com/webapp/page/backend/register-event.aspx\" accept-charset=\"UTF-8\">\n";
            //rs += "<form id=\"form1\" method=\"post\" action=\"http://localhost:40025/FAMail_Back/webapp/page/backend/register-event.aspx\" accept-charset=\"UTF-8\">\n";
            rs += String.Format("<input name=\"UserId\" id=\"UserId\" type=\"hidden\" value=\"{0}\" />\n", UserID);
            rs += String.Format("<input name=\"eventId\" id=\"eventId\" type=\"hidden\" value=\"{0}\" />\n", eventId);
            rs += String.Format("<input name=\"visibleField\" id=\"visibleField\" type=\"hidden\" value=\"{0}\" />\n", visibleField.Trim());
            rs += String.Format("<input name=\"groupId\" id=\"groupId\" type=\"hidden\" value=\"{0}\" />\n", groupId);
            rs += String.Format("<input name=\"startDate\" id=\"startDate\" type=\"hidden\" value=\"{0}\" />\n", tblEvent.Rows[0]["StartDate"]);
            rs += String.Format("<input name=\"endDate\" id=\"endDate\" type=\"hidden\" value=\"{0}\" />\n", tblEvent.Rows[0]["EndDate"]);
            rs += String.Format("<input name=\"requireTime\" id=\"requireTime\" type=\"hidden\" value=\"{0}\" />\n", requireTime.Trim());       
            rs += "<table>\n";
            rs += rowVisible;
            rs += "</table>\n";
            rs += "</form>\n";
            return rs;
        }
        catch (Exception)
        {

            return null;
        }
    }
    protected Hashtable getVisibleField()
    {
        Hashtable visibleField = new Hashtable();
        if (rdoName2.Checked == true)
        {
            visibleField.Add("Name", "Họ tên");
        }
        visibleField.Add("Email", "Email");
        if (rdoJob2.Checked == true)
        {
            visibleField.Add("Job", "Nghề nghiệp");
        }
        if (rdoCampany2.Checked == true)
        {
            visibleField.Add("Company", "Công ty");
        }
        if (rdoGender2.Checked == true)
        {
            visibleField.Add("Gender", "Giới tính");
        }
        if (rdoPhone2.Checked == true)
        {
            visibleField.Add("Phone", "Điện thoại");
        } 
        if (rdoSecondPhone2.Checked == true)
        {
            visibleField.Add("SecondPhone", "Điện thoại khác");
        }
        if (rdoAddress2.Checked == true)
        {
            visibleField.Add("Address1", "Địa chỉ");
        }
        if (rdoAddressTwo2.Checked == true)
        {
            visibleField.Add("Address2", "Địa chỉ liên lạc");
        }
        if (rdoCity2.Checked == true)
        {
            visibleField.Add("City", "Thành phố");
        }
        if (rdoProvince2.Checked == true)
        {
            visibleField.Add("Province", "Quận/Huyện");
        }
        if (rdoZipCode2.Checked == true)
        {
            visibleField.Add("ZipCode", "Mã vùng");
        }
        if (rdoCountry2.Checked == true)
        {
            visibleField.Add("Country", "Quốc gia");
        }
        if (rdoFax2.Checked == true)
        {
            visibleField.Add("Fax", "Fax");
        }

        return visibleField;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }
    protected void btnBackEvent_Click(object sender, EventArgs e)
    {
        Response.Redirect("create-event.aspx");
    }

    public string bankimage(string email)
    {
        return "";
    }
}
