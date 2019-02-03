using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CalorieCalculator.Nunit.ParallelTests
{
    [TestFixture]
    [Parallelizable]
    public class LoginTest : TestBase
    {
        //public static IEnumerable<String> BrowserToRun()
        //{
        //    String[] browsers = { "chrome", "firefox" };
        //    foreach(String b in browsers)
        //    {
        //        yield return b;
        //    }
        //}
        
        [Test]
        [TestCaseSource(typeof(TestBase),"BrowserToRun")]
        public void ValidLogin(String browserName)
        {
            SetUp(browserName);
            driver.Url = "http://www.facebook.com";
            driver.FindElement(By.Name("email")).SendKeys("anindita.chandra@gmail.com");
            driver.FindElement(By.Name("pass")).SendKeys("Canindit75#");
            driver.FindElement(By.XPath("//*[@type='submit']")).Click();
            Assert.AreEqual(driver.Title, "Facebook");
            

        }
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRun")]
        public void InValidLogin(String browserName)
        {
            SetUp(browserName);
            driver.Url = "http://www.facebook.com";
            driver.FindElement(By.Name("email")).SendKeys("anindita.chandra@gmail.com");
            driver.FindElement(By.Name("pass")).SendKeys("pass");
            driver.FindElement(By.XPath("//*[@type='submit']")).Click();
            Assert.AreEqual(driver.Title, "Facebook - log in or sign in");
        }
    }
}
