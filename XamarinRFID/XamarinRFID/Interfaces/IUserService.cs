using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinRFID
{
    public interface IUserService
    {
        Task<bool> ValidateLogin(string username, string password);
    }
}
