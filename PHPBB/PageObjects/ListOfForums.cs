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
    class ListOfForums
    {
        private IWebDriver driver;

        public ListOfForums(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[1]/div[2]/div/ul[1]/li[3]/div/a/span")]
        private IWebElement Profilename;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[1]/div[2]/div/ul[1]/li[3]/div/div/ul/li[1]/a/span")]
        private IWebElement ControlPanel;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[1]/div[2]/div/ul[1]/li[3]/div/div/ul/li[2]/a")]
        private IWebElement Profile;
        [FindsBy(How = How.Id, Using = "keywords")]
        private IWebElement Keywords;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[1]/div[1]/div/div[2]/form/fieldset/button")]
        private IWebElement SearchButton;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div[2]/div/div/div/span")]
        private IWebElement SearchedWord;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div[2]/div/ul[2]/li/dl/dt/div/a")]
        private IWebElement FirstForum;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div[2]/a/span")]
        private IWebElement NewTopic;
        [FindsBy(How = How.Id, Using = "subject")]
        private IWebElement Subject;
        [FindsBy(How = How.Id, Using = "message")]
        private IWebElement Message;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/form/div[2]/div/fieldset/input[3]")]
        private IWebElement Send;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div/div/p")]
        private IWebElement MessageSent;
        
        public bool CheckProfile(string name)
        {
            string ProfilenameText = Profilename.Text;
            return ProfilenameText.Contains(name);
        }

        public void SearchInForum(string searchword)
        {
            Keywords.SendKeys(searchword);
            SearchButton.Click();
        }
        
        public bool CheckSearch(string searchedword)
        {
            return SearchedWord.Text.Contains(searchedword);
        }

        public void OpenControlPanel()
        {
            Profilename.Click();
            ControlPanel.Click();
        }
        public void OpenProfile()
        {
            Profilename.Click();
            Profile.Click();
        }

        public void CreateNewTopic()
        {
            FirstForum.Click();
            NewTopic.Click();
            Subject.SendKeys("Hello, World");
            Message.SendKeys("HI");
            Send.Click();
        }
        public bool CheckSent()
        {
            return MessageSent.Text.Contains("Повідомлення додано, але воно потребує схвалення модератора Вас буде повідомлено, коли ваше повідомлення буде схвалено.");
        }

    }
}
