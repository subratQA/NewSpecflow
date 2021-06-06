using log4net;
using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using Specflow.BaseClasses;
using Specflow.ComponentHelper;
using Specflow.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.Pages
{
    public class PageClass_Home
    {
        public IWebDriver driver;
        private static readonly ILog logs = LoggerHelper.GetLogger(typeof(PageClass_Home));

        public PageClass_Home(IWebDriver _driver)
        {
            this.driver = _driver;
            PageFactory.InitElements(_driver, this);
        }

        private static By inputform = By.XPath("//a[@class='dropdown-toggle'][contains(text(),'Input Forms')]");
        private static By simpleDemo = By.XPath("//ul[@class='dropdown-menu']//a[contains(text(),'Simple Form Demo')]");

        public PageClass_SimpleFormDemo SelectSimpleFormDemoFromInformFormList(string Item)
        {
            if (!GenericHelper.GetElement(inputform).Displayed)
            {
                throw new Exception("Input Form not clicked");
            }
            ButtonHelper.ClickButton(inputform);
            if (!GenericHelper.GetElement(simpleDemo).Displayed)
            {
                throw new Exception("Simple Demo not displayed");
            }
            ButtonHelper.ClickButton(simpleDemo);
            return new PageClass_SimpleFormDemo(ObjectRepository.driver);
        }


    }   
}
