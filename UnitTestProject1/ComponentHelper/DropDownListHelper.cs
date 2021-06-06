using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.ComponentHelper
{
    public class DropDownListHelper
    {
        private static readonly ILog logs = LoggerHelper.GetLogger(typeof(DropDownListHelper));
        private static IWebElement element;
        public static void SelectListItemByname(By Locator, string item)
        {
            try
            {
                element = GenericHelper.GetElement(Locator);
                SelectElement select = new SelectElement(element);
                select.SelectByValue(item);
                logs.Info("Selected the Item: " + item);
            }
            catch (Exception e)
            {
                logs.Error(e.StackTrace);
                GenericHelper.TakeScreenshotForMePlease();
                throw;
            }
           
        }
        public static void SelectListByIndex(By Locator, int index)
        {
            element = GenericHelper.GetElement(Locator);
            SelectElement select = new SelectElement(element);
            select.SelectByIndex(index);
            logs.Info("Selected the Item index: " + index);
        }
        public static IList<string> GetAllItem(By Locator)
        {
            try
            {
                element = GenericHelper.GetElement(Locator);
                SelectElement select = new SelectElement(element);
                return select.Options.Select((x) => x.Text).ToList();//Linq expression        }
            }
            catch (Exception e)
            {
                logs.Error(e.StackTrace);
                GenericHelper.TakeScreenshotForMePlease();
                throw;
            }
            
        }
        public static void SelectListItemByname(IWebElement Locator, string item)
        {
            try
            {
                SelectElement select = new SelectElement(Locator);
                //select.SelectByValue(item);
                select.SelectByText(item);
                logs.Info("Selected the Item by name: " + item);
            }
            catch (Exception e)
            {
                logs.Error(e.StackTrace);
                GenericHelper.TakeScreenshotForMePlease();
                throw;
            }
            
        }
    }
}
