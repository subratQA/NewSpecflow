using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using Specflow.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Specflow.ComponentHelper
{
    public class GenericHelper
    {
        public IWebDriver iDriver;
        public static bool IsElementPresent(By Locator)
        {
            try { return ObjectRepository.driver.FindElements(Locator).Count == 1; }
            catch (Exception) { return false; }
        }

        public static IWebElement GetElement(By Locator)
        {
            IWebElement element = ObjectRepository.driver.FindElement(Locator);
            if (IsElementPresent(Locator) && IsClickable(element))
                //return ObjectRepository.driver.FindElement(Locator);
                return element;
            else
                throw new NoSuchElementException("Element Not Found : " + Locator.ToString());
        }

        public static void TakeScreenshotForMePlease(string fileName = "Screen")
        {
            Screenshot screen = ObjectRepository.driver.TakeScreenshot();
            if (fileName.Equals("Screen"))
            {
                fileName = fileName + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
                screen.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
                return;
            }
            screen.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
        }

        internal static void TakeScreenshot()
        {
            throw new NotImplementedException();
        }

        public static bool CanIWaitForWebelementToAppearInPage(By Locator, TimeSpan timeout)
        {
            ObjectRepository.driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(1));//Reseting the implicit wait/disabling
            WebDriverWait wait = new WebDriverWait(ObjectRepository.driver, timeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            bool flag = wait.Until(funcWait(Locator));
            ObjectRepository.driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(ObjectRepository.config.GetElementLoadTimeOut()));//Reinitilaing the implicit wait
            return flag;
        }
        public static IWebElement INeedToWaitForWebelementToAppearInPage(By Locator, TimeSpan timeout)
        {
            ObjectRepository.driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(1));//Reseting the implicit wait/disabling
            WebDriverWait wait = new WebDriverWait(ObjectRepository.driver, timeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            IWebElement flag = wait.Until(funcWaitForWebElement(Locator));
            ObjectRepository.driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(ObjectRepository.config.GetElementLoadTimeOut()));//Reinitilaing the implicit wait
            return flag;
        }

        private static Func<IWebDriver, bool> funcWait(By Locator)// Anonymous function to wait for the element
        {                                                                   //which  returns true or false

            return ((x) =>
            {
                if (x.FindElements(Locator).Count == 1)
                    return true;
                return false;
            });
        }
        private static Func<IWebDriver, IWebElement> funcWaitForWebElement(By Locator)// Anonymous function to wait for the element
        {                                                                   //which  returns the Webelemet or null

            return ((x) =>
            {
                if (x.FindElements(Locator).Count == 1)
                    return x.FindElement(Locator);
                return null;
            });
        }

        public static bool IsClickable(IWebElement webElement)
        {
            try
            {
                int i = 0;
                while (true)
                {
                    if (webElement.Displayed && webElement.Size.Width > 0 && webElement.Size.Height > 0 && webElement.Enabled)
                    {
                        return true;
                    }
                    if (i == 5)
                    {
                        return false;
                    }
                    Thread.Sleep(500);
                    ++i;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public string getTitle
        {
            get { return iDriver.Title; }
         }
        
    }
}
