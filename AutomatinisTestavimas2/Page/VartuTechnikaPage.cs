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
    public class VartuTechnikaPage : BasePage
    {
        
        private const string PageAddress = "https://vartutechnika.lt/";
        private IWebElement _widthInput => Driver.FindElement(By.Id("doors_width"));
        private IWebElement _heightInput => Driver.FindElement(By.Id("doors_height"));
        private IWebElement _autoCheckBox => Driver.FindElement(By.Id("automatika"));
        private IWebElement _MontavimoCheckBox => Driver.FindElement(By.Id("darbai"));
        private IWebElement _calculateButton => Driver.FindElement(By.Id("calc_submit"));
        private IWebElement _resultBox => Driver.FindElement(By.CssSelector("#calc_result > div"));

        public VartuTechnikaPage(IWebDriver webdriver) : base(webdriver)
        {
            
        }
        public VartuTechnikaPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
                return this;
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
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
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
