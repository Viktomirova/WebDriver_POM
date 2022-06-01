using OpenQA.Selenium;

using System.Collections.ObjectModel;
using System.Linq;

namespace WebDriver_POM.Pages
{
    public class ViewStudentsPage : BasePage
    {
        public ViewStudentsPage(IWebDriver driver) 
            : base(driver)
        {
        }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/students";

        public ReadOnlyCollection<IWebElement> RegisteredStudents => 
            driver.FindElements(By.CssSelector("body > ul > li"));

        public string[] GetRegisteredStudents()
        {
            string[] studentsList = this.RegisteredStudents.Select(s => s.Text).ToArray();
            return studentsList;
        }
    }
}
