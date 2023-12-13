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
        private AllPages allPages;
        private string firstName = "stage";
        private string lastName = "stage";
        private string[] emails = { "random@random.random" , "stage@stage.stage" , "stage23@stage23.stage23" };
        private string password = "Stage0221!";
        private string[] rePasswords = { "Stage0221!Stage0221!", "Stage0221!", "Stage0221!" };
        [SetUp]
        public void Setup()
        {
            allPages = new AllPages();
        }
        [Test]
        public void RegistrationFormValidationError1()
        {
            allPages.RegistrationPage.Register(firstName, lastName, emails[0], password, rePasswords[0]);
            Assert.True(allPages.RegistrationPage.GetValidationError() == "Passwords don't match.");
        }
        [Test]
        public void RegistrationFormValidationError2()
        {
            allPages.RegistrationPage.Register(firstName, lastName, emails[1], password, rePasswords[1]);
            Assert.True(allPages.RegistrationPage.GetValidationError() == "Account is already registered.");
        }
        [Test]  
        public void RegistrationFormValidationError3()
        {
            //registrationPage.Register(firstName, lastName, emails[1], password, rePasswords[1]);
            allPages.LoginPage.LoginAsAdmin();
            Thread.Sleep(3000);
            allPages.LoginPage.ClickAdminButton();
            Thread.Sleep(3000);
        }
        [TearDown]
        public void TearDown()
        {
            allPages.browser.Close();
            allPages.browser.Quit();
        }
    }
}
