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
        public WaitManager Wait { get; set; }
        public IWebDriver Driver { get; set; }
        public LoginPage(IWebDriver browser, WaitManager wait)
        {
            Driver = browser;
            Wait = wait;
        }
        public void GoToLoginPage()
        {
            Driver.Navigate().GoToUrl("https://btube-app.onrender.com/#/login");
            Driver.Manage().Window.Maximize();
            Wait.ConfirmPageLoaded();

        }
        public void GetElements()
        {
            EmailInputField = Wait.Wait.Until(ExpectedConditions.ElementExists(By.Id("SignInEmail")));
            PasswordInputField = Wait.Wait.Until(ExpectedConditions.ElementExists(By.Id("SignInPassword")));
            LoginButton = Wait.Wait.Until(ExpectedConditions.ElementExists(By.Id("SignInButtonComplete")));
            CreateAccountLink = Wait.Wait.Until(ExpectedConditions.ElementExists(By.Id("GoToRegister")));
            SignInForm = Wait.Wait.Until(ExpectedConditions.ElementExists(By.Id("SignIn")));
            VisualBugDiv = Driver.FindElement(By.CssSelector("#SignIn > div:first-child"));
        }
        public void Login(string email, string password)
        {
            GoToLoginPage();
            Wait.WaitOnLoadingScreen();
            GetElements();
            EmailInputField.SendKeys(email);
            PasswordInputField.SendKeys(password);
            LoginButton.Click();
        }
        public void LoginAsAdmin()
        {
            GoToLoginPage();
            Wait.WaitOnLoadingScreen();
            GetElements();
            EmailInputField.SendKeys("Stage@stage.stage");
            PasswordInputField.SendKeys("Stage0221!");
            LoginButton.Click();
        }
        public string GetValidationError()
        {
            ValidationError = Wait.Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("code")));
            if (ValidationError.Text != "")
            {
                return ValidationError.Text;

            }
            else
            {
                return "No validation error on login from";
            }
        }
        public string SignInDivBorder()
        {
            GetElements();
            return SignInForm.GetCssValue("border");
        }
        public void ClickAdminButton()
        {
            AdminButton = Wait.Wait.Until(ExpectedConditions.ElementExists(By.CssSelector("a[href='#/admin/bugs']")));
            AdminButton.Click();
        }
        public bool HasIsRequiredType()
        {
            bool isRequired = EmailInputField.GetAttribute("required") != null;

            if (isRequired)
            {
                Console.WriteLine("The input has the 'required' attribute.");
                return true;
            }
            else
            {
                Console.WriteLine("The input does not have the 'required' attribute.");
                return false;

            }
        }
    }
}
