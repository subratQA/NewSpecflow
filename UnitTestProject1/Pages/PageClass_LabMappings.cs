using log4net;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Specflow.BaseClasses;
using Specflow.ComponentHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.Pages
{
   public class PageClass_LabMappings:PageBase
    {
        private IWebDriver driver;
        ILog logs = LoggerHelper.GetLogger(typeof(PageClass_LabMappings));

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_ContentBody_ContentBody_txtStudyName")]
        private IWebElement studyName;

        public PageClass_LabMappings(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
            PageFactory.InitElements(driver, this);
        }


    }
}
