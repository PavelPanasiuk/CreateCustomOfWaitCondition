using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace CreateCustomOfWaitCondition
{
    class CustomEnableMethod
    {
        public bool CanWeClick(string webpath, IWebDriver driver, string urlForSearchElement)
        {
            bool result = false;
            driver.Navigate().GoToUrl(urlForSearchElement);

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement webElement = wait.Until<IWebElement>((d) => d.FindElement(By.XPath(webpath)));
                result = webElement.Enabled;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
