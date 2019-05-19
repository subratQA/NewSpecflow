using Specflow.Pages;
using Specflow.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace UnitTestProject1.Definations
{
    [Binding]
     public class StepDef_CreateNewStudy
    {
        private PageClass_Login hPage;
        private PageClass_Home lPage;
        private PageClass_StudySave stPage;
        private PageClass_EnterStudyDetail etPage;

        [Given(@"I Logged into Designer application")]
        public void GivenILoggedIntoDesignerApplication()
        {
            if (!PageClass_Login.Login(ObjectRepository.config.getUserName(), ObjectRepository.config.getPassword()))
            {

            }
        }
        [Then(@"I see desginer home page")]
        public void ThenISeeDesginerHomePage()
        {
            
        }

    }
}
