using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for MailGroupDTO
/// </summary>
public class MailGroupDTO
{
	public MailGroupDTO()
	{
		
	}
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }

}
