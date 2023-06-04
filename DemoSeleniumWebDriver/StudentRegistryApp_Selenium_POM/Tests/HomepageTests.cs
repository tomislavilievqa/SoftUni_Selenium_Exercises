using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StudentRegistryApp_Selenium_POM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryApp_Selenium_POM.Tests
{
    public class HomepageTests : BasePageTests
    {

        public Homepage page;
        public ViewStudentsPage studentsPage;
        public AddStudentsPage addStudentsPage;

        [OneTimeSetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless"); // Run Chrome in headless mode
            chromeOptions.AddArgument("--disable-gpu"); // Disable GPU acceleration
            this.driver = new ChromeDriver(chromeOptions); //chromeOptions
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            this.page = new Homepage(driver);
            page.Open();

        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

        [Test]
        public void Test_HomePage_Content()
        {

            Assert.IsTrue(page.IsOpen());
            Assert.AreEqual("Students Registry", page.GetPageHeadingText());
            Assert.AreEqual("MVC Example", page.GetPageTitle());

            var expectedResult = page.GetStudentsCount();

            this.studentsPage = new ViewStudentsPage(driver);   

            this.studentsPage.Open();

            var studentsCount = studentsPage.GetRegisteredStudents().Length.ToString();

            Assert.That(expectedResult,Is.EqualTo(studentsCount));
       
        }

        [Test]
        public void Test_HomePage_Links()
        {
            
            page.LinkViewStudentsPage.Click();
            this.studentsPage = new ViewStudentsPage(driver);   
            Assert.IsTrue(studentsPage.IsOpen());

            driver.Navigate().Back();

            page.LinkAddStudentsPage.Click();
            this.addStudentsPage = new AddStudentsPage(driver);
            Assert.IsTrue(addStudentsPage.IsOpen());

            driver.Navigate().Back();


        }
    }
}
