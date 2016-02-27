using Android.Content;
using Android.Preferences;
using Newtonsoft.Json;
using Ongawa.Clases;
using System.Collections.Generic;

namespace Ongawa.Servicios
{
    class Persistencia
    {
        ISharedPreferences prefs;
        ISharedPreferencesEditor editor;

        public Persistencia(Context cont)
        {
            prefs = PreferenceManager.GetDefaultSharedPreferences(cont);
            editor = prefs.Edit();
        }

        public void store(encuesta_raw datos)
        {
            string raw = prefs.GetString("datos", null);
            List<encuesta_raw> lista;
            if (raw != null)
            {
                lista = JsonConvert.DeserializeObject<List<encuesta_raw>>(raw);
                lista.Add(datos);
            }
            else
            {
                lista = new List<encuesta_raw>();
                lista.Add(datos);
            }
            string raw2 = JsonConvert.SerializeObject(lista);
            editor.PutString("datos", raw2);
            editor.Commit();
        }

        public List<encuesta_raw> recover()
        {
            string raw = prefs.GetString("datos", null);
            List<encuesta_raw> lista;
            if (raw == null)
                lista = new List<encuesta_raw>();
            else
                lista = JsonConvert.DeserializeObject<List<encuesta_raw>>(raw);
            return lista;
        }
        public void storeKey(string key)
        {
            editor.PutString("login", key);
            editor.Commit();
        }
        public bool checkKey()
        {
            string raw = prefs.GetString("login", null);
            if (raw == null)
                return false;
            else
                return true;
        }
        public void clearKey()
        {
            editor.PutString("login", null);
            editor.Commit();
        }
    }
}