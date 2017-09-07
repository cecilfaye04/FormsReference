using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinRFID
{
    public class UserService : IUserService
    {
      
        public Task asd()
        {
            return Task.Delay(0);
        }

      async Task<bool> IUserService.ValidateLogin(string username, string password)
        {
            await asd();

            if (username == "admin" && password == "password")
            {
                return true;
            }
            else { return false; }
        }
    }
}
