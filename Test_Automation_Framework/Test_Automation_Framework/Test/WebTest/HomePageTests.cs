using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Framework.Framework.POM;

namespace Test_Automation_Framework.Test.WebTest
{
    public class HomePageTests
    {
        public AllPages AllPages { get; set; }
        [SetUp]
        public void setup()
        {
            AllPages = new AllPages();
            AllPages.HomePage.GoToPage();
        }

        [Test]
        public void TestS1()
        {

            AllPages.HomePage.SearchBarClickAndType();

            Assert.Pass();
        }
        [Test]
        public void TestS3()
        {

            string navigationColor = AllPages.HomePage.Navigation.GetCssValue("background-color");
            Assert.AreEqual("rgba(20, 20, 20, 1)", navigationColor);

        }
        [Test]
        public void TestS4()
        {
            AllPages.HomePage.GetAutocomplete();
            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            AllPages.CloseBrowser();
        }
    }
}
