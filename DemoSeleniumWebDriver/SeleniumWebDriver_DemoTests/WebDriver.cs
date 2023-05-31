
using System.Runtime.CompilerServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V111.IndexedDB;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace SeleniumWebDriver_DemoTests

{
    public class WebDriverDemo
    {
        private WebDriver driver;
        public string websiteUrl = "https://wikipedia.org";

        [OneTimeSetUp]
        public void OpenBrowsers()
        {
            this.driver = new ChromeDriver();
            //driver.Manage().Window.Maximize();
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            driver.Url = websiteUrl;
            //this.driver = new FirefoxDriver();
            //this.driver = new EdgeDriver();
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }

        [Test]
        public void Test_Wikipedia_CheckTitle()
        {           
            var pageTitle = driver.Title;

            Assert.That("Wikipedia", Is.EqualTo(pageTitle));
        }

        [Test]
        public void Test_Wikipedia_SearchForQA()
        {
            //Arange
            
            driver.FindElement(By.CssSelector("#searchInput")).Click();
            driver.FindElement(By.CssSelector("#searchInput")).SendKeys("QA" + Keys.Enter);
            //Act
            string expectedUrl = "https://en.wikipedia.org/wiki/QA";

            //Assert
            Assert.That(driver.Url.ToString(), Is.EqualTo(expectedUrl));
        }




    }
}