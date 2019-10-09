namespace iCrt_01
{
    partial class frm_icrt_main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_icrt_main));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_ComputerName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tb_Display = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_LR_Install = new System.Windows.Forms.Button();
            this.bt_LERC_online = new System.Windows.Forms.Button();
            this.bt_Exit = new System.Windows.Forms.Button();
            this.bt_MassInst = new System.Windows.Forms.Button();
            this.bt_Lerc_Offline = new System.Windows.Forms.Button();
            this.bt_Uninstall = new System.Windows.Forms.Button();
            this.bt_Install_Sched = new System.Windows.Forms.Button();
            this.bt_ViewFiles = new System.Windows.Forms.Button();
            this.bt_Reset = new System.Windows.Forms.Button();
            this.bt_Install = new System.Windows.Forms.Button();
            this.rb_Online = new System.Windows.Forms.RadioButton();
            this.rb_Offline = new System.Windows.Forms.RadioButton();
            this.cb_AgentType = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(324, 20);
            this.textBox1.TabIndex = 0;
            // 
            // lbl_ComputerName
            // 
            this.lbl_ComputerName.AutoSize = true;
            this.lbl_ComputerName.Location = new System.Drawing.Point(12, 9);
            this.lbl_ComputerName.Name = "lbl_ComputerName";
            this.lbl_ComputerName.Size = new System.Drawing.Size(83, 13);
            this.lbl_ComputerName.TabIndex = 1;
            this.lbl_ComputerName.Text = "Computer Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(143, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Check It";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_Display
            // 
            this.tb_Display.Location = new System.Drawing.Point(15, 102);
            this.tb_Display.Multiline = true;
            this.tb_Display.Name = "tb_Display";
            this.tb_Display.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_Display.Size = new System.Drawing.Size(334, 254);
            this.tb_Display.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_AgentType);
            this.groupBox1.Controls.Add(this.bt_LR_Install);
            this.groupBox1.Controls.Add(this.bt_LERC_online);
            this.groupBox1.Controls.Add(this.bt_Exit);
            this.groupBox1.Controls.Add(this.bt_MassInst);
            this.groupBox1.Controls.Add(this.bt_Lerc_Offline);
            this.groupBox1.Controls.Add(this.bt_Uninstall);
            this.groupBox1.Controls.Add(this.bt_Install_Sched);
            this.groupBox1.Controls.Add(this.bt_ViewFiles);
            this.groupBox1.Controls.Add(this.bt_Reset);
            this.groupBox1.Controls.Add(this.bt_Install);
            this.groupBox1.Location = new System.Drawing.Point(13, 363);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 163);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client Functions";
            // 
            // bt_LR_Install
            // 
            this.bt_LR_Install.Location = new System.Drawing.Point(213, 105);
            this.bt_LR_Install.Name = "bt_LR_Install";
            this.bt_LR_Install.Size = new System.Drawing.Size(117, 23);
            this.bt_LR_Install.TabIndex = 9;
            this.bt_LR_Install.Text = "LR Features";
            this.bt_LR_Install.UseVisualStyleBackColor = true;
            this.bt_LR_Install.Click += new System.EventHandler(this.bt_LR_Install_Click);
            // 
            // bt_LERC_online
            // 
            this.bt_LERC_online.Location = new System.Drawing.Point(7, 105);
            this.bt_LERC_online.Name = "bt_LERC_online";
            this.bt_LERC_online.Size = new System.Drawing.Size(117, 23);
            this.bt_LERC_online.TabIndex = 8;
            this.bt_LERC_online.Text = "Install LERC (Online)";
            this.bt_LERC_online.UseVisualStyleBackColor = true;
            this.bt_LERC_online.Click += new System.EventHandler(this.bt_LERC_online_Click);
            // 
            // bt_Exit
            // 
            this.bt_Exit.Location = new System.Drawing.Point(213, 134);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.Size = new System.Drawing.Size(75, 23);
            this.bt_Exit.TabIndex = 7;
            this.bt_Exit.Text = "Exit";
            this.bt_Exit.UseVisualStyleBackColor = true;
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // bt_MassInst
            // 
            this.bt_MassInst.Location = new System.Drawing.Point(130, 105);
            this.bt_MassInst.Name = "bt_MassInst";
            this.bt_MassInst.Size = new System.Drawing.Size(75, 23);
            this.bt_MassInst.TabIndex = 6;
            this.bt_MassInst.Text = "Mass Install";
            this.bt_MassInst.UseVisualStyleBackColor = true;
            this.bt_MassInst.Click += new System.EventHandler(this.bt_MassInst_Click);
            // 
            // bt_Lerc_Offline
            // 
            this.bt_Lerc_Offline.Location = new System.Drawing.Point(213, 77);
            this.bt_Lerc_Offline.Name = "bt_Lerc_Offline";
            this.bt_Lerc_Offline.Size = new System.Drawing.Size(117, 23);
            this.bt_Lerc_Offline.TabIndex = 5;
            this.bt_Lerc_Offline.Text = "Install LERC (Offline)";
            this.bt_Lerc_Offline.UseVisualStyleBackColor = true;
            this.bt_Lerc_Offline.Click += new System.EventHandler(this.bt_Lerc_Offline_Click);
            // 
            // bt_Uninstall
            // 
            this.bt_Uninstall.Location = new System.Drawing.Point(7, 77);
            this.bt_Uninstall.Name = "bt_Uninstall";
            this.bt_Uninstall.Size = new System.Drawing.Size(117, 23);
            this.bt_Uninstall.TabIndex = 4;
            this.bt_Uninstall.Text = "Uninstall CB (Online)";
            this.bt_Uninstall.UseVisualStyleBackColor = true;
            this.bt_Uninstall.Click += new System.EventHandler(this.bt_Uninstall_Click);
            // 
            // bt_Install_Sched
            // 
            this.bt_Install_Sched.Location = new System.Drawing.Point(211, 48);
            this.bt_Install_Sched.Name = "bt_Install_Sched";
            this.bt_Install_Sched.Size = new System.Drawing.Size(117, 23);
            this.bt_Install_Sched.TabIndex = 3;
            this.bt_Install_Sched.Text = "Install Client (Offline)";
            this.bt_Install_Sched.UseVisualStyleBackColor = true;
            this.bt_Install_Sched.Click += new System.EventHandler(this.bt_Install_Sched_Click);
            // 
            // bt_ViewFiles
            // 
            this.bt_ViewFiles.Location = new System.Drawing.Point(130, 48);
            this.bt_ViewFiles.Name = "bt_ViewFiles";
            this.bt_ViewFiles.Size = new System.Drawing.Size(75, 23);
            this.bt_ViewFiles.TabIndex = 2;
            this.bt_ViewFiles.Text = "View Files";
            this.bt_ViewFiles.UseVisualStyleBackColor = true;
            this.bt_ViewFiles.Click += new System.EventHandler(this.bt_ViewFiles_Click);
            // 
            // bt_Reset
            // 
            this.bt_Reset.Location = new System.Drawing.Point(49, 134);
            this.bt_Reset.Name = "bt_Reset";
            this.bt_Reset.Size = new System.Drawing.Size(75, 23);
            this.bt_Reset.TabIndex = 1;
            this.bt_Reset.Text = "Reset";
            this.bt_Reset.UseVisualStyleBackColor = true;
            this.bt_Reset.Click += new System.EventHandler(this.bt_Reset_Click);
            // 
            // bt_Install
            // 
            this.bt_Install.Location = new System.Drawing.Point(7, 48);
            this.bt_Install.Name = "bt_Install";
            this.bt_Install.Size = new System.Drawing.Size(117, 23);
            this.bt_Install.TabIndex = 0;
            this.bt_Install.Text = "Install CB (Online)";
            this.bt_Install.UseVisualStyleBackColor = true;
            this.bt_Install.Click += new System.EventHandler(this.bt_Install_Click);
            // 
            // rb_Online
            // 
            this.rb_Online.AutoSize = true;
            this.rb_Online.Enabled = false;
            this.rb_Online.Location = new System.Drawing.Point(63, 79);
            this.rb_Online.Name = "rb_Online";
            this.rb_Online.Size = new System.Drawing.Size(55, 17);
            this.rb_Online.TabIndex = 7;
            this.rb_Online.TabStop = true;
            this.rb_Online.Text = "Online";
            this.rb_Online.UseVisualStyleBackColor = true;
            // 
            // rb_Offline
            // 
            this.rb_Offline.AutoSize = true;
            this.rb_Offline.Enabled = false;
            this.rb_Offline.Location = new System.Drawing.Point(226, 79);
            this.rb_Offline.Name = "rb_Offline";
            this.rb_Offline.Size = new System.Drawing.Size(55, 17);
            this.rb_Offline.TabIndex = 8;
            this.rb_Offline.TabStop = true;
            this.rb_Offline.Text = "Offline";
            this.rb_Offline.UseVisualStyleBackColor = true;
            // 
            // cb_AgentType
            // 
            this.cb_AgentType.FormattingEnabled = true;
            this.cb_AgentType.Items.AddRange(new object[] {
            "Workstation",
            "Server"});
            this.cb_AgentType.Location = new System.Drawing.Point(95, 19);
            this.cb_AgentType.Name = "cb_AgentType";
            this.cb_AgentType.Size = new System.Drawing.Size(156, 21);
            this.cb_AgentType.TabIndex = 11;
            // 
            // frm_icrt_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 538);
            this.Controls.Add(this.rb_Offline);
            this.Controls.Add(this.rb_Online);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tb_Display);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_ComputerName);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_icrt_main";
            this.Text = "iCrt";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbl_ComputerName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_Display;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_Install;
        private System.Windows.Forms.RadioButton rb_Online;
        private System.Windows.Forms.RadioButton rb_Offline;
        private System.Windows.Forms.Button bt_Reset;
        private System.Windows.Forms.Button bt_ViewFiles;
        private System.Windows.Forms.Button bt_Install_Sched;
        private System.Windows.Forms.Button bt_Uninstall;
        private System.Windows.Forms.Button bt_MassInst;
        private System.Windows.Forms.Button bt_Lerc_Offline;
        private System.Windows.Forms.Button bt_Exit;
        private System.Windows.Forms.Button bt_LERC_online;
        private System.Windows.Forms.Button bt_LR_Install;
        private System.Windows.Forms.ComboBox cb_AgentType;
    }
}

