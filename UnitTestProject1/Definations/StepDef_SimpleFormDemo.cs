using OpenQA.Selenium;
using Specflow.ComponentHelper;
using Specflow.Pages;
using Specflow.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Specflow.Definations
{
    [Binding]
    public sealed class StepDef_SimpleFormDemo
    {
        public PageClass_Home hPage;
        public PageClass_SimpleFormDemo simplePage;

        [Given(@"I Navigate to Demo Website")]
        public void GivenINavigateToDemoWebsite()
        {           
            NavigationHelper.NavigateToURL();
            ObjectRepository.hPage = new PageClass_Home(ObjectRepository.driver);
            if (GenericHelper.IsElementPresent(By.Id("image-darkener")))
            {
                ObjectRepository.hPage.ClickNoThanksBtn();
            }
            //GenericHelper.CanIWaitForWebelementToAppearInPage(By.Id("image-darkener"), TimeSpan.FromSeconds(10));
            
        }

        [Given(@"I Select ""(.*)"" from Input Forms")]
        public void GivenISelectFromInputForms(string item)
        {
           
            ObjectRepository.simplePage =  ObjectRepository.hPage.SelectSimpleFormDemoFromInformFormList(item);
        }

        [Then(@"I see Input Form Page displayed")]
        public void ThenISeeInputFormPageDisplayed()
        {
            ObjectRepository.simplePage.VerifyInputLabelText();
        }

        [Given(@"I Enter ""(.*)"" in Enter Message field")]
        public void GivenIEnterInEnterMessageField(string text)
        {
            ObjectRepository.simplePage.SetEnterMessage(text);
        }

        [Given(@"I click on Button Show Message")]
        public void GivenIClickOnButton()
        {
            ObjectRepository.simplePage.ClickShowMessageButton();
        }

        [Then(@"I see the Output message as ""(.*)"" for One Input Field")]
        public void ThenISeeTheOutputMessageAsForOneInputField(string message)
        {
            ObjectRepository.simplePage.CheckOutputText(message);
        }

        [Given(@"I Enter (.*) in EnterA field")]
        public void GivenIEnterInEnterAField(int number1)
        {
            ObjectRepository.simplePage.SetValue1(number1);
        }


        [Given(@"I Enter (.*) in EnterB field")]
        public void GivenIEnterInEnterBField(int number2)
        {
            ObjectRepository.simplePage.SetValue2(number2);
        }

        [Given(@"I click on Button Get Total")]
        public void GivenIClickOnButtonGetTotal()
        {
            ObjectRepository.simplePage.ClickGetTotal();
        }

        [Then(@"I see the Output message as (.*) for Two Input Field")]
        public void ThenISeeTheOutputMessageAsForTwoInputField(int output)
        {
            ObjectRepository.simplePage.CheckValue(output);
        }



    }
}
