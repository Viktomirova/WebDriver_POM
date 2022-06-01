using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using WebDriver_POM.Pages;

namespace WebDriver_POM.Tests
{
    [TestFixture]
    public class ViewStudentsTests : BaseTests
    {
        
        private ViewStudentsPage studentsPage;

        [SetUp]
        public void SetUp()
        {
            studentsPage = new ViewStudentsPage(driver);
            studentsPage.Open();
        }

        [Test]
        public void Test1_Links()
        {
            studentsPage.ViewStudentsLink.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
            Assert.AreEqual(studentsPage.GetPageUrl(), driver.Url);
        }

        [Test]
        public void Test2_Title()
        {
            Assert.AreEqual(studentsPage.GetPageHeading(), "Registered Students");
        }

        [Test]
        public void Test3_Content()
        {
            Assert.AreEqual("Students", studentsPage.GetPageTitle());
        }

        [Test]
        public void Test4_ListOfStudents()
        {
            var students = studentsPage.GetRegisteredStudents();
            foreach (var item in students)
            {
                Assert.IsTrue(item.IndexOf("(") > 0);
                Assert.IsTrue(item.IndexOf(")") == item.Length - 1);
            }
        }
    }
}
