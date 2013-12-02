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
/// Summary description for DepartmentBUS
/// </summary>
public class DepartmentBUS:IDepartment
{
    DepartmentDAO dpmDAO = null;

	public DepartmentBUS()
	{
        dpmDAO = new DepartmentDAO();
	}


    #region IDepartment Members

    public void tblDepartment_insert(DepartmentDTO dt)
    {
        dpmDAO.tblDepartment_insert(dt);
    }

    public void tblDepartment_Update(DepartmentDTO dt)
    {
        dpmDAO.tblDepartment_Update(dt);
    }

    public void tblDepartment_Delete(int ID)
    {
        dpmDAO.tblDepartment_Delete(ID);
    }

    public DataTable GetAll()
    {
       return dpmDAO.GetAll();
    }

    public DataTable GetByID(int ID)
    {
        return dpmDAO.GetByID(ID);
    }

    #endregion
}
