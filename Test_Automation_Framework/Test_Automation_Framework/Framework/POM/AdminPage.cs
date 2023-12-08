using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Framework.Framework.POM
{
    public class AdminPage
    {
        IWebDriver driver;
        public AdminPage(IWebDriver browser) 
        {
            driver = browser;
        }
        public void GoToUsers()
        {
            driver.Navigate().GoToUrl("https://btube-app.onrender.com/#/admin/users");
        }
    }
}
