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
    class Profile
    {
        private IWebDriver driver;

        public Profile(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/form/div[3]/div/div/div")]
        private IWebElement RealStatus;

        public bool CheckStatus()
        {
            return RealStatus.Text.Contains("Hi everyone!");
        }
        
    }
}
