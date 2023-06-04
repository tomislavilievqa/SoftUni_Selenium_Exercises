using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StudentRegistryApp_Selenium_POM.Pages;

namespace StudentRegistryApp_Selenium_POM.Tests
{
    public class AddStudentsPageTests : BasePageTests
    {

        public AddStudentsPage page;
        public Homepage homepage;
        public ViewStudentsPage viewStudentsPage;

        [OneTimeSetUp]
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


        [Test]
        public void Test_TestAddStudentPage_Content()
        {

            Assert.IsTrue(page.IsOpen());
            Assert.AreEqual("Register New Student", page.GetPageHeadingText());
            Assert.AreEqual("Add Student", page.GetPageTitle());

            Assert.AreEqual("Name:", page.FieldStudentName.Text);
            Assert.AreEqual("Email:", page.FieldStudentEmail.Text);

            Assert.That(page.AddButton.Text, Is.EqualTo("Add"));

            var errorMessage = page.GetErrorMessage();
            Assert.That(errorMessage, Is.EqualTo("Cannot add student. Name and email fields are required!"));

        }

        [Test]
        public void Test_TestAddStudentPage_Links()
        {
            page.LinkViewStudentsPage.Click();
            this.viewStudentsPage = new ViewStudentsPage(driver);
            Assert.IsTrue(viewStudentsPage.IsOpen());

            driver.Navigate().Back();

            page.LinkHomePage.Click();
            this.homepage = new Homepage(driver);
            Assert.IsTrue(homepage.IsOpen());

            driver.Navigate().Back();

        }

        [TestCase("test", "test@gmail.com")]
        [Test]
        public void Test_TestAddStudentPage_AddInvalidInput(string name, string email)
        {


        }


        [Test]
        public void Test_TestAddStudentPage_AddValidInputs()
        {

        }
    }
}