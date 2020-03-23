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
            this.PageElements.Add("FindStoreSearchResult", By.XPath("//*[@class='StoreSelector-Option--mQyct disable-click-focus']"));
            // IWebElement ExploreProductsTitle = driver.FindElement(By.ClassName("Home-Title--6Oi2Q"));
            // IWebElement FindStoreSearchBox = driver.FindElement(By.ClassName("Input-InputField--KUzM1 disable-click-focus"));
            // IWebElement FindStoreSearchResult = driver.FindElement(By.XPath("//*[@class='StoreSelector-Option--mQyct disable-click-focus']"));
            // IWebElement ProductSearchBox = driver.FindElement(By.ClassName("NavSearch-Input--3VNY4 disable-click-focus"));
        }
        //     public void ConfirExploreProductsPageTitle(string LinkText)
        // {
        //     IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        //     IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(LinkText)));
        // }

        public void SetFindStoreSearchBoxText(string FieldCode, string FieldText, int SleepTimeInMilliSecs=0)
        {
            IWebElement FindStoreSearchBox = this.driver.FindElement(this.PageElements["ContactInfoIFrame"]);
            this.driver.SwitchTo().Frame(FindStoreSearchBox);
            
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