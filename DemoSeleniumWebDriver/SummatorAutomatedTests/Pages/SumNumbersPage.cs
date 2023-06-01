using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummatorAutomatedTests.Pages
{
    public class SumNumbersPage
    {
        public WebDriver driver;
        public const string baseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";

        public SumNumbersPage(WebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FirstField => driver.FindElement(By.Id("number1"));
        // public IWebElement FirstField { get { return driver.FindElement(By.CssSelector("#number1")); } }
        public IWebElement OperationField => driver.FindElement(By.CssSelector("#operation"));
        public IWebElement OperationFieldDefaultValue => driver.FindElement(By.CssSelector("#operation > option:nth-child(1)"));
        public IWebElement SecondField => driver.FindElement(By.Id("number2"));
        public IWebElement CalcButton => driver.FindElement(By.CssSelector("#calcButton"));
        public IWebElement ResetButton => driver.FindElement(By.CssSelector("#resetButton"));
        public IWebElement Result => driver.FindElement(By.CssSelector("#result"));

        public void Open()
        {
            driver.Navigate().GoToUrl(baseUrl);
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public bool IsPageOpen()
        {
            if (driver.Url == baseUrl)
            {
                return true;

            }
            return false;

        }

        public string CalculateNumbers(string firstValue, string operation, string secondValue)
        {
            FirstField.SendKeys(firstValue);
            SecondField.SendKeys(secondValue);
            OperationField.SendKeys(operation);

            CalcButton.Click();

            return Result.Text;
        }

        //public bool IsFormEmpty(string valueOfFirstField, string valueOfSecondField, string valueOfDropdown)
        //{

        //    valueOfFirstField = FirstField.Text;
        //    valueOfSecondField = SecondField.Text;
        //    valueOfDropdown = OperationField.Text;

        //    if (valueOfDropdown == string.Empty && valueOfFirstField == string.Empty && valueOfSecondField == string.Empty)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        public bool IsFormEmpty()
        {

            if (FirstField.Text == "" &&
                SecondField.Text == "" &&
                OperationFieldDefaultValue.Text == "-- select an operation --" &&
                Result.Text == string.Empty)
            {

                return true;
            }

            return false;

        }
    }
}
