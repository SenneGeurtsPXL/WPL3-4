using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;

namespace Test_Automation_Framework.Framework.Driver
{
    public enum BrowserType
    {
        Chrome,
        Edge, 
        Firefox
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
        public static IWebDriver Firefox
        {
            get
            {

                return new FirefoxDriver();

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
                case "firefox":
                    return DriverManager.Firefox;
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
