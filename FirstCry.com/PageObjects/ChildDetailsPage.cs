using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCry.com.PageObjects
{
    internal class ChildDetailsPage
    {
        IWebDriver driver;
        public ChildDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "child_date")]
        public IWebElement DOBlink { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@alt='logo']")]
        public IWebElement CalenderLink { get; set; }

        [FindsBy(How = How.Id, Using = "child-name")]
        public IWebElement ChildNamelink { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Girl']")]
        public IWebElement ChildGenderlink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='child_details_btn_view']//button[@type='button'][normalize-space()='Submit']")]
        public IWebElement SubmitBtnlink { get; set; }

        public void DOBLinkType()
        {
            Actions actions = new Actions(driver);
            actions.DoubleClick(CalenderLink).Build().Perform();
        }
        public void CalenderLinkClk()
        {
            CalenderLink.Click();
        }
        public void ChildNameType(string? childname)
        {
            ChildNamelink.SendKeys(childname);
        }
        public void ChildGenderType()
        {
            ChildGenderlink.Click();

        }
        public void SubmitBtnClick()
        {
            SubmitBtnlink.Click();
        }

    }
}

