using OpenQA.Selenium;
using Specflow.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.ComponentHelper
{
   public class WebTableHelper
    {
        internal static string GetTableXpath(string locator, int row, int col)
        {
            return $"{locator}//tbody//tr[{row}]//td[{col}]";
        }
        private static IWebElement GetGridElement(string locator, int row, int col)
        {
            var xPath = GetTableXpath(locator, row, col);
            if(GenericHelper.IsElementPresent(By.XPath(xPath + "//a")))
            {
                return ObjectRepository.driver.FindElement(By.XPath(xPath + "//a"));    //for link and button
            }
            else if(GenericHelper.IsElementPresent(By.XPath(xPath + "//input")))
            {
                return ObjectRepository.driver.FindElement(By.XPath(xPath + "//input"));        //for text box
            }
            else
            {
                return ObjectRepository.driver.FindElement(By.XPath(xPath));
            }
        }
        public static string GetColumnValues(string locator, int row, int col)
        {
            string columnxPath = GetTableXpath(locator, row, col);
            string colValue = string.Empty;

           if (GenericHelper.IsElementPresent(By.XPath(columnxPath)))
            {
                colValue = ObjectRepository.driver.FindElement(By.XPath(locator)).Text;
            }
            return colValue;
        }

        public static string GetColumnValuesInGrid(string locator, int row, int col)
        {
            return GetGridElement(locator,row,col).Text;
        }

        public static IList<string> GetAllValuesInTable(string locator)
        {
            List<string> list = new List<string>();
            var row = 1;
            var col = 1;

            while(GenericHelper.IsElementPresent(By.XPath(GetTableXpath(locator,row, col))))
            {
                while (GenericHelper.IsElementPresent(By.XPath(GetTableXpath(locator, row, col))))
                {
                    //Console.WriteLine(GetColumnValues(locator, row, col));
                    list.Add(GetColumnValues(locator, row, col));
                    col++;
                }
                row++;
                col = 1;
            }
            return list;
        }

        public static void ClickButtonInColInTable(string locator, int row, int col)
        {
            GetGridElement(locator,row,col).Click();
        }
    }
}
