﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.IO;


public partial class webapp_template_backend_backend : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                checkRole();
                LoadCurrentDate();
                loadLimitWithUser();
                UserLoginDTO userLogin = getUserLogin();
                if (userLogin != null)
                {
                    lblInfo.Text = userLogin.Username;
                    lkClientDetail.NavigateUrl = "../../page/backend/clientdetail.aspx";
                    lkClientDetail.Visible = userLogin.DepartmentId == 2;
                    if(userLogin.UserType==0)
                    hplManager.NavigateUrl = "../../page/backend/clientregister.aspx";
                    else
                        hplManager.NavigateUrl = "../../page/backend/customer.aspx";
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
            catch (Exception)
            {
                Response.Redirect("login.aspx");
            }

        }
        
    }

    private void loadLimitWithUser()
    {
        
        //if (getUserLogin().DepartmentId == 1)
        //{
        //    hplLimit.Text = "Gửi & Tạo KH: Không giới hạn";
        //}
        //else if (getLimitWithUser() != null)
        //{
        //    hplLimit.Text = "Gửi: " + getUserLogin().hasSendMail + "/" + getLimitWithUser().limitSendMail
        //        + ", Tạo KH: " + getUserLogin().hasCreatedCustomer + "/" + getLimitWithUser().limitCreateCustomer;
        //}
        //else
        //{
        //    hplLimit.Text = "Gửi & Tạo KH: Không giới hạn";
        //}
        
    }
    private void checkRole()
    {
        try
        {
            UserLoginDTO ulDto = getUserLogin();
            foreach (Control child in ControlPanel.Controls)
            {
                if (child is HyperLink)
                {
                    HyperLink hplRole = (HyperLink)child;
                    hplRole.Visible =
                          Common.checkRoleByRoleId(int.Parse(hplRole.Attributes["roleId"]), ulDto.DepartmentId);
                }
            }
            
        }
        catch (Exception ex)
        {
        }

    }
    public string GetCurrentPageName()
    {
        string urlPath = Request.Url.AbsolutePath;
        FileInfo fileInfo = new FileInfo(urlPath);
        string pageName = fileInfo.Name;
        return pageName;
    }
    protected void LoadCurrentDate()
    {
        DateTime d = DateTime.Now;
        string[] thu = { " Chủ nhật", " Thứ hai", " Thứ ba", " Thứ tư", "Thứ năm", " Thứ sáu", " Thứ bảy" };
        int i = d.DayOfWeek.GetHashCode();
        string currentDate = "Hôm nay: " + thu[i] + ", ngày " + d.ToShortDateString() + ", hiện tại là: " + d.ToShortTimeString(); ;
        hplCurrentDate.Text = currentDate;
    }
    protected void lbtLogout_Click(object sender, EventArgs e)
    {
        Session["us-login"] = null;
        Response.Redirect("login.aspx");
    }

    private UserLoginDTO getUserLogin()
    {
        if (Session["us-login"] != null)
        {
            return (UserLoginDTO)Session["us-login"];
        }
        return null;
    }

    private RoleDetailDTO getLimitWithUser()
    {
        try
        {
            if (Session["limitWithUser"] != null)
            {
                return (RoleDetailDTO)Session["limitWithUser"];
            }
        }
        catch (Exception)
        {
            return null;
        }        
        return null;
    }
  
}
