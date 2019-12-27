using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHPBB.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void goToPage(string URL)
        {
            driver.Navigate().GoToUrl($"{URL}");
        }

        public void GeneratedStartPage()
        {
            HomePage home = new HomePage(driver);
            home.goToPage("http://endzait.kl.com.ua/");
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[3]/div[1]/div/ul/li[4]/a")]
        private IWebElement DeleteCookie;
        [FindsBy(How = How.CssSelector, Using = "#phpbb_confirm > div > form > fieldset > input[name='confirm']")]
        private IWebElement DeleteCookieYes;


        
        public void DeleteCookieFiles()
        {
            DeleteCookie.Click();
            System.Threading.Thread.Sleep(1000);
            DeleteCookieYes.Click();
            System.Threading.Thread.Sleep(5000);
        }

    }
}
