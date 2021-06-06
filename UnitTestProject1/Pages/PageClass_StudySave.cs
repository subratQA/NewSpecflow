using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumExtras.PageObjects;
using Specflow.BaseClasses;
using Specflow.ComponentHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Specflow.Pages
{
    public class PageClass_StudySave:PageBase
         
    {
        private IWebDriver driver;
        private static readonly ILog logs = LoggerHelper.GetLogger(typeof(PageClass_StudySave));

        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ContentLeft_ContentLeft_Actions1_ActionsRepeater_ctl00_divLink']/a")]
        public IWebElement ViewStudyJobs;
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ContentLeft_ContentLeft_Actions1_ActionsRepeater_ctl02_divLink']/a")]
        public IWebElement VerifyStudy;
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ContentLeft_ContentLeft_Actions1_ActionsRepeater_ctl04_divLink']/a")]
        public IWebElement PublishStudy;
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ContentLeft_ContentLeft_Actions1_ActionsRepeater_ctl06_divLink']/a")]
        public IWebElement StudyLabelEditCheck;
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ContentLeft_ContentLeft_Actions2_DocumentLinksRepeater_ctl00_divDocLink']/a")]
        public IWebElement ConfigureFileName;
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ContentLeft_ContentLeft_Actions2_DocumentLinksRepeater_ctl02_divDocLink']/a")]
        public IWebElement SDS;
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ContentLeft_ContentLeft_Actions2_DocumentLinksRepeater_ctl04_divDocLink']/a")]
        public IWebElement ECD;

        public PageClass_StudySave(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
            PageFactory.InitElements(_driver, this);
        }
        #region ActionUtilities
        public void ClickLinkFromActionPallet(string linkname)
        {

            try
            {
                switch (linkname.ToUpper())
                {
                    case "VIEW STUDY JOBS":
                        ViewStudyJobs.Click();
                        logs.Info("Clicked on View Study Jobs link ");
                        break;
                    case "VERIFY STUDY":
                        VerifyStudy.Click();
                        logs.Info("Clicked on Verify Study link ");
                        break;
                    case "PUBLISH STUDY":
                        PublishStudy.Click();
                        logs.Info("Clicked on Publish Study link ");
                        break;
                    case "STUDY LABEL EDIT CHECK":
                        StudyLabelEditCheck.Click();
                        logs.Info("Clicked on Study Label Edit Check link ");
                        break;
                    case "CONFIGURE FILE NAME":
                        ConfigureFileName.Click();
                        logs.Info("Clicked on Configure file name link ");
                        break;
                    case "STUDY DESIGN SPECIFICATION (SDS)":
                        SDS.Click();
                        logs.Info("Clicked on SDS link ");
                        break;
                    case "EDIT CHECKS AND DERIVATIONS (EDD)":
                        ECD.Click();
                        logs.Info("Clicked on EDD link ");
                        break;
                    default:
                        logs.Error("Invalid link: " + linkname);
                        throw new Exception("Invalid Action pallet link :" + linkname);
                        break;
                }
            }
            catch (Exception e)
            {
                logs.Error(e.StackTrace);
                GenericHelper.TakeScreenshotForMePlease();
                throw;
            }
            

        }
        #endregion

    }
}
