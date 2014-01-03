using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for IDepartment
/// </summary>
public interface IRoleDetail
{
    void tblRoleDetail_insert(RoleDetailDTO dt);
    void tblRoleDetail_Delete(int roleId, int departmentId);
    DataTable GetAll();
    DataTable GetByDepartmentId(int departmentId);
    DataTable GetByDepartmentIdAndRole(int role, int departmentId);
}
