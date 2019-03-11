using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestA
{
    [TestClass]
    public class MainTest
    {

        ChromeDriver chromeDriver;

        [TestInitialize]
        public void TestInitialice()
        {
            chromeDriver = new ChromeDriver();
            chromeDriver.Url = "https://www.alkosto.com";

            //var ventana = chromeDriver.FindElementByClassName("grow");
            //ventana.Click();
        }

        [TestMethod]
        [Priority(0)]
        public void LoginTest()
        {
            
            var btnMyAccount = chromeDriver.FindElementByClassName("my-account-link");

            btnMyAccount.Click();

            var txtLogin = chromeDriver.FindElementById("login-username");

            var txtPassword = chromeDriver.FindElementById("login-password");

            txtLogin.SendKeys("jsoto25@hotmail.com");

            txtPassword.SendKeys("indigo2");

            var btnContinuar = chromeDriver.FindElementById("send2");

            btnContinuar.Click();
            
        }

        [TestMethod]
        [Priority(1)]
        public void LogoutTest()
        {
            
            var btnLogout = chromeDriver.FindElementByClassName("log-out-link");
            btnLogout.Click();
            
        }
    }
}
