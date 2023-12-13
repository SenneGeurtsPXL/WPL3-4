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
        public WaitManager Wait { get; set; }
        public IWebDriver Driver { get; set; }
        public RegistrationPage(IWebDriver browser, WaitManager wait)
        {
            Driver = browser;
            Wait = wait;
        }
        public void GetElements()
        {
            FirstNameInputField = Wait.Wait.Until(ExpectedConditions.ElementExists(By.Id("RegisterFirstName")));
            LastNameInputField = Wait.Wait.Until(ExpectedConditions.ElementExists(By.Id("RegisterLastName")));
            EmailInputField = Wait.Wait.Until(ExpectedConditions.ElementExists(By.Id("RegisterEmail")));
            PasswordInputField = Wait.Wait.Until(ExpectedConditions.ElementExists(By.Id("RegisterPassword")));
            RePasswordInputField = Wait.Wait.Until(ExpectedConditions.ElementExists(By.Id("RegisterRePassword")));
            RegisterButton = Wait.Wait.Until(ExpectedConditions.ElementExists(By.Id("RegisterButtonComplete")));
            SignInLink = Wait.Wait.Until(ExpectedConditions.ElementExists(By.Id("GoToRegister")));
        }
        public void GoToRegistrationPage()
        {
            Driver.Navigate().GoToUrl("https://btube-app.onrender.com/#/register");
            Wait.WaitOnLoadingScreen();
        }
        public void Register(string firstName,string lastName,string email,string password,string rePassword)
        {
            GoToRegistrationPage();
            GetElements();
            FirstNameInputField.SendKeys(firstName);
            LastNameInputField.SendKeys(lastName);
            EmailInputField.SendKeys(email);
            PasswordInputField.SendKeys(password);
            RePasswordInputField.SendKeys(rePassword);
            RegisterButton.Click();
        }
        public string GetValidationError()
        {
            ValidationError = Wait.Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("code")));
            return ValidationError.Text;

        }
    }
}
