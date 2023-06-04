using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryApp_Selenium_POM.Pages
{
    public class BasePage
    {
        private readonly IWebDriver driver;

        public virtual string pageUrl { get; }

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement LinkHomePage => driver.FindElement(By.CssSelector("body > a:nth-child(1)"));

        public IWebElement LinkAddStudentsPage => driver.FindElement(By.CssSelector("body > a:nth-child(5)"));

        public IWebElement LinkViewStudentsPage => driver.FindElement(By.CssSelector("body > a:nth-child(3)"));

        public IWebElement ElementTextHeading => driver.FindElement(By.CssSelector("body > h1"));

        public IWebElement ElementTextRegisteredStudents => driver.FindElement(By.XPath("/html/body/p/text()"));

        public IWebElement ElementCountRegisteredStudents => driver.FindElement(By.CssSelector("body > p > b"));

        public void Open()
        {
            driver.Navigate().GoToUrl(this.pageUrl);
        }

        public bool IsOpen()
        {
            return driver.Url == this.pageUrl;
        }
        public string GetPageTitle()
        {
            return driver.Title;
        }

        public string GetPageHeadingText()
        {
            return ElementTextHeading.Text;
        }

        public string GetStudentsCount()
        {
            return ElementCountRegisteredStudents.Text;

        }

    }
}
