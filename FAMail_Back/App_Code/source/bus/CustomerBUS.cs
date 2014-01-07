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
public class CustomerBUS : ICustomer
{
    CustomerDAO ctDao = null;
    public CustomerBUS()
    {
        ctDao = new CustomerDAO();
    }
    #region ICustomer Members

    public int tblCustomer_insert(CustomerDTO dt)
    {
        return ctDao.tblCustomer_insert(dt);
    }
    public void tblCustomer_Update(CustomerDTO dt)
    {
        ctDao.tblCustomer_Update(dt);
    }
    public void tblCustomer_Delete(int Id)
    {
        ctDao.tblCustomer_Delete(Id);
    }
    public DataTable GetAll(string Name, string phone, string email, int assignTo)
    {
        return ctDao.GetAll(Name, phone, email, assignTo);
    }
    public DataTable GetAllFilterCustomer(string Name, string address, int assignTo,string phone)
    {
        return ctDao.GetAllFilterCustomer(Name, address, assignTo, phone);
    }
    public DataTable Search(int userId, string Name, string phone, string email, int groupid)
    {
        return ctDao.Search(userId, Name, phone, email, groupid);
    }
    public DataTable GetByID(int Id)
    {
        return ctDao.GetByID(Id);
    }

    public DataTable GetCustomerID(int Id, int assignTo)
    {
        return ctDao.GetCustomerID(Id, assignTo);
    }


    public DataTable GetByGroupID(int AssignTo)
    {
        return ctDao.GetByGroupID(AssignTo);
    }
    public DataTable GetByEmail(string Email)
    {
        return ctDao.GetByEmail(Email);
    }
    public void tblCustomer_UpdateCountBuy(int CustomerID)
    {
        ctDao.tblCustomer_UpdateCountBuy(CustomerID);
    }
    public void tblCustomer_UpdateRecive(int CustomerID, bool recivedEmail)
    {
        ctDao.tblCustomer_UpdateRecive(CustomerID, recivedEmail);
    }
    public DataTable GetByCountBuy(int countBuy)
    {
        return ctDao.GetByCountBuy(countBuy);
    }
    public DataTable GetAllByUser(int UserID)
    {
        return ctDao.GetAllByUser(UserID);
    }

    public DataTable GetEmail(string Email)
    {
        return ctDao.GetEmail(Email);
    }
    public DataTable GetCheckEmailByUserId(string Email, int UserId)
    {
        return ctDao.GetCheckEmailByUserId(Email, UserId);
    }
    public DataTable GetEmailByUser(int UserID, string Email)
    {
        return ctDao.GetEmailByUser(UserID, Email);
    }

    public System.Data.DataTable GetCountEmail(int ClientId)
    {
        return ctDao.GetCountEmail(ClientId);
    }

    public System.Data.DataTable GetCountCustomerCreatedMail(int ClientId)
    {
        return ctDao.GetCountCustomerCreatedMail(ClientId);
    }

    public DataTable GetClientId(int UserID)
    {
        return ctDao.GetClientId(UserID);
    }

    public DataTable GetClientIdSub(int UserID)
    {
        return ctDao.GetClientIdSub(UserID);
    }

    public DataTable GetAllByUserAssignTo(int UserID, int assignTo, string name, string email,string phone)
    {
        return ctDao.GetAllByUserAssignTo(UserID, assignTo, name, email, phone);
    }

    public DataTable GetCustomerByCustomerID(int UserID, int customerid, int GroupID)
    {
        return ctDao.GetCustomerByCustomerID(UserID, customerid, GroupID);
    }

    public DataTable GetAllByAssignToCustomer(int UserID, string name, string phone, string email, int assignTo)
    {
        return ctDao.GetAllByAssignToCustomer(UserID, name, phone, email, assignTo);
    }

    public DataTable GetAllCustomerDepart3(int UserID, int assignTo)
    {
        return ctDao.GetAllCustomerDepart3(UserID, assignTo);
    }

    public DataTable GetAllCustomerDepart3AssignTo(int UserID, string name, string phone, string email, int assignTo)
    {
        return ctDao.GetAllCustomerDepart3AssignTo(UserID, name, phone, email, assignTo);
    }

    #endregion

    #region ICustomer Members


    public DataTable GetByEmail(string Email, int UserID)
    {
        return ctDao.GetByEmail(Email, UserID);
    }

    #endregion


    public DataTable GetAll()
    {
        throw new NotImplementedException();
    }
}
