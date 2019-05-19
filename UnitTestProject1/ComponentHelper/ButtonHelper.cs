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
        private static IWebElement buttonElement;
        public static void ClickButton(By Locator)
        {
            buttonElement = GenericHelper.GetElement(Locator);
            buttonElement.Click();
        }
        public static bool IsButtonEnabled(By Locator)
        {
            buttonElement = GenericHelper.GetElement(Locator);
            return buttonElement.Enabled;
        }
        public static string GetButtonText(By Locator)
        {
            buttonElement = GenericHelper.GetElement(Locator);
            if (buttonElement.GetAttribute("value") == null)
                return string.Empty;
            return buttonElement.GetAttribute("value");
        }
    }
}
