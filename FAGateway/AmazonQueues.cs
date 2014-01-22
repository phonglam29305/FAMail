using Amazon.SQS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAGateway
{
    /// <summary>Represents the bounce or complaint notification stored in Amazon SQS.</summary>
    class AmazonSqsNotification
    {
        public string Type { get; set; }
        public string Message { get; set; }
    }

    /// <summary>Represents an Amazon SES bounce notification.</summary>
    class AmazonSesBounceNotification
    {
        public string NotificationType { get; set; }
        public AmazonSesBounce Bounce { get; set; }
    }
    /// <summary>Represents meta data for the bounce notification from Amazon SES.</summary>
    class AmazonSesBounce
    {
        public string BounceType { get; set; }
        public string BounceSubType { get; set; }
        public DateTime Timestamp { get; set; }
        public List<AmazonSesBouncedRecipient> BouncedRecipients { get; set; }
    }
    /// <summary>Represents the email address of recipients that bounced
    /// when sending from Amazon SES.</summary>
    class AmazonSesBouncedRecipient
    {
        public string EmailAddress { get; set; }
    }
    class AmazonQueues
    {
        public static void ProcessQueuedBounce(ReceiveMessageResponse response)
        {
            int messages = response.ReceiveMessageResult.Message.Count;

            if (messages > 0)
            {
                foreach (var m in response.ReceiveMessageResult.Message)
                {
                    // First, convert the Amazon SNS message into a JSON object.
                    if (m.Body.IndexOf("notificationType") >= 0)
                    {
                        var notification = Newtonsoft.Json.JsonConvert.DeserializeObject<AmazonSesBounceNotification>(m.Body);
                        if (notification.Bounce != null)
                        {
                            // Now access the Amazon SES bounce notification.
                            //var bounce = Newtonsoft.Json.JsonConvert.DeserializeObject<AmazonSesBounceNotification>(notification.Message);

                            switch (notification.Bounce.BounceType)
                            {
                                case "Transient":
                                    // Per our sample organizational policy, we will remove all recipients 
                                    // that generate an AttachmentRejected bounce from our mailing list.
                                    // Other bounces will be reviewed manually.
                                    switch (notification.Bounce.BounceSubType)
                                    {
                                        case "AttachmentRejected":
                                            foreach (var recipient in notification.Bounce.BouncedRecipients)
                                            {
                                                //RemoveFromMailingList(recipient.EmailAddress);
                                            }
                                            break;
                                        default:
                                            //ManuallyReviewBounce(bounce);
                                            break;
                                    }
                                    break;
                                default:
                                    // Remove all recipients that generated a permanent bounce 
                                    // or an unknown bounce.
                                    foreach (var recipient in notification.Bounce.BouncedRecipients)
                                    {
                                        //RemoveFromMailingList(recipient.EmailAddress);
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
