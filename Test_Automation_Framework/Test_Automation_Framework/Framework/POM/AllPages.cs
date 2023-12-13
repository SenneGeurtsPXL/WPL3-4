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
        public LoginPage LoginPage { get; set; }
        public RegistrationPage RegistrationPage { get; set; }
        public IWebDriver browser { get; set; }
        public WaitManager Wait { get; set; }
        public ConfigReader ConfigFile { get; set; }
        public AllPages()
        {
            ConfigFile = new ConfigReader();
            browser = DriverManager.GetDriver(ConfigFile.BrowserType);
            Wait = new WaitManager(browser,ConfigFile.WaitTime);

            RegistrationPage = new RegistrationPage(browser,Wait.Wait);
            LoginPage = new LoginPage(browser,Wait.Wait);
        }
    }
}
