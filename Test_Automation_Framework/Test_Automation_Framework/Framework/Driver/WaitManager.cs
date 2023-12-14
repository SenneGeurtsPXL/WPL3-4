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
        public IWebDriver Driver { get; set; }
        public WaitManager(IWebDriver driver,int timespanInSeconds)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timespanInSeconds));
        }
        //This function waits for the loading screen to dissapear
        public void WaitOnLoadingScreen()
        {
            // Refresh the page to handle any white screen issues
            Driver.Navigate().Refresh();

            // CSS selectors for the loading screens
            string firstCssSelector = ".css-1yo793j";
            string secondCssSelector = ".css-1k60ssk";
            
            // Wait for the first loading screen to be visible
            Thread.Sleep(1000);
            // Check if either of the loading screens is present
            var elements = Driver.FindElements(By.CssSelector(firstCssSelector));
            var elementsSecond = Driver.FindElements(By.CssSelector(secondCssSelector));
            if (elements.Count > 0)
            {
                // Wait for the first loading screen to be visible and then invisible
                Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(firstCssSelector)));
                Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(firstCssSelector)));
            }
            else if (elementsSecond.Count > 0)
            {
                // Wait for the second loading screen to be visible and then invisible
                Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(secondCssSelector)));
                Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(secondCssSelector)));
            }
        }
        //this function checks of the loading screen excists, if not the page gets refreshed
        public void ConfirmPageLoaded()
        {
            try
            {
                IWebElement loadingScreen = Driver.FindElement(By.CssSelector("div.css-1yo793j"));
                while (loadingScreen == null)
                {
                    Driver.Navigate().Refresh();
                }
            }
            catch (Exception)
            {

                Driver.Navigate().Refresh();
            }
        }
    }
}
