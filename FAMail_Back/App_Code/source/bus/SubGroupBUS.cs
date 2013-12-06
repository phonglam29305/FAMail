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
/// Summary description for SubGroupBUS
/// </summary>
public class SubGroupBUS:ISubGroup
{
    SubGroupDAO sgDAO = null;
	public SubGroupBUS()
	{
        sgDAO = new SubGroupDAO();
	}

    #region ISubGroup Members

    public void tblSubGroup_insert(SubGroupDTO dt)
    {
        sgDAO.tblSubGroup_insert(dt);
    }

    public void tblSubGroup_Update(SubGroupDTO dt)
    {
        sgDAO.tblSubGroup_Update(dt);
    }

    public void tblSubGroup_Delete(int IDSubGroup)
    {
        sgDAO.tblSubGroup_Delete(IDSubGroup);
    }

    public DataTable GetAll()
    {
       return sgDAO.GetAll();
    }

    public DataTable GetByID(int IDSubGroup)
    {
        return sgDAO.GetByID(IDSubGroup);
    }

    #endregion
}
