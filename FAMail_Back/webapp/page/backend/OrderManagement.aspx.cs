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
using System.Net.Mail;
using Email;

public partial class webapp_page_backend_OrderManagement : System.Web.UI.Page
{
    Common cm = new Common();
    CustomerBUS ctBUS= null;
    OrderBUS oBUS = null;
    OrderDatailBUS odBUS = null;
    MailGroupBUS mgBUS = null;
    DetailGroupBUS dgBUS = null;
    DataTable dtProduct = new DataTable();
    ProductBUS prBUS = null;
    CategoryBUS cateBus = null;
    CountBuyBUS countBUS = null;
    int CustomerID = 0;
    bool updateOrderDetail;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitBus();
            //this.grvProduct.DataSource = dtProduct;
            //this.grvProduct.DataBind();
            Session["orderList"] = null;
            if (Session["orderList"] == null)
            {
                dtProduct = cm.CreateDetailOrder();
                Session["orderList"] = dtProduct;

            }
            
            LoadGroupMail();
            AutoCreateID();
            LoadEditOrder();
            updateOrderDetail = false;
        }
    }

    private void LoadEditOrder()
    {
        try
        {
            string orderId = Request["OrderID"];
            if (orderId == "" || orderId == null)
            {
                Session["orderList"] = null;
                if (Session["orderList"] == null)
                {
                    dtProduct = cm.CreateDetailOrder();
                    Session["orderList"] = dtProduct;
                 
                }
            }
            else
            {
                if (oBUS.tblOrder_GetByID(orderId).Rows.Count > 0)
                {
                    DataTable order = oBUS.tblOrder_GetByID(orderId);
                    this.hdfUpdate.Value = "True";
                    LoadGroupMail();
                    txtOrderID.Text = orderId;
                    int CustomerID = int.Parse(order.Rows[0]["CustomerID"].ToString());
                    DataTable customer = ctBUS.GetByID(CustomerID);
                    //Lấy thông tin khách hàng
                    if (customer.Rows.Count > 0)
                    {
                        this.txtName.Text = customer.Rows[0]["Name"].ToString();
                        this.txtPhoneNumber.Text = customer.Rows[0]["Phone"].ToString();
                        this.txtAddress.Text = customer.Rows[0]["Address"].ToString();
                        this.txtEmail.Text = customer.Rows[0]["Email"].ToString();
                        this.drlGender.Text = customer.Rows[0]["Gender"].ToString();
                        this.txtBirthday.Text = DateTime.Parse(customer.Rows[0]["Birthday"].ToString()).ToShortDateString();
                        this.txtSecondPhone.Text = customer.Rows[0]["SecondPhone"].ToString();
                    }
                    //Load thông tin đơn hàng
                    this.txtCreateDate.Text = String.Format("{0:MM/dd/yyyy HH:mm}", DateTime.Parse(order.Rows[0]["CreateDate"].ToString()));
                    this.txtDeliveryDate.Text = String.Format("{0:MM/dd/yyyy HH:mm}", DateTime.Parse(order.Rows[0]["DeliveryDate"].ToString()));
                    this.txtPersonCreate.Text = order.Rows[0]["PersonCreate"].ToString();
                    this.txtPaymentMethod.Text = order.Rows[0]["PaymentMethod"].ToString();
                    this.txtDiliveryMethod.Text = order.Rows[0]["DeliveryMethod"].ToString();
                    this.drlStatus.SelectedValue= order.Rows[0]["Status"].ToString();
                    this.txtHandsel.Text = order.Rows[0]["HandSel"].ToString();
                    //Lấy thông tin chi tiết đơn hàng
                    if (odBUS.tblOrderDetail_GetByID(orderId).Rows.Count > 0)
                    {
                        Session["orderList"]=odBUS.tblOrderDetail_GetByID(orderId);
                        this.grvProduct.DataSource = odBUS.tblOrderDetail_GetByID(orderId);
                        this.grvProduct.DataBind();
                    }
                }
            }
        }
        catch (Exception)
        {


        }
       
      

    }

    private void AutoCreateID()
    {
        
        this.txtOrderID.Text = cm.NextID(cm.GetLastID("tblOrder", "OrderID","HD"), "HD");
    }

    private void LoadGroupMail()
    {
        InitBus();
        this.drlGroupMail.DataSource = mgBUS.GetAllNew();
        this.drlGroupMail.DataTextField = "Name";
        this.drlGroupMail.DataValueField = "Id";
        this.drlGroupMail.DataBind();
    }

    private void InitBus()
    {
        cm = new Common();
        ctBUS = new CustomerBUS();
        oBUS = new OrderBUS();
        odBUS = new OrderDatailBUS();
        mgBUS = new MailGroupBUS();
        dgBUS = new DetailGroupBUS();
    }
    
    protected void btnAddProduct_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable tblProduct = new DataTable(); 
            
            string err = ValidateInputDetail();
            if (err== "")
            {
                InitBus();
                tblProduct = (DataTable)Session["orderList"];
                if (hdfUpdateProduct.Value=="" || hdfUpdateProduct.Value.ToString()==null)
                {
                    DataRow rowProduct = tblProduct.NewRow();
                    rowProduct["ProductID"] = this.txtProductID.Text;
                    rowProduct["ProductName"] = this.txtProductName.Text;
                    rowProduct["DeliveryCode"] = this.txtDeliveryCode.Text;
                    rowProduct["UnitPrice"] = this.txtUnitPrice.Text;
                    rowProduct["Quantity"] = this.txtQuantity.Text;
                    rowProduct["Total"] = this.txtTotal.Text;
                    rowProduct["Note"] = this.txtNote.Text;
                    tblProduct.Rows.Add(rowProduct);
                    grvProduct.DataSource = tblProduct;
                    grvProduct.DataBind();
                }
                else
                {
                    if (tblProduct.Rows.Count > 0)
                    {
                        DataRow[] orderDetailRow = tblProduct.Select(String.Format("ProductID ={0}", txtProductID.Text));
                        orderDetailRow[0]["ProductName"] = this.txtProductName.Text;
                        orderDetailRow[0]["Quantity"] = this.txtQuantity.Text;
                        orderDetailRow[0]["UnitPrice"] = this.txtUnitPrice.Text;
                        orderDetailRow[0]["Total"] = this.txtTotal.Text;
                        orderDetailRow[0]["Note"] = this.txtNote.Text;
                        orderDetailRow[0]["DeliveryCode"] = this.txtDeliveryCode.Text;
                        grvProduct.DataSource = tblProduct;
                        grvProduct.DataBind();
                        hdfUpdateProduct.Value = "";
                        txtProductID.Text = "";
                        txtProductName.Text = "";
                        txtQuantity.Text = "";
                        txtTotal.Text = "";
                        txtDeliveryCode.Text = "";
                        txtUnitPrice.Text = "";
                        txtNote.Text = "";
                    }
                }
            }
            else
            {
                pnInfo.Visible = true;
                lblInfo.Text = err; 
                return;
            }
        }
        catch (Exception )
        {
            Visible(false);
            pnInfo.Visible = true;
            lblInfo.Text = "Lỗi trong quá trình thêm sản phẩm vào chi tiết đơn hàng";
        }
    }

    private string ValidateInputDetail()
    {
        int Pro;
        double price;
        string err = "";
        if (txtProductID.Text == "" || int.TryParse(txtProductID.Text, out Pro) == false)
        {
            err = "Bạn chưa nhập mã sản phẩm hoăc không đúng đinh dạng";
        }
        else if (txtProductName.Text == "")
        {
            err = "Bạn chưa nhập tên sản phẩm";
        }
        else if (txtQuantity.Text == "" || int.TryParse(txtQuantity.Text, out Pro) == false)
        {
            err = "Bạn chưa nhập số lượng hoặc không đúng định dạng";
        }
        else if (txtUnitPrice.Text == "" || double.TryParse(txtUnitPrice.Text, out price) == false)
        {
            err = "Bạn chưa nhập đơn giá hoặc không đúng định dạng";
        }
        return err;
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool status = false;
        InitBus();
        string err = ValidateInput();
        //Thêm khách hàng 
        if (err == "")
        {
            try
            {
                if (ctBUS.GetByEmail(GetCustomerDTO().Email).Rows.Count > 0)
                {
                    CustomerID = int.Parse(ctBUS.GetByEmail(GetCustomerDTO().Email).Rows[0]["Id"].ToString());
                    ctBUS.tblCustomer_Update(GetCustomerDTO());
                }
                else
                {
                    CustomerID = ctBUS.tblCustomer_insert(GetCustomerDTO());
                }
                int GroupID = int.Parse(this.drlGroupMail.SelectedValue);
                DetailGroupDTO dgDTO = new DetailGroupDTO() { CustomerID = CustomerID, GroupID = GroupID };
                //Thêm vào nhóm mail 
                if (dgBUS.GetByID(GroupID, CustomerID).Rows.Count == 0)
                {
                    dgBUS.tblDetailGroup_insert(dgDTO);
                }
                //Thêm vào hóa đơn
                if (oBUS.tblOrder_GetByID(GetOrderDTO().OrderID).Rows.Count > 0 || hdfUpdate.Value!="")
                {
                    status = GetOrderDTO().Status;
                    oBUS.tblOrder_updateStatus(GetOrderDTO().OrderID, status);
                }
                else
                {
                    oBUS.tblOrder_insert(GetOrderDTO());
                }
                // Thêm vào chi tiết hóa đơn
                DataTable tblProduct = (DataTable)Session["orderList"];
                if (tblProduct.Rows.Count > 0)
                {
                    OrderDatailDTO odDTO = new OrderDatailDTO();
                    for (int i = 0; i < tblProduct.Rows.Count; i++)
                    {
                        //Thêm từng sản phẩm vào chi tiết đơn hàng
                        odDTO.ProductID = int.Parse(tblProduct.Rows[i]["ProductID"].ToString());
                        odDTO.OrderID = txtOrderID.Text;
                        odDTO.ProductName = tblProduct.Rows[i]["ProductName"].ToString();
                        odDTO.DeliveryCode = tblProduct.Rows[i]["DeliveryCode"].ToString();
                        odDTO.UnitPrice = float.Parse(tblProduct.Rows[i]["UnitPrice"].ToString());
                        odDTO.Quantity = int.Parse(tblProduct.Rows[i]["Quantity"].ToString());
                        odDTO.Total = odDTO.Quantity * odDTO.UnitPrice;
                        odDTO.Note = tblProduct.Rows[i]["Note"].ToString();
                        odDTO.Size = "M";                        
                        int CateGoryID;
                        if (odBUS.tblOrderDetail_GetByID(txtOrderID.Text, odDTO.ProductID).Rows.Count > 0)
                        {
                            odBUS.tblOrderDetail_update(odDTO);
                        }
                        else
                        {
                            odBUS.tblOrderDetail_insert(odDTO);
                        }
                      
                        if (status == true)
                        {
                            prBUS = new ProductBUS();
                            //Lấy nhóm của sản phẩm
                            CateGoryID = int.Parse(prBUS.GetByID(odDTO.ProductID).Rows[0]["Category"].ToString());
                            countBUS = new CountBuyBUS();
                            if (countBUS.GetByID(CustomerID, CateGoryID).Rows.Count > 0)
                            {
                                //Cập nhật số lần mua của khách hàng này theo nhóm sản phẩm
                                countBUS.tblCountBuy_UpdateCountBuy(CustomerID, CateGoryID);
                            }
                            else
                            {
                                //Thêm vào đếm lần mua theo nhóm
                                countBUS.tblCountBuy_insert(CustomerID, CateGoryID, 1);
                            }
                        }
                      

                    }
                    //Cập nhật số lần mua cho khách hàng
                    if (status == true)
                    {
                        ctBUS = new CustomerBUS();
                        ctBUS.tblCustomer_UpdateCountBuy(CustomerID);
                    }
                    //Load lại thông tin khách hàng
                    Visible(false);
                    pnSuccess.Visible = true;
                    lblSuccess.Text = "Cập nhật thành công một đơn hàng";
                    LoadDefautlValue();
                    Session["orderList"] = null;
                    //Tạo mã hóa đơn tự động
                    AutoCreateID();
                }
            }
            catch (Exception ex)
            {
                Visible(false);
                pnError.Visible = true;
                lblError.Text = "Lỗi xảy ra trong quá trình nhập:" + ex.Message;
            }
        }
        else
        {
            Visible(false);
            pnError.Visible = true;
            lblError.Text = err;
        }
    }

    private void LoadDefautlValue()
    {
        txtAddress.Text = "";
        txtBirthday.Text = "";
        txtCreateDate.Text = "";
        txtDeliveryDate.Text = "";
        txtDiliveryMethod.Text = "";
        txtEmail.Text = "";
        txtName.Text = "";
        txtNote.Text = "";
        AutoCreateID();
        txtPaymentMethod.Text = "";
        txtPersonCreate.Text = "";
        txtPhoneNumber.Text = "";
        txtProductID.Text = "";
        txtProductName.Text = "";
        txtQuantity.Text = "";
        txtSecondPhone.Text = "";
        txtTotal.Text = "";
        txtDeliveryCode.Text = "";
        txtUnitPrice.Text = "";
    }

    private string ValidateInput()
    {
        int i=0;
        DateTime h;
        float f;
        string err = "";
        DataTable tblProduct = new DataTable();
        tblProduct = (DataTable)Session["orderList"];
        if (txtName.Text == "")
        {
            err = "Bạn chưa nhập tên khách hàng";
            txtName.Focus();
        }
        else if (txtBirthday.Text == "" || DateTime.TryParse(txtBirthday.Text, out h) == false)
        {
            err = "Bạn chưa nhập ngày sinh , hoặc không đúng định dạng";
            txtBirthday.Focus();
        }
        else if (txtAddress.Text == "")
        {
            err = "Bạn chưa nhập địa chỉ";
            txtAddress.Focus();
        }
        else if (txtPhoneNumber.Text == "")
        {
            err = "Bạn chưa nhập số điện thoại";
            txtPhoneNumber.Focus();
        }
        else if (txtEmail.Text == "" || EmailVaildate(txtEmail.Text) == false)
        {
            err = "Bạn chưa nhập Email hoặc không đúng định dạng";
            txtEmail.Focus();
        }
        else if (txtDiliveryMethod.Text == "")
        {
            err = "Bạn chưa nhập phương thức giao hàng";
            txtDiliveryMethod.Focus();
        }
        else if (txtDeliveryDate.Text == "")
        {
            err = "Bạn chưa nhập ngày giao hàng";
        }
            
        else if (tblProduct.Rows.Count<0)
        {
            err = "Bạn chưa nhập thông tin chia tiết đơn hàng";
        }
        else if (txtHandsel.Text == "" || float.TryParse(txtHandsel.Text, out f) == false)
        {
            err = "Bạn chưa nhập thông tin tiền đặt cọc hoặc không đúng định dạng";
            txtHandsel.Focus();
            txtHandsel.Text = "0";
        }
        return err;
    }

    private bool EmailVaildate(string p)
    {
      
        try
        {
            MailAddress m = new MailAddress(p);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
  
    }

    private void Visible(bool p)
    {
        pnError.Visible = p;
        pnSuccess.Visible = p;
    }

    private OrderDatailDTO GetOrderDetail()
    {
        OrderDatailDTO odDTO = new OrderDatailDTO();
        return odDTO;
    }

    private OrderDTO GetOrderDTO()
    {
        OrderDTO oDTO = new OrderDTO();
        oDTO.CustomerID = CustomerID;
        oDTO.OrderID = this.txtOrderID.Text;
        oDTO.PersonCreate = this.txtPersonCreate.Text;
        oDTO.CreateDate = convertStringToDate(this.txtCreateDate.Text);
        oDTO.DeliveryDate = convertStringToDate(txtDeliveryDate.Text);
        oDTO.DeliveryMethod = txtDiliveryMethod.Text;
        oDTO.PaymentMethod = txtPaymentMethod.Text;
        oDTO.Status = bool.Parse(drlStatus.SelectedValue);
        oDTO.HandSel = float.Parse(txtHandsel.Text);
        return oDTO;
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
    private CustomerDTO GetCustomerDTO()
    {
        CustomerDTO ctDTO = new CustomerDTO();
        ctDTO.Name = this.txtName.Text;
        ctDTO.Gender = this.drlGender.Text;
        ctDTO.BirthDay = DateTime.Parse(this.txtBirthday.Text);
        ctDTO.Phone = this.txtPhoneNumber.Text;
        ctDTO.Address = txtAddress.Text;
        ctDTO.Email = this.txtEmail.Text;
        ctDTO.SecondPhone = this.txtSecondPhone.Text;
        ctDTO.Province = "";
        ctDTO.Type = "";
        ctDTO.Fax = "";
        ctDTO.Country = "";
        ctDTO.Company = "";
        ctDTO.City = "";
        ctDTO.Id = CustomerID;
        return ctDTO;
    }
    protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
    {
        float total = 0;
        float par;
        int quan;
        if (txtUnitPrice.Text == "" || float.TryParse(txtUnitPrice.Text, out par) == false)
        {
            this.txtUnitPrice.Text = "";
            this.txtUnitPrice.Focus();
            total = 0;
        }
        else
        {
            if (txtQuantity.Text == "" || int.TryParse(txtQuantity.Text, out quan) == false)
            {
                total = 0;
            }
            else
            {
                total = int.Parse(txtQuantity.Text) * float.Parse(this.txtUnitPrice.Text);
            }
        }
        this.txtTotal.Text = total.ToString();
    }
    protected void txtQuantity_TextChanged(object sender, EventArgs e)
    {

        float total = 0;
        float par;
        int quan;
        if (txtQuantity.Text == "" || int.TryParse(txtQuantity.Text, out quan) == false)
        {
            this.txtUnitPrice.Text = "";
            this.txtUnitPrice.Focus();
            total = 0;
        }
        else
        {
            if (txtUnitPrice.Text == "" || float.TryParse(txtUnitPrice.Text, out par) == false)
            {
                total = 0;
            }
            else
            {
                total = int.Parse(txtQuantity.Text) * float.Parse(this.txtUnitPrice.Text);
            }
        }
        this.txtTotal.Text = total.ToString();
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        int ProductID = int.Parse(((ImageButton)sender).CommandArgument);
        string orderID = this.txtOrderID.Text;
        DataTable dtDetailOrder = new DataTable();
        if (Session["orderList"] != null)
        {
            dtDetailOrder = (DataTable)Session["orderList"];
            if (dtDetailOrder.Rows.Count > 0)
            {
                for (int i = 0; i < dtDetailOrder.Rows.Count; i++)
                {
                    if (int.Parse(dtDetailOrder.Rows[i]["ProductID"].ToString()) == ProductID)
                    {
                        dtDetailOrder.Rows[i].Delete();
                    }
                }
                odBUS = new OrderDatailBUS();
                odBUS.tblOrder_Delete(orderID, ProductID);
                dtDetailOrder = odBUS.tblOrderDetail_GetByID(orderID);
            }
        }
        
        //Goi lại gridview;
        grvProduct.DataSource = dtDetailOrder;
        grvProduct.DataBind();
    }
    protected void txtProductID_TextChanged(object sender, EventArgs e)
    {
        int ProductID = 0;
      
        if (int.TryParse(txtProductID.Text, out ProductID) != false)
        {
            ProductID = int.Parse(txtProductID.Text);
            prBUS = new ProductBUS();
            ConnectionData.OpenMyConnection();
        }
        else
        {
            Visible(false);
            pnInfo.Visible = true;
            lblInfo.Text = "Bạn phải nhập mã sản phẩm là số !";
            return;
        }
        DataTable product = prBUS.GetByID(ProductID);
        if (product.Rows.Count > 0)
        {
            pnInfo.Visible = false;
            txtProductName.Text = product.Rows[0]["Title"].ToString();
            txtUnitPrice.Text = product.Rows[0]["UnitPrice"].ToString();
            txtQuantity.Text = "1";
           float total = int.Parse(txtQuantity.Text) * float.Parse(this.txtUnitPrice.Text);
           this.txtTotal.Text = total.ToString();
        }
        else
        {
            Visible(false);
            pnInfo.Visible = true;
            lblInfo.Text = "Không tồn tại mã sản phẩm này !";
            txtProductName.Text = "";
            txtUnitPrice.Text = "";
        }
        ConnectionData.CloseMyConnection();
    }
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        int ProductID = int.Parse(((ImageButton)sender).CommandArgument);
        DataTable dtDetailOrder = new DataTable();
        dtDetailOrder = (DataTable)Session["orderList"];
        if (dtDetailOrder.Rows.Count > 0)
        {
            DataRow[] orderDetailRow = dtDetailOrder.Select(String.Format("ProductID ={0}",ProductID));
            txtProductID.Text = ProductID.ToString();
            this.txtProductName.Text =orderDetailRow[0]["ProductName"].ToString();
            this.txtQuantity.Text = orderDetailRow[0]["Quantity"].ToString();
            this.txtUnitPrice.Text = orderDetailRow[0]["UnitPrice"].ToString();
            this.txtTotal.Text = orderDetailRow[0]["Total"].ToString();
            this.txtNote.Text= orderDetailRow[0]["Note"].ToString();
            this.txtDeliveryCode.Text = orderDetailRow[0]["DeliveryCode"].ToString();
            this.hdfUpdateProduct.Value = ProductID.ToString();
        }
    }
}
