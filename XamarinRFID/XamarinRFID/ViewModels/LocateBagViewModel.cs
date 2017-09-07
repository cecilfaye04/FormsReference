using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XamarinRFID;

namespace XamarinRFID
{
    public class LocateBagViewModel : MvxViewModel/*, INotifyPropertyChanged*/
    {
        //private readonly ILocationService _service;
        Location x = new Location();

         public event PropertyChangedEventHandler PropertyChangedd;

        //private ObservableCollection<ILocation> _location = new ObservableCollection<ILocation>();
        //public ObservableCollection<ILocation> Locations
        //{
        //    get {
        //        return _location; }
        //    set
        //    {
        //        _location = value;

        //        if (PropertyChangedd != null)
        //        {
        //            //PropertyChanged(() => Locations);
        //            Mvx.Resolve<IMvxMainThreadDispatcher>()
        //  .RequestMainThreadAction(() => PropertyChangedd(this, new PropertyChangedEventArgs("Locations")));

        //            //RaisePropertyChanged(() => Locations);

        //        }
        //    }
        //}


        //public LocateBagViewModel()
        //{
        //}
        //public LocateBagViewModel(ILocationService service)
        //{
        //    _service = service;
        //}

        //private void NotifyPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        private string _searchEntry;
        public string SearchEntry
        {
            get { return _searchEntry; }
            set
            {
                _searchEntry = value;
                //RaisePropertyChanged(() => SearchEntry);
                Mvx.Resolve<IMvxMainThreadDispatcher>()
         .RequestMainThreadAction(() => RaisePropertyChanged(() => SearchEntry));
            }
        }

        private Location _baglocation;
        public Location BagLocation
        {
            get  {
                return 
                    _baglocation; }
            set
            {
                _baglocation = value;

                RaisePropertyChanged(() => BagLocation);

            }
        }

        //private MyMap _customMap;
        //public MyMap customMap
        //{
        //    get { return _customMap; }
        //    set
        //    {
        //        _customMap = value;
        //        RaisePropertyChanged(() => customMap);
        //        customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(14.654520, 121.052374),
        //                                 Distance.FromMiles(0.5)));
        //    }
        //}


        public ICommand ShowBagLocationCommand
        {
            get
            {
                return new MvxCommand(() =>
                {

                    //x = await _service.SearchBagtag("123");

                   
                   //Locations.Add(new Locations { Latitude = 14.614520, Longitude = 121.052374 });
                    Location x = new Location() { Latitude = 123, Longitude = 3 };
                   
                    InvokeOnMainThread(() => BagLocation = x);
                    //NotifyPropertyChanged("Price");
                    //BagLocation = x;
                    //_service.Locationasd(x);
                    //LocateBagPage xx = new LocateBagPage();
                    //OnFabClickDone();
                    //y.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(14.614520, 121.052374),
                    //                      Distance.FromMiles(0.5)));
                });
            }
        }

   
        //public delegate void FabClickDoneEvent(object sender, EventArgs args);
        //public event FabClickDoneEvent FabClickDone;

        //protected virtual void OnFabClickDone()
        //{
        //    FabClickDone?.Invoke(this, EventArgs.Empty);
        //}
        //public MvxCommand ClickMoto
        //{
        //    get;
        //}

    }
}
