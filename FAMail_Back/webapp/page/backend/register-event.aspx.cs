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

public partial class webapp_page_backend_register_event : System.Web.UI.Page
{
    EventBUS eventBus = null;
    EventDetailBUS eventDetailBus = null;
    MailConfigBUS mailConfigBus = null;
    CustomerBUS customerBus = null;
    DetailGroupBUS dgBus = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string eventId, name, email, company, phone, secondPhone, address1,
                address2, city, province, country, zipcode, fax, groupId,
                visibleField, gender, requireTime, UserID;

             eventId = Request.Params["eventId"];
             name = Request.Params["Name"];
             if (name == null || name == "")
             {
                 name = "";
             }
             email = Request.Params["Email"];
             if (email == null || email == "")
             {
                 Session["Error"] = "Vui lòng kiểm tra lại thông tin đăng ký !";
                 Response.Redirect("event-register-error.aspx", false);
                 return;
             }
             gender = Request.Params["Gender"];
             if (gender == null || gender == "")
             {
                 gender = "Name";
             }

             company = Request.Params["Company"];
             if (company == null || company == "")
             {
                 company = "";
             }
             phone = Request.Params["Phone"];
             if (phone == null || phone == "")
             {
                 phone = "";
             }
             secondPhone = Request.Params["SecondPhone"];
             if (secondPhone == null || secondPhone == "")
             {
                 secondPhone = "";
             }
             address1 = Request.Params["Address1"];
             if (address1 == null || address1 == "")
             {
                 address1 = "";
             }
             address2 = Request.Params["Address2"];
             if (address2 == null || address2 == "")
             {
                 address2 = "";
             }
             city = Request.Params["City"];
             if (city == null || city == "")
             {
                 city = "";
             }
             province = Request.Params["Province"];
             if (province == null || province == "")
             {
                 province = "";
             }
             country = Request.Params["Country"];
             if (country == null || country == "")
             {
                 country = "";
             }
             zipcode = Request.Params["ZipCode"];
             if (zipcode == null || zipcode == "")
             {
                 zipcode = "";
             }
             fax = Request.Params["Fax"];
             if (fax == null || fax == "")
             {
                 fax = "";
             }

            requireTime = Request.Params["requireTime"];

            groupId = Request.Params["groupId"];
            UserID = Request.Params["UserID"];
            //startDate = Request.Params["startDate"];
            //endDate = Request.Params["endDate"];
            visibleField = Request.Params["visibleField"];
            string[] arrVisible = visibleField.Trim().Split(' ');

            eventDetailBus = new EventDetailBUS();
            eventBus = new EventBUS();

            EventDetailDTO eventDetailDto = new EventDetailDTO();
            eventDetailDto.EventId = int.Parse(eventId);
            eventDetailDto.FullName = name;
            eventDetailDto.EmailID = email;
            eventDetailDto.Company = company;
            eventDetailDto.Phone = phone;
            eventDetailDto.SecondPhone = secondPhone;
            eventDetailDto.Address = address1;
            eventDetailDto.Address2 = address2;
            eventDetailDto.City = city;
            eventDetailDto.Province = province;            
            eventDetailDto.Country = country;
            eventDetailDto.ZipCode = zipcode;
            eventDetailDto.Fax = fax;
            eventDetailDto.CreateDate = DateTime.Now;
            eventDetailDto.GroupId = int.Parse(groupId);
            eventDetailDto.CountReceivedMail = 0;
            eventDetailDto.LastReceivedMail = DateTime.Now;

            // Kiem tra dieu kien
            // Check thời gian của sự kiện
            DataTable tblEvent = eventBus.GetByID(int.Parse(eventId));
            if (tblEvent.Rows.Count > 0)
            {
                if (requireTime.Equals("true"))
                {
                    if (DateTime.Parse(tblEvent.Rows[0]["StartDate"].ToString()) <= DateTime.Now
                            && DateTime.Now <= DateTime.Parse(tblEvent.Rows[0]["EndDate"].ToString()))
                    {
                    }
                    else
                    {
                        Session["Error"] = "Thời hạn đăng ký đã hết, vui lòng chờ sự kiện kế tiếp. Cảm ơn !";
                        Response.Redirect("event-register-error.aspx", false);
                        return;
                    }
                }
                
            }

            // Mot email chi dang ky duoc mot event
            DataTable checkEmail = eventDetailBus.GetByIdAndEmail(int.Parse(eventId), email);
            if (checkEmail.Rows.Count > 0)
            {
                Session["Error"] = "Email đã được sử dụng. Vui lòng chọn email khác !";
                Response.Redirect("event-register-error.aspx",false);
                return;
            }

            // Gui mail
            // Lay thong tin event
            eventBus = new EventBUS();
            DataTable tbEvent = eventBus.GetByID(int.Parse(eventId));
            //get mail config
            if (tbEvent.Rows.Count > 0)
            {
                DataRow rEvent = tbEvent.Rows[0];
                mailConfigBus = new MailConfigBUS();
                DataTable tbMailConfig = mailConfigBus.GetByID(int.Parse(tbEvent.Rows[0]["ConfigId"].ToString()));

                // Them khach hang vao bang event detail     
                eventDetailBus.tblEventDetail_insert(eventDetailDto);

                try
                {
                    // Them khach hang vao danh sach khach hang
                    customerBus = new CustomerBUS();
                    DataTable tblCustomer = customerBus.GetByEmail(email,int.Parse(UserID));
                    int customerId = 0;
                    if (tblCustomer.Rows.Count == 0)
                    {
                        CustomerDTO customerDto = new CustomerDTO();
                        customerDto.Name = name;
                        customerDto.Gender = gender;
                        customerDto.BirthDay = DateTime.Now;
                        customerDto.Email = email;
                        customerDto.Phone = phone;
                        customerDto.SecondPhone = secondPhone;
                        customerDto.Address = address1;
                        customerDto.Fax = fax;
                        customerDto.Company = company;
                        customerDto.City = city;
                        customerDto.Province = province;
                        customerDto.Country = country;
                        customerDto.Type = "0";
                        customerDto.UserID = int.Parse(UserID);
                        
                        customerId = customerBus.tblCustomer_insert(customerDto);
                    } else {
                        customerId = int.Parse(tblCustomer.Rows[0]["Id"].ToString());
                    }

                    // Them khach hang vao detail group.
                    dgBus = new DetailGroupBUS();
                    DataTable tblDetailGroup = dgBus.GetByID(int.Parse(groupId),customerId);
                    if (tblDetailGroup.Rows.Count <= 0)
                    {
                        DetailGroupDTO dgDto = new DetailGroupDTO();
                        dgDto.GroupID = int.Parse(groupId);
                        dgDto.CustomerID = customerId;
                        dgDto.CountReceivedMail = 0;
                        dgDto.LastReceivedMail = DateTime.Now;
                        dgBus.tblDetailGroup_insert(dgDto);
                    }
                }
                catch (Exception)
                {                    
                }                

                if (tbMailConfig.Rows.Count > 0)
                {
                    DataRow rConfig = tbMailConfig.Rows[0];
                    ProcessSendEmail process = new ProcessSendEmail();

                    // Xu ly them loi chao trong noi dung mail
                    string body = rEvent["Body"].ToString();
                    string welcome = (name==""||name==null)?email:name;

                    // Replace with [khachhang] or [email]
                    body = body.Replace("[khachhang]", welcome);
                    body = body.Replace("[email]", email);

                    bool rsSend = true;

                    //rsSend = process.SendMail(rEvent["Subject"].ToString(),
                    //    body, rConfig["Server"].ToString(), int.Parse(rConfig["Port"].ToString()),
                    //    rConfig["Email"].ToString(), rConfig["Password"].ToString(), rConfig["Name"].ToString(),
                    //    email, rConfig["username"].ToString(),bool.Parse(rConfig["isSSL"].ToString()));
                                        

                    if (rsSend)
                    {
                        // chuyen den trang success
                        string url = rEvent["ResponeUrl"].ToString();
                        if (url.Equals("Default"))
                        {
                            Response.Redirect("event-register-success.aspx", false);
                        }
                        else
                        {
                            Response.Redirect(url, false);
                        }
                    }
                    else
                    {
                        Session["Error"] = "Bạn đã đăng ký không thành công.";
                        Response.Redirect("event-register-error.aspx", false);
                    }

                }
                else
                {
                    Session["Error"] = "Bạn đã đăng ký không thành công.";
                    Response.Redirect("event-register-error.aspx", false);
                }

            }
            
        }
        catch (Exception ex)
        {
            Session["Error"] = "Một số lỗi hệ thống đã xảy ra. Vui lòng kiểm tra lại thông tin !\n"+ex.Message;
            Response.Redirect("event-register-error.aspx");
        }
    }
}
