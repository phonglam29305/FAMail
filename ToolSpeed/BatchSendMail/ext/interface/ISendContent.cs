using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for ISendContent
/// </summary>
public interface ISendContent
{
    int tblSendContent_insert(SendContentDTO dt);
    void tblSendContent_Update(SendContentDTO dt);
    void tblSendContent_Delete(int Id);
    DataTable GetAll();
    DataTable GetByID(int Id);
    DataTable GetAll(int userId);
}
