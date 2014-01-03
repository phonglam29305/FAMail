using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchSendMail.ext.dto
{
   public class MailToDTO
    {
        public int customerId { get; set; }
        public string MailTo { get; set; }
        public string Name { get; set; }
        public int countReceivedMail { get; set; }
    }
}
