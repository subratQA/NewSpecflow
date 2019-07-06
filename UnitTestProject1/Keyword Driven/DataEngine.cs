using OpenQA.Selenium;
using Specflow.ComponentHelper;
using Specflow.CustomException;
using Specflow.ExcelUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.Keyword_Driven
{
    public class DataEngine
    {
        private readonly int _keywordCol;
        private readonly int _locatorTypeCol;
        private readonly int _locatorValueCol;
        private readonly int _paramterCol;

        public DataEngine(int Keywordcol,int LocatorTypecol,int LocatorValueCol,int ParameterCol )
        {
            this._keywordCol = Keywordcol;
            this._locatorTypeCol = LocatorTypecol;
            this._locatorValueCol = LocatorValueCol;
            this._paramterCol = ParameterCol;
        }

        private By GetElementLocator(string locatorType, string locatorValue)
        {
            switch (locatorType)
            {
                case "ClassName":
                    return By.ClassName(locatorValue);
                case "CssSelector":
                    return By.CssSelector(locatorValue);
                case "Id":
                    return By.Id(locatorValue);
                case "PartialLinkText":
                    return By.PartialLinkText(locatorValue);
                case "Name":
                    return By.Name(locatorValue);
                case "XPath":
                    return By.XPath(locatorValue);
                case "TagName":
                    return By.TagName(locatorValue);
                default:
                    return By.Id(locatorValue);
            }
        }

        private void PerformAction(string keyword, string locatorType, string locatorValue, params string[] args)
        {
            switch (keyword)
            {
                case "Click":
                    ButtonHelper.ClickButton(GetElementLocator(locatorType, locatorValue));
                    break;
                case "SendKeys":
                    TextBoxHelper.SetText(GetElementLocator(locatorType, locatorValue), args[0]);
                    break;
                case "Select":
                    DropDownListHelper.SelectListItemByname(GetElementLocator(locatorType, locatorValue), args[0]);
                    break;
                case "WaitForEle":
                    GenericHelper.CanIWaitForWebelementToAppearInPage(GetElementLocator(locatorType, locatorValue),
                        TimeSpan.FromSeconds(50));
                    break;
                case "Navigate":
                    NavigationHelper.NavigateToURL(args[0]);
                    break;
                default:
                    throw new NoKeywordFoundException("Keywrd not found: " + keyword);
            }
        }

        public void ExecuteScript(string xlPath, string sheetName)
        {
            int totalRows = ExcelReaderHelper.GetTotalRows(xlPath, sheetName);
            for (int i = 1; i < totalRows; i++)
            {
                var lctType = ExcelReaderHelper.GetCellData(xlPath, sheetName, i, _locatorTypeCol).ToString();
                var lctValue = ExcelReaderHelper.GetCellData(xlPath, sheetName, i, _locatorValueCol).ToString();
                var keyword = ExcelReaderHelper.GetCellData(xlPath, sheetName, i, _keywordCol).ToString();
                var param = ExcelReaderHelper.GetCellData(xlPath, sheetName, i, _paramterCol).ToString();
                PerformAction(keyword, lctType, lctValue, param);
            }
        }

    }

    
}
