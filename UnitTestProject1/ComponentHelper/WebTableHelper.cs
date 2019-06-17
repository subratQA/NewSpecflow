using log4net;
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
        private static readonly ILog logs = LoggerHelper.GetLogger(typeof(WebTableHelper));
        internal static string GetTableXpath(string locator, int row, int col)
        {
            logs.Info("Returned webtable: "+ $"{locator}/tbody/tr[{row}]/td[{col}]");
            return $"{locator}/tbody/tr[{row}]/td[{col}]";
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
                colValue = ObjectRepository.driver.FindElement(By.XPath(columnxPath)).Text;
                logs.Info("Returned column value: " + colValue);
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

        public static bool ClickButtonInColInTable(string locator, int row, int col)
        {
            IWebElement ele = GetGridElement(locator, row, col);
            if(!ele.Enabled && ele.TagName != "a")
            {
                return false;
            }
            ele.Click();
            logs.Info("Clicked on locator: " + locator);
            return true;
        }

        public static int GetRowByStudyNameAndProtcol(string locator, string RowText, string protcol)
        {
            var row = 1;
            int finalrow = 0;

            while (GenericHelper.IsElementPresent(By.XPath(GetTableXpath(locator, row, 2))))
            {
                string colstudyText = GetColumnValues(locator, row, 2);
                if (colstudyText == RowText)
                {
                    finalrow = row;
                    string actProtocolText = GetColumnValues(locator, finalrow, 1);
                    if (actProtocolText.Equals(protcol))
                    {
                        logs.Info("Row number located: " + finalrow);
                        break;
                    }
                    row = finalrow;                        
                }
                row++;
            }  
            return finalrow;
        }

        //public static bool FindMatchingProtoclAgainstStudy(string locator, string study, string protocl)
        //{
        //    bool matchfound = false;
        //    int studyrow = GetRowByStudyText(locator, study);
        //    int protocolrow = GetRowByStudyText(locator, protocl);
        //    if (studyrow.Equals(protocl))
        //    {
        //        matchfound = true;
        //    }
        //    return matchfound;
        //}
    }
}
