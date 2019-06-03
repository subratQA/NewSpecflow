using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeProj
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            {
                string strNumber = "100";
                int Result = 0;
                int parsedNum = int.Parse(strNumber);
                bool isSuccess = int.TryParse(strNumber, out Result);
                Console.WriteLine("Parsed number={0}", parsedNum);
                if (isSuccess)
                {
                    Console.WriteLine("Try Parse Success");
                }
                else
                {
                    Console.WriteLine("Try Parse Failed");
                }
            }
        }

    }
}
