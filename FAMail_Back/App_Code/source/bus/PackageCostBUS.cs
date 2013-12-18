using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PackageCostBUS
/// </summary>
public class PackageCostBUS
{
	public PackageCostBUS()
	{
		
	}
    PackageCostDAO pkgDAO = new PackageCostDAO();
    public DataTable GetPackageCost(int id)
    {
        return pkgDAO.GetPackageCost(id);
    }
}