using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
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
