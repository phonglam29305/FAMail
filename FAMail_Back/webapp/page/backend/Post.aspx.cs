using Email;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webapp_Post : System.Web.UI.Page
{
    baivietBUS bv = new baivietBUS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDDl();
        }
        btncapnhat.Visible = false;
    }
    private void LoadDDl()
    {
        string sql = "SELECT * FROM tblGroupConfig";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        ddlGroup.DataSource = table;
        ddlGroup.DataTextField = "groupName";
        ddlGroup.DataValueField = "idGroup";
        ddlGroup.DataBind();
        dtbaiviet.DataSource = bv.getallconfig().DefaultView;
        dtbaiviet.DataBind();
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (fUlIcon.HasFile)
        {
            string Title = txtTitle.Text.Trim();
            string fileName = fUlIcon.PostedFile.FileName;
            string path = Server.MapPath("../../../images/");
            fUlIcon.SaveAs(path + fileName);
            string Desc = txtDescription.Text;
            string Content = txtContent.Text;
            string idGroup = ddlGroup.SelectedValue.ToString();
            string key = GenerateRandomPassword(6);
            string today = DateTime.Now.ToShortDateString();
            string link = txtLink.Text;
            if (link.Length <= 0)
            {
                link = GenerateURL(ConvertTitle(Title), key).ToString();
            }
            if (ConnectionData._MyConnection.State == ConnectionState.Closed)
            {
                ConnectionData._MyConnection.Open();
            }
            string sql = "Insert Into tblConfig ([key],keyName,keyDescription,keyImage,value,link,idGroup,createDate) values (@key,@keyName,@keyDescription,@keyImage,@value,@link,@idGroup,@createDate) ";
            SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@key", SqlDbType.NVarChar).Value = key;
            cmd.Parameters.Add("@keyName", SqlDbType.NVarChar).Value = Title;
            cmd.Parameters.Add("@keyDescription", SqlDbType.NVarChar).Value = Desc;
            cmd.Parameters.Add("@keyImage",SqlDbType.NVarChar).Value ="/images/"+ fileName;
            cmd.Parameters.Add("@value", SqlDbType.NVarChar).Value = Content;
            cmd.Parameters.Add("@link", SqlDbType.NVarChar).Value = link;
            cmd.Parameters.Add("@idGroup", SqlDbType.NVarChar).Value = idGroup;
            cmd.Parameters.Add("@createDate", SqlDbType.Date).Value = today;
            cmd.ExecuteNonQuery();
            Response.Redirect("Post.aspx");
        }
        else
        {
            string Title = txtTitle.Text.Trim();
            string Desc = txtDescription.Text;
            string Content = txtContent.Text;
            string idGroup = ddlGroup.SelectedValue.ToString();
            string key = GenerateRandomPassword(6);
            string today = DateTime.Now.ToShortDateString();
            string link = txtLink.Text;
            if (link.Length <= 0)
            {
                link = GenerateURL(ConvertTitle(Title), key).ToString();
            }
            if (ConnectionData._MyConnection.State == ConnectionState.Closed)
            {
                ConnectionData._MyConnection.Open();
            }
            string sql = "Insert Into tblConfig ([key],keyName,keyDescription,value,link,idGroup,createDate) values (@key,@keyName,@keyDescription,@value,@link,@idGroup,@createDate) ";
            SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@key", SqlDbType.NVarChar).Value = key;
            cmd.Parameters.Add("@keyName", SqlDbType.NVarChar).Value = Title;
            cmd.Parameters.Add("@keyDescription", SqlDbType.NVarChar).Value = Desc;
            cmd.Parameters.Add("@value", SqlDbType.NVarChar).Value = Content;
            cmd.Parameters.Add("@link", SqlDbType.NVarChar).Value = link;
            cmd.Parameters.Add("@idGroup", SqlDbType.NVarChar).Value = idGroup;
            cmd.Parameters.Add("@createDate", SqlDbType.Date).Value = today;
            cmd.ExecuteNonQuery();
            Response.Redirect("Post.aspx");
        }
    }
    public static string GenerateRandomPassword(int length)
    {
        string allowedLetterChars = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";
        string allowedNumberChars = "0123456789";
        char[] chars = new char[length];
        Random rd = new Random();
        bool useLetter = true;
        for (int i = 0; i < length; i++)
        {
            if (useLetter)
            {
                chars[i] = allowedLetterChars[rd.Next(0, allowedLetterChars.Length)];
                useLetter = false;
            }
            else
            {
                chars[i] = allowedNumberChars[rd.Next(0, allowedNumberChars.Length)];
                useLetter = true;
            }
        }
        return new string(chars);
    }
    public static string ConvertTitle(object Title)
    {
        string stTitle = Title.ToString();
        stTitle = ConvertVN(stTitle).ToLower();
        stTitle = stTitle.Replace(" ", "-");
        stTitle = stTitle.Replace(":", "");
        stTitle = stTitle.Replace(",", "");
        return stTitle;
    }
    public static string ConvertVN(string chucodau)
    {
        const string FindText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
        const string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyaaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyy";
        int index = -1;
        char[] arrChar = FindText.ToCharArray();
        while ((index = chucodau.IndexOfAny(arrChar)) != -1)
        {
            int index2 = FindText.IndexOf(chucodau[index]);
            chucodau = chucodau.Replace(chucodau[index], ReplText[index2]);
        }
        return chucodau;
    }
    public static string GenerateURL(string Title, string strId)
    {
        string strTitle = Title.ToString();
        #region Generate SEO Friendly URL based on Title
        //Trim Start and End Spaces.
        strTitle = strTitle.Trim();
        //Trim "-" Hyphen
        strTitle = strTitle.Trim('-');
        strTitle = strTitle.ToLower();
        char[] chars = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();
        strTitle = strTitle.Replace("c#", "C-Sharp");
        strTitle = strTitle.Replace("vb.net", "VB-Net");
        strTitle = strTitle.Replace("asp.net", "Asp-Net");
        //Replace . with - hyphen
        strTitle = strTitle.Replace(".", "-");
        //Replace Special-Characters
        for (int i = 0; i < chars.Length; i++)
        {
            string strChar = chars.GetValue(i).ToString();
            if (strTitle.Contains(strChar))
            {
                strTitle = strTitle.Replace(strChar, string.Empty);
            }
        }
        //Replace all spaces with one "-" hyphen
        strTitle = strTitle.Replace(" ", "-");
        //Replace multiple "-" hyphen with single "-" hyphen.
        strTitle = strTitle.Replace("--", "-");
        strTitle = strTitle.Replace("---", "-");
        strTitle = strTitle.Replace("----", "-");
        strTitle = strTitle.Replace("-----", "-");
        strTitle = strTitle.Replace("----", "-");
        strTitle = strTitle.Replace("---", "-");
        strTitle = strTitle.Replace("--", "-");
        //Run the code again...
        //Trim Start and End Spaces.
        strTitle = strTitle.Trim();
        //Trim "-" Hyphen
        strTitle = strTitle.Trim('-');
        #endregion
        //Append ID at the end of SEO Friendly URL
        strTitle =  strTitle + "-" + strId + ".html";
        return strTitle;
    }
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btn = sender as ImageButton;
        string id = btn.CommandArgument;
        //Response.Redirect("Post.aspx?key=" + id);
        DataTable table = bv.getbykey(id);
        if (table.Rows.Count > 0)
        {
            txtTitle.Text = table.Rows[0]["keyName"].ToString();
            txtLink.Text = table.Rows[0]["link"].ToString();
            txtDescription.Text = table.Rows[0]["keyDescription"].ToString();
            txtContent.Text = table.Rows[0]["value"].ToString();
            Label1.Text = table.Rows[0]["key"].ToString();
        }
        btnSubmit.Visible = false;
        btncapnhat.Visible = true;
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        string  key = ((ImageButton)sender).CommandArgument.ToString();
        int i = 0;
        try
        {
            if (ConnectionData._MyConnection.State == ConnectionState.Closed)
            {
                ConnectionData._MyConnection.Open();
            }
            SqlCommand cmd = new SqlCommand("DELETE FROM tblconfig WHERE [key] =@key",
                ConnectionData._MyConnection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@key", SqlDbType.NVarChar).Value =key;
            i = cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            ConnectionData._MyConnection.Close();
        }
        //return i > 0;
        LoadDDl();

    }
    protected void btncapnhat_Click(object sender, EventArgs e)
    {
        //string sql = "update tblConfig set (keyName,keyDescription,value,link,idGroup,createDate) values (@key,@keyName,@keyDescription,@value,@link,@idGroup,@createDate) ";
        //string Title = txtTitle.Text.Trim();
        //string Desc = txtDescription.Text;
        //string Content = txtContent.Text;
        //string idGroup = ddlGroup.SelectedValue.ToString();
        //string key = GenerateRandomPassword(6);
        //string today = DateTime.Now.ToShortDateString();
        //string link = txtLink.Text;
        //string sql = "update tblConfig set " +
        //    "keyName=@keyName," +
        //    "keyDescription=@keyDescription," +
        //    "value=@value," +
        //    "link=@link," +
        //    "idGroup=@idGroup," +
        //    "where [key]=@key";
        //SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        //cmd.CommandType = CommandType.Text;
        //cmd.Parameters.Add("@key", SqlDbType.NVarChar).Value = key;
        //cmd.Parameters.Add("@keyName", SqlDbType.NVarChar).Value = Title;
        //cmd.Parameters.Add("@keyDescription", SqlDbType.NVarChar).Value = Desc;
        //cmd.Parameters.Add("@value", SqlDbType.NVarChar).Value = Content;
        //cmd.Parameters.Add("@link", SqlDbType.NVarChar).Value = link;
        //cmd.Parameters.Add("@idGroup", SqlDbType.NVarChar).Value = idGroup;
        //cmd.ExecuteNonQuery();
        //Response.Redirect("Post.aspx");
        if (fUlIcon.HasFile)
        {
            string Title = txtTitle.Text.Trim();
            string fileName = fUlIcon.PostedFile.FileName;
            string path = Server.MapPath("../../../images/");
            fUlIcon.SaveAs(path + fileName);
            string Desc = txtDescription.Text;
            string Content = txtContent.Text;
            string idGroup = ddlGroup.SelectedValue.ToString();
            string key = Label1.Text;
            string today = DateTime.Now.ToShortDateString();
            string link = txtLink.Text;
            if (link.Length <= 0)
            {
                link = GenerateURL(ConvertTitle(Title), key).ToString();
            }
            string sql = "update tblConfig set keyName=@keyName,keyDescription=@keyDescription,value=@value,link=@link,idGroup=@idGroup where [key]=@key";
            SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@key", SqlDbType.NVarChar).Value = key;
            cmd.Parameters.Add("@keyName", SqlDbType.NVarChar).Value = Title;
            cmd.Parameters.Add("@keyDescription", SqlDbType.NVarChar).Value = Desc;
            cmd.Parameters.Add("@keyImage", SqlDbType.NVarChar).Value = "/images/" + fileName;
            cmd.Parameters.Add("@value", SqlDbType.NVarChar).Value = Content;
            cmd.Parameters.Add("@link", SqlDbType.NVarChar).Value = link;
            cmd.Parameters.Add("@idGroup", SqlDbType.NVarChar).Value = idGroup;
            cmd.Parameters.Add("@createDate", SqlDbType.Date).Value = today;
            cmd.ExecuteNonQuery();
            Response.Redirect("Post.aspx");
        }
        else
        {
            string Title = txtTitle.Text.Trim();
            string Desc = txtDescription.Text;
            string Content = txtContent.Text;
            string idGroup = ddlGroup.SelectedValue.ToString();
            string key = Label1.Text;
            string today = DateTime.Now.ToShortDateString();
            string link = txtLink.Text;
            if (link.Length <= 0)
            {
                link = GenerateURL(ConvertTitle(Title), key).ToString();
            }
            string sql = "update tblConfig set keyName=@keyName,keyDescription=@keyDescription,value=@value,link=@link,idGroup=@idGroup where [key]=@key";
            SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@key", SqlDbType.NVarChar).Value = key;
            cmd.Parameters.Add("@keyName", SqlDbType.NVarChar).Value = Title;
            cmd.Parameters.Add("@keyDescription", SqlDbType.NVarChar).Value = Desc;
            cmd.Parameters.Add("@value", SqlDbType.NVarChar).Value = Content;
            cmd.Parameters.Add("@link", SqlDbType.NVarChar).Value = link;
            cmd.Parameters.Add("@idGroup", SqlDbType.NVarChar).Value = idGroup;
            cmd.Parameters.Add("@createDate", SqlDbType.Date).Value = today;
            cmd.ExecuteNonQuery();
            Response.Redirect("Post.aspx");
        }
    }
}