using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomatinisTestavimas2
{
    internal class IwebDriver
    {
        public string Url { get; internal set; }

        public static implicit operator IwebDriver(ChromeDriver v)
        {
            throw new NotImplementedException();
        }

        internal void Quit()
        {
            throw new NotImplementedException();
        }

        internal IWebElement FindElement(By by)
        {
            throw new NotImplementedException();
        }

        internal object Navigate()
        {
            throw new NotImplementedException();
        }

        internal object Manage()
        {
            throw new NotImplementedException();
        }
    }
}