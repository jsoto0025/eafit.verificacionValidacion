using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class AdicionarItemACarrito
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;
        
        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.katalon.com/";
        }
        
        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                //driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        
        [TestInitialize]
        public void InitializeTest()
        {
            verificationErrors = new StringBuilder();
        }
        
        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [TestMethod]
        public void TheAdicionarItemACarritoTest()
        {
            driver.Navigate().GoToUrl("https://www.alkosto.com/");
            // ERROR: Caught exception [ERROR: Unsupported command [captureEntirePageScreenshot |  | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame | index=1 | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame | relative=parent | ]]
            driver.FindElement(By.LinkText("Mi cuenta")).Click();
            driver.FindElement(By.Id("login-username")).Click();
            driver.FindElement(By.Id("login-username")).Clear();
            driver.FindElement(By.Id("login-username")).SendKeys("jsoto25@hotmail.com");
            driver.FindElement(By.Id("login-password")).Clear();
            driver.FindElement(By.Id("login-password")).SendKeys("indigo2");
            driver.FindElement(By.Id("send2")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [captureEntirePageScreenshot |  | ]]
            driver.FindElement(By.LinkText("LG")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Celular LG K9 SS 4G Azul'])[1]/following::img[1]")).Click();
            driver.FindElement(By.LinkText("Mi cuenta")).Click();
            driver.FindElement(By.LinkText("Cerrar sesión")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
