using Cirrious.CrossCore;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace XamarinRFID
{
    public partial class LocateBagPage : ContentPage,INotifyPropertyChanged
    {

        public LocateBagViewModel ViewModel
        {
            get { return BindingContext as LocateBagViewModel; }
        }


        public LocateBagPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new LocateBagViewModel(); ;
            InitializeComponent();
            //ViewModel.Locations.CollectionChanged += UpdatePins;
            //((LocateBagViewModel)this.ViewModel).PropertyChanged += new PropertyChangedEventHandler(EventHandlerFoo);

            //IMvxNotifyPropertyChanged viewModel = ViewModel as IMvxNotifyPropertyChanged;
            //viewModel.WeakSubscribe(UpdatePins);
            //ViewModel.Locations.CollectionChanged += UpdatePins;


            //ViewModel.PropertyChanged += (sender, args) =>
            //{
            //    if (args.PropertyName == "Locations")
            //    {
            //        MyLocationMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(162.052374, 121.052374),
            //                                  Distance.FromMiles(0.5)));
            //    }
            //};


            //ViewModel.PropertyChanged += (sender, args) =>
            //{
            //    if (args.PropertyName == "SearchEntry")
            //    {
            //        MyLocationMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(162.052374, 121.052374),
            //                                  Distance.FromMiles(0.5)));
            //    }
            //};


            //       new MvxPropertyChangedListener(ViewModel).Listen<ObservableCollection<ILocation>>(
            //() => ViewModel.Locations,
            //() =>
            //{
            //    MyLocationMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(162.052374, 121.052374),
            //                                  Distance.FromMiles(0.5)));
            //});


            //           new MvxPropertyChangedListener(ViewModel).Listen<string>(
            //() => ViewModel.SearchEntry,
            //() =>
            //{
            //    MyLocationMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(162.052374, 121.052374),
            //                                  Distance.FromMiles(0.5)));
            //});


            //MyLocationMap.OnSearchLocation += Change;
            //model.ShowBagLocationCommand += Clickeda;

            btnLocate.Clicked += Clickeda;


        }

     

        private void EventHandlerFoo(object sender, EventArgs e)
        {
            PropertyChangedEventArgs eventArgs = (PropertyChangedEventArgs)e;
            if (eventArgs.PropertyName == "Locations")
            {

                MyLocationMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(14.654525, 121.052374),
                                                   Distance.FromMiles(0.5)));
            }

            else if (eventArgs.PropertyName == "SearchEntry")
            {

                MyLocationMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(14.654525, 121.052374),
                                                   Distance.FromMiles(0.5)));
            }
        }


        private void UpdatePins(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           MyLocationMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(14.654525, 121.052374),
                                              Distance.FromMiles(0.5)));
        }

        public void Clickeda(object sender, EventArgs e)
        {
            MyLocationMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(14.654525, 121.052374),
                                          Distance.FromMiles(0.5)));
        }

    }
}
