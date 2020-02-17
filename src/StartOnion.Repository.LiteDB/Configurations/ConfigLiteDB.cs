namespace StartOnion.Repository.LiteDB.Configurations
{
    public class ConfigLiteDB
    {
        public string PathDB { get; }

        public ConfigLiteDB(string pathDB)
        {
            PathDB = pathDB;
        }
    }
}
