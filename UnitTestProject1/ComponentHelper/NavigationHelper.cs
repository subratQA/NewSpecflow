﻿using log4net;
using Specflow.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.ComponentHelper
{
    public class NavigationHelper
    {
        private static readonly ILog logs = LoggerHelper.GetLogger(typeof(NavigationHelper));
        public static void NavigateToURL(string url)
        {
            ObjectRepository.driver.Navigate().GoToUrl(url);
            logs.Info("Navigated to url : " + url);
        }
    }
}
