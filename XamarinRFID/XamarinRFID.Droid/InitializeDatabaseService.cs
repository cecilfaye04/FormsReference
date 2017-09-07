using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using SQLitePCL;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

namespace XamarinRFID.Droid
{
    public class InitializeDatabaseService : IInitializeService
    {
        public async Task InitializeAsync()
        {
            var _db = new ItemDatabase(GetConnection);
            if (!DatabaseExists())
                await _db.InitializeAsync();
            CoreApp.Connection = _db;
        }

        private static bool DatabaseExists()
        {
            return File.Exists(GetDatabasePath());
        }

        private static string GetDatabasePath()
        {
            return System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "RFID.db3");
        }

        private static SQLiteConnectionWithLock GetConnection()
        {
            return new SQLiteConnectionWithLock(new SQLitePlatformAndroid(), new SQLiteConnectionString(GetDatabasePath(), false));
        }

      
    }
}