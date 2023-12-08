using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCry.com.PageObjects
{
    internal class GoToCartPage
    {
        IWebDriver driver;
        public GoToCartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//label[text()=' Login to place order ']")]

        IWebElement ? LoginToPlaceOrderBtn { get; set; }

        public void LoginToPlaceOrderBtnClk()
        {
            LoginToPlaceOrderBtn.Click();
        }
    }
}
