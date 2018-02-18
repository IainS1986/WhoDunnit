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
    [Activity(
        Theme = "@style/Theme.Splash",
        MainLauncher = true,
        NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.StartActivity(typeof(MainActivity));
        }
    }
}

