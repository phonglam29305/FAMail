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

public partial class tinh_nang_he_thong_register : System.Web.UI.Page
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
            lblTenGoiMail.Text = table.Rows[0]["packageName"].ToString();
            lbdiengiai.Text = table.Rows[0]["Description"].ToString();
            lbtotalfree.Text = table.Rows[0]["totalFee"].ToString();


            Drpacketime.DataTextField = "MonthText";
            Drpacketime.DataValueField = "discount";
            DataTable Time = dk.Getpackagetime();
            DataColumn col = new DataColumn("MonthText", typeof(string));
            Time.Columns.Add(col);
            foreach (DataRow r in Time.Rows)
            {
                r["MonthText"] = Convert.ToInt32(r["monthcount"]).ToString("00' tháng'");
            }
            Drpacketime.DataSource = Time;
            Drpacketime.DataBind();

            lbtongphi.Text = Convert.ToInt32(table.Rows[0]["totalfee"]).ToString("#,#.#' $'");
        }

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
        double a = Convert.ToDouble(Drpacketime.SelectedValue.ToString());
        double b = Convert.ToDouble(lbtotalfree.Text);
        double c = b * (a) / 100;
        lbtongphi.Text = c.ToString("#,#.#' $'");

    }
    protected void Drpacketime_SelectedIndexChanged(object sender, EventArgs e)
    {
        tinhtien();
        Label5.Visible = true;
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        dk = new RegisterBUS();
        string mess = check();
        if (mess == "")
        {
            clientdto cliendto = getclient();
            ConnectionData.OpenMyConnection();
            clientRegisterdto clientRegister = new clientRegisterdto();
            clientRegister.from = DateTime.Now;
            clientRegister.to = DateTime.Now.AddDays(Convert.ToInt32(Drpacketime.SelectedItem.Text.Replace(" tháng", "")) * 30);

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
                clientRegister.limitId = Convert.ToInt32(T.Rows[0]["limitid"]);
            }
            object temp = dk.Getpackagetime().Select("monthCount=" + Drpacketime.SelectedItem.Text.Replace(" tháng", ""))[0]["packageTimeId"];
            Int32.TryParse(temp + "", out id);
            clientRegister.packageTimeId = id;

            UserLoginDTO ulDto = new UserLoginDTO();
            ulDto.Username = txtclientname.Text;
            ulDto.Password = GetMd5Hash(txtPass.Text);
            ulDto.Email = txtemail.Text;
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

                Response.Redirect("Default.aspx");
               
            }
        }
        else
        {
            lbdiengiai.Text = mess;
            lblTenGoiMail.ForeColor = System.Drawing.Color.Red;
        }
        Session["email"] = txtemail.Text;
    }
    public static string GetMd5Hash(string input)
    {
        MD5 md5Hash = MD5.Create();
        // Convert the input string to a byte array and compute the hash. 
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Create a new Stringbuilder to collect the bytes 
        // and create a string.
        StringBuilder sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data  
        // and format each one as a hexadecimal string. 
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        // Return the hexadecimal string. 
        return sBuilder.ToString();
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
        tenkh = this.txtclientname.Text;
        email = this.txtemail.Text;
        password = this.txtPass.Text.ToString().Trim();
        confilmPass = this.txtpassAgain.Text.ToString().Trim();
        Phone = this.txtphone.Text;
        address = this.txtaddress.Text;
        //captcha = this.txtbody.Text;

        if (tenkh == "" || tenkh == null)
        {
            this.txtclientname.Focus();
            return "Bạn chưa nhập tên";
        }
        else if (email == "" || email == null)
        {
            this.txtemail.Focus();
            return "Bạn chưa nhập Email";
        }
        else if (password == "" || password == null)
        {
            this.txtPass.Focus();
            return "Bạn chưa nhập mật khẩu";
        }
        else if (confilmPass == "" || confilmPass == null)
        {
            this.txtpassAgain.Focus();
            return "Bạn chưa xác nhận lại mật khẩu";
        }
        else if (Phone == "" || Phone == null)
        {
            this.txtphone.Focus();
            return "Bạn chưa nhập số điện thoại";
        }
        else if (address == "" || address == null)
        {
            this.txtaddress.Focus();
            return "Bạn chưa nhập địa chỉ";
        }
        //else if (captcha == "" || captcha == null)
        //{
        //    this.txtbody.Focus();
        //    return "Bạn chưa nhập vào mã captcha";
        //}
        else if (IsValidMail(email) == false)
        {
            this.txtemail.Focus();
            return "Bạn email của bạn không đúng định dạng";
        }
        else if (IsItNumber(Phone) == false)
        {
            this.txtphone.Focus();
            return "Bạn nhập số điện thoại không đúng định dạng";
        }
        else if (password.Equals(confilmPass) == false)
        {
            this.txtpassAgain.Focus(); ;
            return "Hai mật khẩu không trùng nhau!";

        }
        //else
        //{
        //    cptCaptcha.ValidateCaptcha(txtbody.Text.Trim());
        //    if (!cptCaptcha.UserValidated)
        //    {
        //        this.txtpassAgain.Focus();
        //        return "Mã bảo vệ không đúng";

        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}
        return "";
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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}