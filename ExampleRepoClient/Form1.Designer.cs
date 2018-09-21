namespace ExampleRepoClient
{
    partial class Form1
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
            this.cbModules = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbBranches = new System.Windows.Forms.ComboBox();
            this.btnViewChanges = new System.Windows.Forms.Button();
            this.lbChanges = new System.Windows.Forms.ListBox();
            this.btnGetServerUpdates = new System.Windows.Forms.Button();
            this.lbServerChanges = new System.Windows.Forms.ListBox();
            this.lbBranch = new System.Windows.Forms.Label();
            this.lbModule = new System.Windows.Forms.Label();
            this.btnUpdateLocal = new System.Windows.Forms.Button();
            this.btnCheckInChanges = new System.Windows.Forms.Button();
            this.clientLoginPanel = new ExampleRepoClient.LoginPanelControl();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.cbModules.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbModules.FormattingEnabled = true;
            this.cbModules.Location = new System.Drawing.Point(488, 56);
            this.cbModules.Name = "comboBox1";
            this.cbModules.Size = new System.Drawing.Size(674, 28);
            this.cbModules.TabIndex = 1;
            this.cbModules.SelectedIndexChanged += new System.EventHandler(this.AfterModulePicked);
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblStatus.Location = new System.Drawing.Point(418, 21);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(744, 23);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "label1";
            this.lblStatus.Visible = false;
            // 
            // cbBranches
            // 
            this.cbBranches.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBranches.FormattingEnabled = true;
            this.cbBranches.Location = new System.Drawing.Point(488, 90);
            this.cbBranches.Name = "cbBranches";
            this.cbBranches.Size = new System.Drawing.Size(674, 28);
            this.cbBranches.TabIndex = 3;
            // 
            // btnViewChanges
            // 
            this.btnViewChanges.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnViewChanges.Enabled = false;
            this.btnViewChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewChanges.Location = new System.Drawing.Point(896, 136);
            this.btnViewChanges.Name = "btnViewChanges";
            this.btnViewChanges.Size = new System.Drawing.Size(266, 37);
            this.btnViewChanges.TabIndex = 4;
            this.btnViewChanges.Text = "View Pending Local Changes";
            this.btnViewChanges.UseVisualStyleBackColor = false;
            this.btnViewChanges.Click += new System.EventHandler(this.btnViewChanges_Click);
            // 
            // lbChanges
            // 
            this.lbChanges.FormattingEnabled = true;
            this.lbChanges.Location = new System.Drawing.Point(417, 179);
            this.lbChanges.Name = "lbChanges";
            this.lbChanges.Size = new System.Drawing.Size(745, 173);
            this.lbChanges.TabIndex = 5;
            // 
            // btnGetServerUpdates
            // 
            this.btnGetServerUpdates.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGetServerUpdates.Enabled = false;
            this.btnGetServerUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetServerUpdates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetServerUpdates.Location = new System.Drawing.Point(896, 373);
            this.btnGetServerUpdates.Name = "btnGetServerUpdates";
            this.btnGetServerUpdates.Size = new System.Drawing.Size(266, 37);
            this.btnGetServerUpdates.TabIndex = 6;
            this.btnGetServerUpdates.Text = "View Pending Server Updates";
            this.btnGetServerUpdates.UseVisualStyleBackColor = false;
            this.btnGetServerUpdates.Click += new System.EventHandler(this.btnGetServerUpdates_Click);
            // 
            // lbServerChanges
            // 
            this.lbServerChanges.FormattingEnabled = true;
            this.lbServerChanges.Location = new System.Drawing.Point(417, 416);
            this.lbServerChanges.Name = "lbServerChanges";
            this.lbServerChanges.Size = new System.Drawing.Size(745, 173);
            this.lbServerChanges.TabIndex = 7;
            // 
            // lbBranch
            // 
            this.lbBranch.AutoSize = true;
            this.lbBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBranch.Location = new System.Drawing.Point(418, 93);
            this.lbBranch.Name = "lbBranch";
            this.lbBranch.Size = new System.Drawing.Size(64, 20);
            this.lbBranch.TabIndex = 8;
            this.lbBranch.Text = "Branch:";
            // 
            // lbModule
            // 
            this.lbModule.AutoSize = true;
            this.lbModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbModule.Location = new System.Drawing.Point(417, 59);
            this.lbModule.Name = "lbModule";
            this.lbModule.Size = new System.Drawing.Size(65, 20);
            this.lbModule.TabIndex = 9;
            this.lbModule.Text = "Module:";
            // 
            // btnUpdateLocal
            // 
            this.btnUpdateLocal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnUpdateLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateLocal.Location = new System.Drawing.Point(417, 373);
            this.btnUpdateLocal.Name = "btnUpdateLocal";
            this.btnUpdateLocal.Size = new System.Drawing.Size(144, 37);
            this.btnUpdateLocal.TabIndex = 10;
            this.btnUpdateLocal.Text = "Update Local";
            this.btnUpdateLocal.UseVisualStyleBackColor = false;
            this.btnUpdateLocal.Click += new System.EventHandler(this.btnUpdateLocal_Click);
            // 
            // btnCheckInChanges
            // 
            this.btnCheckInChanges.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCheckInChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckInChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckInChanges.Location = new System.Drawing.Point(417, 136);
            this.btnCheckInChanges.Name = "btnCheckInChanges";
            this.btnCheckInChanges.Size = new System.Drawing.Size(168, 37);
            this.btnCheckInChanges.TabIndex = 11;
            this.btnCheckInChanges.Text = "Check In Changes";
            this.btnCheckInChanges.UseVisualStyleBackColor = false;
            this.btnCheckInChanges.Click += new System.EventHandler(this.btnCheckInChanges_Click);
            // 
            // clientLoginPanel
            // 
            this.clientLoginPanel.BackColor = System.Drawing.Color.White;
            this.clientLoginPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clientLoginPanel.Location = new System.Drawing.Point(12, 12);
            this.clientLoginPanel.Name = "clientLoginPanel";
            this.clientLoginPanel.Size = new System.Drawing.Size(389, 577);
            this.clientLoginPanel.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 607);
            this.Controls.Add(this.btnCheckInChanges);
            this.Controls.Add(this.btnUpdateLocal);
            this.Controls.Add(this.lbModule);
            this.Controls.Add(this.lbBranch);
            this.Controls.Add(this.lbServerChanges);
            this.Controls.Add(this.btnGetServerUpdates);
            this.Controls.Add(this.lbChanges);
            this.Controls.Add(this.btnViewChanges);
            this.Controls.Add(this.cbBranches);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cbModules);
            this.Controls.Add(this.clientLoginPanel);
            this.Name = "Form1";
            this.Text = "Example Repository Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LoginPanelControl clientLoginPanel;
        private System.Windows.Forms.ComboBox cbModules;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cbBranches;
        private System.Windows.Forms.Button btnViewChanges;
        private System.Windows.Forms.ListBox lbChanges;
        private System.Windows.Forms.Button btnGetServerUpdates;
        private System.Windows.Forms.ListBox lbServerChanges;
        private System.Windows.Forms.Label lbBranch;
        private System.Windows.Forms.Label lbModule;
        private System.Windows.Forms.Button btnUpdateLocal;
        private System.Windows.Forms.Button btnCheckInChanges;
    }
}

