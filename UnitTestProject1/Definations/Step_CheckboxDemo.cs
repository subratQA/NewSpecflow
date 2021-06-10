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
    public sealed class Step_CheckboxDemo
    {
        public PageClass_Home hPage;
        public Page_Class_CheckboxDemo cPage;
        public static PageClass_SimpleFormDemo simplePage;

        [Given(@"I Select Checkbox Demo from Input Forms")]
        public void GivenISelectCheckboxDemoFromInputForms()
        {
            ObjectRepository.hPage = new PageClass_Home(ObjectRepository.driver);
            ObjectRepository.cPage =  ObjectRepository.hPage.SelectCheckBoxDemoFromInformFormList();
        }

        [Then(@"I see Checkbox Demo Page displayed")]
        public void ThenISeeCheckboxDemoPageDisplayed()
        {
            ObjectRepository.cPage.VerifyCheckboxLabelText();
        }

        [Given(@"I select checkbox ""(.*)""")]
        public void GivenISelectCheckbox(string checkItem)
        {
            ObjectRepository.cPage.ClickSingleCheckbox(checkItem);
        }

        [Then(@"I see the Success message as ""(.*)"" for Single Checkbox")]
        public void ThenISeeTheSuccessMessageAsForSingleCheckbox(string msg)
        {
            ObjectRepository.cPage.CheckSuccessText(msg);
        }

        [Given(@"I Click ""(.*)"" Button")]
        public void GivenIClickButton(string btn)
        {
            ObjectRepository.cPage.ClickCheckAllButton(btn);
        }

        [Then(@"I see Button Text as ""(.*)""")]
        public void ThenISeeButtonTextAs(string btnText)
        {
            ObjectRepository.cPage.VerifyBtnText(btnText);
        }

        [Given(@"I check checkbox ""(.*)""")]
        public void GivenICheckCheckbox(string checkBox)
        {
            ObjectRepository.cPage.ClickSingleCheckbox(checkBox);
        }

        [Given(@"I uncheck checkbox ""(.*)""")]
        public void GivenIUncheckCheckbox(string checkBox)
        {
            ObjectRepository.cPage.ClickSingleCheckbox(checkBox);
        }

    }
}
