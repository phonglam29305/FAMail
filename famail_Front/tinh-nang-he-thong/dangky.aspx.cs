using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Email;
using System.Net.Mail;

public partial class tinh_nang_he_thong_Dangky : System.Web.UI.Page
{
    RegisterBUS dk;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    private void LoadData()
    {
        if (Request.QueryString["packageId"] != null)
        {
            dk = new RegisterBUS();
            string idpackage = Request.QueryString["packageId"].ToString();
            int id = Convert.ToInt32(idpackage);
            DataTable table = dk.GetByUserId(id);
            lbgoimail.Text = table.Rows[0]["packageName"].ToString();
            lbdiengiai.Text = table.Rows[0]["Description"].ToString();
            lbtotalfree.Text = table.Rows[0]["totalFee"].ToString();


        Drpacketime.DataTextField = "monthCount";
        Drpacketime.DataValueField = "packageTimeId";
        Drpacketime.DataSource = dk.Getpackagetime();
        Drpacketime.DataBind();
        }

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {

    }

    private clientdto getclient()
    {
        clientdto client = new clientdto();

        client.clientName = txtclientname.Text;
        client.address = txtaddress.Text;
        client.email = txtemail.Text;
        client.phone = txtphone.Text;

        return client;


    }
    private void tinhtien()
    {
        double a = Convert.ToDouble(Drpacketime.SelectedItem.Text.ToString());
        double b = Convert.ToDouble(lbtotalfree.Text);
        double c = b * (a) / 100;
        lbtongphi.Text = c.ToString();

    }
    protected void Drpacketime_SelectedIndexChanged(object sender, EventArgs e)
    {
        tinhtien();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        clientdto cliendto = getclient();
        ConnectionData.OpenMyConnection();
        dk = new RegisterBUS();
        clientRegisterdto clientRegister = new clientRegisterdto();
        clientRegister.from = DateTime.Now;
        clientRegister.to = DateTime.Now.AddDays(Convert.ToInt32(Drpacketime.SelectedItem.Text) * 30);

        string idpackage = Request.QueryString["packageId"].ToString();
        int id = 0;
        Int32.TryParse(idpackage, out id);
        clientRegister.packageId = id;

        DataTable T =dk.GetPackageById(id);
        if (T != null && T.Rows.Count > 0)
        {clientRegister.totalFee = Convert.ToDouble(T.Rows[0]["cost"]);
        clientRegister.subAccontCount = Convert.ToInt32(T.Rows[0]["subAccontCount"]);
        }
        Int32.TryParse(Drpacketime.SelectedValue, out id);
        clientRegister.packageTimeId = id;

        dk.Insert_client(cliendto,clientRegister);


        SmtpClient SmtpServer = new SmtpClient();
        SmtpServer.Credentials = new System.Net.NetworkCredential("AKIAIGXHHO72FHXGCPFQ", "Ara8HV/kcfjNU+rqrTpJBAAjs/OsD1xEykLsuguqpe1Z");

        SmtpServer.Port = 25;
        SmtpServer.Host = "email-smtp.us-east-1.amazonaws.com";
        SmtpServer.EnableSsl = true;
        MailMessage mail = new MailMessage();
        String[] addr = txtemail.Text.Split(' ');


        mail.From = new MailAddress("admin@fastautomaticmail.com",
        "Xác Nhận Từ Hệ Thống FA MAIL  ", System.Text.Encoding.UTF8);
        Byte i;
        for (i = 0; i < addr.Length; i++)
            mail.To.Add(addr[i]);
        mail.Subject = "chao mung bao";
        mail.Body = "Dear";
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        mail.ReplyTo = new MailAddress(txtemail.Text);
        SmtpServer.Send(mail);


    }
}