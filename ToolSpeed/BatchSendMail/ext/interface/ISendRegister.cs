using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for ISendRegister
/// </summary>
public interface ISendRegister
{
    void tblSendRegister_insert(SendRegisterDTO dt);
    void tblSendRegister_Update(SendRegisterDTO dt);
    void tblSendRegister_Delete(int ID);
    DataTable GetAll();
    DataTable GetByID(int ID);
    DataTable GetByTime(DateTime befortTimeStart, int status);
    void tblSendRegister_UpdateStatus(int Id, int Status, DateTime EndDate);
    DataTable GetWailSend(DateTime Now);
    DataTable GetMailError(DateTime Now);
    DataTable GetSended();
    int GetByMailConfigID(int ID);
    int GetByContentID(int ID);
    DataTable GetByStatus(int status);
    DataTable GetByTimeNext(DateTime timeStart, DateTime timeEnd, int status);
    string GetByAfter(DateTime timeEnd, int status);
    int GetByBefor(DateTime timeStart, int status);
    DataTable GetMailError(DateTime Now, int MailConfigID);
    DataTable GetWailSend(DateTime Now, int MailConfigID);
    DataTable GetByTimeCheck(DateTime befortTimeStart, int status);
    DataTable GetByStatus(int status, int MailConfigID);
    DataTable GetAll(int MailConfigID);
    int GetByGroupID(int GroupID, int status);
}
