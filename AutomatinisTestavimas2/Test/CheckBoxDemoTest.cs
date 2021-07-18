using AutomatinisTestavimas2.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2.Test
{
    public class CheckBoxDemoTest
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
        public void TestOneCheckBox()
        {
            CheckBoxDemoPage page = new CheckBoxDemoPage(_driver);
            page.SelectFirstCheckBox()
                .CheckText();
        }

        [Test]
        public static void TestMultipleCheckbox()
        {
            CheckBoxDemoPage page = new CheckBoxDemoPage(_driver);
            page.DeselectFirstCheckBox()
                .SelectAllElementsOfMultipleCheckBox()
                .UncheckAllButtonApeared()
                .UncheckMultipleCheckBox();
            

        }


    }
}
