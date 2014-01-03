using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchSendMail.ext.dto
{
   public class SendMailDTO
    {
       public int customerId { get; set; }
       public int groupId { get; set; }
       public string hostName { get; set; }
       public string mailFrom { get; set; }
       public string mailTo { get; set; }
       public string userSmtp { get; set; }
       public string passSmtp { get; set; }
       public int port { get; set; }
       public string senderName { get; set; }
       public string recieveName { get; set; }
       public bool SSL { get; set; }
       public int countReceivedMail { get; set; }
       public int eventId { get; set; }
       public string lastReceivedMail { get; set; }
    }
}
