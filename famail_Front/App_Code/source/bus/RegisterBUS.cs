using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for dangkyBUS
/// </summary>
public class RegisterBUS
{
    RegisterDAO dangky = new RegisterDAO();
	public RegisterBUS()
	{
		
	}

    public DataTable GetByUserId(int id)
    {
        return dangky.GetByUserId(id);
    }
    public DataTable Getpackagetime()
    {
        return dangky.GetAllPackagetime();
    }
    public void Insert_client(clientdto client, clientRegisterdto clientRegister)
    {
        dangky.Insert_Client(client, clientRegister);
    }
    
}