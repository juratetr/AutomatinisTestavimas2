using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSc;

namespace AutomatinisTestavimas2.Page
{
    public class VartuTechnikaPage 
    {
        private static IWebDriver _driver;

        private IWebElement _widthInput => _driver.FindElement(By.Id("doors_width"));
        private IWebElement _heightInput => _driver.FindElement(By.Id("doors_height"));
        private IWebElement _autoCheckBox => _driver.FindElement(By.Id("automatika"));
        private IWebElement _MontavimoCheckBox => _driver.FindElement(By.Id("darbai"));
        private IWebElement _calculateButton => _driver.FindElement(By.Id("calc_submit"));
        private IWebElement _resultBox => _driver.FindElement(By.CssSelector("#calc_result > div"));

        public VartuTechnikaPage(IWebDriver webdriver) 
        {
           _driver = webdriver;
        }

        public VartuTechnikaPage InsertWidth(string width)
        {
            _widthInput.Clear();
            _widthInput.SendKeys(width);
            return this;
        }
        public VartuTechnikaPage InsertHight(string height)
        {
            _heightInput.Clear();
            _heightInput.SendKeys(height);
            return this;
        }

        public VartuTechnikaPage InsertWidthAndHeight(string width, string height)
        {
            InsertWidth(width);
            InsertHight(height);
            return this;
        }

        public VartuTechnikaPage CheckAutomatikaCheckBox(bool shouldBeChecked)
        {
            if (shouldBeChecked != _autoCheckBox.Selected)
                _autoCheckBox.Click();
            return this;
        }
         public VartuTechnikaPage CheckMontavimoCheckBox(bool shouldBeChecked)
        {
            if (shouldBeChecked != _MontavimoCheckBox.Selected)
                _MontavimoCheckBox.Click();
            return this;
        }

        public VartuTechnikaPage ClickCalculateButton()
        {
            _calculateButton.Click();
            return this;
        }

        private VartuTechnikaPage WaitForResult()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => _resultBox.Displayed);
            return this;
        }

        public VartuTechnikaPage CheckResult(string expectedResult)
        {
            Assert.IsTrue(_resultBox.Text.Contains(expectedResult), $"Result is not the same, expected { expectedResult}, but was { _resultBox.Text}");
            return this;
        }



    }
}
