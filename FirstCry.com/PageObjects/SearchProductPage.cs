using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCry.com.PageObjects
{
    internal class SearchProductPage
    {
        IWebDriver driver;
        public SearchProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
         
        }

        [FindsBy(How = How.XPath, Using = "//img[@title='Babyhug Twill Floral Embroidered Frock with Full Sleeves Polka Dots Printed Inner Tee - Pink']")]
        IWebElement? SearchProduct { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='sort-select-content L12_42']")]
        IWebElement ? SortByLink { get; set; }

        [FindsBy(How=How.XPath,Using = "//a[normalize-space()='Best Seller']")]
        IWebElement BestSellerLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Bath Time')]")]
        IWebElement? BathTimeFilterLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@title='Mom']")]
        IWebElement? SelectFilterProduct { get; set; }






        public AddToCartPage ClickOnDress()
        {
            Actions actions = new Actions(driver);
            Action performActions = () => actions.MoveToElement(SearchProduct).Build().Perform();
            performActions.Invoke();
            SearchProduct.Click();
            List<string> list = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(list[1]);
            return new AddToCartPage(driver);
        }
        public void SortByLinkClick()
        {
            SortByLink.Click();
            Thread.Sleep(4000);
            
            
        }
        public void BestSellerLinkClick() { 
        BestSellerLink.Click();
        }
        public void BathTimeFilterLinkClick()
        {
            Actions actions = new Actions(driver);
            Action performActions = () => actions.MoveToElement(BathTimeFilterLink).Build().Perform();
            performActions.Invoke();
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(6);
            wait.Until(d => BathTimeFilterLink.Displayed);

            BathTimeFilterLink.Click();
        }
        public WishlistPage SelectFilterProductClick()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(6);
            wait.Until(d => SelectFilterProduct.Displayed);
            SelectFilterProduct.Click();
            List<string> list = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(list[1]);
            return new WishlistPage(driver);
        }
        
       
    }
}
