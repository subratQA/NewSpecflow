using log4net;
using Specflow.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.ComponentHelper
{
    public class BrowserHelper
    {
       private static readonly ILog logs = LoggerHelper.GetLogger(typeof(ButtonHelper));
        public static void MaximizeBrowser()
        {
            ObjectRepository.driver.Manage().Window.Maximize();
            logs.Info("Browser Maximized");
        }
        public static void MoveForward()
        {
            ObjectRepository.driver.Navigate().Forward();
            logs.Info("Selected Move forward");
        }
        public static void MoveBack()
        {
            ObjectRepository.driver.Navigate().Back();
            logs.Info("Selected Move backward");
        }
    }
}
