using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AlkostoFunctionalTest
{



    [TestClass]
    public class TCAlkosto003Test
    {
        public TestContext TestContext { get; set; }
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;
        private static TestContext testContext;

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

        //[TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Data\Data003.csv", "Data003#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        [Priority(3)]

        public void TheTCAlkosto003Test()
        {
            // ERROR: Caught exception [ERROR: Unsupported command [loadVars | Data003.csv | ]]
            driver.Navigate().GoToUrl("https://www.alkosto.com/");
            // ERROR: Caught exception [ERROR: Unsupported command [captureEntirePageScreenshot |  | ]]
            Utilis.TakeScreenShot(driver, "TCAlkosto003");
            string busqueda = TestContext.DataRow["busqueda"].ToString();
            driver.FindElement(By.Id("search")).Click();
            driver.FindElement(By.Id("search")).Clear();
            driver.FindElement(By.Id("search")).SendKeys(busqueda);
            // ERROR: Caught exception [ERROR: Unsupported command [captureEntirePageScreenshot |  | ]]
            Utilis.TakeScreenShot(driver, "TCAlkosto003");
            driver.FindElement(By.Id("searchSubmit")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Ver detalle'])[3]/following::button[1]")).Click();
            driver.FindElement(By.Id("go_cart_btn")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [captureEntirePageScreenshot |  | ]]
            Utilis.TakeScreenShot(driver, "TCAlkosto003");
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

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
