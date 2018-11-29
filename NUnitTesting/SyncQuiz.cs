using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Support.UI;
using System;

namespace NUnitTesting
{
    class SyncQuiz
    {

        private string testUrl = "https://www.ultimateqa.com/";
        private IWebDriver driver;
        private WebDriverWait wait;



        [SetUp]
        public void startDriver()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        [Test]

        public void pageSyncQuiz()
        {
            //navigate to main page, and sync on an element

            driver.Navigate().GoToUrl(testUrl);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath
                ("//div[@class='et_parallax_bg et_pb_parallax_css et_pb_inner_shadow']")));

            driver.Manage().Window.Maximize();

            //clixk on automation exercises link
            driver.FindElement(By.XPath
                ("//a[@href='https://www.ultimateqa.com/automation/']")).Click();

            //wait for 7 shares to be visible
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@data-post_id='507']")));

            //find the link for big page with many elements and click on it

            driver.FindElement(By.XPath("//a[@href='../complicated-page']")).Click();

           
    
          //sync on 5 shares graphic
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@data-post_id='579']")));

            //Assert on title

            Assert.AreEqual("Complicated Page - Ultimate QA", driver.Title);

}


        [TearDown]
        public void closeDriver()
        {
            driver.Close();
            driver.Quit();
            

        }


    }
}
