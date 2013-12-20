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
/// Summary description for SendContentBUS
/// </summary>
public class SendContentBUS:ISendContent
{
    public SendContentBUS(){}
    SendContentDAO scDao = new SendContentDAO();
    #region ISendContent Members

    public int tblSendContent_insert(SendContentDTO dt)
    {
      return  scDao.tblSendContent_insert(dt);
    }

    public void tblSendContent_Update(SendContentDTO dt)
    {
        scDao.tblSendContent_Update(dt);
    }

    public void tblSendContent_Delete(int Id)
    {
        scDao.tblSendContent_Delete(Id);
    }

    public DataTable GetAll()
    {
        return scDao.GetAll();
    }
    public DataTable GetAllWidthBody()
    {
        return scDao.GetAllWidthBody();
    }

    public DataTable GetByID(int Id)
    {
        return scDao.GetByID(Id);
    }

    public DataTable GetAll(int userId)
    {
        return scDao.GetAll(userId);
    }
    #endregion

    
}
