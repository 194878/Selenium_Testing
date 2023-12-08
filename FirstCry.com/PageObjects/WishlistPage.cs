using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCry.com.PageObjects
{
    internal class WishlistPage
    {
        IWebDriver driver;
        public WishlistPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//span[@class='p_shortlist_like shtl-icon']")]
        IWebElement? ShortListBtnLink { get; set; }

        public void ShortListBtnLinkClick()
        {
            ShortListBtnLink.Click();
        }
    }
}
