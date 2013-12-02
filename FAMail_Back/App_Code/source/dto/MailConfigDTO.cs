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
/// Summary description for MailConfigDTO
/// </summary>
public class MailConfigDTO
{
    public int Id { get; set; }
    public string Server { get; set; }
    public int Port { get; set; }
    public string Email { get; set; }
    public string username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public int DepartmentID { get; set; }
    public int parentId { get; set; }
    public int levelId { get; set; }
    public bool isSSL { get; set; }
    public int userId { get; set; }
	public MailConfigDTO()
	{
		
	}
}
