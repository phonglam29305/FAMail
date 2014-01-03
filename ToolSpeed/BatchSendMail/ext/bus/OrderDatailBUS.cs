using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for OrderDatailBUS
/// </summary>
public class OrderDatailBUS:IOrderDetail
{
    OrderDatailDAO odBUS = null;
	public OrderDatailBUS()
	{
        odBUS = new OrderDatailDAO();
	}

    #region IOrderDetail Members

    public int tblOrderDetail_insert(OrderDatailDTO dt)
    {
      return  odBUS.tblOrderDetail_insert(dt);
    }

    public int tblOrderDetail_update(OrderDatailDTO dt)
    {
        return odBUS.tblOrderDetail_update(dt);
    }

    public void tblOrder_Delete(string OrderID, int ProductID)
    {
        odBUS.tblOrderDetail_Delete(OrderID, ProductID);
    }

    public void tblOrderDetail_Delete(string OrderID)
    {
        odBUS.tblOrderDetail_Delete(OrderID);
    }

    public DataTable tblOrderDetail_GetByID(string OrderID)
    {
        return odBUS.tblOrderDetail_GetByID(OrderID);
    }

    public DataTable tblOrderDetail_GetByID(string OrderID, int ProductID)
    {
        return odBUS.tblOrderDetail_GetByID(OrderID,ProductID);
    }

    public DataTable GetAll()
    {
        return odBUS.GetAll();
    }

    #endregion

    #region IOrderDetail Members


    public DataTable tblOrderDetail_GetByDeliveryCode(string DeliveryCode)
    {
        return odBUS.tblOrderDetail_GetByDeliveryCode(DeliveryCode);
    }

    #endregion
}
