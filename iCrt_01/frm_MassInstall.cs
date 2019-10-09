using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCrt_01
{
    public partial class frm_MassInstall : Form
    {
        public int totalcount = 0;
        public int totalchecked = 0;

        public frm_MassInstall()
        {
            InitializeComponent();
            //bt_Execute.Enabled = false;
            bt_Check.Enabled = false;
            lbl_Total_Count.Text = totalcount.ToString();
            cb_AgentType.SelectedIndex = 0;

        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void bt_Load_Click(object sender, EventArgs e)
        {
            bt_Load.Enabled = false;
            if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using(var reader = new StreamReader(openFileDialog1.FileName))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        dataGridView1.Rows.Add(line, "N/A", "N/A", "N/A", "N/A");
                        totalcount = totalcount + 1;
                        lbl_Total_Count.Text = totalcount.ToString();
                        lbl_Check_Count.Text = totalchecked.ToString();
                    }
                }
            }
            bt_Check.Enabled = true;
        }

        private void bt_Clear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            //bt_Execute.Enabled = false;
            bt_Check.Enabled = false;
            bt_Load.Enabled = true;
            totalchecked = 0;
            totalcount = 0;
            lbl_Total_Count.Text = totalcount.ToString();
            lbl_Check_Count.Text = totalchecked.ToString();
        }

        private void bt_Check_Click(object sender, EventArgs e)
        {
            bt_Check.Enabled = false;
            //Task resultTask = new;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Task resultTask = Task.Factory.StartNew(() =>
                  {
                      try {
                        if (BEFunctions.MachineOnline(row.Cells[0].Value.ToString()))
                        {
                            row.Cells[1].Value = "True";
                              
                             // lbl_Check_Count.Text = totalchecked.ToString();
                          }
                        else
                        {
                            row.Cells[1].Value = "False";
                            totalchecked++;
                             // lbl_Check_Count.Text = totalchecked.ToString();
                        }
                          if (row.Cells[1].Value.ToString() == "True")
                          {
                              if (BEFunctions.canReachPath(row.Cells[0].Value.ToString()))
                              {
                                  row.Cells[2].Value = "True";
                              }
                              else
                              {
                                  row.Cells[2].Value = "False";
                                  totalchecked++;
                              }
                              if (row.Cells[2].Value.ToString() == "True")
                              {
                                  if (BEFunctions.isCBInstalled(row.Cells[0].Value.ToString()))
                                  {
                                      row.Cells[3].Value = "True";
                                      totalchecked++;
                                  }
                                  else
                                  {
                                      row.Cells[3].Value = "False";
                                      totalchecked++;
                                  }
                              }
                              
                          }
                          lbl_Check_Count.Text = totalchecked.ToString();
                      }
                      
                      catch {
                         
                      }
     
                  });
                
            }

            if (totalcount == totalchecked)
            {
                
                bt_Execute.Enabled = true;
            }
        }

        private void bt_Execute_Click(object sender, EventArgs e)
        {
            bt_Execute.Enabled = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Task resultTask = Task.Factory.StartNew(() =>
                {
                    try
                    {
                        
                        if (row.Cells[2].Value.ToString() == "True")
                        {
                            bool server = false;
                            if (cb_AgentType.SelectedIndex == 1)
                            {
                                server = true;
                            }
                            row.Cells[4].Value = "Copying";
                            BEFunctions.copyCB((row.Cells[0].Value.ToString()), server);
                            row.Cells[4].Value = "Unzipping";
                            BEFunctions.unZipCB((row.Cells[0].Value.ToString()));
                            row.Cells[4].Value = "Installing";
                            var commandLine = @"\\" + row.Cells[0].Value.ToString() + @"\admin$\System32\msiexec.exe -i \\" + row.Cells[0].Value.ToString() + @"\c$\tmp\cbsetup.msi /qn";
                            BEFunctions.installCB((row.Cells[0].Value.ToString()), commandLine);
                        }
                    }
                    catch
                    {

                    }

                });

            }
        }

        
    }
}
