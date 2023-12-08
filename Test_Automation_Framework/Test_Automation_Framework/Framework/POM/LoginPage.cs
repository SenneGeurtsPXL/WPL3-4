using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Framework.Framework.Driver;

namespace Test_Automation_Framework.Framework.POM
{
    public class LoginPage
    {
        public IWebElement EmailInputField { get; set; }
        public IWebElement PasswordInputField { get; set; }
        public IWebElement LoginButton { get; set; }
        public IWebElement CreateAccountLink { get; set; }
        public IWebElement SignInForm { get; set; }
        public IWebElement VisualBugDiv { get; set; }
        public IWebElement SignInDiv { get; set; }
        public IWebElement ValidationError { get; set; }
        public IWebElement AdminButton { get; set; }
        public WebDriverWait Wait { get; set; }
        public IWebDriver driver { get; set; }
        public LoginPage(IWebDriver browser)
        {
            driver = browser;
            driver.Navigate().GoToUrl("https://btube-app.onrender.com/#/login");
            driver.Manage().Window.Maximize();
            driver.Navigate().Refresh();
            Thread.Sleep(10000);
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            EmailInputField = Wait.Until(ExpectedConditions.ElementExists(By.Id("SignInEmail")));
            PasswordInputField = Wait.Until(ExpectedConditions.ElementExists(By.Id("SignInPassword")));
            LoginButton = Wait.Until(ExpectedConditions.ElementExists(By.Id("SignInButtonComplete")));
            CreateAccountLink = Wait.Until(ExpectedConditions.ElementExists(By.Id("GoToRegister")));
            SignInForm = Wait.Until(ExpectedConditions.ElementExists(By.Id("SignIn")));
            VisualBugDiv = driver.FindElement(By.CssSelector("#SignIn > div:first-child"));

            //ValidationError = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("code")));
        }
        public void Login(string email,string password)
        {
            EmailInputField.SendKeys(email);
            PasswordInputField.SendKeys(password);
            LoginButton.Click();
        }
        public void GoToLogin()
        {
            driver.Navigate().GoToUrl("https://btube-app.onrender.com/#/login");
        }
        public string GetValidationError()
        {
            ValidationError = Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("code")));
            return ValidationError.Text;
        }
        public string SignInDivBorder()
        {
            return SignInForm.GetCssValue("border");
        }
        public void ClickAdminButton()
        {
            Wait.Until(ExpectedConditions.ElementExists(By.TagName("a")));
            IReadOnlyCollection<IWebElement> allAElements = driver.FindElements(By.CssSelector("a"));
            foreach (var element in allAElements)
            {
                Console.WriteLine("in de foreach");
                Console.WriteLine("element " + element.GetAttribute("href"));
            }
            Console.WriteLine("uit de foreach");
        }
    }
}
