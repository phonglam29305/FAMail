using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Email;

public partial class webapp_page_backend_ListOrder : System.Web.UI.Page
{
    OrderBUS orBUS = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                orBUS = new OrderBUS();
                LoadOrDer();
            }
        }
        catch (Exception)
        {
            
            
        }

    }

    private void LoadOrDer()
    {
        try
        {
            int CustomerID = int.Parse(Request.QueryString["CustomerID"].ToString());

            DataTable order = orBUS.tblOrder_GetCustomer(CustomerID);
            dlPager.MaxPages = 1000;
            dlPager.PageSize = 10;
            dlPager.DataSource = order.DefaultView;
            dlPager.BindToControl = dtlOrder;
            this.dtlOrder.DataSource = dlPager.DataSourcePaged;
            this.dtlOrder.DataBind();;
                if (order.Rows.Count > 0)
                {
                    //Lấy thông tin đơn đặt hàng
                    for (int i = 0; i < order.Rows.Count; i++)
                    {
                        Label lblStatus = (Label)dtlOrder.Items[i].FindControl("lblStatus");
                        if (order.Rows[i]["Status"].ToString() == "True")
                        {
                            lblStatus.Text = "Đã giao hàng";
                        }
                        else
                        {
                            lblStatus.Text = "Chưa giao hàng";
                        }
                    }                   
                }
        }
        catch (Exception)
        {
            dlPager.MaxPages = 1000;
            dlPager.PageSize = 10;
            dlPager.DataSource = orBUS.GetAll().DefaultView;
            dlPager.BindToControl = dtlOrder;
            this.dtlOrder.DataSource = dlPager.DataSourcePaged;
            this.dtlOrder.DataBind(); 
            //this.dtlOrder.DataSource = orBUS.GetAll();
            //this.dtlOrder.DataBind();
            if (orBUS.GetAll().Rows.Count > 0)
            {
                for (int i = 0; i < orBUS.GetAll().Rows.Count; i++)
                {
                    Label lblStatus = (Label)dtlOrder.Items[i].FindControl("lblStatus");
                    if (orBUS.GetAll().Rows[i]["Status"].ToString() == "True")
                    {
                        lblStatus.Text = "Đã giao hàng";
                    }
                    else
                    {
                        lblStatus.Text = "Chưa giao hàng";
                    }
                }
            }
        }
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            orBUS = new OrderBUS();
            string  OrderId = ((ImageButton)sender).CommandArgument.ToString();
            ConnectionData.OpenMyConnection();
            orBUS.tblOrder_Delete(OrderId);
            pnError.Visible = false;
            pnSuccess.Visible = true;
            lblSuccess.Text = "Bạn đã xóa thành công đơn hàng có mã : " + OrderId;
            LoadOrDer();
            ConnectionData.CloseMyConnection();
        }
        catch (Exception ex)
        {
            pnError.Visible = true;
            lblError.Text = ex.Message;
        }
    }
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        if (txtDateFrom.Text == "" || txtDateTo.Text == "")
        {
            //Lọc theo mã đơn hàng
            if (txtOrderID.Text == "")
            {
                pnError.Visible = true;
                lblError.Text = "Bạn phải nhập thông tin tìm kiếm";
            }
            else
            {
                orBUS = new OrderBUS();
                if (orBUS.tblOrder_GetByID(txtOrderID.Text).Rows.Count > 0)
                {
                    this.dtlOrder.DataSource = orBUS.tblOrder_GetByID(txtOrderID.Text);
                    this.dtlOrder.DataBind();
                }
                else
                {
                    pnError.Visible = false;
                    pnSuccess.Visible = true;
                    lblSuccess.Text = "Không tìm thấy dữ liệu";
                }
            }
        }
            //Lọc theo ngày tháng lập đơn hàng
        else
        {
            DateTime from = convertStringToDate(txtDateFrom.Text);
            DateTime to = convertStringToDate(txtDateTo.Text);
            orBUS = new OrderBUS();
            if (orBUS.tblOrder_GetByDateCreate(from, to).Rows.Count > 0)
            {
                this.dtlOrder.DataSource = orBUS.tblOrder_GetByDateCreate(from, to);
                this.dtlOrder.DataBind();
            }
        }
    }
    protected void drlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool status = bool.Parse(drlStatus.SelectedValue.ToString());
        orBUS = new OrderBUS();
        this.dtlOrder.DataSource = orBUS.tblOrder_GetByStatus(status);
        this.dtlOrder.DataBind();
        if (orBUS.tblOrder_GetByStatus(status).Rows.Count > 0)
        {
            for (int i = 0; i < orBUS.tblOrder_GetByStatus(status).Rows.Count; i++)
            {
                Label lblStatus = (Label)dtlOrder.Items[i].FindControl("lblStatus");
                if (orBUS.tblOrder_GetByStatus(status).Rows[i]["Status"].ToString() == "True")
                {
                    lblStatus.Text = "Đã giao hàng";
                }
                else
                {
                    lblStatus.Text = "Chưa giao hàng";
                }
            }
            
        }
    }
    protected DateTime convertStringToDate(string strDate)
    {
        int month = int.Parse(strDate.Substring(0, 2));
        int day = int.Parse(strDate.Substring(3, 2));
        int year = int.Parse(strDate.Substring(6, 4));
        int hours = int.Parse(strDate.Substring(11, 2));
        int minute = int.Parse(strDate.Substring(14, 2));
        DateTime dDate = new DateTime(year, month, day, hours, minute, 00);
        return dDate;
    }

}
