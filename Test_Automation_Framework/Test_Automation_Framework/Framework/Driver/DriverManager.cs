using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Framework.Framework.Driver
{
    public enum BrowserType
    {
        Chrome,
        Edge
    }
    public class DriverManager
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

                return new EdgeDriver();

            }
        }
        public static IWebDriver GetDriver(string browserType)
        {
            switch (browserType)
            {
                case "chrome":
                    return DriverManager.Chrome;
                case "edge":
                    return DriverManager.Edge;
                default:
                    throw new ArgumentException("Invalid browser type");
            }
        }
        public static void CloseDriver(IWebDriver browser)
        {
            browser.Close();
            browser.Quit();
        }
    }
}
