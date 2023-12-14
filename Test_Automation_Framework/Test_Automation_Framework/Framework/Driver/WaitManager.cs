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
                //refreshesh for if there is a white screen
                Driver.Navigate().Refresh();
                //css selector for the loading screen
                string cssSelector = "div.css-1yo793j";
                //check for the loading screen bug
                var elements = Driver.FindElements(By.CssSelector(cssSelector));
                if (elements.Count <= 0)
                {
                    //searching loading screen with bug
                    string secondload = ".css-1k60ssk";
                    Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(secondload)));
                    Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(secondload)));
                }
                else
                {
                    //wait until the loading screen is visible and then is not vissible anymore
                    Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelector)));
                    Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(cssSelector)));   
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
