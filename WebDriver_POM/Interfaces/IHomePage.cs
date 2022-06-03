using OpenQA.Selenium;
using System;

namespace WebDriver_POM.Interfaces
{
    public class IHomePage
    {
        protected readonly IWebDriver driver;

        public IHomePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
        }

        public virtual string PageUrl { get; }
        public IWebElement HomeLink => driver.FindElement(By.LinkText("Home"));
        public IWebElement ViewStudentsLink => driver.FindElement(By.LinkText("View Students"));
        public IWebElement AddStudentLink => driver.FindElement(By.LinkText("Add Student"));
        public IWebElement PageHeading => driver.FindElement(By.CssSelector("body > h1"));

        public void Open()
        {
            driver.Navigate().GoToUrl(this.PageUrl);
        }

        public bool IsOpen()
        {
            if (driver.Url != this.PageUrl)
            {
                return false;
            }
            return true;
        }

        public string GetPageUrl()
        {
            return driver.Url;
        }

        public string GetPageHeading()
        {
            return PageHeading.Text;
        }
        
        public string GetPageTitle()
        {
            return driver.Title;
        }
    }
}
