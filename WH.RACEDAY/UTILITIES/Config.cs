using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WH.RACEDAY
{
    public sealed class Config
    {
        public static string GetStringConfiguration(string parameter)
        {
            return ConfigurationManager.AppSettings[parameter].ToString();
        }

        public static string GetServiceBaseURL()
        {
            return GetStringConfiguration(SETTINGS.WEBSERVICEBASEURL);
        }
    }
}
