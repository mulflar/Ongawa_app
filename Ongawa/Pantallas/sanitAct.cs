
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Ongawa.Clases;
using System;

namespace Ongawa.Pantallas
{
    [Activity(Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]
    public class sanitAct : Activity
    {
        ImageButton losa_m;
        ImageButton losa_c;
        ImageButton losa_h;
        ImageButton losa_p;

        ImageButton cierre_cem;
        ImageButton cierre_can;
        ImageButton cierre_mad;
        ImageButton cierra_lad;


        encuesta_raw datos;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Sanitario);
            datos = JsonConvert.DeserializeObject<encuesta_raw>(Intent.GetStringExtra("encuesta"));

            losa_m = FindViewById<ImageButton>(Resource.Id.losa_madera);
            losa_m.Click += losa_m_OnClick;

            losa_c = FindViewById<ImageButton>(Resource.Id.losa_ceramica);
            losa_c.Click += losa_c_OnClick;

            losa_h = FindViewById<ImageButton>(Resource.Id.losa_hormigon);
            losa_h.Click += losa_h_OnClick;

            losa_p = FindViewById<ImageButton>(Resource.Id.losa_piedra);
            losa_p.Click += losa_p_OnClick;

            cierre_cem = FindViewById<ImageButton>(Resource.Id.cierre_cemento);
            cierre_cem.Click += cierre_cem_OnClick;

            cierre_can = FindViewById<ImageButton>(Resource.Id.cierre_candado);
            cierre_can.Click += cierre_can_OnClick;

            cierre_mad = FindViewById<ImageButton>(Resource.Id.cierre_madera);
            cierre_mad.Click += cierre_mad_OnClick;

            cierra_lad = FindViewById<ImageButton>(Resource.Id.cierre_ladrillo);
            cierra_lad.Click += cierra_lad_OnClick;
        }
        #region cierres
        void cierre_cem_OnClick(object sender, EventArgs eventArgs)
        {
            datos.cie = 1;
            cierre_cem.SetColorFilter(Color.Argb(255, 255, 255, 255));
            cierre_can.ClearColorFilter();
            cierre_mad.ClearColorFilter();
            cierra_lad.ClearColorFilter();
        }
        void cierre_can_OnClick(object sender, EventArgs eventArgs)
        {
            datos.cie = 4;
            cierre_cem.ClearColorFilter();
            cierre_can.SetColorFilter(Color.Argb(255, 255, 255, 255));
            cierre_mad.ClearColorFilter();
            cierra_lad.ClearColorFilter();
        }
        void cierre_mad_OnClick(object sender, EventArgs eventArgs)
        {
            datos.cie = 3;
            cierre_cem.ClearColorFilter();
            cierre_can.ClearColorFilter();
            cierre_mad.SetColorFilter(Color.Argb(255, 255, 255, 255));
            cierra_lad.ClearColorFilter();
        }
        void cierra_lad_OnClick(object sender, EventArgs eventArgs)
        {
            datos.cie = 2;
            cierre_cem.ClearColorFilter();
            cierre_can.ClearColorFilter();
            cierre_mad.ClearColorFilter();
            cierra_lad.SetColorFilter(Color.Argb(255, 255, 255, 255));
        }
        #endregion
        #region losas
        void losa_m_OnClick(object sender, EventArgs eventArgs)
        {
            datos.mat = 1;
            losa_m.SetColorFilter(Color.Argb(255, 255, 255, 255));
            losa_c.ClearColorFilter();
            losa_h.ClearColorFilter();
            losa_p.ClearColorFilter();
        }
        void losa_c_OnClick(object sender, EventArgs eventArgs)
        {
            datos.mat = 2;
            losa_m.ClearColorFilter();
            losa_c.SetColorFilter(Color.Argb(255, 255, 255, 255));
            losa_h.ClearColorFilter();
            losa_p.ClearColorFilter();
        }
        void losa_h_OnClick(object sender, EventArgs eventArgs)
        {
            datos.mat = 3;
            losa_m.ClearColorFilter();
            losa_c.ClearColorFilter();
            losa_h.SetColorFilter(Color.Argb(255, 255, 255, 255));
            losa_p.ClearColorFilter();
        }
        void losa_p_OnClick(object sender, EventArgs eventArgs)
        {
            datos.mat = 4;
            losa_m.ClearColorFilter();
            losa_c.ClearColorFilter();
            losa_h.ClearColorFilter();
            losa_p.SetColorFilter(Color.Argb(255, 255, 255, 255));
        }
        #endregion
        [Java.Interop.Export("atras")]
        public void atras(View view)
        {
            StartActivity(typeof(introAct));
            Finish();
        }
        [Java.Interop.Export("siguiente")]
        public void siguiente(View view)
        {
            if (FindViewById<ToggleButton>(Resource.Id.toggleAgua).Checked)
                datos.agu = 0;
            else
                datos.agu = 1;
            if (FindViewById<ToggleButton>(Resource.Id.toggleMosc).Checked)
                datos.mos = 0;
            else
                datos.mos = 1;
            if (FindViewById<ToggleButton>(Resource.Id.toggleOlor).Checked)
                datos.mos = 0;
            else
                datos.mos = 1;
            if (FindViewById<ToggleButton>(Resource.Id.toggleOlor).Checked)
                datos.olo = 0;
            else
                datos.olo = 1;
            if (FindViewById<ToggleButton>(Resource.Id.togglePriv).Checked)
                datos.pri = 0;
            else
                datos.pri = 1;
            if (FindViewById<ToggleButton>(Resource.Id.toggleVent).Checked)
                datos.ven = 0;
            else
                datos.ven = 1;
            var activity = new Intent(this, typeof(resumAct));
            activity.PutExtra("encuesta", JsonConvert.SerializeObject(datos));
            StartActivity(activity);
        }
    }
}