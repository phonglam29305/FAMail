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
