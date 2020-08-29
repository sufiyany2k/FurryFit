using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FurryFit.Database
{
    public class FurryFitDB
    {

        readonly SQLiteAsyncConnection _database;

        public FurryFitDB(string dbPath)
        {
            _database = new SQLiteAsyncConnection(App.dbPath);
            
        }

        public SQLiteAsyncConnection SqLiteAsyncConnection {
            get { return _database; }
        }
        
    }
}
