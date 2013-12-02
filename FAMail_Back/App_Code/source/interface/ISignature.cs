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
/// Summary description for ISignature
/// </summary>
public interface ISignature
{
    void tblSignature_insert(SignatureDTO dt);
    void tblSignature_Update(SignatureDTO dt);
    void tblSignature_Delete(int id);
    DataTable GetAll();
    DataTable GetByUserId(int userId);
    DataTable GetById(int id);
}
