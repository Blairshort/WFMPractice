using NUnit.Framework;

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
    public class JeffMainPage : WFMUtils.POM
    {
        public JeffMainPage(IWebDriver aDriver) 
            : base(
                "/main", 
                aDriver
            )
        {
            this.AddSelDescriptor(
                "WeeklySales", 
                By.XPath("//*[@class='menu__nav menu--main__nav']//*[text()='Weekly Sales']"),
                new Dictionary<string,string>{
                    {"isStatic", "y"}
                }
            );
            this.AddSelDescriptor(
                "Tips&Ideas", 
                By.XPath("//*[@class='menu__nav menu--main__nav']//*[text()='Tips & Ideas']"),
                new Dictionary<string,string>{
                    {"isStatic", "y"}
                }
            );
            this.AddSelDescriptor(
                "StoreLocator", 
                By.XPath("//*[@class='menu__nav menu--main__nav']//*[text()='Store Locator']"),
                new Dictionary<string,string>{
                    {"isStatic", "y"}
                }
            );
            this.AddSelDescriptor(
                "BrowseProducts", 
                By.XPath("//*[@class='menu__nav menu--main__nav']//*[text()='Browse Products']"),
                new Dictionary<string,string>{
                    {"isStatic", "y"}
                }
            );
            this.AddSelDescriptor(
                "Covid19Update", 
                By.XPath("//*[@class='menu__nav menu--main__nav']//*[text()='COVID-19 Update']"),
                new Dictionary<string,string>{
                    {"isStatic", "y"}
                }
            );
        }

        public void ClickToBrowseProductsMenu(int MaxWaitTimeInSecs=10)
        {
            driver.FindElement(this.GetBySelector("BrowseProducts")).Click();
            WFMUtils.WaitForCurrPageToFinishLoading(driver, MaxWaitTimeInSecs);
            Assert.That(driver.Url, Does.StartWith("https://products.wholefoodsmarket.com/"));
        }
    }
}