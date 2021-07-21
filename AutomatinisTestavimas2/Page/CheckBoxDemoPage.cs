using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSc;

namespace AutomatinisTestavimas2.Page
{
    public class CheckBoxDemoPage : BasePage
    {
        

        private IWebElement _firstCheckBox => Driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement _textBox => Driver.FindElement(By.Id("txtAge"));
        private IReadOnlyCollection<IWebElement> _multipleCheckBoxList => Driver.FindElements(By.CssSelector(".cb1-element"));
        private IWebElement _checkAllButton => Driver.FindElement(By.Id("check1"));
        

        public CheckBoxDemoPage (IWebDriver webdriver) : base(webdriver)
        {
            
        }

        public CheckBoxDemoPage SelectFirstCheckBox()
        {
            _firstCheckBox.Click();
            return this;
        }
        public CheckBoxDemoPage CheckText()
        {
            Assert.IsTrue(_textBox.Text.Equals("Success - Check box is checked"), "Neatsirado “Success - Check box is checked” pranešimas.");
            return this;
        }

        public CheckBoxDemoPage DeselectFirstCheckBox()
        {            
            if (_firstCheckBox.Selected)
                _firstCheckBox.Click();
            return this;
        }

        public CheckBoxDemoPage SelectAllElementsOfMultipleCheckBox()
        {
            
            foreach (IWebElement element in _multipleCheckBoxList)
            {
                element.Click();
            }
            return this;
        }

        public CheckBoxDemoPage UncheckAllButtonApeared()
        {
            
            Assert.IsTrue(_checkAllButton.GetAttribute("value").Contains("Uncheck All"), "Mygtukas nepersivadino į “Uncheck All”.");
            
            return this;
        }

        public CheckBoxDemoPage UncheckMultipleCheckBox()
        {            
            if (_firstCheckBox.Selected)
                _firstCheckBox.Click();
            
            foreach (IWebElement element in _multipleCheckBoxList)
                {  
                    element.Click();
                }
            
            return this;
        }

    }
}
