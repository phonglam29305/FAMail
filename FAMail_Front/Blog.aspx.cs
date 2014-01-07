using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Blog : System.Web.UI.Page
{
    baivietBUS baiviet = new baivietBUS();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadData();
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
            }
        }
    }
}