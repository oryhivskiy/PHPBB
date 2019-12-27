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
    class Login
    {
        private IWebDriver driver;

        public Login(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement Username;
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement Password;
        [FindsBy(How = How.Id, Using = "autologin")]
        private IWebElement Autologin;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/form/fieldset/input[1]")]
        private IWebElement Enter;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[1]/div[2]/div/ul[1]/li[3]/a")]
        private IWebElement EnterProfile;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/form/div[1]/div/div/fieldset/div")]
        private IWebElement LoginFailedMessage;

        public void EnterLoginAndPassword(string name, string password)
        {
            Username.SendKeys(name);
            Password.SendKeys(password);
            Enter.Click();
        }
         public bool CheckLoginFalse(string failedmessage)
        {
            string LoginFailedMessageText = LoginFailedMessage.Text;
            return LoginFailedMessageText.Contains(failedmessage);
        }

        public void EnterWithAutologin(string name, string password)
        {
            Username.SendKeys(name);
            Password.SendKeys(password);
            Autologin.Click();
            Enter.Click();
        }

        public bool CheckEnter()
        {
            return EnterProfile.Text.Contains("Вхід"); 
        }


    }
}
