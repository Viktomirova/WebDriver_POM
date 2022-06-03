using OpenQA.Selenium;
using WebDriver_POM.Interfaces;

namespace WebDriver_POM.Pages
{
    public class HomePage : IHomePage
    {
        public HomePage(IWebDriver driver) 
            : base(driver)
        {
        }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/";

        public IWebElement StudentCount => driver.FindElement(By.CssSelector("body > p > b"));

        public int GetStudentCount()
        {
            return int.Parse(StudentCount.Text);
        }
    }
}
