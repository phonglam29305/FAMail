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
/// Summary description for IHtmlMailRule
/// </summary>
public interface IHtmlMailRule
{
    void tblHtmlMailRule_insert(HtmlMailRuleDTO dt);
    void tblHtmlMailRule_Update(HtmlMailRuleDTO dt);
    void tblHtmlMailRule_Delete(string Attribute);
    DataTable GetAll();
    DataTable GetByID(string Attribute);
}
