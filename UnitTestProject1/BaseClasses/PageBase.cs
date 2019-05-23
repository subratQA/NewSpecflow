using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Specflow.ComponentHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.BaseClasses
{
    public class PageBase
    {

        public IWebDriver iDriver;
        public PageBase(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            this.iDriver = _driver;
        }

        [FindsBy(How =How.Id,Using = "ctl00_ctl00_ucHeader_lnkLogout")]
        private IWebElement logoutlink;

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
    }
}
