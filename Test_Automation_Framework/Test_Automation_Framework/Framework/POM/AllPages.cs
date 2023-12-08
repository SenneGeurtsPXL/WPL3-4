using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Framework.Framework.Driver;

namespace Test_Automation_Framework.Framework.POM
{
    public class AllPages
    {
        public TestPage page { get; set; }
        public LoginPage loginPage { get; set; }
        public IWebDriver browser { get; set; }
        public WaitManager Wait { get; set; }
        public ConfigReader ConfigFile { get; set; }
        public AllPages()
        {
            ConfigFile = new ConfigReader();
            browser = DriverManager.GetDriver(ConfigFile.BrowserType);
            Wait = new WaitManager(browser,ConfigFile.WaitTime);
            page = new TestPage(browser,Wait.Wait);
            loginPage = new LoginPage(browser);
        }
    }
}
