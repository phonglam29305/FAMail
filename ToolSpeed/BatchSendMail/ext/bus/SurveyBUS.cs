using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for SurveyBUS
/// </summary>
public class SurveyBUS : ISurvey
{
	SurveyDAO sv= new SurveyDAO();

    #region ISurvey Members


    public void tblSurvey_insert(SurveyDTO dt)
    {
        sv.tblSurvey_insert(dt);
    }

    public void tblSurvey_Update(SurveyDTO dt)
    {
        sv.tblSurvey_Update(dt);
    }

    public void tblSurvey_Delete(int ID)
    {
        sv.tblSurvey_Delete(ID);
    }

    public DataTable GetAll()
    {
       return sv.GetAll();
    }

    public DataTable GetByID(int ID)
    {
        return sv.GetByID(ID);
    }

    #endregion



    #region ISurvey Members


    public DataTable GetAll(int MailConfigID)
    {
        return sv.GetAll(MailConfigID);
    }

    #endregion
}
