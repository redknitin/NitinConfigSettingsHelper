ConfigSettingsHelper
=========================

.NET ConfigSettingsHelper

The .NET ConfigSettingsHelper makes it super-easy to read from and write to the standard .NET config file.

To begin with, add the ConfigSettingsHelper to your project using NuGet by either adding it from the GUI Package Manager or by using the following Package Manager Console statement

    Install-Package ConfigUtilities

Example (appSettings)

    //To write the appSetting
    new ConfigHelper()["themeName"] = "nitin";
    
    //To read the appSetting
    var connStr = new ConfigHelper()["themeName"]
    
Example (connectionStrings)

    //To write the connection string
    string connStr = @"Data Source=localhost;Initial Catalog=testdb;User ID=nitin;Password=red";
    new ConnectionStringHelper()["DbConn"] = connStr;
    
    //To read the connection string
    var connStr = new ConnectionStringHelper()["DbConn"]
