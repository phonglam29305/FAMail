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
/// Summary description for HtmlMailRuleBUS
/// </summary>
public class HtmlMailRuleBUS:IHtmlMailRule
{
    HtmlMailRuleDAO hmrDAO = null;
	public HtmlMailRuleBUS()
	{
        hmrDAO = new HtmlMailRuleDAO();
	}

    #region IHtmlMailRule Members

    public void tblHtmlMailRule_insert(HtmlMailRuleDTO dt)
    {
        hmrDAO.tblHtmlMailRule_insert(dt);
    }

    public void tblHtmlMailRule_Update(HtmlMailRuleDTO dt)
    {
        hmrDAO.tblHtmlMailRule_Update(dt);
    }

    public void tblHtmlMailRule_Delete(string Attribute)
    {
        hmrDAO.tblHtmlMailRule_Delete(Attribute);
    }

    public DataTable GetAll()
    {
        return hmrDAO.GetAll();
    }

    public DataTable GetByID(string Attribute)
    {
        return hmrDAO.GetByID(Attribute);
    }

    #endregion
}
