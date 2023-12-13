using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using Test_Automation_Framework.Framework.Driver;

namespace Test_Automation_Framework.Framework.POM
{
    public class AdminPage
    {
        private WaitManager waitManager;
        IWebDriver driver;
        public ConfigReader ConfigFile { get; set; }
        public AdminPage() 
        {
            driver = DriverManager.GetDriver(ConfigFile.BrowserType);
            waitManager = new WaitManager(driver, ConfigFile.WaitTime);
        }
        public void GoToUsers()
        {
            driver.Navigate().GoToUrl("https://btube-app.onrender.com/#/admin/users");
        }
    }
}
