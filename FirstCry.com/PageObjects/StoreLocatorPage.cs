
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCry.com.PageObjects
{
    internal class StoreLocatorPage
    {
        IWebDriver driver;
        public StoreLocatorPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "storetype")]
        IWebElement? StoreTypeLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//option[text()='Babyhug']")]
        IWebElement? StoreTypeSelectLink { get; set; }

        [FindsBy(How = How.ClassName, Using = "sel_lst")]
        IWebElement? SelectStateLink{ get; set; }

        [FindsBy(How = How.XPath, Using = "//option[text()='Kerala']")]
        IWebElement? SelectStatePickLink { get; set; }

        [FindsBy(How = How.ClassName, Using = "sel_lst")]
        IWebElement? SelectCityLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//option[text()='Thodupuzha Temple Byepass']")]
        IWebElement? SelectCityPickLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Search']")]
        IWebElement? SearchBtnLink { get; set; }

        public void StoreTypeLinkClick()
        {
            List<string> list = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(list[1]);
            StoreTypeLink.Click();
        }
        public void StoreTypeLinkSelectClk()
        {
            StoreTypeSelectLink.Click();
        }
        public void SelectStateLinkClick()
        {
            SelectStateLink.Click();
        }
        public void SelectStatePickLinkClick()
        {
            SelectStatePickLink.Click();
        }
        public void SelectCityClick()
        {
            SelectCityLink.Click();
        }
        public void SelectCityPick()
        {
            SelectCityPickLink.Click();
        }
        public void SearchBtnClk()
        {
            SearchBtnLink.Click();
        }
    }
}
