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
        private AllPages AllPages;
        private string FirstName = "stage";
        private string LastName = "stage";
        private string[] Emails = { "random@random.random" , "stage@stage.stage" , "stage23@stage23.stage23" };
        private string Password = "Stage0221!";
        private string[] RePassword = { "Stage0221!Stage0221!", "Stage0221!", "Stage0221!" };
        [SetUp]
        public void Setup()
        {
            AllPages = new AllPages();
        }
        [Test]
        public void RegistrationFormValidationError1()
        {
            AllPages.RegistrationPage.Register(FirstName, LastName, Emails[0], Password, RePassword[0]);
            Assert.True(AllPages.RegistrationPage.GetValidationError() == "Passwords don't match.");
        }
        [Test]
        public void RegistrationFormValidationError2()
        {
            AllPages.RegistrationPage.Register(FirstName, LastName, Emails[1], Password, RePassword[1]);
            Assert.True(AllPages.RegistrationPage.GetValidationError() == "Account is already registered.");
        }
        [Test]  
        public void RegistrationFormValidationError3()
        {
            AllPages.RegistrationPage.Register("ditiseentest", "ditiseenteste", "Correcteemail@email.be", "TestTest123!", "TestTest123!");
            AllPages.LoginPage.LoginAsAdmin();
            AllPages.LoginPage.ClickAdminButton();
            AllPages.AdminPage.GoToUsersTab();
            Thread.Sleep(2000);
            AllPages.AdminPage.DeleteLastCreatedUser();
            Thread.Sleep(2000);

        }
        [TearDown]
        public void TearDown()
        {
            AllPages.CloseBrowser();
        }
    }
}
