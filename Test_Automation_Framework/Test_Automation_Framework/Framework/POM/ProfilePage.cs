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
            //starten van homepagina
            Driver.Navigate().GoToUrl("https://btube-app.onrender.com/#/");
            Thread.Sleep(500);
            Driver.Navigate().Refresh();
            Driver.Manage().Window.Maximize();

            Driver.Navigate().Refresh();
            WaitManager.WaitOnLoadingScreen();
            
            //clicken op sign in button 
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
            
            //naar profile page gaan
            IWebElement profileButton =
                Wait.Until(ExpectedConditions.ElementExists(
                    By.CssSelector("a[href='#/profile'] button#OrdersPageButton")));
            profileButton.Click();
            //kort wachten tot alles is ingeladen
            Thread.Sleep(200);
        }

        public IReadOnlyCollection<IWebElement> getAllPElements()
        {
            //alle elementen met tagname p vinden en teruggeven
            Wait.Until(ExpectedConditions.ElementExists(By.TagName("p")));
            IReadOnlyCollection<IWebElement> paragraphElements = Driver.FindElements(By.TagName("p"));
            return paragraphElements;
        }


        public IWebElement creditButton()
        {
            //alle buttons zoeken
            Wait.Until(ExpectedConditions.ElementExists(By.TagName("button")));
            IReadOnlyCollection<IWebElement> allButtons = Driver.FindElements(By.TagName("button"));
            //button met add credits uit deze buttons zoeken en returnen en anders null returnen
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
            //creditbutton clicken met vorige methode
            IWebElement button = creditButton();
            creditButton().Click();
            //input zoeken voor credits en invullen
            IWebElement creditfield = Driver.FindElement(By.Name("amount"));
            creditfield.SendKeys(credits.ToString());
            //buy button zoeken op basis van de text in de button en dan clicken
            IWebElement buttonBuy = Driver.FindElement(By.XPath("//button[text()='buy']"));
            buttonBuy.Click();
        }

        public string getCredits()
        {
            //browser refreshen voor als er net credits zijn toegevoegd maar nog niet displayed
            Driver.Navigate().Refresh();
            WaitManager.WaitOnLoadingScreen();
            //laatstse p element zoeken en teruggeven (element waar de hoeveelheid credits zit)
            Wait.Until(ExpectedConditions.ElementExists(By.TagName("p")));
            var allPElements = getAllPElements();
            var lastElement = allPElements.LastOrDefault();
            return lastElement.Text;
        }

        public string checkBorderColor(IWebElement button)
        {
            //geeft de border color terug van een button
            return button.GetCssValue("border-color");
        }

        public string checkHoverBorderColor(IWebElement button)
        {
            //hoveren over button en dan border color terug geven
            var action = new Actions(Driver);
            action.MoveToElement(button).Perform();
            return button.GetCssValue("border-color");
        }

        //gets the loading screen, to be moved somewhere else
        public IWebElement loadingScreen()
        {
            //btube opendoen en wachten op mogelijk with scherm om dan te refreshen
            Driver.Navigate().GoToUrl("https://btube-app.onrender.com/#/");
            Thread.Sleep(500);
            Driver.Navigate().Refresh();
            Driver.Manage().Window.Maximize();
            //zoeken naar een loading screen en als er niets gevonden is geen loading screen terug geven
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
            //alle p elementen ophalen
            var allPElements = getAllPElements();
            //bool voor als p element met "FIRSTNAME:" gevonden is
            bool foundFirstName = false;
            foreach (var element in allPElements)
            {
                //als p element met "FIRSTNAME:" gevonden is dan checken of volgende element geen "LASTNAME:" en anders de firstname terug geven
                if (foundFirstName)
                {
                    string text = element.Text;
                    if (text == "LASTNAME:")
                    {
                        return null;
                    }
                    return text;
                }
                //checken of p element met "FIRSTNAME:" gevonden is
                if (element.Text == "FIRSTNAME:")
                {
                    foundFirstName = true;
                }
            }

            return null;
        }
    }
}