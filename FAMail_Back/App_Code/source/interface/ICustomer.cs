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
/// Summary description for ICustomer
/// </summary>
public interface ICustomer
{
    int tblCustomer_insert(CustomerDTO dt);
    void tblCustomer_Update(CustomerDTO dt);
    void tblCustomer_Delete(int Id);
    DataTable GetAll();
    DataTable GetByID(int Id);
    DataTable GetByEmail(string Email);
    DataTable GetByEmail(string Email, int UserID);
    void tblCustomer_UpdateCountBuy(int CustomerID);
    void tblCustomer_UpdateRecive(int CustomerID, bool recivedEmail);
    DataTable GetByCountBuy(int countBuy);
    DataTable GetAllByUser(int UserID);
    
}
