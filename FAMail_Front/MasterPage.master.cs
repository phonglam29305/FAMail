using Email;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public ViewChildBus view = new ViewChildBus();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadHeader();
            LoadFooter();
        }
    }
    private void LoadHeader()
    {
        string sql = "SELECT * FROM tblConfig Where idGroup='header'";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        rptListPost.DataSource = table;
        rptListPost.DataBind();
    }
    private void LoadFooter()
    {
        string sql = "Select * From tblGroupConfig except (Select * From tblGroupConfig Where idGroup='mainpost' OR idGroup='header')";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        DataTable dt;
        foreach (DataRow dr in table.Rows)
        {
            string idgroup = dr["idGroup"].ToString();
            SqlCommand cmd2 = new SqlCommand("Select * From tblGroupConfig Where idGroup='" + idgroup + "'", ConnectionData._MyConnection);
            cmd2.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            dt = new DataTable();
            da.Fill(dt);
        }
        rptFooter.DataSource = table;
        rptFooter.DataBind();
    }
}
