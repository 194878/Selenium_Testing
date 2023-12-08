using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FirstCry.com.PageObjects
{
    internal class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "search_box")]
         IWebElement? SearchBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='anch poplogin_main poplogin R12_61']")]
        IWebElement? LoginHomePageLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='anch Register_popup Register R12_61']")]
        IWebElement? RegisterHomePageLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='FirstCry Parenting']")]
        IWebElement? ParentingHomePageLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@title='Firstcry.com - Online Baby & Kids Store']")]
        IWebElement? HomeIconLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Support']")]
        IWebElement ? HomeSupportLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Stores & Preschools']")]
        IWebElement? StoresLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Find Stores']")]
        IWebElement? FindStoresLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@id='sh']")]
        IWebElement? ShortListLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='ALL CATEGORIES']")]
        IWebElement? BoysFashionClkLink { get; set; }

        [FindsBy(How = How.Id, Using = "qcro")]
        IWebElement? QuickReorderClkLink { get; set; }
        [FindsBy(How = How.Id, Using = "track")]
        IWebElement? TrackorderClkLink { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Diapering']")]
        IWebElement? DiaperingClkLink { get; set; }





        public SearchProductPage SearchProduct(string? search)
        {
            
            SearchBox.Clear();
            SearchBox.SendKeys(search);
            SearchBox.SendKeys(Keys.Enter);

            return new SearchProductPage(driver);
        }
        public LoginPage LoginHomeClick()
        {
            LoginHomePageLink.Click();
            return new LoginPage(driver);
        }
        public ParentingPage ParentingHomePageClick()
        {
            
            ParentingHomePageLink.Click();
            return new ParentingPage(driver);
        }
        public void HomeIconLinkClick()
        {
            HomeIconLink.Click();
        }
        public SupportPage HomePageSupportClick()
        {
            HomeSupportLink.Click();
            return new SupportPage(driver);
        }
        public void StoresLinkClick()
        {
            StoresLink.Click();
        }
        public StoreLocatorPage FindStoreLinkClick()
        {
            FindStoresLink.Click();
            return new StoreLocatorPage(driver);
        }
        public void ShortListClick()
        {
            ShortListLink.Click();
        }
        public void BoysFashionClick()
        {
            BoysFashionClkLink.Click();
        }
        public void QuickReorderClick()
        {
            QuickReorderClkLink.Click();
        }
        public void TrackorderClick()
        {
            TrackorderClkLink.Click();
        }
        public void DiaperingClick()
        {
            DiaperingClkLink.Click();
        }
    }
}
