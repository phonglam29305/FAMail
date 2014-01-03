using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContentSendEventBUS
/// </summary>
public class ContentSendEventBUS : IContentSendEvent
{
    ContentSendEventDAO cseDao = new ContentSendEventDAO();
    #region IContentSendEvent Members

    public void tblContentSendEvent_insert(ContentSendEventDTO dt)
    {
        cseDao.tblContentSendEvent_insert(dt);
    }

    public int tblContentSendEvent_Update(ContentSendEventDTO dt)
    {
        return cseDao.tblContentSendEvent_Update(dt);
    }

    public void tblContentSendEvent_Delete(int id)
    {
        cseDao.tblContentSendEvent_Delete(id);
    }

    public System.Data.DataTable GetAll()
    {
        return cseDao.GetAll();
    }

    public System.Data.DataTable GetById(int id)
    {
        return cseDao.GetById(id);
    }

    public System.Data.DataTable GetByEventId(int eventId)
    {
        return cseDao.GetByEventId(eventId);
    }

    #endregion
}