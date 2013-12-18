using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClientRegisterBUS
/// </summary>
public class ClientRegisterBUS
{
	public ClientRegisterBUS()
	{
		
	}
    ClientRegisterDAO clientdao = new ClientRegisterDAO();
    public DataTable GetbyID(int id)
    {
        return clientdao.GetByID(id);
    }
public DataTable Search_client_register(string clientName, string namepackagelimit, string registerTime_from, string registerTime_to, string expireDate_from, string expireDate_to)
    {
        return clientdao.Search_client_register(clientName, namepackagelimit, registerTime_from, registerTime_to, expireDate_from, expireDate_to);
    }

    public DataTable GetAllPackage()
    {
        return clientdao.GetAllPackage();
    }
    public int UpdateUpgrade(int clientId, int packageId, int limitId, int SubAccount, float totalFee, int registerType, int packagetimeid, string From, string To, string LastRegisterFrom, string LastRegisterTo, int LastRegisterFee, int LastRegisterFeeRemain)
    {
        return clientdao.UpdateUpgrade(clientId, packageId, limitId, SubAccount, totalFee, registerType, packagetimeid,From,To,LastRegisterFrom,LastRegisterTo,LastRegisterFee,LastRegisterFeeRemain);
    }
}