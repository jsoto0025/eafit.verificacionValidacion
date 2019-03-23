using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestA
{
    [TestClass]
    public class MainTest
    {

        IWebDriver driver;

        [TestInitialize]
        public  void TestInitialice()
        {
            driver = new ChromeDriver();
        }

        [TestMethod]
        [Priority(0)]
        public void LoginTest()
        {


            driver.Url = "https://www.alkosto.com";
            Thread.Sleep(3000);

            
            var btnMyAccount = driver.FindElement(By.ClassName("my-account-link"));

            btnMyAccount.Click();

            var txtLogin = driver.FindElement(By.Id( "login-username"));

            var txtPassword = driver.FindElement(By.Id("login-password"));

            txtLogin.SendKeys("jsoto25@hotmail.com");

            txtPassword.SendKeys("indigo2");

            var btnContinuar = driver.FindElement(By.Id("send2"));

            btnContinuar.Click();

            var btnLogout = driver.FindElement(By.ClassName("log-out-link"));
            btnLogout.Click();
        }
        
        [TestCleanup]
        public  void ClassCleanup()
        {
            driver.Close();
        }
    }
}
