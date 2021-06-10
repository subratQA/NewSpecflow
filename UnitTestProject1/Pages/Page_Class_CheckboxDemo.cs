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
    public class Page_Class_CheckboxDemo
    {

        public IWebDriver driver;
        private static readonly ILog logs = LoggerHelper.GetLogger(typeof(PageClass_Home));

        public Page_Class_CheckboxDemo(IWebDriver _driver)
        {
            this.driver = _driver;
            PageFactory.InitElements(_driver, this);
        }

        private static By checkboxLabel = By.XPath("//div[contains(text(),'Single Checkbox Demo')]");
        private static By singleCheckbox = By.XPath("//input[@id='isAgeSelected']");
        private static By Option1 = By.XPath("//body[1]/div[2]/div[1]/div[2]/div[2]/div[2]/div[1]/label[1]");
        private static By Option2 = By.XPath("//body[1]/div[2]/div[1]/div[2]/div[2]/div[2]/div[2]/label[1]");
        private static By Option3 = By.XPath("//body[1]/div[2]/div[1]/div[2]/div[2]/div[2]/div[3]/label[1]");
        private static By Option4 = By.XPath("//body[1]/div[2]/div[1]/div[2]/div[2]/div[2]/div[4]/label[1]");
        private static By CheckAllBtn = By.XPath("//input[@value='Check All']");
        private static By UnCheckAllBtn = By.XPath("//input[@value='Uncheck All']");
        private static By SuccessMsg = By.XPath("//div[@id='txtAge']");

        private static By chkBtn(string btn)
        {
            return By.XPath("//input[@value='" + btn + "'");
        }

        public bool VerifyCheckboxLabelText()
        {
            return GenericHelper.IsElementPresent(checkboxLabel);
        }
        public void ClickSingleCheckbox(string checkboxname)
        {
            switch (checkboxname.ToUpper())
            {
                case "CLICK ON THIS CHECK BOX":
                    ButtonHelper.ClickButton(singleCheckbox);
                    break;
                case "OPTION1":
                    ButtonHelper.ClickButton(Option1);
                    break;
                case "OPTION2":
                    ButtonHelper.ClickButton(Option2);
                    break;
                case "OPTION3":
                    ButtonHelper.ClickButton(Option3);
                    break;
                case "OPTION4":
                    ButtonHelper.ClickButton(Option4);
                    break;
                default:
                    throw new Exception("No check box");
                    break;
            }
            
        }
        public void ClickCheckAllButton(string btnTxt)
        {
            switch (btnTxt.ToUpper())
            {
                case "CHECK ALL":
                    ButtonHelper.ClickButton(CheckAllBtn);
                    break;
                case "UNCHECK ALL":
                    ButtonHelper.ClickButton(UnCheckAllBtn);
                    break;
                default:
                    throw new Exception("Incorrect btn provided");
                    break;
            }
            
        }

        public bool CheckSuccessText(string output)
        {
            if (!GenericHelper.GetElement(SuccessMsg).Displayed)
            {
                throw new Exception("Element not found: ");
            }
            string actText = GenericHelper.GetElement(SuccessMsg).Text;
            if (!actText.Equals(output))
            {
                Assert.Fail();
            }
            return true;
        }

        public bool VerifyBtnText(string btnName)
        {
            switch (btnName.ToUpper())
            {
                case "CHECK ALL":
                    if (!GenericHelper.GetElement(CheckAllBtn).GetAttribute("value").Equals(btnName))
                        return false;
                    return true;
                case "UNCHECK ALL":
                    if (!GenericHelper.GetElement(UnCheckAllBtn).GetAttribute("value").Equals(btnName))
                        return false;
                    return true;
                default:
                    return false;
            }
        }

    }
}
