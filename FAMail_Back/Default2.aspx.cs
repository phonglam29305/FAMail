using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    //public static string CalculateCost(string myParam)
    //{
    //    string rasd = "Success catching event!!!";
    //    return rasd;
    //}
    public static string CalculateCost(string args)
    {
        string returnValue = string.Empty;
        returnValue ="Your current selected value is " + args.Trim();
        return returnValue;
    }
    [WebMethod]
    public static string sbGetData(string sdPreNo)
    {
        return sdPreNo+" hurray";
    }
}