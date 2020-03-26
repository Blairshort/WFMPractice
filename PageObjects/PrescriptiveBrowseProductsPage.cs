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
    public class PrescriptiveBrowseProductsPage : WFMUtils.POM
    {
        public PrescriptiveBrowseProductsPage(IWebDriver aDriver) 
            : base(
                "/BrowseProducts", 
                aDriver
            )
        {
            this.AddSelDescriptor(
                "HomeLogoLink", 
                By.CssSelector("a[aria-label='Whole Foods Market']"),
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
    }
}