using Akavache;
using Android.App;
using Android.OS;
using Android.Preferences;
using Lager.Android;

namespace AndroidTest
{
    [Activity(Label = "My Activity")]
    public class SettingsActivity : PreferenceActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.AddPreferencesFromResource(Resource.Layout.Settings);

            BlobCache.ApplicationName = "Settings Test App";

            var storage = new TestSettings();

            var textPreference = this.FindPreference("pref_text");
            textPreference.BindSetting(storage, x => x.Text, x => x.ToString());

            var boolPreference = this.FindPreference("pref_bool");
            boolPreference.BindSetting(storage, x => x.Boolean, x => bool.Parse((string)x));
        }
    }
}