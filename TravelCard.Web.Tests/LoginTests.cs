using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TravelCard.Web.Tests
{
    [TestClass]
    public class LoginTests
    {
        [TestMethod]
        public void LoginSuccessTest()
        {
            const string indexUrl = "http://localhost:5000/";
            const string homeUrl = "http://localhost:5000/home";
            
            var options = new FirefoxOptions();
            options.AddArgument("--headless");
            options.PageLoadStrategy = PageLoadStrategy.Normal;

            using IWebDriver driver = new FirefoxDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            
            driver.Navigate().GoToUrl(indexUrl);

            var usernameInput = driver.FindElement(By.Id("usernameInput"));
            var passwordInput = driver.FindElement(By.Id("passwordInput"));
            var loginButton  = driver.FindElement(By.Id("loginButton"));
            
            usernameInput.SendKeys("AnyUsername");
            passwordInput.SendKeys("AnyPassword");
            loginButton.Click();

            var actualUrl = driver.Url;

            Assert.AreEqual(homeUrl, actualUrl);
        }
    }
}