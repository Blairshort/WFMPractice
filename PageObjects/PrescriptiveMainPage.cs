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
                    {"isStatic", "y"},
                    {"clickCausesPageLoad", "y"}
                }
            );
            this.AddSelDescriptor(
                "Menu_WeeklySales", 
                By.XPath("//*[@class='menu__nav menu--main__nav']//*[text()='Weekly Sales']"),
                new Dictionary<string,string>{
                    {"isStatic", "y"},
                    {"clickCausesPageLoad", "y"}
                }
            );
            this.AddSelDescriptor(
                "Button_SeeWeeklySales", 
                By.XPath("//a[text()='See weekly sales']"),
                new Dictionary<string,string>{
                    {"isStatic", "y"},
                    {"clickCausesPageLoad", "y"}
                }
            );
            this.AddSelDescriptor(
                "Menu_Tips&Ideas", 
                By.XPath("//*[@class='menu__nav menu--main__nav']//*[text()='Tips & Ideas']"),
                new Dictionary<string,string>{
                    {"isStatic", "y"},
                    {"clickCausesPageLoad", "y"}
                }
            );
            this.AddSelDescriptor(
                "Menu_StoreLocator", 
                By.XPath("//*[@class='menu__nav menu--main__nav']//*[text()='Store Locator']"),
                new Dictionary<string,string>{
                    {"isStatic", "y"},
                    {"clickCausesPageLoad", "y"}
                }
            );
            this.AddSelDescriptor(
                "Button_FindAStore", 
                By.XPath("//a[text()='Find a store']"),
                new Dictionary<string,string>{
                    {"isStatic", "y"},
                    {"clickCausesPageLoad", "y"}
                }
            );
            this.AddSelDescriptor(
                "Button_FindYourStore", 
                By.XPath("//a[text()='Find your store']"),
                new Dictionary<string,string>{
                    {"isStatic", "y"},
                    {"clickCausesPageLoad", "y"}
                }
            );
            this.AddSelDescriptor(
                "Menu_BrowseProducts", 
                By.XPath("//*[@class='menu__nav menu--main__nav']//*[text()='Browse Products']"),
                new Dictionary<string,string>{
                    {"isStatic", "y"},
                    {"clickCausesPageLoad", "y"}
                }
            );
            this.AddSelDescriptor(
                "Button_BrowseProducts", 
                By.XPath("//a[text()='Browse products']"),
                new Dictionary<string,string>{
                    {"isStatic", "y"},
                    {"clickCausesPageLoad", "y"}
                }
            );
            this.AddSelDescriptor(
                "Button_GetDelivery&Pickup", 
                By.XPath("//a[text()='Get delivery & pickup']"),
                new Dictionary<string,string>{
                    {"isStatic", "y"},
                    {"clickCausesPageLoad", "y"}
                }
            );
            this.AddSelDescriptor(
                "Menu_Covid19Update", 
                By.XPath("//*[@class='menu__nav menu--main__nav']//*[text()='COVID-19 Update']"),
                new Dictionary<string,string>{
                    {"isStatic", "y"},
                    {"clickCausesPageLoad", "y"}
                }
            );
        }

        public void ClickToHomePage(int MaxWaitTimeInSecs=10)
        {
            ClickEltByName("HomeLogoLink");
            // WFMUtils.WaitForCurrPageToFinishLoading(driver, MaxWaitTimeInSecs);
            Assert.That(driver.Url, Does.StartWith("https://www.wholefoodsmarket.com/"));
        }


        public void ClickMenu_ToWeeklySalesPage(int MaxWaitTimeInSecs=10)
        {
            ClickEltByName("Menu_WeeklySales");
            // WFMUtils.WaitForCurrPageToFinishLoading(driver, MaxWaitTimeInSecs);
            Assert.That(driver.Url, Does.StartWith("https://www.wholefoodsmarket.com/sales-flyer"));
        }

        public void ClickButton_SeeWeeklySalesPage(int MaxWaitTimeInSecs=10)
        {
            ClickEltByName("Button_SeeWeeklySales");
            // WFMUtils.WaitForCurrPageToFinishLoading(driver, MaxWaitTimeInSecs);
            Assert.That(driver.Url, Does.StartWith("https://www.wholefoodsmarket.com/sales-flyer"));
        }

        public void ClickMenu_ToTipsAndIdeasPage(int MaxWaitTimeInSecs=10)
        {
            ClickEltByName("Menu_Tips&Ideas");
            // WFMUtils.WaitForCurrPageToFinishLoading(driver, MaxWaitTimeInSecs);
            Assert.That(driver.Url, Does.StartWith("https://inspiration.wholefoodsmarket.com/"));
        }

        public void ClickMenu_ToStoreLocatorPage(int MaxWaitTimeInSecs=10)
        {
            ClickEltByName("Menu_StoreLocator");
            // WFMUtils.WaitForCurrPageToFinishLoading(driver, MaxWaitTimeInSecs);
            Assert.That(driver.Url, Does.StartWith("https://www.wholefoodsmarket.com/stores"));
        }

        public void ClickButton_FindAStore(int MaxWaitTimeInSecs=10)
        {
            ClickEltByName("Button_FindAStore");
            // WFMUtils.WaitForCurrPageToFinishLoading(driver, MaxWaitTimeInSecs);
            Assert.That(driver.Url, Does.StartWith("https://www.wholefoodsmarket.com/stores"));
        }

        public void ClickButton_FindYourStore(int MaxWaitTimeInSecs=10)
        {
            ClickEltByName("Button_FindYourStore");
            // WFMUtils.WaitForCurrPageToFinishLoading(driver, MaxWaitTimeInSecs);
            Assert.That(driver.Url, Does.StartWith("https://www.wholefoodsmarket.com/stores"));
        }

        public void ClickMenu_ToBrowseProductsPage(int MaxWaitTimeInSecs=10)
        {
            ClickEltByName("Menu_BrowseProducts");
            // WFMUtils.WaitForCurrPageToFinishLoading(driver, MaxWaitTimeInSecs);
            Assert.That(driver.Url, Does.StartWith("https://products.wholefoodsmarket.com/"));
        }

        public void ClickMenu_ToCovid19UpdatePage(int MaxWaitTimeInSecs=10)
        {
            ClickEltByName("Menu_Covid19Update");
            // WFMUtils.WaitForCurrPageToFinishLoading(driver, MaxWaitTimeInSecs);
            Assert.That(driver.Url, Does.StartWith("https://www.wholefoodsmarket.com/company-info/covid-19-response"));
        }
    }
}