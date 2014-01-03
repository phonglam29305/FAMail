using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for ICustomer
/// </summary>
public interface ICustomer
{
    int tblCustomer_insert(CustomerDTO dt);
    void tblCustomer_Update(CustomerDTO dt);
    void tblCustomer_Delete(int Id);
    //DataTable GetAll();
    DataTable GetAllByRegisterId(int RegisterId);
    DataTable GetByID(int Id);
    DataTable GetByID(int Id, bool statusRecive);
    DataTable GetByEmail(string Email);
    void tblCustomer_UpdateCountBuy(int CustomerID);
    void tblCustomer_UpdateRecive(int CustomerID, bool recivedEmail);
    DataTable GetByCountBuy(int countBuy);
    
}
