using System.Collections.ObjectModel;
using Xamarin.Forms.Maps;

namespace XamarinRFID
{
    public class MyMap : Map
    {
        //private readonly ObservableCollection<ILocation> _items = new ObservableCollection<ILocation>();

        public delegate void OnSearchLocationDelegate();

        public OnSearchLocationDelegate OnSearchLocation { get; set; }

        public Location MapLocation { get; set; }
    }
}
