using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for IEvent
/// </summary>
public interface IEvent
{
     int tblEvent_insert(EventDTO dt);
     void tblEvent_Update(EventDTO dt);
     void tblEvent_Delete(int EventId);
     DataTable GetAll();
     DataTable GetByID(int EventId);
     DataTable GetByUserId(int userId);
     void tblEventCustomer_Update(int eventId, int customerId, int count);
}
