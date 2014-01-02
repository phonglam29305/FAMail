using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Post : System.Web.UI.Page
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
            DataTable table = baiviet.GetalltblConfig_id(key);
            DataRow dr1 = table.NewRow();
            dr1["id"] = 0;
            dr1["idGroup"] = "";
            table.Rows.InsertAt(dr1, 0);
            rtmenu.DataSource = table.DefaultView;
            rtmenu.DataBind();
            foreach (DataRow dr in dt.Rows)
            {
                ltrPost.Text = dr["value"].ToString();
                string groupId = dr["idGroup"].ToString();
                DataTable dtList = new DataTable();
                dtList = baiviet.Getalltblconfig_idgroup(groupId);
                rtmenu.DataSource = dtList;
                rtmenu.DataBind();
            }
        }
    }
}