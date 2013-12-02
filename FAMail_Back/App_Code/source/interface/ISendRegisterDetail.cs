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
/// Summary description for ISendRegisterDetail
/// </summary>
public interface ISendRegisterDetail
{
    int tblSendRegisterDetail_insert(SendRegisterDetailDTO dt);
    void tblSendRegisterDetail_Update(int SendRegisterDetailId, DateTime StartDate, DateTime EndDate, bool Status);
    void tblSendRegisterDetail_Delete(int SendRegisterId);
    DataTable GetAll();
    DataTable GetByID(int SendRegisterId);
    DataTable GetBySendIdAndLimit(int SendRegisterId, int limit);
    DataTable GetByStatus(bool status);
    void tblSendRegisterDetail_Delete(int SendRegisterId, string email);
    DataTable GetBySendIdAndLimit(int SendRegisterId, int limit, string EmailSend);
    DataTable GetByStatus(bool status, string EmailSend);
    void tblSendRegisterDetail_UpdateOpenMail(int SendRegisterDetailId, bool isOpenMail, DateTime DateOpen);
    DataTable GetByStatus(bool status, int SendRegisterId);
    void tblSendRegisterDetail_UpdateOpenMail(int SendRegisterId, bool isOpenMail, DateTime DateOpen, string Email);
    DataTable GetByOpenMail(int SendRegisterId); 
    DataTable GetByNotReceve(int SendRegisterId);
    void tblSendRegisterDetail_UpdateUnreceve(int SendRegisterId, bool isUnreceve, DateTime DateUnreceve, string Email);
}
