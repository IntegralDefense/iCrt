using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Windows;
using iCrt_01.Model;

namespace iCrt_01
{
    public partial class frm_FileView : Form
    {

        private readonly ObservableFileSystem filesystem = new ObservableFileSystem();
        private CancellationTokenSource cancelSource;
        private readonly BEFunctions cb = new BEFunctions();
        public static string ComputerName { get; private set; }

        public frm_FileView(string Hostname)
        {
            InitializeComponent();
            ComputerName = Hostname;
                      
        }

        private void bt_Close_Click(object sender, EventArgs e)
        {
            cancelSource.Cancel(false);
            Close();
        }

        public static void PopulateTree(TreeView tree, ObservableFileSystem filesystem)
        {
            tree.Nodes.Clear();
            List<TreeNode> roots = new List<TreeNode>();
            roots.Add(tree.Nodes.Add("FilePathFolder"));
        //    roots.Add(tree.Nodes.Add("Items"));
            foreach (FilePathFolder item in filesystem)
            {
                if (item.Children.Count == roots.Count) roots.Add(roots[roots.Count - 1].LastNode);
                roots[item.Children.Count].Nodes.Add(item.Name);
            }
        
        }

        private async void bt_Load_Click(object sender, EventArgs e)
        {
            try
            {
                
                var sensorId = BEFunctions.GetSensorIdForHost(ComputerName);
                if (sensorId == -1)
                {
                    MessageBox.Show(String.Format("A matching sensor could not be found for the Sensor Hostname: '{0}'", ComputerName));
                    return;
                }
                               

                using (cancelSource = new CancellationTokenSource())
                {
                    var resultCount = 0;
                    var totalCount = 0;
                    do
                    {
                        resultCount = await cb.UpdateFilesBatch(filesystem, sensorId, totalCount, 500, cancelSource.Token);
                        if (resultCount < 0)
                        {
                            return;
                        }
                        totalCount += resultCount;
                        lbl_Counts.Text = totalCount.ToString();

                    }
                    while (resultCount > 0);
                    lbl_Counts.Text = totalCount.ToString();
                }

                MessageBox.Show("Done.");
                PopulateTree(tv_Files, filesystem);

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("An error occured: {0}", ex.ToString()));
            }

        }
                
    }


}
