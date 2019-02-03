using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;

namespace CalorieCalculator.Nunit.ParallelTests
{
   
   public class TestBase
    {
       protected IWebDriver driver;
        public static IEnumerable<String> BrowserToRun()
        {
            String[] browsers = { "chrome", "firefox" };
            foreach (String b in browsers)
            {
                yield return b;
            }
        }
     
        public void SetUp(String browserName)
        {
            if (browserName.Equals("chrome"))
                driver = new ChromeDriver();
            else if (browserName.Equals("ie"))
                driver = new InternetExplorerDriver();
            else if (browserName.Equals("firefox"))
                driver = new FirefoxDriver();
            //driver.Navigate().GoToUrl("https://www.calculator.net/bmi-calculator.html");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
