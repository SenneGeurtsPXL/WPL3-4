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
    public class LoginTests
    {
        private AllPages AllPages;
        private readonly string[] Emails = { "stage@stage.stage", "wrongmail.aze", "stage@stage.stage", "stage@stage.stage" };
        private readonly string[] Passwords = { "Wrongpassword", "aze", "Stage0221!Stage0221!", "Stage0221!" };

        [SetUp]
        public void setup()
        {
            AllPages = new AllPages();
        }
        [Test]
        public void LoginFormValidationError1()
        {
            //VOOR VOLGENDE WOENSDAG
            AllPages.LoginPage.Login(Emails[0], Passwords[0]);
            Assert.IsTrue(AllPages.LoginPage.GetValidationError() == "Email or password incorrect.");
        }
        [Test]
        public void LoginFormValidationError2()
        {
            AllPages.LoginPage.Login(Emails[1], Passwords[1]);
            Assert.IsTrue(AllPages.LoginPage.GetValidationError() == "Please fill in a correct email-adress.");
        }
        [Test]
        public void LoginFormValidationError3()
        {
            AllPages.LoginPage.Login(Emails[2], Passwords[2]);
            Assert.IsTrue(AllPages.LoginPage.GetValidationError() == "Email or password incorrect.");
        }
        [Test]
        public void LoginFormValidationError4()
        {
            AllPages.LoginPage.Login(Emails[3], Passwords[3]);
        }

        [Test]
        public void TinyVisualBug()
        {
            AllPages.LoginPage.GoToLoginPage();
            if (Convert.ToInt16(AllPages.LoginPage.SignInDivBorder().Substring(0, 1)) <= 2)
            {
                Console.WriteLine(AllPages.LoginPage.SignInDivBorder().Substring(0, 1));
                Assert.IsFalse(Convert.ToInt16(AllPages.LoginPage.SignInDivBorder().Substring(0, 1)) <= 2, "Visual bug: border thickness div > 2px");
            }
        }
        [TearDown]
        public void TearDown()
        {
            AllPages.CloseBrowser();
        }
    }
}
