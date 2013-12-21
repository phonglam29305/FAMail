<%@ Application Language="C#" %>

<script runat="server">
    
    static System.Threading.Timer _mailCheckerTimer;
    static System.Threading.Timer _mailSendTimer;
    static System.Threading.Timer _systemTimer;
    Email.ProcessSendEmail processEmail;
    SendRegisterBUS srBUS = new SendRegisterBUS();
    CustomerBUS cBUS = new CustomerBUS();
    MailConfigBUS mcBUS = new MailConfigBUS();
    SendContentBUS scBUS = new SendContentBUS();
    DetailGroupBUS dgBUS = new DetailGroupBUS();
    Common common = new Common();
    public static System.Data.DataTable listSendRegister = new System.Data.DataTable();
    public static System.Data.DataTable listSendContent = new System.Data.DataTable();
    public static System.Data.DataTable listCustomer = new System.Data.DataTable();
    public static System.Data.DataTable listMailConfig = new System.Data.DataTable();
    public static int sendRegisterId;
    public static bool find;
    log4net.ILog logs = log4net.LogManager.GetLogger("ErrorRollingLogFileAppender");
    // chuoi ket noi 
    void Application_Start(object sender, EventArgs e)   {
        log4net.Config.XmlConfigurator.Configure();
        string strConnect = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        Email.ConnectionData._ConnectionString = strConnect;
        Email.ConnectionData.AddNewConnection();
        //processEmail = new Email.ProcessSendEmail();
       // StartMailChecker();  


    }
    void timScheduledTask_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
       
    }
    
    void Application_End(object sender, EventArgs e) 
    {
      
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
    }

    void Session_Start(object sender, EventArgs e) 
    {
    }

    void Session_End(object sender, EventArgs e) 
    {
    }
    public void StartMailChecker()
    {
        //Tạo thời gian kiểm tra Email cần gửi
        TimeSpan dueTime = TimeSpan.FromSeconds(1);
        TimeSpan systemDueTime = TimeSpan.FromSeconds(1);

        _mailCheckerTimer = new System.Threading.Timer(MyRoutineToCall, null, TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(2));
        _mailSendTimer = new System.Threading.Timer(CallSendEmail, null, dueTime, TimeSpan.FromSeconds(29));
    }
    public void changeSendTimer(int start, int end)
    {
        _mailSendTimer.Change(start, end);
    }

    public void mailCheckerTimer(int start, int end)
    {
        _mailCheckerTimer.Change(start, end);
    }
    //Phương thức dừng kiểm tra Email
    public void StopMailChecker()
    {
        if (_mailCheckerTimer != null)        
        {
            _mailCheckerTimer.Change(-1, -1);
            _mailCheckerTimer.Dispose();
            _mailCheckerTimer = null;
            _mailSendTimer.Change(-1, -1);
            _mailSendTimer.Dispose();
            _mailSendTimer = null;
        }
    }
   
    public  void MyRoutineToCall(Object state)
    {
        if (Email.ProcessSendEmail.Stop == false)
        {
            GetData();
        }
    }
    public void MyRoutineToSend(Object state)
    {       
        TimeSpan systemDueTime = TimeSpan.FromSeconds(5);        
        _systemTimer = new System.Threading.Timer(CallSendEmail, null, systemDueTime, systemDueTime);
        
    }
    protected void CallSendEmail(Object state)
    {
        try
        {
            System.Data.DataRow Row = null;
            DateTime currentDate = DateTime.Now;
            for (int i = 0; i < listSendRegister.Rows.Count; i++)
            {
                System.Data.DataRow rowTemp = listSendRegister.Rows[i];
                DateTime dateItem = DateTime.Parse(rowTemp["StartDate"].ToString());
                if (currentDate.Year == dateItem.Year && currentDate.Month == dateItem.Month
                    && currentDate.Day == dateItem.Day && currentDate.Hour == dateItem.Hour)
                   // && currentDate.Minute == dateItem.Minute)
                {
                    Row = rowTemp;
                    break;
                }
            }
            if (Row != null)
            {              
                int currentSendRegisterId = int.Parse(Row["Id"].ToString());
                if (currentSendRegisterId != sendRegisterId)
                {
                    sendRegisterId = currentSendRegisterId;
                    string groupId = Row["GroupTo"].ToString();
                    System.Data.DataTable tblCustomerByGroup = dgBUS.GetByID(int.Parse(groupId));
                    int countEmail = tblCustomerByGroup.Rows.Count;
                    int calcMinute = common.calculatorMinuteQuantityEmail(countEmail);
                    int total = (calcMinute + 1) * 60;
                    
                    //Hùng thêm ngày 16/09
                    //processEmail.callSendBulkMail(Row, listSendContent, listCustomer, listMailConfig);   
                    // Code mới
                    processEmail.callSendBulkMail_BySubGroup(Row, listSendContent, listCustomer, listMailConfig);  
                }                       
            }       
        }
        catch (Exception ex )
        {
            Console.WriteLine(ex.ToString()); logs.Error("Global-CallSendEmail" + ex);
        }   
    }
    public void GetData()
    {
        try
        {
            Email.ConnectionData.OpenMyConnection();
            listCustomer.Clear();
            listSendRegister.Clear();
            listMailConfig.Clear();
            listSendContent.Clear();

            //lấy danh sách đăng ký gửi ( tính từ ngày hiện tại)
            listSendRegister = srBUS.GetByTime(DateTime.Now, 0);
            //listCustomer = cBUS.GetAll();
            listMailConfig = mcBUS.GetAll();
            listSendContent = scBUS.GetAllWidthBody();
            Email.ConnectionData.CloseMyConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString()); logs.Error("Global-GetData" + ex);
        }    
    }
       
</script>
