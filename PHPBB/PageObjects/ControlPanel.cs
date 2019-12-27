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
    class ControlPanel
    {
        private IWebDriver driver;

        public ControlPanel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div[1]/ul/li[2]")]
        private IWebElement Profile;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div[2]/div/div/div[1]/div[1]/ul/li[4]/a")]
        private IWebElement ControlKeys;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div[1]/ul/li[2]/a")]
        private IWebElement ControlStatus;
        [FindsBy(How = How.Id, Using = "signature")]
        private IWebElement Signature;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div[2]/div/div/div[2]/form/fieldset/input[3]")]
        private IWebElement ControlSend;

        public void EditStatus()
        {
            Profile.Click();
            ControlStatus.Click();
            Signature.Clear();
            Signature.SendKeys("Hi everyone!");
            ControlSend.Click();
        }
        



    }
}
