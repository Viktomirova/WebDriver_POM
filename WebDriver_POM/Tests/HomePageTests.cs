using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using WebDriver_POM.Pages;

namespace WebDriver_POM.Tests
{
    [TestFixture]
    public class HomePageTests : BaseTests
    {
        
        private HomePage homePage;

        [SetUp]
        public new void SetUp()
        {
            homePage = new HomePage(driver);
            homePage.Open();
        }

        [Test]
        public void Test1_Links()
        {
            homePage.HomeLink.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());
            Assert.AreEqual(homePage.GetPageUrl(), driver.Url);
        }

        [Test]
        public void Test2_Content()
        {
            Assert.AreEqual(homePage.GetPageHeading(), "Students Registry");
        }

        [Test]
        public void Test3_StudentCount()
        {
            Assert.DoesNotThrow(() => homePage.GetStudentCount());
        }
    }
}
