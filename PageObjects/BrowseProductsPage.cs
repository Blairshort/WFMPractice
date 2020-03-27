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
    public class BrowseProductsPage
    {
        IWebDriver driver;
        public Dictionary<string, By> PageElements;
        public BrowseProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            this.PageElements = new Dictionary<string, By>();
            this.PageElements.Add("FindStore", By.CssSelector("input[placeholder='Search by zip code or city (U.S. stores only)']"));
            this.PageElements.Add("FindStoreSearchResult", By.XPath("//*[@id='app']/div/div/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]"));
            this.PageElements.Add("ProductSearchBox", By.ClassName("NavSearch-Input--3VNY4"));
            this.PageElements.Add("SavedStoreLocation", By.ClassName("MenuStoreName__2XKZb"));
            this.PageElements.Add("ProductCard", By.ClassName("ProductCard-Root--3g5WI"));
            this.PageElements.Add("ProductCardName", By.ClassName("ProductCard-Name--1o2Gg"));
            this.PageElements.Add("ProductHeader", By.ClassName("ProductHeader-Name--1ysBV"));
        }
        public void SetFindStoreSearchBoxText(string FieldCode, string FieldText, int SleepTimeInMilliSecs=4000)
        {
            IWebElement FindStoreSearchBox = this.driver.FindElement(this.PageElements["FindStore"]);
            
            IWait<IWebDriver> wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
            IWebElement FieldElt = wait.Until(ExpectedConditions.ElementIsVisible(this.PageElements[FieldCode]));

            FieldElt.SendKeys(FieldText);

            this.driver.SwitchTo().DefaultContent();

            if (SleepTimeInMilliSecs > 0) {
                Thread.Sleep(SleepTimeInMilliSecs);
            } 
        }

        public void ClickElementAfterSearch (string FieldCode, string FieldText, int SleepTimeInMilliSecs=4000)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement subelement = wait.Until(ExpectedConditions.ElementIsVisible(this.PageElements[FieldCode]));
            Actions action = new Actions(driver);
            action.MoveToElement(subelement);
            action.Click().Build().Perform();
        }

        public void SetProductSearchBoxText(string FieldCode, string FieldText, int SleepTimeInMilliSecs=4000)
        {
            IWebElement ProductSearchBox = this.driver.FindElement(this.PageElements["ProductSearchBox"]);
            
            IWait<IWebDriver> wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
            IWebElement FieldElt = wait.Until(ExpectedConditions.ElementIsVisible(this.PageElements[FieldCode]));

            FieldElt.SendKeys(FieldText);

            this.driver.SwitchTo().DefaultContent();

            if (SleepTimeInMilliSecs > 0) {
                Thread.Sleep(SleepTimeInMilliSecs);
            } 
        }

        public void DoMenuHoverThenClickProductCard(By PageElements, int HoverSleepTimeInMilliSecs=4000)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(PageElements));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Build().Perform();

            if (HoverSleepTimeInMilliSecs > 0) {
                System.Threading.Thread.Sleep(HoverSleepTimeInMilliSecs);
            }

            IWait<IWebDriver> wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement subelement = wait2.Until(ExpectedConditions.ElementIsVisible(PageElements));
            action.MoveToElement(subelement);
            action.Click().Build().Perform();
        }
        
        // public string GetSavedStoreText(By PageElements, string LinkText)
        // {
        //     IWebElement ContactIFrame = this.driver.FindElement(this.PageElements["SavedStoreLocation"]);
        //     this.driver.SwitchTo().Frame(ContactIFrame);
            
        //     IWait<IWebDriver> wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
        //     IWebElement FieldElt = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(LinkText)));

        //     string FieldText = FieldElt.GetAttribute("value");

        //     this.driver.SwitchTo().DefaultContent();

        //     return FieldText;
        // }

    }
}