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
/// Summary description for SpamRuleBUS
/// </summary>
public class SpamRuleBUS : ISpamRule
{
    SpamRuleDAO SpamDao = null;
	public SpamRuleBUS()
	{
        SpamDao = new SpamRuleDAO();
	}

    #region ISpamRule Members

    public int tblSpamRule_insert(SpamRuleDTO dt)
    {
        return SpamDao.tblSpamRule_insert(dt);
    }

    public int tblSpamRule_Update(SpamRuleDTO dt)
    {
        return SpamDao.tblSpamRule_Update(dt);
    }

    public void tblSpamRule_Delete(string Keyword)
    {
        SpamDao.tblSpamRule_Delete(Keyword);
    }

    public DataTable tblSpamRule_SearchByKeyword(string Keyword)
    {
     return   SpamDao.tblSpamRule_SearchByKeyword(Keyword);
    }

    public DataTable GetAll()
    {
        return SpamDao.GetAll();
    }

    #endregion

    #region ISpamRule Members


    public DataTable tblSpamRule_GetByID(string Keyword)
    {
        return SpamDao.tblSpamRule_GetByID(Keyword);
    }

    #endregion
}
