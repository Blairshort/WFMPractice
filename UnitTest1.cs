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
            Assert.Pass();
        }

        [Test]
        public void ContactUs()
        {
            WFMUtils.LoadWebPage(this.driver, "https://www.us.sogeti.com");

            WFMMainPage SogetiUSAMainPageObj = new WFMMainPage(driver);
            SogetiUSAMainPageObj.DoMenuHoverThenClickMenuLink(SogetiUSAMainPageObj.NavMenuSelectors["Contact"], "Contact us");
        
        [OneTimeTearDown]
        public void Close()
        {
            driver.Close();
        }
    }
}