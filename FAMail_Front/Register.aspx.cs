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
using System.Data.SqlClient;
using System.Configuration;

public partial class Register : System.Web.UI.Page
{
    RegisterBUS dk;
    protected string packageFee;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            lbthoigian.Text = DateTime.Now.ToString("dd/MM/yyyy:hh:mm:ss");
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
                lbtotalfree.Text = dt.Rows[0]["totalFee"].ToString();

            }
        }
    }

    private double tinhtien()
    {
        double sum = 0;
        double a = Convert.ToDouble(DropDownList1.SelectedValue.ToString());
        double b = Convert.ToDouble(lbtotalfree.Text);
        if (a > 1)
        {
            string sql = "SELECT * FROM tblpackageTime Where monthCount='" + a + "'";
            SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            int discount;
            foreach (DataRow dr in table.Rows)
            {
                discount = Convert.ToInt32(dr["disCount"].ToString());
                sum = ((b - (b * discount) / 100)*a);
            }
        }
        else
        {
            int packageid = Convert.ToInt32(Request.QueryString["packageId"]);
            dk = new RegisterBUS();
            DataTable dt = dk.GetByUserId(packageid);
            foreach (DataRow dr in dt.Rows)
            {
                sum = Convert.ToInt32(dr["totalFee"].ToString());

            }
        }
        return sum;
    }
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

        int time = Convert.ToInt32(DropDownList1.SelectedValue);
        int sum = fee * time;

        double LastFee = tinhtien();
        lblCost.Text = "Phí dịch vụ là: " + LastFee + " $";
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
                clientRegister.limitId = Convert.ToInt32(T.Rows[0]["limitId"]);

            }
            object temp = dk.Getpackagetime();
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
                //mail.From = new MailAddress("customersevices@fastautomaticmail.com",
                //" Hệ Thống FA MAIL  ", System.Text.Encoding.UTF8);
                mail.From = new MailAddress(ConfigurationManager.AppSettings["SystemOutEmail"].ToString(), "Hệ Thống FA MAIL ", System.Text.Encoding.UTF8);
                Byte i;
                for (i = 0; i < addr.Length; i++)
                    mail.To.Add(addr[i]);
                mail.Subject = "Thư xác nhận";
                mail.IsBodyHtml = true;
                mail.Body += "<html>  <body><table class='auto-style1'> <tr><td>Chào " + txtUserName.Text + " Thân mến! </td></tr><tr><td>Chúc mừng bạn đã đăng ký thành công gói " + lblTenGoi.Text + " của FA Mail </td></tr><tr><td>Thông tin tài khoản đăng nhập</td></tr><tr><td> Email đăng nhập: '" + txtEmail.Text + "'</td></tr><tr><td>Link tới trang login: http://emailmarketing.1onlinebusinesssystem.com/webapp/page/backend/login.aspx </td></tr><tr> <td> Trân trọng,</td</tr> <tr> <td>Customer services</td</tr><tr><td> Email:suppor@fastautomaticmail.com</td></tr></table></body>  ";
                mail.Body += "</html>";
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.ReplyTo = new MailAddress(txtEmail.Text);
                SmtpServer.Send(mail);


                SmtpClient SmtpServer1 = new SmtpClient();
                SmtpServer1.Credentials = new System.Net.NetworkCredential("AKIAIGXHHO72FHXGCPFQ", "Ara8HV/kcfjNU+rqrTpJBAAjs/OsD1xEykLsuguqpe1Z");
                SmtpServer1.Port = 25;
                SmtpServer1.Host = "email-smtp.us-east-1.amazonaws.com";
                SmtpServer1.EnableSsl = true;
                MailMessage mail1 = new MailMessage();
                String[] addr1 = txtmail.Text.Split(' ');
                //mail.From = new MailAddress("customersevices@fastautomaticmail.com",
                //" Hệ Thống FA MAIL  ", System.Text.Encoding.UTF8);
                mail1.From = new MailAddress(ConfigurationManager.AppSettings["SystemOutEmail"].ToString(), "Hệ Thống FA MAIL ", System.Text.Encoding.UTF8);
                Byte a;
                for (a = 0; a < addr1.Length; a++)
                    mail1.To.Add(addr1[a]);
                
                mail1.Subject = "Thong tin khachs hang dang ky";
                mail1.IsBodyHtml = true;
                mail1.Body += "<html>  <body><table class='auto-style1'> <tr><td>Chào " + txtUserName.Text + " Thân mến! </td></tr><tr><td>Khách hàng đăng ký thành công gói " + lblTenGoi.Text + " của FA Mail </td></tr><tr><td>Thông tin tài khoản đăng nhập</td></tr><tr><td> Email đăng nhập: '" + txtEmail.Text + "'</td></tr><tr><td>Ngày đăng ký: "+ lbthoigian.Text +"</td></tr><tr> <td> Trân trọng,</td</tr> <tr> <td>Customer services</td</tr><tr><td> Email:suppor@fastautomaticmail.com</td></tr></table></body>  ";
                mail1.Body += "</html>";
                mail1.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail1.ReplyTo = new MailAddress(ConfigurationManager.AppSettings["SysteminEmail"].ToString());
                SmtpServer1.Send(mail1);
                //Response.Redirect("success.aspx?id=" + idpackage);
            }
        }
        else
        {
            lblError.Text = mess;
            lblError.ForeColor = System.Drawing.Color.Red;
        }
        Session["username"] = txtUserName.Text;

    }
    private bool checkemail(string Email)
    {
        dk = new RegisterBUS();
        DataTable data = dk.kiemtramail(Email);
        if (data.Rows.Count > 0)
        {
            return true;
        }
        return false;
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
        else if (password.Equals(confilmPass) == false)
        {
            this.txtConfirmPass.Focus(); ;
            return "Hai mật khẩu không trùng nhau!";

        }
        else if (email == "" || email == null)
        {
            this.txtEmail.Focus();
            return "Bạn chưa nhập Email";
        }
        else if (address == "" || address == null)
        {
            this.txtDiaChi.Focus();
            return "Bạn chưa nhập địa chỉ";
        }
        else if (Phone == "" || Phone == null)
        {
            this.txtPhone.Focus();
            return "Bạn chưa nhập số điện thoại";
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
        
        else if (checkemail(txtEmail.Text))
        {
            return "Tên " + txtEmail.Text + " này đã tồn tại trong hệ thống  ";
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