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
        public void HardCodedTest()
        {
        var browser = DriverManager.GetDriver(BrowserType.Chrome);


            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("BROWSER");
            Console.WriteLine("--------------------------------------------------------------------------------");

            browser.Navigate().GoToUrl("https://btube-app.onrender.com/#/");
            browser.Navigate().Refresh();
            browser.Manage().Window.Maximize();

            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60));

            browser.Navigate().Refresh();
            Thread.Sleep(10000);

            IWebElement signInButton = wait.Until(ExpectedConditions.ElementExists(By.Id("SignInButton")));
            signInButton.Click();

            IWebElement userName = wait.Until(ExpectedConditions.ElementExists(By.Id("SignInEmail")));
            IWebElement paswoord = wait.Until(ExpectedConditions.ElementExists(By.Id("SignInPassword")));
            userName.SendKeys("stageadmin@stageadmin.stageadmin");
            paswoord.SendKeys("StageAdmin0221!");

            IWebElement signInButtonComplete = wait.Until(ExpectedConditions.ElementExists(By.Id("SignInButtonComplete")));
            signInButtonComplete.Click();


            IWebElement profileButton = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("a[href='#/profile'] button#OrdersPageButton"))); 
            profileButton.Click();

            Thread.Sleep(2000);

            wait.Until(ExpectedConditions.ElementExists(By.TagName("p")));
            IReadOnlyCollection<IWebElement> paragraphElements = browser.FindElements(By.TagName("p"));

            foreach (IWebElement paragraph in paragraphElements)
            {
                if (paragraph.Text.Length > 0)
                {
                    Console.WriteLine("JA" + paragraph.Text.ToString());

                }

            }

            Thread.Sleep(7000);

            browser.Close();

            browser.Quit();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("BROWSER" + "einde");
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
    }
}
