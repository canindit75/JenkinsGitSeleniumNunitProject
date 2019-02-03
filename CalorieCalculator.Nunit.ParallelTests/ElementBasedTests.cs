using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace CalorieCalculator.Nunit.ParallelTests
{
    [TestFixture]
    [Parallelizable]
    public class ElementBasedTests : TestBase
    {
        
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRun")]
        public void VerifyDropDownCount(String browserName)
        {
            SetUp(browserName);
            driver.Url = "https://www.calculator.net/bmi-calculator.html";

            int DropDownCount = driver.FindElements(By.XPath("//select")).Count;
            Assert.AreEqual(0, DropDownCount);
        }

        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRun")]
        public void VerifyTextBoxCount(String browserName)
        {
            SetUp(browserName);
            driver.Url = "https://www.calculator.net/bmi-calculator.html";

            int TextboxCount = driver.FindElements(By.XPath("//input[@type='text']")).Count;
            Assert.AreEqual(6, TextboxCount);
        }
    }
}
