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
/// Summary description for DepartmentDTO
/// </summary>
public class RoleDetailDTO
{
    public RoleDetailDTO()
	{
	}
    public int roleId { get; set; }
    public int departmentId { get; set; }
    public int limitSendMail { get; set; }
    public int limitCreateCustomer { get; set; }
    public DateTime toDate { get; set; }
}
