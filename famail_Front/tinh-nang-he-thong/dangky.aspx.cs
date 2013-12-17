using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class tinh_nang_he_thong_Dangky : System.Web.UI.Page
{
    dangkyBUS dk;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadData();
    }
    private void LoadData()
    {
        //DataTable pakage = display.GetIdpackage_Nam();
        if (Request.QueryString["packageId"].ToString() != null)
        {
            dk= new dangkyBUS();
            string idpackage = Request.QueryString["packageId"].ToString();
            int id = Convert.ToInt32(idpackage);
            DataTable table =dk.GetByUserId(id);

            lbgoimail.Text = table.Rows[0]["packageName"].ToString();
            lbdiengiai.Text = table.Rows[0]["Description"].ToString();
        }
       

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {

    }
}