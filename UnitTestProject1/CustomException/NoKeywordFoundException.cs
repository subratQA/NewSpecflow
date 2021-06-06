using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.CustomException
{
   public class NoKeywordFoundException:Exception
    {
        public NoKeywordFoundException(String msg) : base(msg)
        {
            Console.WriteLine("No Such Keywords Exist");
        }
    }
}
