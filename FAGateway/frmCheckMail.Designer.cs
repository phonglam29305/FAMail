namespace FAGateway
{
    partial class frmCheckMail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEmailVerify = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.btmDomainVerify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEmailVerify
            // 
            this.btnEmailVerify.Location = new System.Drawing.Point(320, 26);
            this.btnEmailVerify.Name = "btnEmailVerify";
            this.btnEmailVerify.Size = new System.Drawing.Size(75, 23);
            this.btnEmailVerify.TabIndex = 0;
            this.btnEmailVerify.Text = "Verify";
            this.btnEmailVerify.UseVisualStyleBackColor = true;
            this.btnEmailVerify.Click += new System.EventHandler(this.btnEmailVerify_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(97, 28);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(217, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Domain:";
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(97, 57);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(217, 20);
            this.txtDomain.TabIndex = 4;
            // 
            // btmDomainVerify
            // 
            this.btmDomainVerify.Location = new System.Drawing.Point(320, 55);
            this.btmDomainVerify.Name = "btmDomainVerify";
            this.btmDomainVerify.Size = new System.Drawing.Size(75, 23);
            this.btmDomainVerify.TabIndex = 3;
            this.btmDomainVerify.Text = "Verify";
            this.btmDomainVerify.UseVisualStyleBackColor = true;
            // 
            // frmCheckMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 293);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.btmDomainVerify);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnEmailVerify);
            this.Name = "frmCheckMail";
            this.Text = "frmCheckMail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEmailVerify;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Button btmDomainVerify;
    }
}