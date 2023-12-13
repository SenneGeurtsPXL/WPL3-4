using OpenQA.Selenium;
using Test_Automation_Framework.Framework.Driver;
using Test_Automation_Framework.Framework.POM;

namespace Test_Automation_Framework.Test.WebTest;

public class ProfileTests
{
    public AllPages AllPages { get; set; }
    [SetUp]
    public void setup()
    {
        //senne dit is de juiste
        AllPages = new AllPages();
        AllPages.ProfilePage.goToPage();
    }

    [Test]
    public void testAllInfoDisplayed()
    {
        IReadOnlyCollection<IWebElement> elements = AllPages.ProfilePage.getAllPElements();
        Assert.IsTrue(elements.Count >= 9, "not enough elements");
    }

    [Test]
    public void testbutton()
    {
        IWebElement button = AllPages.ProfilePage.creditButton();
        Assert.IsNotNull(button, "no credit button found");
    }

    [Test]
    public void testCredits()
    {
        string firstAmount = AllPages.ProfilePage.getCredits();
        AllPages.ProfilePage.addCredits(15);
        Thread.Sleep(1000);
        string secondAmount = AllPages.ProfilePage.getCredits();
        Assert.IsTrue(secondAmount == (int.Parse(firstAmount) + 15).ToString(),
            "credits are not added or wrong amount is added");
    }

    [Test]
    public void testNegativeCredits()
    {
        string firstAmount = AllPages.ProfilePage.getCredits();
        AllPages.ProfilePage.addCredits(-15);
        Thread.Sleep(1000);
        string secondAmount = AllPages.ProfilePage.getCredits();
        Assert.IsFalse(int.Parse(secondAmount) < int.Parse(firstAmount), "Negative credits can be added");
    }
    [Test]
    public void testLoadingScreen()
    {
        IWebElement loadingScreen = AllPages.ProfilePage.loadingScreen();
        Assert.IsNotNull(loadingScreen, "no loading screen found");
    }

    [Test]
    public void testButtonHover()
    {
        string beforeColor = AllPages.ProfilePage.checkBorderColor(AllPages.ProfilePage.creditButton());
        string afterColor = AllPages.ProfilePage.checkHoverBorderColor(AllPages.ProfilePage.creditButton());
        Assert.IsFalse(beforeColor == afterColor, "border color does not change on hover");
    }

    [Test]
    public void testFirstName()
    {
        string firstName = AllPages.ProfilePage.getFirstName();
        Assert.IsNotNull(firstName, "404 the first name is not found");
    }

    //also would need to be moved


    [TearDown]
    public void TearDown()
    {
        AllPages.CloseBrowser();
    }
}