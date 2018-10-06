namespace Food.Server
{
    /// <summary>
    ///     Represents the configuration value.
    /// </summary>
    public interface IConfiguration
    {
        /// <summary>
        ///     Gets the connection string to be used for
        ///     connecting to the database.
        /// </summary>
        string ConnectionString { get; }
    }
}
