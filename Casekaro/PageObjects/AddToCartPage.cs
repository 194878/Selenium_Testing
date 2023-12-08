using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casekaro.PageObjects
{
    internal class AddToCartPage
    {
        IWebDriver driver;
        public AddToCartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        [FindsBy(How = How.Id, Using = "AddToCartText-product-template")]
        IWebElement? AddtoCartButtonLink { get; set; }
        public PlaceOrderPage AddtoCartButtn()
        {
            AddtoCartButtonLink.Click();
            return  new PlaceOrderPage(driver);
        }
    }
}
