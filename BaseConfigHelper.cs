using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigUtilities
{
    /// <summary>
    /// Base class for the ConnectionStringHelper and ConfigHelper classes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseConfigHelper<T> where T : new()
    {
        /// <summary>
        /// Factory method
        /// </summary>
        /// <returns></returns>
        public static T GetInstance()
        {
            return new T();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseConfigHelper() { }

        /// <summary>
        /// Constructor accepting the path, which is stored in a member variable
        /// </summary>
        /// <param name="aPath"></param>
        public BaseConfigHelper(string aPath) { Path = aPath; }

        /// <summary>
        /// Private member variable to hold the path of the config file
        /// </summary>
        private string mPath = null;

        /// <summary>
        /// Accessor and mutator to obtain the path of the config file. If the path has not been defined, reflection is used to obtain the location of the application entry assembly.
        /// </summary>
        public string Path
        {
            get
            {
                if (mPath == null)
                {
                    return System.Reflection.Assembly.GetEntryAssembly().Location;
                }
                else
                {
                    return mPath;
                }
            }
            set { mPath = value; }
        }

        /// <summary>
        /// Private member variable used to hold a reference to the configuration object
        /// </summary>
        private System.Configuration.Configuration mConfiguration = null;

        /// <summary>
        /// Protected method for obtaining a reference to the configuration object
        /// </summary>
        protected System.Configuration.Configuration Configuration
        {
            get
            {
                if (mConfiguration == null)
                {
                    mConfiguration = System.Configuration.ConfigurationManager.OpenExeConfiguration(Path);
                }
                return mConfiguration;
            }
        }

    }
}
