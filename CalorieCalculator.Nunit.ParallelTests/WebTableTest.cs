using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace CalorieCalculator.Nunit.ParallelTests
{
    [TestFixture]
    [Parallelizable]
    public class WebTableTest : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRun")]
        public void VerifyTableRowCount(String browserName)
        {
            SetUp(browserName);
            driver.Url = "https://www.calculator.net/bmi-calculator.html";
            
            int TableRowCount = driver.FindElements(By.XPath("//*[@class='cinfoT'][1]/tbody/tr")).Count;
            Assert.AreEqual(9, TableRowCount);
        }
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRun")]
        public void VerifyCountLinks(String browserName)
        {
            SetUp(browserName);
            driver.Url = "https://www.calculator.net/bmi-calculator.html";
            int LinkCount = driver.FindElements(By.XPath("//a")).Count;
            Assert.AreEqual(LinkCount, 31);



        }
    }
}
