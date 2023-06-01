using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummatorAutomatedTests.Pages;
using NuGet.Frameworks;

namespace SummatorAutomatedPOMTests.Tests
{
    public class Tests
    {

        public WebDriver driver;
        public SumNumbersPage page; 

        [OneTimeSetUp]
        public void OpenBrowser()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless"); // Run Chrome in headless mode
            chromeOptions.AddArgument("--disable-gpu"); // Disable GPU acceleration
            this.driver = new ChromeDriver(chromeOptions); //chromeOptions
            //this.driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            this.driver.Manage().Window.Maximize();
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            this.page = new SumNumbersPage(driver);
            page.Open();

        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }

        [TestCase("1", "+ (sum)", "2", "Result: 3")]
        [TestCase("-10", "+ (sum)", "-2", "Result: -12")]
        [TestCase("-1", "+ (sum)", "2", "Result: 1")]
        [TestCase("1e22", "+ (sum)", "1e22", "Result: 2e+22")]
        [TestCase("1000000000000000", "+ (sum)", "2000000000000000", "Result: 3000000000000000")]
        [TestCase("test", "+ (sum)", "2", "Result: invalid input")]
        [TestCase("test", "+ (sum)", "test", "Result: invalid input")]
        [TestCase("2", "+ (sum)", "test", "Result: invalid input")]
        [TestCase("@", "+ (sum)", "2", "Result: invalid input")]
        [TestCase("@", "+ (sum)", "@", "Result: invalid input")]
        [TestCase("2", "+ (sum)", "@", "Result: invalid input")]
        [TestCase("2", "@", "2", "Result: invalid operation")]
        [TestCase("2", "!!!!", "2", "Result: invalid operation")]
        [TestCase("2", "", "2", "Result: invalid operation")]
        [TestCase("2", ",", "2", "Result: invalid operation")]
        [TestCase("2", "2", "2", "Result: invalid operation")]
        [TestCase("", "+ (sum)", "2", "Result: invalid input")]
        [TestCase("", "+ (sum)", "", "Result: invalid input")]
        [TestCase("2", "+ (sum)", "", "Result: invalid input")]
        [TestCase("", "+ (sum)", "", "Result: invalid input")]
        [TestCase("12.22", "+ (sum)", "12.22", "Result: 24.44")]
        [TestCase("12.22", "+ (sum)", "12", "Result: 24.22")]
        [TestCase("12", "+ (sum)", "12.22", "Result: 24.22")]
        [TestCase("12.00", "+ (sum)", "12.00", "Result: 24")]
        [TestCase("12.00", "+ (sum)", "12", "Result: 24")]
        [TestCase("12", "+ (sum)", "12.00", "Result: 24")]
        public void Test_SumNumbers(string firstNum, string operation,
            string secondNum, string expectedResult)
        {
            Assert.True(page.IsPageOpen());

            page.ResetButton.Click();

            var actualResult = page.CalculateNumbers(firstNum, operation, secondNum);

            Assert.AreEqual(expectedResult, actualResult);
            
        }

        [TestCase("12", "+ (sum)", "12.00")]        
        public void Test_CheckTheResetButton(string firstNum, string operation,
            string secondNum)
        {
            Assert.True(page.IsPageOpen());

            page.ResetButton.Click();

            page.CalculateNumbers(firstNum, operation, secondNum);

            page.ResetButton.Click();

            Assert.True(page.IsFormEmpty());
                      
        }
    }
}
