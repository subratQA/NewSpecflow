using Specflow.LogGenerators;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Specflow.Configuration;


namespace Specflow.Reportings
{
    public class ScenarioAssist
    {
        public static void BeforeFeature()
        {
            KillProcesses();

            if (new LogGeneratorBase().CreateReportsFolderForTestCase())
            {

            }
        }

        static void KillProcesses()
        {
            try
            {
                var processes = Process.GetProcessesByName("WINWORD");
                foreach (var process in processes)
                {
                    process.Kill();
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}
