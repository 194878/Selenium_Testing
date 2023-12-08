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
    internal class SupportPage
    {
        IWebDriver driver;
        public SupportPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "contactdet")]
        IWebElement? ContactDetails { get; set; }
        [FindsBy(How = How.Id, Using = "customercare")]
        IWebElement? CustomerCareLink { get; set; }

        public void ContactDetailsLink()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(By.ClassName("club-block"))).Build().Perform();

            ContactDetails.Click();
        }
        public void CustomerCareClick()
        {
            CustomerCareLink.Click();
        }
    }
}
