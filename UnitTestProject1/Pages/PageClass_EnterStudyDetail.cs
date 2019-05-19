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
   public class PageClass_EnterStudyDetail:PageBase
    {
        private IWebDriver iDriver;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_ContentBody_ContentBody_txtStudyName")]
        private IWebElement studyName;
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_ContentBody_ContentBody_txtStudyLabel")]
        private IWebElement studyLabel;
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_ContentBody_ContentBody_txtProtocol")]
        private IWebElement Protocol;
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_ContentBody_ContentBody_txtProtocolLabel")]
        private IWebElement protcolLabel;
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_ContentBody_ContentBody_txtStudyIndication")]
        private IWebElement studyIndication;
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_ContentBody_ContentBody_ddlTherapeuticArea")]
        private IWebElement theraputic;
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_ContentBody_ContentBody_txtClientSponsor")]
        private IWebElement clientsponsor;
        [FindsBy(How = How.Id, Using = "ddlTargetApp")]
        private IWebElement targetApp;
        [FindsBy(How = How.Name, Using = "ctl00$ctl00$ContentBody$ContentBody$SaveBtn")]
        private IWebElement savebtn;
        [FindsBy(How = How.Id, Using = "ctl00$ctl00$ContentBody$ContentBody$CancelBtn")]
        private IWebElement cancelbtn;

        public PageClass_EnterStudyDetail(IWebDriver driver) : base(driver)
        {
            this.iDriver = driver;
        }

        public PageClass_StudySave CreateNewStudy(string studyname, string studylabel, string protocol, string protcollabel, string studyIndi, string therap, string client, string target)
        {
            studyName.Clear();
            studyName.SendKeys(studyname);
            studyLabel.Clear();
            studyLabel.SendKeys(studylabel);
            Protocol.Clear();
            Protocol.SendKeys(protocol);
            protcolLabel.Clear();
            protcolLabel.SendKeys(protcollabel);
            studyIndication.Clear();
            studyIndication.SendKeys(studyIndi);
            DropDownListHelper.SelectListItemByname(theraputic, therap);
            Thread.Sleep(1000);
            clientsponsor.SendKeys(client);
            DropDownListHelper.SelectListItemByname(targetApp, target);
            savebtn.Click();
            return new PageClass_StudySave(iDriver);
        }

    }
}
