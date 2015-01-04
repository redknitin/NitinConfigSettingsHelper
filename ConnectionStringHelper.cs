using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigUtilities
{
    /// <summary>
    /// Provides a simple means of reading connection strings from and writing connection strings to the application's configuration file
    /// </summary>
    /// <example>
    /// <code>
    /// //To write the connection string
    /// string connStr = @"Data Source=.;Initial Catalog=nitin;User ID=nitin;Password=nitin";
    /// new ConnectionStringHelper()["DbConn"] = connStr;
    /// 
    /// //To read the connection string
    /// var connStr = new ConnectionStringHelper()["DbConn"]
    /// </code>
    /// </example>
    public class ConnectionStringHelper : BaseConfigHelper<ConnectionStringHelper>
    {
        /// <summary>
        /// Indexer for accessing the connection string entries
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string this[string key]
        {
            get
            {
                if (Configuration.ConnectionStrings.ConnectionStrings[key]!=null)
                {
                    return Configuration.ConnectionStrings.ConnectionStrings[key].ConnectionString;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (Configuration.ConnectionStrings.ConnectionStrings[key] != null)
                {
                    Configuration.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
                }
                else
                {
                    Configuration.ConnectionStrings.ConnectionStrings.Add(new System.Configuration.ConnectionStringSettings(key, value));
                }

                Configuration.Save();
            }
        }
    }
}
