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
/// Summary description for DetailGroupBUS
/// </summary>
public class DetailGroupBUS:IDetailGroup
{
    DetailGroupDAO dsgDAO = null;
	public DetailGroupBUS()
	{
        dsgDAO = new DetailGroupDAO();
	}

    #region IDetailGroup Members

    public void tblDetailGroup_insert(DetailGroupDTO dt)
    {
        dsgDAO.tblDetailGroup_insert(dt);
    }

    public void tblDetailGroup_Delete(int GroupID, int CustomerID)
    {
        dsgDAO.tblDetailGroup_Delete(GroupID, CustomerID);
    }

    public DataTable GetAll()
    {
        return dsgDAO.GetAll();
    }

    public DataTable GetByID(int GroupID, int CustomerID)
    {
        return dsgDAO.GetByID(GroupID,CustomerID);
    }

    public DataTable GetByID(int GroupID)
    {
        return dsgDAO.GetByID(GroupID);
    }

    public void tblDetailGroup_Update(DetailGroupDTO dt)
    {
        dsgDAO.tblDetailGroup_Update(dt);
    }

    public void tblDetailGroup_Update(int quantity)
    {
        throw new NotImplementedException();
    }
    #endregion







    #region IDetailGroup Members


    public void tblDetailGroup_DeleteByCustomerID(int CustomerID)
    {
        dsgDAO.tblDetailGroup_DeleteByCustomerID(CustomerID);
    }

    public void tblDetailGroup_DeleteByGroup(int GroupID)
    {
        dsgDAO.tblDetailGroup_DeleteByGroup(GroupID);
    }

    #endregion
}
