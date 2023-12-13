﻿using OpenQA.Selenium;
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
        private AllPages allPages;
        private string[] emails = { "stage@stage.stage", "wrongmail.aze", "stage@stage.stage", "stage@stage.stage" };
        private string[] passwords = { "Wrongpassword", "aze", "Stage0221!Stage0221!", "Stage0221!" };

        [SetUp]
        public void setup()
        {
            allPages = new AllPages();
        }
        [Test]
        public void LoginFormValidationError1()
        {
            //VOOR VOLGENDE WOENSDAG
            allPages.LoginPage.Login(emails[0], passwords[0]);
            Assert.IsTrue(allPages.LoginPage.GetValidationError() == "Email or password incorrect.");
        }
        [Test]
        public void LoginFormValidationError2()
        {
            allPages.LoginPage.Login(emails[1], passwords[1]);
            Assert.IsTrue(allPages.LoginPage.GetValidationError() == "Please fill in a correct email-adress.");
        }
        [Test]
        public void LoginFormValidationError3()
        {
            allPages.LoginPage.Login(emails[2], passwords[2]);
            Assert.IsTrue(allPages.LoginPage.GetValidationError() == "Email or password incorrect.");
        }
        [Test]
        public void LoginFormValidationError4()
        {
            allPages.LoginPage.Login(emails[3], passwords[3]);
        }

        [Test]
        public void TinyVisualBug()
        {
            allPages.LoginPage.GoToLoginPage();
            if (Convert.ToInt16(allPages.LoginPage.SignInDivBorder().Substring(0, 1)) <= 2)
            {
                Console.WriteLine(allPages.LoginPage.SignInDivBorder().Substring(0, 1));
                Assert.IsFalse(Convert.ToInt16(allPages.LoginPage.SignInDivBorder().Substring(0, 1)) <= 2, "Visual bug: border thickness div > 2px");
            }
        }
        [TearDown]
        public void TearDown()
        {
            allPages.Browser.Close();
            allPages.Browser.Quit();
        }
    }
}
