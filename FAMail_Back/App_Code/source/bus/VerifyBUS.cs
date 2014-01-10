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
/// Summary description for VerifyBUS
/// </summary>
public class VerifyBUS:IVerify
{
    VerifyDAO vDao = new VerifyDAO();
    public void tblVerify_insert(VerifyDTO dt)
    {
        vDao.tblVerify_insert(dt);
    }

    public void tblVerify_Delete(string email)
    {
        vDao.tblVerify_Delete(email);
    }
    public void updateveryfy(string EmailVerify, bool Isdelete)
    {
        vDao.updateveryfy(EmailVerify, Isdelete);
    }
    public DataTable GetAll()
    {
        return vDao.GetAll();
    }

    public DataTable GetByUserId(int userId)
    {
        return vDao.GetByUserId(userId);
    }

    #region IVerify Members


    public DataTable GetByEmail(string EmailVerify)
    {
        return vDao.GetByEmail(EmailVerify);
    }

    #endregion
}
