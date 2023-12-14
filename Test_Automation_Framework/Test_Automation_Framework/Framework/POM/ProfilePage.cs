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

        public ProfilePage(IWebDriver browser, WaitManager waitManager)
        {
            Driver = browser;
            WaitManager = waitManager;
            Wait = waitManager.Wait;
        }

        public void goToPage()
        {
            //starting homepagina
            Driver.Navigate().GoToUrl("https://btube-app.onrender.com/#/");
            Thread.Sleep(500);
            Driver.Navigate().Refresh();
            Driver.Manage().Window.Maximize();

            Driver.Navigate().Refresh();
            WaitManager.WaitOnLoadingScreen();
            
            //click on sign in button 
            IWebElement signInButton = Wait.Until(ExpectedConditions.ElementExists(By.Id("SignInButton")));
            signInButton.Click();
            
            //login
            IWebElement userName = Wait.Until(ExpectedConditions.ElementExists(By.Id("SignInEmail")));
            IWebElement paswoord = Wait.Until(ExpectedConditions.ElementExists(By.Id("SignInPassword")));
            userName.SendKeys("stageadmin@stageadmin.stageadmin");
            paswoord.SendKeys("StageAdmin0221!");

            IWebElement signInButtonComplete =
                Wait.Until(ExpectedConditions.ElementExists(By.Id("SignInButtonComplete")));
            signInButtonComplete.Click();
            
            //go to profile page
            IWebElement profileButton =
                Wait.Until(ExpectedConditions.ElementExists(
                    By.CssSelector("a[href='#/profile'] button#OrdersPageButton")));
            profileButton.Click();
            //wait until everything is loaded
            Thread.Sleep(200);
        }

        public IReadOnlyCollection<IWebElement> getAllPElements()
        {
            //return all elements with tagname p
            Wait.Until(ExpectedConditions.ElementExists(By.TagName("p")));
            IReadOnlyCollection<IWebElement> paragraphElements = Driver.FindElements(By.TagName("p"));
            return paragraphElements;
        }


        public IWebElement creditButton()
        {
            //search all buttons
            Wait.Until(ExpectedConditions.ElementExists(By.TagName("button")));
            IReadOnlyCollection<IWebElement> allButtons = Driver.FindElements(By.TagName("button"));
            //searching button with add credits and return it
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
            //clicking credit button with previous method
            IWebElement button = creditButton();
            creditButton().Click();
            //searching input to enter credits in
            IWebElement creditfield = Driver.FindElement(By.Name("amount"));
            creditfield.SendKeys(credits.ToString());
            //searching and clicking buy button based on the text in that button
            IWebElement buttonBuy = Driver.FindElement(By.XPath("//button[text()='buy']"));
            buttonBuy.Click();
        }

        public string getCredits()
        {
            //refreshing browser for if new credits are added but not yet displayed
            Driver.Navigate().Refresh();
            WaitManager.WaitOnLoadingScreen();
            //find last p element and return it
            Wait.Until(ExpectedConditions.ElementExists(By.TagName("p")));
            var allPElements = getAllPElements();
            var lastElement = allPElements.LastOrDefault();
            return lastElement.Text;
        }

        public string checkBorderColor(IWebElement button)
        {
            //return border color of a button
            return button.GetCssValue("border-color");
        }

        public string checkHoverBorderColor(IWebElement button)
        {
            //hover over a button and return the border color
            var action = new Actions(Driver);
            action.MoveToElement(button).Perform();
            return button.GetCssValue("border-color");
        }

        
        public IWebElement loadingScreen()
        {
            //opens btube site and waits on white screen and then refreshes
            Driver.Navigate().GoToUrl("https://btube-app.onrender.com/#/");
            Thread.Sleep(500);
            Driver.Navigate().Refresh();
            Driver.Manage().Window.Maximize();
            //searching for a loading screen
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
            //gets all p elements
            var allPElements = getAllPElements();
            //bool for if p element with "FIRSTNAME:" is found
            bool foundFirstName = false;
            foreach (var element in allPElements)
            {
                //if p element with "FIRSTNAME:" is found, return the text if the next p element is not "LASTNAME:"
                if (foundFirstName)
                {
                    string text = element.Text;
                    if (text == "LASTNAME:")
                    {
                        return null;
                    }
                    return text;
                }
                //check if p element is "FIRSTNAME:"
                if (element.Text == "FIRSTNAME:")
                {
                    foundFirstName = true;
                }
            }

            return null;
        }
    }
}