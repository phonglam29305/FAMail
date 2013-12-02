using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for ProductDTO
/// </summary>
public class ProductDTO
{
	public ProductDTO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int ID { get; set; }
    public string Title { get; set; }
    public DateTime AddedDate { get; set; }
    public string AddedBy { get; set; }
    public DateTime LastModifyDate { get; set; }
    public string LastModifyBy { get; set; }
    public string Description { get; set; }
    public string Excerpt { get; set; }
    public string BodyContent { get; set; }
    public object UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
    public string Thumbnail { get; set; }
    public int Category { get; set; }
    public int Manufacture { get; set; }
    public int PriorityOrder { get; set; }
    public bool IsDelete { get; set; }
    public string Tag { get; set; }
    public int Currency { get; set; }
    public int Tax { get; set; }
    public int Views { get; set; }
    public bool IsNew { get; set; }
    public string Code { get; set; }
    public bool originalprice { get; set; }
    public float DiscountPercentage { get; set; }
    public bool UnitPercent { get; set; }

}
