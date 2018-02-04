using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using NControl.Droid;
using NControl.Controls.Droid;
using Prism;
using System.ComponentModel;

namespace WhoDunnit.Droid
{
    [Activity(Label = "WhoDunnit", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            NControlViewRenderer.Init();
            NControls.Init();
            LoadApplication(new App());
        }
    }
}

