using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tinh_nang_he_thong_Bang_gia : System.Web.UI.Page
{
   public  displayingfunctionBUS display = new displayingfunctionBUS();
 
    protected void Page_Load(object sender, EventArgs e)
    {
        loadfunction();
        loadData();
    }
    private void loadfunction()
    {
        
    }
    private void loadData()
    {
        try
        {
            DataTable pakage=display.GetAllpackeg();
            dlGoiDichVu.DataSource = dlSDCN.DataSource = pakage;
            dlGoiDichVu.DataBind();
            dlSDCN.DataBind();
            int ma = int.Parse(pakage.Rows[0]["packageId"].ToString());

            DataTable t = display.LoadFunctionPackage(ma);

            dlTenChucNang.DataSource = t.DefaultView;
            dlTenChucNang.DataBind();

       

        }
        catch (Exception ex)
        {  }
    }
}