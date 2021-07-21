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
    public class DropDownNDTest
    {
        private static DropDownNDPage _page;
        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new DropDownNDPage(driver);
        }

        [OneTimeTearDown]

        public static void TearDown()
        {
            //_page.CloseBrowser();
        }

       
        [TestCase("New York", "Washington", TestName = "1) Pasirenkame 2 reiksmes ir patikriname, ar rodo pirmą pažymėtą.")]
        public void Test1(params string[] selectedElements)
        {
            _page.DeselectAll()
                 .SelectFromMultipleDropdownByValue(selectedElements.ToList())
                 .ClickFirstSelectedButton()
                 .VerifyResultFirstSelected(selectedElements.First());
        }

        [TestCase("Florida", "Ohio", TestName = "2) Pasirenkame dvi reikšmes ir patikriname, ar rodo visas pasirinktas.")]
        public void Test2(params string[] selectedElements)
        {
            _page.DeselectAll()
                 .SelectFromMultipleDropdownByValue(selectedElements.ToList())
                 .ClickGetAllSelectedButton()
                 .VerifyResultAllSelected();
        }

        [TestCase("Texas", "California", "New Jersey", TestName = "3) Pasirenkame 3 reikšmes ir patikriname, ar rodo pirmą pažymėtą.")]
        public void Test3(params string[] selectedElements)
        {
            
            _page.DeselectAll()
                 .SelectFromMultipleDropdownByValue(selectedElements.ToList())
                 .ClickFirstSelectedButton()
                 .VerifyResultFirstSelected(selectedElements.First());
                
        }

        [TestCase("Pennsylvania", "New York", "Washington", "Florida", TestName = "4) Pasirenkame 4 reikšmes ir patikriname, ar rodo visas pasirinktas.")]
        public void Test4(params string[] selectedElements)
        {
            _page.DeselectAll()
                 .SelectFromMultipleDropdownByValue(selectedElements.ToList())
                 .ClickGetAllSelectedButton()
                 .VerifyResultAllSelected();
        }

    }
}
