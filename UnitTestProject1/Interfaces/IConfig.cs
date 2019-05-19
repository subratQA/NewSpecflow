using Specflow.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.Interfaces
{
    public interface IConfig
    {
        BrowserType GetBrowserType();
        string getUserName();
        string getPassword();
        string getUrl();
        int GetPageLoadTimeOut();
        int GetElementLoadTimeOut();


    }
}
