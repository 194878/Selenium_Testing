using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casekaro.PageObjects
{
    internal class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this); 
        }
        [FindsBy(How = How.XPath, Using = "//button[@class='btn--link site-header__icon site-header__search-toggle js-drawer-open-top']")]
        IWebElement? SearchbuttonLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='search__input search-bar__input']")]
        IWebElement? SearchLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='site-header__icon site-header__account']")]
        IWebElement? LoginIconLink { get; set; }

        public ProductPage  SearchPro(string? search)
        {
            SearchbuttonLink.Click();
            SearchLink.SendKeys(search);
            SearchLink.SendKeys(Keys.Enter);
            return new ProductPage(driver);
        }
        public LoginPage LoginIconClk()
        {
            LoginIconLink.Click();
            return new LoginPage(driver);
        }
    }
}
