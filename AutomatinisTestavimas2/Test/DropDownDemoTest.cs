using AutomatinisTestavimas2.Drivers;
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
    public class DropDownDemoTest : BaseTest
    {
        [Test]
        public void TestDropDown()
        {
            _dropdownDemoPage.NavigateToDefaultPage()
                             .SelectFromDropdownByText("Friday")
                             .VerifyResult("Friday");
        }

        [TestCase("New Jersey", "California", TestName = "Pasirenkame 2 reiksmes ir patikriname pirma pasirinkima")]
        [TestCase("Washington", "Ohio", "Texas", TestName = "Pasirenkame 3 reiksmes ir patikriname pirma pasirinkima")]
        public void TestMultipleDropdown(params string[] selectedElements)
        {
            _dropdownDemoPage.NavigateToDefaultPage()
                             .SelectFromMultipleDropdownAndClickFirstButton(selectedElements.ToList())
                             .CheckFirstState(selectedElements[0]);
        }

        [TestCase("New Jersey", "California", TestName = "Pasirenkame 2 reiksmes ir patikriname visus pasirinkimus")]
        [TestCase("Washington", "Ohio", "Texas", "Florida", TestName = "Pasirenkame 4 reiksmes ir patikriname visus pasirinkimus")]
        public void TestMultipleDropdownGetAll(params string[] selectedElements)
        {
            _dropdownDemoPage.NavigateToDefaultPage()
                             .SelectFromMultipleDropDownByValue(selectedElements.ToList())
                             .ClickGetAllButton();
        }
    }


}
