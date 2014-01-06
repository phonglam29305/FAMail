using Email;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class success : System.Web.UI.Page
{
    RegisterBUS dk;
    protected string packageFee;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadData();
    }
    private void LoadData()
    {
        if (Request.QueryString["id"] != null)
        {
            int packageid = Convert.ToInt32(Request.QueryString["id"]);
            string sql = "SELECT * FROM tblPackage Where packageId='"+packageid+"'";
            SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            foreach(DataRow dr in table.Rows)
            {
                lblPackageName.Text = table.Rows[0]["packageName"].ToString();
            }
        }
    }
}