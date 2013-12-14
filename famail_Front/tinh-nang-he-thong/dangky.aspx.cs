using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tinh_nang_he_thong_Dangky : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadData();
    }
    private void LoadData()
    {
        if (Request.QueryString["type"].ToString() != null)
        {
            string type = Request.QueryString["type"].ToString();
            Label4.Text = "Gói 100 mail";
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {

    }
}