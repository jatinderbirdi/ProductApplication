using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace App2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Spinner spinnerOfProduct;
        double[] rateOfProduct = { 25,88,40,63,20 };
        EditText etprice;
        TextView tot;
        Button addProduct;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            tot = (TextView)FindViewById(Resource.Id.total);
            SetContentView(Resource.Layout.activity_main);
            // Declaring the edittext and spinner in the file
            addProduct = (Button)FindViewById(Resource.Id.add);
            etprice = (EditText)FindViewById(Resource.Id.value);
            spinnerOfProduct = (Spinner)FindViewById(Resource.Id.spinnerOfProducts);
            var carAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.product_array, Android.Resource.Layout.SimpleSpinnerItem);

            //Creating the adapter for spinner
            spinnerOfProduct.Adapter = carAdapter;
            spinnerOfProduct.ItemSelected += delegate
            {
                string msg = "The product which is selected is " + spinnerOfProduct.SelectedItem.ToString();
                Toast.MakeText(this, msg, ToastLength.Long).Show();
                etprice.Text = rateOfProduct[spinnerOfProduct.SelectedItemId].ToString();
            };
            var i = 0;
            addProduct.Click += delegate
            {
                i += Convert.ToInt32(etprice.Text);
                tot.Text = Convert.ToString(i);
            };

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

