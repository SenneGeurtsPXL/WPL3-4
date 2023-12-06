using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace B_tube_test_automation_framework
{
    [TestFixture]
    public static class test
    {
        //aanmaken webdriver
        //setup van driver

        [Test]
        public static void HardCodedTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://btube-app.onrender.com/#/");
            
            driver.Navigate().Refresh();
            driver.Manage().Window.Maximize();


            
            WebDriverWait wait = new WebDriverWait (driver, TimeSpan.FromSeconds(60));

            driver.Navigate().Refresh();
            Thread.Sleep(10000);



            IWebElement signInButton = wait.Until(ExpectedConditions.ElementExists(By.Id("SignInButton")));
            signInButton.Click();




            IWebElement userName = wait.Until(ExpectedConditions.ElementExists(By.Id ("SignInEmail")));
            IWebElement paswoord = wait.Until(ExpectedConditions.ElementExists(By.Id ("SignInPassword")));


            userName.SendKeys("stageadmin@stageadmin.stageadmin");
            paswoord.SendKeys("StageAdmin0221!");
            
            IWebElement signInButtonComplete = wait.Until(ExpectedConditions.ElementExists(By.Id("SignInButtonComplete")));
            signInButtonComplete.Click();

            Thread.Sleep(10000);




            driver.Quit();
            
        }

    }
}