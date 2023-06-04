using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryApp_Selenium_POM.Tests
{
    public class BasePageTests
    {
        protected WebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless"); // Run Chrome in headless mode
            chromeOptions.AddArgument("--disable-gpu"); // Disable GPU acceleration
            this.driver = new ChromeDriver(chromeOptions); //chromeOptionsthis.driver = new ChromeDriver();

        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }


    }
}
