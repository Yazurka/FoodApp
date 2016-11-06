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
            get { return "Server=zbook17-mnl;Database=app;Uid=iconkeeper;Pwd=mysql;"; }
        }
    }
}
