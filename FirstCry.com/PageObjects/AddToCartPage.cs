using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCry.com.PageObjects
{
    internal class AddToCartPage
    {
        IWebDriver driver;
        public AddToCartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//span[text()='9 - 12 M']")]
        public IWebElement DressSize { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='ADD TO CART']")]
        public IWebElement AddToCartButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='step2 M16_white']")]
        public IWebElement GoToCartButton { get; set; }


        public void SizeSelect()
        {
            DressSize.Click();
        }
        public void AddToCart()
        {
            AddToCartButton.Click();
        }
        public GoToCartPage GoToCartClick()
        {
            GoToCartButton.Click();
            return new GoToCartPage(driver);
        }
    }
}
