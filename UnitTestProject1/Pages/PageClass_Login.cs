using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumExtras.PageObjects;
using Specflow.BaseClasses;
using Specflow.ComponentHelper;
using Specflow.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Specflow.Pages
{
    public class PageClass_Login:PageBase
    {
        public IWebDriver driver;//ObjectRepository.driver;
        private static readonly ILog logs = LoggerHelper.GetLogger(typeof(PageClass_Login));

        #region WebElements
        // private IWebElement userNamefield = GenericHelper.GetElement(By.Id("Login_ContentBody_txtUsername"));
        //  private IWebElement passwordfield = GenericHelper.GetElement(By.Id("Login_ContentBody_txtPassword"));
        // private IWebElement loginbtn = GenericHelper.GetElement(By.Id("Login_ContentBody_btnLogin"));
        private static By userNamefield = By.Id("Login_ContentBody_txtUsername");
        private static By passwordfield = By.Id("Login_ContentBody_txtPassword");
        private static By loginbtn = By.Id("Login_ContentBody_btnLogin");

        [FindsBy(How = How.Id,Using = "Login_ContentBody_txtUsername")]
        private IWebElement username;
        [FindsBy(How = How.Id, Using = "Login_ContentBody_txtPassword")]
        private IWebElement passwrd;
        [FindsBy(How = How.Id, Using = "Login_ContentBody_btnLogin")]
        private IWebElement lgnBttn;

       // IWebElement username => iDriver.FindElementById("Login_ContentBody_txtUsername");
        //IWebElement passwrd => iDriver.FindElementById("Login_ContentBody_txtPassword");
        //IWebElement lgnBttn => iDriver.FindElementById("Login_ContentBody_btnLogin");


        #endregion

        #region contructor

        public PageClass_Login(IWebDriver _driver) :base(_driver) //calling the constructor of parent class
        {
            //PageFactory.InitElements(ObjectRepository.driver, this);
            this.driver = _driver;
            PageFactory.InitElements(driver, this);
        }


        #endregion

        #region ActionUtilities
        public static bool Login(string username, string password)
        {
            try
            {
                TextBoxHelper.ClearTextFromTextBox(userNamefield);
                Thread.Sleep(250);
                TextBoxHelper.SetText(userNamefield, username);
                
                TextBoxHelper.ClearTextFromTextBox(passwordfield);
                Thread.Sleep(250);
                TextBoxHelper.SetText(passwordfield, password);                
                ButtonHelper.ClickButton(loginbtn);
                
            }
            catch (Exception e)
            {

            }
            return true;
        }

            public PageClass_Home loginToDesigner(string uname, string pwd)
            {
            try
            {
                NavigationHelper.NavigateToURL(ObjectRepository.config.getUrl());
                username.Clear();
                Thread.Sleep(250);
                username.SendKeys(uname);
                logs.Info("Text Set: " + uname);
                passwrd.Clear();
                Thread.Sleep(250);
                passwrd.SendKeys(pwd);
                logs.Info("Text Set: " + pwd);
                lgnBttn.Click();
                logs.Info("Clicked on login button");
            }
            catch (Exception e)
            {
                logs.Error(e.StackTrace);
                GenericHelper.TakeScreenshotForMePlease();
                throw;
            }
             return new PageClass_Home(driver);
            }

        }
        #endregion

    }
