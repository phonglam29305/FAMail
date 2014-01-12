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

public partial class emailtrack : System.Web.UI.Page
{
    SendRegisterDetailBUS srdBUS = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            srdBUS = new SendRegisterDetailBUS();
            if (Request.Params["emailsentID"] != null & Request.Params["email"]!=null)
                StampSentEmail(Request.Params["emailsentID"].ToString(), Request.Params["email"].ToString());
            if (Request.Params["contentid"] != null & Request.Params["email"] != null)
                StampSentEvenyEmail(Request.Params["contentid"].ToString(), Request.Params["email"].ToString());
        }
        Response.Redirect("none.gif");
    }
    private void StampSentEmail(string sReadID)
    {
        ConnectionData.OpenMyConnection();
        srdBUS.tblSendRegisterDetail_UpdateOpenMail(int.Parse(sReadID), true, DateTime.Now);
        ConnectionData.CloseMyConnection();
    }
    private void StampSentEmail(string sReadID, string Email)
    {
        ConnectionData.OpenMyConnection();
        srdBUS.tblSendRegisterDetail_UpdateOpenMail(int.Parse(sReadID), true, DateTime.Now ,Email);
        ConnectionData.CloseMyConnection();
    }
    private void StampSentEvenyEmail(string sReadID, string Email)
    {
        ConnectionData.OpenMyConnection();
        srdBUS.tblSendEventDetail_UpdateOpenMail(int.Parse(sReadID), true, DateTime.Now, Email);
        ConnectionData.CloseMyConnection();
    }
}
