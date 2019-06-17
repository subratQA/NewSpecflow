using OpenQA.Selenium;
using Specflow.ComponentHelper;
using Specflow.Pages;
using Specflow.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Specflow.Definations
{
    [Binding]
   public class StepDef_SelectStudy
    {
        public PageClass_Login lPage;
        public PageClass_Home hPage;
        public PageClass_StudySave stPage;
        public PageClass_EnterStudyDetail etPage;
        public PageClass_LabMappings labPage;
        public PageClass_Forms fPage;


        [Given(@"I Selected Study ""(.*)"" having Sponsor/Client ""(.*)"" from Home Page")]
        public void GivenISelectedStudyHavingProtocolFromHomepPage(string studyname, string protocol)
        {
            hPage = new PageClass_Home(ObjectRepository.driver);
            ObjectRepository.etPage = hPage.SelectStudy(studyname, protocol);
        }

        [Given(@"I click on ""(.*)"" link in Forms page")]
        public void GivenIClickOnLinkInFormsPage(string formname)
        {
            fPage = new PageClass_Forms(ObjectRepository.driver);
            fPage.ClickHeaderLinksInFormsPage(formname);
        }

        [Given(@"I entered Form Name as ""(.*)""")]

        [Given(@"I entered ""(.*)"" as ""(.*)""")]
        public void GivenIEnteredAs(string colName, string texttoenter)
        {
            fPage.SetTextInFormsTableEditBoxes(colName, texttoenter);
        }

        [Given(@"I clicked on ""(.*)"" Icon")]
        public void GivenIClickedOnIcon(string iconname)
        {
            fPage.ClickIconsInFormPage("Save");
        }


        #region THEN

        [Then(@"I see a notification ""(.*)""")]
        public void ThenISeeANotification(string msg)
        {
            fPage.ReadNotificationText(msg);
        }

        [Then(@"I see form ""(.*)"" in the table created")]
        public void ThenISeeFormInTheTableCreated(string formname)
        {
            fPage.VerifyFormNameExistInTable(formname);
        }

        #endregion

    }
}
