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
/// Summary description for Verify
/// </summary>
public interface IVerify
{
    void tblVerify_insert(VerifyDTO dt);
    void tblVerify_Delete(string email);
    DataTable GetAll();
    DataTable GetByUserId(int userId);
    DataTable GetByEmail(string EmailVerify, int userid);
}
