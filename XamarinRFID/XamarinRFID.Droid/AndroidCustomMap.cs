using Xamarin.Forms.Platform.Android;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using System.Threading.Tasks;
using Javax.Net.Ssl;
using Java.Net;
using System.IO;
using Newtonsoft.Json;
using Xamarin.Forms;
using XamarinRFID;
using XamarinRFID.Droid;
using Xamarin.Forms.Maps.Android;
using System;
using Xamarin.Forms.Maps;
using System.Collections.Generic;

[assembly: ExportRenderer(typeof(MyMap), typeof(AndroidCustomMap))]
namespace XamarinRFID.Droid
{
    public class AndroidCustomMap : MapRenderer, IOnMapReadyCallback
    {
        private MyMap _xamarinMap;
        private GoogleMap _googleMap;

        //protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
        //{
        //    base.OnElementChanged(e);

        //    if (e.OldElement != null)
        //    {
        //        // Unsubscribe
        //    }

        //    if (e.NewElement != null)
        //    {
        //        var formsMap = (MyMap)e.NewElement;
        //        routeCoordinates = formsMap.RouteCoordinates;

        //        ((MapView)Control).GetMapAsync(this);
        //    }
        //}

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
                _xamarinMap = e.NewElement as MyMap;
            ((MapView)Control).GetMapAsync(this);
        }

        public  virtual void OnMapReady(GoogleMap googleMap)
        {
            _googleMap = googleMap;

            //_googleMap.CameraChange += _googleMap_CameraChange;
            _googleMap.CameraChange += _googleMap_CameraChange;
            //map = googleMap;
            //    var polylineOptions = new PolylineOptions();
            //    polylineOptions.InvokeColor(0x66FF0000);
            //    var a = new LatLng(14.657299, 121.057196);
            //    var b = new LatLng(14.653410, 121.048007);
            //    await GetRouteInfo(a, b);
        }

       

        private async void _googleMap_CameraChange(object sender, GoogleMap.CameraChangeEventArgs e)
        {
            // This
            //if (_xamarinMap.OnSearchLocation != null)
            //    _xamarinMap.OnSearchLocation();

            MarkerOptions markerOpt1 = new MarkerOptions();
            markerOpt1.SetPosition(new LatLng(14.652641438532108, 121.0489296913147));
            markerOpt1.SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueRed));
            markerOpt1.SetTitle("Bag Location");
            _googleMap.AddMarker(markerOpt1);

            MarkerOptions markerOpt2 = new MarkerOptions();
            markerOpt2.SetPosition(new LatLng(14.657374623605888, 121.05620384216309));
            markerOpt2.SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueBlue));
            markerOpt2.SetTitle("Current Location");
            _googleMap.AddMarker(markerOpt2);

            MarkerOptions markerOpt3 = new MarkerOptions();
            markerOpt3.SetPosition(new LatLng(35.652832, 139.839478));
            markerOpt3.SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueRed));
            markerOpt3.SetTitle("Bag Location");
            _googleMap.AddMarker(markerOpt3);

            var a = new LatLng(14.652641438532108, 121.0489296913147);
            var b = new LatLng(14.657374623605888, 121.05620384216309);
             await GetRouteInfo(a, b);

            // or this
            //MessagingCenter.Send<object>(this, "RegionChanged");
        }




        public async Task GetRouteInfo(LatLng origin, LatLng destination)
        {
            string response = string.Empty;
            await Task.Run(() =>
            {
                URL url = new URL(string.Format("https://maps.googleapis.com/maps/api/directions/json?" +
                    "origin={0},{1}&destination={2},{3}&mode=walking&key={4}",
                    origin.Latitude, origin.Longitude, destination.Latitude, destination.Longitude,
                    "AIzaSyCgx1MivNMRG1zVWd93Uu0XwysGsmAlxt8"));

                HttpsURLConnection urlConnection = (HttpsURLConnection)url.OpenConnection();
                urlConnection.Connect();
                var stream = urlConnection.InputStream;

                using (var streamReader = new StreamReader(stream))
                {
                    response = streamReader.ReadToEnd();
                }
                return response;
            });

            PolylineOptions polylines = GetPolylines(response);
            polylines.InvokeColor(-65536);
            polylines.InvokeWidth(5);
            _googleMap.AddPolyline(polylines);
        }

        public PolylineOptions GetPolylines(string routeInfo)
        {

            var routeObject = JsonConvert.DeserializeObject<Rootobject>(routeInfo);

            List<LatLng> coordinatesList = DecodeEncodedPolyline(routeObject.routes[0].overview_polyline.points);

            var distance = routeObject.routes[0].legs[0].distance.text;
            var duration = routeObject.routes[0].legs[0].duration.text;

           

            PolylineOptions polylines = new PolylineOptions();

            foreach (var lines in coordinatesList)
            {
                polylines.Add(lines);
            };
            return polylines;
        }

        //from internet ^-^
        public static List<LatLng> DecodeEncodedPolyline(string encodedPath)
        {
            int len = encodedPath.Length;
            List<LatLng> path = new List<LatLng>();
            int index = 0;
            int lat = 0;
            int lng = 0;

            while (index < len)
            {
                int result = 1;
                int shift = 0;
                int b;
                do
                {
                    b = encodedPath[index++] - 63 - 1;
                    result += b << shift;
                    shift += 5;
                } while (b >= 0x1f);
                lat += (result & 1) != 0 ? ~(result >> 1) : (result >> 1);

                result = 1;
                shift = 0;
                do
                {
                    b = encodedPath[index++] - 63 - 1;
                    result += b << shift;
                    shift += 5;

                } while (b >= 0x1f);
                lng += (result & 1) != 0 ? ~(result >> 1) : (result >> 1);

                path.Add(new LatLng(lat * 1e-5, lng * 1e-5));
            }
            return path;


        }
    }
}