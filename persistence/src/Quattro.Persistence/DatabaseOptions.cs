namespace Quattro.Persistence
{
    public enum Database
    {
        MySql,
        SqlServer
    }
    public class DatabaseOptions
    {
        public string ConnectionString { get; set; }

        public Database Database { get; set; }
    }
}
