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
/// Summary description for SurveyDetailBUS
/// </summary>
public class SurveyDetailBUS:ISurveyDetail //ke thua interface
{
    SurveyDetailDAO sdDao = new SurveyDetailDAO();
    public SurveyDetailBUS() { }

    #region ISurveyDetail Members

    public void tblSurveyDetail_insert(SurveyDetailDTO dt)
    {
        sdDao.tblSurveyDetail_insert(dt);
    }

    public void tblSurveyDetail_Update(SurveyDetailDTO dt)
    {
        sdDao.tblSurveyDetail_Update(dt);
    }
    public DataTable GetAll()
    {
        return sdDao.GetAll();
    }

    public void tblSurveyDetail_Delete(string EmailId)
    {
        sdDao.tblSurveyDetail_Delete(EmailId);
    }

    public DataTable GetByID(string EmailId)
    {
       return sdDao.GetByID(EmailId);
    }

    #endregion
}
