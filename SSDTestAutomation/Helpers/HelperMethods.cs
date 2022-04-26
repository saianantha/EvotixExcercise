using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSDTestAutomation.Helpers
{
    public class HelperMethods
    {
        private readonly IWebDriver _driver;

        public HelperMethods(IWebDriver driver) => _driver = driver;
        
        public void WaitForElementLoad(IWebElement element)
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(element);
            actions.Perform();
        }
        public void ClickElement(IWebElement element)
        {
            element.Click();
        }
        public void WaitForTime(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }
    }
}
