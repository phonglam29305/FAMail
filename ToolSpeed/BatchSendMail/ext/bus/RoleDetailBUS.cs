using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for RoleDetailBUS
/// </summary>
public class RoleDetailBUS:IRoleDetail
{
    RoleDetailDAO rdDao = null;
	public RoleDetailBUS()
	{
        rdDao = new RoleDetailDAO();
	}

    #region IRoleDetail Members

    public void tblRoleDetail_insert(RoleDetailDTO dt)
    {
        rdDao.tblRoleDetail_insert(dt);
    }

    public void tblRoleDetail_Delete(int roleId, int departmentId)
    {
        rdDao.tblRoleDetail_Delete(roleId, departmentId);
    }

    public DataTable GetAll()
    {
        return rdDao.GetAll();
    }

    public DataTable GetByDepartmentId(int departmentId)
    {
        return rdDao.GetByDepartmentId(departmentId);
    }

    public DataTable GetByDepartmentIdAndRole(int role, int departmentId)
    {
        return rdDao.GetByDepartmentIdAndRole(role, departmentId);
    }

    #endregion


}
