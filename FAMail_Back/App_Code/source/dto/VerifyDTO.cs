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
/// Summary description for VerifyDTO
/// </summary>
public class VerifyDTO
{
    public VerifyDTO()
	{
	}
    public string EmailVerify { get; set; }
    public int userId { get; set; }
    public int isdelete { get; set; }

}
