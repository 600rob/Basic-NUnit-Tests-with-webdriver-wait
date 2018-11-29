using System;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace NUnitTesting
{
    [TestFixture]
    public class InteractionsTests
    {
        private Actions actions;
        private string testUrl = "http://compendiumdev.co.uk/selenium/gui_user_interactions.html";
        private  IWebDriver driver;
        private IWebElement sourceElement;
        private IWebElement targetElement;

        [OneTimeSetUp]
        public void launchPage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(testUrl);
           
        }


        [SetUp]
        public void refreshPage()
        {
            driver.Navigate().Refresh();
            driver.Manage().Window.Maximize();
            actions = new Actions(driver);
            sourceElement = driver.FindElement(By.Id("draggable1"));
            targetElement = driver.FindElement(By.Id("droppable1"));
        }

        [Test]
        public void useDragNDrop()

        {
           actions.DragAndDrop(sourceElement, targetElement).Perform();

            Assert.AreEqual("Dropped!", targetElement.Text);


        }

        [Test]
        public void useClickAndhold()

        {
            

            
            actions.ClickAndHold(sourceElement)
                .MoveToElement(targetElement)
                .Release().Build();

            actions.Perform();


           Assert.AreEqual("Dropped!", targetElement.Text);


        }



        [TearDown]
        public void stopDriver()
        {
            driver.Quit();

        }
    }
}
