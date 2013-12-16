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
/// Summary description for CustomerBUS
/// </summary>
public class ClientBUS : IClient
{
    ClientDAO ctDao = null;
    public ClientBUS()
    {
        ctDao = new ClientDAO();
    }

    public bool Customer_Lock_Unlock(int Id, Common.clientStatus status)
    {
        return ctDao.Customer_Lock_Unlock(Id, status);
    }

    public DataTable Search(string name, string email, int sex, bool isCheckExpire, string from, string to)
    {
        return ctDao.Search(name, email, sex, isCheckExpire, from, to);
    }

    public DataTable GetByID(int Id)
    {
        return ctDao.GetByID(Id);
    }

    public DataTable GetByEmail(string Email)
    {
        return ctDao.GetByEmail(Email);
    }
    public void UpdateInfomation(int clientid, string name, string adddress, DateTime dateofbirth, string phone)
    {
        ctDao.UpdateInfomation(clientid, name, adddress, dateofbirth, phone);
    }
    public void UpdateExtendLicense(string clientid, DateTime activeday, DateTime expireday)
    {
        ctDao.UpdateExtendLicense(clientid, activeday, expireday);
    }
}
