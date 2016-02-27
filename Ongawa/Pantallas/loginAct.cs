using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using Ongawa.Servicios;

namespace Ongawa.Pantallas
{
    [Activity(MainLauncher = true, Icon = "@drawable/icon", NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class loginAct : Activity
    {
        Persistencia storer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            storer = new Persistencia(this);
            if(storer.checkKey())
            {
                StartActivity(typeof(introAct));
                Finish();
            }
            else
                SetContentView(Resource.Layout.Login);
        }
        /// <summary>
		/// Logins the click.
		/// </summary>
		/// <param name="view">View.</param>
		[Java.Interop.Export("loginClick")]
        public void loginClick(View view)
        {
            WebReference.encuesta webservice = new WebReference.encuesta();
            string user = FindViewById<EditText>(Resource.Id.usrBox).Text;
            string password = FindViewById<EditText>(Resource.Id.passBox).Text;
            if (user != "" && password != "")
            {
                int id = webservice.comprobaruser(user, password, "jkdgnnjbgjk34564534");
                if(id>0)
                {
                    storer.storeKey("1");
                    StartActivity(typeof(introAct));
                    Finish();
                }
                else
                {
                    //usuario erroneo
                    AlertDialog.Builder dialog = Auxiliar.AlertBox(GetString(Resource.String.errorWrongUser), this);
                    dialog.Show();
                }
            }
            else {
                //campo vacio
                AlertDialog.Builder dialog = Auxiliar.AlertBox(GetString(Resource.String.errorEmptyForm), this);
                dialog.Show();
            }
        }
    }
}