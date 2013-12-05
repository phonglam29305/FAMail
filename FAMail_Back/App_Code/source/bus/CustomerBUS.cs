﻿using System;
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
public class CustomerBUS:ICustomer
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

    public DataTable GetAll()
    {
        return ctDao.GetAll();
    }

    public DataTable GetByID(int Id)
    {
        return ctDao.GetByID(Id);
    }

    #endregion



    public DataTable GetByEmail(string Email)
    {
        return ctDao.GetByEmail(Email);
    }

 
    #region ICustomer Members



    #endregion

    #region ICustomer Members


    public void tblCustomer_UpdateCountBuy(int CustomerID)
    {
        ctDao.tblCustomer_UpdateCountBuy(CustomerID);
    }

    public void tblCustomer_UpdateRecive(int CustomerID, bool recivedEmail)
    {
        ctDao.tblCustomer_UpdateRecive(CustomerID, recivedEmail);
    }

    #endregion

    #region ICustomer Members


    public DataTable GetByCountBuy(int countBuy)
    {
        return ctDao.GetByCountBuy(countBuy);
    }

    #endregion
}