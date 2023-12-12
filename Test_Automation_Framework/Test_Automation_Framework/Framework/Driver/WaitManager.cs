using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace Test_Automation_Framework.Framework.Driver
{
    public class WaitManager
    {
        public WebDriverWait Wait { get; set; }
        public WaitManager(IWebDriver driver,int timespanInSeconds)
        {
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timespanInSeconds));
        }
        public void waitOnLoadingScreen()
        {
            string cssSelector = "div.css-1yo793j";
            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelector)));
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(cssSelector)));
        }
    }
}
