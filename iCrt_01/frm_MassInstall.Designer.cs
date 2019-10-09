namespace iCrt_01
{
    partial class frm_MassInstall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MassInstall));
            this.bt_Load = new System.Windows.Forms.Button();
            this.bt_Clear = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgv_Hostname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Online = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_AdminShare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_ClientPresent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_InstallStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_Execute = new System.Windows.Forms.Button();
            this.bt_Exit = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bt_Check = new System.Windows.Forms.Button();
            this.lbl_TxtTotal = new System.Windows.Forms.Label();
            this.lbl_Total_Count = new System.Windows.Forms.Label();
            this.lbl_Text_Checked = new System.Windows.Forms.Label();
            this.lbl_Check_Count = new System.Windows.Forms.Label();
            this.cb_AgentType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Load
            // 
            this.bt_Load.Location = new System.Drawing.Point(13, 13);
            this.bt_Load.Name = "bt_Load";
            this.bt_Load.Size = new System.Drawing.Size(75, 23);
            this.bt_Load.TabIndex = 0;
            this.bt_Load.Text = "Load List";
            this.bt_Load.UseVisualStyleBackColor = true;
            this.bt_Load.Click += new System.EventHandler(this.bt_Load_Click);
            // 
            // bt_Clear
            // 
            this.bt_Clear.Location = new System.Drawing.Point(396, 12);
            this.bt_Clear.Name = "bt_Clear";
            this.bt_Clear.Size = new System.Drawing.Size(75, 23);
            this.bt_Clear.TabIndex = 1;
            this.bt_Clear.Text = "Clear List";
            this.bt_Clear.UseVisualStyleBackColor = true;
            this.bt_Clear.Click += new System.EventHandler(this.bt_Clear_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_Hostname,
            this.dgv_Online,
            this.dgv_AdminShare,
            this.dgv_ClientPresent,
            this.dgv_InstallStatus});
            this.dataGridView1.Location = new System.Drawing.Point(13, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(539, 540);
            this.dataGridView1.TabIndex = 2;
            // 
            // dgv_Hostname
            // 
            this.dgv_Hostname.HeaderText = "Hostname";
            this.dgv_Hostname.Name = "dgv_Hostname";
            // 
            // dgv_Online
            // 
            this.dgv_Online.HeaderText = "Online";
            this.dgv_Online.Name = "dgv_Online";
            // 
            // dgv_AdminShare
            // 
            this.dgv_AdminShare.HeaderText = "Admin Share?";
            this.dgv_AdminShare.Name = "dgv_AdminShare";
            // 
            // dgv_ClientPresent
            // 
            this.dgv_ClientPresent.HeaderText = "CB Installed?";
            this.dgv_ClientPresent.Name = "dgv_ClientPresent";
            // 
            // dgv_InstallStatus
            // 
            this.dgv_InstallStatus.HeaderText = "Install Status";
            this.dgv_InstallStatus.Name = "dgv_InstallStatus";
            // 
            // bt_Execute
            // 
            this.bt_Execute.Location = new System.Drawing.Point(203, 602);
            this.bt_Execute.Name = "bt_Execute";
            this.bt_Execute.Size = new System.Drawing.Size(75, 23);
            this.bt_Execute.TabIndex = 3;
            this.bt_Execute.Text = "Execute";
            this.bt_Execute.UseVisualStyleBackColor = true;
            this.bt_Execute.Click += new System.EventHandler(this.bt_Execute_Click);
            // 
            // bt_Exit
            // 
            this.bt_Exit.Location = new System.Drawing.Point(477, 12);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.Size = new System.Drawing.Size(75, 23);
            this.bt_Exit.TabIndex = 4;
            this.bt_Exit.Text = "Exit";
            this.bt_Exit.UseVisualStyleBackColor = true;
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "csv";
            this.openFileDialog1.Filter = "Comma Separated Values|*.csv|All File|*.*";
            // 
            // bt_Check
            // 
            this.bt_Check.Location = new System.Drawing.Point(94, 13);
            this.bt_Check.Name = "bt_Check";
            this.bt_Check.Size = new System.Drawing.Size(75, 23);
            this.bt_Check.TabIndex = 5;
            this.bt_Check.Text = "Check List";
            this.bt_Check.UseVisualStyleBackColor = true;
            this.bt_Check.Click += new System.EventHandler(this.bt_Check_Click);
            // 
            // lbl_TxtTotal
            // 
            this.lbl_TxtTotal.AutoSize = true;
            this.lbl_TxtTotal.Location = new System.Drawing.Point(20, 589);
            this.lbl_TxtTotal.Name = "lbl_TxtTotal";
            this.lbl_TxtTotal.Size = new System.Drawing.Size(86, 13);
            this.lbl_TxtTotal.TabIndex = 6;
            this.lbl_TxtTotal.Text = "Total Machines: ";
            // 
            // lbl_Total_Count
            // 
            this.lbl_Total_Count.AutoSize = true;
            this.lbl_Total_Count.Location = new System.Drawing.Point(106, 589);
            this.lbl_Total_Count.Name = "lbl_Total_Count";
            this.lbl_Total_Count.Size = new System.Drawing.Size(0, 13);
            this.lbl_Total_Count.TabIndex = 7;
            // 
            // lbl_Text_Checked
            // 
            this.lbl_Text_Checked.AutoSize = true;
            this.lbl_Text_Checked.Location = new System.Drawing.Point(342, 589);
            this.lbl_Text_Checked.Name = "lbl_Text_Checked";
            this.lbl_Text_Checked.Size = new System.Drawing.Size(80, 13);
            this.lbl_Text_Checked.TabIndex = 8;
            this.lbl_Text_Checked.Text = "Total Checked:";
            // 
            // lbl_Check_Count
            // 
            this.lbl_Check_Count.AutoSize = true;
            this.lbl_Check_Count.Location = new System.Drawing.Point(423, 589);
            this.lbl_Check_Count.Name = "lbl_Check_Count";
            this.lbl_Check_Count.Size = new System.Drawing.Size(13, 13);
            this.lbl_Check_Count.TabIndex = 9;
            this.lbl_Check_Count.Text = "0";
            // 
            // cb_AgentType
            // 
            this.cb_AgentType.FormattingEnabled = true;
            this.cb_AgentType.Items.AddRange(new object[] {
            "Workstation",
            "Server"});
            this.cb_AgentType.Location = new System.Drawing.Point(203, 12);
            this.cb_AgentType.Name = "cb_AgentType";
            this.cb_AgentType.Size = new System.Drawing.Size(156, 21);
            this.cb_AgentType.TabIndex = 10;
            // 
            // frm_MassInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 637);
            this.Controls.Add(this.cb_AgentType);
            this.Controls.Add(this.lbl_Check_Count);
            this.Controls.Add(this.lbl_Text_Checked);
            this.Controls.Add(this.lbl_Total_Count);
            this.Controls.Add(this.lbl_TxtTotal);
            this.Controls.Add(this.bt_Check);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.bt_Execute);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bt_Clear);
            this.Controls.Add(this.bt_Load);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_MassInstall";
            this.Text = "Mass Install";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Load;
        private System.Windows.Forms.Button bt_Clear;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bt_Execute;
        private System.Windows.Forms.Button bt_Exit;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bt_Check;
        private System.Windows.Forms.Label lbl_TxtTotal;
        private System.Windows.Forms.Label lbl_Total_Count;
        private System.Windows.Forms.Label lbl_Text_Checked;
        private System.Windows.Forms.Label lbl_Check_Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_Hostname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_Online;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_AdminShare;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_ClientPresent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_InstallStatus;
        private System.Windows.Forms.ComboBox cb_AgentType;
    }
}