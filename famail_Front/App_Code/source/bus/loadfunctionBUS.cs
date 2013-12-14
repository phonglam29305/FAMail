using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for loadfunction
/// </summary>
public class loadfunctionBUS

{
    loadfunction load = new loadfunction();
	public loadfunctionBUS()
	{
		
	}
    public DataTable loadfunction()
    {
        return load.GetAllPackage();
    }
}