using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Framework.Framework.Driver
{
    public class WaitManager
    {
        public WebDriverWait Wait { get; set; }
        public WaitManager(IWebDriver driver,int timespanInSeconds)
        {
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timespanInSeconds));
        }
    }
}
