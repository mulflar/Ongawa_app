using Android.App;
using Android.Content;

namespace Ongawa.Servicios
{
    public static class Auxiliar
    {
        public static AlertDialog.Builder AlertBox(string errorMsg, Context context)
        {
            AlertDialog.Builder dialog = new AlertDialog.Builder(context);
            dialog.SetTitle("ERROR");
            dialog.SetMessage(errorMsg);
            dialog.SetNeutralButton("ACEPTAR", (s, EventArgs) => { });
            return dialog;
        }
    }
}