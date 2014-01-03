using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for DetailGroupBUS
/// </summary>
public class DetailGroupBUS:IDetailGroup
{
    DetailGroupDAO dgDao = null;
	public DetailGroupBUS()
	{
        dgDao = new DetailGroupDAO();
	}

    #region IDetailGroup Members

    public void tblDetailGroup_insert(DetailGroupDTO dt)
    {
        dgDao.tblDetailGroup_insert(dt);
    }

    public void tblDetailGroup_Delete(int GroupID, int CustomerID)
    {
        dgDao.tblDetailGroup_Delete(GroupID, CustomerID);
    }

    public DataTable GetAll()
    {
        return dgDao.GetAll();
    }

    public DataTable GetByID(int GroupID, int CustomerID)
    {
        return dgDao.GetByID(GroupID, CustomerID);
    }

    public DataTable GetByID(int GroupID)
    {
        return dgDao.GetByID(GroupID);
    }
    public DataTable GetCustomerByGroupID(int GroupID)
    {
        return dgDao.GetCustomerByGroupID(GroupID);
    }

    public void tblDetailGroup_Update(DetailGroupDTO dt)
    {
        dgDao.tblDetailGroup_Update(dt);
    }

    public void tblDetailGroup_Update(int quantity)
    {
        throw new NotImplementedException();
    }
    public DataTable getGroupListByEventList()
    {
        return dgDao.getGroupListByEventList();
    }
    #endregion





    
}
