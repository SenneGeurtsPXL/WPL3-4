using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Framework.Framework.Driver;

namespace Test_Automation_Framework.Framework.POM
{
    public class HomePage
    {
        public string HeaderBackgroundColor { get; set; }
        public IWebElement SearchBar { get; set; }
        public IWebElement? AutoComplete { get; set; }
        public IList<IWebElement>? AutoCompleteOptions { get; set; }
        public IWebElement Navigation { get; set; }
        public IWebElement Header { get; set; }
        public WaitManager Wait { get; set; }
        public IWebDriver Driver { get; set; }

        public Dictionary<string, string> testInput = new Dictionary<string, string>
                    {
                        {"After", "After, After we collided"},
                        {"Sput", "Sputnik"},
                        {"Mul", "Mulan"},
                        {"The sil", "The Silencing"},
                        {"sponge", "The SpongeBob Movie: Sponge on the Run"},
                        {"battlefield", "Battlefield 2025"},
                        {"rogue", "Rogue City, Rogue, Rogue Warfare: Death of a Nation"},
                        {"ALADDIN", "Aladdin"},
                        {"aladdin", "Aladdin"},
                        //{"a", ""},
                        {"intersteller", ""},
                        {"oppenheimer", ""},
                        {"Brightest", ""},
                        {"123", ""},
                        {"       ", ""},
                        {"     Aladdin", ""},
                        {"Aladdin     ", ""},
                        {"&é\"$^^^^^$", ""},
                        {"Jänssens", ""},
                        {"不願做奴隸", ""},
                        {"123456", ""},
                        //{"No InputValue", ""},                      
                        //{"SQL statement", ""}
                    };

        public void GoToPage()
        {
            Driver.Navigate().GoToUrl("https://btube-app.onrender.com/#/");
            Driver.Manage().Window.Maximize();
            Wait.ConfirmPageLoaded();
            Wait.WaitOnLoadingScreen();
            FindElements();
        }
        public HomePage(IWebDriver browser, WaitManager wait)
        {
            this.Driver = browser;
            this.Wait = wait;
        }
        public void FindElements()
        {
            SearchBar = Driver.FindElement(By.CssSelector("input"));
            Navigation = Wait.Wait.Until(ExpectedConditions.ElementExists(By.Id("nav")));
            GetHeaderBackgroundColor();
        }
        public void GetAutocomplete()
        {
            AutoComplete = Driver.FindElement(By.CssSelector(".MuiAutocomplete-option"));
        }
        public void SearchBarClickAndType()
        {
            SearchBar.Click();
            SearchBar.SendKeys("a");
        }
        public void GetAutocompleteOptions()
        {
            AutoCompleteOptions = Driver.FindElements(By.CssSelector(".MuiAutocomplete-option"));
        }
        public void SearchBarClearAndSendKey(string testCase)
        {
            SearchBar.Clear();
            SearchBar.SendKeys(testCase);
            GetAutocompleteOptions();
            CheckForDropDown();
        }
        public void CheckForDropDown()
        {
            IWebElement dropdown = AutoComplete;
            if (dropdown == null)
            {
                Console.WriteLine("Step failed: Dropdown not displayed");
                return;
            }
        }
        public void GetHeaderBackgroundColor()
        {
            HeaderBackgroundColor = Navigation.GetCssValue("background-color");
        }
        public void CheckIfInputsAreCorrect()
        {
            SearchBar.Click();
            foreach (var testCase in testInput)
            {
                bool isMatch = false;

                SearchBarClearAndSendKey(testCase.Key);

                List<string> expectedValues = testCase.Value.Split(',').Select(value => value.Trim()).ToList();

                if (AutoCompleteOptions.Count == 0 && expectedValues.All(string.IsNullOrEmpty))
                {
                    isMatch = true;
                }
                else
                {
                    for (int i = 0; i < AutoCompleteOptions.Count; i++)
                    {
                        string optionText = AutoCompleteOptions[i].Text.Trim();

                        if (AutoCompleteOptions.Count == expectedValues.Count)
                        {
                            if (expectedValues.Any(value => optionText.ToLower().Contains(value.ToLower())))
                            {
                                isMatch = true;
                                break;
                            }
                        }
                        else
                        {
                            isMatch = false;
                            break;

                        }
                    }
                }
                if (!isMatch)
                {
                    Console.WriteLine($"Failed for input '{testCase.Key}': Expected '{testCase.Value}', Actual '{string.Join(", ", AutoCompleteOptions.Select(opt => opt.Text))}'");

                }
            }
        }
    }
}