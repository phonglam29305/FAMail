using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FAGateway
{
    public partial class frmCheckMail : Form
    {
        public frmCheckMail()
        {
            InitializeComponent();
        }
        string accessKey, secretKey, password, server, username;
        private void btnEmailVerify_Click(object sender, EventArgs e)
        {
            getConfigAmazone();
            //VerifyEmail veriryEmail = new VerifyEmail(accessKey, secretKey);
            bool status = EmailTools.IsEmail(txtEmail.Text.Trim());
            MessageBox.Show(status+"");
        }

        private void getConfigAmazone()
        {
            accessKey = ConfigurationManager.AppSettings["AccessKey"].ToString();
            if (accessKey == null)
            {
                accessKey = "AKIAISOKS5VTXBRTVFEQ";
            }
            secretKey = ConfigurationManager.AppSettings["SecrectKey"].ToString();
            if (secretKey == null)
            {
                secretKey = "4vWG7GoCd5JbZ/r9hxA8MTIoo9elkkvRxW80qyU6";
            }

            password = ConfigurationManager.AppSettings["PasswordSMTP"].ToString();
            if (password == null)
            {
                password = "AjzPf6o0UITv4qtyXEzXY15xm9nmyVhb7Tk7g2X8DOPk";
            }

            server = ConfigurationManager.AppSettings["ServerSMTP"].ToString();
            if (server == null)
            {
                server = "email-smtp.us-east-1.amazonaws.com";
            }

            username = ConfigurationManager.AppSettings["UserNameSMTP"].ToString();
            if (username == null)
            {
                username = "AKIAJGQEDHANI2RZVAWQ";
            }

        }
    }
}
