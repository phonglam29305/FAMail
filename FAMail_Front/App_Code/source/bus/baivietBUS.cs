using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for baivietBUS
/// </summary>
public class baivietBUS
{
    baivietDao baiviet = new baivietDao();
	public baivietBUS()
	{	
	}
   public DataTable GetalltblConfig()
    {
        return baiviet.GetalltblConfig();

    }
   public DataTable GetalltblConfig_id(string id)
   {
       return baiviet.GetalltblConfig_id(id);
   }
   public DataTable Getalltblconfig_idgroup(string idGroup)
   {
       return baiviet.Getalltblconfig_idgroup(idGroup);
   }
}