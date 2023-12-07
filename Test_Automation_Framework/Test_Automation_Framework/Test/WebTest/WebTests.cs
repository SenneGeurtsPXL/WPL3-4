
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Test_Automation_Framework.Framework.Driver;
using Test_Automation_Framework.Framework.POM;

namespace Test_Automation_Framework.Test.WebTest
{
    public class WebTests
    {
        #region Searchbar autocomplete
        #endregion
        #region Check Profile Information
        [Test]
        public void CheckProfileInformation()
        {
            var browser = DriverManager.GetDriver(BrowserType.Chrome);
            
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

            Assert.IsTrue(paragraphElements.Count() >= 9, "not enough info on profile page");

            browser.Close();
            browser.Quit();
        }
        #endregion
    }
}
