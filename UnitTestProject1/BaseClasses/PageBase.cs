using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using Specflow.ComponentHelper;
using Specflow.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Specflow.BaseClasses
{
    public class PageBase
    {

        public IWebDriver driver;
        private static readonly ILog logs = LoggerHelper.GetLogger(typeof(PageBase));
        public PageBase(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            this.driver = _driver;
        }

        [FindsBy(How =How.Id,Using = "ctl00_ctl00_ucHeader_lnkLogout")]
        private IWebElement logoutlink;
        [FindsBy(How = How.XPath, Using = "//*[@id='Home']")]
        private IWebElement hometab;
        [FindsBy(How = How.XPath, Using = "//*[@id='Study']")]
        private IWebElement studytab;
        [FindsBy(How = How.Id, Using = "Events")]
        private IWebElement eventstab;
        [FindsBy(How = How.Id, Using = "Domains")]
        private IWebElement domaintab;
        [FindsBy(How = How.Id, Using = "Forms")]
        private IWebElement formstab;
        [FindsBy(How = How.Id, Using = "Codelists")]
        private IWebElement codeliststab;
        [FindsBy(How = How.Id, Using = "Labs")]
        private IWebElement labstab;
        [FindsBy(How = How.XPath, Using = "//img[contains(@id,'imgNotificationIcon')]")]
        public IWebElement notification_icon;
        //[FindsBy(How = How.XPath, Using = "//div[contains(@id,'RadToolTipWrapper')]")]
        //public IWebElement notification_TextArea;
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ContentMainMenu_MainMenu1_tdNotification']")]
        public IWebElement notification_TextArea;
       

        //IWebElement logoutlink => iDriver.FindElementById("ctl00_ctl00_ucHeader_lnkLogout");
        //        private IWebElement logoutlink
        //       {
        //           get
        //          {
        //               return iDriver.FindElement(By.Id("ctl00_ctl00_ucHeader_lnkLogout"));
        //           }
        //       }

        public void logOutFromApplication()
        {
            try
            {
                if (GenericHelper.IsElementPresent(logoutlink))
                {
                    logoutlink.Click();
                    logs.Info("Logged out of application");
                }
            }
            catch (Exception e)
            {
                logs.Error(e.StackTrace);
                GenericHelper.TakeScreenshotForMePlease();
                throw;
            }
            
        }
        public PageClass_LabMappings clickHeaderTabs(string tabName)
        {
            switch (tabName.ToUpper())
            {
                case "HOME":
                    hometab.Click();
                    logs.Info("Clicked Home Tab");
                    break;
                case "STUDY":
                    studytab.Click();
                    logs.Info("Clicked Study Tab");
                    break;
                case "EVENTS":
                    eventstab.Click();
                    logs.Info("Clicked Events Tab");
                    break;
                case "FORMS":
                    formstab.Click();
                    logs.Info("Clicked Forms Tab");
                    break;
                case "DOMAINS":
                    domaintab.Click();
                    logs.Info("Clicked Domains Tab");
                    break;
                case "CODELISTS":
                    codeliststab.Click();
                    logs.Info("Clicked Codelist Tab");
                    break;
                case "LABS":
                    labstab.Click();
                    logs.Info("Clicked Labs Tab");
                    break;
                default:
                    throw new Exception("Wrong tab name provided");                      
            }
            return new PageClass_LabMappings(driver);
        }

        internal void HoverOverObject(IWebElement Object)
        {
            try
            {
                Actions act = new Actions(driver);
                act.MoveToElement(Object);
                act.Build();
                act.Perform();
                logs.Info("Hover over is success on object : " + Object.Text);
            }
            catch (Exception e)
            {
                logs.Error(e.StackTrace);
                GenericHelper.TakeScreenshotForMePlease();
                throw;
            }
           
        }
        public bool ReadNotificationText(string text)
        {
            HoverOverObject(notification_icon);
            //Thread.Sleep(1000);
            if(!GenericHelper.IsElementPresent(notification_TextArea))
            {
                logs.Error("Failed to find the notification box");
                throw new Exception("Notification Text Box not displayed");
            }
            string temptext = notification_TextArea.GetAttribute("id") + "/span";
            IWebElement ele = GenericHelper.GetElement(By.XPath(temptext));
            string acttext = ele.Text;
            
            if (!text.Equals(acttext))
            {
                logs.Error("Failed : Notification text didnt match with actual text: "+text);
                throw new Exception("Notification Text not matched with actual text : "+ text);
            }
            logs.Info("Pass: Notification text match with actual text: " + text);
            return true;
        }
    }
}
