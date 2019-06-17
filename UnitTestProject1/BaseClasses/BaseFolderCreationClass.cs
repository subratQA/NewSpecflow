using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Specflow.BaseClasses
{
   public class BaseFolderCreationClass
    {
        public bool CreateReportsFolderForTestCase()
        {
            try
            {
                if (CreateReportsBaseFolder())
                {
                    string RunFolder = DateTime.Now.ToString();
                    RunFolder = RunFolder.Replace("/", "-");
                    RunFolder = RunFolder.Replace(":", " ");
                    FeatureContext.Current["ReportsFolderPath"] = FeatureContext.Current["ReportsFolderPath"] + @"\" + RunFolder + @"\";
                    Directory.CreateDirectory(FeatureContext.Current["ReportsFolderPath"].ToString());
                    String tempFolderPath = FeatureContext.Current["ReportsFolderPath"].ToString() + "Temp";
                    FeatureContext.Current["Screenshot_TempFolder"] = tempFolderPath;
                    Directory.CreateDirectory(tempFolderPath);
                    return true;
                }
            }
            catch (Exception e)
            {
            }
            return false;
        }
        bool CreateReportsBaseFolder()
        {
            try
            {
                String BasePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)));
                BasePath = BasePath.Replace("file:\\", "");
                BasePath = BasePath + @"\Executed Test Reports\";
                if (!Directory.Exists(BasePath))
                {
                    Directory.CreateDirectory(BasePath);
                }
                FeatureContext.Current.Add("ReportsFolderName", FeatureContext.Current.FeatureInfo.Title);
                FeatureContext.Current.Add("ReportsFolderPath", BasePath + FeatureContext.Current["ReportsFolderName"]);
                if (!Directory.Exists(FeatureContext.Current["ReportsFolderPath"].ToString()))
                {
                    Directory.CreateDirectory(FeatureContext.Current["ReportsFolderPath"].ToString());
                }
                return true;
            }
            catch (Exception e)
            {
            }
            return false;
        }
    }
}
