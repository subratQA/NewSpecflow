using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using Specflow.BaseClasses;
using Specflow.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Specflow.ComponentHelper
{
    public class GenericHelper
    {
        public IWebDriver iDriver;
        private static readonly ILog logs = LoggerHelper.GetLogger(typeof(GenericHelper));
        public static bool IsElementPresent(By Locator)
        {
            try
            {
                //IWebElement element = ObjectRepository.driver.FindElement(Locator);
                return ObjectRepository.driver.FindElements(Locator).Count == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool IsElementPresent(IWebElement element)
        {
            try
            {
                if (element == null)
                {
                    return false;
                }
            }
            catch(NoSuchElementException e)
            {
               
            }
            return true;
        } 

        public static IWebElement GetElement(By Locator)
        {
            IWebElement element = ObjectRepository.driver.FindElement(Locator);
            if (IsElementPresent(Locator) && IsClickable(element))
            {
                //return ObjectRepository.driver.FindElement(Locator);
                logs.Info("Element located: " + element);
                return element;
            }
            else
            {
                throw new NoSuchElementException("Element Not Found : " + Locator.ToString());
            }
                
        }

        public static void TakeScreenshotForMePlease(string fileName = "Screen")
        {
            Screenshot screen = ObjectRepository.driver.TakeScreenshot();
            if (fileName.Equals("Screen"))
            {
                fileName = fileName + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
                screen.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
                logs.Info("Screenshot name is: " + fileName);
                return;
            }
            screen.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
            logs.Info("Screenshot name is: " + fileName);
        }

        internal static void TakeScreenshot()
        {
            try
            {
                string stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
                if (stepType.Equals("Then", StringComparison.InvariantCultureIgnoreCase))
                  {
                    String scenarioTitle = ScenarioContext.Current.ScenarioInfo.Title;
                    String step = ScenarioContext.Current.StepContext.StepInfo.Text;
                    Screenshot screen = ObjectRepository.driver.TakeScreenshot();
                    String screenshotFullPath = FeatureContext.Current["Screenshot_TempFolder"] + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
                    screen.SaveAsFile(screenshotFullPath);
                }
            }
            catch (Exception)
            {

                throw;
            }        
        }


        public static WebDriverWait GetWebdriverWait(TimeSpan timeout)
        {
            TimeSpan time = ObjectRepository.driver.Manage().Timeouts().ImplicitWait;
            WebDriverWait wait = new WebDriverWait(ObjectRepository.driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(500),
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            logs.Info(" Wait Object Created ");
            return wait;
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
                    logs.Info(" Waiting for Element : " + Locator);
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

        private static Func<IWebDriver, IList<IWebElement>> GetAllElements(By locator)
        {
            return ((x) =>
            {
                return x.FindElements(locator);
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

        public static void SelecFromAutoSuggest(By autoSuggesLocator, string initialStr, string strToSelect,
   By autoSuggestistLocator)
        {
            var autoSuggest = ObjectRepository.driver.FindElement(autoSuggesLocator);
            autoSuggest.SendKeys(initialStr);
            Thread.Sleep(1000);

            var wait = GenericHelper.GetWebdriverWait(TimeSpan.FromSeconds(40));
            var elements = wait.Until(GetAllElements(autoSuggestistLocator));
            var select = elements.First((x => x.Text.Equals(strToSelect, StringComparison.OrdinalIgnoreCase)));
            //IWebElement select =  elements.First((x=>x.Text.Equals(strToSelect,StringComparison.OrdinalIgnoreCase)))
            select.Click();
            Thread.Sleep(1000);
        }

    }
}
