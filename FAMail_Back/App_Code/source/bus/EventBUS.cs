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
/// Summary description for EventBUS
/// </summary>
public class EventBUS : IEvent
{
    public EventBUS() { }

    #region IEvent Members
    EventDAO eDao = new EventDAO();
    public int tblEvent_insert(EventDTO dt)
    {
        return eDao.tblEvent_insert(dt);
    }

    public void tblEvent_Update(EventDTO dt)
    {
        eDao.tblEvent_Update(dt);
    }

    public void tblEvent_Delete(int EventId)
    {
        eDao.tblEvent_Delete(EventId);
    }

    public DataTable GetAll()
    {
        return eDao.GetAll();
    }

    public DataTable GetByID(int EventId)
    {
        return eDao.GetByID(EventId);
    }

    public DataTable GetAllListEvent(string subject, int userId, int group)
    {
        return eDao.GetAllListEvent(subject, userId, group);
    }

    public DataTable GetAllListEventDepart2(string subject, int userId, int group)
    {
        return eDao.GetAllListEventDepart2(subject, userId, group);
    }

    public DataTable GetAssignTo(int groupId)
    {
        return eDao.GetAssignTo(groupId);
    }


    public DataTable GetByUserId(int userId)
    {
        return eDao.GetByUserId(userId);
    }
    #endregion



}
