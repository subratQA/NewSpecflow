using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Specflow.Interfaces;
using Specflow.Pages;

namespace Specflow.Settings
{
    public class ObjectRepository
    {
        public static IConfig config { get; set; }
        public static IWebDriver driver { get; set; }
        public static IWebElement webelement { get; set; }

        public static PageClass_Login lPage;
        public static PageClass_Home hPage;
        public static PageClass_StudySave stPage;
        public static PageClass_EnterStudyDetail etPage;
        public static PageClass_LabMappings labPage;
        public static PageClass_Forms fPage;
        public static PageClass_SimpleFormDemo simplePage;

    }
}
