




using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomatinisTestavimas2
{
    class Class3
    {
        private static IWebDriver _driver;
        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement popUp = _driver.FindElement(By.Id("at-cv-lightbox-close"));
            wait.Until(d => popUp.Displayed);
            popUp.Click();
        }
        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }
        [TestCase("2", "2", "4", TestName = "2 plius 2 = 4")]
        [TestCase("-5", "3", "-2", TestName = "-5 plius 3 = -2")]
        [TestCase("a", "b", "NaN", TestName = "a plius b = NaN")]
        public static void TestSum(string firstName, string secondName, string result)
        {
            IWebElement firstInput = _driver.FindElement(By.Id("sum1"));
            IWebElement secondInput = _driver.FindElement(By.Id("sum2"));
            firstInput.Clear();
            firstInput.SendKeys(firstName);
            secondInput.Clear();
            secondInput.SendKeys(secondName);
            _driver.FindElement(By.CssSelector("#gettotal > button")).Click();
            IWebElement resultFromPage = _driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(result, resultFromPage.Text, "Result is NOK");

        }
    }
}
