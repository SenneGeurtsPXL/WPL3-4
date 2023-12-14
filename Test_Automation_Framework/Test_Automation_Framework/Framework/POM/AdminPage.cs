using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using Test_Automation_Framework.Framework.Driver;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;

namespace Test_Automation_Framework.Framework.POM
{
    public class AdminPage
    {
        public WaitManager Wait;
        public IWebDriver Browser { get; set; }
        public IWebDriver Driver;
        public IWebElement Table { get; set; }
        public AdminPage(IWebDriver browser,WaitManager wait) 
        {
            Driver = browser;
            Wait = wait;
        }
        public void GoToUsersTab()
        {
            Driver.Navigate().GoToUrl("https://btube-app.onrender.com/#/admin/users");
        }
        //gets all users from the list
        public void GetAllUsers() {
            Wait.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"root\"]/div/div[2]/div[3]/div/main/div[2]/div/tbody/tr[1]/th")));
            IReadOnlyCollection<IWebElement> allTrElements = Driver.FindElements(By.TagName("tr"));
        }
        //looks in the last for the delete button wich is the last svg on the page
        public void DeleteLastCreatedUser()
        {
            Wait.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"root\"]/div/div[2]/div[3]/div/main/div[2]/div/tbody/tr[1]/th")));
            IReadOnlyCollection<IWebElement> allSvgElements = Driver.FindElements(By.TagName("svg"));
            IWebElement Svg = allSvgElements.Last();
            Svg.Click();
        }
    }
}
