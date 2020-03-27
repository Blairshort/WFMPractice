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
        string WFMMainPageURL = "https://www.wholefoodsmarket.com/";
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            this.driver = WFMUtils.InitDriver("Chrome", "C:\\Users\\bshort\\WebDriver");
        }

        [Test]
        public void TestWFMMainPageBringup2()
        {
            WFMUtils.LoadWebPage(driver, WFMMainPageURL);
            Assert.That(driver.Url, Is.EqualTo(WFMMainPageURL));

            Thread.Sleep(2000); 
        }

        [Test]
        public void TestPrescriptiveMainPage_ClickToOtherPages()
        {
            WFMUtils.LoadWebPage(driver, WFMMainPageURL);
            Assert.That(driver.Url, Is.EqualTo(WFMMainPageURL));

            PrescriptiveMainPage PrescriptiveMainPageObj = new PrescriptiveMainPage(driver);
            // PrescriptiveMainPageObj.ClickMenu_ToWeeklySalesPage();
            // PrescriptiveMainPageObj.ClickToHomePage();
            // PrescriptiveMainPageObj.ClickMenu_ToTipsAndIdeasPage();
            // PrescriptiveMainPageObj.ClickToHomePage();
            // PrescriptiveMainPageObj.ClickMenu_ToStoreLocatorPage();
            // PrescriptiveMainPageObj.ClickToHomePage();
            PrescriptiveMainPageObj.ClickMenu_ToBrowseProductsPage();

            PrescriptiveBrowseProductsPage PrescriptiveBrowseProductsPageObj = new PrescriptiveBrowseProductsPage(driver);
            PrescriptiveBrowseProductsPageObj.ClickToHomePage();
            // PrescriptiveMainPageObj.ClickMenu_ToCovid19UpdatePage();
            // PrescriptiveMainPageObj.ClickToHomePage();
            Thread.Sleep(2000); 
        }

        [TestCase("WeeklySales", "https://www.wholefoodsmarket.com/sales-flyer")]
        [TestCase("Tips&Ideas", "https://inspiration.wholefoodsmarket.com/")]
        [TestCase("StoreLocator", "https://www.wholefoodsmarket.com/stores")]
        [TestCase("BrowseProducts", "https://products.wholefoodsmarket.com/")]
        [TestCase("Covid19Update", "https://www.wholefoodsmarket.com/company-info/covid-19-response")]
        public void TestWFMMainPageMenuLinks2(string MenuCode, string DestUrl)
        {
            WFMUtils.LoadWebPage(driver, WFMMainPageURL);
            Assert.That(driver.Url, Is.EqualTo(WFMMainPageURL));

            WFMMainPage WFMMainPageObj = new WFMMainPage(driver);

            driver.FindElement(WFMMainPageObj.NavMenuSelectors[MenuCode]).Click();
            WFMUtils.WaitForCurrPageToFinishLoading(driver);
            Assert.That(driver.Url, Does.StartWith(DestUrl));

            Thread.Sleep(2000); 
        }

        [Test]
        public void TestBrowseProducts_FindStore2()
        {
            WFMUtils.LoadWebPage(driver, WFMMainPageURL);
            Assert.That(driver.Url, Is.EqualTo(WFMMainPageURL));

            WFMMainPage WFMMainPageObj = new WFMMainPage(driver);
            WFMMainPageObj.ClickToBrowseProductsMenu();

            BrowseProductsPage BrowseProductsPageObj = new BrowseProductsPage(driver);
            BrowseProductsPageObj.SetFindStoreSearchBoxText("FindStore", "78758");
            BrowseProductsPageObj.ClickStoreFromSearch("FindStoreSearchResult", "Domain — 11920 Domain Dr, Austin, TX 78758");
            Assert.That(driver.FindElement(BrowseProductsPageObj.PageElements["SavedStoreLocation"]).GetAttribute("innerText"), Is.EqualTo("Domain"));
            WFMUtils.ScreenshotToFilepath(driver, "jeffshot.png");
            Thread.Sleep(2000); 
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

        }

        [Test]
        public void TestWeeklySalesClick()
        {
            WFMUtils.LoadWebPage(this.driver, "https://www.wholefoodsmarket.com/");

            WFMMainPage WFMMainPageObj = new WFMMainPage(driver);
            WFMMainPageObj.ClickMenuLink(WFMMainPageObj.NavMenuSelectors["WeeklySales"], "Weekly Sales");
            WFMMainPageObj.Equals ("https://www.wholefoodsmarket.com/sales-flyer");
            Thread.Sleep(2000); 
        }

        [Test]
        public void TestTipsAndIdeasClick()
        {
            WFMUtils.LoadWebPage(this.driver, "https://www.wholefoodsmarket.com/");

            WFMMainPage WFMMainPageObj = new WFMMainPage(driver);
            WFMMainPageObj.ClickMenuLink(WFMMainPageObj.NavMenuSelectors["Tips&Ideas"], "Tips & Ideas");
            WFMMainPageObj.Equals ("https://inspiration.wholefoodsmarket.com/");
            Thread.Sleep(2000); 
        }

        [Test]
        public void TestStoreLocatorClick()
        {
            WFMUtils.LoadWebPage(this.driver, "https://www.wholefoodsmarket.com/");

            WFMMainPage WFMMainPageObj = new WFMMainPage(driver);
            WFMMainPageObj.ClickMenuLink(WFMMainPageObj.NavMenuSelectors["StoreLocator"], "Store Locator");
            WFMMainPageObj.Equals ("https://www.wholefoodsmarket.com/stores");
            Thread.Sleep(2000); 
        }

        [Test]
        public void TestBrowseProductsClick()
        {
            WFMUtils.LoadWebPage(this.driver, "https://www.wholefoodsmarket.com/");

            WFMMainPage WFMMainPageObj = new WFMMainPage(driver);
            WFMMainPageObj.ClickMenuLink(WFMMainPageObj.NavMenuSelectors["BrowseProducts"], "Browse Products");
            WFMMainPageObj.Equals ("https://products.wholefoodsmarket.com/");
            Thread.Sleep(2000); 
        }

        [Test]
        public void TestCOVID19UpdateClick()
        {
            WFMUtils.LoadWebPage(this.driver, "https://www.wholefoodsmarket.com/");

            WFMMainPage WFMMainPageObj = new WFMMainPage(driver);
            WFMMainPageObj.ClickMenuLink(WFMMainPageObj.NavMenuSelectors["Covid19Update"], "COVID-19 Update");
            WFMMainPageObj.Equals ("https://www.wholefoodsmarket.com/company-info/covid-19-response");
            Thread.Sleep(2000); 
        }

        [Test]
        public void TestSearchProducts()
        {
            WFMUtils.LoadWebPage(this.driver, "https://products.wholefoodsmarket.com/");

            BrowseProductsPage BrowseProductsPageObj = new BrowseProductsPage(driver);
            BrowseProductsPageObj.SetFindStoreSearchBoxText("FindStore", "78758");
            BrowseProductsPageObj.ClickElementAfterSearch("FindStoreSearchResult", "Domain — 11920 Domain Dr, Austin, TX 78758");
            Thread.Sleep(2000); 
            Assert.AreEqual(this.driver.FindElement(BrowseProductsPageObj.PageElements["SavedStoreLocation"]).GetAttribute("innerText"), "Domain");
            Thread.Sleep(2000); 
            BrowseProductsPageObj.SetProductSearchBoxText("ProductSearchBox", "Apple");
            Thread.Sleep(2000); 
            Assert.That(this.driver.FindElement(BrowseProductsPageObj.PageElements["ProductCardName"]).GetAttribute("innerText"), Contains.Substring("Apple"));
            BrowseProductsPageObj.DoMenuHoverThenClickProductCard(BrowseProductsPageObj.PageElements["ProductCard"]);
            Thread.Sleep(3000);
            Assert.That(this.driver.FindElement(BrowseProductsPageObj.PageElements["ProductHeader"]).GetAttribute("innerText"), Contains.Substring("Apple"));
        }

        [TearDown]
        public void Close()
        {
            driver.Close();
        }
    }
}