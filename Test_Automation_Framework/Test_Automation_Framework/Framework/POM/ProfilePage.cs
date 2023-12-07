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
        private static IWebDriver browser;
        private WebDriverWait wait;
        public ProfilePage(IWebDriver driver)
        {
            browser = driver;
            wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60));
        }
        public void goToPage()
        {
            browser.Navigate().GoToUrl("https://btube-app.onrender.com/#/");
            Thread.Sleep(500);
            browser.Navigate().Refresh();
            browser.Manage().Window.Maximize();

            browser.Navigate().Refresh();
            Thread.Sleep(10000);

            IWebElement signInButton = wait.Until(ExpectedConditions.ElementExists(By.Id("SignInButton")));
            signInButton.Click();

            IWebElement userName = wait.Until(ExpectedConditions.ElementExists(By.Id("SignInEmail")));
            IWebElement paswoord = wait.Until(ExpectedConditions.ElementExists(By.Id("SignInPassword")));
            userName.SendKeys("stageadmin@stageadmin.stageadmin");
            paswoord.SendKeys("StageAdmin0221!");

            IWebElement signInButtonComplete = wait.Until(ExpectedConditions.ElementExists(By.Id("SignInButtonComplete")));
            signInButtonComplete.Click();
            
            IWebElement profileButton = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("a[href='#/profile'] button#OrdersPageButton")));
            profileButton.Click();

            Thread.Sleep(2000);
        }
        
        public IReadOnlyCollection<IWebElement> getAllPElements()
        {
            wait.Until(ExpectedConditions.ElementExists(By.TagName("p")));
            IReadOnlyCollection<IWebElement> paragraphElements = browser.FindElements(By.TagName("p"));
            return paragraphElements;
        }

        

        public IWebElement creditButton()
        {
            wait.Until(ExpectedConditions.ElementExists(By.TagName("button")));
            IReadOnlyCollection<IWebElement> allButtons = browser.FindElements(By.TagName("button"));
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
            IWebElement creditfield = browser.FindElement(By.Name("amount"));
            creditfield.SendKeys(credits.ToString());
            IWebElement buttonBuy = browser.FindElement(By.XPath("//button[text()='buy']"));
            buttonBuy.Click();
        }

        public string getCredits()
        {
            browser.Navigate().Refresh();
            Thread.Sleep(6000);
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
            var action = new Actions(browser);
            action.MoveToElement(button).Perform();
            return button.GetCssValue("border-color");
        }
    }
}
