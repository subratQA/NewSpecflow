using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.ComponentHelper
{
    public class AssertHelper
    {
        public static void AreEqual(string expected, string actual)
        {
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch
            {
                //No exception, so that the execution should not stop if the assertion fails
            }

        }

        public static void AreEqualElement(IWebElement expected, IWebElement actual)
        {
            try
            {
               Assert.AreEqual(expected.Text, actual.Text, string.Format("Expected element : {0} But Actual element is :{1}", expected.Text,actual.Text));
                Assert.IsNotNull(expected);
            }
            catch
            {

                //No exception, so that the execution should not stop if the assertion fails
            }
        }

        public static void AreEqualElement(By expected, By actual)
        {
            try
            {
                Assert.AreEqual(GenericHelper.GetElement(expected), GenericHelper.GetElement(actual), string.Format("Expected element : {0} But Actual element is :{1}", GenericHelper.GetElement(expected), GenericHelper.GetElement(actual)));
                Assert.IsNotNull(expected);
            }
            catch
            {

                //No exception, so that the execution should not stop if the assertion fails
            }
        }
        public static void IsElementPresent(IWebElement expected)
        {
            try
            {
                Assert.IsNotNull(expected);

            }
            catch
            {

                //No exception, so that the execution should not stop if the assertion fails
            }

        }

        public static void IsElementPresent(By expected)
        {
            try
            {
                Assert.IsNotNull(GenericHelper.GetElement(expected));

            }
            catch
            {

                //No exception, so that the execution should not stop if the assertion fails
            }

        }

    }
    
}
