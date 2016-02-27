
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Newtonsoft.Json;
using Ongawa.Clases;
using Ongawa.Servicios;

namespace Ongawa.Pantallas
{
    [Activity(Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]
    public class resumAct : Activity
    {
        encuesta_raw datos;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Resumen);
            datos = JsonConvert.DeserializeObject<encuesta_raw>(Intent.GetStringExtra("encuesta"));
            FindViewById<TextView>(Resource.Id.refText).Text = datos.fam;
            FindViewById<TextView>(Resource.Id.locationtext).Text = datos.direccion;
            if (datos.agu == 1)
                FindViewById<TextView>(Resource.Id.agu).Text = "SI";
            else
                FindViewById<TextView>(Resource.Id.agu).Text = "NO";

            if (datos.ven == 1)
                FindViewById<TextView>(Resource.Id.vent).Text = "SI";
            else
                FindViewById<TextView>(Resource.Id.vent).Text = "NO";

            if (datos.mos == 1)
                FindViewById<TextView>(Resource.Id.mos).Text = "SI";
            else
                FindViewById<TextView>(Resource.Id.mos).Text = "NO";

            if (datos.olo == 1)
                FindViewById<TextView>(Resource.Id.olo).Text = "SI";
            else
                FindViewById<TextView>(Resource.Id.olo).Text = "NO";

            if (datos.pri == 1)
                FindViewById<TextView>(Resource.Id.pri).Text = "SI";
            else
                FindViewById<TextView>(Resource.Id.pri).Text = "NO";

            switch (datos.mat)
            {
                case 1:
                    FindViewById<ImageView>(Resource.Id.imageLosa).SetImageResource(Resource.Drawable.madera);
                    break;
                case 2:
                    FindViewById<ImageView>(Resource.Id.imageLosa).SetImageResource(Resource.Drawable.ceramica1);
                    break;
                case 3:
                    FindViewById<ImageView>(Resource.Id.imageLosa).SetImageResource(Resource.Drawable.hormigon);
                    break;
                case 4:
                    FindViewById<ImageView>(Resource.Id.imageLosa).SetImageResource(Resource.Drawable.piedra);
                    break;
            }

            switch (datos.cie)
            {
                case 1:
                    FindViewById<ImageView>(Resource.Id.imageCierre).SetImageResource(Resource.Drawable.cemento);
                    break;
                case 2:
                    FindViewById<ImageView>(Resource.Id.imageCierre).SetImageResource(Resource.Drawable.ladrillo);
                    break;
                case 3:
                    FindViewById<ImageView>(Resource.Id.imageCierre).SetImageResource(Resource.Drawable.madera);
                    break;
                case 4:
                    FindViewById<ImageView>(Resource.Id.imageCierre).SetImageResource(Resource.Drawable.candado);
                    break;
            }
        }
        [Java.Interop.Export("atras")]
        public void atras(View view)
        {
            var activity = new Intent(this, typeof(sanitAct));
            activity.PutExtra("encuesta", JsonConvert.SerializeObject(datos));
            StartActivity(activity);
        }
        [Java.Interop.Export("aceptar")]
        public void aceptar(View view)
        {
            new Thread(() =>
            {
                WebReference.encuesta webservice = new WebReference.encuesta();
                webservice.insertreg(JsonConvert.SerializeObject(datos), "jkdgnnjbgjk34564534");
            }).Start();
           
            Persistencia storer = new Persistencia(this);
            storer.store(datos);
            StartActivity(typeof(introAct));
            Finish();
        }
    }
}