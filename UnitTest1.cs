using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

namespace WFMPractice
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            this.driver = WFMUtils.InitDriver("Chrome", "C:\\Users\\bshort\\WebDriver");
        }

        [TestCase("WeeklySales")]
        [TestCase("Tips&Ideas")]
        [TestCase("StoreLocator")]
        [TestCase("BrowseProducts")]
        [TestCase("Covid19Update")]
        public void TestWFMMainPageMenu(string MenuCode)
        {
            WFMUtils.LoadWebPage(this.driver, "https://www.wholefoodsmarket.com/");
        
            WFMMainPage WFMMainPageObj = new WFMMainPage(driver);
            WFMMainPageObj.DoMenuHover(WFMMainPageObj.NavMenuSelectors[MenuCode]);
            // Assert.Pass();
        }

        [Test]
        public void TestWeeklySalesClick()
        {
            WFMUtils.LoadWebPage(this.driver, "https://www.wholefoodsmarket.com/");

            WFMMainPage WFMMainPageObj = new WFMMainPage(driver);
            WFMMainPageObj.DoMenuHoverThenClickMenuLink(WFMMainPageObj.NavMenuSelectors["WeeklySales"], "Weekly Sales");
            // Assert.Pass();
            WeeklySalesPage WeeklySalesPageObj = new WeeklySalesPage(driver);
            WeeklySalesPageObj.ConfirmWeeklySalesPageTitle(WeeklySalesPageObj.NavMenuSelectors["WeeklySales"], "Weekly Sales");

            Thread.Sleep(2000); 
        }

        [OneTimeTearDown]
        public void Close()
        {
            driver.Close();
        }
    }
}