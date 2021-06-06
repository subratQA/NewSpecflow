using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Specflow.ComponentHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.Pages
{
    public class PageClass_SimpleFormDemo
    {
        public IWebDriver driver;
        private static readonly ILog logs = LoggerHelper.GetLogger(typeof(PageClass_Forms));

        public PageClass_SimpleFormDemo(IWebDriver _driver)
        {
            this.driver = _driver;
            PageFactory.InitElements(_driver, this);
        }

        private static By EnterMsg = By.Id("user-message");
        private static By ShowMsgButton = By.XPath("//form[@id='get-input']/button[@type='button']");
        private static By YourMsgOutPut = By.XPath("//span[@id='display']");
        private static By InputFieldLabel = By.XPath("//div[contains(text(),'Single Input Field')]");
        private static By Value1 = By.Id("sum1");
        private static By Value2 = By.Id("sum2");
        private static By GetTotalBtn = By.XPath("//button[@class='btn btn-default'][onclick='return total()']");
        private static By ShowValue = By.XPath("//span[@id='displayvalue']");
        public void SetEnterMessage(string message)
        {
            TextBoxHelper.SetText(EnterMsg, message);
        }
        public void SetValue1(int number)
        {
            TextBoxHelper.SetText(Value1, number.ToString());
        }

        public void SetValue2(int number)
        {
            TextBoxHelper.SetText(Value2, number.ToString());
        }
        public void ClickGetTotal()
        {
            ButtonHelper.ClickButton(GetTotalBtn);
        }

        public void ClickShowMessageButton()
        {
            ButtonHelper.ClickButton(ShowMsgButton);
        }

        public bool VerifyInputLabelText()
        {
           return GenericHelper.IsElementPresent(InputFieldLabel);
        }

        public bool CheckOutputText(string output)
        {
            if (!GenericHelper.GetElement(YourMsgOutPut).Displayed)
            {
                throw new Exception("Element not found: ");
            }
            string actText = GenericHelper.GetElement(YourMsgOutPut).GetAttribute("value");
            if (!actText.Equals(output))
            {
                Assert.Fail();
            }
            return true;
        }
        public bool CheckValue(int output)
        {
            if (!GenericHelper.GetElement(ShowValue).Displayed)
            {
                throw new Exception("Element not found: ");
            }
            string actText = GenericHelper.GetElement(ShowValue).GetAttribute("value");
            if (!actText.Equals(output))
            {
                Assert.Fail();
            }
            return true;
        }
    }
}
