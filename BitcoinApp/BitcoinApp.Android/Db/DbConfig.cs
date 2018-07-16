using BitcoinApp.Db;
using Xamarin.Forms;

[assembly: Dependency(typeof(BitcoinApp.Droid.Db.DbConfig))]
namespace BitcoinApp.Droid.Db
{
    public class DbConfig : IDbConfig
    {
        private string _dbPath;

        public string DBPath
        {
            get
            {
                if (string.IsNullOrEmpty(_dbPath))
                {
                    _dbPath = System.Environment.GetFolderPath(
                        System.Environment.SpecialFolder.Personal);
                }
                return _dbPath;
            }
        }
    }
}