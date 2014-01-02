using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Amazon.SimpleEmail.Model;
using System.Collections;
using Amazon;
using System.Collections.Generic;
using Amazon.SimpleEmail;
using System.Net.Mail;

/// <summary>
/// Summary description for VerifyEmail
/// </summary>
public class VerifyEmail
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
        client = new AmazonSimpleEmailServiceClient(AccessKey, SecretKey);
        List<String> verifiedEmailAddresses = ListVerifiedEmailAddresses();
        VerifyEmailAddressRequest request = new VerifyEmailAddressRequest();
        VerifyEmailAddressResponse response = new VerifyEmailAddressResponse();

        VerifyEmailIdentityRequest Irequest = new VerifyEmailIdentityRequest();
        VerifyEmailIdentityResponse Iresponse = new VerifyEmailIdentityResponse();
        if (IsValidMail(email) == true)
        {
            if (!verifiedEmailAddresses.Contains(email))
            {
                if (client != null)
                {
                    Irequest.EmailAddress = email.Trim();
                    Iresponse = client.VerifyEmailIdentity(Irequest);
                    VerifyEmailIdentityResult rs = Iresponse.VerifyEmailIdentityResult;
                   
                    if (!string.IsNullOrEmpty(Iresponse.ResponseMetadata.RequestId))
                    {
                        result = true;
                    }
                }
            }
        }
        return result;
    }
    public bool DeleteEmailAddress(string email)
    {
        client = new AmazonSimpleEmailServiceClient(AccessKey, SecretKey);
        bool result = false;
        Amazon.SimpleEmail.Model.DeleteVerifiedEmailAddressRequest request = new Amazon.SimpleEmail.Model.DeleteVerifiedEmailAddressRequest();
        Amazon.SimpleEmail.Model.DeleteVerifiedEmailAddressResponse response = new Amazon.SimpleEmail.Model.DeleteVerifiedEmailAddressResponse();
        if (client != null)
        {
            request.EmailAddress = email.Trim();
            response = client.DeleteVerifiedEmailAddress(request);

            if (!string.IsNullOrEmpty(response.ResponseMetadata.RequestId))
            {
                result = true;
            }
        }

        return result;
    }

   public List<string> ListVerifiedEmailAddresses()
    {
    
        Amazon.SimpleEmail.Model.ListVerifiedEmailAddressesRequest request = new Amazon.SimpleEmail.Model.ListVerifiedEmailAddressesRequest();
        Amazon.SimpleEmail.Model.ListVerifiedEmailAddressesResponse response = new Amazon.SimpleEmail.Model.ListVerifiedEmailAddressesResponse();

        List<string> verifiedEmailList = new List<string>();
        response = client.ListVerifiedEmailAddresses(request);
        if (client != null)
        {
            if (response.ListVerifiedEmailAddressesResult != null)
            {
                if (response.ListVerifiedEmailAddressesResult.VerifiedEmailAddresses != null)
                {
                    verifiedEmailList.AddRange(response.ListVerifiedEmailAddressesResult.VerifiedEmailAddresses);
                }
            }
        }

        return verifiedEmailList;
    }

    public bool IsValidMail(string emailaddress)
    {
        try
        {
            MailAddress m = new MailAddress(emailaddress);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
