using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SummatorAutomatedTests
{
    [TestFixture]
    public class SummatorDDT
    {
        private WebDriver driver;
        private const string url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";
        private IWebElement firstInput;
        private IWebElement secondInput;
        private IWebElement operationField;
        private IWebElement calcButton;
        private IWebElement result;
        private IWebElement resetButton;

        [OneTimeSetUp]
        public void OpenBrowser()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless"); // Run Chrome in headless mode
            chromeOptions.AddArgument("--disable-gpu"); // Disable GPU acceleration
            this.driver = new ChromeDriver(chromeOptions); //chromeOptions
            this.driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            this.driver.Navigate().GoToUrl(url);           
            //this.driver.Manage().Window.Maximize();
            firstInput = driver.FindElement(By.CssSelector("#number1"));
            operationField = driver.FindElement(By.CssSelector("#operation"));
            secondInput = driver.FindElement(By.CssSelector("#number2"));
            calcButton = driver.FindElement(By.CssSelector("#calcButton"));
            result = driver.FindElement(By.CssSelector("#result"));
            resetButton = driver.FindElement(By.CssSelector("#resetButton"));
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }

        [TestCase("1", "+", "2", "Result: 3")]
        [TestCase("-10", "+", "-2", "Result: -12")]
        [TestCase("-1", "+", "2", "Result: 1")]
        [TestCase("1e22", "+", "1e22", "Result: 2e+22")]
        [TestCase("1000000000000000", "+", "2000000000000000", "Result: 3000000000000000")]
        [TestCase("test", "+", "2", "Result: invalid input")]
        [TestCase("test", "+", "test", "Result: invalid input")]
        [TestCase("2", "+", "test", "Result: invalid input")]
        [TestCase("@", "+", "2", "Result: invalid input")]
        [TestCase("@", "+", "@", "Result: invalid input")]
        [TestCase("2", "+", "@", "Result: invalid input")]
        [TestCase("2", "@", "2", "Result: invalid operation")]
        [TestCase("2", "!!!!", "2", "Result: invalid operation")]
        [TestCase("2", "", "2", "Result: invalid operation")]
        [TestCase("2", ",", "2", "Result: invalid operation")]
        [TestCase("2", "2", "2", "Result: invalid operation")]
        [TestCase("", "+", "2", "Result: invalid input")]
        [TestCase("", "+", "", "Result: invalid input")]
        [TestCase("2", "+", "", "Result: invalid input")]
        [TestCase("", "+", "", "Result: invalid input")]
        [TestCase("12.22", "+", "12.22", "Result: 24.44")]
        [TestCase("12.22", "+", "12", "Result: 24.22")]
        [TestCase("12", "+", "12.22", "Result: 24.22")]
        [TestCase("12.00", "+", "12.00", "Result: 24")]
        [TestCase("12.00", "+", "12", "Result: 24")]
        [TestCase("12", "+", "12.00", "Result: 24")]

        public void Test_SummatorOfNumbers_TestingTheSumOperation(string firstNum, string operation,
            string secondNum, string expectedResult)
        {
            //Arange
            resetButton.Click();
            //firstInput.Click();
            firstInput.SendKeys(firstNum);
            //operationField.Click();
            operationField.SendKeys(operation);
            //secondInput.Click();
            secondInput.SendKeys(secondNum);
            
            //Act
            calcButton.Click();

            //Assert
            Assert.That(expectedResult, Is.EqualTo(result.Text));
        }

        [TestCase("3", "-", "2", "Result: 1")]
        [TestCase("-10", "-", "-2", "Result: -8")]
        [TestCase("-1", "-", "2", "Result: -3")]
        [TestCase("2e22", "-", "1e22", "Result: 1e+22")]
        [TestCase("1e22", "-", "2e22", "Result: -1e+22")]
        [TestCase("-1e22", "-", "-2e22", "Result: 1e+22")]
        [TestCase("2000000000000000", "-", "1000000000000000", "Result: 1000000000000000")]
        [TestCase("test", "-", "2", "Result: invalid input")]
        [TestCase("test", "-", "test", "Result: invalid input")]
        [TestCase("@", "-", "2", "Result: invalid input")]
        [TestCase("@", "-", "@", "Result: invalid input")]
        public void Test_SummatorOfNumbers_TestingTheSubstractOperation(string firstNum, string operation,
            string secondNum, string expectedResult)
        {
            //Arange
            resetButton.Click();
            //firstInput.Click();
            firstInput.SendKeys(firstNum);
            //operationField.Click();
            operationField.SendKeys(operation);
            //secondInput.Click();
            secondInput.SendKeys(secondNum);

            //Act
            calcButton.Click();

            //Assert
            Assert.That(expectedResult, Is.EqualTo(result.Text));
        }

        [TestCase("3", "*", "2", "Result: 6")]
        [TestCase("-10", "*", "-2", "Result: 20")]
        [TestCase("-1", "*", "2", "Result: -2")]
        [TestCase("2", "*", "-1", "Result: -2")]
        [TestCase("2e22", "*", "1e22", "Result: 2e+44")]
        [TestCase("1e22", "*", "2e22", "Result: 2e+44")]
        [TestCase("-1e22", "*", "-2e22", "Result: 2e+44")]
        [TestCase("2000000000000000", "*", "1000000000000000", "Result: 2e+30")]
        [TestCase("test", "*", "2", "Result: invalid input")]
        [TestCase("test", "*", "test", "Result: invalid input")]
        [TestCase("@", "*", "2", "Result: invalid input")]
        [TestCase("@", "*", "@", "Result: invalid input")]
        public void Test_SummatorOfNumbers_TestingTheMultiplyOperation(string firstNum, string operation,
           string secondNum, string expectedResult)
        {
            //Arange
            resetButton.Click();
            //firstInput.Click();
            firstInput.SendKeys(firstNum);
            //operationField.Click();
            operationField.SendKeys(operation);
            //secondInput.Click();
            secondInput.SendKeys(secondNum);

            //Act
            calcButton.Click();

            //Assert
            Assert.That(expectedResult, Is.EqualTo(result.Text));
        }

        [TestCase("3", "/", "2", "Result: 1.5")]
        [TestCase("3", "/", "3", "Result: 1")]
        [TestCase("-3", "/", "1", "Result: -3")]
        [TestCase("1", "/", "-3", "Result: -0.333333333333")]
        [TestCase("2e22", "/", "1e22", "Result: 2")]
        [TestCase("1e22", "/", "2e22", "Result: 0.5")]
        [TestCase("-1e22", "/", "-2e22", "Result: 0.5")]
        [TestCase("2000000000000000", "/", "1000000000000000", "Result: 2")]
        [TestCase("test", "/", "2", "Result: invalid input")]
        [TestCase("test", "/", "test", "Result: invalid input")]
        [TestCase("@", "/", "2", "Result: invalid input")]
        [TestCase("@", "/", "@", "Result: invalid input")]
        public void Test_SummatorOfNumbers_TestingTheDivideOperation(string firstNum, string operation,
   string secondNum, string expectedResult)
        {
            //Arange
            resetButton.Click();
            //firstInput.Click();
            firstInput.SendKeys(firstNum);
            //operationField.Click();
            operationField.SendKeys(operation);
            //secondInput.Click();
            secondInput.SendKeys(secondNum);

            //Act
            calcButton.Click();

            //Assert
            Assert.That(expectedResult, Is.EqualTo(result.Text));
        }

        [Test]
        public void Test_SummatorOfNumbers_SumTwoValidNumbersAndReset()
        {
            //Arange
            resetButton.Click();
            firstInput.SendKeys("1");
            driver.FindElement(By.CssSelector("#operation > option:nth-child(2)")).Click();
            secondInput.SendKeys("2");
            calcButton.Click();

            var resultText = driver.FindElement(By.CssSelector("#result > pre")).Text;

            Assert.That(resultText, Is.Not.Empty);

            driver.FindElement(By.CssSelector("#resetButton")).Click();

            var valueOfFirstField = driver.FindElement(By.CssSelector("#number1")).GetAttribute("placeholder").ToString();
            var valueOfSecondField = driver.FindElement(By.CssSelector("#number2")).GetAttribute("placeholder").ToString();
            var valueOfDropdown = driver.FindElement(By.CssSelector("#operation > option:nth-child(1)")).Text;

            Assert.That(valueOfDropdown, Is.EqualTo("-- select an operation --"));
            Assert.That(valueOfSecondField, Is.EqualTo("2nd number"));
            Assert.That(valueOfFirstField, Is.EqualTo("1st number"));

        }

    }
}