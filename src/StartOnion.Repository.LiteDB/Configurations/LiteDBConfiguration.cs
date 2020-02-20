namespace StartOnion.Repository.LiteDB.Configurations
{
    public class LiteDBConfiguration
    {
        public string PathDB { get; }

        public LiteDBConfiguration(string pathDB)
        {
            PathDB = pathDB;
        }
    }
}
