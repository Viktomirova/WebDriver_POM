using NUnit.Framework;
using WebDriver_POM.Pages;

namespace WebDriver_POM.Tests
{
    [TestFixture]
    public class ViewStudentsTests : BaseTests
    {
        
        private ViewStudentsPage studentsPage;

        [SetUp]
        public new void SetUp()
        {
            studentsPage = new ViewStudentsPage(driver);
            studentsPage.Open();
        }

        [Test]
        public void Test1_Links()
        {
            studentsPage.Open();
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
            Assert.IsNotNull(students);
            foreach (var item in students)
            {
                Assert.IsNotNull(item);
            }
        }
    }
}
