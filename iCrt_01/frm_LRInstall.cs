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

namespace iCrt_01
{
    public partial class frm_LRInstall : Form
    {
        private static string ComputerName { get; set; }
        private static int sensorID { get; set; }
        private static int sessionID { get; set; }
        private static int fileID { get; set; }
        private static string status { get; set; }

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

        private void bt_Upload_Click(object sender, EventArgs e)
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
                var response = client.Execute<List<CBLRFile>>(request);
                foreach (CBLRFile item in response.Data)
                {
                    fileID = item.id;
                }
                //lbl_LR_Status.Text = "Connected, Session ID: " + sessionID.ToString();
            }
            //If all has gone well we now have a fileID that we can use to PUT the file on the LR machine.
             
            var request_put = new RestRequest(Method.POST);
            request_put.AddHeader("X-Auth-Token", iCrt_01.Properties.Resources.CBApiKey);
            request_put.Resource = "/v1/cblr/session/" + sessionID + "/command";
            var lrFile = new CBLRCmd();
            lrFile.name = "put file";
            lrFile.file_id = fileID;
            //Lets build a JSON string to upload the file to the LR machine.
            //This will be made up of three segments, name, file_id and object.
            //Some super genius at CB named on of the JSON fields "object"
            string name_field = "\"name\":\"put file\"";
            string file_id = String.Format("\"file_id\":\"{0}\"", fileID);
            string object_field = String.Format("\"object\":\"{0}\"", openFileDialog1.SafeFileName);
            string body = "{" + name_field + "," + file_id + "," + object_field + "}";
            request_put.RequestFormat = DataFormat.Json;
            request_put.AddParameter("application/json", body, ParameterType.RequestBody);
            var response_put = client.Execute(request_put);
        }
    }
}
