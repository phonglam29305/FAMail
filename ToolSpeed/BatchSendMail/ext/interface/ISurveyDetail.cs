using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;


/// <summary>
/// Summary description for ISurveyDetail
/// </summary>
public interface ISurveyDetail
{
    void tblSurveyDetail_insert(SurveyDetailDTO dt);
    void tblSurveyDetail_Update(SurveyDetailDTO dt);
    void tblSurveyDetail_Delete(string EmailId);
    DataTable GetAll();
    DataTable GetByID(string EmailId);
}
