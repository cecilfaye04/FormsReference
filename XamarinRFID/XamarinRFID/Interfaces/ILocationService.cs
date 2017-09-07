using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace XamarinRFID
{
    public interface ILocationService
    {
        Task<Location> SearchBagtag(string bagtagno);

        void Locationasd(Location location);
      
    }
}
