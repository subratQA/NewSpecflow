using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Specflow.BaseClasses;
using Specflow.ComponentHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.Pages
{
    public class PageClass_Home:PageBase
    {
        private IWebDriver iDriver;
        #region Constructor
            public PageClass_Home(IWebDriver driver) : base(driver)
                {
                    this.iDriver = driver;
                }
        #endregion


        #region WebElements
        [FindsBy(How =How.Id,Using = "ctl00_ContentMainMenu_ctl00_MenuRepeater_ctl00_lblMenu")]
        private IWebElement HomeIcon;
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ContentLeft_actions1_ActionsRepeater_ctl04_divLink']/a")]
        private IWebElement link_ImportStudy;
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ContentLeft_actions1_ActionsRepeater_ctl00_divLink']/a")]
        private IWebElement link_CreateNewStudy;
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ContentLeft_actions1_ActionsRepeater_ctl02_divLink']/a")]
        private IWebElement link_createstudyfromexist;

        //private static By HomeIcon = By.Id("Home");
        //private static By link_CreateNewStudy = By.XPath("//*[@id='ctl00_ContentLeft_actions1_ActionsRepeater_ctl00_divLink']/a");
        //private static By link_createstudyfromexist = By.XPath("//*[@id='ctl00_ContentLeft_actions1_ActionsRepeater_ctl01_divLink']/a");
        //private static By link_ImportStudy = By.XPath("//*[@id='ctl00_ContentLeft_actions1_ActionsRepeater_ctl04_divLink']/a");

        #endregion

        public PageClass_EnterStudyDetail clickActionPalletLink(string linkname)
        {
            switch (linkname.ToUpper())
            {
                case "CREATE NEW STUDY":
                    link_CreateNewStudy.Click();
                    break;

                case "IMPORT STUDY":
                    link_ImportStudy.Click();
                    break;
                case "CREATE STUDY FROM EXISTING":
                    link_createstudyfromexist.Click();
                    break;
                default:
                    throw new Exception("Invalid Action pallet link :" + linkname);
                    break;
            }
            return new PageClass_EnterStudyDetail(iDriver);
        }

        public static bool IsUserInHomePage()
        {
            return true;
        }
    }
}
