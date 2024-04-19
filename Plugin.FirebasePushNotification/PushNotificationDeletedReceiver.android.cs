using System.Collections.Generic;
using Android.Content;

namespace Plugin.FirebasePushNotification
{
    [BroadcastReceiver(Enabled = true, Exported = false)]
    public class PushNotificationDeletedReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            var extras = intent.Extras;

            if (extras != null && !extras.IsEmpty)
            {
                foreach (var key in extras.KeySet())
                {
                    parameters.Add(key, extras.GetString(key));
                    System.Diagnostics.Debug.WriteLine(key, extras.GetString(key));
                }
            }

            FirebasePushNotificationManager.RegisterDelete(parameters);
        }
    }
}
