using System.Configuration;

namespace Food.Server
{
    public class AppSettingsConfiguration : IConfiguration
    {

        /// <summary>
        /// Gets the connection string to be used for 
        /// connecting to the database. 
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionString"]; }
        }
    }
}
