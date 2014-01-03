using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for IDepartment
/// </summary>
public interface IDepartment
{
    void tblDepartment_insert(DepartmentDTO dt);
    void tblDepartment_Update(DepartmentDTO dt);
    void tblDepartment_Delete(int ID);
    DataTable GetAll();
    DataTable GetByID(int ID);
}
