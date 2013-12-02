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
/// Summary description for ProductBUS
/// </summary>
public class ProductBUS:IProduct
{
    ProductDAO prDao = null;
	public ProductBUS()
	{
        prDao = new ProductDAO();
	}


    #region IProduct Members

    public DataTable GetAll()
    {
        return prDao.GetAll();
    }

    public DataTable GetByID(int ID)
    {
        return prDao.GetByID(ID);
    }

    #endregion
}
