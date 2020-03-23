using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WFMPractice
{
    public class WFMMainPage
    {
        IWebDriver driver;
        public Dictionary<string, By> NavMenuSelectors;
                   

        public WFMMainPage(IWebDriver driver)
        {
            this.driver = driver;
            this.NavMenuSelectors = new Dictionary<string, By>();
            this.NavMenuSelectors.Add("WeeklySales", By.XPath("//*[@class='menu__nav menu--main__nav']//*[text()='Weekly Sales']"));
            this.NavMenuSelectors.Add("Tips&Ideas", By.XPath("//*[@class='menu__nav menu--main__nav']//*[text()='Tips & Ideas']"));
            this.NavMenuSelectors.Add("StoreLocator", By.XPath("//*[@class='menu__nav menu--main__nav']//*[text()='Store Locator']"));
            this.NavMenuSelectors.Add("BrowseProducts", By.XPath("//*[@class='menu__nav menu--main__nav']//*[text()='Browse Products']"));
            this.NavMenuSelectors.Add("Covid19Update", By.XPath("//*[@class='menu__nav menu--main__nav']//*[text()='COVID-19 Update']"));
        }
                public void DoMenuHover(By MenuSelector, int HoverSleepTimeInMilliSecs=4000)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(MenuSelector));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Build().Perform();

            if (HoverSleepTimeInMilliSecs > 0) { 
            System.Threading.Thread.Sleep(HoverSleepTimeInMilliSecs);
            }
        }
        
        public void DoMenuHoverThenClickMenuLink(By MenuSelector, string LinkText, int HoverSleepTimeInMilliSecs=4000)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(MenuSelector));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Build().Perform();

            if (HoverSleepTimeInMilliSecs > 0) {
                System.Threading.Thread.Sleep(HoverSleepTimeInMilliSecs);
            }

            IWait<IWebDriver> wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement subelement = wait2.Until(ExpectedConditions.ElementIsVisible(By.LinkText(LinkText)));
            action.MoveToElement(subelement);
            action.Click().Build().Perform();
        }
    }
}