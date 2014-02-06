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
/// Summary description for IDetailSubGroup
/// </summary>
public interface IDetailGroup
{
    void tblDetailGroup_insert(DetailGroupDTO dt);
    void tblDetailGroup_Delete(int GroupID, int CustomerID);
    void tblDetailGroup_Update(DetailGroupDTO dt);
    void tblDetailGroup_Update(int quantity);
    DataTable GetAll();
    DataTable GetByID(int GroupID, int CustomerID);
    DataTable GetByID(int GroupID);
    object GetCountByGroupID(int GroupID);
    void tblDetailGroup_DeleteByCustomerID(int CustomerID);
    void tblDetailGroup_DeleteByGroup(int GroupID);
}
