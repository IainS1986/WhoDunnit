using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Prism.DryIoc;
using DryIoc;
using Android.Graphics.Drawables;
using Android.Graphics;
using NControl.Droid;
using NControl.Controls.Droid;
using Prism;
using Prism.Ioc;
using WhoDunnit.Views;

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
            LoadApplication(new App(new AndroidInitializer()));

            if (ActionBar != null)
                ActionBar.SetIcon(new ColorDrawable(Color.Transparent));
        }

        public class AndroidInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IContainerRegistry containerRegistry)
            {
            }
        }
    }
}

