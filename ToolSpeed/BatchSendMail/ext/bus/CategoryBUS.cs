﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for CategoryBUS
/// </summary>
public class CategoryBUS:ICategory
{
    CategoryDAO cateDao;
	public CategoryBUS()
	{
        cateDao = new CategoryDAO();
	}

    #region ICategory Members

    public DataTable GetByID(int ID)
    {
        return cateDao.GetByID(ID);
    }

    #endregion
}
