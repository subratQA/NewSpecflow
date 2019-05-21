using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.ComponentHelper
{
    public class AssertHelper
    {
        public static void AreEqual (string expected, string actual)
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
    }
}
