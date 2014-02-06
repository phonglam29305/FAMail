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
    DataTable GetReportByEventId(int eventId);
}
