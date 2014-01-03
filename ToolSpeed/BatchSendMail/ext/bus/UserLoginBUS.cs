using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserLoginBUS
/// </summary>
public class UserLoginBUS:IUserLogin
{
    UserLoginDAO ulDao = null;
	public UserLoginBUS()
	{
        ulDao = new UserLoginDAO();
	}

    public void tblUserLogin_insert(UserLoginDTO dt)
    {
        ulDao.tblUserLogin_insert(dt);
    }

    public void tblUserLogin_Update(UserLoginDTO dt)
    {
        ulDao.tblUserLogin_Update(dt);
    }

    public void tblUserLogin_Delete(int userId)
    {
        ulDao.tblUserLogin_Delete(userId);
    }

    public System.Data.DataTable GetAll()
    {
        return ulDao.GetAll();
    }

    public System.Data.DataTable GetByUserId(int userId)
    {
        return ulDao.GetByUserId(userId);
    }

    public System.Data.DataTable GetByUsername(string username)
    {
        return ulDao.GetByUsername(username);
    }


    public System.Data.DataTable GetByUsernameAndPass(string username, string password)
    {
        return ulDao.GetByUsernameAndPass(username, password);
    } 


    public System.Data.DataTable GetByDepartmentId(int departmentId)
    {
        return ulDao.GetByDepartmentId(departmentId);
    }


}