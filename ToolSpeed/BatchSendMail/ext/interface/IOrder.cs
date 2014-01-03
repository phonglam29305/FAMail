using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for IOrder
/// </summary>
public interface IOrder
{
    int tblOrder_insert(OrderDTO dt);
    int tblOrder_update(OrderDTO dt);
    int tblOrder_updateStatus(string OrderID, bool Status);
    void tblOrder_Delete(string OrderID);
    DataTable tblOrder_GetByID(string OrderID);
    DataTable GetAll();
    DataTable tblOrder_GetByDateCreate(DateTime from, DateTime to);
    DataTable tblOrder_GetByStatus(bool status);
    DataTable tblOrder_GetCustomer(int customerID);
}
