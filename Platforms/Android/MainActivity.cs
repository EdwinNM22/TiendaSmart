﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views; 

namespace TiendaSmart
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Cambiar el color de la barra de estado
            Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#00796B")); // Ajusta el color según tu navbar
        }
    }
}
