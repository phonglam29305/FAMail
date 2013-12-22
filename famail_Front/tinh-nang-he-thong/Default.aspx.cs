using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tinh_nang_he_thong_Default : System.Web.UI.Page
{
    public displayingfunctionBUS display = new displayingfunctionBUS();
    protected void Page_Load(object sender, EventArgs e)
    {
        loadData();
    }
    private void loadData()
    {
        try
        {
            DataTable pakage = display.GetAllpackeg();
            dlGoiDichVu.DataSource  = rptMain.DataSource = pakage;
            dlGoiDichVu.DataBind();
            rptMain.DataBind();
            DataTable t = display.LoadFunctionPackage(Convert.ToInt32(pakage.Rows[0]["packageId"].ToString()));
            rptNameFunction.DataSource = t.DefaultView;
            rptNameFunction.DataBind();
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("functionId", typeof(String));
            dtTemp.Columns.Add("functionName", typeof(String));
            dtTemp.Columns.Add("isUse", typeof(String));
            dtTemp.Columns.Add("orderNo", typeof(String));
            foreach (DataRow dr in pakage.Rows)
            {
                int ma = int.Parse(pakage.Rows[0]["packageId"].ToString());
                DataTable dt = display.LoadFunctionPackage(ma);
                foreach (DataRow drs2 in dt.Rows)
                {
                    DataRow drTemp = dtTemp.NewRow();
                    drTemp["functionId"] = drs2["functionId"].ToString();
                    drTemp["functionName"] = drs2["functionName"].ToString();
                    drTemp["isUse"] = drs2["isUse"].ToString();
                    drTemp["orderNo"] = drs2["orderNo"].ToString();
                    dtTemp.Rows.Add(drTemp);
                }
            }
            //rptSudungChucnang.DataSource = dtTemp;
            //rptSudungChucnang.DataBind();
        }
        catch(Exception ex)
        { 
            throw new Exception();
        }
    }
}