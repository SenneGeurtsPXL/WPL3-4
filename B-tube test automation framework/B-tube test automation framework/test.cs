using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
            driver.Quit();
            
        }

    }
}