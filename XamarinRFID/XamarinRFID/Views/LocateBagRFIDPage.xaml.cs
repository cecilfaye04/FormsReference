using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace XamarinRFID
{
    public partial class LocateBagRFIDPage : ContentPage
    {
        public LocateBagRFIDPage()
        {
            

            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
         
        }
        //public void Clicked(object sender, EventArgs e)
        //{
        //    bagList.IsVisible = true;
        //}

        //public void OnMore(object sender, EventArgs e)
        //{
        //    MyLocationMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(35.652832, 139.839478),
        //                                Distance.FromMiles(0.5)));
        //    bagtagEntry.Text = "123-456-78";
        //}
    }
}
