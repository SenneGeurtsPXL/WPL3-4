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
        public IWebElement ValidationError { get; set; }
        public WebDriverWait Wait { get; set; }
        public LoginPage(IWebDriver browser)
        {
            browser.Navigate().GoToUrl("https://btube-app.onrender.com/#/login");
            browser.Navigate().Refresh();
            browser.Manage().Window.Maximize();
            browser.Navigate().Refresh();
            Thread.Sleep(10000);
            Wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60));
            EmailInputField = Wait.Until(ExpectedConditions.ElementExists(By.Id("SignInEmail")));
            PasswordInputField = Wait.Until(ExpectedConditions.ElementExists(By.Id("SignInPassword")));
            LoginButton = Wait.Until(ExpectedConditions.ElementExists(By.Id("SignInButtonComplete")));
            CreateAccountLink = Wait.Until(ExpectedConditions.ElementExists(By.Id("GoToRegister")));
            SignInForm = Wait.Until(ExpectedConditions.ElementExists(By.Id("SignIn")));
            //VisualBugDiv = SignInForm.FindElement(By.Id(".child_class"));
            //ValidationError = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("code")));
        }
        public string GetValidationError()
        {
            ValidationError = Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("code")));
            return ValidationError.Text;

        }

    }
}
