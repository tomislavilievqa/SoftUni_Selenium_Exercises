using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics.Metrics;
using System.Runtime.ExceptionServices;

namespace TestsForURLShortener
{

    public class Tests
    {

        private WebDriver driver;
        private const string url = "https://shorturl.softuniqa.repl.co/";

        [OneTimeSetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();

        }
        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

        [Test]
        public void VerifyingTheTile()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://shorturl.softuniqa.repl.co/urls");

            var title = driver.Title;

            var expectedTitle = "Short URLs";

            Assert.AreEqual(title, expectedTitle);
        }

        [TestCase("https://nakov.com", "http://shorturl.softuniqa.repl.co/go/nak")]
        [TestCase("https://nakov.com", "http://shorturl.softuniqa.repl.co/go/nak")]
        public void VerifyingTheLinks(string originalURL, string shortURL)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://shorturl.softuniqa.repl.co/urls");
            var table = driver.FindElement(By.ClassName("urls"));

            var firstCellData = table.FindElement(By.CssSelector("body > main > table > tbody > tr:nth-child(1) > td:nth-child(1) > a")).Text;
            var secondCellData = table.FindElement(By.CssSelector("body > main > table > tbody > tr:nth-child(1) > td:nth-child(2) > a")).Text;
            Assert.AreEqual(originalURL, firstCellData);
            Assert.AreEqual(shortURL, secondCellData);


        }

    }
}
