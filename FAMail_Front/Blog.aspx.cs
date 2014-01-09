using Email;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Blog : System.Web.UI.Page
{
    baivietBUS baiviet = new baivietBUS();
    PagedDataSource pgsource = new PagedDataSource();
    int findex, lindex;
    //protected HtmlString tagname;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadData();
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
        strTitle = strTitle + "-" + strId + ".html";
        return strTitle;
    }
    private void LoadData()
    {
        if (Request.QueryString["key"] != null)
        {
            string key = Request.QueryString["key"].ToString();
            DataTable dt = baiviet.GetalltblConfig_id(key);
            foreach (DataRow dr in dt.Rows)
            {
                ltrPost.Text = dr["value"].ToString();
                blogitemdetail.Visible = true;
                blogpage.Visible = false;
                string tag = dr["tag"].ToString();
                string[] tags = tag.Split(',');
                for (int i = 0; i < tags.Length; i++)
                {
                    ltrBlogTag.Text += "<a href='#' title='" + tags[i] + "'>" + tags[i] + "</a> ";
                }
                string sTitle = dr["keyName"].ToString();
                string strId = dr["key"].ToString();
                string host = HttpContext.Current.Request.Url.Authority;
                string path = host + "/" + GenerateURL(ConvertTitle(sTitle), strId);
                fbcomment.Attributes["data-href"] = path;
            }
        }
        else
        {
            string sql = "SELECT * FROM tblConfig Where idGroup='blog'";
            SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            int RowCount = table.Rows.Count;
            table.Columns.Add("PostTag");
            pgsource.DataSource = table.DefaultView;
            pgsource.AllowPaging = true;
            pgsource.PageSize = 5;
            pgsource.CurrentPageIndex = CurrentPage;
            ViewState["totpage"] = pgsource.PageCount;
            if (RowCount < pgsource.PageSize)
            {
                divpaging.Visible = false;
            }
            doPaging();
            string tagtemp = "";
            foreach (DataRow dr in table.Rows)
            {
                string tag = dr["tag"].ToString(); tagtemp = "";
                if (tag != "")
                {
                    string[] tags = tag.Split(',');
                    for (int i = 0; i < tags.Length; i++)
                    {
                        tagtemp += "<a href='#' title='" + tags[i] + "'>" + tags[i] + "</a> ";
                    }
                }
                dr["PostTag"] = tagtemp;
            }
            
            rptBlog.DataSource = pgsource;
            rptBlog.DataBind();
        }
    }
    private void doPaging()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("PageIndex");
        dt.Columns.Add("PageText");
        findex = CurrentPage - 2;
        if (CurrentPage > 2)
        {
            lindex = CurrentPage + 3;
        }
        else
        {
            lindex = 5;
        }
        int five = 5;
        if (lindex > Convert.ToInt32(ViewState["totpage"]))
        {
            lindex = Convert.ToInt32(ViewState["totpage"]);
            findex = lindex - five;
        }
        if (findex < 0)
        {
            findex = 0;
        }
        for (int i = findex; i < lindex; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = i;
            dr[1] = i + 1;
            dt.Rows.Add(dr);
        }
        DataListPaging.Style.Add("margin", "0px auto");
        DataListPaging.DataSource = dt;
        DataListPaging.DataBind();
    }
    private int CurrentPage
    {
        get
        {   //Check view state is null if null then return current index value as "0" else return specific page viewstate value
            if (ViewState["CurrentPage"] == null)
            {
                return 0;
            }
            else
            {
                return ((int)ViewState["CurrentPage"]);
            }
        }
        set
        {
            //Set View statevalue when page is changed through Paging DataList
            ViewState["CurrentPage"] = value;
        }
    }

    protected void DataListPaging_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.Equals("newpage"))
        {
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            LoadData();
        }
    }
    protected void DataListPaging_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        LinkButton lnkPage = (LinkButton)e.Item.FindControl("Pagingbtn");
        if (lnkPage.CommandArgument.ToString() == CurrentPage.ToString())
        {
            lnkPage.Enabled = false;
        }
    }
}