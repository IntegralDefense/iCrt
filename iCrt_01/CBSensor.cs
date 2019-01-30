using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCrt_01
{
    public class CBSensor
    {
        public string systemvolume_total_size { get; set; }
        public string emet_telemetry_path { get; set; }
        public string os_environment_display_string { get; set; }
        public string emet_version { get; set; }
        public string emet_dump_flags { get; set; }
        public string clock_delta { get; set; }
        public bool supports_cblr { get; set; }
        public string sensor_uptime { get; set; }
        public string last_update { get; set; }
        public string physical_memory_size { get; set; }
        public int build_id { get; set; }
        public string uptime { get; set; }
        public bool is_isolating { get; set; }
        public string event_log_flush_time { get; set; }
        public string computer_dns_name { get; set; }
        public string emet_report_setting { get; set; }
        public int id { get; set; }
        public int emet_process_count { get; set; }
        public bool emet_is_gpo { get; set; }
        public int power_state { get; set; }
        public bool network_isolation_enabled { get; set; }
        public bool uninstalled { get; set; }
        public string systemvolume_free_size { get; set; }
        public string status { get; set; }
        public string num_eventlog_bytes { get; set; }
        public string sensor_health_message { get; set; }
        public string build_version_string { get; set; }
        public string computer_sid { get; set; }
        public string next_checkin_time { get; set; }
        public int node_id { get; set; }
        public int cookie { get; set; }
        public string emet_exploit_action { get; set; }
        public string computer_name { get; set; }
        public string license_expiration { get; set; }
        public bool supports_isolation { get; set; }
        public string parity_host_id { get; set; }
        public bool supports_2nd_gen_modloads { get; set; }
        public string network_adapters { get; set; }
        public int sensor_health_status { get; set; }
        public string registration_time { get; set; }
        public bool restart_queued { get; set; }
        public string notes { get; set; }
        public string num_storefiles_bytes { get; set; }
        public int os_environment_id { get; set; }
        public int shard_id { get; set; }
        public string boot_id { get; set; }
        public string last_checkin_time { get; set; }
        public int os_type { get; set; }
        public int group_id { get; set; }
        public bool display { get; set; }
        public bool uninstall { get; set; } //
    }

    public class CBProcess
    {
        public string process_md5 { get; set; } //	"000000000000000000000000000000"
        public int sensor_id { get; set; } //	6049
        public bool filtering_known_dlls { get; set; } //	false
        public int modload_count { get; set; } //	0
        public string parent_unique_id { get; set; } //	"000017a1-0000-0004-01d4-666544f194c0-000000000001"
        public int emet_count { get; set; } //	0
        public string cmdline { get; set; } //	"(unknown)"
        public int filemod_count { get; set; } //	15
        public string id { get; set; } //	"000017a1-0000-0064-01d4-666544f9eaa2"
        public string parent_name { get; set; } //	"(unknown)"
        public string parent_md5 { get; set; } //	"000000000000000000000000000000"
        public string group { get; set; } //	"cybersecurity"
        public string parent_id { get; set; } //	"000017a1-0000-0004-01d4-666544f194c0"
        public string hostname { get; set; } //	"etd0156456"
        public string last_update { get; set; } //	"2018-10-27T16:04:06.016Z"
        public string start { get; set; } //	"2018-10-17T22:03:43.554Z"
        public int comms_ip { get; set; } //	-1,568,609,750 2,147,483,647
        public int regmod_count { get; set; } //	44
        public int interface_ip { get; set; } //	-1568609750
        public int process_pid { get; set; } //	100
        public string username { get; set; } //	"SYSTEM"
        public bool terminated { get; set; } //	false
        public string process_name { get; set; } //	"registry"
        public string emet_config { get; set; } //""
        public string last_server_update { get; set; } //	"2018-10-27T16:09:00.186Z"
        public string path { get; set; } //"registry"
        public int netconn_count { get; set; } //	0
        public int parent_pid { get; set; } //	4
        public int crossproc_count { get; set; } //	32
        public long segment_id { get; set; } //	1540656540141
        public string host_type { get; set; } //"workstation"
        public int processblock_count { get; set; } //	0
        public string os_type { get; set; } //"windows"
        public int childproc_count { get; set; } //	0
        public string unique_id { get; set; } //"000017a1-0000-0064-01d4-666544f9eaa2-0166b64929ed"
    }

    public class CBProcDetail
    {
        public int modload_count { get; set; } //0
        public int sensor_id { get; set; } //6049
        public string uid { get; set; } //"S-1-5-18"
        public bool filtering_known_dlls { get; set; } //	false
        public string parent_unique_id { get; set; } //"000017a1-0000-0004-01d4-666544f194c0-000000000001"
        public List<string> regmod_complete { get; set; } //	
        //0	"8|2018-10-27 16:04:06.016|\\registry\\machine\\system\\controlset001\\control\\hivelist\\\\registry\\machine\\drivers|false"
        public List<string> filemod_complete { get; set; } //
        public string cmdline { get; set; } //""
        public string max_last_update { get; set; } //	"2018-10-27T16:04:06.016Z"
        public string min_last_update { get; set; } //	"2018-10-27T16:04:06.016Z"
        public string last_update { get; set; } //	"2018-10-27T16:04:06.016Z"
        public string id { get; set; } //	"000017a1-0000-0064-01d4-666544f9eaa2"
        public bool terminated { get; set; } //false
        public int crossproc_count { get; set; } //	32
        public string group { get; set; } //"cybersecurity"
        public string max_last_server_update { get; set; } //"2018-10-27T16:09:00.186Z"
        public string parent_id { get; set; } //"000017a1-0000-0004-01d4-666544f194c0"
        public string hostname { get; set; } //"etd0156456"
        public int filemod_count { get; set; } //15
        public string start { get; set; } //"2018-10-17T22:03:43.554Z"
        public int comms_ip { get; set; } //-1568609750
        public int netconn_count { get; set; } //0
        public int interface_ip { get; set; } //	-1568609750
        public int process_pid { get; set; } //100
        public string username { get; set; } //	"SYSTEM"
        public string process_name { get; set; } //	"registry"
        public int emet_count { get; set; } //	0
        public string last_server_update { get; set; } //	"2018-10-27T16:09:00.186Z"
        public string path { get; set; } //"registry"
        public int regmod_count { get; set; } //	44
        public int parent_pid { get; set; } //	4
        public long segment_id { get; set; } //1540656540141
        public string min_last_server_update { get; set; } //	"2018-10-27T16:09:00.186Z"
        public string host_type { get; set; } //	"workstation"
        public int processblock_count { get; set; } //	0
        public string os_type { get; set; } //"windows"
        public int childproc_count { get; set; } //	0
        public string unique_id { get; set; } //	"000017a1-0000-0064-01d4-666544f9eaa2-0166b64929ed"
    }

    public class CBResult
    {
        public List<string> terms { get; set; }
        public List<string> results { get; set; }

    }

    public class CBResultProc
    {
        public List<CBProcDetail> process { get; set; }
        public string elapsed { get; set; }
        
    }

    public class CBLRItem
    {
        public string status { get; set; } //: "pending", 
        public int sensor_id { get; set; } //: 10, 
        public List<string> supported_commands { get; set; } //: [], 
        public List<string> drives { get; set; } //: [], 
        public int storage_size { get; set; } // 0, 
        public long create_time  { get; set; } //: 1418247933.634789, 
        public int sensor_wait_timeout { get; set; } //: 120, 
        public string address { get; set; } //: null, 
        public int check_in_timeout { get; set; } //: 1200, 
        public int id { get; set; }//: 2, 
        public string hostname { get; set; }//: "WIN-EP7RMLTCLAJ", 
        public int storage_ttl { get; set; }//: 7, 
        public string os_version { get; set; } // "", 
        public int session_timeout { get; set; } //: 300, 
        public string current_working_directory { get; set; }//: ""

    }

    public class CBLRFile
    {
        public int status { get; set; }
        public string file_name { get; set; }
        public int size_uploaded { get; set; }
        public int size { get; set; }
        public int id { get; set; }
        public bool delete { get; set; }
    }

    public class CBLRCmd
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; } //: id of this command
        [JsonProperty(PropertyName = "session_id")]
        public int session_id { get; set; } //: the id of the session
        [JsonProperty(PropertyName = "sensor_id")]
        public int sensor_id { get; set; } //: the sensor id for the session
        [JsonProperty(PropertyName = "command_timeout")]
        public int command_timeout { get; set; } //: the timeout(in seconds) that the sensor is willing to wait until the command completes.
        [JsonProperty(PropertyName = "status")]
        public string status { get; set; } //: One of the following: “in progress”, “complete”, “cancel”, “error”
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; } //: The name of the command(ie “reg set”, “reg query”, “get file”….)
        [JsonProperty(PropertyName = "object")]
        public string  _object { get; set; } //: the object the command operates on.This is specific to the command but has meaning in a generic way for logging, and display purposes
        [JsonProperty(PropertyName = "completion_time")]
        public int completion_time { get; set; } //
        [JsonProperty(PropertyName = "file_id")]
        public int file_id { get; set; } //


    }

}
