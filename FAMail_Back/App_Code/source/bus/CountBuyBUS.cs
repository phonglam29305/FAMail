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
/// Summary description for CountBuyBUS
/// </summary>
public class CountBuyBUS:ICountBuy
{
    CountBuyDAO cotDao = null;
	public CountBuyBUS()
	{
        cotDao = new CountBuyDAO();
	}

    #region ICountBuy Members

    public void tblCountBuy_insert(int CustomerID, int CategoryID, int CountBuy)
    {
        cotDao.tblCountBuy_insert(CustomerID, CategoryID, CountBuy);
    }

    public int tblCountBuy_UpdateCountBuy(int CustomerID, int CategoryID)
    {
        return cotDao.tblCountBuy_UpdateCountBuy(CustomerID, CategoryID);
    }

    public void tblCountBuy_Delete(int CustomerID, int CategoryID)
    {
        cotDao.tblCountBuy_Delete(CustomerID, CategoryID);
    }

    public DataTable GetAll()
    {
        return cotDao.GetAll();
    }

    public DataTable GetByID(int CustomerID, int CategoryID)
    {
        return cotDao.GetByID(CustomerID, CategoryID);
    }

    public DataTable GetByCategoryID(int CategoryID)
    {
        return cotDao.GetByCategoryID(CategoryID);
    }

    #endregion

    #region ICountBuy Members


    public DataTable GetGroup()
    {
        return cotDao.GetGroup();
    }

    #endregion
}
