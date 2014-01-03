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
/// Summary description for MailGroup
/// </summary>
public class MailGroupBUS : IMailGroup
{
    public MailGroupBUS()
    {
    }
    MailGroupDAO mgDao = new MailGroupDAO();

    #region IMailGroup Members

    public void tblMailGroup_insert(MailGroupDTO dt)
    {
        mgDao.tblMailGroup_insert(dt);
    }

    public void tblMailGroup_Update(MailGroupDTO dt)
    {
        mgDao.tblMailGroup_Update(dt);
    }

    public void tblMailGroup_Delete(int ID)
    {
        mgDao.tblMailGroup_Delete(ID);
    }

    public DataTable GetAll()
    {
        return mgDao.GetAll();
    }

    public DataTable GetByID(int Id)
    {
        return mgDao.GetByID(Id);
    }

    public DataTable GetSubClientByAssignUserID(int Id)
    {
        return mgDao.GetSubClientByAssignUserID(Id);
    }


    public DataTable GetAll(int userid)
    {
        return mgDao.GetAll(userid);
    }

    public DataTable GetGroupMailDepart2(int userid)
    {
        return mgDao.GetGroupMailDepart2(userid);
    }

    

    public DataTable GetAllAssignTo(int MailConfigID)
    {
        return mgDao.GetAllAssignTo(MailConfigID);
    }
    public DataTable GetAllNew(int userId)
    {
        return mgDao.GetAllNew(userId);
    }

    public DataTable GetAllNewDepart3(int AssignTouserId)
    {
        return mgDao.GetAllNewDepart3(AssignTouserId);
    }

    public DataTable GetSubClientBySubID(int subId)
    {
        return mgDao.GetSubClientBySubID(subId);
    }


    public DataTable GetAllNew()
    {
        return mgDao.GetAllNew();
    }

    public DataTable GetSubClient(int clientId)
    {
        return mgDao.GetSubClient(clientId);
    }

    public DataTable GetSubClientAll()
    {
        return mgDao.GetSubClientAll();
    }

    #endregion


}
