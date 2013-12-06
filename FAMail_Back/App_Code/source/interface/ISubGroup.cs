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
/// Summary description for ISubGroup
/// </summary>
public interface ISubGroup
{
    void tblSubGroup_insert(SubGroupDTO dt);
    void tblSubGroup_Update(SubGroupDTO dt);
    void tblSubGroup_Delete(int IDSubGroup);
    DataTable GetAll();
    DataTable GetByID(int IDSubGroup);
}
