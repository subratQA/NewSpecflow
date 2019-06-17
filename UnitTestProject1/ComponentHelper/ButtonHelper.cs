using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.ComponentHelper
{
    public class ButtonHelper
    {
        private static readonly ILog logs = LoggerHelper.GetLogger(typeof(ButtonHelper));
        private static IWebElement buttonElement;
        public static void ClickButton(By Locator)
        {
            try
            {
                buttonElement = GenericHelper.GetElement(Locator);
                buttonElement.Click();
                logs.Info("Button clicked : " + Locator);
            }
            catch (Exception e)
            {
                logs.Error(e.StackTrace);
                GenericHelper.TakeScreenshotForMePlease();
                throw;
            }
           
        }
        public static bool IsButtonEnabled(By Locator)
        {
            buttonElement = GenericHelper.GetElement(Locator);
            return buttonElement.Enabled;
            
        }
        public static string GetButtonText(By Locator)
        {
            try
            {
                buttonElement = GenericHelper.GetElement(Locator);
                if (buttonElement.GetAttribute("value") == null)
                    return string.Empty;
                logs.Info("Button Text : " + Locator);                
            }
            catch (Exception e)
            {
                logs.Error(e.StackTrace);
                GenericHelper.TakeScreenshotForMePlease();
                throw;           
            }
            return buttonElement.GetAttribute("value");
        }
    }
}
