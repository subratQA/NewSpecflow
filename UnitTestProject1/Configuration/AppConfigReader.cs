using Specflow.Interfaces;
using Specflow.Settings;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Specflow.Configuration
{

    public class AppConfigReader : IConfig
    {
        public string getUrl()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Url);
        }
        public string getUserName()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.UserName);
        }

        public BrowserType GetBrowserType()
        {
            string browser = ConfigurationManager.AppSettings.Get(AppConfigKeys.BrowserType);
            return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
        }


        public string getPassword()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Password);
        }

        public int GetPageLoadTimeOut()
        {
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.PageLoadTimeOut);
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);
        }

        public int GetElementLoadTimeOut()
        {
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.ElementLoadTimeOut);
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);
        }
    }
}
