using OpenQA.Selenium;

namespace StudentRegistryApp_Selenium_POM.Pages
{
    public class Homepage : BasePage
    {
        private readonly IWebDriver driver;

        public Homepage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public override string pageUrl => "https://studentregistry.softuniqa.repl.co/";



    }
}
