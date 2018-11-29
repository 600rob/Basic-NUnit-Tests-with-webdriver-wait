using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;


/*
 * navigate to ultimateqa.com, enter search term 'Complicated page' submit the search.
 * open the page and asser on the page
 */
namespace NUnitTesting
{
    class AutomationQuiz
        {
        private IWebDriver driver;
        private string testUrl = "https://www.ultimateqa.com/";
        private WebDriverWait wait;
        Actions action;

        [SetUp]
        public void startDriver()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(testUrl);
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            action = new Actions(driver);
        }

            [Test]
            public void canSearchAndOpenNewPage()
        {
            Assert.AreEqual("Home - Ultimate QA", driver.Title);

            //wait for the over lay and close it
            //wait.Until(ExpectedConditions.ElementToBeClickable
            //  (By.XPath("//a[@title='Close']"))).Click();

            action.MoveToElement(driver.FindElement(By.CssSelector("span[id='et_search_icon']")))
                .Click()
                .Perform();
            
            //sync on searc field visiblity
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[class='et-search-field']")));


            submitSearch("complicated page");

            //sync om title
           // wait.Until(ExpectedConditions.ElementToBeClickable
             //   (By.LinkText("https://www.ultimateqa.com/complicated-page/"))).
               // Click();

            //click on the complicated page link
            driver.FindElement(By.CssSelector("a[href='https://www.ultimateqa.com/complicated-page/']"))

                .Click();
            wait.Until(ExpectedConditions.TitleIs("Complicated Page - Ultimate QA"));

            Assert.AreEqual("Complicated Page - Ultimate QA", driver.Title);

}

        [TearDown]
        public void stopDriver()
        {
            driver.Close();
            driver.Quit();


        }
        //helper method
        private void submitSearch(string v)
        {
            IWebElement searchField = driver.FindElement(By.CssSelector("input[class='et-search-field']"));
            searchField.SendKeys(v);
            searchField.Submit();
        }
    }
}
