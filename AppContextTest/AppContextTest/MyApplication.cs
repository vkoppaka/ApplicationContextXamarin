using System;
using Android.App;
using Android.Content;
using Android.Runtime;

namespace AppContextTest
{
    [Application]
    public class MyApplication : Application
    {
        private static Context context;

        public MyApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            context = ApplicationContext;
        }

        public static Context GetApplicationContext()
        {
            return context;
        }
    }
}