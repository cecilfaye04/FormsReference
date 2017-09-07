using System.Collections.Generic;
using System.Threading.Tasks;

namespace XamarinRFID
{
    public interface IDataService
    {
        Task UpdateAsync(UserModel i);
        Task<UserModel> LoadUserAsync();
    }
}
