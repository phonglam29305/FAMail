using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for RoleListBUS
/// </summary>
public class RoleListBUS:IRoleList
{
    RoleListDAO rlDao = null;
	public RoleListBUS()
	{
        rlDao = new RoleListDAO();
	}

    #region IRoleList Members

    public void tblRoleList_insert(RoleListDTO dt)
    {
        rlDao.tblRoleList_insert(dt);
    }

    public void tblRoleList_Delete(int roleId)
    {
        rlDao.tblRoleList_Delete(roleId);
    }

    public DataTable GetAll()
    {
        return rlDao.GetAll();
    }

    public DataTable GetByRoleId(int roleId)
    {
        return rlDao.GetByRoleId(roleId);
    }

    #endregion
}
