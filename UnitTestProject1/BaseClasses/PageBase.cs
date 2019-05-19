using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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

        [FindsBy(How =How.Id,Using = "ctl00_ctl00_ucHeader_lnkLogout")]
        private IWebElement logoutlink;

        public PageBase(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        protected void logOutFromApplication()
        {
            if(GenericHelper.IsElementPresent(By.Id("ctl00_ctl00_ucHeader_lnkLogout")));
            { logoutlink.Click(); }
        }
    }
}
