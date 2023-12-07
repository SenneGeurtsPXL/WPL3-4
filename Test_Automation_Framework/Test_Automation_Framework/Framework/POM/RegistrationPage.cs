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
        public RegistrationPage(BrowserType browser)
        {
            var driver = DriverManager.GetDriver(browser);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            FirstNameInputField = wait.Until(ExpectedConditions.ElementExists(By.Id("RegisterFirstName")));
            LastNameInputField = wait.Until(ExpectedConditions.ElementExists(By.Id("RegisterLastName")));
            EmailInputField = wait.Until(ExpectedConditions.ElementExists(By.Id("RegisterEmail")));
            PasswordInputField = wait.Until(ExpectedConditions.ElementExists(By.Id("RegisterPassword")));
            RePasswordInputField = wait.Until(ExpectedConditions.ElementExists(By.Id("RegisterRePassword")));
            RegisterButton = wait.Until(ExpectedConditions.ElementExists(By.Id("RegisterButtonComplete")));
            SignInLink = wait.Until(ExpectedConditions.ElementExists(By.Id("GoToRegister")));
        }
    }
}
