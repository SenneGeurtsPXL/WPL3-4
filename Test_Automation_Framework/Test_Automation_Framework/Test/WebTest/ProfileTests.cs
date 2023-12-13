using OpenQA.Selenium;
using Test_Automation_Framework.Framework.Driver;
using Test_Automation_Framework.Framework.POM;

namespace Test_Automation_Framework.Test.WebTest;

public class ProfileTests
{
    IWebDriver browser;
    private ProfilePage profilePage;

    [SetUp]
    public void setup()
    {
        browser = DriverManager.Chrome;
        profilePage = new ProfilePage();
        profilePage.goToPage();
    }

    [Test]
    public void testAllInfoDisplayed()
    {
        IReadOnlyCollection<IWebElement> elements = profilePage.getAllPElements();
        Assert.IsTrue(elements.Count >= 9, "not enough elements");
    }

    [Test]
    public void testbutton()
    {
        IWebElement button = profilePage.creditButton();
        Assert.IsNotNull(button, "no credit button found");
    }

    [Test]
    public void testCredits()
    {
        string firstAmount = profilePage.getCredits();
        profilePage.addCredits(15);
        Thread.Sleep(1000);
        string secondAmount = profilePage.getCredits();
        Assert.IsTrue(secondAmount == (int.Parse(firstAmount) + 15).ToString(),
            "credits are not added or wrong amount is added");
    }

    [Test]
    public void testNegativeCredits()
    {
        string firstAmount = profilePage.getCredits();
        profilePage.addCredits(-15);
        Thread.Sleep(1000);
        string secondAmount = profilePage.getCredits();
        Assert.IsFalse(int.Parse(secondAmount) < int.Parse(firstAmount), "Negative credits can be added");
    }
    [Test]
    public void testLoadingScreen()
    {
        IWebElement loadingScreen = profilePage.loadingScreen();
        Assert.IsNotNull(loadingScreen, "no loading screen found");
    }

    [Test]
    public void testButtonHover()
    {
        string beforeColor = profilePage.checkBorderColor(profilePage.creditButton());
        string afterColor = profilePage.checkHoverBorderColor(profilePage.creditButton());
        Assert.IsFalse(beforeColor == afterColor, "border color does not change on hover");
    }

    [Test]
    public void testFirstName()
    {
        string firstName = profilePage.getFirstName();
        Assert.IsNotNull(firstName, "404 the first name is not found");
    }

    //also would need to be moved
    

    [TearDown]
    public void TearDown()
    {
        browser.Close();
        browser.Quit();
    }
}