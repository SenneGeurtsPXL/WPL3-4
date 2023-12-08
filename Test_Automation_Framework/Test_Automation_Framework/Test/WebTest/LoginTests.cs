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
        IWebDriver browser;
        private LoginPage loginPage;
        private string[] emails = { "stage@stage.stage", "wrongmail.aze", "stage@stage.stage", "stage@stage.stage" };
        private string[] passwords = { "Wrongpassword", "aze", "Stage0221!Stage0221!", "Stage0221!" };
        [SetUp]
        public void setup()
        {
            browser = DriverManager.Chrome;
            loginPage = new LoginPage(browser);
        }
        [Test]
        public void LoginFormValidationError1()
        {
            loginPage.Login(emails[0], passwords[0]);
            Assert.IsTrue(loginPage.GetValidationError() == "Email or password incorrect.");
        }
        [Test]
        public void LoginFormValidationError2()
        {
            loginPage.Login(emails[1], passwords[1]);
            Assert.IsTrue(loginPage.GetValidationError() == "Please fill in a correct email-adress.");
        }
        [Test]
        public void LoginFormValidationError3()
        {
            loginPage.Login(emails[2], passwords[2]);
            Assert.IsTrue(loginPage.GetValidationError() == "Email or password incorrect.");
        }
        [Test]
        public void LoginFormValidationError4()
        {
            loginPage.Login(emails[3], passwords[3]);
            loginPage.GoToLogin();
            loginPage.ClickAdminButton();
            
        }

        [Test]
        public void TinyVisualBug()
        {
            Console.WriteLine(loginPage.SignInDivBorder());
            if (Convert.ToInt16(loginPage.SignInDivBorder().Substring(0, 1)) <= 2)
            {
                Console.WriteLine(loginPage.SignInDivBorder().Substring(0, 1));
                Assert.IsFalse(Convert.ToInt16(loginPage.SignInDivBorder().Substring(0, 1)) <= 2, "Visual bug: border thickness div > 2px");
            }
        }
        [TearDown]
        public void TearDown()
        {
            browser.Close();
            browser.Quit();
        }

    }
}
