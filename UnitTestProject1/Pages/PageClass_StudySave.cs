using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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
        private IWebDriver iDriver;

        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ContentLeft_ContentLeft_Actions1_ActionsRepeater_ctl00_divLink']/a")]
        private IWebElement ViewStudyJobs;
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ContentLeft_ContentLeft_Actions1_ActionsRepeater_ctl02_divLink']/a")]
        private IWebElement VerifyStudy;
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ContentLeft_ContentLeft_Actions1_ActionsRepeater_ctl04_divLink']/a")]
        private IWebElement PublishStudy;
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ContentLeft_ContentLeft_Actions1_ActionsRepeater_ctl06_divLink']/a")]
        private IWebElement StudyLabelEditCheck;
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ContentLeft_ContentLeft_Actions2_DocumentLinksRepeater_ctl00_divDocLink']/a")]
        private IWebElement ConfigureFileName;
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ContentLeft_ContentLeft_Actions2_DocumentLinksRepeater_ctl02_divDocLink']/a")]
        private IWebElement SDS;
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ContentLeft_ContentLeft_Actions2_DocumentLinksRepeater_ctl04_divDocLink']/a")]
        private IWebElement ECD;

        public PageClass_StudySave(IWebDriver driver) : base(driver)
        {
            this.iDriver = driver;
        }
        #region ActionUtilities
        public void ClickLinkFromActionPallet(string linkname)
        {
            switch (linkname.ToUpper())
            {
                case "VIEW STUDY JOBS":
                    ViewStudyJobs.Click();
                    break;
                case "VERIFY STUDY":
                    VerifyStudy.Click();
                    break;
                case "PUBLISH STUDY":
                    PublishStudy.Click();
                    break;
                case "STUDY LABEL EDIT CHECK":
                    StudyLabelEditCheck.Click();
                    break;
                case "CONFIGURE FILE NAME":
                    ConfigureFileName.Click();
                    break;
                case "STUDY DESIGN SPECIFICATION (SDS)":
                    SDS.Click();
                    break;
                case "EDIT CHECKS AND DERIVATIONS (EDD)":
                    ECD.Click();
                    break;
                default:
                    throw new Exception("Invalid Action pallet link :" + linkname);
                    break;
            }

        }
        #endregion

    }
}
