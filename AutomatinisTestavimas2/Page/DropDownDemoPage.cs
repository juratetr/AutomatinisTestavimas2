using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2.Page
{
    public class DropDownDemoPage : BasePage
    {
        private const string PageAddress = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        private const string ResultText = "Day selected :- ";
        private SelectElement _DropDown => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private IWebElement _ResultTextElement => Driver.FindElement(By.CssSelector(".selected-value"));
        private SelectElement _MultiDropDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        private IWebElement _FirstSelectedButton => Driver.FindElement(By.Id("printMe"));
        private IWebElement _GetAllSelectedButton => Driver.FindElement(By.Id("printAll"));

        public DropDownDemoPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }

        public DropDownDemoPage SelectFromDropdownByText(string text)
        {
            _DropDown.SelectByText(text);
            return this;
        }
        public DropDownDemoPage SelectFromDropdownByValue(string text)
        {
            _DropDown.SelectByValue(text);
            return this;
        }
        public DropDownDemoPage VerifyResult(string selectedDay)
        {
            Assert.IsTrue(_ResultTextElement.Text.Equals(ResultText + selectedDay), $"Result is wrong, not {selectedDay}");
            return this;
        }
        public DropDownDemoPage SelectFromMultipleDropdownByValue(List<string> listOfStates)
        {
            _MultiDropDown.DeselectAll();
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.LeftControl);
            foreach (string state in listOfStates)
            {
                foreach (IWebElement option in _MultiDropDown.Options)
                {
                    if (state.Equals(option.GetAttribute("value")))
                    {
                        action.Click(option);
                        break;
                    }
                }
            }
            action.KeyUp(Keys.LeftControl);
            action.Build().Perform();
            action.Click(_FirstSelectedButton);
            action.Build().Perform();
            return this;
        }
        public DropDownDemoPage ClickGetAllButton()
        {
            _GetAllSelectedButton.Click();
            return this;
        }

        public void SelectFromMultipleDropDownByValue1(string firstValue, string secondValue)
        {
            Actions actions = new Actions(Driver);
            _MultiDropDown.SelectByValue(firstValue);
            actions.KeyDown(Keys.Control);
            _MultiDropDown.SelectByValue(secondValue);
            actions.KeyUp(Keys.Control);
            actions.Build().Perform();
        }
        public DropDownDemoPage ClickFirstSelectedButton()
        {
            _FirstSelectedButton.Click();
            return this;
        }

        public DropDownDemoPage ClickAllSelectedButton()
        {
            _GetAllSelectedButton.Click();
            return this;
        }

    }




}
