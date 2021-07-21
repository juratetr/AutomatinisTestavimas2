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
    public class DropDownDemoTest
    {
        private static DropDownDemoPage _page;

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new DropDownDemoPage(driver);
        }

        [OneTimeTearDown]

        public static void TearDown()
        {
            //_page.CloseBrowser();
        }

        [Test]
        public void TestDropdown()
        {
            _page.SelectFromDropdownByValue("Friday")
                .VerifyResult("Friday");
        }
        [Test]
        public void TestMultipleDropdown()
        {
            _page.SelectFromMultipleDropDownByValue1("Florida", "Ohio");
            _page.ClickAllSelectedButton();
        }

        [TestCase("New Jersey", "California", TestName = "Pasirenkame 2 reiksmes ir patikriname")]
        public void TestMultipleDropdown1(params string[] selectedElements)
        {
            _page.SelectFromMultipleDropdownByValue(selectedElements.ToList())
                            .ClickAllSelectedButton();
        }
    }


}
