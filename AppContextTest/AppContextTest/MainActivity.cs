﻿using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace AppContextTest
{
    [Activity(Label = "AppContextTest", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : BaseActivity
    {

        protected override int LayoutResource
        {
            get { return Resource.Layout.main; }
        }
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Get our button from the layout resource,
            // and attach an event to it
            var clickButton = FindViewById<Button>(Resource.Id.my_button);

            clickButton.Click += (sender, args) =>
              {
                  clickButton.Text = string.Format("{0} clicks!", count++);
              };

            var navigationButton = FindViewById<Button>(Resource.Id.nav_button);

            navigationButton.Click += (sender, args) =>
              {
                  var intent = new Intent(this, typeof(SecondActivity));
                  intent.PutExtra("clicks", count);
                  StartActivity(intent);
              };

            var customStringAndroidWay = MyApplication.GetApplicationContext().GetString(Resource.String.HelloCustom);
            var customStringXamarinWay = Android.App.Application.Context.GetString(Resource.String.HelloCustom);
            
            clickButton.Text = customStringAndroidWay;

            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(false);

        }
    }
}

