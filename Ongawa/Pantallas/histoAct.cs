using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ongawa.Clases;
using Ongawa.Servicios;

namespace Ongawa.Pantallas
{
    [Activity(Label = "histoAct")]
    public class histoAct : Activity
    {
        List<encuesta_raw> datos;
        ListView lista;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Historico);
            Persistencia servicio = new Persistencia(this);
            datos = servicio.recover();
            if (datos.Count == 0)
            {
                AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                dialog.SetTitle("ERROR");
                dialog.SetMessage("No hay datos almacenados");
                dialog.SetNeutralButton("ACEPTAR", (s, EventArgs) => { Finish(); });
                dialog.Show();
            }
            else
            {
                lista = FindViewById<ListView>(Resource.Id.listHist);
                lista.ItemClick += OnListItemClick;
                //lista.Adapter = new ItemsAdapterList(this, datos);
            }
        }
        void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var activity = new Intent(this, typeof(resumAct));
            //activity.PutExtra("lista", datos[e.Position].getList());
            StartActivity(activity);
        }
    }
}