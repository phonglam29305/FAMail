using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for CustomerDTO
/// </summary>
public class CustomerDTO
{
	public CustomerDTO()
	{
	
	}
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public DateTime BirthDay { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string SecondPhone { get; set; }
    public string Address { get; set; }
    public string Fax { get; set; }
    public string Company { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string Country { get; set; }
    public string Type { get; set; }
    public int countBuy { get; set; }
    public bool recivedEmail { get; set; }
  
}
