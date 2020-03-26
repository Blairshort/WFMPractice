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
    public class PrescriptiveMainPage : WFMUtils.POM
    {
        public PrescriptiveMainPage(IWebDriver aDriver) 
            : base(
                "/Main", 
                aDriver
            )
        {
            this.AddSelDescriptor(
                "HomeLogoLink", 
                By.CssSelector(".logo__link"),
                new Dictionary<string,string>{
                    {"isStatic", "y"}
                }
            );
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

        public void ClickToHomePage(int MaxWaitTimeInSecs=10)
        {
            ClickEltByName("HomeLogoLink");
            WFMUtils.WaitForCurrPageToFinishLoading(driver, MaxWaitTimeInSecs);
            Assert.That(driver.Url, Does.StartWith("https://www.wholefoodsmarket.com/"));
        }


        public void ClickToWeeklySalesPage(int MaxWaitTimeInSecs=10)
        {
            ClickEltByName("WeeklySales");
            WFMUtils.WaitForCurrPageToFinishLoading(driver, MaxWaitTimeInSecs);
            Assert.That(driver.Url, Does.StartWith("https://www.wholefoodsmarket.com/sales-flyer"));
        }

        public void ClickToTipsAndIdeasPage(int MaxWaitTimeInSecs=10)
        {
            ClickEltByName("Tips&Ideas");
            WFMUtils.WaitForCurrPageToFinishLoading(driver, MaxWaitTimeInSecs);
            Assert.That(driver.Url, Does.StartWith("https://inspiration.wholefoodsmarket.com/"));
        }

        public void ClickToStoreLocatorPage(int MaxWaitTimeInSecs=10)
        {
            ClickEltByName("StoreLocator");
            WFMUtils.WaitForCurrPageToFinishLoading(driver, MaxWaitTimeInSecs);
            Assert.That(driver.Url, Does.StartWith("https://www.wholefoodsmarket.com/stores"));
        }

        public void ClickToBrowseProductsPage(int MaxWaitTimeInSecs=10)
        {
            ClickEltByName("BrowseProducts");
            WFMUtils.WaitForCurrPageToFinishLoading(driver, MaxWaitTimeInSecs);
            Assert.That(driver.Url, Does.StartWith("https://products.wholefoodsmarket.com/"));
        }

        public void ClickToCovid19UpdatePage(int MaxWaitTimeInSecs=10)
        {
            ClickEltByName("Covid19Update");
            WFMUtils.WaitForCurrPageToFinishLoading(driver, MaxWaitTimeInSecs);
            Assert.That(driver.Url, Does.StartWith("https://www.wholefoodsmarket.com/company-info/covid-19-response"));
        }
    }
}