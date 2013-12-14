using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tinh_nang_he_thong_Bang_gia : System.Web.UI.Page
{
    displayingfunctionBUS display = new displayingfunctionBUS();
 
    protected void Page_Load(object sender, EventArgs e)
    {
        loadfunction();
        loadData();
    }
    private void loadfunction()
    {
        dtfunction.DataSource = display.GetAllfunction().DefaultView;
        dtfunction.DataBind();
    }
    private void loadData()
    {
        try
        {
            int id = 6;
            //DateTime dt1 = new DateTime();
            DataTable t = display.LoadFunctionPackage(id);
            DataList2.DataSource = t.DefaultView;
            DataList2.DataBind();
            int id1 = 7;
            //DateTime dt1 = new DateTime();
            DataTable t1 = display.LoadFunctionPackage(id1);
            DataList1.DataSource = t1.DefaultView;
            DataList1.DataBind();
            int id2 = 8;
            //DateTime dt1 = new DateTime();
            DataTable t2 = display.LoadFunctionPackage(id2);
            DataList3.DataSource = t2.DefaultView;
            DataList3.DataBind();
            int id3 = 9;
            //DateTime dt1 = new DateTime();
            DataTable t3 = display.LoadFunctionPackage(id3);
            DataList4.DataSource = t3.DefaultView;
            DataList4.DataBind();

        }
        catch (Exception ex)
        {  }
    }
}