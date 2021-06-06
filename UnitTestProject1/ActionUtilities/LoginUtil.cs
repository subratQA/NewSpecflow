using OpenQA.Selenium;
using Specflow.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.ActionUtilities
{
    public class LoginUtil
    {
        public static bool Login(string username, string password)
        {
            try
            {
                ObjectRepository.config.GetBrowserType();
                // TextBoxHelper.SetText(PageClass_Home. UserNameTextbox, username);
                //TextBoxHelper.SetText(Page_Login.PasswordTextbox, password);
                // ButtonHelper.ClickButton(Page_Login.LoginButton);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public static void ScrollIntoView(IWebElement webElement)
        {
            ((IJavaScriptExecutor)ObjectRepository.driver).ExecuteScript("arguments[0].scrollIntoView(false);", webElement);
        }
    }
}
