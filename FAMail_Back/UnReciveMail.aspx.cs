using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Email;

public partial class UnReciveMail : System.Web.UI.Page
{
    static int SendRegisterID = 0;
    SendRegisterDetailBUS srdBUS = null;
    CustomerBUS ctBUS = new CustomerBUS();
    static  string email = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            srdBUS = new SendRegisterDetailBUS();
            if (Request.Params["sendRegisterId"] != null & Request.Params["email"] != null)
            {
                SendRegisterID = int.Parse(Request.Params["sendRegisterId"].ToString());
                email = Request.Params["email"].ToString();
            }
        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        ConnectionData.OpenMyConnection();
        srdBUS = new SendRegisterDetailBUS();
        ctBUS = new CustomerBUS();
        srdBUS.tblSendRegisterDetail_UpdateUnreceve(SendRegisterID, true, DateTime.Now, email);
        DataTable table=   ctBUS.GetByEmail(email);
        int customerID = int.Parse(table.Rows[0]["Id"].ToString());
        ctBUS.tblCustomer_UpdateRecive(customerID, false);
        ConnectionData.CloseMyConnection();
    }
}
