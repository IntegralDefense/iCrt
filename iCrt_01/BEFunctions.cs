using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Management;
using System.Net.NetworkInformation;
using RestSharp;
using RestSharp.Deserializers;
using iCrt_01.Model;
using Microsoft.Win32.TaskScheduler;
using System.Threading;
using System.Threading.Tasks;

namespace iCrt_01
{
    class BEFunctions
    {
        private static bool PingHost(string ComputerName)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(ComputerName);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }

        public static bool MachineOnline(string ComputerName)
        {
            bool online = false;
            online = PingHost(ComputerName);
            return online;
        }
                
        public static bool CreateTask(string ComputerName)
        {
            bool success = false;
            try
            {
                using (TaskService ts = new TaskService(Properties.Resources.CBTaskServer))
                {
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = string.Format("CB Install for {0}", ComputerName);
                    td.Principal.LogonType = TaskLogonType.Password;
                    TimeTrigger tt = new TimeTrigger();
                    tt.Enabled = true;
                    tt.StartBoundary = DateTime.Today + TimeSpan.FromHours(23);
                    //tt.EndBoundary = DateTime.Today + TimeSpan.FromDays(2);
                    tt.Repetition.Interval = TimeSpan.FromMinutes(60);
                    tt.Repetition.StopAtDurationEnd = true;
                    tt.Repetition.Duration = TimeSpan.FromDays(1);
                    td.Triggers.Add(tt);
                    ExecAction ea1 = new ExecAction();
                    ea1.Path = @"C:\Windows\System32\WindowsPowerShell\v1.0\PowerShell.exe";
                    ea1.Arguments = Properties.Resources.CBPSScriptPathandName + " " + ComputerName;
                    td.Actions.Add(ea1);
                    string taskName = "CBInstall " + ComputerName;
                    ts.RootFolder.RegisterTaskDefinition(taskName, td, TaskCreation.CreateOrUpdate, Properties.Resources.CBserviceAccount, Properties.Resources.CBSApwd);
                    success = true;
                   
                }
            }
            catch
            {

            }
            

                return success;
        }

        public static bool QueryMachine(string ComputerName)
        {

            return false;
        }

        public static bool GetMachineInfo(string ComputerName)
        {

            return false;
        }

        public static bool canReachPath(string ComputerName)
        {
            // Check to see if the admin path is open on the machine for copying.
            bool success = false;
            string path = @"\\" + ComputerName + @"\c$";
            try
            {
                if (Directory.Exists(path))
                {
                    // Admin share exists, lets check for tmp
                    success = true;                                       
                }
            }
            catch (Exception)
            {
                
            }

            return success;
        }

        public static bool isCBInstalled(string ComputerName)
        {
            
            bool success = false;
            string targetvalue = "Carbon Black Sensor";
            List<string> programs = ReadRemoteRegistryusingWMI(ComputerName);
            foreach (string program in programs)
            {
                if (program == targetvalue)
                {
                    success = true;
                    break;
                }
            }
            
            return success;
        }

        public static bool copyCB(string ComputerName)
        {
            //Function assumes that preflight checks are met.  Machine is online and the admin share can be reached.
            bool success = false;
            string targetpath = @"\\" + ComputerName + @"\c$\tmp";
            string sourcepath = iCrt_01.Properties.Resources.CBSourceServer + @"\" + iCrt_01.Properties.Resources.CbfileName;

            string destfile = System.IO.Path.Combine(targetpath, iCrt_01.Properties.Resources.CbfileName);

            //create tmp folder if it does not exist.
            try
            {
                if (!Directory.Exists(targetpath))
                {
                    Directory.CreateDirectory(targetpath);
                    //success = true;
                }
                else
                {
                    //Folder already exists.
                    //success = true;
                }
            }
            catch (Exception)
            {

            }

            //Now try to copy the file from the server to the client machine.
            try
            {
                File.Copy(sourcepath, destfile, true);
                success = true;
            }
            catch
            {
                //File copy failed
            }

            return success;
        }

        public static bool copyLERC(string ComputerName)
        {
            //Function assumes that preflight checks are met.  Machine is online and the admin share can be reached.
            bool success = false;
            string targetpath = @"\\" + ComputerName + @"\c$\tmp";
            string sourcepath = iCrt_01.Properties.Resources.LERCServer + @"\" + iCrt_01.Properties.Resources.LERCFileName;

            string destfile = System.IO.Path.Combine(targetpath, iCrt_01.Properties.Resources.LERCFileName);

            //create tmp folder if it does not exist.
            try
            {
                if (!Directory.Exists(targetpath))
                {
                    Directory.CreateDirectory(targetpath);
                    //success = true;
                }
                else
                {
                    //Folder already exists.
                    //success = true;
                }
            }
            catch (Exception)
            {

            }

            //Now try to copy the file from the server to the client machine.
            try
            {
                File.Copy(sourcepath, destfile, true);
                success = true;
            }
            catch
            {
                //File copy failed
            }

            return success;
        }

        public static int installCB(string ComputerName, string commandLine)
        {
            int returnval = -1;
            //var commandLine = @"\\" + ComputerName + @"\admin$\System32\msiexec.exe -i \\" + ComputerName + @"\c$\tmp\cbsetup.msi /qn";

            try
            {

                ConnectionOptions connOptions = new ConnectionOptions();
                connOptions.Impersonation = ImpersonationLevel.Impersonate;
                connOptions.EnablePrivileges = true;
                ManagementScope manScope = new ManagementScope(string.Format(@"\\{0}\ROOT\CIMV2", ComputerName), connOptions);
                manScope.Connect();
                ObjectGetOptions objectGetOptions = new ObjectGetOptions();
                ManagementPath managementPath = new ManagementPath("Win32_Process");
                ManagementClass processClass = new ManagementClass(manScope, managementPath, objectGetOptions);
                ManagementBaseObject inParams = processClass.GetMethodParameters("Create");
                inParams["CommandLine"] = commandLine;
                ManagementBaseObject outParams = processClass.InvokeMethod("Create", inParams, null);

                Console.WriteLine("Creation of the process returned: " + outParams["returnValue"]);
                Console.WriteLine("Process ID: " + outParams["processId"]);
                returnval = Convert.ToInt32(outParams["processId"]);
            }
            catch
            {

            }
            return returnval;
        }

        public static int uninstallCB(string ComputerName)
        {
            int returnval = -1;
            var commandLine = @"\\" + ComputerName + @"\admin$\System32\msiexec.exe /x {6A351232-5472-4290-B5D8-39217F82095B} /qn";


            try
            {

                ConnectionOptions connOptions = new ConnectionOptions();
                connOptions.Impersonation = ImpersonationLevel.Impersonate;
                connOptions.EnablePrivileges = true;
                ManagementScope manScope = new ManagementScope(string.Format(@"\\{0}\ROOT\CIMV2", ComputerName), connOptions);
                manScope.Connect();
                ObjectGetOptions objectGetOptions = new ObjectGetOptions();
                ManagementPath managementPath = new ManagementPath("Win32_Process");
                ManagementClass processClass = new ManagementClass(manScope, managementPath, objectGetOptions);
                ManagementBaseObject inParams = processClass.GetMethodParameters("Create");
                inParams["CommandLine"] = commandLine;
                ManagementBaseObject outParams = processClass.InvokeMethod("Create", inParams, null);

                Console.WriteLine("Creation of the process returned: " + outParams["returnValue"]);
                Console.WriteLine("Process ID: " + outParams["processId"]);
                returnval = Convert.ToInt32(outParams["processId"]);
            }
            catch
            {

            }
            return returnval;
        }

        public static int GetSensorIdForHost(string ComputerName)
        {
            int sensorId = -1;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var answer = new CBSensor();
            var client = new RestClient(iCrt_01.Properties.Resources.CBMasServer);
            var request = new RestRequest();
            //int sensorId = "";
            request.AddHeader("X-Auth-Token", iCrt_01.Properties.Resources.CBApiKey);
            request.Resource = "/v1/sensor?hostname=" + ComputerName;
            request.RootElement = "CBSensor";

            var response = client.Execute<List<CBSensor>>(request);

            foreach (CBSensor item in response.Data)
            {
                if (item.id > sensorId)
                {
                    sensorId = item.id;
                    answer = item;
                }
                
            }

            sensorId = answer.id;
            return sensorId;
        }

        public async Task<int> UpdateFilesBatch(ObservableFileSystem fileSystem, int sensorId, int start, int rows, CancellationToken cancelToken = default(CancellationToken))
        {

            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var client = new RestClient();
            client.BaseUrl = new System.Uri(iCrt_01.Properties.Resources.CBMasServer);
            var filereq = new RestRequest();
            filereq.AddHeader("X-Auth-Token", iCrt_01.Properties.Resources.CBApiKey);
            filereq.Resource = "/v1/process?start={start}&rows={rows}&q=sensor_id:{sensorID} and filemod_count:[1 TO *]&sort=start asc";
            filereq.AddParameter("start", start, ParameterType.UrlSegment);
            filereq.AddParameter("rows", rows, ParameterType.UrlSegment);
            filereq.AddParameter("sensorID", sensorId, ParameterType.UrlSegment);
            
            var queryForPidsResponse = client.Execute<CBResult>(filereq);
            if (cancelToken.IsCancellationRequested)
                            {
                                return -1;
                            }
            if (queryForPidsResponse.StatusCode != System.Net.HttpStatusCode.OK)
                            {
                                throw new ApplicationException(String.Format("Could not get process batch for sensor id:{0}, start:{1}, rows:{2} - HTTP Code {3}",
                                    sensorId, start, rows, queryForPidsResponse.StatusCode));
                            }
            else
            {
                int resultCount = 0;
                foreach (var item in queryForPidsResponse.Data.results)
                {
                    RestSharp.RestResponse response = new RestSharp.RestResponse();
                    response.Content = item;
                    RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
                    var result = deserial.Deserialize<CBProcess>(response);

                    var processId = result.id;
                    var segmentId = result.segment_id;
                    var eventreq = new RestRequest();
                    eventreq.AddHeader("X-Auth-Token", iCrt_01.Properties.Resources.CBApiKey);
                    eventreq.Resource=(String.Format("/v1/process/{0}/{1}/event", processId, segmentId));
                    var queryForEventsResponse = await client.ExecuteTaskAsync<CBResultProc>(eventreq, cancelToken);
                    if (queryForEventsResponse.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        // do something
                    }
                    else
                    {
                        foreach (var filemod in queryForEventsResponse.Data.process)
                        {
                            if (filemod.filemod_complete == null)
                            {
                                continue;
                            }
                            else
                            {
                                try
                                {
                                foreach(string evt in filemod.filemod_complete)
                                    {
                                        var evtParts = evt.Split('|');
                                        int type = Convert.ToInt32(evtParts[0]);
                                        fileSystem.AddFileSystemItem(evtParts[2], evtParts[1], type);

                                    }
                                                      
                                                        
                                }
                                catch
                                {
                                    continue;
                                }
                            }
                            
                            
                        }
                    }
                    resultCount++;

                    if (cancelToken.IsCancellationRequested)
                    {
                        return resultCount;
                    }
                }

                return resultCount;
            }
                               
        }

        public static bool unZipCB(string ComputerName)
        {
            //This assumes that all precheck conditions have been met, IE the admin share can be reached and the file exists on the target machine
            bool success = false;

            string targetpath = @"\\" + ComputerName + @"\c$\tmp";
            string targetzip = System.IO.Path.Combine(targetpath, iCrt_01.Properties.Resources.CbfileName);

            try
            {
                System.IO.Compression.ZipFile.ExtractToDirectory(targetzip, targetpath);
                success = true;
            }
            catch
            {
                
            }
            return success;
        }

        public static bool estLRSession(RestClient CBClient, int SensorID)
        {
            bool success = false;


            return success;
        }

        public static CBSensor getCBSensorInfo(string ComputerName)
        {
            int sensorId = -1;
            
            var answer = new CBSensor();
            var client = new RestClient(iCrt_01.Properties.Resources.CBMasServer);
            var request = new RestRequest();
            request.AddHeader("X-Auth-Token", iCrt_01.Properties.Resources.CBApiKey);
            request.Resource = "/v1/sensor?hostname=" + ComputerName;
            request.RootElement = "CBSensor";
            
            var response = client.Execute<List<CBSensor>>(request);

            try
            {
                foreach (CBSensor item in response.Data)
                            {
                                if (item.id > sensorId)
                                {
                                    sensorId = item.id;
                                    answer = item;

                                }
                           }
            }
            catch
            {

            }
            
            return answer;
            
        }

        private static List<string> ReadRemoteRegistryusingWMI(string ComputerName)
        {
            List<string> programs = new List<string>();

            ConnectionOptions connectionOptions = new ConnectionOptions();
            //connectionOptions.Impersonation = ImpersonationLevel.Impersonate;
            ManagementScope scope = new ManagementScope("\\\\" + ComputerName + "\\root\\CIMV2", connectionOptions);
            try
            {
                scope.Connect();

                string softwareRegLoc = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";

                ManagementClass registry = new ManagementClass(scope, new ManagementPath("StdRegProv"), null);
                ManagementBaseObject inParams = registry.GetMethodParameters("EnumKey");
                inParams["hDefKey"] = 0x80000002;//HKEY_LOCAL_MACHINE
                inParams["sSubKeyName"] = softwareRegLoc;

                // Read Registry Key Names 
                ManagementBaseObject outParams = registry.InvokeMethod("EnumKey", inParams, null);
                string[] programGuids = outParams["sNames"] as string[];

                foreach (string subKeyName in programGuids)
                {
                    inParams = registry.GetMethodParameters("GetStringValue");
                    inParams["hDefKey"] = 0x80000002;//HKEY_LOCAL_MACHINE
                    inParams["sSubKeyName"] = softwareRegLoc + @"\" + subKeyName;
                    inParams["sValueName"] = "DisplayName";
                    // Read Registry Value 
                    outParams = registry.InvokeMethod("GetStringValue", inParams, null);

                    if (outParams.Properties["sValue"].Value != null)
                    {
                        string softwareName = outParams.Properties["sValue"].Value.ToString();
                        programs.Add(softwareName);
                    }
                }
            }
            catch
            {

            }

            
            return programs;
        }

       

    }
}
