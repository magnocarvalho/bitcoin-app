using BitcoinApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace BitcoinApp.Db
{
    public class DbBase : IDisposable
    {
        protected SQLiteConnection Connection;

        public DbBase()
        {
            var config = DependencyService.Get<IDbConfig>();
            Connection = new SQLiteConnection(Path.Combine(config.DBPath, "database.db3"),
                SQLiteOpenFlags.ReadWrite |
                SQLiteOpenFlags.Create |
                SQLiteOpenFlags.SharedCache);
            Connection.CreateTable<MarketPrice>();
            Connection.CreateTable<ActualPrice>();
            Connection.CreateTable<Value>();
        }

        public void Dispose()
        {
            if (Connection != null)
                Connection.Dispose();
        }

        public SQLiteConnection GetConnection() => Connection;
        
    }
}
