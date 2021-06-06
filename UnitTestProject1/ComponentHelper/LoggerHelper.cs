using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Specflow.ComponentHelper
{
   public class LoggerHelper
    {
        #region FIELDS

        private static ILog _logger;
        private static FileAppender _fileAppender;
        private static RollingFileAppender _rollingFileAppender;
        private static string _layout = " %date{dd-MMM-yyy-HH:mm:ss} [%class][%level][%method]- %message%newline";

        #endregion

        #region PROPERTY

        public static string LayOut
        {
            set { _layout = value; }             //id user wants to set his own layout then he can call this property
        }
        #endregion

        #region PRIVATE APPENDERS

        private static PatternLayout getPatternLayout()
        {
            var patternlayout = new PatternLayout()
            {
                ConversionPattern = _layout
            };
            patternlayout.ActivateOptions();
            return patternlayout;
        }

        internal static string ResultFolder()
        {
            String BasePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)));
            BasePath = BasePath.Replace("file:\\", "");
            BasePath = BasePath + @"\Reports\";
            string RunFolder = DateTime.Now.ToString();
            RunFolder = RunFolder.Replace("/", "-");
            RunFolder = RunFolder.Replace(":", " ");
            RunFolder = BasePath + RunFolder;
            FeatureContext.Current["ReportsFolderPath"] = FeatureContext.Current.FeatureInfo.Title + "_DebugLog.txt";
            //String fileName = FeatureContext.Current.FeatureInfo.Title + "DebugLog.txt";
            string fileName = FeatureContext.Current["ReportsFolderPath"].ToString();
            string finalPath = RunFolder + @"\"+fileName;
            return finalPath;
        }
        private static FileAppender getFileAppender()
        {
           

            var fileAppender = new FileAppender()
            {
                Name = "FileAppender",
                Layout = getPatternLayout(),
                Threshold = Level.All,
                AppendToFile = true,
                File = ResultFolder(),
            };
            fileAppender.ActivateOptions();
            return fileAppender;
        }

        private static RollingFileAppender getRollingFileAppender()
        {
            var rollinFileAppender = new RollingFileAppender()
            {
                Name = "RollingFileAppender",
                Layout = getPatternLayout(),
                Threshold = Level.All,
                AppendToFile = true,
                MaximumFileSize = "1MB",
                MaxSizeRollBackups = 15,
                File = ResultFolder(),
                
            };
            rollinFileAppender.ActivateOptions();
            return rollinFileAppender;
        }
        #endregion
        
        #region INITIALIZATION

        public static ILog GetLogger(Type type)
        {
            //if (_fileAppender == null)
            //    _fileAppender = getFileAppender();
            if (_rollingFileAppender == null)
                _rollingFileAppender = getRollingFileAppender();
            if (_logger != null)
               return _logger;
            BasicConfigurator.Configure(_rollingFileAppender);
            _logger = LogManager.GetLogger(type);
            return _logger;
        }

        public bool CreateLogFile(String applicationName, String version, String environment)
        {
            try
            {
                String fileName = FeatureContext.Current.FeatureInfo.Title + "_" + "DebugLog.txt";
                FeatureContext.Current.Add("DebugLog", fileName);
                String reportsFolderPath = FeatureContext.Current["ReportsFolderPath"].ToString();
                FileStream fs = File.Create(reportsFolderPath + fileName);
                fs.Close();
                return true;
            }
            catch (Exception e)
            {

            }
            return false;
        }

        #endregion
    }
}
