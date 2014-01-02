using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PackageLimitBUS
/// </summary>
public class PackageLimitBUS
{
    PackageLimitDAO sign = null;
	public PackageLimitBUS()
	{
        sign = new PackageLimitDAO();
	}
    public void tblPackageLimit_insert(PackageLimitDTO dt)
    {
        sign.tblPackageLimit_insert(dt);
    }
    public void tblPackageLimit_Delete(int limitId)
    {
        sign.tblPackageLimit_Delete(limitId);
    }
    public System.Data.DataTable GetAll()
    {
        return sign.GetAll();
    }

    public System.Data.DataTable GetByUserIdPackageLimit(int limitId)
    {
        return sign.GetByUserIdPackageLimit(limitId);
    }
    public void tblPackageLimit_Update(PackageLimitDTO dt)
    {
        
        sign.tblPackageLimit_Update(dt);
    }
    public DataTable GetAvailablePackage(int limitId)
    {
        return sign.GetAvailablePackage(limitId);
    }
    public DataTable viladate_Packagelimint(string namepackagelimit,object id)
    {
        return sign.viladate_Packagelimint(namepackagelimit,id);
    }
    public DataTable check_delete_package(int limitId)
    {
        PackageLimitDAO pa = new PackageLimitDAO();
        return pa.check_delete_package(limitId);

    }
    public DataTable check_delete_clientregister(int limitId)
    {
        return sign.check_delete_clientregister(limitId);
    }

}