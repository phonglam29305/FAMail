using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ViewChildBus
/// </summary>
public class ViewChildBus
{
    ViewChild view = new ViewChild();
	public ViewChildBus()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetAllChild(string idGroup)
    {
        return view.GetAllChild(idGroup);
    }
}