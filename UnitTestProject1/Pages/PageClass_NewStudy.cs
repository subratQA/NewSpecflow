using OpenQA.Selenium;
using Specflow.ComponentHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Specflow.Pages
{
    public class PageClass_NewStudy
    {
        #region WebElements
        // private IWebElement userNamefield = GenericHelper.GetElement(By.Id("Login_ContentBody_txtUsername"));
        //  private IWebElement passwordfield = GenericHelper.GetElement(By.Id("Login_ContentBody_txtPassword"));
        // private IWebElement loginbtn = GenericHelper.GetElement(By.Id("Login_ContentBody_btnLogin"));
        private static By userNamefield = By.Id("Login_ContentBody_txtUsername");
        private static By passwordfield = By.Id("Login_ContentBody_txtPassword");
        private static By loginbtn = By.Id("Login_ContentBody_btnLogin");

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
        #endregion

    }
}
