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
    class Class2
    {
        [Test]
        public static void TestChromeDriver()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://login.yahoo.com/";
            chrome.Quit();
        }
        [Test]
        public static void TestFirefoxDriver()
        {
            IWebDriver firefox = new FirefoxDriver();
            firefox.Url = "https://login.yahoo.com/";
            firefox.Quit();
        }

        [Test]
        public static void TestYahooPage()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://login.yahoo.com/";
            IWebElement loginInputField = chrome.FindElement(By.Id("login-username"));
            loginInputField.SendKeys("Test");
            chrome.Quit();
        }

        [Test]
        public static void TestSeleniumPage()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "http://www.seleniumeasy.com/test/basic-first-form-demo.html";
            IWebElement InputField = chrome.FindElement(By.Id("user-message"));
            string myText = "Grazu";
            InputField.SendKeys(myText);
            IWebElement button = chrome.FindElement(By.CssSelector("#get-input > button"));
            button.Click();
            IWebElement result = chrome.FindElement(By.Id("display"));
            Assert.AreEqual(myText, result.Text, "Tekstas neatsirado");
            chrome.Quit();
        }

        [Test]
        public static void TestSeleniumPageTwoInputFields1()
            {
            IWebDriver firefox = new FirefoxDriver();
            firefox.Url = "http://www.seleniumeasy.com/test/basic-first-form-demo.html";
            IWebElement InputField1 = firefox.FindElement(By.Id("sum1"));
            string txtNum1 = "2";
            InputField1.SendKeys(txtNum1);
            IWebElement InputField2 = firefox.FindElement(By.Id("sum2"));
            string txtNum2 = "2";
            InputField2.SendKeys(txtNum2);
            IWebElement button = firefox.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();
            IWebElement result = firefox.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("4", result.Text, "Suma nėra 4");
            firefox.Quit();



        }

        [Test]
        public static void TestSeleniumPageTwoInputFields2()
        {
            IWebDriver firefox = new FirefoxDriver();
            firefox.Url = "http://www.seleniumeasy.com/test/basic-first-form-demo.html";
            IWebElement InputField1 = firefox.FindElement(By.Id("sum1"));
            string txtNum1 = "-5";
            InputField1.SendKeys(txtNum1);
            IWebElement InputField2 = firefox.FindElement(By.Id("sum2"));
            string txtNum2 = "3";
            InputField2.SendKeys(txtNum2);
            IWebElement button = firefox.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();
            IWebElement result = firefox.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("-2", result.Text, "Suma nėra -2");
            firefox.Quit();



        }

        [Test]
        public static void TestSeleniumPageTwoInputFields3()
        {
            IWebDriver firefox = new FirefoxDriver();
            firefox.Url = "http://www.seleniumeasy.com/test/basic-first-form-demo.html";
            IWebElement InputField1 = firefox.FindElement(By.Id("sum1"));
            string txtNum1 = "a";
            InputField1.SendKeys(txtNum1);
            IWebElement InputField2 = firefox.FindElement(By.Id("sum2"));
            string txtNum2 = "b";
            InputField2.SendKeys(txtNum2);
            IWebElement button = firefox.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();
            IWebElement result = firefox.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("NaN", result.Text, "Raidžių suma nėra NaN");
            firefox.Quit();



        }

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


    }

}
