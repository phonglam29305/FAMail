using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for IContentSendEvent
/// </summary>
public interface IContentSendEvent
{
    void tblContentSendEvent_insert(ContentSendEventDTO dt);
    int tblContentSendEvent_Update(ContentSendEventDTO dt);
    void tblContentSendEvent_Delete(int id);
    DataTable GetAll();
    DataTable GetById(int id);
    DataTable GetByEventId(int eventId);
}
