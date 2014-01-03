using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for EventBUS
/// </summary>
public class EventBUS:IEvent
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

    public DataTable GetByUserId(int userId)
    {
        return eDao.GetByUserId(userId);
    }
    #endregion




    public void tblEventCustomer_Update(int eventId, int customerId, int count)
    {
        eDao.tblEventCustomer_Update( eventId, customerId,count);
    }
}
