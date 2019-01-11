using System;
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
    public partial class frm_icrt_main : Form
    {
        public string Computername;

        public frm_icrt_main()
        {
            InitializeComponent();
            bt_Install.Enabled = false;
            bt_ViewFiles.Enabled = false;
            bt_Uninstall.Enabled = false;
            bt_Install_Sched.Enabled = false;
            bt_LR_Install.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Stop clicking the button!
            //button1.Enabled = false;

            rb_Offline.Checked = false;
            rb_Online.Checked = false;
            bt_Install.Enabled = false;
            bt_Install_Sched.Enabled = false;
            tb_Display.Clear();
            bool Isonline;
            Computername = textBox1.Text;
            //Machine preflight checks is it online?
            Isonline = BEFunctions.MachineOnline(Computername);
            if (Isonline == true)
            {
                tb_Display.AppendText("Machine is online");
                tb_Display.AppendText(Environment.NewLine);
                
                if (BEFunctions.canReachPath(Computername))
                {
                    tb_Display.AppendText("Admin share is accessible");
                    tb_Display.AppendText(Environment.NewLine);
                    rb_Online.Checked = true;
                    bt_Install.Enabled = true;
                   
                }
                else
                {
                    tb_Display.AppendText("Admin share is inaccessible");
                    tb_Display.AppendText(Environment.NewLine);
                    rb_Offline.Checked = true;
                }
                //IS CB Installed?
                if (rb_Online.Checked)
                {
                    if (BEFunctions.isCBInstalled(Computername))
                    {
                        tb_Display.AppendText("Carbon Black local install found");
                        tb_Display.AppendText(Environment.NewLine);
                        bt_Uninstall.Enabled = true;
                    }
                    else
                    {
                        tb_Display.AppendText("Carbon Black local install NOT found");
                        tb_Display.AppendText(Environment.NewLine);
                    }
                }
                
                
                CBSensor cbSensor = BEFunctions.getCBSensorInfo(Computername);
                if (!(cbSensor.id == 0))
                {
                    tb_Display.AppendText("Carbon Black sensor found on server: " + cbSensor.id);
                    tb_Display.AppendText(Environment.NewLine);
                    tb_Display.AppendText("Carbon Black sensor version: " + cbSensor.build_version_string);
                    tb_Display.AppendText(Environment.NewLine);
                    tb_Display.AppendText("CB Last check-in:  " + cbSensor.last_checkin_time);
                    tb_Display.AppendText(Environment.NewLine);
                    tb_Display.AppendText("CB Client OS:  " + cbSensor.os_environment_display_string);
                    tb_Display.AppendText(Environment.NewLine);
                    bt_ViewFiles.Enabled = true;
                    bt_LR_Install.Enabled = true;
                }
                else
                {
                    tb_Display.AppendText("Carbon Black sensor instance not found.");
                    tb_Display.AppendText(Environment.NewLine);
                }


            }
            else
            {
                tb_Display.AppendText("Machine hostname is offline.");
                tb_Display.AppendText(Environment.NewLine);
                rb_Offline.Checked = true;
                bt_Install_Sched.Enabled = true;
            }
        }

        private void bt_Reset_Click(object sender, EventArgs e)
        {
            tb_Display.Clear();
            textBox1.Clear();
            Computername = textBox1.Text;
            button1.Enabled = true;
            bt_Install.Enabled = false;
            bt_ViewFiles.Enabled = false;
            bt_Uninstall.Enabled = false;
            bt_Install_Sched.Enabled = false;
            bt_LR_Install.Enabled = false;

        }

        private void bt_ViewFiles_Click(object sender, EventArgs e)
        {
            Computername = textBox1.Text;
            var Newform = new frm_FileView(Computername);
            Newform.Show();
        }

        private void bt_Install_Click(object sender, EventArgs e)
        {
            var commandLine = @"\\" + Computername + @"\admin$\System32\msiexec.exe -i \\" + Computername + @"\c$\tmp\cbsetup.msi /qn";
            bt_Install.Enabled = false;
            if (BEFunctions.copyCB(Computername))
            {
                tb_Display.AppendText("CB Package copied.");
                tb_Display.AppendText(Environment.NewLine);
            }
            if (BEFunctions.unZipCB(Computername))
            {
                tb_Display.AppendText("CB Package unzipped.");
                tb_Display.AppendText(Environment.NewLine);
            }
            var returnval = BEFunctions.installCB(Computername, commandLine);
            if ( returnval != -1)
            {
                tb_Display.AppendText(String.Format("CB Package installer started, Process ID {0}.", returnval));
                tb_Display.AppendText(Environment.NewLine);
            }
           
        }

        private void bt_Install_Sched_Click(object sender, EventArgs e)
        {
            bt_Install_Sched.Enabled = false;
            Computername = textBox1.Text;
            if (BEFunctions.CreateTask(Computername))
            {
                tb_Display.AppendText("CB Package install task scheduled.");
                tb_Display.AppendText(Environment.NewLine);
                
            }

        }

        private void bt_Uninstall_Click(object sender, EventArgs e)
        {
            var returnval = BEFunctions.uninstallCB(Computername);
            if (returnval != -1)
            {
                tb_Display.AppendText(String.Format("CB Package uninstaller started, Process ID {0}.", returnval));
                tb_Display.AppendText(Environment.NewLine);
            }
        }

        private void bt_MassInst_Click(object sender, EventArgs e)
        {
            var Newform = new frm_MassInstall();
            Newform.Show();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void bt_LERC_online_Click(object sender, EventArgs e)
        {
            var commandLine = @"\\" + Computername + @"\admin$\System32\msiexec.exe -i \\" + Computername + @"\c$\tmp\lercSetup.msi /qn /l lerc_install.log company=2 reconnectdelay=60 chunksize=2048 serverurls=https://control.integraldefense.com/";
            

            bt_LERC_online.Enabled = false;
            if (BEFunctions.copyCB(Computername))
            {
                tb_Display.AppendText("LERC Package copied.");
                tb_Display.AppendText(Environment.NewLine);
            }
            
            var returnval = BEFunctions.installCB(Computername, commandLine);
            if (returnval != -1)
            {
                tb_Display.AppendText(String.Format("CB Package installer started, Process ID {0}.", returnval));
                tb_Display.AppendText(Environment.NewLine);
            }
        }

        private void bt_Lerc_Offline_Click(object sender, EventArgs e)
        {
            bt_Lerc_Offline.Enabled = false;
            Computername = textBox1.Text;
            if (BEFunctions.CreateTask(Computername))
            {
                tb_Display.AppendText("LERC Package install task scheduled.");
                tb_Display.AppendText(Environment.NewLine);

            }
        }

        private void bt_LR_Install_Click(object sender, EventArgs e)
        {
            Computername = textBox1.Text;
            var Newform = new frm_LRInstall(Computername);
            Newform.Show();
        }
    }
}
