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
public interface IRoleList
{
    void tblRoleList_insert(RoleListDTO dt);
    void tblRoleList_Delete(int roleId);
    DataTable GetAll();
    DataTable GetByRoleId(int roleId);
    DataTable GetRoleByDepartmentId(int departmentId);
}
