using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  System.Data;

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
    public DataTable getall()
    {
        return smtpaccount.GetAll();
    }
    public bool smtpaccount_Delete(int id)
    {
        return smtpaccount.smtpaccount_Delete(id);
    }
    public DataTable getid(int id)
    {
        return smtpaccount.GetByid(id);
    }
    public void update(SMTPaccountDTO dt)
    {
      smtpaccount.updateSMTP(dt);
    }
  
}