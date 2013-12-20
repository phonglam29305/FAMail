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
/// Summary description for MailConfigBUS
/// </summary>
public class MailConfigBUS:IMailConfig
{
    public MailConfigBUS() { }

    MailConfigDAO mcDao= new MailConfigDAO();


    #region IMailConfig Members

    public void tblMailConfig_insert(MailConfigDTO dt)
    {
        mcDao.tblMailConfig_insert(dt);
    }

    public void tblMailConfig_Update(MailConfigDTO dt)
    {
        mcDao.tblMailConfig_Update(dt);
    }
    public void tblMailConfig_Delete(int Id)
    {
        mcDao.tblMailConfig_Delete(Id);
    }

    public DataTable GetAll()
    {
        return mcDao.GetAll();
    }

    public DataTable GetByID(int Id)
    {
        return mcDao.GetByID(Id);
    }

    public DataTable GetByEmailAndPass(string email,string pass)
    {
        return mcDao.GetByEmailAndPass(email, pass);
    }


    #endregion

    #region IMailConfig Members


    public DataTable GetAll(int DepartmentID)
    {
        return mcDao.GetAll(DepartmentID);
    }

    #endregion

    #region IMailConfig Members


    public DataTable GetByUserId(int UserId)
    {
        return mcDao.GetByUserId(UserId);
    }

    public DataTable GetBySub(int userId)
    {
        return mcDao.GetBySub(userId);
    }
    #endregion
}
