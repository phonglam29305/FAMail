using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PackageFunctionBUS
/// </summary>
public class PackageFunctionBUS
{
	public PackageFunctionBUS()
	{
		
	}
    PackageFunctionDAO sign = new PackageFunctionDAO();
    public DataTable GetFunctionbyPackageId(int packageId)
    {
        return sign.GetFunctionbyPackageId(packageId);
    }
}