using AutomatinisTestavimas2.Drivers;
using AutomatinisTestavimas2.Page;
using AutomatinisTestavimas2.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static DropDownDemoPage _dropdownDemoPage;
        public static VartuTechnikaPage _vartuTechnikaPage;
        public static SebPage _sebPage;
        public static SenukaiPage _senukaiPage;
        public static AlertPage _alertPage;

        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetIncognitoChrome();
            _dropdownDemoPage = new DropDownDemoPage(driver);
            _vartuTechnikaPage = new VartuTechnikaPage(driver);
            _sebPage = new SebPage(driver);
            _senukaiPage = new SenukaiPage(driver);
            _alertPage = new AlertPage(driver);
        }

        [TearDown]
        public static void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreenshot(driver);
        }
       
        [OneTimeTearDown]

        public static void TearDown()
        {
            // driver.Quit(); 
        }
    }


}
