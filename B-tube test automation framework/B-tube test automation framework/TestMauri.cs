using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using B_tube_test_automation_framework.Web_applicatie.Driver_Manager;

namespace B_tube_test_automation_framework
{
    public class TestMauri
    {
        //aanmaken webdriver
        //setup van driver

        [Test]
        public static void HardCodedTest()
        {
                var browser = DriverManager.Chrome;
                browser.Navigate().GoToUrl("https://btube-app.onrender.com/#/");

                browser.Navigate().Refresh();
                browser.Manage().Window.Maximize();

                WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60));

                browser.Navigate().Refresh();
                Thread.Sleep(5000);


                IWebElement signInButton = wait.Until(ExpectedConditions.ElementExists(By.Id("SignInButton")));
                signInButton.Click();


                IWebElement userName = wait.Until(ExpectedConditions.ElementExists(By.Id("SignInEmail")));
                IWebElement paswoord = wait.Until(ExpectedConditions.ElementExists(By.Id("SignInPassword")));


                userName.SendKeys("stageadmin@stageadmin.stageadmin");
                paswoord.SendKeys("StageAdmin0221!");

                IWebElement signInButtonComplete = wait.Until(ExpectedConditions.ElementExists(By.Id("SignInButtonComplete")));
                signInButtonComplete.Click();

                Thread.Sleep(10000);


                browser.Quit();
            }


            

        }
    }
}
