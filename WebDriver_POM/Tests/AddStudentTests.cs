using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using WebDriver_POM.Pages;

namespace WebDriver_POM.Tests
{
    public class AddStudentTests
    {
        private IWebDriver driver;
        private AddStudentPage page;

        [SetUp]
        public void SetUp()
        {
            this.driver = new ChromeDriver();
            this.page = new AddStudentPage(driver);
            page.Open();
        }

        [TearDown]
        public void ShutDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test1_Links()
        {
            Assert.AreEqual(page.GetPageUrl(), driver.Url);
            Assert.That(driver.FindElements(By.CssSelector("body > ul")), Is.Not.Null);
        }

        [Test]
        public void Test2_Title()
        {
            Assert.AreEqual(page.GetPageHeading(), "Register New Student");
        }

        [Test]
        public void Test3_TryToAddWithEmptyFields()
        {
            IWebElement addButton = driver.FindElement(By.CssSelector("body > form > button"));
            addButton.Click();
            string atualElement = driver.FindElement(By.CssSelector("body > div")).Text;
            Assert.That(atualElement, Is.EqualTo(page.GetErrorMsg()));
        }

        [TestCase ("koko", "koko@mail.co")]
        public void Test4_AddValidStudent(string name, string mail)
        {
            HomePage homePage = new HomePage(driver);
            homePage.Open();
            int count = homePage.GetStudentCount();
            page.Open();
            page.AddStudent(name, mail);
            homePage.Open();
            int newCount = homePage.GetStudentCount();
            Assert.That(count + 1, Is.EqualTo(newCount));
        }
    }
}
