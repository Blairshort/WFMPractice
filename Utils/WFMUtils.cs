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
        } 

        public class POM
        {
            public static Dictionary<string, POM> POMRegistry = new Dictionary<string, POM>();
            public IWebDriver driver;
            public string Path;
            public SelsMgr SelsMgr;
        
            public POM(string aPath, IWebDriver aDriver)
            {
                POMRegistry.Add(Path, this); // Add this POM to the registry

                Path = aPath;
                driver = aDriver;
                SelsMgr = new SelsMgr();
            }

            public void AddSelDescriptor(string aName, By aBySelector, Dictionary<string,string> aAttrsDict)
            {
                this.SelsMgr.AddSelDescriptor(aName, aBySelector, aAttrsDict);
            }
            public By GetBySelector(string aName)
            {
                return SelsMgr.GetBySelector(aName);
            }
        }

        public static void LoadWebPage(IWebDriver driver, string Url, int TimeoutInSecs=10) 
        {
            driver.Url = Url;
            WaitForCurrPageToFinishLoading(driver, TimeoutInSecs);
            // new WebDriverWait(
            //     driver, 
            //     TimeSpan.FromSeconds(TimeoutInSecs)
            // ).Until(
            //     d => ((IJavaScriptExecutor) d).ExecuteScript("return document.readyState").Equals("complete")
            // );
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
    }
}