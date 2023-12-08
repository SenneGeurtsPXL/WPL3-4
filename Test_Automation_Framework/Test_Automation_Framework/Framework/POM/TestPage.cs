﻿using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Framework.Framework.POM
{
    public class TestPage
    {
        public IWebElement EmailInputField { get; set; }
        public IWebElement PasswordInputField { get; set; }
        public IWebElement LoginButton { get; set; }
        public IWebElement CreateAccountLink { get; set; }
        public IWebElement SignInForm { get; set; }
        public IWebElement VisualBugDiv { get; set; }
        public IWebElement SignInDiv { get; set; }
        public IWebElement ValidationError { get; set; }
        public WebDriverWait Wait { get; set; }
        public TestPage(IWebDriver browser, WebDriverWait wait)
        {
            browser.Navigate().GoToUrl("https://btube-app.onrender.com/#/login");
            browser.Manage().Window.Maximize();
            browser.Navigate().Refresh();
            browser.Navigate().Refresh();
            Thread.Sleep(10000);
            Wait = wait;
            EmailInputField = Wait.Until(ExpectedConditions.ElementExists(By.Id("SignInEmail")));
            PasswordInputField = Wait.Until(ExpectedConditions.ElementExists(By.Id("SignInPassword")));
            LoginButton = Wait.Until(ExpectedConditions.ElementExists(By.Id("SignInButtonComplete")));
            CreateAccountLink = Wait.Until(ExpectedConditions.ElementExists(By.Id("GoToRegister")));
            SignInForm = Wait.Until(ExpectedConditions.ElementExists(By.Id("SignIn")));
            VisualBugDiv = browser.FindElement(By.CssSelector("#SignIn > div:first-child"));

            //ValidationError = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("code")));
        }
        public void Login(string email, string password)
        {
            EmailInputField.SendKeys(email);
            PasswordInputField.SendKeys(password);
            LoginButton.Click();
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
    }
}