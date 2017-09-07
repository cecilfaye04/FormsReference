using SQLite;
using MvvmCross.Plugins.Sqlite;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace XamarinRFID
{
    public class DataService : IDataService
    {
        public async Task<UserModel> LoadUserAsync()
        {
           return await CoreApp.Connection.Table<UserModel>().FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(UserModel i)
        {
            await CoreApp.Connection.InsertOrReplaceAsync(i);
        }

     

    }
}
