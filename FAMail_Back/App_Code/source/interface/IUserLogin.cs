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
/// Summary description for IUserLogin
/// </summary>
public interface IUserLogin
{
    void tblUserLogin_insert(UserLoginDTO dt);
    void tblUserLogin_Update(UserLoginDTO dt);
    void tblUserLogin_Delete(int userId);
    DataTable GetAll();
    DataTable GetByUserId(int userId);
    DataTable GetByUsername(string username);
    DataTable GetByUsernameAndPass(string username,string password);
    DataTable GetByDepartmentId(int departmentId);
    void tblUpdateSendMail(int userId, int hasSendMail);
    void tblUserLogin_UpdateByDepartmentId(int departmentId, int hasSendMail);
}
