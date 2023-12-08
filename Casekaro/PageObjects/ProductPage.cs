using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casekaro.PageObjects
{
    internal class ProductPage
    {
        IWebDriver driver;
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[5]/main[1]/ul[1]/li[3]/div[1]/a[1]")]
        IWebElement? SelectProductLink { get; set; }
        public AddToCartPage SelectProduct()
        {
            SelectProductLink.Click();
            return new AddToCartPage(driver);
        }
    }
}
