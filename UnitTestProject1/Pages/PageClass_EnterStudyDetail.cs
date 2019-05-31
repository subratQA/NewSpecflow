using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
//using OpenQA.Selenium.Support.PageObjects;
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
   public class PageClass_EnterStudyDetail:PageBase
    {
        private IWebDriver driver;

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
        [FindsBy(How = How.Id, Using = "ddlClient")]
        private IWebElement clientsponsor;
        [FindsBy(How = How.Id, Using = "ddlTargetApp")]
        private IWebElement targetApp;
        [FindsBy(How = How.Name, Using = "ctl00$ctl00$ContentBody$ContentBody$SaveBtn")]
        private IWebElement savebtn;
        [FindsBy(How = How.Id, Using = "ctl00$ctl00$ContentBody$ContentBody$CancelBtn")]
        private IWebElement cancelbtn;
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_ContentBody_ContentBody_ddlLabs")]
        private IWebElement labsfield;


        public PageClass_EnterStudyDetail(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
            PageFactory.InitElements(driver, this);
            //this.p = new PageFactory();
            //this.p.InitElements(driver, this);
            //p.Refresh();
        }

        public PageClass_StudySave CreateNewStudy(string studyname, string studylabel, string protocol, string protcollabel, string studyIndi, string therap, string client, string target,string labs)
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
            DropDownListHelper.SelectListItemByname(clientsponsor, client);
            DropDownListHelper.SelectListItemByname(targetApp, target);
            DropDownListHelper.SelectListItemByname(labsfield, labs);
            savebtn.Click();
            return new PageClass_StudySave(driver);
        }

    }
}
