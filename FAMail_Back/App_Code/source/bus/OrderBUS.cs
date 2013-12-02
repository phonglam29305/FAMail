using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for OrderBUS
/// </summary>
public class OrderBUS: IOrder
{
    OrderDAO oDao = null;
	public OrderBUS()
	{
        oDao = new OrderDAO();
	}

    #region IOrder Members

    public int tblOrder_insert(OrderDTO dt)
    {
        return oDao.tblOrder_insert(dt);
    }

    public int tblOrder_update(OrderDTO dt)
    {
       return oDao.tblOrder_update(dt);
    }

    public int tblOrder_updateStatus(string OrderID, bool Status)
    {
        return oDao.tblOrder_updateStatus(OrderID,Status);
    }

    public void tblOrder_Delete(string OrderID)
    {
        oDao.tblOrder_Delete(OrderID);
    }

    public DataTable tblOrder_GetByID(string OrderID)
    {
        return oDao.tblOrder_GetByID(OrderID);
    }

    public DataTable GetAll()
    {
       return oDao.GetAll();
    }

    #endregion

    #region IOrder Members


    public DataTable tblOrder_GetByDateCreate(DateTime from, DateTime to)
    {
        return oDao.tblOrder_GetByDateCreate(from, to);
    }

    #endregion

    #region IOrder Members


    public DataTable tblOrder_GetByStatus(bool status)
    {
        return oDao.tblOrder_GetByStatus(status);
    }

    public DataTable tblOrder_GetCustomer(int customerID)
    {
      return  oDao.tblOrder_GetCustomer(customerID);
    }

    #endregion
}
