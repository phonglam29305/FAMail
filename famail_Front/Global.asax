<%@ Application Language="C#" %>

<script runat="server">
    
  
    void Application_Start(object sender, EventArgs e)   {
        string strConnect = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        Email.ConnectionData._ConnectionString = strConnect;
        Email.ConnectionData.AddNewConnection();
        //processEmail = new Email.ProcessSendEmail();
        //StartMailChecker();        
    }
    void Application_Error(object sender, EventArgs e)
    {
        //There should be some checking done so that not all the errors
        //are cleared
        Context.ClearError();
    }
    void Application_EndRequest(object sender, EventArgs e)
    {
        Response.Cookies.Add(new HttpCookie("Test", "Test"));
    }
       
</script>
