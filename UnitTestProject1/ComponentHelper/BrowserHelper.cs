using log4net;
using OpenQA.Selenium;
using Specflow.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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

        public static void RefreshPage()
        {
            ObjectRepository.driver.Navigate().Refresh();
        }

        public static void SwitchToWindow(int index = 0)
        {
            Thread.Sleep(1000);
            ReadOnlyCollection<string> windows = ObjectRepository.driver.WindowHandles;

            if ((windows.Count - 1) < index)
            {
                throw new NoSuchWindowException("Invalid Browser Window Index" + index);
            }


            ObjectRepository.driver.SwitchTo().Window(windows[index]);
            Thread.Sleep(1000);
            MaximizeBrowser();

        }


        public static void SwitchToParent()
        {
            var windowids = ObjectRepository.driver.WindowHandles;


            for (int i = windowids.Count - 1; i > 0;)
            {
                ObjectRepository.driver.Close();
                i = i - 1;
                Thread.Sleep(2000);
                ObjectRepository.driver.SwitchTo().Window(windowids[i]);
            }
            ObjectRepository.driver.SwitchTo().Window(windowids[0]);

        }

        public static void SwitchToFrame(By locatot)
        {
            ObjectRepository.driver.SwitchTo().Frame(ObjectRepository.driver.FindElement(locatot));
        }
    }
}

