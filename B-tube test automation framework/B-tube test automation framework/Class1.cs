using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_tube_test_automation_framework
{
    public class Class1
    {
        //aanmaken webdriver
        public IWebDriver driver;
        //setup van driver
        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
        }
        //test die wordt uitgevoerd
        [Test]
        public void hardCodedTest()
        {
            driver.Url = "https://btube-app.onrender.com/#/";
        }
        //afsluiten van de test
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
