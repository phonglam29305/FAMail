using Amazon.SimpleEmail.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FAGateway
{
    public partial class frmMail : Form
    {
        public frmMail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCheckMail check = new frmCheckMail();
            check.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Amazon.SimpleEmail.AmazonSimpleEmailServiceClient mailClient = new Amazon.SimpleEmail.AmazonSimpleEmailServiceClient(System.Configuration.ConfigurationManager.AppSettings["AccessKey"], System.Configuration.ConfigurationManager.AppSettings["SecrectKey"]);
            //var obj = mailClient.GetSendQuota();
            SendEmailRequest request = new SendEmailRequest();
            List<string> toaddress = new List<string>();
            toaddress.Add("phonglam29305@gmail.com");
            Destination des = new Destination(toaddress);
            request.Destination = des;
            request.Source = "phonglam29305@yahoo.com";
            Amazon.SimpleEmail.Model.Message mes = new Amazon.SimpleEmail.Model.Message();
            mes.Body = new Body(new Content( @"Hiện tại, Windows Phone mới hỗ trợ đến màn hình full HD, do đó để tương thích với màn hình 2K, hệ điều hành chắc chắn phải có bản cập nhật mới. Mặt khác, vi xử lý Snapdragon 805 của Qualcomm được biết sẽ phát hành đại trà vào nửa sau năm nay, nên thời điểm xuất hiện Lumia 1820 dùng vi xử lý này tại MWC 2014 vào tháng Hai sẽ là dấu hỏi lớn.
 
Microsoft đã từng nói hãng đã chi tới 2,6 tỉ USD để phát triển cho hệ điều hành Windows Phone. Và năm nay, Microsoft đang có kế hoạch lớn dành cho Windows Phone lẫn Nokia. Do đó, chúng ta hãy cứ hy vọng Lumia 1525 và Lumia 1820 sẽ là bom tấn smartphone được kích hoạt trong 2014 này."));
            mes.Subject = new Content("Test send via amazon");

            request.Message = mes;

            SendEmailResponse response = mailClient.SendEmail(request);
            var messageId = response.SendEmailResult.MessageId;
            GetIdentityNotificationAttributesRequest notifyRequest = new GetIdentityNotificationAttributesRequest();
            List<string> iden = new List<string>();
            iden.Add("phonglam29305@gmail.com"); //iden.Add(response.ResponseMetadata.RequestId);
            notifyRequest.Identities = iden;
            var notify = mailClient.GetIdentityNotificationAttributes(notifyRequest);
            //MessageBox.Show(notify.GetIdentityNotificationAttributesResult.NotificationAttributes["Bounces"].BounceTopic);

            var temp = mailClient.GetSendStatistics();
            MessageBox.Show("Total: "+temp.GetSendStatisticsResult.SendDataPoints.Count+"\nDeliveryAttempts: "+temp.GetSendStatisticsResult.SendDataPoints[265].DeliveryAttempts+"\n"
                + "Complaints: " + temp.GetSendStatisticsResult.SendDataPoints[265].Complaints + "\n"
                + "Bounces: " + temp.GetSendStatisticsResult.SendDataPoints[265].Bounces + "\n"
                + "Rejects: " + temp.GetSendStatisticsResult.SendDataPoints[265].Rejects + "\n");
           // MessageBox.Show("Max24HourSend:" + obj.GetSendQuotaResult.Max24HourSend + "\nMaxSendRate:" + obj.GetSendQuotaResult.MaxSendRate + "\nSentLast24Hours:" + obj.GetSendQuotaResult.SentLast24Hours);

            Amazon.SimpleNotificationService.Model.GetEndpointAttributesRequest endpointRequest = new Amazon.SimpleNotificationService.Model.GetEndpointAttributesRequest();
            Amazon.SimpleNotificationService.AmazonSimpleNotificationServiceClient notifyClient = new Amazon.SimpleNotificationService.AmazonSimpleNotificationServiceClient();
            //string result = notifyClient.GetEndpointAttributes(notify).GetEndpointAttributesResult.ToXML();
            //MessageBox.Show(result);

        }
    }
}
