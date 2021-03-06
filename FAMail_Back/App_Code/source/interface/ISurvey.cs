﻿using System;
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
/// Summary description for ISurvey
/// </summary>
public interface ISurvey
{
	
        void tblSurvey_insert(SurveyDTO dt);
        void tblSurvey_Update(SurveyDTO dt);
        void tblSurvey_Delete(int ID);
        DataTable GetAll();
        DataTable GetByID(int ID);
        DataTable GetAll(int MailConfigID);
	
}
