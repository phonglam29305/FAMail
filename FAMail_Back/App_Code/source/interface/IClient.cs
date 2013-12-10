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
public interface IClient
{
    bool Customer_Lock_Unlock(int Id, Common.clientStatus status);
    DataTable Search(string name, string email, int sex, bool isCheckExpire, string from, string to);
    DataTable GetByID(int Id);
    DataTable GetByEmail(string Email);   
    
}
