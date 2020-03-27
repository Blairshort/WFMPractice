using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;


namespace WFMPractice
{
    public class WFMUtils
    {
        public class SelDescriptor
        {
            public By BySelector;
            public Dictionary<string, string> AttrsDict;
            public string Name;
            public SelDescriptor(string aName, By aBySelector, Dictionary<string,string> aAttrsDict)
            {
                Name = aName;
                BySelector = aBySelector;
                AttrsDict = aAttrsDict;
            }

            public Boolean HasAttr(string aAttrName)
            {
                if (AttrsDict.ContainsKey(aAttrName))
                {
                    return true;
                }
                return false;
            }

            public string GetAttrVal(string aAttrName)
            {
                return AttrsDict[aAttrName];
            }
        } 

        public class SelsMgr
        {
            public Dictionary<string, SelDescriptor> SelsDict;

            public SelsMgr()
            {
                SelsDict = new Dictionary<string, SelDescriptor>();
            }
            public void AddSelDescriptor(string aName, By aBySelector, Dictionary<string,string> aAttrsDict)
            {
                SelsDict.Add(aName, new SelDescriptor(aName, aBySelector, aAttrsDict));
            }

            public By GetBySelector(string aName)
            {
                return SelsDict[aName].BySelector;
            }

            public SelDescriptor GetSelDescriptor(string aName)
            {
                return SelsDict[aName];
            }


            public List<By> GetBySelectorsList_EltsHavingAttrName(string aAttrName)
            {
                List<By> BySelectorsList = new List<By>();

                foreach(KeyValuePair<string, SelDescriptor> CurrSelKV in SelsDict)
                {
                    if (CurrSelKV.Value.HasAttr(aAttrName))
                    {
                        BySelectorsList.Add(CurrSelKV.Value.BySelector);
                    }
                }
                return BySelectorsList;
            }

            public List<By> GetBySelectorsList_EltsHavingAttrNameVal(string aAttrName, string aAttrVal)
            {
                List<By> BySelectorsList = new List<By>();

                foreach(KeyValuePair<string, SelDescriptor> CurrSelKV in SelsDict)
                {
                    if (CurrSelKV.Value.HasAttr(aAttrName) && CurrSelKV.Value.GetAttrVal(aAttrVal) == aAttrVal)
                    {
                        BySelectorsList.Add(CurrSelKV.Value.BySelector);
                    }
                }
                return BySelectorsList;
            }
        } 

        public class POM
        {
            public static Dictionary<string, POM> POMRegistry = new Dictionary<string, POM>();
            public IWebDriver driver;
            public string Path;
            public SelsMgr SelsMgr;
        
            public POM(string aPath, IWebDriver aDriver)
            {
                Path = aPath;
                driver = aDriver;
                SelsMgr = new SelsMgr();

                POMRegistry.Add(Path, this); // Add this POM to the registry
            }

            public void AddSelDescriptor(string aName, By aBySelector, Dictionary<string,string> aAttrsDict)
            {
                this.SelsMgr.AddSelDescriptor(aName, aBySelector, aAttrsDict);
            }
            public By GetBySelector(string aName)
            {
                return SelsMgr.GetBySelector(aName);
            }

            public void WaitForAllStaticEltsToBeVisible(int aTimeoutInSecs=10)
            {
                List<By> StaticEltsBySelectorsList = SelsMgr.GetBySelectorsList_EltsHavingAttrName("isStatic");
                WaitForAllEltsToBeVisible(driver, StaticEltsBySelectorsList, aTimeoutInSecs);
            }            

            public void WaitForPageToFinishLoading(int aTimeoutInSecs=10) 
            {
                new WebDriverWait(
                    driver, 
                    TimeSpan.FromSeconds(aTimeoutInSecs)
                ).Until(
                    d => ((IJavaScriptExecutor) d).ExecuteScript("return document.readyState").Equals("complete")
                );

                WaitForAllStaticEltsToBeVisible(aTimeoutInSecs);
            }

            public IWebElement ClickEltByName(string aEltName, int MaxWaitTimeInSecs=10)
            {
                SelDescriptor CurrSelDescriptor = SelsMgr.GetSelDescriptor(aEltName);
                IWebElement elt = driver.FindElement(CurrSelDescriptor.BySelector);
                elt.Click();
                if (CurrSelDescriptor.HasAttr("ClickCausesPageLoad"))
                {
                    WaitForCurrPageToFinishLoading(driver, MaxWaitTimeInSecs);
                    return null;
                } else
                {
                    return elt;
                }
            }
        }

        public static void LoadWebPage(IWebDriver driver, string Url, int TimeoutInSecs=10) 
        {
            driver.Url = Url;
            WaitForCurrPageToFinishLoading(driver, TimeoutInSecs);
        }

        public static void WaitForCurrPageToFinishLoading(IWebDriver driver, int TimeoutInSecs=10) 
        {
            new WebDriverWait(
                driver, 
                TimeSpan.FromSeconds(TimeoutInSecs)
            ).Until(
                d => ((IJavaScriptExecutor) d).ExecuteScript("return document.readyState").Equals("complete")
            );
        }

        public static IWebDriver InitDriver(string DriverType, string DriverDirPath) 
        {
            IWebDriver driver;
            string[] ValidDriverTypes = {"FireFox", "Chrome"};
            
            if (DriverType == "FireFox") {
                driver = new FirefoxDriver(DriverDirPath);
            } else if (DriverType == "Chrome")  {
                driver = new ChromeDriver(DriverDirPath);
            } else {
                throw new System.ArgumentException($"Parameter 'DriverType' was provided the value \"{DriverType}\"; it must be one of: \"{string.Join("\", \"", ValidDriverTypes)}\"!");
            }

            driver.Manage().Window.Maximize();
            _ = driver.Manage().Timeouts().ImplicitWait;
            return driver;
        }

        public static void WaitForUrl(IWebDriver driver, String url, int TimeoutInSecs=10) {
           new WebDriverWait(
               driver,
               TimeSpan.FromSeconds(TimeoutInSecs)
           ).Until(
               ExpectedConditions.UrlToBe(url)
           );
        }

        public static void WaitForAllEltsToBeVisible(IWebDriver driver, List<By> aBySelectorsList, int TimeoutInSecs=10) {
            foreach (By CurrBySelector in aBySelectorsList) 
            {
                new WebDriverWait(
                    driver,
                    TimeSpan.FromSeconds(TimeoutInSecs)
                ).Until(
                    ExpectedConditions.ElementIsVisible(CurrBySelector)
                );
            }
        }

        public static void WaitForEltToBeVisible(IWebDriver driver, By BySelector, int TimeoutInSecs=10) {
           new WebDriverWait(
               driver,
               TimeSpan.FromSeconds(TimeoutInSecs)
           ).Until(
               ExpectedConditions.ElementIsVisible(BySelector)
           );
        }

        public static void ScreenshotToFilepath(IWebDriver driver, string Filepath)
        {
            try
            {
                Screenshot image = ((ITakesScreenshot) driver).GetScreenshot();
                image.SaveAsFile(Filepath, ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
               Debug.WriteLine(e);
               Assert.Fail("Exception creating screenshot!\n" + e);
            }
        } 

        public void HoverOverElt(IWebDriver driver, By EltSelector, int HoverTimeInSecs=3, int TimeoutInSecs=10)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(EltSelector));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Build().Perform();

            if (HoverTimeInSecs > 0) { 
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(HoverTimeInSecs));
            }
        }

        public void HoverOverEltThenClickLinkText(IWebDriver driver, By EltSelector, string LinkText, int HoverTimeInSecs=3, int TimeoutInSecs=10)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(EltSelector));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Build().Perform();

            if (HoverTimeInSecs > 0) {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(HoverTimeInSecs));
            }

            IWait<IWebDriver> wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeoutInSecs));
            IWebElement subelement = wait2.Until(ExpectedConditions.ElementIsVisible(By.LinkText(LinkText)));
            action.MoveToElement(subelement);
            action.Click().Build().Perform();
        }                        
    }
}