# iCrt
Windows C# Gui Implementation of the Carbon Black Response feature set.

Will interrogate a machine via WMI to determine prescense of a CB sensor, then check with a CB Master server to show last checkin time of the sensor, handy for indentifying a machine that might have a bad install. 

Includes many useful features.  Can deploy the CB Response agent to accessible machines on the same LAN.  (Admin rights required on target devices.)  

Mass install feature to deploy to multiple machines at once across a network.  

Configurable for most any enterprise environment.

-In Progress - GUI implementation of common LiveResponse features such as dropping and retrieving files from a LR session.
  File structure browser of a target machine (VERY SLOW)
  
  In order to make use of the tool in your environment, you will need to add your information to the following property resource fields in the application prior to building it.
  
CBApiKey - Your API key from your CB Response instance.

CbfileName - File name of the compressed CB Sensor install.

CBMasServer - FQDN of your CB Master server with the API path so... EX: https://cbmaster.mycompany.com:8443/api

CBPSScriptPathandName - This is the install script to be called on a scheduled task server.  Could be anything called from Task scheduler. EX: C:\Scripts\CBInstall\CN_InstallClient.ps1

CBSApwd - Password to be used for creating scheduled tasks.

CBserviceAccount - Account to be used for creating scheduled tasks.

CBSourceServer - FQDN and path of where your Carbon Black Response sensor installer is.  EX: \\CBFileServer.Mycompany.com\Clientintallers

CBTaskServer - FQDN of the server you want to use as a scheduled task server for offline installs.  EX: TASKSERVER.mycompany.com

LERCFileName - This ties into another GIT project, this is the installer name for the Live Response module. Ex: lercSetup.msi

LERCServer - Similar to the path used for CBSourceServer just is the path for LERCFileName - EX: \\lercfileserver.mycompany.com\ClientInstallers
  
