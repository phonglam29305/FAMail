using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SMTPaccountDTO
/// </summary>
public class SMTPaccountDTO
{
	public SMTPaccountDTO()
	{
	}
    public int  id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Accesskey { get; set; }
    public string Secreckey { get; set; }
    public string PasswordSMTP { get; set; }
    public string ServerSMTP { get; set; }
    public string UsernameSMTP { get; set; }
    public string Limit { get; set; }
}