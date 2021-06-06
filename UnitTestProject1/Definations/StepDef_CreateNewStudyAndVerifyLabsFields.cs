using Specflow.Pages;
using Specflow.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Specflow.ComponentHelper;

namespace Specflow.Definations
{
    [Binding]

     public class StepDef_CreateNewStudyAndVerifyLabsFields
    {
        public PageClass_Login lPage;
        public PageClass_Home hPage;
        public PageClass_StudySave stPage;
        public PageClass_EnterStudyDetail etPage;
        public PageClass_LabMappings labPage;

        #region Given Block

        [Given(@"I Logged into Designer application")]
        public void GivenILoggedIntoDesignerApplication()
        {
            lPage = new PageClass_Login(ObjectRepository.driver);
          ObjectRepository.hPage = lPage.loginToDesigner(ObjectRepository.config.getUserName(), ObjectRepository.config.getPassword());
        }

        [Given(@"I Logged into Designer application in the instance ""(.*)""")]
        public void GivenILoggedIntoDesignerApplicationInTheInstance(string url)
        {
            NavigationHelper.NavigateToURL(url);
        }

        [Given(@"I create a study with below details")]
        public void GivenICreateAStudyWithBelowDetails()
        {

        }
        [Given(@"I Click on ""(.*)"" link from Action Pallet")]
        public void GivenIClickOnLinkFromActionPallet(string link)
        {
            //PageClass_EnterStudyDetail page = new PageClass_EnterStudyDetail(driver);
            // etPage = hPage.clickActionPalletLink(link);
            //hPage = new PageClass_Home(ObjectRepository.driver);
            //ObjectRepository.etPage = ObjectRepository.hPage.clickActionPalletLink(link);
        }

        [Given(@"I Click on the ""(.*)"" study having protocol ""(.*)""")]
        public void GivenIClickOnTheStudyHavingProtocol(string stutyname, string protocol)
        {
            
        }

        [Given(@"I click on ""(.*)"" Tab")]
        public void GivenIClickOnTab(string tabName)
        {
            etPage = new PageClass_EnterStudyDetail(ObjectRepository.driver);
            ObjectRepository.labPage = ObjectRepository.etPage.clickHeaderTabs(tabName);
        }




        #endregion

        #region And Block

        [Given(@"I entered Study Name,Study Label,Protocol,Protocol Label,Study Indication,Therapeutic Area,Client and Clicked on Save Button")]
        public void GivenIEnteredStudyNameStudyLabelProtocolProtocolLabelStudyIndicationTherapeuticAreaClient(Table table)
        {
            //etPage = new PageClass_EnterStudyDetail(ObjectRepository.driver);
            foreach (var row in table.Rows)
            {
                ObjectRepository.stPage = ObjectRepository.etPage.CreateNewStudy(row["Study Name"],row["Study Label"],row["Protocol"],row["Protocol Label"],row["Study Indication"],row["Therapeutic Area"],row["Client"],row["Target App"],row["Labs"]);
            }                           
        }


        #endregion

        #region Then Block

        [Then(@"I see desginer home page")]
        [When (@"I am in desginer home page")]
        public void ThenISeeDesginerHomePage()
        {
            //AssertHelper.IsElementPresent(ObjectRepository.hPage.homeIcon);
           // Console.WriteLine("Home Page");

        }

        [Then(@"I see study has been created successfully")]
        public void ThenISeeStudyHasBeenCreatedSuccessfully()
        {
            AssertHelper.IsElementPresent(ObjectRepository.stPage.ViewStudyJobs);
                
        }

        [Then(@"I Verify the subtabs (.*)")]
        public void ThenIVerifyTheSubtabs(string tabsName)
        {
            //AssertHelper.IsElementPresent();
        }


        #endregion

    }
}
