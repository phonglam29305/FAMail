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

public partial class webapp_page_backend_PrintOrder : System.Web.UI.Page
{
    OrderBUS oBUS = null;
    OrderDatailBUS odBUS= null;
    CustomerBUS ctBus= null;
    Common cm = null;
    float Total = 0;
    float HandSel = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                InitBUS();
                LoadOrderDetail();
            }
        }
        catch (Exception)
        {
            
            
        }
    }

    private void InitBUS()
    {
        oBUS = new OrderBUS();
        odBUS = new OrderDatailBUS();
        ctBus = new CustomerBUS();
        
    }

    private void LoadOrderDetail()
    {
        try
        {
            string  OrderID = Request.QueryString["OrderID"];
            if (OrderID == "" || OrderID == null)
            {
                Response.Redirect("ListOrder.aspx");
            }
            else
            {
                DataTable order = oBUS.tblOrder_GetByID(OrderID);
                if (order.Rows.Count > 0)
                {
                    //Lấy thông tin đơn đặt hàng
                    lblDay.Text = DateTime.Now.Day.ToString();
                    lblMonth.Text = DateTime.Now.Month.ToString();
                    lblYear.Text = DateTime.Now.Year.ToString();
                    lblOrderID.Text = OrderID;
                    lblPaymentForm.Text = order.Rows[0]["PaymentMethod"].ToString();
                    lblDeliveryDate.Text = DateTime.Parse(order.Rows[0]["DeliveryDate"].ToString()).ToShortDateString();
                    lblDeliveryMethod.Text = order.Rows[0]["DeliveryMethod"].ToString();
                    lblDateCreate.Text = DateTime.Parse(order.Rows[0]["CreateDate"].ToString()).ToShortDateString();
                    lblPersonCreate.Text = order.Rows[0]["PersonCreate"].ToString();
                    HandSel = float.Parse(order.Rows[0]["HandSel"].ToString());
                    lblHandSel.Text = String.Format("{0}  VNĐ", String.Format("{0:0,0}", HandSel));
                    int CustomerID = int.Parse(order.Rows[0]["CustomerID"].ToString());
                    //Lấy thông tin khách hàng
                    
                    DataTable customer = ctBus.GetByID(CustomerID);
                    if (customer.Rows.Count > 0)
                    {
                        lblNameCustomer.Text= customer.Rows[0]["Name"].ToString();
                        lblGender.Text = customer.Rows[0]["Gender"].ToString();
                        lblPhoneNumber.Text = customer.Rows[0]["Phone"].ToString();
                        lblEmail.Text = customer.Rows[0]["Email"].ToString();
                        lblAddress.Text = customer.Rows[0]["Address"].ToString();
                    }
                    //Lấy thông tin hóa đơn
                    DataTable orderDetail = odBUS.tblOrderDetail_GetByID(OrderID);
                    CreateDetailOrder(orderDetail);

                    lblTotal.Text = String.Format("{0}  VNĐ", String.Format("{0:0,0}", Total));
                    cm = new Common();
                    lblSubTotal.Text = String.Format("{0}  VNĐ", String.Format("{0:0,0}", (Total - HandSel)));
                    float subtotal = Total - HandSel;
                    lblWordMoney.Text = cm.DocTienBangChu(long.Parse(subtotal.ToString()), " Đồng");
                }
                
            }


        }
        catch (Exception )
        {
            throw;
        }
    }

    private void CreateDetailOrder(DataTable orderDetail)
    {
        int stt=0;
        string html="";
        if (orderDetail.Rows.Count > 0)
        {
            for (int i = 0; i < orderDetail.Rows.Count; i++)
            {
                stt++;
                html += String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}<td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td></tr>",
                    stt, orderDetail.Rows[i]["ProductID"],
                    orderDetail.Rows[i]["ProductName"],
                    orderDetail.Rows[i]["DeliveryCode"],
                    String.Format("{0:0,0}", double.Parse(orderDetail.Rows[i]["UnitPrice"].ToString())), 
                    orderDetail.Rows[i]["Quantity"], 
                    String.Format("{0:0,0}",
                    float.Parse(orderDetail.Rows[i]["Total"].ToString())), 
                    orderDetail.Rows[i]["Note"]);
                Total = Total + float.Parse(orderDetail.Rows[i]["Total"].ToString());             

            }
            lblChitiet.Text = html;
        }
        else
        {
            lblChitiet.Text = "Không có chi tiết";
        }
    }
}
