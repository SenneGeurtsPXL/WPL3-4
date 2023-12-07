﻿
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V118.Network;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Test_Automation_Framework.Framework.Driver;
using Test_Automation_Framework.Framework.POM;

namespace Test_Automation_Framework.Test.WebTest
{
    public class WebTests
    {
        #region Searchbar autocomplete
        #endregion
        #region Check Profile Information
        [Test]
        public void CheckProfileInformation()
        {
            var browser = DriverManager.GetDriver(BrowserType.Chrome);
            
            browser.Navigate().GoToUrl("https://btube-app.onrender.com/#/");
            browser.Navigate().Refresh();
            browser.Manage().Window.Maximize();

            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60));

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

            wait.Until(ExpectedConditions.ElementExists(By.TagName("p")));
            IReadOnlyCollection<IWebElement> paragraphElements = browser.FindElements(By.TagName("p"));

            Assert.IsTrue(paragraphElements.Count() >= 9, "not enough info on profile page");

            browser.Close();
            browser.Quit();
        }
        #endregion
        #region Login form validation
        [Test]
        public void LoginFormValidation()
        {
            //na de login knop te drukken kan ik niks meer ingeven in de input fields
            var browser = DriverManager.GetDriver(BrowserType.Chrome);

            LoginPage loginPage = new LoginPage(browser);

            string[] Emails = { "stage@stage.stage", "wrongmail.aze", "stage@stage.stage", "stage@stage.stage" };
            string[] Passwords = { "Wrongpassword", "aze", "Stage0221!Stage0221!", "Stage0221!" };
           
            loginPage.EmailInputField.SendKeys(Emails[1]);

            loginPage.PasswordInputField.SendKeys(Passwords[1]);
            loginPage.LoginButton.Click();
            Console.WriteLine(loginPage.GetValidationError());
            Thread.Sleep(1000);

            browser.Close();
            browser.Quit();

        }
        #endregion
        #region Registration form validation
        [Test]
        public void RegistrationFormValidation()
        {
            //deze pas maken wanneer we users uit de database kunnen halen
            var browser = DriverManager.GetDriver(BrowserType.Chrome);

            RegistrationPage registrationPage = new RegistrationPage(browser);

            string[] firstNames = { "stagtage", "wrongmail", "stag", "stage" };
            string[] lastNames = { "stagtage", "wrongmail", "stag", "stage" };
            string[] Emails = { "stagtage", "wrongmail", "stag", "stage" };
            string[] Passwords = { "Wrongpassword", "aze", "Stage022", "Stage0" };

            registrationPage.FirstNameInputField.SendKeys("");
            registrationPage.LastNameInputField.SendKeys("");

            registrationPage.EmailInputField.SendKeys("");

            registrationPage.PasswordInputField.SendKeys("");
            registrationPage.RePasswordInputField.SendKeys("");

            registrationPage.RegisterButton.Click();

            Console.WriteLine(registrationPage.GetValidationError());

            registrationPage.RegisterButton.Click();

            browser.Close();
            browser.Quit();

        }
        #endregion

        #region senne pom test
        [Test]
        public void testAllInfoDisplayed()
        {
            var browser = DriverManager.GetDriver(BrowserType.Chrome);
            ProfilePage profilePage = new ProfilePage(browser);
            profilePage.goToPage();
            IReadOnlyCollection<IWebElement> elements = profilePage.getAllPElements();
            Assert.IsTrue(elements.Count >= 9, "not enough elements");
            browser.Close();
            browser.Quit();
        }
        [Test]
        public void testbutton()
        {
            var browser = DriverManager.GetDriver(BrowserType.Chrome);
            ProfilePage profilePage = new ProfilePage(browser);
            profilePage.goToPage();
            IWebElement button = profilePage.creditButton();
            Assert.IsNotNull(button, "no credit button found");
            browser.Close();
            browser.Quit();
        }

        [Test]
        public void testCredits()
        {
            var browser = DriverManager.GetDriver(BrowserType.Chrome);
            ProfilePage profilePage = new ProfilePage(browser);
            profilePage.goToPage();
            string firstAmount = profilePage.getCredits();
            profilePage.addCredits(15);
            Thread.Sleep(5000);
            string secondAmount = profilePage.getCredits();
            Assert.IsTrue(secondAmount == (int.Parse(firstAmount)+15).ToString(), "credits are not added or wrong amount is added");
            browser.Close();
            browser.Quit();
        }

        [Test]
        public void testNegativeCredits()
        {
            var browser = DriverManager.GetDriver(BrowserType.Chrome);
            ProfilePage profilePage = new ProfilePage(browser);
            profilePage.goToPage();
            string firstAmount = profilePage.getCredits();
            profilePage.addCredits(-15);
            Thread.Sleep(5000);
            string secondAmount = profilePage.getCredits();
            Assert.IsFalse(int.Parse(secondAmount) < int.Parse(firstAmount), "Negative credits can be added");
            browser.Close();
            browser.Quit();
        }

        [Test]
        public void testButtonHover()
        {
            var browser = DriverManager.GetDriver(BrowserType.Chrome);
            ProfilePage profilePage = new ProfilePage(browser);
            profilePage.goToPage();
            string beforeColor = profilePage.checkBorderColor(profilePage.creditButton());
            string afterColor = profilePage.checkHoverBorderColor(profilePage.creditButton());
            Assert.IsFalse(beforeColor == afterColor, "border color does not change on hover");
        }
        #endregion
    }
}
