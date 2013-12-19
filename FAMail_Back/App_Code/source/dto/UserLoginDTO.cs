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
/// Summary description for UserLoginDTO
/// </summary>
public class UserLoginDTO
{
    public UserLoginDTO()
    {
    }
    public int UserId { get; set; }
    public int SubId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int DepartmentId { get; set; }
    public int hasSendMail { get; set; }
    public int hasCreatedCustomer { get; set; }
    public int UserType { get; set; }
    public string Email { get; set; }
    public bool Is_Block { get; set; }
    public int ClientID { get; set; }
    public int Deleted { get; set; }
}
