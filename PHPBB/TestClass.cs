using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PHPBB.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHPBB
{
    public class TestClass
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void LoginTrue()
        {
            HomePage home = new HomePage(driver);
            home.GeneratedStartPage();
            Login login = new Login(driver);
            login.EnterLoginAndPassword("Євгеній","12332145");
            ListOfForums listofforums = new ListOfForums(driver);
            Assert.IsTrue(listofforums.CheckProfile("Євгеній"), "Login failed");
        }

        [Test]
        public void LoginFalse()
        {
            HomePage home = new HomePage(driver);
            home.GeneratedStartPage();
            Login login = new Login(driver);
            login.EnterLoginAndPassword("Євген", "12332145");
            ListOfForums listofforums = new ListOfForums(driver);
            Assert.IsTrue(login.CheckLoginFalse("Ви ввели невірне ім'я користувача."), "Login unfailed");
        }

        [Test]
        public void CheckSearch()
        {
            HomePage home = new HomePage(driver);
            home.GeneratedStartPage();
            ListOfForums listofforums = new ListOfForums(driver);
            listofforums.SearchInForum("During");
            Assert.IsTrue(listofforums.CheckSearch("During"), "Search failed");
        }

        [Test]
        public void CheckAutologin()
        {
            HomePage home = new HomePage(driver);
            home.GeneratedStartPage();
            Login login = new Login(driver);
            login.EnterWithAutologin("Євгеній", "12332145");
            home.GeneratedStartPage();
            ListOfForums listofforums = new ListOfForums(driver);
            Assert.IsTrue(listofforums.CheckProfile("Євгеній"), "Login failed");
        }

        [Test]
        public void DeleteCookie()
        {
            HomePage home = new HomePage(driver);
            home.GeneratedStartPage();
            Login login = new Login(driver);
            login.EnterLoginAndPassword("Євгеній", "12332145");
            home.DeleteCookieFiles();
            Assert.IsTrue(login.CheckEnter(), "Delete failed");
        }

        [Test]
        public void CreateNewTopic()
        {
            HomePage home = new HomePage(driver);
            home.GeneratedStartPage();
            Login login = new Login(driver);
            login.EnterLoginAndPassword("Євгеній", "12332145");
            ListOfForums listofforums = new ListOfForums(driver);
            listofforums.CreateNewTopic();
            Assert.IsTrue(listofforums.CheckSent(), "Sent failed");
        }

        [Test]
        public void CreateNewStatus()
        {
            HomePage home = new HomePage(driver);
            home.GeneratedStartPage();
            Login login = new Login(driver);
            login.EnterLoginAndPassword("Євгеній", "12332145");
            ListOfForums listofforums = new ListOfForums(driver);
            listofforums.OpenControlPanel();
            ControlPanel controlpanel = new ControlPanel(driver);
            controlpanel.EditStatus();
            listofforums.OpenProfile();
            Profile profile = new Profile(driver);
            Assert.IsTrue(profile.CheckStatus(), "Status incorrect");
        }
        
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
