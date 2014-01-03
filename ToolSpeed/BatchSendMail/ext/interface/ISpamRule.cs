using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for ISpamRule
/// </summary>
public interface ISpamRule
{
    int tblSpamRule_insert(SpamRuleDTO dt);
    int tblSpamRule_Update(SpamRuleDTO dt);
    void tblSpamRule_Delete(string Keyword);
    DataTable tblSpamRule_SearchByKeyword(string Keyword);
    DataTable GetAll();
    DataTable tblSpamRule_GetByID(string Keyword);
    
}
