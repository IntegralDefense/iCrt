namespace iCrt_01
{
    partial class frm_FileView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_FileView));
            this.tv_Files = new System.Windows.Forms.TreeView();
            this.bt_Close = new System.Windows.Forms.Button();
            this.bt_Load = new System.Windows.Forms.Button();
            this.lb_FileCount = new System.Windows.Forms.Label();
            this.lbl_Counts = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tv_Files
            // 
            this.tv_Files.Location = new System.Drawing.Point(10, 38);
            this.tv_Files.Name = "tv_Files";
            this.tv_Files.Size = new System.Drawing.Size(776, 377);
            this.tv_Files.TabIndex = 0;
            // 
            // bt_Close
            // 
            this.bt_Close.Location = new System.Drawing.Point(711, 421);
            this.bt_Close.Name = "bt_Close";
            this.bt_Close.Size = new System.Drawing.Size(75, 23);
            this.bt_Close.TabIndex = 1;
            this.bt_Close.Text = "Close";
            this.bt_Close.UseVisualStyleBackColor = true;
            this.bt_Close.Click += new System.EventHandler(this.bt_Close_Click);
            // 
            // bt_Load
            // 
            this.bt_Load.Location = new System.Drawing.Point(10, 421);
            this.bt_Load.Name = "bt_Load";
            this.bt_Load.Size = new System.Drawing.Size(75, 23);
            this.bt_Load.TabIndex = 2;
            this.bt_Load.Text = "Load Files";
            this.bt_Load.UseVisualStyleBackColor = true;
            this.bt_Load.Click += new System.EventHandler(this.bt_Load_Click);
            // 
            // lb_FileCount
            // 
            this.lb_FileCount.AutoSize = true;
            this.lb_FileCount.Location = new System.Drawing.Point(674, 22);
            this.lb_FileCount.Name = "lb_FileCount";
            this.lb_FileCount.Size = new System.Drawing.Size(60, 13);
            this.lb_FileCount.TabIndex = 3;
            this.lb_FileCount.Text = "File Count: ";
            // 
            // lbl_Counts
            // 
            this.lbl_Counts.AutoSize = true;
            this.lbl_Counts.Location = new System.Drawing.Point(741, 22);
            this.lbl_Counts.Name = "lbl_Counts";
            this.lbl_Counts.Size = new System.Drawing.Size(0, 13);
            this.lbl_Counts.TabIndex = 4;
            // 
            // frm_FileView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_Counts);
            this.Controls.Add(this.lb_FileCount);
            this.Controls.Add(this.bt_Load);
            this.Controls.Add(this.bt_Close);
            this.Controls.Add(this.tv_Files);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_FileView";
            this.Text = "Sensor File System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tv_Files;
        private System.Windows.Forms.Button bt_Close;
        private System.Windows.Forms.Button bt_Load;
        private System.Windows.Forms.Label lb_FileCount;
        private System.Windows.Forms.Label lbl_Counts;
    }
}