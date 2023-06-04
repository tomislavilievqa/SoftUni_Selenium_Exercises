using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryApp_Selenium_POM.Pages
{
    public class AddStudentsPage : BasePage
    {
        private readonly IWebDriver driver;

        public AddStudentsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public override string pageUrl => "https://studentregistry.softuniqa.repl.co/add-student";

        public IWebElement ErrorMessage => driver.FindElement(By.CssSelector("body > div"));
        public IWebElement FieldStudentName => driver.FindElement(By.CssSelector("body > form > div:nth-child(1)"));
        public IWebElement FieldStudentEmail => driver.FindElement(By.CssSelector("body > form > div:nth-child(2)"));
        public IWebElement AddButton => driver.FindElement(By.CssSelector("body > form > button"));

        public void AddStudent(string name, string email)
        {
            this.FieldStudentName.SendKeys(name);
            this.FieldStudentEmail.SendKeys(email);
            this.AddButton.Click();
        }

        public string GetErrorMessage()
        {
            AddButton.Click();
            return ErrorMessage.Text;
        }

        public bool IsFieldsAreEmpty(params By[] fieldLocators)
        { 
            bool isEmpty = fieldLocators.Any(locator =>
            {
                IWebElement field = driver.FindElement(locator);
                return string.IsNullOrWhiteSpace(field.GetAttribute("value"));
            });

            return isEmpty;
        }

    }
}
