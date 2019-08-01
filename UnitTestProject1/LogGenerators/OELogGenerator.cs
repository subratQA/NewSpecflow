using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Word = Microsoft.Office.Interop.Word;
using Specflow.WordUtility;

namespace Specflow.LogGenerators
{
    public class OELogGenerator:LogGeneratorBase
    {
        public bool CreateLogFile(String applicationName, String version, String environment)
        {
            try
            {
                String resDocName = FeatureContext.Current.FeatureInfo.Title + "_" + "OELog";
                FeatureContext.Current.Add("OELog", resDocName);
                String reportsFolderPath = FeatureContext.Current["ReportsFolderPath"].ToString();
                MsWord word = new MsWord();
                word.CreateOELogFromTemplate(resDocName, reportsFolderPath, applicationName, version, environment);
                FeatureContext.Current.Add("TableCounter", 1);
                FeatureContext.Current.Add("OELog_TableList", new TableList());
                return true;
            }
            catch (Exception e)
            {

            }
            return false;
        }

    }
}
