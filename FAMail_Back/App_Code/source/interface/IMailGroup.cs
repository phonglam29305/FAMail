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
/// Summary description for IMailGroup
/// </summary>
public interface IMailGroup
{
    void tblMailGroup_insert(MailGroupDTO dt);
    void tblMailGroup_Update(MailGroupDTO dt);
    void tblMailGroup_Delete(int ID);
    DataTable GetAll();
    DataTable GetByID(int Id);
    DataTable GetAll(int userId);
    DataTable GetMailGroupByUserId(int userId);
    DataTable GetAllNew();
}
