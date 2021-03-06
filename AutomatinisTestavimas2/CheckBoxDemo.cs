using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2
{
    class CheckBoxDemo
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-checkbox-demo.html");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public static void TestOneCheckBox()
        {
            _driver.FindElement(By.Id("isAgeSelected")).Click();
            IWebElement text = _driver.FindElement(By.Id("txtAge"));
            Assert.IsTrue(text.Text.Equals("Success - Check box is checked"));
        }

        [Test]
        public static void TestMultipleCheckbox()
        {
            IWebElement firstCheckbox = _driver.FindElement(By.Id("isAgeSelected"));
            if (firstCheckbox.Selected)
                firstCheckbox.Click();
            IReadOnlyCollection<IWebElement> multipleCheckboxList = _driver.FindElements(By.CssSelector(".cb1-element"));
            foreach (IWebElement element in multipleCheckboxList)
            {
                element.Click();
            }
        }

    }
}
