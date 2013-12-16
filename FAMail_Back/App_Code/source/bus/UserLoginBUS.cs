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

    public void tblUserLoginSubClient_insert(UserLoginDTO dt)
    {
        ulDao.tblUserLoginSubClient_insert(dt);
    }

    public void tblSubClient_insert(UserLoginDTO dt)
    {
        ulDao.tblSubClient_insert(dt);
    }

    public void tblUserLogin_Update(UserLoginDTO dt)
    {
        ulDao.tblUserLogin_Update(dt);
    }

    public void tblSubClient_Update(UserLoginDTO dt)
    {
        ulDao.tblSubClient_Update(dt);
    }

    public void tblUserLoginSub_Update(int UserID,bool Is_Block)
    {
        ulDao.tblUserLoginSub_Update(UserID, Is_Block);
    }

    public void tblUserLogin_Delete(int userId)
    {
        ulDao.tblUserLogin_Delete(userId);
    }

    public void tblSubClient_Delete(int userId)
    {
        ulDao.tblSubClient_Delete(userId);
    }

    public System.Data.DataTable GetAll()
    {
        return ulDao.GetAll();
    }

    public System.Data.DataTable GetSubClient()
    {
        return ulDao.GetSubClient();
    }


    public System.Data.DataTable GetIsBlockByUserId(int userId)
    {
        return ulDao.GetIsBlockByUserId(userId);
    }

    public System.Data.DataTable GetByUserId(int userId)
    {
        return ulDao.GetByUserId(userId);
    }

    public System.Data.DataTable GetAllByUserId(int userId)
    {
        return ulDao.GetAllByUserId(userId);
    }


    public System.Data.DataTable GetUserIDByUserName(string username)
    {
        return ulDao.GetUserIDByUserName(username);
    }

    public System.Data.DataTable GetBySubId(int subId)
    {
        return ulDao.GetBySubId(subId);
    }

    public System.Data.DataTable GetClientId(int userId)
    {
        return ulDao.GetClientId(userId);
    }

    public System.Data.DataTable GetUserIdBySubID(int subId)
    {
        return ulDao.GetUserIdBySubID(subId);
    }


    public System.Data.DataTable GetByUsername(string username)
    {
        return ulDao.GetByUsername(username);
    }


    public System.Data.DataTable GetByUsernameAndPass(string username, string password)
    {
        return ulDao.GetByUsernameAndPass(username, password);
    } 


    public System.Data.DataTable GetByUserType(int departmentId)
    {
        return ulDao.GetByUserType(departmentId);
    }


    public System.Data.DataTable GetByDepartmentId(int departmentId)
    {
        return ulDao.GetByDepartmentId(departmentId);
    }

    public void tblUserLogin_Update(int userId, int hasSendMail)
    {
        ulDao.tblUserLogin_Update(userId, hasSendMail);
    }
    public void tblUserLogin_UpdateByDepartmentId(int departmentId, int hasSendMail)
    {
        ulDao.tblUserLogin_UpdateByDepartmentId(departmentId, hasSendMail);
    }
   
}