using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

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
            driver.Manage().Window.Maximize();
            driver.Navigate().Refresh();

            
            

            WebDriverWait wait = new WebDriverWait (driver, TimeSpan.FromSeconds(60));
            IWebElement signInButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("RegisterButton")));

            signInButton.Click();

            IWebElement userName = wait.Until(ExpectedConditions.ElementExists(By.Id ("SignInEmail")));
            IWebElement paswoord = wait.Until(ExpectedConditions.ElementExists(By.Id ("SignInPasswoord")));


            userName.SendKeys("stageadmin@stageadmin.stageadmin");
            paswoord.SendKeys("StageAdmin0221!");






            driver.Quit();
            
        }

    }
}