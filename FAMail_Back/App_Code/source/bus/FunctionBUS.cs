using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FunctionBUS
/// </summary>
public class FunctionBUS
{
    FunctionDAO sign = null;
	public FunctionBUS()
	{
        sign = new FunctionDAO();
	}
    //public void tblFunction_insert(FunctionDTO dt)
    //{
    //    //sign.tblSignature_insert(dt);
    //    sign.tblFunction_insert(dt);
    //}
    public void tblFunction_insert(FunctionDTO dt)
    {
        sign.tblFunction_insert(dt);
    }
    public bool tblFunction_Delete(int functionId )
    {
        return sign.tblFunction_Delete(functionId);
    }
    public System.Data.DataTable GetAll()
    {
        return sign.GetAll();
    }
    public System.Data.DataTable GetByFunctionId(int functionId)
    {
        return sign.GetByUserId(functionId);
    }
    //public System.Data.DataTable GetByUserId(int functionId)
    //{
    //    return sign.GetByUserId(functionId);
    //}




    public System.Data.DataTable GetByUserId(int functionId)
    {
        return sign.GetByUserId(functionId);
    }
    //public void tblSignature_Update(SignatureDTO dt)
    //{
    //    //sign.tblSignature_Update(dt);
    //    sign.tblFunction_insert(dt);
    //}
    public void tblSignature_Update(FunctionDTO dt)
    {
        sign.tblFunction_Update(dt);
    }
   

    public DataTable tblFunction_GetByID(string functionName)
    {
        return sign.tblFunction_GetByID(functionName);
    }


    public DataTable GetbyPackage(int packageId)
    {
        return sign.GetbyPackage(packageId);
    }
    public DataTable kiemtraxoa_tblClientFunction(int functionId)
    {
        return sign.kiemtraxoa_tblClientFunction(functionId);

    }
    public DataTable kiemtraxoa_tblPackageFunction(int functionId)
    {
        return sign.kiemtraxoa_tblPackageFunction(functionId);
    }

}