<%@ Application Language="C#" %>

<script runat="server">
    
  
    void Application_Start(object sender, EventArgs e)   {
        string strConnect = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        Email.ConnectionData._ConnectionString = strConnect;
        Email.ConnectionData.AddNewConnection();
        //processEmail = new Email.ProcessSendEmail();
        //StartMailChecker();        
    }
   
       
</script>
