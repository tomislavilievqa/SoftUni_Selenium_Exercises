using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummatorAutomatedTests
{
    public class SumNumbersPage
    {
        private WebDriver driver;
        private const string baseUrl = "https://sum-numbers.softuniqa.repl.co";

        public WebDriver Driver { get => driver; set => driver = value; }

        public SumNumbersPage(WebDriver driver)
        {
            this.Driver = new ChromeDriver();
        }
 
    }
}
