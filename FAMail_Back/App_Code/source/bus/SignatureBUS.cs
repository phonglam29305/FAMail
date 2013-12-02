using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SignatureBUS
/// </summary>
public class SignatureBUS:ISignature
{
    SignatureDAO sign = null;
    public SignatureBUS()
    {
        sign = new SignatureDAO();
    }

    public void tblSignature_insert(SignatureDTO dt)
    {
        sign.tblSignature_insert(dt);
    }

    public void tblSignature_Update(SignatureDTO dt)
    {
        sign.tblSignature_Update(dt);
    }

    public void tblSignature_Delete(int id)
    {
        sign.tblSignature_Delete(id);
    }

    public System.Data.DataTable GetAll()
    {
        return sign.GetAll();
    }

    public System.Data.DataTable GetByUserId(int userId)
    {
        return sign.GetByUserId(userId);
    }

    #region ISignature Members


    public System.Data.DataTable GetById(int id)
    {
        return sign.GetById(id);
    }

    #endregion
}