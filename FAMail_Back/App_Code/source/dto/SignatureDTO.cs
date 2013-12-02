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
/// Summary description for MailGroupDTO
/// </summary>
public class SignatureDTO
{
    public SignatureDTO()
	{
	}
    public int id { get; set; }
    public int userId { get; set; }
    public string signatureContent { get; set; }
    public string SignatureName { get; set; }

}
