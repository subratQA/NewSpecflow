using OpenQA.Selenium;
using log4net;
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
   public class PageClass_Forms:PageBase
    {
        public IWebDriver driver;
        private static readonly ILog logs = LoggerHelper.GetLogger(typeof(PageClass_Forms));

        public PageClass_Forms(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Add Form']")]
        public IWebElement AddForm_link;
        [FindsBy(How = How.XPath, Using = "//a[text()='Delete Form']")]
        public IWebElement DeleteForm_link;
        [FindsBy(How = How.XPath, Using = "a[text()='Copy Form']")]
        public IWebElement CopyForm_link;
        [FindsBy(How = How.XPath, Using = "a[text()='Add Form']")]
        public IWebElement CreateFormfromExist_link;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtFName')]")]
        public IWebElement formName_EditField;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtFormLabel')]")]
        public IWebElement formLabel_EditField;
        [FindsBy(How = How.XPath, Using = "//input[contains(@src,'icon_save.gif')]")]
        public IWebElement btnSave_icon;
        [FindsBy(How = How.XPath, Using = "//input[contains(@src, 'icon_saveAdd.gif')]")]
        public IWebElement btnSaveAdd_icon;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'btnCancel')]")]
        public IWebElement btnCancel_icon;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'btnEdit')]")]
        public IWebElement btnEdit_icon;

        static string formsTable = "//table[contains(@id,'grdForms')]";

        #region METHODS
        public PageClass_Forms ClickHeaderLinksInFormsPage(string formname)
        {
            try
            {
                switch (formname.ToUpper())
                {
                    case "ADD FORM":
                        AddForm_link.Click();
                        logs.Info("Clicked on Add form link");
                        break;
                    case "DELETE FORM":
                        DeleteForm_link.Click();
                        logs.Info("Clicked on Delete form link");
                        break;
                    case "COPY FORM":
                        CopyForm_link.Click();
                        logs.Info("Clicked on Copy form link");
                        break;
                    case "CREATE FORM FROM EXISTING":
                        CreateFormfromExist_link.Click();
                        logs.Info("Clicked on Create form from existing link");
                        break;
                    default:
                        throw new Exception("String provided : " + formname + " is not a valid form name");
                }
            }
            catch (Exception e)
            {
                logs.Error(e.StackTrace);
                GenericHelper.TakeScreenshotForMePlease();
                throw;
            }
           
            return new PageClass_Forms(driver);
            //PageFactory.InitElements(this.driver, this);
        }

        public PageClass_Forms SetTextInFormsTableEditBoxes(string colname, string textToSet)
        {
            try
            {
                switch (colname.ToUpper())
                {
                    case "FORM NAME":
                        //PageFactory.InitElements(driver, this);
                        formName_EditField.Clear();
                        Thread.Sleep(250);
                        formName_EditField.SendKeys(textToSet);
                        logs.Info("Form Name text entered : " + textToSet);
                        break;
                    case "FORM LABEL":
                        formLabel_EditField.Clear();
                        Thread.Sleep(250);
                        formLabel_EditField.SendKeys(textToSet);
                        logs.Info("Form Label text entered : " + textToSet);
                        break;
                    default:
                        throw new Exception("Invalid colum name : " + colname);
                }
            }
            catch (Exception e)
            {
                logs.Error(e.StackTrace);
                GenericHelper.TakeScreenshotForMePlease();
                throw;
            }
            

            return new PageClass_Forms(driver);
        }

        public PageClass_Forms ClickIconsInFormPage(string iconname)
        {
            try
            {
                switch (iconname.ToUpper())
                {
                    case "SAVE":
                        btnSave_icon.Click();
                        logs.Info("Clicked on Save icon");
                        break;
                    case "SAVEADD":
                        btnSaveAdd_icon.Click();
                        logs.Info("Clicked on Save + icon");
                        break;
                    case "CANCEL":
                        btnCancel_icon.Click();
                        logs.Info("Clicked on Cancel Icon");
                        break;
                    case "EDIT":
                        btnEdit_icon.Click();
                        logs.Info("Clicked on Edit icon");
                        break;
                    default:
                        throw new Exception("Invalid icon name given: " + iconname);
                }
            }
            catch (Exception e)
            {
                logs.Error(e.StackTrace);
                GenericHelper.TakeScreenshotForMePlease();
                throw;
            }           

            return new PageClass_Forms(driver);

        }

        public bool VerifyFormNameExistInTable(string formname)
        {
            try
            {
                IList<string> li = WebTableHelper.GetAllValuesInTable(formsTable);
                bool found = false;
                //foreach (var item in li)
                    for (int k = 0; k < li.Count; k++)
                     {
                        if ((li[k].Equals(formname)))
                        {
                            logs.Info("Form Name verified : " + formname);
                            found =  true;
                            return true;
                            //break;
                        }
                    }
                    logs.Error("Form Name not verified : " + formname);
                    return false;                    
            }
            catch (Exception e)
            {
                logs.Error(e.StackTrace);
                GenericHelper.TakeScreenshotForMePlease();
                throw;
            }          
            //return new PageClass_Forms(driver);
        }
        #endregion 
    }
}
