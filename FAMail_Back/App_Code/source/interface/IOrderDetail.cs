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
/// Summary description for IOrderDetail
/// </summary>
public interface IOrderDetail
{
    int tblOrderDetail_insert(OrderDatailDTO dt);
    int tblOrderDetail_update(OrderDatailDTO dt);
    void tblOrder_Delete(string OrderID, int ProductID);
    void tblOrderDetail_Delete(string OrderID);
    DataTable tblOrderDetail_GetByID(string OrderID);
    DataTable tblOrderDetail_GetByID(string OrderID, int ProductID);
    DataTable GetAll();
    DataTable tblOrderDetail_GetByDeliveryCode(string DeliveryCode);
}
