﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using Test_Automation_Framework.Framework.Driver;

namespace Test_Automation_Framework.Framework.POM
{
    public class AllPages
    {
        public LoginPage LoginPage { get; set; }
        public RegistrationPage RegistrationPage { get; set; }
        public AdminPage AdminPage { get; set; }
        public ProfilePage ProfilePage { get; set; }
        public WaitManager Wait { get; set; }
        public ConfigReader ConfigFile { get; set; }
        public IWebDriver Browser { get; set; }

        public AllPages()
        {
            ConfigFile = new ConfigReader();
            Browser = DriverManager.GetDriver(ConfigFile.BrowserType);
            Wait = new WaitManager(Browser, ConfigFile.WaitTime);

            RegistrationPage = new RegistrationPage(Browser, Wait);
            LoginPage = new LoginPage(Browser, Wait);
            AdminPage = new AdminPage(Browser, Wait);
            ProfilePage = new ProfilePage(Browser, Wait);
        }
        public void CloseBrowser()
        {
            Browser.Close();
            Browser.Quit();
        }
    }
    }

