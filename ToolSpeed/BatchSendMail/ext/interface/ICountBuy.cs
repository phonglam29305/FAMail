using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for ICountBuy
/// </summary>
public interface ICountBuy
{
    void tblCountBuy_insert(int CustomerID, int CategoryID, int CountBuy);
    int tblCountBuy_UpdateCountBuy(int CustomerID, int CategoryID);
    void tblCountBuy_Delete(int CustomerID, int CategoryID);
    DataTable GetAll();
    DataTable GetByID(int CustomerID, int CategoryID);
    DataTable GetByCategoryID(int CategoryID);
    DataTable GetGroup();
}
