using FullApp.Services.Interfaces;

namespace FullApp.Services
{
    public class DatabaseService : IDatabaseService
    {
        public string GetDataFromDatabase1()
        {
            return "DataFrom database 1";
        }

        public string GetDataFromDatabase2()
        {
            return "DataFrom database 2";
        }
    }
}
