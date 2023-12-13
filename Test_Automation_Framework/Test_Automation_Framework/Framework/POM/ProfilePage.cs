using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Test_Automation_Framework.Framework.Driver;

namespace Test_Automation_Framework.Framework.POM
{
    public class ProfilePage
    {
        private static IWebDriver Driver;
        private WaitManager WaitManager;
        private WebDriverWait Wait;

        public ProfilePage(IWebDriver browser,WaitManager waitManager)
        {
            Driver = browser;
            WaitManager = waitManager;
            Wait = waitManager.Wait;
        }

        public void goToPage()
        {
            Driver.Navigate().GoToUrl("https://btube-app.onrender.com/#/");
            Thread.Sleep(500);
            Driver.Navigate().Refresh();
            Driver.Manage().Window.Maximize();

            Driver.Navigate().Refresh();
            WaitManager.WaitOnLoadingScreen();

            IWebElement signInButton = Wait.Until(ExpectedConditions.ElementExists(By.Id("SignInButton")));
            signInButton.Click();

            IWebElement userName = Wait.Until(ExpectedConditions.ElementExists(By.Id("SignInEmail")));
            IWebElement paswoord = Wait.Until(ExpectedConditions.ElementExists(By.Id("SignInPassword")));
            userName.SendKeys("stageadmin@stageadmin.stageadmin");
            paswoord.SendKeys("StageAdmin0221!");

            IWebElement signInButtonComplete =
                Wait.Until(ExpectedConditions.ElementExists(By.Id("SignInButtonComplete")));
            signInButtonComplete.Click();

            IWebElement profileButton =
                Wait.Until(ExpectedConditions.ElementExists(
                    By.CssSelector("a[href='#/profile'] button#OrdersPageButton")));
            profileButton.Click();

            Thread.Sleep(500);
        }

        public IReadOnlyCollection<IWebElement> getAllPElements()
        {
            Wait.Until(ExpectedConditions.ElementExists(By.TagName("p")));
            IReadOnlyCollection<IWebElement> paragraphElements = Driver.FindElements(By.TagName("p"));
            return paragraphElements;
        }


        public IWebElement creditButton()
        {
            Wait.Until(ExpectedConditions.ElementExists(By.TagName("button")));
            IReadOnlyCollection<IWebElement> allButtons = Driver.FindElements(By.TagName("button"));
            foreach (var button in allButtons)
            {
                if (button.Text.ToLower().Contains("add credits"))
                {
                    return button;
                }
            }

            return null;
        }

        public void addCredits(int credits)
        {
            IWebElement button = creditButton();
            creditButton().Click();
            IWebElement creditfield = Driver.FindElement(By.Name("amount"));
            creditfield.SendKeys(credits.ToString());
            IWebElement buttonBuy = Driver.FindElement(By.XPath("//button[text()='buy']"));
            buttonBuy.Click();
        }

        public string getCredits()
        {
            Driver.Navigate().Refresh();
            WaitManager.WaitOnLoadingScreen();
            var allPElements = getAllPElements();
            var lastElement = allPElements.LastOrDefault();
            return lastElement.Text;
        }

        public string checkBorderColor(IWebElement button)
        {
            return button.GetCssValue("border-color");
        }

        public string checkHoverBorderColor(IWebElement button)
        {
            var action = new Actions(Driver);
            action.MoveToElement(button).Perform();
            return button.GetCssValue("border-color");
        }

        //gets the loading screen, to be moved somewhere else
        public IWebElement loadingScreen()
        {
            Driver.Navigate().GoToUrl("https://btube-app.onrender.com/#/");
            Thread.Sleep(500);
            Driver.Navigate().Refresh();
            Driver.Manage().Window.Maximize();
            try
            {
                IWebElement loadingScreen =
                    Wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.css-1yo793j img.css-1pma2px")));
                return loadingScreen;
            }
            catch
            {
                return null;
            }
        }
        public string getFirstName()
        {
            var allPElements = getAllPElements();
            bool foundFirstName = false;
            foreach (var element in allPElements)
            {
                if (foundFirstName)
                {
                    string text = element.Text;
                    if (text == "LASTNAME:")
                    {
                        return null;
                    }
                    return text;
                }
        
                if (element.Text == "FIRSTNAME:")
                {
                    foundFirstName = true;
                }
            }
    
            return null;
        }
    }
}