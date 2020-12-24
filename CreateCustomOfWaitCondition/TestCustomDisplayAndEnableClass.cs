using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;

namespace CreateCustomOfWaitCondition
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver _chromeDriver = new ChromeDriver();
        private CustomDisplayMethod _display = new CustomDisplayMethod();
        private CustomEnableMethod _enable = new CustomEnableMethod();

        [SetUp]
        public void Setup()
        {
            _chromeDriver.Navigate().GoToUrl("https://www.google.com/");
        }

        [Test]
        public void TestingDisplayedMethod()
        {
            string xPath = "//input[@name='q']";
            _chromeDriver.FindElement(By.XPath(xPath));

            var result = _display.FirstTryIsElementDisplay(xPath, _chromeDriver, _chromeDriver.Url);
            if (result == false)
            {
                throw new Exception("This element didn't display.");
            }
        }

        [Test]
        public void TestingEnableMethod()
        {
            string xPath = "//input[@class='gNO89b'][1]";
            _chromeDriver.FindElement(By.XPath(xPath));

            var result = _enable.CanWeClick(xPath, _chromeDriver, _chromeDriver.Url);
            if (result == false)
            {
                throw new Exception("This element didn't enable.");
            }
        }

        [TearDown]
        public void TearDown()
        {
            _chromeDriver.Quit();
        }
    }
}