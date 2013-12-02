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
/// Summary description for IDepartment
/// </summary>
public interface IRoleDetail
{
    void tblRoleDetail_insert(RoleDetailDTO dt);
    void tblRoleDetail_Delete(int roleId, int departmentId);
    int tblRoleDetail_Update(RoleDetailDTO dt);
    DataTable GetAll();
    DataTable GetByDepartmentId(int departmentId);
    DataTable GetByDepartmentIdAndRole(int role, int departmentId);
}
