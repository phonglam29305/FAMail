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
}
