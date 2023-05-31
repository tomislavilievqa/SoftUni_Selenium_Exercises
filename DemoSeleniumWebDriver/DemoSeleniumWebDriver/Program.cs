using OpenQA.Selenium.Chrome;

namespace DemoSeleniumWebDriver
{
    internal class SeleniumWebDriver
    {
        static void Main(string[] args)
        {
            // create browser instance

            var driver = new ChromeDriver();

            // navigate to Wikipedia

            driver.Url = "https://wikipedia.org";

            // close browser
            driver.Quit();
            
            
        }

    }
}