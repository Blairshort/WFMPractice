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
            this.PageElements.Add("ProductSearchBox", By.ClassName("NavSearch-Root--xmvRY"));
            this.PageElements.Add("SavedStoreLocation", By.ClassName("MenuStoreName__2XKZb"));
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

        public void ClickStoreFromSearch (string FieldCode, string FieldText, int SleepTimeInMilliSecs=4000)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement subelement = wait.Until(ExpectedConditions.ElementIsVisible(this.PageElements[FieldCode]));
            Actions action = new Actions(driver);
            action.MoveToElement(subelement);
            action.Click().Build().Perform();
        }

        public string GetSavedStoreText(By PageElements, string LinkText)
        {
            IWebElement ContactIFrame = this.driver.FindElement(this.PageElements["SavedStoreLocation"]);
            this.driver.SwitchTo().Frame(ContactIFrame);
            
            IWait<IWebDriver> wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
            IWebElement FieldElt = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(LinkText)));

            string FieldText = FieldElt.GetAttribute("value");

            this.driver.SwitchTo().DefaultContent();

            return FieldText;
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
    }
}