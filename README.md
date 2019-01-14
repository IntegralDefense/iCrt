# iCrt
Windows C# Gui Implementation of the Carbon Black Response feature set.

Will interrogate a machine via WMI to determine prescense of a CB sensor, then check with a CB Master server to show last checkin time of the sensor, handy for indentifying a machine that might have a bad install. 

Includes many useful features.  Can deploy the CB Response agent to accessible machines on the same LAN.  (Admin rights required on target devices.)  

Mass install feature to deploy to multiple machines at once across a network.  

Configurable for most any enterprise environment.

-In Progress - GUI implementation of common LiveResponse features such as dropping and retrieving files from a LR session.
  File structure browser of a target machine (VERY SLOW)