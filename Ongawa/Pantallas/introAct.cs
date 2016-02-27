using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Locations;
using Android.OS;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Ongawa.Clases;
using Ongawa.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ongawa.Pantallas
{
    [Activity(Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]
    public class introAct : Activity, ILocationListener
    {
        Location _currentLocation;
        LocationManager _locationManager;
        string _locationProvider;
        TextView estadoLoc;
        TextView ubicacion;
        encuesta_raw datos;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Inicio);
            FindViewById<ImageButton>(Resource.Id.botGetLoc).Click += AddressButton_OnClick;
            estadoLoc = FindViewById<TextView>(Resource.Id.LocStatus);
            ubicacion = FindViewById<TextView>(Resource.Id.address);
            datos = new encuesta_raw();
            InitializeLocationManager();
        }

        void InitializeLocationManager()
        {
            _locationManager = (LocationManager)GetSystemService(LocationService);
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Fine,
                PowerRequirement = Power.High
            };
            IList<string> acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);

            if (acceptableLocationProviders.Any())
            {
                _locationProvider = acceptableLocationProviders.First();
                _locationManager.RequestLocationUpdates(_locationProvider, 0, 0, this);
            }
            else
            {
                _locationProvider = string.Empty;
                estadoLoc.Text = GetString(Resource.String.errorLoc);
            }
        }

        async void AddressButton_OnClick(object sender, EventArgs eventArgs)
        {
            if (_currentLocation == null)
            {
                estadoLoc.Text = GetString(Resource.String.awaitLoc);
                return;
            }
            Address address = await ReverseGeocodeCurrentLocation();
            estadoLoc.Text = address.CountryName + ", " + address.Locality + ", " + address.GetAddressLine(0);
            estadoLoc.Text = "Ubicado";
            ubicacion.Text = "Centro, Alicante, Alicante, España";
            ProgressBar prog = FindViewById<ProgressBar>(Resource.Id.progBar);
            prog.Visibility = ViewStates.Invisible;
        }
        async Task<Address> ReverseGeocodeCurrentLocation()
        {
            Geocoder geocoder = new Geocoder(this);
            IList<Address> addressList =
                await geocoder.GetFromLocationAsync(_currentLocation.Latitude, _currentLocation.Longitude, 10);

            Address address = addressList.FirstOrDefault();
            return address;
        }
        protected override void OnResume()
        {
            base.OnResume();
            _locationManager.RequestLocationUpdates(_locationProvider, 0, 0, this);
        }
        protected override void OnPause()
        {
            base.OnPause();
            _locationManager.RemoveUpdates(this);
        }
        public async void OnLocationChanged(Location location)
        {
            _currentLocation = location;
            if (_currentLocation == null)
            {
                estadoLoc.Text = GetString(Resource.String.awaitLoc);
            }
            else
            {
                Address address = await ReverseGeocodeCurrentLocation();
                estadoLoc.Text = address.CountryName + ", " + address.Locality + ", " + address.GetAddressLine(0);
                ProgressBar prog = FindViewById<ProgressBar>(Resource.Id.progBar);
                prog.Visibility = ViewStates.Invisible;
            }
        }
        public void OnProviderDisabled(string provider) { }
        public void OnProviderEnabled(string provider) { }
        public void OnStatusChanged(string provider, Availability status, Bundle extras) { }

        [Java.Interop.Export("nuevo")]
        public void nuevo(View view)
        {
            datos.direccion = ubicacion.Text;
            datos.lat = (long)_currentLocation.Latitude;
            datos.lon = (long)_currentLocation.Longitude;
            datos.fam = FindViewById<TextView>(Resource.Id.refFam).Text;
            var activity = new Intent(this, typeof(sanitAct));
            activity.PutExtra("encuesta", JsonConvert.SerializeObject(datos));
            StartActivity(activity);
        }
        [Java.Interop.Export("logout")]
        public void logout(View view)
        {
            Persistencia storer = new Persistencia(this);
            storer.clearKey();
            StartActivity(typeof(loginAct));
            Finish();
        }
    }
}