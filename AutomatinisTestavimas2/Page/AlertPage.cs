using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2.Page
{
    public class AlertPage : BasePage
    {
        private const string PageAddress = "https://www.seleniumeasy.com/test/javascript-alert-box-demo.html";
        private IWebElement _AlertButton => Driver.FindElement(By.XPath("//button[@onclick='myAlertFunction()']"));
        private IWebElement _ConfirmationAlertButton => Driver.FindElement(By.XPath("//button[@onclick='myConfirmFunction()']"));
        private IWebElement _PromptAlertButton => Driver.FindElement(By.XPath("//button[@onclick='myPromptFunction()']"));

        public AlertPage(IWebDriver webdriver) : base(webdriver)
        {
        }
        public AlertPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public AlertPage ClickAlertButton()
        {
            _AlertButton.Click();
            return this;
        }

        public AlertPage AcceptAlert()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Accept();
            return this;
        }
        public AlertPage ClickConfirmationAlertButton()
        {
            _ConfirmationAlertButton.Click();
            return this;
        }

        public AlertPage DismissConfirmationAlert()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Dismiss();
            return this;
        }
        public AlertPage ClickPromptAlertButton()
        {
            _PromptAlertButton.Click();
            return this;
        }
        public AlertPage InsertTextAndAcceptPromptAlert(string text)
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.SendKeys(text);
            alert.Accept();
            return this;
        }

    }
}
