using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for OrderDatailDTO
/// </summary>
public class OrderDatailDTO
{
	public OrderDatailDTO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string OrderID { get; set; }
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public string DeliveryCode { get; set; }
    public string Size { get; set; }
    public float UnitPrice { get; set; }
    public int Quantity { get; set; }
    public float Total { get; set; }
    public string Note { get; set; }
}
