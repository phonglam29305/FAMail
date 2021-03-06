﻿using System;
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
/// Summary description for PackageBUS
/// </summary>
public class PackageBUS
{
	public PackageBUS()
	{		
	}
    PackageDAO sign = new PackageDAO();
    //public void tblFunction_insert( dt)
    //{
    //    sign.tblFunction_insert(dt);
    //}
    public DataTable GetAllPackage()
    {
        return sign.GetAllPackage();
    }
    public DataTable GetdataPackage()
    {
        return sign.GetdaPackage();
    }
    public void tblPackage_insert(PackageDTO dt)
    {
        sign.tblPackage_insert(dt);
       
    }
    public bool tblPackage_delete(int packageId)
    {
        return sign.tblPackage_Delete(packageId);
    }
    public void tblPackage_Update(PackageDTO dt)
    {
        sign.tblPackage_Update(dt);
    }

    public System.Data.DataTable GetById(int packageId)
    {
        return sign.GetById(packageId);
    }


    public bool deletePackageFuntion(int packageID)
    {
        return sign.deletePackageFuntion(packageID);
    }

    public bool addFunction(int packageID, int functionId)
    {
        return sign.addFunction(packageID,  functionId);
    }
    public DataTable GetAvailablePackage(int packageId)
    {
        return sign.GetAvailablePackage(packageId);
    }
    public DataTable validata_Namepackage(string packageName,object id)
    {
        return sign.validate_PackageName(packageName,id);
    }
    public DataTable check_delete_clientregister(int packageId)
    {
        return sign.check_delete_clientregister(packageId);
    }
   
}