using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casekaro.PageObjects
{
    internal class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "customer_register_link")]
        IWebElement? CreateAccntClkLink { get; set; }
        public RegisterPage CreateAccntClk()
        {
            CreateAccntClkLink.Click();
            return new RegisterPage(driver);
        }
    }
}
