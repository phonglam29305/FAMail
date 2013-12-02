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
/// Summary description for SurveyDetail
/// </summary>
public class SurveyDetailDTO
{
    public string EmailId { get; set; }
    public DateTime SurveyDate { get; set; }
    public int SurveyId { get; set; }
    public string Description { get; set; }
	public SurveyDetailDTO()
	{
		
	}

}
