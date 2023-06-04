using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryApp_Selenium_POM.Pages
{
    public class ViewStudentsPage : BasePage
    {
        private readonly IWebDriver driver;

        public ViewStudentsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public override string pageUrl => "https://studentregistry.softuniqa.repl.co/students";
        public ReadOnlyCollection<IWebElement> ListItemsStudents => driver.FindElements(By.CssSelector("body > ul > li"));

        public string[] GetRegisteredStudents()
        {

            var elementsStudents = this.ListItemsStudents.Select(student => student.Text).ToArray();

            return elementsStudents;
        }

    }
}
