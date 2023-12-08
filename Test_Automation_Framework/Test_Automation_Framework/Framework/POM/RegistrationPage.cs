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
    public class RegistrationPage
    {
        public IWebElement FirstNameInputField { get; set; }
        public IWebElement LastNameInputField { get; set; }
        public IWebElement EmailInputField { get; set; }
        public IWebElement PasswordInputField { get; set; }
        public IWebElement RePasswordInputField { get; set; }
        public IWebElement RegisterButton { get; set; }
        public IWebElement SignInLink { get; set; }
        public IWebElement ValidationError { get; set; }
        public WebDriverWait Wait { get; set; }
        public IWebDriver Driver { get; set; }


        public RegistrationPage(IWebDriver browser)
        {
            Driver = browser;
            browser.Navigate().GoToUrl("https://btube-app.onrender.com/#/register");
            browser.Navigate().Refresh();
            browser.Manage().Window.Maximize();
            browser.Navigate().Refresh();
            Thread.Sleep(10000);
            Wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60));
            FirstNameInputField = Wait.Until(ExpectedConditions.ElementExists(By.Id("RegisterFirstName")));
            LastNameInputField = Wait.Until(ExpectedConditions.ElementExists(By.Id("RegisterLastName")));
            EmailInputField = Wait.Until(ExpectedConditions.ElementExists(By.Id("RegisterEmail")));
            PasswordInputField = Wait.Until(ExpectedConditions.ElementExists(By.Id("RegisterPassword")));
            RePasswordInputField = Wait.Until(ExpectedConditions.ElementExists(By.Id("RegisterRePassword")));
            RegisterButton = Wait.Until(ExpectedConditions.ElementExists(By.Id("RegisterButtonComplete")));
            SignInLink = Wait.Until(ExpectedConditions.ElementExists(By.Id("GoToRegister")));
        }
        public void Register(string firstName,string lastName,string email,string password,string rePassword)
        {
            FirstNameInputField.SendKeys(firstName);
            LastNameInputField.SendKeys(lastName);
            EmailInputField.SendKeys(email);
            PasswordInputField.SendKeys(password);
            RePasswordInputField.SendKeys(rePassword);
            RegisterButton.Click();
        }
        public string GetValidationError()
        {
            ValidationError = Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("code")));
            return ValidationError.Text;

        }
    }
}
