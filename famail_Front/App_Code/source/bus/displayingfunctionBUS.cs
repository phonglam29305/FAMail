using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for displayingfunctionBUS
/// </summary>
public class displayingfunctionBUS
{
    displayingfunction display = new displayingfunction();
    LoadFunctionPackageDAO sign = new LoadFunctionPackageDAO();
	public displayingfunctionBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetAllfunction()
    {
        return display.GetAllfunction();
    }
    //public DataTable GetAllpackeg()
    //{
    //    return display.GetAllpakeg();
    //}
    public DataTable LoadFunctionPackage(int id)
    {
      return  sign.dispalyfunctionpackage(id);
    }

    public DataTable GetAllpackeg()
    {
        return display.GetAllpakeg();
    }

    public DataTable GetAllpackeg1(string ten)
    {
        return display.GetAllpakeg();
    }
    public DataTable GetbyPackage(int packageId)
    {
        return display.GetbyPackage(packageId);
    }
}