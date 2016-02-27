using Android.Locations;
using Newtonsoft.Json;
using System;

namespace Ongawa.Clases
{
    public class encuesta_raw
    {
        public DateTime fecha;
        public string direccion;
        public long lat;
        public long lon;
        public string fam;
        public int ven;
        public int pri;
        public int cie;
        public int mos;
        public int olo;
        public int agu;
        public int mat;


        public encuesta_raw()
        {
            fecha = DateTime.Now;
        }
    }
}