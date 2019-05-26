using OpenQA.Selenium;
using Specflow.ActionUtilities;
using Specflow.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.ComponentHelper
{
    public class TextBoxHelper
    {
        private static IWebElement element;

        public static bool IsClickable { get; private set; }
        public static object DebugException { get; private set; }

        public static bool SetText(By Locator, string text)
        {
            // element = GenericHelper.GetElement(Locator);
            // element.SendKeys(text);
            bool isTextEntered = false;
            try
            {
                if (Locator != null)
                {
                   // LoginUtil.ScrollIntoView(Locator);
                    ObjectRepository.webelement = GenericHelper.GetElement(Locator);
                    ObjectRepository.webelement.SendKeys(text);
                    isTextEntered = true;
                }
                if (!isTextEntered)
                {
                    //LogException("Object does not exist and failed to set text to textbox", String.Empty, logMessageOnException);
                }
            }
            catch (Exception e)
            {
                // LogException("Failed to set text to textbox", e.ToString(), logMessageOnException);
            }
            return isTextEntered;

        }

        public static bool SetText(IWebElement element, string text)
        {
            bool isTextEntered = false;
            try
            {
                if (element.GetProperty("class") != null)
                {
                    LoginUtil.ScrollIntoView(element);
                    element.SendKeys(text);
                    isTextEntered = true;
                }
            }
            catch (Exception e)
            {
                // LogException("Failed to set text to textbox", e.ToString(), logMessageOnException);
            }
            return isTextEntered;
        }

        public static void ClearTextFromTextBox(By Locator)
        {
            //element = GenericHelper.GetElement(Locator);
            //element.Clear();
            try
            {
                if (Locator != null)
                {
                    //LoginUtil.ScrollIntoView(Locator);
                    ObjectRepository.webelement = GenericHelper.GetElement(Locator);
                    ObjectRepository.webelement.Clear();
                }
            }
            catch (Exception e)
            {
                // LogException("Failed to set text to textbox", e.ToString(), logMessageOnException);
            }
        }
    }
}
