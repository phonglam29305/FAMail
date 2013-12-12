using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Email;
using System.Data.SqlClient;
/// <summary>
/// Summary description for clientRegisterBUS
/// </summary>
public class clientRegisterBUS
{
    clientRegisterDAO sign = new clientRegisterDAO();
	public clientRegisterBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable Search_client_register(string clientName, string namepackagelimit, string registerTime_from, string registerTime_to, string expireDate_from, string expireDate_to)
    {
        return sign.Search_client_register(clientName, namepackagelimit, registerTime_from, registerTime_to, expireDate_from, expireDate_to);
    }

    public DataTable GetAllPackage()
    {
        return sign.GetAllPackage();
    }
}