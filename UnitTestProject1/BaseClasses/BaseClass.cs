﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Specflow.ComponentHelper;
using Specflow.Configuration;
using Specflow.CustomException;
using Specflow.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.BaseClasses
{
    public class BaseClass
    {
        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            return option;
        }
        private static InternetExplorerOptions GetIEOptions()
        {
            InternetExplorerOptions IEOptins = new InternetExplorerOptions();
            IEOptins.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            IEOptins.EnsureCleanSession = true;
            return IEOptins;

        }
        private static FirefoxProfile GetFireFoxOptions()
        {
            FirefoxProfile profile = new FirefoxProfile();
            FirefoxProfileManager manager = new FirefoxProfileManager();
            profile = manager.GetProfile("default");
            return profile;
        }

        private static IWebDriver getFirefoxDriver()
        {
            IWebDriver driver = new FirefoxDriver();
            return driver;
        }
        private static IWebDriver getChromeDriver()
        {
            IWebDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }
        private static IWebDriver getIEDriver()
        {
            IWebDriver driver = new InternetExplorerDriver(GetIEOptions());
            return driver;
        }
        [AssemblyInitialize]
        public static void initWebDriver(TestContext tc)
        {

            ObjectRepository.config = new AppConfigReader();

            switch (ObjectRepository.config.GetBrowserType())
            {
                case BrowserType.Chrome:
                    ObjectRepository.driver = getChromeDriver();
                    break;
                case BrowserType.Firefox:
                    ObjectRepository.driver = getFirefoxDriver();
                    break;
                case BrowserType.IE:
                    ObjectRepository.driver = getIEDriver();
                    break;
                default:
                    throw new NoSuchDriverFound("Driver not found : " + ObjectRepository.config.GetBrowserType().ToString());
            }
            ObjectRepository.driver.Manage().Timeouts()
                .PageLoad.Add(TimeSpan.FromSeconds(ObjectRepository.config.GetPageLoadTimeOut()));
            ObjectRepository.driver.Manage().Timeouts()
                .ImplicitWait.Add(TimeSpan.FromSeconds(ObjectRepository.config.GetElementLoadTimeOut()));

            BrowserHelper.MaximizeBrowser();
        }
        [AssemblyCleanup]
        public static void tearDown()
        {
            if (ObjectRepository.driver != null)
            {
                ObjectRepository.driver.Quit();
            }
        }


    }
}
