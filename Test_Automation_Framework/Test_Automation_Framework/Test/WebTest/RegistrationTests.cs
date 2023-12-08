using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Framework.Framework.Driver;
using Test_Automation_Framework.Framework.POM;

namespace Test_Automation_Framework.Test.WebTest
{
    public class RegistrationTests
    {
        IWebDriver browser;
        private RegistrationPage registrationPage;
        private LoginPage loginPage;
        private string firstName = "stage";
        private string lastName = "stage";
        private string[] emails = { "random@random.random" , "stage@stage.stage" , "stage23@stage23.stage23" };
        private string password = "Stage0221!";
        private string[] rePasswords = { "Stage0221!Stage0221!", "Stage0221!", "Stage0221!" };
        [SetUp]
        public void Setup()
        {
            registrationPage = new RegistrationPage(browser);
            loginPage = new LoginPage(browser);
        }
        [Test]
        public void RegistrationFormValidationError1()
        {
            registrationPage.Register(firstName, lastName, emails[0], password, rePasswords[0]);
            Assert.True(registrationPage.GetValidationError() == "Passwords don't match.");
        }
        [Test]
        public void RegistrationFormValidationError2()
        {
            registrationPage.Register(firstName, lastName, emails[1], password, rePasswords[1]);
            Assert.True(registrationPage.GetValidationError() == "Account is already registered.");
            //commentaar schrijven
            //loggen
            //zoveel mogelijk foutieve dingen ingeven spaties komma's en al
            //wait moet een global zijn
            //allpages aanmaken
            //config files met default settings
            //stream reader maken en al de deafult data
            //close en quit global maken

        }
        [Test]  
        public void RegistrationFormValidationError3()
        {
            //registrationPage.Register(firstName, lastName, emails[1], password, rePasswords[1]);
        }
        [TearDown]
        public void TearDown()
        {
            browser.Close();
            browser.Quit();
        }
    }
}
