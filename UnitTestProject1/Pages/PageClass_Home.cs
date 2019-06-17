using log4net;
using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
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
    public class PageClass_Home:PageBase
    {
        public IWebDriver driver;
        private static readonly ILog logs = LoggerHelper.GetLogger(typeof(PageClass_Home));

        #region Constructor
        public PageClass_Home(IWebDriver _driver) : base(_driver)
        {           
            this.driver = _driver;
            PageFactory.InitElements(_driver, this);
        }
        #endregion

        #region WebElements
        [FindsBy(How =How.Id,Using = "ctl00_ContentMainMenu_ctl00_MenuRepeater_ctl00_lblMenu")]
        public IWebElement homeIcon;
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ContentLeft_actions1_ActionsRepeater_ctl04_divLink']/a")]
        [CacheLookup]
        public IWebElement link_ImportStudy;
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ContentLeft_actions1_ActionsRepeater_ctl00_divLink']/a")]
        [CacheLookup]
        public IWebElement link_CreateNewStudy;
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ContentLeft_actions1_ActionsRepeater_ctl02_divLink']/a")]
        [CacheLookup]
        public IWebElement link_createstudyfromexist;
        [FindsBy(How = How.XPath, Using = "//table[@id='ctl00_ContentBody_ctl00_grdHome_ctl00']")]
        [CacheLookup]
        public IWebElement table_Studies;

        public static string tableStudies = "//table[@id='ctl00_ContentBody_ctl00_grdHome_ctl00']";

        //private static By HomeIcon = By.Id("Home");
        //private static By link_CreateNewStudy = By.XPath("//*[@id='ctl00_ContentLeft_actions1_ActionsRepeater_ctl00_divLink']/a");
        //private static By link_createstudyfromexist = By.XPath("//*[@id='ctl00_ContentLeft_actions1_ActionsRepeater_ctl01_divLink']/a");
        //private static By link_ImportStudy = By.XPath("//*[@id='ctl00_ContentLeft_actions1_ActionsRepeater_ctl04_divLink']/a");

        #endregion
        public IWebElement HomeIcon { get { return homeIcon; } }
        public IWebElement LinkImportStudy { get { return link_ImportStudy; } }
        public IWebElement LinkCreateNewStudy { get { return link_CreateNewStudy; } }
        public IWebElement LinkCreateStudyFrom { get { return link_createstudyfromexist; } }
        public PageClass_EnterStudyDetail clickActionPalletLink(string linkname)
        {
            switch (linkname.ToUpper())
            {
                case "CREATE NEW STUDY":
                    LinkCreateNewStudy.Click();
                    logs.Info("Clicked on create new study link");
                    break;

                case "IMPORT STUDY":
                    LinkImportStudy.Click();
                    logs.Info("Clicked on import study link");
                    break;
                case "CREATE STUDY FROM EXISTING":
                    LinkCreateStudyFrom.Click();
                    logs.Info("Clicked on create study from existing link");
                    break;
                default:
                    logs.Info("Invalid link name provided: "+linkname);
                    throw new Exception("Invalid Action pallet link :" + linkname);
                    break;
            }
            return new PageClass_EnterStudyDetail(driver);
        }

        public static bool IsUserInHomePage()
        {
            return true;
            
        }

        public PageClass_EnterStudyDetail SelectStudy(string study, string protocol)
        {
            int actrow = WebTableHelper.GetRowByStudyNameAndProtcol(tableStudies, study, protocol);
            if(!WebTableHelper.ClickButtonInColInTable(tableStudies, actrow, 2))
            {
                logs.Info("Failed to select the study : "+study + " having protcol:" + protocol);
                Console.WriteLine("Failed");
            }
            logs.Info("Pass: Clicked on the study : "+study + " having protcol:"+protocol);
            return new PageClass_EnterStudyDetail(driver);
        }
    }
}
