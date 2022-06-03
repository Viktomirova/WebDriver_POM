using OpenQA.Selenium;

namespace WebDriver_POM.Pages
{
    public class AddStudentPage : HomePage
    {

        public AddStudentPage(IWebDriver driver)
            : base(driver)
        {
        }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/add-student";

        IWebElement NameField => driver.FindElement(By.Id("name"));

        IWebElement EmailField => driver.FindElement(By.Id("email"));

        IWebElement AddButton => driver.FindElement(By.CssSelector("body > form > button"));

        IWebElement ElementErrorMsg => driver.FindElement(By.CssSelector("body > div"));

        public void AddStudent(string name, string email)
        {
            this.NameField.SendKeys(name);
            this.EmailField.SendKeys(email);
            this.AddButton.Click();
        }

        public string GetErrorMsg()
        {
            return ElementErrorMsg.Text;
        }
    }
}
