using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SMTPaccountBUS
/// </summary>
public class SMTPaccountBUS
{
    SMTPaccountDAO smtpaccount = new SMTPaccountDAO();
	public SMTPaccountBUS()
	{
		
	}
    public void insert(SMTPaccountDTO dt)
    {
        smtpaccount.insertSMTP(dt);
    }
  
}