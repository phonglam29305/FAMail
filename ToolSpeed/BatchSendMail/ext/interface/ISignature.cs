using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
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
