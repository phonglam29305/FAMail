using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon.SimpleEmail.Model;
using Amazon.SimpleEmail;
namespace BatchSendMail.ext.common
{
    class VerifyEmail
    {

        private AmazonSimpleEmailServiceClient client;
        public VerifyEmail(string accessKey, string secretKey)
        {
            AccessKey = accessKey;
            SecretKey = secretKey;
            client = new Amazon.SimpleEmail.AmazonSimpleEmailServiceClient(accessKey, secretKey);
        }

        public VerifyEmail()
        {
            // TODO: Complete member initialization
        }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public bool VerifyEmailAddress(string email)
        {
            bool result = false;
 
            VerifyEmailAddressRequest request = new VerifyEmailAddressRequest();
            VerifyEmailAddressResponse response = new VerifyEmailAddressResponse();
 
            if (client != null)
            {
 
                request.EmailAddress = email.Trim();
                response = client.VerifyEmailAddress(request);
 
                if (!string.IsNullOrEmpty(response.ResponseMetadata.RequestId))
                {
                    result = true;
                  
                }
            }
 
            return result;
        }
      
    }

}
