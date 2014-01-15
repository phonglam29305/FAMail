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
using System.Net.Mail;

public partial class webapp_page_backend_Customer : System.Web.UI.Page
{
    ClientBUS clientBUS = null;
    log4net.ILog logs = log4net.LogManager.GetLogger("ErrorRollingLogFileAppender");
    UserLoginDTO userLogin = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        userLogin = getUserLogin();
        if (!IsPostBack)
        {
            try
            {
                loadData();
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
        else Response.Redirect("~");//test confict
        return null;
    }
    private void loadData()
    {
        try
        {
            InitBUS();
            DataTable T = clientBUS.Search("", "", -1, false, "", "");
            dlPager.MaxPages = 1000;
            dlPager.PageSize = 50;
            dlPager.DataSource = T.DefaultView;
            dlPager.BindToControl = dtlCustomer;
            this.dtlCustomer.DataSource = dlPager.DataSourcePaged;
            this.dtlCustomer.DataBind();
        }
        catch (Exception ex)
        { logs.Error(userLogin.Username+"-Client - LoadData", ex); }
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        try{
        InitBUS();
        int sex = 0;
        sex = int.Parse(dlGioiTinh.SelectedValue.ToString());
        DataTable T = clientBUS.Search(txtName.Text, txtEmail.Text, sex, false, "", "");
        dlPager.MaxPages = 1000;
        dlPager.PageSize = 50;
        dlPager.DataSource = T.DefaultView;
        dlPager.BindToControl = dtlCustomer;
        this.dtlCustomer.DataSource = dlPager.DataSourcePaged;
        this.dtlCustomer.DataBind();
        }
        catch (Exception ex)
        { logs.Error(userLogin.Username+"-Client - Filter", ex); }
    }
    protected void btn_Click(object sender, CommandEventArgs e)
    {
        try
        {
            InitBUS();
            int id = int.Parse(e.CommandArgument + "");
            if (e.CommandName == "Lock")
                clientBUS.Customer_Lock_Unlock(id, Common.clientStatus.Lock);
            else
                clientBUS.Customer_Lock_Unlock(id, Common.clientStatus.Normal);
            btnFilter_Click(null, EventArgs.Empty);
        }
        catch (Exception ex)
        { logs.Error(userLogin.Username+"-Client - Lock-UnLock", ex); }
    }
    private void InitBUS()
    {
        clientBUS = new ClientBUS();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }
    protected void btnActive_Click(object sender, ImageClickEventArgs e)
    {
        InitBUS();
        int clinetId = int.Parse(((ImageButton)sender).CommandArgument.ToString());
        DataTable data = clientBUS.getallclient(clinetId);
        if (data.Rows.Count > 0)
        {
            Label8.Text = data.Rows[0]["email"].ToString();
        }
        SmtpClient SmtpServer = new SmtpClient();
        SmtpServer.Credentials = new System.Net.NetworkCredential("AKIAIGXHHO72FHXGCPFQ", "Ara8HV/kcfjNU+rqrTpJBAAjs/OsD1xEykLsuguqpe1Z");
        SmtpServer.Port = 25;
        SmtpServer.Host = "email-smtp.us-east-1.amazonaws.com";
        SmtpServer.EnableSsl = true;
        MailMessage mail = new MailMessage();
        String[] addr = Label8.Text.Split(' ');
        mail.From = new MailAddress(ConfigurationManager.AppSettings["SystemOutEmail"].ToString(), "Hệ Thống FA MAIL ", System.Text.Encoding.UTF8);
        Byte i;
        for (i = 0; i < addr.Length; i++)
            mail.To.Add(addr[i]);
        mail.Subject = "Thư xác nhận";
        mail.IsBodyHtml = true;
        mail.Body = "Tai khoan da active";
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        mail.ReplyTo = new MailAddress(Label8.Text);
        SmtpServer.Send(mail);
    }
}
