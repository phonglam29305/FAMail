using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for IMailConfig
/// </summary>
public interface IMailConfig
{
    void tblMailConfig_insert(MailConfigDTO dt);
    void tblMailConfig_Update(MailConfigDTO dt);
    void tblMailConfig_Delete(int Id);
    DataTable GetAll();
    DataTable GetByID(int Id);
    DataTable GetByEmailAndPass(string email,string pass);
    DataTable GetAll(int DepartmentID);
}
