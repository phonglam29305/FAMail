using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for IEventDetail
/// </summary>
public interface IEventDetail
{
    void tblEventDetail_insert(EventDetailDTO dt);
    void tblEventDetail_Update(EventDetailDTO dt);
    void tblEventDetail_Delete(int EventId);
    DataTable GetAll();
    DataTable GetByID(int EventId);
    DataTable GetByGroupId(int GroupId);
    DataTable GetByIdAndEmail(int EventId, string email);


}
