using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casekaro.PageObjects
{
    internal class PlaceOrderPage
    {
        IWebDriver driver;
        public PlaceOrderPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//button[@onclick='initiateGokwik()']")]
        IWebElement? PlaceOrderBtnLink { get; set; }
        public void PlaceOrderBtnClk()
        {
            PlaceOrderBtnLink.Click();
            Thread.Sleep(5000);
        }

    }
}
