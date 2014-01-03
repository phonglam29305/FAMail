using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for OrderDTO
/// </summary>
public class OrderDTO
{
	public OrderDTO()
	{
		
	}
    public string OrderID { get; set; }
	public DateTime CreateDate { get; set; }
	public int CustomerID { get; set; }
	public string PersonCreate { get; set; }
	public bool Status { get; set; }
	public DateTime DeliveryDate { get; set; }
	public string DeliveryMethod { get; set; }
	public string PaymentMethod { get; set; }
    public float HandSel { get; set; }
}
