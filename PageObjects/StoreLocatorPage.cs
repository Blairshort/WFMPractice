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
    public class StoreLocatorPage
    {
        IWebDriver driver;      
           public By FindMarketTitle = By.Id("w-store-finder__header");
            By StoreFinderSearchBar = By.Id("w-store-finder__search-bar");
            By StoreLocatorMenuButton = By.ClassName("wfm-search-bar--list");
            By SearchIcon = By.Id("sf-search-icon");
            By CloseIcon = By.Id("sf-close-icon");

            public StoreLocatorPage(IWebDriver driver) {
                this.driver = driver;
        } 
    }
}