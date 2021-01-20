using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace CreateCustomOfWaitCondition
{
    [TestFixture]
    public class Tests
    {
        private ChromeDriver _chromeDriver;
        private CustomDisplayMethod _display = new CustomDisplayMethod();
        private CustomEnableMethod _enable = new CustomEnableMethod();

        [SetUp]
        public void Setup()
        {
            // _chromeDriver.Navigate().GoToUrl("https://yandex.by/");
            _chromeDriver = new ChromeDriver();
            _chromeDriver.Navigate().GoToUrl("https://yandex.by/");
        }

        [Test]
        public void TestingDisplayedMethod()
        {
            string xPath = "//input[@name='text']";
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
            string xPath = "//div/button[@class='button mini-suggest__button button_theme_websearch button_size_ws-head i-bem button_js_inited']";
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

    [TestFixture]
    public class NewClass
    {
        private ChromeDriver _chromeDriver = new ChromeDriver();
        private CustomDisplayMethod _display = new CustomDisplayMethod();
        private CustomEnableMethod _enable = new CustomEnableMethod();

        [SetUp]
        public void Setup()
        {
            _chromeDriver.Navigate().GoToUrl("https://yandex.by/");
        }

        [Test]
        [Ignore("TestingEnableMethod")]
        public void TestingEnableMethod()
        {
            string xPath = "//div/button[@class='button mini-suggest__button button_theme_websearch button_size_ws-head i-bem button_js_inited']";
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