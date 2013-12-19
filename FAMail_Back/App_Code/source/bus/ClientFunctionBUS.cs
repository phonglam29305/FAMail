using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClientFunctionBUS
/// </summary>
public class ClientFunctionBUS
{
    ClientFunctionDAO clientfunction = new ClientFunctionDAO();
	public ClientFunctionBUS()
	{
		
	}
    public DataTable GetByregisterIdandclientId(int Id, int Id2)
    {
        return clientfunction.GetByregisterIdandclientId(Id, Id2);
    }
    public void UpdateFunction(int registerId, int clientId, int functionId)
    {
        clientfunction.UpdateFunction(registerId,clientId,functionId);
    }
}