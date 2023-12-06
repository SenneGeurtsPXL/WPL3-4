using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_tube_test_automation_framework.Web_applicatie.Driver_Manager
{
    public enum BrowserType
    {
        Chrome,
        Edge
    }

    public static class DriverManager
    {
        public static IWebDriver Chrome
        {
            get
            {
                return new ChromeDriver();
            }
        }

        public static IWebDriver Edge
        {
            get
            {
                return new ChromeDriver();
            }
        }
    }


}
