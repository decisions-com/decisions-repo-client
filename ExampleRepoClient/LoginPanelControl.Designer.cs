namespace ExampleRepoClient
{
    partial class LoginPanelControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.tbRepoServerUser = new System.Windows.Forms.TextBox();
            this.tbRepoServerPass = new System.Windows.Forms.TextBox();
            this.lbClientBaseUrl = new System.Windows.Forms.Label();
            this.lbClientUsername = new System.Windows.Forms.Label();
            this.lbClientPassword = new System.Windows.Forms.Label();
            this.lbRepoServerUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbUser
            // 
            this.tbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUser.Location = new System.Drawing.Point(6, 118);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(360, 26);
            this.tbUser.TabIndex = 0;
            // 
            // tbPwd
            // 
            this.tbPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPwd.Location = new System.Drawing.Point(6, 182);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(360, 26);
            this.tbPwd.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(6, 423);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(276, 23);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Login to Client Server";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(279, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbURL
            // 
            this.tbURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbURL.Location = new System.Drawing.Point(6, 55);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(360, 26);
            this.tbURL.TabIndex = 4;
            // 
            // tbRepoServerUser
            // 
            this.tbRepoServerUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRepoServerUser.Location = new System.Drawing.Point(6, 56);
            this.tbRepoServerUser.Name = "tbRepoServerUser";
            this.tbRepoServerUser.Size = new System.Drawing.Size(360, 26);
            this.tbRepoServerUser.TabIndex = 5;
            // 
            // tbRepoServerPass
            // 
            this.tbRepoServerPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRepoServerPass.Location = new System.Drawing.Point(6, 122);
            this.tbRepoServerPass.Name = "tbRepoServerPass";
            this.tbRepoServerPass.PasswordChar = '*';
            this.tbRepoServerPass.Size = new System.Drawing.Size(360, 26);
            this.tbRepoServerPass.TabIndex = 6;
            // 
            // lbClientBaseUrl
            // 
            this.lbClientBaseUrl.AutoSize = true;
            this.lbClientBaseUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClientBaseUrl.Location = new System.Drawing.Point(6, 32);
            this.lbClientBaseUrl.Name = "lbClientBaseUrl";
            this.lbClientBaseUrl.Size = new System.Drawing.Size(102, 20);
            this.lbClientBaseUrl.TabIndex = 7;
            this.lbClientBaseUrl.Text = "Service URL:";
            // 
            // lbClientUsername
            // 
            this.lbClientUsername.AutoSize = true;
            this.lbClientUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClientUsername.Location = new System.Drawing.Point(6, 95);
            this.lbClientUsername.Name = "lbClientUsername";
            this.lbClientUsername.Size = new System.Drawing.Size(87, 20);
            this.lbClientUsername.TabIndex = 8;
            this.lbClientUsername.Text = "Username:";
            // 
            // lbClientPassword
            // 
            this.lbClientPassword.AutoSize = true;
            this.lbClientPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClientPassword.Location = new System.Drawing.Point(6, 159);
            this.lbClientPassword.Name = "lbClientPassword";
            this.lbClientPassword.Size = new System.Drawing.Size(82, 20);
            this.lbClientPassword.TabIndex = 9;
            this.lbClientPassword.Text = "Password:";
            // 
            // lbRepoServerUsername
            // 
            this.lbRepoServerUsername.AutoSize = true;
            this.lbRepoServerUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRepoServerUsername.Location = new System.Drawing.Point(6, 33);
            this.lbRepoServerUsername.Name = "lbRepoServerUsername";
            this.lbRepoServerUsername.Size = new System.Drawing.Size(87, 20);
            this.lbRepoServerUsername.TabIndex = 10;
            this.lbRepoServerUsername.Text = "Username:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Password:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbRepoServerUser);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbRepoServerUsername);
            this.groupBox1.Controls.Add(this.tbRepoServerPass);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 244);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 154);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Repository Server";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbPwd);
            this.groupBox2.Controls.Add(this.tbUser);
            this.groupBox2.Controls.Add(this.lbClientPassword);
            this.groupBox2.Controls.Add(this.tbURL);
            this.groupBox2.Controls.Add(this.lbClientUsername);
            this.groupBox2.Controls.Add(this.lbClientBaseUrl);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 214);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Repository Client";
            // 
            // LoginPanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblStatus);
            this.Name = "LoginPanelControl";
            this.Size = new System.Drawing.Size(387, 637);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.TextBox tbRepoServerUser;
        private System.Windows.Forms.TextBox tbRepoServerPass;
        private System.Windows.Forms.Label lbClientBaseUrl;
        private System.Windows.Forms.Label lbClientUsername;
        private System.Windows.Forms.Label lbClientPassword;
        private System.Windows.Forms.Label lbRepoServerUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
