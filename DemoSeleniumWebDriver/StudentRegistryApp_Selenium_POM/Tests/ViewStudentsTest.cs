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
    public class ViewStudentsTest : BasePageTests
    {

        public Homepage homepage;
        public ViewStudentsPage page;
        public AddStudentsPage addStudentsPage;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            this.page = new ViewStudentsPage(driver);
            page.Open();
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }


        [Test]
        public void Test_ViewStudentsPage_Content()
        {
            Assert.IsTrue(page.IsOpen());
            Assert.AreEqual("Registered Students", page.GetPageHeadingText());
            Assert.AreEqual("Students", page.GetPageTitle());

            var students = page.GetRegisteredStudents();

            foreach (var student in students)
            {
                Assert.That(student.IndexOf("(") > 0);
                Assert.That(student.IndexOf(")") == student.Length-1);
            }          

        }

        [Test]
        public void Test_ViewStudentsPage_Links()
        {
            
            page.LinkHomePage.Click();
            this.homepage = new Homepage(driver);
            Assert.IsTrue(homepage.IsOpen());

            driver.Navigate().Back();

            page.LinkAddStudentsPage.Click();
            this.addStudentsPage = new AddStudentsPage(driver);
            Assert.IsTrue(addStudentsPage.IsOpen());

            driver.Navigate().Back();

        }
    }
}
