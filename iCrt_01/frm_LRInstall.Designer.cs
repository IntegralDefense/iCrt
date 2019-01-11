namespace iCrt_01
{
    partial class frm_LRInstall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_LRInstall));
            this.lbl_CN_Title = new System.Windows.Forms.Label();
            this.lbl_CN = new System.Windows.Forms.Label();
            this.lbl_Sensor_Title = new System.Windows.Forms.Label();
            this.lbl_SensorID = new System.Windows.Forms.Label();
            this.lbl_LR_Title = new System.Windows.Forms.Label();
            this.lbl_LR_Status = new System.Windows.Forms.Label();
            this.bt_Exit = new System.Windows.Forms.Button();
            this.bt_LR_Start = new System.Windows.Forms.Button();
            this.bt_LR_End = new System.Windows.Forms.Button();
            this.bt_Upload = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lbl_FS_Title = new System.Windows.Forms.Label();
            this.lbl_FS_Status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_CN_Title
            // 
            this.lbl_CN_Title.AutoSize = true;
            this.lbl_CN_Title.Location = new System.Drawing.Point(12, 17);
            this.lbl_CN_Title.Name = "lbl_CN_Title";
            this.lbl_CN_Title.Size = new System.Drawing.Size(86, 13);
            this.lbl_CN_Title.TabIndex = 0;
            this.lbl_CN_Title.Text = "ComputerName: ";
            // 
            // lbl_CN
            // 
            this.lbl_CN.AutoSize = true;
            this.lbl_CN.Location = new System.Drawing.Point(104, 17);
            this.lbl_CN.Name = "lbl_CN";
            this.lbl_CN.Size = new System.Drawing.Size(35, 13);
            this.lbl_CN.TabIndex = 1;
            this.lbl_CN.Text = "label2";
            // 
            // lbl_Sensor_Title
            // 
            this.lbl_Sensor_Title.AutoSize = true;
            this.lbl_Sensor_Title.Location = new System.Drawing.Point(12, 30);
            this.lbl_Sensor_Title.Name = "lbl_Sensor_Title";
            this.lbl_Sensor_Title.Size = new System.Drawing.Size(57, 13);
            this.lbl_Sensor_Title.TabIndex = 2;
            this.lbl_Sensor_Title.Text = "Sensor ID:";
            // 
            // lbl_SensorID
            // 
            this.lbl_SensorID.AutoSize = true;
            this.lbl_SensorID.Location = new System.Drawing.Point(76, 30);
            this.lbl_SensorID.Name = "lbl_SensorID";
            this.lbl_SensorID.Size = new System.Drawing.Size(35, 13);
            this.lbl_SensorID.TabIndex = 3;
            this.lbl_SensorID.Text = "label1";
            // 
            // lbl_LR_Title
            // 
            this.lbl_LR_Title.AutoSize = true;
            this.lbl_LR_Title.Location = new System.Drawing.Point(12, 43);
            this.lbl_LR_Title.Name = "lbl_LR_Title";
            this.lbl_LR_Title.Size = new System.Drawing.Size(57, 13);
            this.lbl_LR_Title.TabIndex = 4;
            this.lbl_LR_Title.Text = "LR Status:";
            // 
            // lbl_LR_Status
            // 
            this.lbl_LR_Status.AutoSize = true;
            this.lbl_LR_Status.Location = new System.Drawing.Point(76, 43);
            this.lbl_LR_Status.Name = "lbl_LR_Status";
            this.lbl_LR_Status.Size = new System.Drawing.Size(35, 13);
            this.lbl_LR_Status.TabIndex = 5;
            this.lbl_LR_Status.Text = "label1";
            // 
            // bt_Exit
            // 
            this.bt_Exit.Location = new System.Drawing.Point(118, 399);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.Size = new System.Drawing.Size(75, 23);
            this.bt_Exit.TabIndex = 6;
            this.bt_Exit.Text = "Exit";
            this.bt_Exit.UseVisualStyleBackColor = true;
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // bt_LR_Start
            // 
            this.bt_LR_Start.Location = new System.Drawing.Point(16, 136);
            this.bt_LR_Start.Name = "bt_LR_Start";
            this.bt_LR_Start.Size = new System.Drawing.Size(95, 23);
            this.bt_LR_Start.TabIndex = 7;
            this.bt_LR_Start.Text = "Start Session";
            this.bt_LR_Start.UseVisualStyleBackColor = true;
            this.bt_LR_Start.Click += new System.EventHandler(this.bt_LR_Start_Click);
            // 
            // bt_LR_End
            // 
            this.bt_LR_End.Location = new System.Drawing.Point(106, 370);
            this.bt_LR_End.Name = "bt_LR_End";
            this.bt_LR_End.Size = new System.Drawing.Size(95, 23);
            this.bt_LR_End.TabIndex = 8;
            this.bt_LR_End.Text = "End Session";
            this.bt_LR_End.UseVisualStyleBackColor = true;
            this.bt_LR_End.Click += new System.EventHandler(this.bt_LR_End_Click);
            // 
            // bt_Upload
            // 
            this.bt_Upload.Location = new System.Drawing.Point(116, 136);
            this.bt_Upload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bt_Upload.Name = "bt_Upload";
            this.bt_Upload.Size = new System.Drawing.Size(84, 23);
            this.bt_Upload.TabIndex = 9;
            this.bt_Upload.Text = "Upload File";
            this.bt_Upload.UseVisualStyleBackColor = true;
            this.bt_Upload.Click += new System.EventHandler(this.bt_Upload_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lbl_FS_Title
            // 
            this.lbl_FS_Title.AutoSize = true;
            this.lbl_FS_Title.Location = new System.Drawing.Point(12, 56);
            this.lbl_FS_Title.Name = "lbl_FS_Title";
            this.lbl_FS_Title.Size = new System.Drawing.Size(59, 13);
            this.lbl_FS_Title.TabIndex = 10;
            this.lbl_FS_Title.Text = "File Status:";
            // 
            // lbl_FS_Status
            // 
            this.lbl_FS_Status.AutoSize = true;
            this.lbl_FS_Status.Location = new System.Drawing.Point(76, 56);
            this.lbl_FS_Status.Name = "lbl_FS_Status";
            this.lbl_FS_Status.Size = new System.Drawing.Size(0, 13);
            this.lbl_FS_Status.TabIndex = 11;
            // 
            // frm_LRInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 434);
            this.Controls.Add(this.lbl_FS_Status);
            this.Controls.Add(this.lbl_FS_Title);
            this.Controls.Add(this.bt_Upload);
            this.Controls.Add(this.bt_LR_End);
            this.Controls.Add(this.bt_LR_Start);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.lbl_LR_Status);
            this.Controls.Add(this.lbl_LR_Title);
            this.Controls.Add(this.lbl_SensorID);
            this.Controls.Add(this.lbl_Sensor_Title);
            this.Controls.Add(this.lbl_CN);
            this.Controls.Add(this.lbl_CN_Title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_LRInstall";
            this.Text = "Live Response Features";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_CN_Title;
        private System.Windows.Forms.Label lbl_CN;
        private System.Windows.Forms.Label lbl_Sensor_Title;
        private System.Windows.Forms.Label lbl_SensorID;
        private System.Windows.Forms.Label lbl_LR_Title;
        private System.Windows.Forms.Label lbl_LR_Status;
        private System.Windows.Forms.Button bt_Exit;
        private System.Windows.Forms.Button bt_LR_Start;
        private System.Windows.Forms.Button bt_LR_End;
        private System.Windows.Forms.Button bt_Upload;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lbl_FS_Title;
        private System.Windows.Forms.Label lbl_FS_Status;
    }
}