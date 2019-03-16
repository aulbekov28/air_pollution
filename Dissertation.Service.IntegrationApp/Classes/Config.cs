using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dissertation.Service.IntegrationApp.Classes
{
    internal static class Config
    {
        private static Logger _logger;

        private static Logger Logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = LogManager.GetCurrentClassLogger();
                }
                return _logger;
            }
        }

        private static int? _interval;


        public static int Interval
        {
            get
            {
                #region LogicInterval
                var intrv = ConfigurationManager.AppSettings["LogicInterval"];
                if (!string.IsNullOrEmpty(intrv) && int.TryParse(intrv, out int resInt))
                {
                    _interval = resInt;
                }
                else
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    _interval = 1000 * 60 * 5;
                    config.EditAppSetting("LogicInterval", _interval.ToString());
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
#if DEBUG
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    _interval = 10_500;
                }
#endif

                #endregion
                return _interval.Value;
            }
        }


        internal static void EditAppSetting(this Configuration config, string key, string value)
        {

            if (config.AppSettings.Settings.AllKeys.Contains(key))
            {
                config.AppSettings.Settings[key].Value = value;
            }
            else
            {
                config.AppSettings.Settings.Add(new KeyValueConfigurationElement(key, value));
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

    }
}
