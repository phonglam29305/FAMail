using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for PartSendBUS
/// </summary>
public class PartSendBUS:IPartSend
{
    PartSendDAO psDao = new PartSendDAO();
	public PartSendBUS()
	{
	}

    #region IPartSend Members

    public void tblPartSend_insert(PartSendDTO dt)
    {
        psDao.tblPartSend_insert(dt);
    }

    public void tblPartSend_update(PartSendDTO dt)
    {
        psDao.tblPartSend_Update(dt);
    }

    public void tblPartSend_Delete(int userId, int groupId)
    {
        psDao.tblUserLogin_Delete(userId, groupId);
    }

    public DataTable GetAll()
    {
        return psDao.GetAll();
    }

    public DataTable GetByUserIdAndGroupId(int userId, int groupId)
    {
        return psDao.GetByUserIdAndGroupId(userId, groupId);
    }

    #endregion
}
