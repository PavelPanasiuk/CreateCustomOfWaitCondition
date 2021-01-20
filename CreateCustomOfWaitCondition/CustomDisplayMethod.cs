using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CreateCustomOfWaitCondition
{
    public class CustomDisplayMethod
    {
        //Method without explisit wait

        public bool FirstTryIsElementDisplay(string webpath, IWebDriver driver, string urlForSearchElement)
        {
            bool result = false;
            driver.Navigate().GoToUrl(urlForSearchElement);

            try
            {
                result = driver.FindElement(By.XPath(webpath)).Displayed;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        //Method with explicit wait. I consider that this method will be better.
        public bool SecondTryIsElementDisplay(string webpath, IWebDriver driver, string urlForSearchElement)
        {
            bool result = false;
            driver.Navigate().GoToUrl(urlForSearchElement);

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement webElement = wait.Until<IWebElement>((d) => d.FindElement(By.XPath(webpath)));
                result = webElement.Displayed;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
