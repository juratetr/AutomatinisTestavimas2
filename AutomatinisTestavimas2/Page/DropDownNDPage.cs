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
    public class DropDownNDPage : BasePage
    {
        private const string PageAddress = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        private const string ResultTextFirstSelected = "First selected option is : ";
        
        private SelectElement _MultiDropDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        private IWebElement _FirstSelectedButton => Driver.FindElement(By.Id("printMe"));
        private IWebElement _GetAllSelectedButton => Driver.FindElement(By.Id("printAll"));
        private IWebElement _ResultTextElement => Driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > p.getall-selected"));
        


        public DropDownNDPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }

        public DropDownNDPage SelectFromMultipleDropdownByValue(List<string> listOfStates)
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

        internal void VerifyResultAllSelected(bool v)
        {
            throw new NotImplementedException();
        }

        public DropDownNDPage ClickGetAllSelectedButton()
        {
            _GetAllSelectedButton.Click();
            return this;
        }
                
        public DropDownNDPage ClickFirstSelectedButton()
        {
            _FirstSelectedButton.Click();
            return this;
        }

       
        public DropDownNDPage VerifyResultFirstSelected(string firstSelectedState)
        {
            Assert.IsTrue(_ResultTextElement.Text.Equals(ResultTextFirstSelected + firstSelectedState), $"Result is wrong, not {firstSelectedState}");
            return this;
        }
        public DropDownNDPage VerifyResultAllSelected(params string[] selectedElements)
        {
            string result = _ResultTextElement.Text;

            foreach (string i in selectedElements)
            { 
                Assert.True(result.Contains(i), $"{i} is missing. {result}");
            }
            return this;
        }
      
        public DropDownNDPage DeselectAll()
        {
            _MultiDropDown.DeselectAll();
            return this;
        }
    }
}
