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
/// Summary description for SendRegisterBUS
/// </summary>
public class SendRegisterBUS : ISendRegister
{
    public SendRegisterBUS() { }
    SendRegisterDAO srDao = new SendRegisterDAO();
    SendRegisterDetailDAO srgDao = new SendRegisterDetailDAO();

    #region ISendRegister Members


    public void tblSendRegister_insert(SendRegisterDTO dt)
    {
        srDao.tblSendRegister_insert(dt);
    }

    public void tblSendRegister_Update(SendRegisterDTO dt)
    {
        srDao.tblSendRegister_Update(dt);
    }

    public void tblSendRegister_Delete(int ID)
    {
        srDao.tblSendRegister_Delete(ID);
        srgDao.tblSendRegisterDetail_Delete(ID);
    }

    public DataTable GetAll()
    {
        return srDao.GetAll();
    }

    public DataTable GetByID(int ID)
    {
        return srDao.GetByID(ID);
    }

    public DataTable GetByTime(DateTime befortTimeStart, int status)
    {
        return srDao.GetByTime(befortTimeStart,status);
    }

    public void tblSendRegister_UpdateStatus(int Id, int Status, DateTime EndDate)
    {
        srDao.tblSendRegister_UpdateStatus(Id, Status, EndDate);
    }

    #endregion



    #region ISendRegister Members


    public DataTable GetWailSend(DateTime Now)
    {
       return srDao.GetWailSend(Now);
    }

    #endregion

    #region ISendRegister Members


    public DataTable GetSended()
    {
       return srDao.GetSended();
    }

    #endregion

    #region ISendRegister Members


    public DataTable GetMailError(DateTime Now)
    {
        return srDao.GetMailError(Now);
    }

    #endregion

    #region ISendRegister Members


    public int GetByMailConfigID(int ID)
    {
        return srDao.GetByMailConfigID(ID);
    }

    #endregion

    #region ISendRegister Members


    public int GetByContentID(int ID)
    {
        return srDao.GetByContentID(ID);
    }

    #endregion


    public DataTable GetByStatus(int status)
    {
        return srDao.GetByStatus(status);
    }

    #region ISendRegister Members


    public DataTable GetByTimeNext(DateTime timeStart, DateTime timeEnd, int status)
    {
      return  srDao.GetByTimeNext(timeStart, timeEnd, status);
    }

    #endregion

    #region ISendRegister Members


    public string GetByAfter(DateTime timeEnd, int status)
    {
        return srDao.GetByAfter(timeEnd, status);
    }

    public int GetByBefor(DateTime timeStart, int status)
    {
        return srDao.GetByBefor(timeStart, status);
    }

    #endregion

    #region ISendRegister Members


    public DataTable GetMailError(DateTime Now, int MailConfigID)
    {
        return srDao.GetMailError(Now, MailConfigID);
    }

    public DataTable GetWailSend(DateTime Now, int MailConfigID)
    {
        return srDao.GetWailSend(Now, MailConfigID);
    }

    public DataTable GetByTimeCheck(DateTime befortTimeStart, int status)
    {
        return srDao.GetByTimeCheck(befortTimeStart, status);
    }

    public DataTable GetByStatus(int status, int MailConfigID)
    {
        return srDao.GetByStatus(status, MailConfigID);
    }

    public DataTable GetAll(int UserId)
    {
        return srDao.GetAll(UserId);
    }

    #endregion

    #region ISendRegister Members


    public int GetByGroupID(int GroupID, int status)
    {
        return srDao.GetByGroupID(GroupID, status);
    }

    #endregion

    #region ISendRegister Members


    public DataTable GetByStatusUser(int status, int AccountId)
    {
       return srDao.GetByStatusUser(status, AccountId);
    }

    #endregion
}
