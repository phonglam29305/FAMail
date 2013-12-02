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

/// <summary>
/// Summary description for EventDetailDTO
/// </summary>
public class EventDetailDTO
{
    
    public int EventId { get; set; }
    public DateTime CreateDate { get; set; }
    public string FullName { get; set; }
    public string EmailID { get; set; }
    public string Company { get; set; }
    public string Phone { get; set; }
    public string SecondPhone { get; set; }
    public string Address { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public string Fax { get; set; }
    public int GroupId { get; set; }
    public int CountReceivedMail { get; set; }
    public DateTime LastReceivedMail { get; set; }
    
    public EventDetailDTO()
    {
        this.EventId = 0;
        this.CreateDate = DateTime.Now;
        this.EmailID = "";
        this.Company = "";
        this.Phone = "";
        this.SecondPhone = "";
        this.Address = "";
        this.Address2 = "";
        this.City = "";
        this.Province = "";
        this.ZipCode = "";
        this.Country = "";
        this.Fax = "";
        this.GroupId = 0;
    }
    public EventDetailDTO(DateTime createDate, string fullName, string emailId,
           string company, string phone, string secondPhone, string address,
           string address2, string city, string province, string zipcode,
           string country, string fax, int groupId)
    {
        this.CreateDate = createDate;
        this.FullName = fullName;
        this.EmailID = emailId;
        this.Company = company;
        this.Phone = phone;
        this.SecondPhone = secondPhone;
        this.Address = address;
        this.Address2 = address2;
        this.City = city;
        this.Province = province;
        this.ZipCode = zipcode;
        this.Country = country;
        this.Fax = fax;
        this.GroupId = groupId;

    }
   
}
