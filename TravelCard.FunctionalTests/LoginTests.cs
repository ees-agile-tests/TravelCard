using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TravelCard.FunctionalTests
{
    [TestClass]
    public class LoginTests
    {
        [TestMethod]
        public void Login()
        {
            using IWebDriver browser = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            
            browser.Navigate().GoToUrl("https://www.google.com");

            Assert.AreEqual("Google", browser.Title);
        }
    }
}