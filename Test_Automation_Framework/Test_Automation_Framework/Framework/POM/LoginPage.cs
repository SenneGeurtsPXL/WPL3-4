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
        public LoginPage(BrowserType browser)
        {
            var driver = DriverManager.GetDriver(browser);
            WebDriverWait wait = new WebDriverWait(DriverManager.Chrome, TimeSpan.FromSeconds(60));
            EmailInputField = wait.Until(ExpectedConditions.ElementExists(By.Id("SignInEmail")));
            PasswordInputField = wait.Until(ExpectedConditions.ElementExists(By.Id("SignInPassword")));
            LoginButton = wait.Until(ExpectedConditions.ElementExists(By.Id("SignInButtonComplete")));
            CreateAccountLink = wait.Until(ExpectedConditions.ElementExists(By.Id("GoToRegister")));
            SignInForm = wait.Until(ExpectedConditions.ElementExists(By.Id("SignIn")));
            VisualBugDiv = SignInForm.FindElement(By.Id(".child_class"));
        }

    }
}
