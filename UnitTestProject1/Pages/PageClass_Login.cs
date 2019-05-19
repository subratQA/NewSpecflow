using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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
        private IWebDriver iDriver;
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


        #endregion

        #region contructor

        public PageClass_Login(IWebDriver driver):base(driver) //calling the constructor of parent class
        {
            //PageFactory.InitElements(ObjectRepository.driver, this);
            this.iDriver = driver;
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
                username.Clear();
                Thread.Sleep(250);
                username.SendKeys(uname);
                 passwrd.Clear();
                Thread.Sleep(250);
                 passwrd.SendKeys(pwd);
                lgnBttn.Click();
                return new PageClass_Home(iDriver);
            }

        }
        #endregion

    }
