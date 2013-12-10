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
/// Summary description for CustomerDTO
/// </summary>
public class ClientDTO
{
    public ClientDTO()
    {

    }
    public int ClientId { get; set; }
    public string ClientName { get; set; }
    public string Sex { get; set; }
    public DateTime DayOfBirth { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Fax { get; set; }
    public string CompanyName { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string Country { get; set; }
    public string Type { get; set; }
    public DateTime registerTime { get; set; }
    public DateTime registerDate { get; set; }
    public int status { get; set; }
    public DateTime activeDate { get; set; }
    public DateTime expireDate { get; set; }
    public int lastRegisterId { get; set; }
    public int registerId { get; set; }
    public float fee { get; set; }
    public int subAccountCount { get; set; }
    public int UserID { get; set; }

}
