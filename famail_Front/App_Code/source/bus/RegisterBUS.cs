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
    public DataTable GetPackageById(int id)
    {
        return dangky.GetPackageById(id);
    }
    public int Insert_client(clientdto client, clientRegisterdto clientRegister, UserLoginDTO ulDto)
    {
        return dangky.Register(client, clientRegister,  ulDto);
    }



    public bool CheckExistByEmail(string Email)
    {
        return dangky.CheckExistByEmail(Email);
    }
    public DataTable kiemtramail(string email)
    {
        return dangky.kientratrungemail(email);
    }
}