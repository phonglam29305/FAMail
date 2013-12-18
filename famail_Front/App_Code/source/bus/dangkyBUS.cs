using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for dangkyBUS
/// </summary>
public class dangkyBUS
{
    dangkyDAO dangky = new dangkyDAO();
	public dangkyBUS()
	{
		
	}

    public DataTable GetByUserId(int id)
    {
        return dangky.GetByUserId(id);
    }
    public DataTable Getpackagetime()
    {
        return dangky.GetAllPackagetime();
    }
    public void Insert_clien(dangkydto dt)
    {
        dangky.Insert_Client(dt);
    }
    
}