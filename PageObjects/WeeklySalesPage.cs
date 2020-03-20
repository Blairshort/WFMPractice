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
    public class WeeklySalesPage
    {
        IWebDriver driver;
        public WeeklySalesPage(IWebDriver driver)
        {
            IWebElement WeeklySalesTitle = driver.FindElement(By.ClassName("w-salesflyer-header__h1"));
        }
            public void ConfirmWeeklySalesPageTitle(string TitleText)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(TitleText)));
        }
    }
}