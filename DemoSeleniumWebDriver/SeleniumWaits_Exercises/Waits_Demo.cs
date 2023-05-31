using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V111.WebAudio;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWaits_Exercises
{
    public class WaitsDemo
    {
        private WebDriver driver;
        private const string url = "https://nakov.com";
        private IWebElement input;

        [OneTimeSetUp]
        public void Setup()
        {
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--headless"); // Run Chrome in headless mode
            //chromeOptions.AddArgument("--disable-gpu"); // Disable GPU acceleration
            this.driver = new ChromeDriver(); //chromeOptions
            this.driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            //this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(url);         

        }
        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();

        }

        [Test]
        public void ImplicitWaiting()
        {
            driver.Manage().Timeouts().ImplicitWait =
                TimeSpan.FromSeconds(5); // will wait for certain time until the specified element
                                         // is loaded and is ready for the requested operation
            driver.FindElement(By.Id("s")).Click();
            driver.FindElement(By.Id("s")).SendKeys("QA" + Keys.Enter);

            // var result = driver.FindElement(By.XPath("//h3[contains(.,\'Search Results')]")).Text;
             var result = driver.FindElement(By.XPath("/html/body/section/hgroup/h3")).Text;

            Assert.That("Search Results for – \"QA\"", Is.EqualTo(result));
        }

        [Test]
        public void ThreadSleep()
        {
            Thread.Sleep(2000); // waiting a fixed timespan, even when the control is loaded earlier
            driver.FindElement(By.Id("s")).Click();
            driver.FindElement(By.Id("s")).SendKeys("QA" + Keys.Enter);

            // var result = driver.FindElement(By.XPath("//h3[contains(.,\'Search Results')]")).Text;
            var result = driver.FindElement(By.XPath("/html/body/section/hgroup/h3")).Text;

            Assert.That("Search Results for – \"QA\"", Is.EqualTo(result));
        }

        [Test]
        public void ExplicitWaits()
        {
            var wait = new WebDriverWait(
                driver, TimeSpan.FromSeconds(5));
            var loginButton = wait.Until<IWebElement>(d =>
            {
                return d.FindElement(By.LinkText("Login"));
            });
            loginButton.Click();

            // var result = driver.FindElement(By.XPath("//h3[contains(.,\'Search Results')]")).Text;
            var result = driver.FindElement(By.XPath("/html/body/section/hgroup/h3")).Text;

            Assert.That("Search Results for – \"QA\"", Is.EqualTo(result));
        }
    }
}