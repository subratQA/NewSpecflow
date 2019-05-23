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

     public sealed class StepDef_CreateNewStudy
    {
        private PageClass_Login lPage;
        private PageClass_Home hPage;
        private PageClass_StudySave stPage;
        private PageClass_EnterStudyDetail etPage;

#region Given Block

        [Given(@"I Logged into Designer application")]
        public void GivenILoggedIntoDesignerApplication()
        {
            lPage = new PageClass_Login(ObjectRepository.driver);
            //NavigationHelper.NavigateToURL(ObjectRepository.config.getUrl());
            lPage.loginToDesigner(ObjectRepository.config.getUserName(), ObjectRepository.config.getPassword());
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

#endregion

        #region Then Block

        [Then(@"I see desginer home page")]
        public void ThenISeeDesginerHomePage()
        {
            hPage = new PageClass_Home(ObjectRepository.driver);
            AssertHelper.IsElementPresent(hPage.homeIcon);
        }

        [Then(@"I see study has been created successfully")]
        public void ThenISeeStudyHasBeenCreatedSuccessfully()
        {
            
        }

#endregion

    }
}
