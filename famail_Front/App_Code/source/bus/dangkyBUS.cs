﻿using System;
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

    public DataTable GetByUserId(int packageId)
    {
        return dangky.GetByUserId(packageId);
    }

    
}