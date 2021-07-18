using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2
{
   class ND1Justino
    {
        [Test]
        public static void TestTwoPlusTwo()
        {
            int i = 2 + 2;
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            IWebElement inputField1 = chrome.FindElement(By.Id("sum1"));
            inputField1.SendKeys("2");
            IWebElement inputField2 = chrome.FindElement(By.Id("sum2"));
            inputField2.SendKeys("2");
            IWebElement button = chrome.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();
            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(i, int.Parse(result.Text), "Nelygu 2");
            chrome.Quit();
        }
        [Test]
        public static void TestMinusFivePlusThree()
        {
            int i = -5 + 3;
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            IWebElement inputField1 = chrome.FindElement(By.Id("sum1"));
            inputField1.SendKeys("-5");
            IWebElement inputField2 = chrome.FindElement(By.Id("sum2"));
            inputField2.SendKeys("3");
            IWebElement button = chrome.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();
            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(i, int.Parse(result.Text), "Nelygu -2");
            chrome.Quit();
        }
        [Test]
        public static void TestAPlusB()
        {
            string i = "NaN";
            IWebDriver firefox = new FirefoxDriver();
            firefox.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            IWebElement inputField1 = firefox.FindElement(By.Id("sum1"));
            inputField1.SendKeys("a");
            IWebElement inputField2 = firefox.FindElement(By.Id("sum2"));
            inputField2.SendKeys("b");

            IWebElement button = firefox.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();
            IWebElement result = firefox.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(i, result.Text, "A plus B error");
            firefox.Quit();
        }
    }
}
