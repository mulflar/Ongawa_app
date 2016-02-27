using Android.App;
using Android.Views;
using Android.Widget;
using Ongawa.Clases;
using System.Collections.Generic;

namespace Ongawa.Adapters
{
    class ItemsAdapter : BaseAdapter<encuesta_raw>
    {
        readonly List<encuesta_raw> listado;
        readonly Activity context;
        /// <summary>
        /// Initializes a new instance of the <see cref="InformaticaRos.VisitasAdapter"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        /// <param name="items">Items.</param>
        public ItemsAdapter(Activity context, List<encuesta_raw> items)
			: base()
		{
            this.context = context;
            this.listado = items;
        }
        /// <param name="position">The position of the item within the adapter's data set whose row id we want.</param>
        /// <summary>
        /// Get the row id associated with the specified position in the list.
        /// </summary>
        /// <returns>To be added.</returns>
        public override long GetItemId(int position)
        {
            return position;
        }
        /// <summary>
        /// Gets the <see cref="InformaticaRos.VisitasAdapter"/> at the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        public override encuesta_raw this[int index]
        {
            get { return listado[index]; }
        }
        /// <summary>
        /// How many items are in the data set represented by this Adapter.
        /// </summary>
        /// <value>To be added.</value>
        public override int Count
        {
            get { return listado.Count; }
        }
        /// <param name="position">The position of the item within the adapter's data set of the item whose view
        ///  we want.</param>
        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <returns>The view.</returns>
        /// <param name="convertView">Convert view.</param>
        /// <param name="parent">Parent.</param>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = listado[position];
            View view = convertView;
            /*if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.filaListados, null);
            view.FindViewById<TextView>(Resource.Id.).Text = item.fecha.ToString();
            view.FindViewById<TextView>(Resource.Id.cantBox).Text = item.fam.ToString();
            view.FindViewById<TextView>(Resource.Id.cantBox).Text = item.direccion.ToString();*/
            return view;
        }
    }
}
