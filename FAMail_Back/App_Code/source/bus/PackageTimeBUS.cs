using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PackageTimeBUS
/// </summary>
public class PackageTimeBUS 
{
    PackageTimeDAO sign=new PackageTimeDAO();
	public PackageTimeBUS()
	{		
	}
    public void tblPackageTime_insert(PackageTimeDTO dt)
    {
       
        sign.tblPackageTime_insert(dt);
    }

    public void tblPackageTime_insert(object getPackageDTO)
    {
        throw new NotImplementedException();
    }
    public System.Data.DataTable GetAll()
    {
        return sign.GetAll();
    }
    public System.Data.DataTable GetByUserId(int packageTimeId)
    {
        return sign.GetByUserId(packageTimeId);
    }
    public bool tblPackageTime_Delete(int packageTimeId)
    {
        return sign.tblPackageTime_Delete(packageTimeId);
    }
    public void tblPackageTime_Update(PackageTimeDTO dt)
    {
   
       sign.tblpackageTime_Update(dt);
    }
}