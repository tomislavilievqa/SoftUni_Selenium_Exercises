using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SummatorAutomatedTests
{
    [TestFixture]
    public class SummatorRefactored
    {
        private WebDriver driver;
        private const string url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";
        private IWebElement firstInput;
        private IWebElement secondInput;
        private IWebElement operationField;
        private IWebElement calcButton;
        private IWebElement result;

        [OneTimeSetUp]
        public void OpenBrowser()
        {
            this.driver = new ChromeDriver();
            //this.driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            this.driver.Manage().Window.Maximize();
            this.driver.Url = url;
            firstInput = driver.FindElement(By.CssSelector("#number1"));
            operationField = driver.FindElement(By.CssSelector("#operation"));
            secondInput = driver.FindElement(By.CssSelector("#number2"));
            calcButton = driver.FindElement(By.CssSelector("#calcButton"));
            result = driver.FindElement(By.CssSelector("#result"));
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
           this.driver.Quit();
        }

        //[Test]
        public void Test_SummatorOfNumbers_SumTwoPositiveNumbers()
        {
            //Arange
            firstInput.SendKeys("1");
            operationField.Click();
            operationField.SendKeys("+");
            secondInput.SendKeys("2");
            calcButton.Click();

            //Act
            string expectedResult = "Result: 3";

            //Assert
            Assert.That(expectedResult, Is.EqualTo(result.Text));
        }

       // [Test]
        public void Test_SummatorOfNumbers_DivideTwoPositiveNumbers()
        {
            //Arange
            firstInput.SendKeys("2");
            driver.FindElement(By.CssSelector("#operation > option:nth-child(5)")).Click();
            secondInput.SendKeys("2");
            calcButton.Click();

            //Act
            string expectedResult = "Result: 1";

            //Assert
            Assert.That(expectedResult, Is.EqualTo(result.Text));
        }

       // [Test]
        public void Test_SummatorOfNumbers_MultiplyTwoPositiveNumbers()
        {
            //Arange
            firstInput.SendKeys("3");
            driver.FindElement(By.CssSelector("#operation > option:nth-child(4)")).Click();
            secondInput.SendKeys("3");
            calcButton.Click();
            //Act
      
            string expectedResult = "Result: 9";

            //Assert
            Assert.That(expectedResult, Is.EqualTo(result.Text));
        }

      //  [Test]
        public void Test_SummatorOfNumbers_SumTwoNegativeNumbers()
        {
            //Arange
            firstInput.SendKeys("-5");
            driver.FindElement(By.CssSelector("#operation > option:nth-child(2)")).Click();
            secondInput.SendKeys("-5");
            calcButton.Click();

            //Act
            var expectedResult = "Result: -10";

            //Assert
            Assert.That(expectedResult, Is.EqualTo(result.Text));
        }

       // [Test]
        public void Test_SummatorOfNumbers_SumTwoValidNumbersAndReset()
        {
            //Arange
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

       // [Test]
        public void Test_SummatorOfNumbers_SumNumberAndText()
        {
            //Arange
            firstInput.SendKeys("text");
            driver.FindElement(By.CssSelector("#operation > option:nth-child(2)")).Click();
            secondInput.SendKeys("2");
            calcButton.Click();

            //Act
            string expectedResult = "Result: invalid input";

            //Assert
            Assert.That(result.Text, Is.EqualTo(expectedResult));
        }
    }
}