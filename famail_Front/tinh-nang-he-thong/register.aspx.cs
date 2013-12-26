using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Email;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

public partial class tinh_nang_he_thong_Register : System.Web.UI.Page
{
    RegisterBUS dk;
    protected string packageFee;
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
            int packageid = Convert.ToInt32(Request.QueryString["packageId"]);
            dk = new RegisterBUS();
            DataTable dt = dk.GetByUserId(packageid);
            foreach (DataRow dr in dt.Rows)
            {
                lblTenGoi.Text = dr["packageName"].ToString();
                packageFee = dr["totalFee"].ToString();
                lblCost.Text = "Phí dịch vụ: " + packageFee + " $"; ;
            }
        }
    }

    //private void LoadData()
    //{
    //    if (Request.QueryString["packageId"] != null)
    //    {
    //        dk = new RegisterBUS();
    //        string idpackage = Request.QueryString["packageId"].ToString();
    //        int id = Convert.ToInt32(idpackage);
    //        DataTable table = dk.GetByUserId(id);
    //        lblTenGoiMail.Text = table.Rows[0]["packageName"].ToString();
    //        lbdiengiai.Text = table.Rows[0]["Description"].ToString();
    //        lbtotalfree.Text = table.Rows[0]["totalFee"].ToString();


    //        Drpacketime.DataTextField = "monthCount";
    //        Drpacketime.DataValueField = "discount";
    //        Drpacketime.DataSource = dk.Getpackagetime();
    //        Drpacketime.DataBind();
    //    }

    //}
    //protected void LinkButton2_Click(object sender, EventArgs e)
    //{

    //}

    //private clientdto getclient()
    //{
    //    clientdto client = new clientdto();

    //    client.clientName = txtclientname.Text;
    //    client.address = txtaddress.Text;
    //    client.email = txtemail.Text;
    //    client.phone = txtphone.Text;

    //    return client;


    //}
    //private void tinhtien()
    //{
    //    double a = Convert.ToDouble(Drpacketime.SelectedValue.ToString());
    //    double b = Convert.ToDouble(lbtotalfree.Text);
    //    double c = b * (a) / 100;
    //    lbtongphi.Text = c.ToString();

    //}
    //protected void Drpacketime_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    tinhtien();
    //    Label5.Visible = true;
    //}
    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{
    //    dk = new RegisterBUS();
    //    if (dk.CheckExistByEmail(txtemail.Text))
    //    {
    //        clientdto cliendto = getclient();
    //        ConnectionData.OpenMyConnection();
    //        clientRegisterdto clientRegister = new clientRegisterdto();
    //        clientRegister.from = DateTime.Now;
    //        clientRegister.to = DateTime.Now.AddDays(Convert.ToInt32(Drpacketime.SelectedItem.Text) * 30);

    //        string idpackage = Request.QueryString["packageId"].ToString();
    //        int id = 0;
    //        Int32.TryParse(idpackage, out id);
    //        clientRegister.packageId = id;

    //        DataTable T = dk.GetPackageById(id);
    //        if (T != null && T.Rows.Count > 0)
    //        {
    //            clientRegister.totalFee = Convert.ToDouble(T.Rows[0]["cost"]);
    //            clientRegister.subAccontCount = Convert.ToInt32(T.Rows[0]["subAccontCount"]);
    //            clientRegister.emailCount = Convert.ToInt32(T.Rows[0]["emailCount"]);
    //        }
    //        object temp = dk.Getpackagetime().Select("monthCount=" + Drpacketime.SelectedItem.Text)[0]["packageTimeId"];
    //        Int32.TryParse(temp + "", out id);
    //        clientRegister.packageTimeId = id;

    //        UserLoginDTO ulDto = new UserLoginDTO();
    //        ulDto.Username = txtclientname.Text;
    //        ulDto.Password = GetMd5Hash(txtPass.Text);
    //        ulDto.Email = txtemail.Text;
    //        ulDto.Is_Block = false;
    //        ulDto.UserType = 2;
    //        if (dk.Insert_client(cliendto, clientRegister, ulDto) > 0)
    //        {

    //            SmtpClient SmtpServer = new SmtpClient();
    //            SmtpServer.Credentials = new System.Net.NetworkCredential("AKIAIGXHHO72FHXGCPFQ", "Ara8HV/kcfjNU+rqrTpJBAAjs/OsD1xEykLsuguqpe1Z");

    //            SmtpServer.Port = 25;
    //            SmtpServer.Host = "email-smtp.us-east-1.amazonaws.com";
    //            SmtpServer.EnableSsl = true;
    //            MailMessage mail = new MailMessage();
    //            String[] addr = txtemail.Text.Split(' ');


    //            mail.From = new MailAddress("admin@fastautomaticmail.com",
    //            "Xác Nhận Từ Hệ Thống FA MAIL  ", System.Text.Encoding.UTF8);
    //            Byte i;
    //            for (i = 0; i < addr.Length; i++)
    //                mail.To.Add(addr[i]);
    //            mail.Subject = "chao mung bao";
    //            mail.Body = "Dear";
    //            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
    //            mail.ReplyTo = new MailAddress(txtemail.Text);
    //            SmtpServer.Send(mail);

    //            Response.Redirect("~");
    //        }
    //    }
    //    else
    //    {
    //        lbdiengiai.Text = "Email này đã được đăng ký!";
    //        lbdiengiai.ForeColor = System.Drawing.Color.Red;
    //    }
    //}

    public static string GetMd5Hash(string input)
    {
        MD5 md5Hash = MD5.Create();
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }
    private clientdto getclient()
    {
        clientdto client = new clientdto();
        client.clientName = txtUserName.Text;
        client.address = txtDiaChi.Text;
        client.email = txtEmail.Text;
        client.phone = txtPhone.Text;
        return client;
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int fee = 0;
        if (Request.QueryString["packageId"] != null)
        {
            int packageid = Convert.ToInt32(Request.QueryString["packageId"]);
            dk = new RegisterBUS();
            DataTable dt = dk.GetByUserId(packageid);
            foreach (DataRow dr in dt.Rows)
            {
                fee = Convert.ToInt32(dr["totalFee"].ToString());
            }
        }
        
        int time =Convert.ToInt32( DropDownList1.SelectedValue);
        int sum = fee * time;
        lblCost.Text = "Phí dịch vụ là: " + sum + " $"; ;
    }
    protected void btnRegis_Click(object sender, EventArgs e)
    {
        dk = new RegisterBUS();
        string mess = check();
        if (mess == "")
        {
            clientdto cliendto = getclient();
            ConnectionData.OpenMyConnection();
            clientRegisterdto clientRegister = new clientRegisterdto();
            clientRegister.from = DateTime.Now;
            clientRegister.to = DateTime.Now.AddDays(Convert.ToInt32(DropDownList1.SelectedValue.ToString()) * 30);

            string idpackage = Request.QueryString["packageId"].ToString();
            int id = 0;
            Int32.TryParse(idpackage, out id);
            clientRegister.packageId = id;

            DataTable T = dk.GetPackageById(id);
            if (T != null && T.Rows.Count > 0)
            {
                clientRegister.totalFee = Convert.ToDouble(T.Rows[0]["cost"]);
                clientRegister.subAccontCount = Convert.ToInt32(T.Rows[0]["subAccontCount"]);
                clientRegister.emailCount = Convert.ToInt32(T.Rows[0]["emailCount"]);
            }
            object temp = dk.Getpackagetime().Select("monthCount=" + DropDownList1.SelectedValue.ToString())[0]["packageTimeId"];
            Int32.TryParse(temp + "", out id);
            clientRegister.packageTimeId = id;

            UserLoginDTO ulDto = new UserLoginDTO();
            ulDto.Username = txtUserName.Text;
            ulDto.Password = GetMd5Hash(txtPass.Text);
            ulDto.Email = txtEmail.Text;
            ulDto.Is_Block = false;
            ulDto.UserType = 2;
            if (dk.Insert_client(cliendto, clientRegister, ulDto) > 0)
            {

                SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Credentials = new System.Net.NetworkCredential("AKIAIGXHHO72FHXGCPFQ", "Ara8HV/kcfjNU+rqrTpJBAAjs/OsD1xEykLsuguqpe1Z");
                SmtpServer.Port = 25;
                SmtpServer.Host = "email-smtp.us-east-1.amazonaws.com";
                SmtpServer.EnableSsl = true;
                MailMessage mail = new MailMessage();
                String[] addr = txtEmail.Text.Split(' ');
                mail.From = new MailAddress("admin@fastautomaticmail.com",
                "Xác Nhận Từ Hệ Thống FA MAIL  ", System.Text.Encoding.UTF8);
                Byte i;
                for (i = 0; i < addr.Length; i++)
                    mail.To.Add(addr[i]);
                mail.Subject = "chao mung bao";
                mail.Body = "<a href='Default.aspx'>";
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.ReplyTo = new MailAddress(txtEmail.Text);
                SmtpServer.Send(mail);
                Response.Redirect("~");
            }
        }
        else
        {
            lblError.Text = mess;
            lblError.ForeColor = System.Drawing.Color.Red;
        }
    }
    private string check()
    {
        string tenkh = null;
        string email = null;
        string password = null;
        string confilmPass = null;
        string Phone = null;
        string address = null;
        string captcha = null;
        tenkh = this.txtUserName.Text;
        email = this.txtEmail.Text;
        password = this.txtPass.Text.ToString().Trim();
        confilmPass = this.txtConfirmPass.Text.ToString().Trim();
        Phone = this.txtPhone.Text;
        address = this.txtDiaChi.Text;
        captcha = this.txtCapt.Text;
        if (tenkh == "" || tenkh == null)
        {
            this.txtUserName.Focus();
            return "Bạn chưa nhập tên";
        }
        else if (email == "" || email == null)
        {
            this.txtEmail.Focus();
            return "Bạn chưa nhập Email";
        }
        else if (password == "" || password == null)
        {
            this.txtPass.Focus();
            return "Bạn chưa nhập mật khẩu";
        }
        else if (confilmPass == "" || confilmPass == null)
        {
            this.txtConfirmPass.Focus();
            return "Bạn chưa xác nhận lại mật khẩu";
        }
        else if (Phone == "" || Phone == null)
        {
            this.txtPhone.Focus();
            return "Bạn chưa nhập số điện thoại";
        }
        else if (address == "" || address == null)
        {
            this.txtDiaChi.Focus();
            return "Bạn chưa nhập địa chỉ";
        }
        else if (captcha == "" || captcha == null)
        {
            this.txtCapt.Focus();
            return "Bạn chưa nhập vào mã captcha";
        }
        else if (IsValidMail(email) == false)
        {
            this.txtEmail.Focus();
            return "Bạn email của bạn không đúng định dạng";
        }
        else if (IsItNumber(Phone) == false)
        {
            this.txtPhone.Focus();
            return "Bạn nhập số điện thoại không đúng định dạng";
        }
        else if (password.Equals(confilmPass) == false)
        {
            this.txtConfirmPass.Focus(); ;
            return "Hai mật khẩu không trùng nhau!";

        }
        else
        {
            return "";
        }
    }
    public bool IsValidMail(string emailaddress)
    {
        try
        {
            MailAddress m = new MailAddress(emailaddress);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
    public bool IsItNumber(string inputvalue)
    {
        Regex isnumber = new Regex("[^0-9]");
        return !isnumber.IsMatch(inputvalue);
    }
}