using Android.App;
using Android.Content.PM;
using Android.OS;

using LX;

namespace HelloWorld.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true,
        ConfigurationChanges = 
        ConfigChanges.Orientation | 
        ConfigChanges.KeyboardHidden | 
        ConfigChanges.ScreenSize)]
    public class MainActivity : AndroidActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            App.OnRun += () => new MainForm();
            base.OnCreate(savedInstanceState);
        }
    }
}