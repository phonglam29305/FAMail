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
/// Summary description for IPartSend
/// </summary>
public interface IPartSend
{
    void tblPartSend_insert(PartSendDTO dt);
    void tblPartSend_update(PartSendDTO dt);
    void tblPartSend_Delete(int userId, int groupId);
    DataTable GetAll();
    DataTable GetByUserIdAndGroupId(int userId, int groupId);    
}
