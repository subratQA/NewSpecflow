using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Specflow.ComponentHelper;
using Specflow.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.BaseClasses
{
    public class PageBase
    {

        public IWebDriver driver;
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
            if(GenericHelper.IsElementPresent(By.Id("ctl00_ctl00_ucHeader_lnkLogout")));
            //if(GenericHelper.IsElementPresent(logoutlink))
            { logoutlink.Click(); }
        }
        public PageClass_LabMappings clickHeaderTabs(string tabName)
        {
            switch (tabName.ToUpper())
            {
                case "HOME":
                    hometab.Click();
                    break;
                case "STUDY":
                    studytab.Click();
                    break;
                case "EVENTS":
                    eventstab.Click();
                    break;
                case "FORMS":
                    formstab.Click();
                    break;
                case "DOMAINS":
                    domaintab.Click();
                    break;
                case "CODELISTS":
                    codeliststab.Click();
                    break;
                case "LABS":
                    labstab.Click();
                    break;
                default:
                    throw new Exception("Wrong tab name provided");                      
            }
            return new PageClass_LabMappings(driver);
        }
    }
}
