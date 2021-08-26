namespace Wicresoft.WFH.Core
{
    using System.Configuration;

    public static class AppSettingsHelper
    {
        public static T GetAppSetting<T>(string key, T defaultValue)
        {
            var text = ConfigurationManager.AppSettings[key];

            T result;
            if (text == null)
            {
                result = defaultValue;
            }
            else
            {
                result = (T)System.Convert.ChangeType(text, typeof(T));
            }

            return result;
        }
    }
}
