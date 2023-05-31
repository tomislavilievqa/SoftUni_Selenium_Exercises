
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SummatorAutomatedTests
{
    public class SummatorTests
    {
        private WebDriver driver;
        private const string url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";

        [SetUp]
        public void OpenBrowser()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            this.driver.Url = url;
        }

        [TearDown]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }

        //[Test]
        public void Test_SummatorOfNumbers_SumTwoPositiveNumbers()
        {
            //Arange
            driver.FindElement(By.CssSelector("#number1")).Click();
            driver.FindElement(By.CssSelector("#number1")).SendKeys("1");
            driver.FindElement(By.CssSelector("#operation > option:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector("#number2")).Click();
            driver.FindElement(By.CssSelector("#number2")).SendKeys("2");
            driver.FindElement(By.CssSelector("#calcButton")).Click();

            var value = driver.FindElement(By.CssSelector("#result")).Text;
            //Act
            string expectedResult = "Result: 3";

            //Assert
            Assert.That(expectedResult, Is.EqualTo(value));
        }

        //[Test]
        public void Test_SummatorOfNumbers_DivideTwoPositiveNumbers()
        {
            //Arange
            driver.FindElement(By.CssSelector("#number1")).Click();
            driver.FindElement(By.CssSelector("#number1")).SendKeys("3");
            driver.FindElement(By.CssSelector("#operation > option:nth-child(5)")).Click();
            driver.FindElement(By.CssSelector("#number2")).Click();
            driver.FindElement(By.CssSelector("#number2")).SendKeys("3");
            driver.FindElement(By.CssSelector("#calcButton")).Click();

            var value = driver.FindElement(By.CssSelector("#result")).Text;
            //Act
            string expectedResult = "Result: 1";

            //Assert
            Assert.That(expectedResult, Is.EqualTo(value));
        }

       // [Test]
        public void Test_SummatorOfNumbers_MultiplyTwoPositiveNumbers()
        {
            //Arange
            driver.FindElement(By.CssSelector("#number1")).Click();
            driver.FindElement(By.CssSelector("#number1")).SendKeys("3");
            driver.FindElement(By.CssSelector("#operation > option:nth-child(4)")).Click();
            driver.FindElement(By.CssSelector("#number2")).Click();
            driver.FindElement(By.CssSelector("#number2")).SendKeys("3");
            driver.FindElement(By.CssSelector("#calcButton")).Click();

            var value = driver.FindElement(By.CssSelector("#result")).Text;
            //Act
            string expectedResult = "Result: 9";

            //Assert
            Assert.That(expectedResult, Is.EqualTo(value));
        }

      //  [Test]
        public void Test_SummatorOfNumbers_SumTwoNegativeNumbers()
        {
            //Arange
            driver.FindElement(By.CssSelector("#number1")).Click();
            driver.FindElement(By.CssSelector("#number1")).SendKeys("-5");
            driver.FindElement(By.CssSelector("#operation > option:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector("#number2")).Click();
            driver.FindElement(By.CssSelector("#number2")).SendKeys("-5");
            driver.FindElement(By.CssSelector("#calcButton")).Click();
            var resultText = driver.FindElement(By.CssSelector("#result")).Text;

            //Act
            var expectedResult = "Result: -10";

            //Assert
            Assert.That(expectedResult, Is.EqualTo(resultText));
        }

        //[Test]
        public void Test_SummatorOfNumbers_SumTwoValidNumbersAndReset()
        {
            //Arange
            driver.FindElement(By.CssSelector("#number1")).Click();
            driver.FindElement(By.CssSelector("#number1")).SendKeys("1");
            driver.FindElement(By.CssSelector("#operation > option:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector("#number2")).Click();
            driver.FindElement(By.CssSelector("#number2")).SendKeys("2");
            driver.FindElement(By.CssSelector("#calcButton")).Click();

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
            driver.FindElement(By.CssSelector("#number1")).Click();
            driver.FindElement(By.CssSelector("#number1")).SendKeys("test");
            driver.FindElement(By.CssSelector("#operation > option:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector("#number2")).Click();
            driver.FindElement(By.CssSelector("#number2")).SendKeys("2");
            driver.FindElement(By.CssSelector("#calcButton")).Click();

            string value = driver.FindElement(By.CssSelector("#result")).Text;
            //Act
            string expectedResult = "Result: invalid input";

            //Assert
            Assert.That(value, Is.EqualTo(expectedResult));
        }
    }
}