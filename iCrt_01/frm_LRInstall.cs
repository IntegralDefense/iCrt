using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Deserializers;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace iCrt_01
{
    public partial class frm_LRInstall : Form
    {
        private static string ComputerName { get; set; }
        private static int sensorID { get; set; }
        private static int sessionID { get; set; }
        private static int fileID { get; set; }
        private static string status { get; set; }
        private static string cmd_status { get; set; }
        private static int cmd_id { get; set; }

        public frm_LRInstall(string Hostname)
        {
            InitializeComponent();
            ComputerName = Hostname;
            lbl_CN.Text = ComputerName;
            sensorID = BEFunctions.GetSensorIdForHost(ComputerName);
            lbl_SensorID.Text = sensorID.ToString();
            lbl_LR_Status.Text = "Disconnected";
            

        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            bt_LR_End_Click(sender, e);
            Dispose();
            Close();
        }

        private void bt_LR_Start_Click(object sender, EventArgs e)
        {
            var LRSession = new CBLRItem();
            LRSession.sensor_id = sensorID;
            var client = new RestClient(iCrt_01.Properties.Resources.CBMasServer);
            var request = new RestRequest(Method.POST);
            
            request.AddHeader("X-Auth-Token", iCrt_01.Properties.Resources.CBApiKey);
            request.Resource = "/v1/cblr/session";
            request.RequestFormat = DataFormat.Json;
            request.AddBody(LRSession);
            

            //We'll loop this portion until we get the session status of active back.  This could take a bit as in some environments there are a lot 
            // of old sessions.  Not sure when CB does the old session clean up. 
            while (status != "active") { 
                var response = client.Execute<List<CBLRItem>>(request);
                try
                {
                    foreach (CBLRItem item in response.Data)
                    {

                        sessionID = item.id;
                        status = item.status;
                        lbl_CWD.Text = item.current_working_directory;
                        //answer = item;
                    }
                    lbl_LR_Status.Text = "Connected, Session ID: " + sessionID.ToString();
                }
                catch
                {
                    //Look for existing sensor ID if this is thrown. 
                    //Assuming we got here due to an existing session.  Starting new request.
                    
                    var request_existingsession = new RestRequest();
                    request_existingsession.AddHeader("X-Auth-Token", iCrt_01.Properties.Resources.CBApiKey);
                    request_existingsession.Resource = "/v1/cblr/session";
                    var response_exist = client.Execute<List<CBLRItem>>(request_existingsession);
                    foreach (CBLRItem item in response_exist.Data)
                    {
                        if (item.sensor_id == sensorID)
                        {
                            sessionID = item.id;
                            if (item.status != "active")
                            {
                                continue;
                            }
                            status = item.status;
                            lbl_CWD.Text = item.current_working_directory;
                        }
                        //answer = item;
                    }
                    lbl_LR_Status.Text = "Connected, Session ID: " + sessionID.ToString();
                }
            }

        }

        private void bt_LR_End_Click(object sender, EventArgs e)
        {
            var LRSession = new CBLRItem();
            LRSession.status = "close";
            var client = new RestClient(iCrt_01.Properties.Resources.CBMasServer);
            var request = new RestRequest(Method.PUT);
            request.AddHeader("X-Auth-Token", iCrt_01.Properties.Resources.CBApiKey);
            request.Resource = "/v1/cblr/session/"+sessionID;
            request.RequestFormat = DataFormat.Json;
            request.AddBody(LRSession);
            
            var response = client.Execute<List<CBLRItem>>(request);
            lbl_LR_Status.Text = "Disconnected";
        }

        private async void bt_Upload_Click(object sender, EventArgs e)
        {
            //Step one is to get the file to the CB server.
            //This needs to be done ASYNC.
            var client = new RestClient(iCrt_01.Properties.Resources.CBMasServer);
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Stream reader = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                var filepath = openFileDialog1.FileName;
                var filename = openFileDialog1.SafeFileName;
                
                var request = new RestRequest(Method.POST);
                request.AddHeader("X-Auth-Token", iCrt_01.Properties.Resources.CBApiKey);
                request.AddHeader("Content-Type", "multipart/form-data");
                request.Resource = "/v1/cblr/session/" + sessionID + "/file";
                request.AlwaysMultipartFormData = true;
                byte[] data = new byte[reader.Length];
                reader.Read(data, 0, (int)reader.Length);

                request.AddFile("file", data, filename);
                var response = await client.ExecuteTaskAsync<List<CBLRFile>>(request);
                //wait for response back from the server that the file uploaded... sadly no progress % returned.
                if (response.ResponseStatus == ResponseStatus.Completed)
                    {
                        foreach (CBLRFile item in response.Data)
                        {
                            fileID = item.id;
                        }

                    }
                lbl_FS_Status.Text = "File Uploaded to server. File ID:" + fileID;
                               
            }

            //If all has gone well we now have a fileID that we can use to PUT the file on the LR machine.

            var put_cmd = new CBLRCmd(); 
            var request_put = new RestRequest(Method.POST);
            request_put.AddHeader("X-Auth-Token", iCrt_01.Properties.Resources.CBApiKey);
            request_put.Resource = "/v1/cblr/session/" + sessionID + "/command";

            put_cmd.name = "put file";
            put_cmd.file_id = fileID;
            put_cmd._object = openFileDialog1.SafeFileName;
            
            string body = JsonConvert.SerializeObject(put_cmd);
            request_put.RequestFormat = DataFormat.Json;
            request_put.AddParameter("application/json", body, ParameterType.RequestBody);
            var response_put = client.Execute<List<CBLRCmd>>(request_put);
            foreach (CBLRCmd item in response_put.Data)
            {
                cmd_status = item.status;
                cmd_id = item.id;
            }
            //The response back from the server is instant in this case but is always "pending"
            //Need to bug the server while we're waiting for that status to come back.
            while (cmd_status == "pending")
            {
                var request_check = new RestRequest();
                request_check.AddHeader("X-Auth-Token", iCrt_01.Properties.Resources.CBApiKey);
                request_check.Resource = "/v1/cblr/session/" + sessionID + "/command";
                var response_check = client.Execute<List<CBLRCmd>>(request_check);
                foreach (CBLRCmd item in response_check.Data)
                {
                    cmd_status = item.status;
                    //cmd_id = item.id;
                }
            }

            lbl_FS_Status.Text = "File uploaded to endpoint.";

        }

        private void bt_RunCMD_Click(object sender, EventArgs e)
        {
            var client = new RestClient(iCrt_01.Properties.Resources.CBMasServer);
            var cmd_body = new CBLRCmd();
            cmd_body.name = "create process";
            cmd_body._object = tb_CommandLine.Text;
            //Execute a command using LR REST Api.
            var request_put = new RestRequest(Method.POST);
            request_put.AddHeader("X-Auth-Token", iCrt_01.Properties.Resources.CBApiKey);
            request_put.Resource = "/v1/cblr/session/" + sessionID + "/command";

            var body = JsonConvert.SerializeObject(cmd_body);
                       
            request_put.AddParameter("application/json", body, ParameterType.RequestBody);
            var response_put = client.Execute<List<CBLRCmd>>(request_put);
            foreach (CBLRCmd item in response_put.Data)
            {
                cmd_status = item.status;
                cmd_id = item.id;
            }

        }

    }
}
