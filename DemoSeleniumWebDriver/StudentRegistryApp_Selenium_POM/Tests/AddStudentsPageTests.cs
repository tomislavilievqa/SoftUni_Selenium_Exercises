using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StudentRegistryApp_Selenium_POM.Pages;

namespace StudentRegistryApp_Selenium_POM.Tests
{
    public class AddStudentsPageTests : BasePageTests
    {

        public AddStudentsPage page;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();        
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            this.page = new AddStudentsPage(driver);
            page.Open();
           
        }
        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

        //[Test]
        //public void IsFieldsAreEmpty_SomeFieldsEmpty_ReturnsTrue()
        //{
        //    // Navigate to the test page

        //    // Perform actions to fill or leave fields empty

        //    bool isEmpty = obj.IsFieldsAreEmpty(By.Id("field1"), By.Name("field2"), By.CssSelector(".field3"));

        //    Assert.IsTrue(isEmpty, "Some fields are empty.");
        //}

        //[Test]
        //public void IsFieldsAreEmpty_AllFieldsFilled_ReturnsFalse()
        //{
        //    // Navigate to the test page
        //    driver.Url = "https://www.example.com/test-page";

        //    // Perform actions to fill all fields

        //    bool isEmpty = obj.IsFieldsAreEmpty(By.Id("field1"), By.Name("field2"), By.CssSelector(".field3"));

        //    Assert.IsFalse(isEmpty, "No fields are empty.");
        //}
    }
}