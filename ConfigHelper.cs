using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigUtilities
{
    /// <summary>
    /// Provides a simple means of reading from and writing to the application's configuration file
    /// </summary>
    /// <example>
    /// <code>
    /// //To write the appSetting
    /// new ConfigHelper()["themeName"] = "nitin";
    /// 
    /// //To read the appSetting
    /// var connStr = new ConfigHelper()["themeName"]
    /// </code>
    /// </example>
    public class ConfigHelper : BaseConfigHelper<ConfigHelper>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ConfigHelper() { }

        /// <summary>
        /// Constructor accepting the path of the config file
        /// </summary>
        /// <param name="aPath">Path of the config file</param>
        public ConfigHelper(string aPath) : base(aPath) { }

        /// <summary>
        /// Indexer for accessing the configuration entries
        /// </summary>
        /// <param name="key">Key of the configuration item</param>
        /// <returns>Value of the configuration item</returns>
        public string this[string key] {
            get
            {
                if (Configuration.AppSettings.Settings.AllKeys.Contains(key))
                {
                    return Configuration.AppSettings.Settings[key].Value;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (Configuration.AppSettings.Settings.AllKeys.Contains(key))
                {
                    Configuration.AppSettings.Settings[key].Value = value;
                }
                else
                {                    
                    Configuration.AppSettings.Settings.Add(key, value);
                }

                Configuration.Save();
            }
        }
    }
}
