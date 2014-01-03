using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for SendRegisterDetailBUS
/// </summary>
public class SendRegisterDetailBUS: ISendRegisterDetail
{
    public SendRegisterDetailBUS() { }
    SendRegisterDetailDAO srdDao = new SendRegisterDetailDAO();
    #region ISendRegisterDetail Members

    public int tblSendRegisterDetail_insert(SendRegisterDetailDTO dt)
    {
      return  srdDao.tblSendRegisterDetail_insert(dt);
    }


    public void tblSendRegisterDetail_Delete(int SendRegisterId)
    {
        srdDao.tblSendRegisterDetail_Delete(SendRegisterId);
    }

    public DataTable GetAll()
    {
        return srdDao.GetAll();
    }

    public DataTable GetByID(int SendRegisterId)
    {
        return srdDao.GetByID(SendRegisterId);
    }

    public DataTable GetBySendIdAndLimit(int SendRegisterId, int limit)
    {
        return srdDao.GetBySendIdAndLimit(SendRegisterId, limit);
    }

    public DataTable GetByStatus(bool status)
    {
        return srdDao.GetByStatus(status);
    }


    public void tblSendRegisterDetail_Delete(int SendRegisterId, string email)
    {
        srdDao.tblSendRegisterDetail_Delete(SendRegisterId, email);
    }
    #endregion

    #region ISendRegisterDetail Members


    public DataTable GetBySendIdAndLimit(int SendRegisterId, int limit, string EmailSend)
    {
      return  srdDao.GetBySendIdAndLimit(SendRegisterId, limit, EmailSend);
    }

    public DataTable GetByStatus(bool status, string EmailSend)
    {
        return srdDao.GetByStatus(status, EmailSend);
    }

    #endregion

    #region ISendRegisterDetail Members


    public void tblSendRegisterDetail_UpdateOpenMail(int SendRegisterDetailId, bool isOpenMail, DateTime DateOpen)
    {
        srdDao.tblSendRegisterDetail_UpdateOpenMail(SendRegisterDetailId, isOpenMail, DateOpen);
    }

    #endregion

    #region ISendRegisterDetail Members


    public void tblSendRegisterDetail_Update(int SendRegisterDetailId, DateTime StartDate, DateTime EndDate, bool Status)
    {
        srdDao.tblSendRegisterDetail_Update(SendRegisterDetailId, StartDate, EndDate, Status);

    }

    #endregion

    #region ISendRegisterDetail Members


    public DataTable GetByStatus(bool status, int SendRegisterId)
    {
        return srdDao.GetByStatus(status, SendRegisterId);
    }

    #endregion
}
