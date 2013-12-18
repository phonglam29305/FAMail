using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for dangkydto
/// </summary>
public class clientdto
{
	public clientdto()
	{
	}
    public int packageTimeId { get; set; }
    public string clientName { get; set; }
    public string address { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string companyName { get; set; }
}