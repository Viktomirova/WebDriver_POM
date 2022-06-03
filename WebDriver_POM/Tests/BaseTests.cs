using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriver_POM.Tests
{
    public class BaseTests
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.driver = new ChromeDriver();
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
    }
}
