using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace XamarinRFID
{
    public class LocationService : ILocationService
    {
        public void Locationasd(Location location)
        {
           
        }

        public async Task<Location> SearchBagtag(string bagtagno)
        {
            await xy();
            return new Location() { Latitude = 14.654525, Longitude = 121.052374 };
        }
        public Task xy()
        {
            return Task.Delay(0);
        }
    }
}
